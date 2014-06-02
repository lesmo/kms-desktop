using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Linq;

namespace KMS.Desktop.Animation {

    class Animator2 {
        public const Int32 DefaultDuration = 300;
        private const Int32 GlobalTimerInterval = 10;
        
        private IAnimationEasing m_easing;
        private Action<Int32> m_propertyAssigner;
        private Int32 m_propertyInitialValue;
        private Int32 m_propertyTargetValue;
        private Int32 m_elapsedTime = 0;

        private Boolean m_stopRequested = false;
        private String m_propertyName;

        private event EventHandler m_animationFinished;
        public event EventHandler AnimationFinished {
            add {
                if ( m_elapsedTime >= Duration )
                    OnAnimationFinished(value);
                else
                    m_animationFinished += value;
            }
            remove {
                m_animationFinished -= value;
            }
        }

        public Control TargetControl {
            get;
            private set;
        }

        public Int32 Duration {
            get;
            private set;
        }

        public Animator2(Control targetControl, PropertyInfo targetProperty, Int32 targetValue, Int32 duration = DefaultDuration) {
            TargetControl = targetControl;
            Duration      = duration;

            m_propertyName         = targetProperty.Name;
            m_propertyTargetValue  = targetValue;
            m_propertyInitialValue = (Int32)targetProperty.GetValue(targetControl, null);
            m_propertyAssigner     = v => targetProperty.SetValue(targetControl, v, null);
        }

        public void Enqueue() {
            m_easing = new EaseInOutBack();
            Animator2.Enqueue(this);
        }

        public void Enqueue<TEasing>() where TEasing : IAnimationEasing {
            m_easing = Activator.CreateInstance<TEasing>();
            Animator2.Enqueue(this);
        }

        public void Stop() {
            m_stopRequested = true;
        }

        private void OnAnimationFinished() {
            OnAnimationFinished(m_animationFinished);
        }

        private void OnAnimationFinished(EventHandler eventDelegate) {
            if ( eventDelegate == null )
                return;

            var eventTarget = eventDelegate.Target as Control ?? TargetControl;
            eventTarget.BeginInvoke(eventDelegate, this, EventArgs.Empty);
        }

        private static System.Timers.Timer s_globalTimer;
        private static Dictionary<Control, Dictionary<String, Queue<Animator2>>> s_animatingObjects;
        static Animator2() {
            s_animatingObjects = new Dictionary<Control, Dictionary<String, Queue<Animator2>>>();
            s_globalTimer      = new System.Timers.Timer {
                Interval  = GlobalTimerInterval,
                AutoReset = true,
                Enabled   = true
            };

            s_globalTimer.Elapsed += GlobalTimer_Elapsed;
        }

        public static void Enqueue(Animator2 animator) {
            lock ( s_animatingObjects ) {
                Dictionary<String, Queue<Animator2>> animatingProperties;

                if ( ! s_animatingObjects.ContainsKey(animator.TargetControl) ) {
                    s_animatingObjects.Add(
                        animator.TargetControl,
                        new Dictionary<String, Queue<Animator2>> {
                            {animator.m_propertyName, new Queue<Animator2>()}
                        }
                    );
                }
            
                animatingProperties = s_animatingObjects[animator.TargetControl];
            
                if ( ! animatingProperties.ContainsKey(animator.m_propertyName) )
                    animatingProperties.Add(animator.m_propertyName, new Queue<Animator2>());
            
                animatingProperties[animator.m_propertyName].Enqueue(animator);
            }
        }

        public static void StopAnimation(Control control) {
            if ( control == null || control.IsDisposed || !s_animatingObjects.ContainsKey(control) ) {
                return;
            } else {
                lock ( s_animatingObjects ) {
                    var removeKeys = s_animatingObjects[control].Select(s => s.Key).ToArray();

                    foreach ( var key in removeKeys )
                        s_animatingObjects[control].Remove(key);
                }
            }
        }

        public static void StopAnimation(Control control, params String[] property) {
            if ( control == null || control.IsDisposed || !s_animatingObjects.ContainsKey(control) ) {
                return;
            } else {
                lock ( s_animatingObjects ) {
                    var removeKeys = s_animatingObjects[control].Where(w => property.Contains(w.Key)).Select(s => s.Key).ToArray();

                    foreach ( var key in removeKeys )
                        s_animatingObjects[control].Remove(key);
                }
            }
        }

        public static Boolean IsAnimating(Control control) {
            if ( control == null || control.IsDisposed || !s_animatingObjects.ContainsKey(control) ) {
                return false;
            } else {
                lock ( s_animatingObjects )
                    return s_animatingObjects.ContainsKey(control);
            }
        }

        public static Animator2 GetCurrentAnimator(Control control, String propertyName) {
            if ( control == null || control.IsDisposed || !s_animatingObjects.ContainsKey(control) || !s_animatingObjects[control].ContainsKey(propertyName) ) {
                return null;
            } else {
                lock ( s_animatingObjects ) {
                    if ( s_animatingObjects[control][propertyName].Count > 0 )
                        return s_animatingObjects[control][propertyName].Peek();
                    else
                        return null;
                }
            }
        }

        private static void GlobalTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
            lock ( s_animatingObjects ) {
                var controlsToRemove = new List<Control>();
                foreach ( var control in s_animatingObjects ) {
                    if ( control.Key.IsDisposed || control.Value.Count == 0 ) {
                        controlsToRemove.Add(control.Key);
                        continue;
                    }

                    var propertiesToRemove = new List<String>();

                    foreach ( var property in control.Value ) {
                        if ( property.Value.Count == 0 ) {
                            propertiesToRemove.Add(property.Key);
                            continue;
                        }

                        var currentAnimator = property.Value.Peek();
                        if ( currentAnimator.m_elapsedTime >= currentAnimator.Duration || currentAnimator.m_stopRequested ) {
                            if ( ! currentAnimator.m_stopRequested )
                                currentAnimator.OnAnimationFinished();

                            property.Value.Dequeue();

                            if ( property.Value.Count > 0 )
                                currentAnimator = property.Value.Peek();
                            else
                                continue;
                        }

                        if ( ! currentAnimator.m_easing.Initialized || currentAnimator.m_elapsedTime < s_globalTimer.Interval )
                            currentAnimator.m_easing.Initialize(
                                currentAnimator.m_propertyInitialValue,
                                currentAnimator.m_propertyTargetValue,
                                currentAnimator.Duration
                            );

                        currentAnimator.m_elapsedTime += (Int32)s_globalTimer.Interval;

                        control.Key.BeginInvoke(
                            currentAnimator.m_propertyAssigner,
                            currentAnimator.m_easing.Ease(currentAnimator.m_elapsedTime)
                        );
                    }

                    foreach ( var property in propertiesToRemove )
                        control.Value.Remove(property);
                }

                foreach ( var control in controlsToRemove )
                    s_animatingObjects.Remove(control);
            }
        }
    }
}

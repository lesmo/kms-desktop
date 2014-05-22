using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using KMS.Desktop.Animation;

namespace KMS.Desktop.Utils {

    static class ObjectAnimation {
        private static Dictionary<Object, List<Animation.Animator2>> AnimatingControls =
            new Dictionary<Object, List<Animation.Animator2>>();

        public static Animator2 AnimateProperty(
            this Control @this,
            String propertyName,
            Int32 targetValue,
            Int32 duration = Animator2.DefaultDuration
        ) {
            var property = typeof(Control).GetProperty(propertyName);
            var animator = new Animator2(@this, property, targetValue, duration);
            animator.Enqueue();

            return animator;
        }

        public static Animator2 AnimateProperty<TEasing>(
            this Control @this,
            String propertyName,
            Int32 targetValue,
            Int32 duration = Animator2.DefaultDuration
        ) where TEasing : IAnimationEasing {
            var property = typeof(Control).GetProperty(propertyName);
            var animator = new Animator2(@this, property, targetValue, duration);
            animator.Enqueue<TEasing>();

            return animator;
        }

        public static void StopAnimation(this Control @this) {
            Animator2.StopAnimation(@this);
        }

        public static void StopAnimation(this Control @this, params String[] properties) {
            Animator2.StopAnimation(@this, properties);
        }

        public static Boolean IsAnimating(this Control @this) {
            return Animator2.IsAnimating(@this);
        }

        public static Animator2 GetCurrentAnimator(this Control @this, String propertyName) {
            return Animator2.GetCurrentAnimator(@this, propertyName);
        }
    }
}

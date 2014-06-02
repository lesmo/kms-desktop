using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using KMS.Desktop.Utils;
using System.Diagnostics;

namespace KMS.Desktop {
    partial class MainWindow {

        private LinkedList<UserControl> m_panelHistory = new LinkedList<UserControl>();
        private LinkedListNode<UserControl> m_currentPanelNode;

        public UserControl CurrentPanel {
            get {
                return m_currentPanelNode == null ? null : m_currentPanelNode.Value;
            }
        }

        /// <summary>
        ///     Realiza la navegación al siguiente Panel T, transmitiéndole información
        ///     para su inicialización.
        /// </summary>
        /// <typeparam name="T">Tipo del Panel.</typeparam>
        /// <param name="data">Información a enviar al Panel durante su inicialización.</param>
        /// <returns>Devuelve la instancia del nuevo Panel, ya inicializado.</returns>
        public T NextPanel<T>() where T : UserControl {
            // Revisar si es necesaio un Invoke.
            if ( InvokeRequired ) {
                return (T)Invoke(
                    new Func<UserControl>(() => NextPanel<T>())
                );
            }

            UserControl nextPanel    = null;
            UserControl currentPanel = null;

            var initializePanel    = false;
            var hidePreviousButton = false;

            if ( m_currentPanelNode == null || m_currentPanelNode.Value == null ) {
                // Insertar el nuevo Panel como primer elemento de la lista.
                nextPanel          = Activator.CreateInstance<T>() as UserControl;
                m_currentPanelNode = m_panelHistory.AddFirst(nextPanel);
                initializePanel    = true;
                hidePreviousButton = true;
            } else {
                currentPanel = m_currentPanelNode.Value;

                if ( m_currentPanelNode.Next == null || m_currentPanelNode.Next.Value == null || !(m_currentPanelNode.Next.Value is T) ) {
                    // Insertar el nuevo Panel como el siguiente del Panel actual.
                    nextPanel = Activator.CreateInstance<T>() as UserControl;
                    m_currentPanelNode = m_panelHistory.AddAfter(m_currentPanelNode, nextPanel);
                    initializePanel = true;
                } else {
                    // Navegar al siguiente Panel que ya se encuentra en memoria.
                    m_currentPanelNode = m_currentPanelNode.Next;
                    nextPanel = m_currentPanelNode.Value;
                }
            }

            Trace.WriteLine("Panel switch [>] " + nextPanel.ToString());

            // Mostrar u ocultar el botón Atrás según sea necesario.
            if ( nextPanel is Panels.IPanelNoBackButton || hidePreviousButton )
                BackButton.Hide();
            else
                BackButton.Show();
            
            // Preparar las animaciones de los Paneles.
            nextPanel.Parent  = MainPanel;
            nextPanel.Top     = 0;
            nextPanel.Left    = nextPanel.Width + 30;
            nextPanel.Enabled = true;
            nextPanel.CreateControl();
            nextPanel.Show();
            nextPanel.BringToFront();

            var animateNext = new EventHandler((Object s1, EventArgs e1) => {
                MainPanel.StopAnimation("Height", "Width");

                if ( nextPanel.Width != MainPanel.Width )
                    MainPanel.AnimateProperty<Animation.EaseInOutBack>("Width", nextPanel.Width);
                
                MainPanel.AnimateProperty<Animation.EaseInOutBack>("Height", nextPanel.Height).AnimationFinished +=
                    (Object s2, EventArgs e2) => nextPanel.AnimateProperty<Animation.EaseInOutElastic>("Left", 0);
            });

            if ( currentPanel == null ) {
                animateNext(null, null);
            } else {
                var animator         = currentPanel.GetCurrentAnimator("Left");
                currentPanel.Enabled = false;
                nextPanel.Left       = (currentPanel.Left > 0 ? CurrentPanel.Left : 0) + currentPanel.Width + 30;

                if ( animator == null ) {
                    animator = currentPanel.AnimateProperty<Animation.EaseInOutElastic>("Left", -currentPanel.Width);
                    animator.AnimationFinished += animateNext;
                } else {
                    animator.AnimationFinished += (Object s2, EventArgs e2) =>
                        currentPanel.AnimateProperty<Animation.EaseInOutElastic>("Left", -currentPanel.Width).AnimationFinished +=
                            animateNext;
                }
            }
            
            // Inicializar el siguiente Panel si es necesario.
            if ( initializePanel )
                nextPanel.SizeChanged += Panel_SizeChanged;
            if ( initializePanel && nextPanel is Panels.IPanelInitialize )
                (nextPanel as Panels.IPanelInitialize).Initialize();

            // Ejecutar el evento de navegación en el Panel anterior.
            if ( currentPanel is Panels.IPanelNextEvent )
                (currentPanel as Panels.IPanelNextEvent).OnNextPanelNavigation();

            return (T)nextPanel;
        }

        void Panel_SizeChanged(object sender, EventArgs e) {
            var senderControl = sender as Control;

            if ( senderControl == null || senderControl != m_currentPanelNode.Value )
                return;

            MainPanel.StopAnimation("Height", "Width");
            MainPanel.AnimateProperty<Animation.EaseInOutBack>("Height", senderControl.Height);
            MainPanel.AnimateProperty<Animation.EaseInOutBack>("Width", senderControl.Width);
        }

        public void RemoveFromHistory<T>() {
            var panelNode = m_panelHistory.First;

            do {
                var nextPanelNode = panelNode.Next;

                if ( panelNode.Value is T && panelNode != m_currentPanelNode && panelNode != null && panelNode.Value != null ) {
                    Trace.WriteLine("Removed panel " + panelNode.Value.ToString());
                    
                    panelNode.Value.Parent  = null;
                    panelNode.Value.Enabled = false;
                    panelNode.Value.Hide();
                    panelNode.Value.Dispose();
                    panelNode.Value = null;

                    m_panelHistory.Remove(panelNode);
                }

                panelNode = nextPanelNode;
            } while ( panelNode != null );
        }

        /// <summary>
        ///     Realiza la navegación al Panel anterior.
        /// </summary>
        /// <returns>Devuelve la instancia del Panel anterior.</returns>
        public UserControl PreviousPanel() {
            // Revisar si es necesaio un Invoke.
            if ( InvokeRequired ) {
                return (UserControl)Invoke(
                    new Func<UserControl>(() => PreviousPanel())
                );
            }

            if ( m_currentPanelNode == null || m_currentPanelNode.Value == null )
                throw new InvalidOperationException("There is exactly NO fucking panels in history.");

            if ( m_currentPanelNode.Previous == null || m_currentPanelNode.Previous.Value == null )
                throw new InvalidOperationException("There is no panel to go back to.");

            UserControl currentPanel  = m_currentPanelNode.Value;
            UserControl previousPanel = m_currentPanelNode.Previous.Value;
            m_currentPanelNode = m_currentPanelNode.Previous;

            Trace.WriteLine("Panel switch [<] " + previousPanel.ToString());

            // Mostrar u ocultar el botón Atrás según sea necesario.
            if ( previousPanel is Panels.IPanelNoBackButton || m_currentPanelNode.Previous == null )
                BackButton.Hide();
            else
                BackButton.Show();

            // Preparar las animaciones de los Paneles.
            previousPanel.Left    = -previousPanel.Width;
            previousPanel.Enabled = true;
            previousPanel.CreateControl();
            previousPanel.Show();
            previousPanel.BringToFront();

            currentPanel.Enabled = false;

            var animateNext = new EventHandler((Object s1, EventArgs e1) => {
                MainPanel.StopAnimation("Height", "Width");
                MainPanel.AnimateProperty<Animation.EaseInOutBack>("Width", previousPanel.Width);
                MainPanel.AnimateProperty<Animation.EaseInOutBack>("Height", previousPanel.Height).AnimationFinished +=
                    (Object s2, EventArgs e2) => previousPanel.AnimateProperty<Animation.EaseInOutElastic>("Left", 0);
            });

            var animator = currentPanel.GetCurrentAnimator("Left");
            var currentPanelOffset = (currentPanel.Width > previousPanel.Width ? currentPanel.Width : previousPanel.Width) + 30;

            if ( animator == null ) {
                animator = currentPanel.AnimateProperty<Animation.EaseInOutElastic>("Left", currentPanelOffset);
                animator.AnimationFinished += animateNext;
            } else {
                animator.AnimationFinished += (Object s2, EventArgs e2) =>
                    currentPanel.AnimateProperty<Animation.EaseInOutElastic>("Left", currentPanelOffset).AnimationFinished +=
                        animateNext;
            }

            // Ejecutar el evento de navegación en el Panel anterior.
            if ( currentPanel is Panels.IPanelPreviousEvent )
                (currentPanel as Panels.IPanelPreviousEvent).OnPreviousPanelNavigation();

            return previousPanel;
        }

        /// <summary>
        ///     Mostrar un Panel con la animación de "Cargando".
        /// </summary>
        /// <returns>Devuelve la instancia del Panel.</returns>
        public Panels.LoadingPanel ShowLoadingPanel() {
            return NextPanel<Panels.LoadingPanel>() as Panels.LoadingPanel;
        }

        /// <summary>
        ///     Mostrar un Panel con la animcación de "Cargando", que permite
        ///     la cancelación de cualquier proceso que se esté llevando a cabo.
        /// </summary>
        /// <returns></returns>
        public Panels.CancelableLoadingPanel ShowCancelableLoadingPanel() {
            RemoveFromHistory<Panels.CancelableLoadingPanel>();
            return NextPanel<Panels.CancelableLoadingPanel>() as Panels.CancelableLoadingPanel;
        }

        /// <summary>
        ///     Oculta el Panel con la animación de "Cargando", volviendo
        ///     al panel que se encuentra inmediatamente antes de éste en
        ///     el historial (normalmente el Panel que lo llamó).
        /// </summary>
        public void HideLoadingPanel() {
            if ( m_currentPanelNode != null && m_currentPanelNode.Value is Panels.LoadingPanelBase )
                PreviousPanel();
        }
    }
}

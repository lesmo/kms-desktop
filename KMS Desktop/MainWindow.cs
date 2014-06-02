using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KMS.Desktop.Utils;
using System.Reflection;
using System.Diagnostics;

namespace KMS.Desktop {
    partial class MainWindow : Form {
        /// <summary>
        ///     Patrón "Singleton". Genera una sola instancia de Main Window.
        /// </summary>
        public static MainWindow Instance {
            get {
                if ( m_instance == null )
                    m_instance = new MainWindow();

                return m_instance;
            }
        }
        private static MainWindow m_instance;

        private MainWindow() {
            InitializeComponent();

            // Establecer la tipografía a utilizar en todo el UI.
            Font = new Font("Open Sans", 8.3f);

            // Establecer un par de cosas que optimizan los procesos de dibujado.
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            typeof(Panel).InvokeMember(
                "DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                MainPanel,
                new object[] { true }
            );

            // Inicializar tamaño anterior del formulario.
            m_lastWindowWidth  = Width;
            m_lastWindowHeight = Height;
        }

        public Boolean BackButtonVisible {
            get {
                return BackButton.Visible;
            }
            set {
                BackButton.Visible = value;
            }
        }

        private void BackButton_Click(object sender, EventArgs e) {
            RemoveFromHistory<Panels.QuestionPanel>();
            RemoveFromHistory<Panels.LoadingPanelBase>();
            PreviousPanel();
        }

        private Int32 m_lastWindowHeight;
        private Int32 m_lastWindowWidth;

        private void MainWindow_SizeChanged(object sender, EventArgs e) {
            var xDelta = Width - m_lastWindowWidth;
            var yDelta = Height - m_lastWindowHeight;

            if ( Math.Abs(xDelta) != 1 )
                m_lastWindowWidth = Width;
            else
                xDelta = 0;

            if ( Math.Abs(yDelta) != 1 )
                m_lastWindowHeight = Height;
            else
                yDelta = 0;

            xDelta = xDelta / 2;
            yDelta = yDelta / 2;

            Int32 newX = DesktopLocation.X;
            Int32 newY = DesktopLocation.Y;

            if ( DesktopLocation.X - xDelta > SystemInformation.VirtualScreen.X && DesktopLocation.X - xDelta + Width < SystemInformation.VirtualScreen.X + SystemInformation.VirtualScreen.Width )
                newX -= xDelta;
            else if ( DesktopLocation.X - xDelta > SystemInformation.VirtualScreen.X )
                newX = SystemInformation.VirtualScreen.X + SystemInformation.VirtualScreen.Width - Width;

            if ( DesktopLocation.Y - yDelta > SystemInformation.VirtualScreen.Y && DesktopLocation.Y - yDelta + Height < SystemInformation.VirtualScreen.Y + SystemInformation.VirtualScreen.Height )
                newY -= yDelta;
            else if ( DesktopLocation.Y - yDelta > SystemInformation.VirtualScreen.Y )
                newY = SystemInformation.VirtualScreen.Y + SystemInformation.VirtualScreen.Height - Height;

            SetDesktopLocation(newX, newY);
        }

        private void MainPanel_SizeChanged(object sender, EventArgs e) {
            // Elimina el "flicker" cuando se redimensiona el Panel.
            MainPanel.Update();
        }
    }
}

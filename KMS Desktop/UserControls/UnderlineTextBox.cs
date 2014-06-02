using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using KMS.Desktop.Properties;

namespace KMS.Desktop.UserControls {
    public enum UnderlineTextBoxStatus {
        Good,
        Attention,
        Error
    }

    public partial class UnderlineTextBox : UserControl {
        /// <summary>
        ///     Evento lanzado cuando el Usuario pulsa la tecla ENTRAR del teclado.
        /// </summary>
        public event EventHandler EnterPressed;

        #region Propiedades para Tiempo de Diseño
        /// <summary>
        ///     Determina si debe utilizarse el carácter de contraseña
        ///     suministrado por el Sistema Operativo. Si es TRUE, la
        ///     Caja de Texto efectivamente se vuelve una entrada de
        ///     Contraseña.
        /// </summary>
        public Boolean UseSystemPasswordChar {
            get {
                return InnerTextBox.UseSystemPasswordChar;
            }
            set {
                InnerTextBox.UseSystemPasswordChar = value;
            }
        }

        /// <summary>
        ///     Color primario de la caja de Texto. Determina el color del
        ///     Texto dentro de la caja y la línea de subrayado.
        /// </summary>
        public new Color ForeColor {
            get {
                return base.ForeColor;
            }
            set {
                InnerTextBox.ForeColor = base.ForeColor = base.BackColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        ///     Color del Texto de Placeholder;
        /// </summary>
        public Color PlaceholderColor {
            get {
                return m_placeholderColor;
            }
            set {
                m_placeholderColor = value;
                this.Invalidate();
            }
        }
        private Color m_placeholderColor;

        /// <summary>
        ///     Color de fondo del Texto.
        /// </summary>
        public new Color BackColor {
            get {
                return InnerTextBox.BackColor;
            }
            set {
                InnerTextBox.BackColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        ///     Texto a mostrar como Placeholder (cuando no hay ningún dato).
        /// </summary>
        public String PlaceHolder {
            get;
            set;
        }

        /// <summary>
        ///     Tamaño de la línea debajo de la Caja de Texto.
        /// </summary>
        public Int32 UnderlineSize {
            get;
            set;
        }
        #endregion

        #region Propiedades para Tiempo de Ejecución
        /// <summary>
        ///     Texto actualmente en la Caja de Texto.
        /// </summary>
        public new String Text {
            get {
                return m_text;
            }
            set {
                InnerTextBox.Text = m_text = value;
            }
        }
        private String m_text = "";
        #endregion

        #region Eventos Internos
        private void UnderlineTextBox_SizeChanged(object sender, EventArgs e) {
            Height = InnerTextBox.Height + UnderlineSize;
        }

        private void InnerTextBox_Enter(object sender, EventArgs e) {
            if ( m_text.Length == 0 )
                InnerTextBox.Select(0, 0);
        }

        private void InnerTextBox_CheckToClear(object sender, EventArgs e) {
            if ( InnerTextBox.Text.Length == 0 || InnerTextBox.Text.ToUpper() == PlaceHolder.ToUpper() ) {
                InnerTextBox.Text = PlaceHolder;
                InnerTextBox.ForeColor = PlaceholderColor;
                m_text = "";
            }
        }

        private void UnderlineTextBox_Load(object sender, EventArgs e) {
            UnderlineTextBox_SizeChanged(this, new EventArgs());
            InnerTextBox_CheckToClear(this, new EventArgs());
        }

        private void InnerTextBox_KeyDown(object sender, KeyEventArgs e) {
            if ( m_text.Length == 0 ) {
                InnerTextBox.Clear();
                InnerTextBox.ForeColor = ForeColor;
            }

            if ( e.KeyCode == Keys.Enter ) {
                if ( EnterPressed  != null )
                    EnterPressed.Invoke(this, new EventArgs());
            }
        }

        private void InnerTextBox_KeyUp(object sender, KeyEventArgs e) {
            if ( InnerTextBox.Text.ToUpper() == PlaceHolder.ToUpper() ) {
                m_text = "";
                InnerTextBox.ForeColor = PlaceholderColor;
            } else {
                m_text = InnerTextBox.Text;
                InnerTextBox.ForeColor = ForeColor;
            }
        }
        private void InnerTextBox_TextChanged(object sender, EventArgs e) {
            OnTextChanged(e);
        }
        #endregion

        public UnderlineTextBox() {
            InitializeComponent();

            ForeColor        = ForeColor;
            PlaceholderColor = SystemColors.GrayText;
            UnderlineSize    = 1;
            BackgroundImage  = null;
        }

        private void InnerTextBox_Validating(object sender, CancelEventArgs e) {
            
        }
    }
}

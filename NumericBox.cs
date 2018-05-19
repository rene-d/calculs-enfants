// CalculsCE1 : programme d'entrainement au calcul - niveau CE1
// Copyright © 2011 René DEVICHI

// adapté de http://www.csharpfr.com/code.aspx?ID=31894

namespace CalculsCE1
{
    using System.Drawing;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(TextBox))] // Pour avoir un bel icone de Textbox dans la toolbox
    public class NumericBox : TextBox
    {
        public NumericBox()
        {
        }

        //* Désactiver les 6 lignes suivantes pour permettre le copier / coller */
        private const int WM_PASTE = 0x0302;
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg != WM_PASTE)
                base.WndProc(ref m);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            // Si la caractère tapé est numérique
            if (char.IsDigit(e.KeyChar))
            { 
                e.Handled = false; // Sinon, on laisse passer le caractère (On peut omettre cette ligne)
            }
            // Si le caractère tapé est un caractère de "controle" (Enter, backspace, ...), on laisse passer
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }
            // Et sinon, on gère toutes les autres touches tapées, et on en fait rien
            else e.Handled = true;

            if (this.Text.Length >= MaxLength)
            {
                if (this.SelectionLength == 0) 
                e.Handled = true;
            }
        }

        /// <summary>
        /// retourne le nombre ou lève une exception en cas d'erreur
        /// </summary>
        public int Integer
        {
            get
            {                
                return int.Parse(base.Text);                
            }
        }

        /// <summary>
        /// retourne le nombre ou int.MinValue en cas d'erreur
        /// </summary>
        public int Integer2
        {
            get
            {
                int result = int.MinValue;
                int.TryParse(base.Text, out result);
                return result;
            }
        }
    }
}

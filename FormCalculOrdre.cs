// CalculsCE1 : programme d'entrainement au calcul - niveau CE1
// Copyright © 2011 René DEVICHI

using System;
using System.Windows.Forms;

namespace CalculsCE1
{
    public partial class FormCalculOrdre : Form
    {
        public FormCalculOrdre()
        {
            InitializeComponent();
        }

        private void FormCalculOrdre_Load(object sender, EventArgs e)
        {
            ucResult.userControlCalcul = ucCalcul;

            ucCalcul.Init(3);

            this.AcceptButton = ucCalcul.AcceptButton;

            // titre de la fenêtre
            this.Text = ucCalcul.Text;

            ucCalcul.Focus();
        }

        private void ucCalcul_CheckResponse(object sender, EventArgs e)
        {
            ucResult.verifie();
        }

        private void ucCalcul_AlgoChanged(object sender, EventArgs e)
        {
            ucResult.encore();
        }
    }
}

// CalculsCE1 : programme d'entrainement au calcul - niveau CE1
// Copyright © 2011 René DEVICHI

using System;
using System.Windows.Forms;

namespace CalculsCE1
{
    public partial class FormCalculAlgo : Form
    {
        public algo[] algos = null;

        public FormCalculAlgo(params algo[] algos)
        {
            InitializeComponent();
            this.algos = algos;
        }

        private void FormCalculAlgo_Load(object sender, EventArgs e)
        {
            if (algos == null)
                return;

            ucResult.userControlCalcul = ucCalcul;

            ucCalcul.Init(algos); 

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

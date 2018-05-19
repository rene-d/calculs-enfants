// CalculsCE1 : programme d'entrainement au calcul - niveau CE1
// Copyright © 2011 René DEVICHI

using System;
using System.Windows.Forms;

namespace CalculsCE1
{
    public partial class FormBravo : Form
    {
        public FormBravo(string prenom)
        {
            InitializeComponent();

            label1.Text = string.Format("BRAVO {0} !", prenom.ToUpper());
            buttonOK.Enabled = false;
        }

        private void FormBravo_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop(); 
            buttonOK.Enabled = true;
            buttonOK.Focus();
        }
    }
}

// CalculsCE1 : programme d'entrainement au calcul - niveau CE1
// Copyright © 2011 René DEVICHI

using System;
using System.Windows.Forms;

namespace CalculsCE1
{
    /// <summary>
    /// fenêtre pour indiquer une erreur de calcul
    /// </summary>
    public partial class FormErreur : Form
    {
        private FormErreur()
        {
            InitializeComponent();
        }

        static public void Show(string operation)
        {
            FormErreur frm = new FormErreur();

            frm.label1.Text = operation;

            frm.timer1.Interval = 3000;
            frm.timer1.Start();

            frm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}

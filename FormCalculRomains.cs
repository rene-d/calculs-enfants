// CalculsCE1 : programme d'entrainement au calcul - niveau CE1
// Copyright © 2011 René DEVICHI

using System;
using System.Windows.Forms;

namespace CalculsCE1
{
    public partial class FormCalculRomains : Form, IUserControlCalcul
    {
        int inconnue;
        Random rand = new Random();

        public FormCalculRomains()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AcceptButton = buttonCheck;
            ucResult.userControlCalcul = this;

            ucResult.encore();
        }

        public ResultatCalcul Vérifie(out string resultat)
        {
            resultat = "";
            int saisie = textBoxZ.Integer;

            if (saisie != inconnue)
            {
                FormErreur.Show("Erreur, ce n'est pas ça !");

                resultat = "erreur";
                textBoxZ.Select();
                return ResultatCalcul.Erreur;
            }

            resultat = string.Format("chiffres romains: {0}", inconnue);
            
            buttonCheck.Enabled = false;
            return ResultatCalcul.OK;
        }

        public void Encore()
        { 
            if (checkBoxDifficile.Checked)
                inconnue = rand.Next(1, 4000);
            else
                inconnue = rand.Next(1, 101);

            textBoxL.Text = new RomanNumber(inconnue).RomanValue; 

            textBoxZ.Text = "";
            textBoxZ.Select();

            buttonCheck.Enabled = true;
        }

        public int Duree
        {
            get { return checkBoxDifficile.Checked ? 60 : 30; }
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            ucResult.verifie();
        }

        private void checkBoxDifficile_CheckedChanged(object sender, EventArgs e)
        {
            ucResult.encore();
        }         
    }
}
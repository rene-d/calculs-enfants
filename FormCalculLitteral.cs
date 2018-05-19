// CalculsCE1 : programme d'entrainement au calcul - niveau CE1
// Copyright © 2011 René DEVICHI

// histoire de tirets:  (perso je n'approuve pas les recommandations de 1990)
// http://fr.wikipedia.org/wiki/Rectifications_orthographiques_du_fran%C3%A7ais_en_1990
// http://fr.wikipedia.org/wiki/Rapport_de_1990_sur_les_rectifications_orthographiques#D.C3.A9tail

using System;
using System.Windows.Forms;

namespace CalculsCE1
{
    public partial class FormCalculLitteral : Form, IUserControlCalcul
    {
        int Max = 0;
        bool Lettres = false;
        int inconnue;
        Random rand = new Random();

        public FormCalculLitteral()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AcceptButton = buttonCheck;
            ucResult.userControlCalcul = this;

            radioButton1.Checked = true;

            checkBox_Click(checkBox1, EventArgs.Empty);
            //ucResult.encore();
        }

        public ResultatCalcul Vérifie(out string resultat)
        {
            resultat = "";

            if (Lettres)
            {
                if (!compare(false))
                {
                    FormErreur.Show("Erreur, ce n'est pas " + inconnue.ToString());

                    resultat = "erreur " + textBoxL.Text;
                    textBoxL.Select();
                    return ResultatCalcul.Erreur;
                }

                resultat = textBoxL.Text;
                textBoxL.Text = Littéral.Int2Lettres(inconnue);                
            }
            else
            {
                int saisie = textBoxZ.Integer2;

                if (saisie == int.MinValue)
                {
                    FormErreur.Show("TU DOIS ENTRER UN NOMBRE !");
                    return ResultatCalcul.ErreurSaisie;
                }

                if (saisie != inconnue)
                {
                    FormErreur.Show("Erreur, ce n'est pas ça !");

                    resultat = "erreur " + textBoxL.Text;
                    textBoxZ.Select();
                    return ResultatCalcul.Erreur;
                }

                resultat = inconnue.ToString();
            }

            buttonCheck.Enabled = false;            
            return ResultatCalcul.OK;
        }

        public void Encore()
        {
            inconnue = rand.Next(0, Max);

            if (Lettres)
            {
                textBoxL.Text = "";
                textBoxL.Select();

                textBoxZ.Text = inconnue.ToString();
                textBoxZ.Select(0, 0);
            }
            else
            {
                textBoxL.Text = Littéral.Int2Lettres(inconnue);
                textBoxL.Select(0, 0);

                textBoxZ.Text = "";
                textBoxZ.Select();
            }
            buttonCheck.Enabled = true;
        }

        public int Duree
        {
            get
            {
                if (Lettres) return 90;                
                if (Max == 100) return 10;
                if (Max == 1000) return 15;
                return 20;
            }
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            ucResult.verifie();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) Max = 100;
            else if (radioButton2.Checked) Max = 1000;
            else Max = 10000;

            ucResult.encore();
        }

        private void checkBox_Click(object sender, EventArgs e)
        {            
            Lettres = (sender == checkBox2) ;

            labelQuestion.Text = Lettres ? "Ecris le nombre ci-dessous en toutes lettres :" 
                                         : "Ecris le nombre suivant en chiffres :";

            textBoxL.ReadOnly = !Lettres;
            pictureBox1.Visible = Lettres;
            label1.Visible = Lettres;
            checkBox1.Checked = !Lettres;
            checkBox2.Checked = Lettres;

            textBoxZ.ReadOnly = Lettres;
            ucResult.encore();
        }

        private bool compare(bool partial)
        {
            string saisie = textBoxL.Text;
            string controle = Littéral.Int2Lettres(inconnue);

            string[] s1 = saisie.ToLower().Split(" -".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] s2 = controle.ToLower().Split(" -".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            if (partial)
            {
                if (s1.Length == 0) return false;
                if (s1.Length > s2.Length) return false;

                for (int i = 0; i < s1.Length - 1; ++i)
                {
                    if (s1[i] != s2[i]) return false;
                }

                if (!s2[s1.Length - 1].StartsWith(s1[s1.Length - 1])) return false;
            }
            else
            {
                if (s1.Length != s2.Length) return false;
                for (int i = 0; i < s1.Length; ++i)
                {
                    if (s1[i] != s2[i]) return false;
                }
            }

            return true;
        }


        private void textBoxL_TextChanged(object sender, EventArgs e)
        {
            if (Lettres)
            {
                if (textBoxL.Text.Trim() == "")
                {
                    pictureBox1.Image = imageList1.Images[1];
                }
                else
                {
                    pictureBox1.Image = compare(true) ? imageList1.Images[0] : imageList1.Images[2];
                }
            }
        }        
    }
}
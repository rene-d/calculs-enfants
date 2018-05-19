// CalculsCE1 : programme d'entrainement au calcul - niveau CE1
// Copyright © 2011 René DEVICHI

using System;
using System.Windows.Forms;

namespace CalculsCE1
{
    public partial class FormCalculProblemes : Form, IUserControlCalcul
    {
        int Qmax = 5;
        Random rand = new Random();

        string[] prénoms = new string[] { "Lupiane", "Minora", "Othé", "Uyg", "Sange", "Ëgal", "Neré", "Sedine", "Ulije" };
        string[] items1 = new string[] { "bouteille d'eau", "soda", "jus d'orange", "jus de pomme" };
        string[] items1s = new string[] { "bouteilles d'eau", "sodas", "jus d'orange", "jus de pomme" };
        string[] items2 = new string[] { "sandwich", "pain au chocolat", "croissant", "sucette" };
        string[] items2s = new string[] { "sandwichs", "pains au chocolat", "croissants", "sucettes" };

        int prénom1, prénom2;
        int item1, item2;
        int[,] quantités = new int[2, 2];
        int[] prix = new int[2];

        public FormCalculProblemes()
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

            int s1 = textBoxZ1.Integer2;
            int s2 = textBoxZ2.Integer2;

            if (s1 == int.MinValue || s2 == int.MinValue)
            {
                FormErreur.Show("TU DOIS ENTRER DES NOMBRES !");
                return ResultatCalcul.ErreurSaisie;
            }

            if (s1 != prix[0] || s2 != prix[1])
            {
                FormErreur.Show("Erreur, ce n'est pas ça !");

                resultat = "erreur";
                textBoxZ1.Select();
                return ResultatCalcul.Erreur;
            }

            resultat = string.Format("problème {0} résolu", checkBoxDifficile.Checked ? "difficile" : "facile");
            
            buttonCheck.Enabled = false;
            return ResultatCalcul.OK;
        }

        public void Encore()
        {
            // choisit deux prénoms différents
            prénom1 = rand.Next(prénoms.Length);
            prénom2 = rand.Next(prénoms.Length - 1);
            if (prénom2 == prénom1) ++prénom2;

            // choisit deux items parmi les deux listes (boisson, nourriture)
            item1 = rand.Next(items1.Length);
            item2 = rand.Next(items2.Length);

            label1.Text = string.Format("{0} :", UppercaseFirst(items1[item1]));
            label2.Text = string.Format("{0} :", UppercaseFirst(items2[item2]));

            quantités[0, 0] = rand.Next(1, Qmax);
            quantités[0, 1] = rand.Next(1, Qmax);

            if (checkBoxDifficile.Checked)
            {
                quantités[1, 0] = rand.Next(1, Qmax);
                quantités[1, 1] = rand.Next(1, Qmax - 1);

                // s'assure que le déterminant de la matrice n'est pas nul, et donc le problème solvable
                int d = quantités[0, 0] * quantités[1, 1] - quantités[0, 1] * quantités[1, 0];
                if (d == 0)
                    ++quantités[1, 1];
            }
            else
            {
                quantités[1, 0] = rand.Next(1, Qmax - 1);
                quantités[1, 1] = rand.Next(1, Qmax - 1);

                // simplifie le calcul en mettant une même quantité pour un des deux items
                int x = rand.Next(2);
                quantités[0, x] = quantités[1, x];

                // s'assure que le déterminant de la matrice n'est pas nul, et donc le problème solvable
                if (quantités[0, 1 - x] == quantités[1, 1 - x])
                    ++quantités[1, 1 - x];
            }

            prix[0] = rand.Next(1, 5);
            prix[1] = rand.Next(1, 5);

            for (int i = 0; i < 2; ++i)
            {
                string i1 = (quantités[i, 0] > 1 ? items1s : items1)[item1];
                string i2 = (quantités[i, 1] > 1 ? items2s : items2)[item2];

                RichTextBox box = (i == 0 ? textBoxP1 : textBoxP2);

                string s =
                    string.Format(@"{0} achète \ul {1}\ulnone  \cf1 {2}\cf0  et \ul {3}\ulnone  \cf2 {4}\cf0  et paie \ul {5}\ulnone  € .",
                        prénoms[i == 0 ? prénom1 : prénom2],
                        quantités[i, 0], i1, quantités[i, 1], i2,
                        quantités[i, 0] * prix[0] + quantités[i, 1] * prix[1]);

                box.Rtf = @"{\rtf1 {\colortbl ;\red0\green0\blue223;\red223\green0\blue0;} " + s + "}";
            }


            textBoxZ1.Text = "";
            textBoxZ2.Text = "";
            textBoxZ1.Select();

            buttonCheck.Enabled = true;
        }

        public int Duree
        {
            get { return 360; }
        }

        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
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
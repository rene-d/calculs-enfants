// CalculsCE1 : programme d'entrainement au calcul - niveau CE1
// Copyright © 2011 René DEVICHI

using System;
using System.Windows.Forms;

namespace CalculsCE1
{
    public partial class UserControlResult : UserControl
    {
        public IUserControlCalcul userControlCalcul;

        int erreurs = 0;
        int succes = 0;
        int etoilesConsécutives = 0;


        public UserControlResult()
        {
            InitializeComponent();
        }

        private void comboBoxPrenom_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enfants.Selecteur(comboBoxPrenom, pictureBoxPhoto);
            //userControl11.Focus();
        }

        private void buttonAjoutEnfant_Click(object sender, EventArgs e)
        {
            timerProgressBar.Stop();
            Enfants.Ajout(comboBoxPrenom);
            Enfants.Selecteur(comboBoxPrenom, pictureBoxPhoto);
            //userControl11.Focus();
            timerProgressBar.Start();
        }

        // permet de proposer un nouveau calcul après 3 s
        private void timerEncore_Tick(object sender, EventArgs e)
        {
            encore();
        }

        private void timerHeure_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabelHeure.Text = DateTime.Now.ToLongTimeString();
        }

        private void timerProgressBar_Tick(object sender, EventArgs e)
        {
            toolStripProgressBar1.PerformStep();

            if (toolStripProgressBar1.Value >= toolStripProgressBar1.Maximum)
            {
                timerProgressBar.Stop();
            }
        }

        private void UserControlResult_Load(object sender, EventArgs e)
        {
            Enfants.Init(comboBoxPrenom);
            Historique.SetListBox(listBoxHistorique);

            toolStripStatusLabelSucces.Text = "";
            toolStripStatusLabelErreurs.Text = "";

            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = 5000;   // 5 secondes
            toolStripProgressBar1.Step = 100;       //
            timerProgressBar.Interval = 100;                  // mise à jour toutes les 100 ms

            toolTip1.SetToolTip(buttonAjoutEnfant, "Ajoute un prénom personnalisé");

            // timer pour afficher l'horloge
            timerHeure_Tick(null, null);
            timerHeure.Interval = 1000;
            timerHeure.Start();
        }

        public void encore()
        {
            timerEncore.Stop();
            labelBravo.Visible = false;
            pictureBoxStar.Visible = false;
            pictureBoxPhoto.Visible = false;

            userControlCalcul.Encore();

            toolStripProgressBar1.Maximum = 1000 * userControlCalcul.Duree;

            // timer pour faire avancer la ProgressBar
            toolStripProgressBar1.Value = 0;
            timerProgressBar.Start();
        }


        public void verifie()
        {
            timerProgressBar.Stop();

            string resultat;
            ResultatCalcul r;
            try
            {
                r = userControlCalcul.Vérifie(out resultat);
            }
            catch
            {
                FormErreur.Show("SAISIE INVALIDE - RECOMMENCE");
                return;
            }

            if (r == ResultatCalcul.ErreurSaisie)
            {
                timerProgressBar.Start();
                return;
            }

            if (toolStripProgressBar1.Value < toolStripProgressBar1.Maximum)
            {
                if (r != ResultatCalcul.OK)
                {
                    etoilesConsécutives = 0;
                    resultat += " *";
                }
                else
                {
                    ++etoilesConsécutives;
                    resultat += " " + new string('*', etoilesConsécutives);
                }

            }
            else
            {
                etoilesConsécutives = 0;
            }

            Historique.Add(resultat);

            if (r != ResultatCalcul.OK)
            {
                toolStripStatusLabelErreurs.Text = string.Format("Erreurs: {0}", ++erreurs);

                timerProgressBar.Start();
                return;
            }

            toolStripStatusLabelSucces.Text = string.Format("Succès: {0}", ++succes);

            labelBravo.Visible = true;
            pictureBoxPhoto.Visible = true;
            if (toolStripProgressBar1.Value < toolStripProgressBar1.Maximum)
            {
                pictureBoxStar.Visible = true;
            }
            toolStripProgressBar1.Value = 0;

            if (etoilesConsécutives >= 5)
            {
                new FormBravo(comboBoxPrenom.Text).ShowDialog(this);
                etoilesConsécutives = 0;
            }

            timerEncore.Interval = 3000;         // nouveau calcul dans 3 secondes            
            timerEncore.Start();
        }

        private void UserControlResult_ControlRemoved(object sender, ControlEventArgs e)
        {
            Historique.SetListBox(null);
        }

        private void UserControlResult_Resize(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(this.Size.Width, 247);
        }
                
    }
}

// CalculsCE1 : programme d'entrainement au calcul - niveau CE1
// Copyright © 2011 René DEVICHI

// note: certaines icônes proviennent de http://icones.pro/ et http://www.iconfinder.com

using System;
using System.Deployment.Application;
using System.Windows.Forms;

namespace CalculsCE1
{
    public partial class FormCalculs : Form
    {

        public FormCalculs()
        {
            InitializeComponent();
        }

        private void FormCalculs_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName;

            /*
            if (DateTime.Now.CompareTo(new DateTime(2012, 07, 1)) > 0)
            {
                MessageBox.Show("L'application est périmée. Obtenez une mise à jour auprès de l'auteur ou téléchargez la dernière version.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                
                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    miseÀJourToolStripMenuItem_Click(null, EventArgs.Empty);
                }

                this.Close();
                return;
            }
            */

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                miseAJourToolStripMenuItem.Enabled = true;
                //miseÀJourToolStripMenuItem.ToolTipText = string.Format("Dernière recherche: {0}", ApplicationDeployment.CurrentDeployment.TimeOfLastUpdateCheck);

                this.Text += string.Format(" - version {0}", ApplicationDeployment.CurrentDeployment.CurrentVersion);

                if (ApplicationDeployment.CurrentDeployment.IsFirstRun)
                {                     
                    MessageBox.Show(@"Merci d'utiliser CalculsCE1 !

Le chronomètre et l'étoile récompensent les plus rapides.
Nouveau module pour apprendre l'écriture des nombres en français.
Contrôle hebdomadaire des mises à jour en tâche de fond ou avec le menu.
Le bouton + permet de gérer la liste des prénoms et photos.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // recharge les photos en ressources le cas échéant
                    if (Properties.Settings.Default.PhotosSupp != null)
                    {
                        foreach (var i in Properties.Settings.Default.PhotosSupp)
                            FormDownload.Download(i, true);
                    }
                }
            }
            else
            {
                miseAJourToolStripMenuItem.Enabled = false;
            }

            Historique.Add(DateTime.Now.ToString());
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void FormCalculs_KeyUp(object sender, KeyEventArgs e)
        {
            /*
            if (e.Control && e.KeyCode == Keys.H)
            {
                new FormHistorique().ShowDialog(this);
            }
            else if (e.Control && e.KeyCode == Keys.O)
            {
                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    System.Diagnostics.Process.Start(ApplicationDeployment.CurrentDeployment.DataDirectory);
                }
                else
                {
                    System.Diagnostics.Process.Start(Application.LocalUserAppDataPath);
                }
            }
            */
        }

        private void miseÀJourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ApplicationDeployment.IsNetworkDeployed)
                return;

            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && sender != null)
            {
                // The control has been CTRL-Clicked
                new FormUpdate().ShowDialog(this);
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                bool update = ApplicationDeployment.CurrentDeployment.CheckForUpdate();
                Cursor.Current = Cursors.Default;

                if (!update)
                {
                    MessageBox.Show("Vous avez déjà la dernière version du logiciel.", Application.ProductName);
                    return;
                }

                if (MessageBox.Show("Une mise à jour est disponible !\r\n\r\nVoulez-vous l'installer ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                Cursor.Current = Cursors.WaitCursor;
                update = ApplicationDeployment.CurrentDeployment.Update();
                Cursor.Current = Cursors.Default;

                if (update)
                {
                    DialogResult r = MessageBox.Show("L'application a été mise à jour.\r\n\r\nVoulez-vous redémarrer maintenant ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (r == DialogResult.Yes)
                        Application.Restart();
                }
                else
                {
                    MessageBox.Show("Impossible de mettre à jour l'application. Veuillez réeesayer plus tard ou désintaller puis réinstaller.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Erreur");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void historiqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormHistorique().ShowDialog(this);
        }

        private void toolStripMenuItemPrénoms_Click(object sender, EventArgs e)
        {
            new FormEnfants().ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FormCalculAlgo(
                    new addition(),
                    new soustraction()
                ).ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FormCalculAlgo(
                    new carrés(),
                    new racines()
                ).ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new FormCalculAlgo(
                    new doubles(),
                    new moitiés()
                ).ShowDialog(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new FormCalculAlgo(
                    new multiplication()
                ).ShowDialog(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new FormCalculAlgo(
                new N_plus_c_est(),
                new N_fois_c_est()
                ).ShowDialog(this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new FormCalculOrdre().ShowDialog(this);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new FormCalculLitteral().ShowDialog(this);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new FormCalculProblemes().ShowDialog(this);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new FormCalculRomains().ShowDialog(this);
        }
    }
}
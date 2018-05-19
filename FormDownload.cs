// CalculsCE1 : programme d'entrainement au calcul - niveau CE1
// Copyright © 2011 René DEVICHI

using System;
using System.Deployment.Application;
using System.Windows.Forms;

namespace CalculsCE1
{
    public partial class FormDownload : Form
    {
        string groupName;               // nom du groupe à télécharger
        bool autoClose;                 // le bouton Fermer est automatiquement cliqué

        ApplicationDeployment ad;
        bool completed;                 // true si on a reçu l'événement DownloadFileGroupCompletedEvent
        bool cancelled;                 // true si on a cliqué sur le bouton Annuler

        private FormDownload()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            button1.Text = "Annuler";
            button1.Enabled = true;

            label1.Text = string.Format("Téléchargement de {0} ...", groupName);

            completed = false;
            cancelled = false;

            ad = ApplicationDeployment.CurrentDeployment;
            ad.DownloadFileGroupProgressChanged += new DeploymentProgressChangedEventHandler(ad_DownloadFileGroupProgressChanged);
            ad.DownloadFileGroupCompleted += new DownloadFileGroupCompletedEventHandler(ad_DownloadFileGroupCompleted);

            ad.DownloadFileGroupAsync(groupName); 
        }

        private void RemoveHandlers()
        {
            ad.DownloadFileGroupProgressChanged -= (ad_DownloadFileGroupProgressChanged);
            ad.DownloadFileGroupCompleted -= (ad_DownloadFileGroupCompleted);
        }

        // mise à jour de l'état du chargement
        private void ad_DownloadFileGroupProgressChanged(object sender, DeploymentProgressChangedEventArgs e)
        {
            if (e.BytesTotal == 0)
                label1.Text = string.Format("Téléchargement de {0} (initialisation)", e.Group, e.BytesCompleted, e.BytesTotal);
            else
                label1.Text = string.Format("Téléchargement de {0} ({1} sur {2} octets)", e.Group, e.BytesCompleted, e.BytesTotal);
            progressBar1.Value = e.ProgressPercentage;
        }

        private void ad_DownloadFileGroupCompleted(object sender, DownloadFileGroupCompletedEventArgs e)
        {
            label1.Text = string.Format("Téléchargement de {0} {1}.", e.Group, e.Cancelled ? "annulé" : "terminé");

            completed = true;       // on peut fermer la fenêtre
            button1.Enabled = true;
            button1.Text = "Fermer";
            button1.Focus();

            if (autoClose)
            {
                System.Threading.Thread.Sleep(5);
                button1_Click(null, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // deux cas:
            //  soit on a fini (téléchargement ou annulation) : on ferme la fenêtre
            //  soit on est en cours de téléchargement : on demande l'annulation
            //  on ne peut pas être en cours d'annulation puisqu'on désactive le bouton

            if (completed)
            {
                DialogResult = cancelled ? DialogResult.Abort : DialogResult.OK;
                Close();
            }
            else 
            {
                button1.Enabled = false;
                cancelled = true;
                ad.DownloadFileGroupAsyncCancel(groupName);
            }
        }

        /// <summary>
        /// charge un groupe de fichiers Click-Once
        /// </summary>
        /// <param name="groupName">nom du groupe à charger</param>
        /// <param name="autoClose">fermer la fenêtre automatiquement lorsque l'opération est terminée</param>
        /// <returns>OK si le groupe a été installé (ou l'est déjà), Abort si opération annulée</returns>
        public static DialogResult Download(string groupName, bool autoClose)
        {
            if (!ApplicationDeployment.IsNetworkDeployed)
            {
                return DialogResult.None;
            }

            if (ApplicationDeployment.CurrentDeployment.IsFileGroupDownloaded(groupName)) 
            {
                return DialogResult.OK;
            }

            using (FormDownload dlg = new FormDownload())
            {
                dlg.groupName = groupName;
                dlg.autoClose = autoClose;

                DialogResult r = DialogResult.OK;
                try
                {
                    r = dlg.ShowDialog();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    dlg.RemoveHandlers();
                }
                return r;
            }
        }
    }
}

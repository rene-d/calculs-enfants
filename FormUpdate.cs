// CalculsCE1 : programme d'entrainement au calcul - niveau CE1
// Copyright © 2011 René DEVICHI

using System;
using System.Deployment.Application;
using System.Diagnostics;
using System.Windows.Forms;

namespace CalculsCE1
{
    public partial class FormUpdate : Form
    {
        ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

        public FormUpdate()
        {
            InitializeComponent();
        }

        private void FormUpdate_Load(object sender, EventArgs e)
        {
            ad.CheckForUpdateCompleted += ad_CheckForUpdateCompleted;
            ad.CheckForUpdateProgressChanged += ad_DownloadFileGroupCompleted;

            set(textBox6, ad.ActivationUri, buttonActivationUri);
            set(textBox7, ad.CurrentVersion);
            set(textBox8, ad.DataDirectory, buttonDataDirectory);
            set(textBox9, ad.IsFirstRun);
            set(textBox10, ad.TimeOfLastUpdateCheck);
            set(textBox11, ad.UpdatedApplicationFullName, buttonUpdatedApplicationFullName);
            set(textBox12, ad.UpdatedVersion);
            set(textBox13, ad.UpdateLocation, buttonUpdateLocation);
        }

        private void set(Control t, object x, Button open = null)
        {
            try
            {
                t.Text = x.ToString();

                if (t.Text == "")
                    throw new Exception("");

                if (open != null)
                {
                    open.Enabled = true;
                    open.Tag = t.Text;
                }
            }
            catch (Exception ex) 
            {
                if (open != null) open.Enabled = false;
                t.Text = ex.Message; 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            set(label1, ad.CheckForUpdate());
            Cursor.Current = Cursors.Default;
       }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                UpdateCheckInfo uci = ad.CheckForDetailedUpdate();

                set(textBox1, uci.AvailableVersion);
                set(textBox2, uci.IsUpdateRequired);
                set(textBox3, uci.MinimumRequiredVersion);
                set(textBox4, uci.UpdateAvailable);
                set(textBox5, uci.UpdateSizeBytes);
            }
            catch (Exception ex)
            {
                label16.Text = ex.Message;
            }
             Cursor.Current = Cursors.Default;            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            set(label15, ad.Update());
            Cursor.Current = Cursors.Default;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                ad.CheckForUpdateAsync();
            }
            catch { }
        }

        private void RemoveHandlers()
        {
            ad.CheckForUpdateCompleted -= (ad_CheckForUpdateCompleted);
            ad.CheckForUpdateProgressChanged -= (ad_DownloadFileGroupCompleted);
        }

        private void ad_CheckForUpdateCompleted(object sender, CheckForUpdateCompletedEventArgs e)
        {
            try
            {
                listBox1.Items.Add(string.Format("AvailableVersion {0}", e.AvailableVersion.ToString()));
            }
            catch { }
        }

        private void ad_DownloadFileGroupCompleted(object sender, DeploymentProgressChangedEventArgs e)
        {
            listBox1.Items.Add(string.Format("{0} {1} {2} {3}", e.BytesCompleted, e.BytesTotal, e.ProgressPercentage, (int)e.State));
        }

        private void FormUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            RemoveHandlers();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            string s = (sender as Button).Tag as string;
            if (s != null && s!="")
                Process.Start(s);
        }
    }
}

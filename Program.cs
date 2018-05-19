// CalculsCE1 : programme d'entrainement au calcul - niveau CE1
// Copyright © 2011 René DEVICHI

// adapté de http://www.codeproject.com/KB/cs/CSSIApp.aspx

using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace SingleInstanceApp
{
    class MainForm : CalculsCE1.FormCalculs
    {
        public string[] Args;
        
        public delegate void ProcessParametersDelegate(object sender, string[] args);
        public void ProcessParameters(object sender, string[] args)
        {
        }
    }

    class Global
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                App myApp = new App();
                myApp.Run(args);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur fatale s'est produite. Merci d'envoyer à l'auteur la copie d'écran." + ex.ToString(), "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// We inherit from the VB.NET WindowsFormApplicationBase class, which has the 
        /// single-instance functionality.
        /// </summary>
        class App : WindowsFormsApplicationBase
        {
            public App()
            {
                // Make this a single-instance application
                this.IsSingleInstance = true; 
                this.EnableVisualStyles = true;
                
                // There are some other things available in the VB application model, for
                // instance the shutdown style:
                this.ShutdownStyle = Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterMainFormCloses; 

                // Add StartupNextInstance handler
                this.StartupNextInstance += new StartupNextInstanceEventHandler(this.SIApp_StartupNextInstance);
            }

            /// <summary>
            /// We are responsible for creating the application's main form in this override.
            /// </summary>
            protected override void OnCreateMainForm()
            {
                // Create an instance of the main form and set it in the application; 
                // but don't try to run it.
                this.MainForm = new MainForm();

                // We want to pass along the command-line arguments to this first instance

                // Allocate room in our string array
                ((MainForm)this.MainForm).Args = new string[this.CommandLineArgs.Count];
                
                // And copy the arguments over to our form
                this.CommandLineArgs.CopyTo(((MainForm)this.MainForm).Args, 0);
            }

            /// <summary>
            /// This is called for additional instances. The application model will call this 
            /// function, and terminate the additional instance when this returns.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="eventArgs"></param>
            protected void SIApp_StartupNextInstance(object sender, 
                StartupNextInstanceEventArgs eventArgs)
            {
                // Copy the arguments to a string array
                string[] args = new string[eventArgs.CommandLine.Count];
                eventArgs.CommandLine.CopyTo(args, 0);

                // Create an argument array for the Invoke method
                object[] parameters = new object[2];
                parameters[0] = this.MainForm;
                parameters[1] = args;

                // Need to use invoke to b/c this is being called from another thread.
                this.MainForm.Invoke(new MainForm.ProcessParametersDelegate(
                    ((MainForm)this.MainForm).ProcessParameters), 
                    parameters );
            }
        }
    } 
}

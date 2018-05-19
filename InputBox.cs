// CalculsCE1 : programme d'entrainement au calcul - niveau CE1
// Copyright © 2011 René DEVICHI

// inspiré de http://www.codeproject.com/KB/edit/InputBox.aspx

using System;
using System.Drawing;
using System.Windows.Forms;

namespace CalculsCE1
{

    #region InputBox return result

    /// <summary>
    /// Class used to store the result of an InputBox.Show message.
    /// </summary>
    public class InputBoxResult
    {
        public DialogResult ReturnCode;
        public string Text;
    }

    #endregion

    /// <summary>
    /// Summary description for InputBox.
    /// </summary>
    public class InputBox
    {

        #region Private Windows Contols and Constructor

        // Create a new instance of the form.
        private Form frmInputDialog;
        private Label lblPrompt;
        private Button btnOK;
        private Button btnCancel;
        private TextBox txtInput;

        public InputBox()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Variables

        private string _formCaption = string.Empty;
        private string _formPrompt = string.Empty;
        private InputBoxResult _outputResponse = new InputBoxResult();
        private string _defaultValue = string.Empty;
        private int _xPos = -1;
        private int _yPos = -1;

        #endregion

        #region Windows Form code

        private void InitializeComponent()
        {
            // Create a new instance of the form.
            frmInputDialog = new Form();
            lblPrompt = new Label();
            btnOK = new Button();
            btnCancel = new Button();
            txtInput = new TextBox();
            frmInputDialog.SuspendLayout();
            // 
            // lblPrompt
            // 
            lblPrompt.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            lblPrompt.BackColor = SystemColors.Control;
            lblPrompt.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((Byte)(0)));
            lblPrompt.Location = new Point(12, 9);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(302, 82);
            lblPrompt.TabIndex = 3;
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            // btnOK.FlatStyle = FlatStyle.Popup;
            btnOK.Location = new Point(326, 8);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(64, 24);
            btnOK.TabIndex = 1;
            btnOK.Text = "&OK";
            btnOK.Click += new EventHandler(btnOK_Click);
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            //btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Location = new Point(326, 40);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(64, 24);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "A&nnuler";
            btnCancel.Click += new EventHandler(btnCancel_Click);
            // 
            // txtInput
            // 
            txtInput.Location = new Point(8, 100);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(379, 20);
            txtInput.TabIndex = 0;
            txtInput.Text = "";
            // 
            // InputBoxDialog
            // 
            frmInputDialog.AutoScaleBaseSize = new Size(5, 13);
            frmInputDialog.ClientSize = new Size(398, 128);
            frmInputDialog.Controls.Add(txtInput);
            frmInputDialog.Controls.Add(btnCancel);
            frmInputDialog.Controls.Add(btnOK);
            frmInputDialog.Controls.Add(lblPrompt);
            frmInputDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
            frmInputDialog.MaximizeBox = false;
            frmInputDialog.MinimizeBox = false;
            frmInputDialog.Name = "InputBoxDialog";
            frmInputDialog.ResumeLayout(false);
        }

        #endregion

        #region Private function, InputBox Form move and change size

        private void LoadForm()
        {
            OutputResponse.ReturnCode = DialogResult.Ignore;
            OutputResponse.Text = string.Empty;

            txtInput.Text = _defaultValue;
            lblPrompt.Text = _formPrompt;
            frmInputDialog.Text = _formCaption;

            // Retrieve the working rectangle from the Screen class
            // using the PrimaryScreen and the WorkingArea properties.
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;

            if ((_xPos >= 0 && _xPos < workingRectangle.Width - 100) && (_yPos >= 0 && _yPos < workingRectangle.Height - 100))
            {
                frmInputDialog.StartPosition = FormStartPosition.Manual;
                frmInputDialog.Location = new System.Drawing.Point(_xPos, _yPos);
            }
            else
                frmInputDialog.StartPosition = FormStartPosition.CenterScreen;


            string PrompText = lblPrompt.Text;

            int n = 0;
            int Index = 0;
            while (PrompText.IndexOf("\n", Index) > -1)
            {
                Index = PrompText.IndexOf("\n", Index) + 1;
                n++;
            }

            if (n == 0)
                n = 1;

            System.Drawing.Point Txt = txtInput.Location;
            Txt.Y = Txt.Y + (n * 4);
            txtInput.Location = Txt;
            System.Drawing.Size form = frmInputDialog.Size;
            form.Height = form.Height + (n * 4);
            frmInputDialog.Size = form;

            frmInputDialog.AcceptButton = btnOK;
            frmInputDialog.CancelButton = btnCancel;

            txtInput.SelectionStart = 0;
            txtInput.SelectionLength = txtInput.Text.Length;
            txtInput.Focus();
        }

        #endregion

        #region Button control click event

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            OutputResponse.ReturnCode = DialogResult.OK;
            OutputResponse.Text = txtInput.Text;
            frmInputDialog.Dispose();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            OutputResponse.ReturnCode = DialogResult.Cancel;
            OutputResponse.Text = string.Empty; //Clean output response
            frmInputDialog.Dispose();
        }

        #endregion

        #region Public Static Show functions

        static public InputBoxResult Show(string Prompt)
        {
            return Show(Prompt, string.Empty, string.Empty, -1, -1);
        }

        static public InputBoxResult Show(string Prompt, string Title)
        {
            return Show(Prompt, Title, string.Empty, -1, -1);
        }

        static public InputBoxResult Show(string Prompt, string Title, string Default)
        {
            return Show(Prompt, Title, Default, -1, -1);
        }

        static public InputBoxResult Show(string Prompt, string Title, string Default, int XPos, int YPos)
        {
            InputBox frm = new InputBox();

            frm.FormCaption = Title;
            frm.FormPrompt = Prompt;
            frm.DefaultValue = Default;
            frm.XPosition = XPos;
            frm.YPosition = YPos;

            // Display the form as a modal dialog box.
            frm.LoadForm();
            frm.frmInputDialog.ShowDialog();
            return frm.OutputResponse;
        }

        #endregion

        #region Private Properties

        private string FormCaption
        {
            set
            {
                _formCaption = value;
            }
        } // property FormCaption

        private string FormPrompt
        {
            set
            {
                _formPrompt = value;
            }
        } // property FormPrompt

        private InputBoxResult OutputResponse
        {
            get
            {
                return _outputResponse;
            }
            set
            {
                _outputResponse = value;
            }
        } // property InputResponse

        private string DefaultValue
        {
            set
            {
                _defaultValue = value;
            }
        } // property DefaultValue

        private int XPosition
        {
            set
            {
                if (value >= 0)
                    _xPos = value;
            }
        } // property XPos

        private int YPosition
        {
            set
            {
                if (value >= 0)
                    _yPos = value;
            }
        } // property YPos

        #endregion
    }
}

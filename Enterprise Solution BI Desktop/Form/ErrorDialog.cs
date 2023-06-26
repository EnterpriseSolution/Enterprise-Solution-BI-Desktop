using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace EnterpriseSolutionBIDesktop
{
    internal partial class ErrorDialog : Form
    {
        private Exception error = new Exception();

        public Exception Error
        {
            get { return error; }
            set { error = value; }
        }

        public ErrorDialog()
        {
            this.TopMost = true;
            InitializeComponent();
        }

        //protected internal override void InitializeLayout()
        //{           
        //    ErrorrichText.ReadOnly = true;
        //}

        protected override void OnLoad(EventArgs e)
        {
            this.TopMost = true;
            base.OnLoad(e);

            string message = Error.Message;
            //try
            //{
                //if (Error is Exception)
                //{                   
                //    message = Error.Message;
                //    string invalidata = string.Empty;
                //    ArrayList arrayList = ((AppException)Error).InvalidData;
                //    for (int i = 0; i < arrayList.Count; i++)
                //    {
                //        invalidata += arrayList[i].ToString() + ",";
                //    }

                //    if (!string.IsNullOrEmpty(invalidata))
                //    {
                //        invalidata = invalidata.Substring(0, invalidata.Length - 1);
                //        message = message + "\nData:" + invalidata;
                //    }
                //}
            //}
            //catch
            //{
            //    throw;
            //}
           
            ErrorDetail error = new ErrorDetail(Error, false);
            ErrorrichText.Text = error.TechnicalDetails;
            lblException.Text = error.ErrorMessage;          
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            //Win32.SetForegroundWindow(this.Handle.ToInt32());
            this.Focus();
                       
        }

        private void btn确定_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btn复制到剪切板_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(ErrorrichText.Text, true);
        }

        private void btn显示详细资料_Click(object sender, EventArgs e)
        {
            if (btnShowDetails.Text == "Show Details")
            {
                this.Height = 400;
                btnShowDetails.Text = "Hide Details";
                //this.btnCopytoClipboard.Visible = false;
            }
            else
            {
                btnShowDetails.Text = "Show Details";
                this.Height = 170;
                //this.btnCopytoClipboard.Visible = true;
            }
            //this.btnCopytoClipboard.Visible = !this.btnCopytoClipboard.Visible;
            this.btnCopytoClipboard.Visible = this.Height == 400;
        }

        //protected override void ReleaseResources()
        //{
        //    try
        //    {
        //        this.btnCopytoClipboard.Click -= new EventHandler(btn复制到剪切板_Click);
        //        this.btnOK.Click -= new EventHandler(this.btn确定_Click);
        //        this.btnShowDetails.Click -= new EventHandler(this.btn显示详细资料_Click);
        //    }

        //    catch
        //    {

        //    }

        //    base.ReleaseResources();
        //}
    }
}

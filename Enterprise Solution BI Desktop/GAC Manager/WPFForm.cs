using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GACManager;

namespace ManagementStudio.GAC_Manager
{
    public partial class WPFForm : Form
    {
        private Type _type;
        public string _text;

        public WPFForm(Type type,string text)
        {
            InitializeComponent();
            _type = type;
            _text = text;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.Text = _text;
            System.Windows.Controls.UserControl ctrl = Activator.CreateInstance(_type) as System.Windows.Controls.UserControl;
            elementHost.Child = ctrl;
        }
    }
}

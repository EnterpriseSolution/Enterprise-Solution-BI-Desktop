#region Enterprise Solution
// Copyright © 2006-2015 Enterprise Solution Limited
// Solution:  Enterprise Solution
// Project:   Enterprise Edition/Microsoft.WinUI
// File:  TabbedMdiManager.cs 
// Date: 2014/07/14 0:40
// Reference: http://www.cnblogs.com/JamesLi2015
#endregion
using Infragistics.Win.UltraWinTabbedMdi;
using System;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinTabbedMdi;

namespace EnterpriseSolutionBIDesktop
{
    public partial class TabbedMdiManager : UltraTabbedMdiManager
    {
        #region Fields

        public System.Windows.Forms.ContextMenuStrip ContextMenuStrip;

        private System.Windows.Forms.ToolStripMenuItem CloseAllForm;
        private System.Windows.Forms.ToolStripMenuItem CloseAllFormButThis;
        private System.Windows.Forms.ToolStripMenuItem CloseForm;
        private System.Windows.Forms.ToolStripMenuItem HorizontalGroup;
        private System.Windows.Forms.ToolStripMenuItem MoveToFirstGroup;
        private System.Windows.Forms.ToolStripMenuItem MoveToLastGroup;
        private System.Windows.Forms.ToolStripMenuItem MoveToNextTabGroup;
        private System.Windows.Forms.ToolStripMenuItem MoveToPreviousGroup;
        private System.Windows.Forms.ToolStripMenuItem ReOpenForm;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem VerticalGroupGroup;

        #endregion Fields

        #region Constructors

        public TabbedMdiManager(): base()
        {
            InitializeComponent();
            this.HorizontalGroup.Image = NewHorizontalGroupImage;
            this.HorizontalGroup.ImageTransparentColor = Color.Fuchsia;
            this.VerticalGroupGroup.Image = NewVerticalGroupImage;
            this.VerticalGroupGroup.ImageTransparentColor = Color.Fuchsia;
            // this.ContextMenuStrip = null;
            //if (!DesignMode)
            //{
            //    this.TabGroupSettings.ShowTabListButton = DefaultableBoolean.False;
            //}
        }

        #endregion Constructors

        #region Properties

        private Bitmap NewHorizontalGroupImage
        {
            get
            {
                Type type = typeof (UltraTabbedMdiManager);
                return Image.FromStream(type.Assembly.GetManifestResourceStream(type, "TabGroupHorizontal.bmp")) as Bitmap;
            }
        }

        private Bitmap NewVerticalGroupImage
        {
            get
            {
                Type type = typeof (UltraTabbedMdiManager);
                return Image.FromStream(type.Assembly.GetManifestResourceStream(type, "TabGroupVerticalVS2005.bmp")) as Bitmap;
            }
        }

        #endregion Properties

        #region Methods

        public void CloseAllFunctionButThis()
        {
            CloseAllFunctionButThis(true);
        }

        public void CloseAllFunctionButThis(bool confirm)
        {
            Form ActiveMdiForm = this.MdiParent.ActiveMdiChild;
            if (this.MdiParent.MdiChildren.Length > 0)
            {
                if (confirm)
                {
                    if (Shared.ShowConfirm("Close All Form But This?") == DialogResult.Yes)
                    {
                        foreach (Form MdiForm in this.MdiParent.MdiChildren)
                        {
                            if (MdiForm == ActiveMdiForm)
                                continue;
                            MdiForm.Close();
                        }
                    }
                }
                else
                {
                    foreach (Form MdiForm in this.MdiParent.MdiChildren)
                    {
                        if (MdiForm == ActiveMdiForm)
                            continue;
                        MdiForm.Close();
                    }
                }
            }
        }

        public void CloseAllFunctionOnTheRight(bool confirm)
        {
            if (this.MdiParent.MdiChildren.Length > 0)
            {
                Form activeMdiForm = this.MdiParent.ActiveMdiChild;

                if (confirm)
                {
                    if (Shared.ShowConfirm("Close Tabs To The Right?") == DialogResult.Yes)
                    {
                        foreach (Form mdiForm in this.MdiParent.MdiChildren)
                        {
                            var tab = TabFromForm(mdiForm);

                            if (tab.Index > ActiveTab.Index)
                                mdiForm.Close();
                        }
                    }
                }
                else
                {
                    foreach (Form mdiForm in this.MdiParent.MdiChildren)
                    {
                        var tab = TabFromForm(mdiForm);

                        if (tab.Index > ActiveTab.Index)
                            mdiForm.Close();
                    }
                }

                if (activeMdiForm != null)
                {
                    var newActiveTab = TabFromForm(activeMdiForm);
                    newActiveTab.Activate();
                }
            }
        }

        public void CloseAllMdiForms()
        {
            if (this.MdiParent.MdiChildren.Length > 0)
            {
                foreach (Form MdiForm in this.MdiParent.MdiChildren)
                {
                    MdiForm.Close();
                }
            }

            //Shared.MainForm.ShowMainMenu();
        }

        public void OnCloseTabForm(object sender, EventArgs e)
        {
            this.ActiveTab.Close();
        }

        public void ReOpenFunction()
        {
            if (this.MdiParent.ActiveMdiChild == null) return;
            //string function = ((FormBase) this.MdiParent.ActiveMdiChild).FunctionCode;

            this.ActiveTab.Close();

            //if (isentityForm)
            //{

            //    if (keyCounts == 1)
            //    {
            //        try
            //        {
            //            DrillDown drillDowm = new DrillDown();
            //            DrillDownKeyPair keypair = new DrillDownKeyPair(keyFields, keyFields, "");
            //            keypair.DrillDownValue = function;
            //            drillDowm.DrillDownKeyPairs.Add(keypair);
            //            Shared.MainForm.OpenDrillDownForm(drillDowm);
            //        }
            //        catch
            //        {
            //            Shared.MainForm.ExecuteFunction(function);
            //        }
            //    }
            //    else
            //        Shared.MainForm.ExecuteFunction(function);
            //}
            //else
            //{

            //Shared.MainForm.ExecuteFunction(function);

            // }
        }

        protected override void OnInitializeContextMenu(MdiTabContextMenuEventArgs e)
        {
            if (e.ContextMenuType == Infragistics.Win.UltraWinTabbedMdi.MdiTabContextMenu.Default)
            {
                e.ContextMenu.MenuItems.Clear();
                toolStripMenuItem1.Visible = false;
                toolStripMenuItem2.Visible = false;
                toolStripMenuItem3.Visible = false;
                VerticalGroupGroup.Visible = false;
                HorizontalGroup.Visible = false;
                MoveToFirstGroup.Visible = false;
                MoveToNextTabGroup.Visible = false;
                MoveToPreviousGroup.Visible = false;
                MoveToLastGroup.Visible = false;
                CloseAllFormButThis.Visible = false;
                CloseTabOnTheRight.Visible = false;
                CloseAllForm.Visible = false;
                if (this.MdiParent.MdiChildren.Length > 1)
                {
                    toolStripMenuItem1.Visible = true;
                    VerticalGroupGroup.Visible = true;
                    HorizontalGroup.Visible = true;
                    toolStripMenuItem2.Visible = true;
                    if (this.MdiParent.MdiChildren.Length > 2)
                    {
                        MoveToFirstGroup.Visible = true;
                    }
                    MoveToNextTabGroup.Visible = true;
                    MoveToPreviousGroup.Visible = true;
                    if (this.MdiParent.MdiChildren.Length > 2)
                    {
                        MoveToLastGroup.Visible = true;
                    }
                    toolStripMenuItem3.Visible = true;
                    CloseAllFormButThis.Visible = true;
                    CloseTabOnTheRight.Visible = true;
                    CloseAllForm.Visible = true;
                }

                //ReOpenForm.Visible = !string.IsNullOrEmpty(((FormBase) this.MdiParent.ActiveMdiChild).FunctionCode);

                ContextMenuStrip.Show(Cursor.Position.X, Cursor.Position.Y);

            }
            // base.OnInitializeContextMenu(e);
        }

        private void CloseAllFormButThis_Click(object sender, EventArgs e)
        {
            CloseAllFunctionButThis();
        }

        void CloseAllForm_Click(object sender, EventArgs e)
        {
            CloseAllMdiForms();
        }

        private void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.CloseForm.Text = "Close Focus Form";
            this.HorizontalGroup.Text = "Horizontal Group";
            this.VerticalGroupGroup.Text = "Vertical Group";
            this.MoveToFirstGroup.Text = "Move To First Group";
            this.MoveToNextTabGroup.Text = "Move To Next Tab Group";
            this.MoveToPreviousGroup.Text = "Move To Previous Group";
            this.MoveToLastGroup.Text = "Move To Last Group";
            this.CloseAllFormButThis.Text = "Close All Form But This";
            this.CloseAllForm.Text = "Close All Form";
            this.ReOpenForm.Text = "ReOpen Function";
            this.CloseTabOnTheRight.Text = "Close Tabs To The Right";

            //foreach (ToolStripItem item in this.ContextMenuStrip.Items)
            //{
            //    if (item is ToolStripMenuItem)
            //        item.Text = Shared.TranslateText(item.Text);
            //}
        }

        void HorizontalGroup_Click(object sender, EventArgs e)
        {
            MdiTab tab = this.ActiveTab;
            this.MoveToNewGroup(tab);
        }

        void MoveToFirstGroup_Click(object sender, EventArgs e)
        {
            MdiTab tab = this.ActiveTab;
            this.MoveToGroup(tab, MdiTabGroupPosition.First);
        }

        void MoveToLastGroup_Click(object sender, EventArgs e)
        {
            MdiTab tab = this.ActiveTab;
            this.MoveToNewGroup(tab, MdiTabGroupPosition.Last);
        }

        void MoveToNextTabGroup_Click(object sender, EventArgs e)
        {
            MdiTab tab = this.ActiveTab;
            this.MoveToNewGroup(tab, MdiTabGroupPosition.Next);
        }

        void MoveToPreviousGroup_Click(object sender, EventArgs e)
        {
            MdiTab tab = this.ActiveTab;
            this.MoveToGroup(tab, MdiTabGroupPosition.Previous);
        }

        private void ReOpenForm_Click(object sender, EventArgs e)
        {
            ReOpenFunction();
        }

        void VerticalGroupGroup_Click(object sender, EventArgs e)
        {
            MdiTab tab = this.ActiveTab;
            this.MoveToNewGroup(tab, tab.TabGroup, RelativePosition.After, Orientation.Vertical);
        }

        #endregion Methods

        #region Other
        
        protected override void OnInitializeTab(MdiTabEventArgs e)
        {
            base.OnInitializeTab(e);
            if (e.Tab.Form is FormBase)
            {
                FormBase form = e.Tab.Form as FormBase;
                if (!string.IsNullOrEmpty(form.Description))
                    e.Tab.ToolTip = form.Description;
            }
             
        }

        private void CloseTabOnTheRight_Click(object sender, EventArgs e)
        {
            CloseAllFunctionOnTheRight(true);
        }

        #endregion Other
    }
}


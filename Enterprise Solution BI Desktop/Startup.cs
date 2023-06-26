using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows.Forms;

namespace EnterpriseSolutionBIDesktop
{
    public partial class Startup : FormBase
    {
        private MainForm _main;

        public Startup(MainForm main)
        {
            InitializeComponent();
            _main = main;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            this.listView.View = View.LargeIcon;
            string[] icons =  { "Sales and Distribution", "Master Data",   "Production Control", "Window" };
            string[] ignores = { "Main Menu", "Close All" };
            listView.BeginUpdate();
            listView.Items.Clear();
            
            foreach (ToolStripItem group in _main.menuStrip.Items)
            {

                var header = group.Text.Replace("&", "");
                group.Image = imageList.Images[Array.IndexOf(icons, header)];


                //ListViewGroup listViewGroup = new ListViewGroup();  
                //listViewGroup.Header = group.Text.Replace("&","");  
                //listViewGroup.Name = group.Name;

                foreach (ToolStripItem item in ((ToolStripMenuItem)group).DropDownItems)
                {
                    if (item is ToolStripMenuItem)
                    {
                        var toolStripMenuItem = item as ToolStripMenuItem;
                        string text = toolStripMenuItem.Text.Replace("&", "");
                        if (ignores.Contains(text))
                            continue;

                        ListViewItem lvi = new ListViewItem
                        {
                            Text = text,
                            ImageIndex = Array.IndexOf(icons, header),
                            ForeColor = Color.Blue
                        };
                        lvi.SubItems.Add(toolStripMenuItem.Text);
                        lvi.Tag = Tuple.Create<string, ToolStripMenuItem>(header, toolStripMenuItem);

                        this.listView.Items.Add(lvi);
                    }
                }
            }

            listView.EndUpdate();


            this.listView.ShowGroups = true;
            Dictionary<String, List<ListViewItem>> map = new Dictionary<String, List<ListViewItem>>();
            foreach (ListViewItem lvi in this.listView.Items)
            {
                var itemMenu = lvi.Tag as Tuple<string, ToolStripMenuItem>;
                var key = itemMenu.Item1;
                if (!map.ContainsKey(key))
                    map[key] = new List<ListViewItem>();
                map[key].Add(lvi);
            }

            List<ListViewGroup> groups = new List<ListViewGroup>();
            foreach (String key in map.Keys)
            {
                groups.Add(new ListViewGroup(key));
            }

            // Sort the groups
            //groups.Sort(new ListViewGroupComparer(this.lastSortOrder));
            
            this.listView.Groups.Clear();
            foreach (ListViewGroup listViewGroup in groups)
            {
                this.listView.Groups.Add(listViewGroup);
                listViewGroup.Items.AddRange(map[listViewGroup.Header].ToArray());
            }

            //listView.OwnerDraw = true;
            //listView.DrawSubItem += ListView_DrawSubItem; ;
        }

        //private void ListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        //{
        //    e.DrawText(TextFormatFlags.NoClipping);
        //}
        
        private SortOrder lastSortOrder = SortOrder.None;
        private void lstTask_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = listView.GetItemAt(e.X, e.Y) as ListViewItem;
            if (item != null && item.Tag != null)
            {
                var itemMenu = item.Tag as Tuple<string, ToolStripMenuItem>;
                if (itemMenu != null)
                    itemMenu.Item2.PerformClick();
            }
        }
    }

    internal class ListViewGroupComparer : IComparer<ListViewGroup>
    {
        public ListViewGroupComparer(SortOrder order)
        {
            this.sortOrder = order;
        }

        public int Compare(ListViewGroup x, ListViewGroup y)
        {
            int result = String.Compare(x.Header, y.Header, true);

            if (this.sortOrder == SortOrder.Descending)
                result = 0 - result;

            return result;
        }

        private SortOrder sortOrder;
    }

}

// Decompiled with JetBrains decompiler
// Type: Apex.Behaviours.GridViewContextMenuBehaviour
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace Apex.Behaviours
{
  public class GridViewContextMenuBehaviour : Behavior<ListView>
  {
    private GridView gridView;
    private List<Tuple<int, GridViewColumn>> removedColumns = new List<Tuple<int, GridViewColumn>>();

    protected override void OnAttached()
    {
      base.OnAttached();
      ListView associatedObject = this.AssociatedObject;
      this.gridView = associatedObject != null && associatedObject.View != null && associatedObject.View is GridView ? (GridView) associatedObject.View : throw new InvalidOperationException("The GridViewContextMenuBehaviour must be attached to a ListView with the GridView View.");
      ContextMenu contextMenu = new ContextMenu();
      foreach (GridViewColumn column in (Collection<GridViewColumn>) ((GridView) associatedObject.View).Columns)
      {
        MenuItem menuItem1 = new MenuItem();
        menuItem1.Header = column.Header;
        menuItem1.IsCheckable = true;
        menuItem1.IsChecked = true;
        MenuItem menuItem = menuItem1;
        GridViewColumn theColumn = column;
        menuItem.Click += (RoutedEventHandler) ((sender, e) =>
        {
          if (this.gridView.Columns.Contains(theColumn))
          {
            this.removedColumns.Add(Tuple.Create<int, GridViewColumn>(this.gridView.Columns.IndexOf(theColumn), theColumn));
            this.gridView.Columns.Remove(theColumn);
            menuItem.IsChecked = false;
          }
          else
          {
            Tuple<int, GridViewColumn> tuple = this.removedColumns.Where<Tuple<int, GridViewColumn>>((Func<Tuple<int, GridViewColumn>, bool>) (t => t.Item2 == theColumn)).First<Tuple<int, GridViewColumn>>();
            this.removedColumns.Remove(tuple);
            int count = tuple.Item1;
            if (count > this.gridView.Columns.Count)
              count = this.gridView.Columns.Count;
            this.gridView.Columns.Insert(count, tuple.Item2);
          }
        });
        contextMenu.Items.Add((object) menuItem);
      }
      this.gridView.ColumnHeaderContextMenu = contextMenu;
    }

    protected override void OnDetaching() => base.OnDetaching();
  }
}

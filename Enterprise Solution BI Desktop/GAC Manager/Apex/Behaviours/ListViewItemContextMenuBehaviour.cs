// Decompiled with JetBrains decompiler
// Type: Apex.Behaviours.ListViewItemContextMenuBehaviour
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using Apex.Extensions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Apex.Behaviours
{
  public class ListViewItemContextMenuBehaviour : Behavior<ListView>
  {
    public static readonly DependencyProperty ContextMenuProperty = DependencyProperty.Register(nameof (ContextMenu), typeof (ContextMenu), typeof (ListViewItemContextMenuBehaviour), new PropertyMetadata((object) null, new PropertyChangedCallback(ListViewItemContextMenuBehaviour.OnContextMenuChanged)));

    protected override void OnAttached()
    {
      base.OnAttached();
      this.WireUpContextMenu();
    }

    protected override void OnDetaching()
    {
      this.UnWireContextMenu();
      base.OnDetaching();
    }

    private void WireUpContextMenu()
    {
      if (this.AssociatedObject == null)
        return;
      this.AssociatedObject.MouseRightButtonUp += new MouseButtonEventHandler(this.listView_MouseRightButtonUp);
    }

    private void UnWireContextMenu()
    {
      if (this.AssociatedObject == null)
        return;
      this.AssociatedObject.MouseRightButtonUp -= new MouseButtonEventHandler(this.listView_MouseRightButtonUp);
    }

    public ContextMenu ContextMenu
    {
      get => (ContextMenu) this.GetValue(ListViewItemContextMenuBehaviour.ContextMenuProperty);
      set => this.SetValue(ListViewItemContextMenuBehaviour.ContextMenuProperty, (object) value);
    }

    private static void OnContextMenuChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs args)
    {
      (o as ListViewItemContextMenuBehaviour).WireUpContextMenu();
    }

    private void listView_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
      if (!(e.OriginalSource is DependencyObject originalSource))
        return;
      ListViewItem parent = originalSource.GetParent<ListViewItem>();
      if (parent == null || this.ContextMenu == null)
        return;
      this.ContextMenu.DataContext = parent.DataContext;
      this.ContextMenu.PlacementTarget = (UIElement) parent;
      this.ContextMenu.IsOpen = true;
    }
  }
}

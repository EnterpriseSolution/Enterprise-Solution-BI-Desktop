// Decompiled with JetBrains decompiler
// Type: Apex.Controls.SelectableItemsControl
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using Apex.MVVM;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Apex.Controls
{
  public class SelectableItemsControl : ItemsControl
  {
    private static readonly DependencyProperty dp = DependencyProperty.RegisterAttached("ItemsSourceProxy", typeof (IEnumerable), typeof (SelectableItemsControl), new PropertyMetadata((object) null, new PropertyChangedCallback(SelectableItemsControl.OnItemsSourceProxyChanged)));
    private static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(nameof (SelectedItem), typeof (object), typeof (SelectableItemsControl), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(SelectableItemsControl.SelectedItemChanged)));
    private IEnumerable fudgeFactor;

    public SelectableItemsControl()
    {
      this.SelectItemCommand = new Command(new Action<object>(this.DoSelectItemCommand));
      Binding binding = new Binding("ItemsSource")
      {
        Source = (object) this
      };
      this.SetBinding(SelectableItemsControl.dp, (BindingBase) binding);
    }

    private static void OnItemsSourceProxyChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      SelectableItemsControl selectableItemsControl = d as SelectableItemsControl;
      selectableItemsControl.CheckNewItemsSourceForSelectedItem(e.NewValue as IEnumerable, true);
      selectableItemsControl.DoFudge();
    }

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      this.CheckNewItemsSourceForSelectedItem(this.ItemsSource, true);
      this.DoFudge();
    }

    private void CheckNewItemsSourceForSelectedItem(IEnumerable newItemsSource, bool forceNotify)
    {
      if (newItemsSource == null)
        return;
      ISelectableItem selectableItem = newItemsSource.Cast<object>().Where<object>((Func<object, bool>) (i => i is ISelectableItem && ((ISelectableItem) i).IsSelected)).Select<object, ISelectableItem>((Func<object, ISelectableItem>) (i => i as ISelectableItem)).FirstOrDefault<ISelectableItem>();
      if (selectableItem == null)
        return;
      this.InternalSelectItem((object) selectableItem, newItemsSource, forceNotify);
    }

    protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
    {
      base.OnItemsChanged(e);
      ISelectableItem selectableItem = this.ItemsSource.Cast<object>().Where<object>((Func<object, bool>) (i => i is ISelectableItem && ((ISelectableItem) i).IsSelected)).Select<object, ISelectableItem>((Func<object, ISelectableItem>) (i => i as ISelectableItem)).FirstOrDefault<ISelectableItem>();
      if (selectableItem != null)
        this.InternalSelectItem((object) selectableItem, this.ItemsSource);
      this.DoFudge();
    }

    private static void SelectedItemChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      object newValue = e.NewValue;
      (d as SelectableItemsControl).DoFudge();
    }

    public object SelectedItem
    {
      get => this.GetValue(SelectableItemsControl.SelectedItemProperty);
      set => this.SetValue(SelectableItemsControl.SelectedItemProperty, value);
    }

    private void DoSelectItemCommand(object itemToSelect)
    {
      this.InternalSelectItem(itemToSelect, this.ItemsSource);
      this.DoFudge();
    }

    private void DoFudge()
    {
      if (this.ItemsSource != this.fudgeFactor && this.fudgeFactor != null)
        this.CheckNewItemsSourceForSelectedItem(this.ItemsSource, true);
      this.fudgeFactor = this.ItemsSource;
    }

    private void InternalSelectItem(object itemToSelect, IEnumerable itemsSource, bool forceNotify = false)
    {
      if (this.SelectedItem == itemToSelect && !forceNotify)
        return;
      ISelectableItem selectableItem = itemsSource.Cast<object>().Where<object>((Func<object, bool>) (i => i is ISelectableItem && ((ISelectableItem) i).IsSelected)).Select<object, ISelectableItem>((Func<object, ISelectableItem>) (i => i as ISelectableItem)).FirstOrDefault<ISelectableItem>();
      if (selectableItem != null)
      {
        selectableItem.IsSelected = false;
        selectableItem.OnDeselected();
      }
      this.SelectedItem = itemToSelect;
      if (!(itemToSelect is ISelectableItem))
        return;
      ((ISelectableItem) itemToSelect).IsSelected = true;
      ((ISelectableItem) itemToSelect).OnSelected();
    }

    public Command SelectItemCommand { get; private set; }
  }
}

// Decompiled with JetBrains decompiler
// Type: Apex.Controls.PivotControl
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using Apex.MVVM;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Apex.Controls
{
  [TemplatePart(Name = "PART_ItemsControl", Type = typeof (ItemsControl))]
  [ContentProperty("PivotItems")]
  [TemplatePart(Name = "PART_PivotScrollViewer", Type = typeof (AnimatedScrollViewer))]
  public class PivotControl : ContentControl
  {
    private ItemsControl itemsControl;
    private AnimatedScrollViewer pivotScrollViewer;
    public static readonly DependencyProperty PivotItemsProperty = DependencyProperty.Register(nameof (PivotItems), typeof (ObservableCollection<PivotItem>), typeof (PivotControl), new PropertyMetadata((object) new ObservableCollection<PivotItem>()));
    public static readonly DependencyProperty SelectedPivotItemProperty = DependencyProperty.Register(nameof (SelectedPivotItem), typeof (PivotItem), typeof (PivotControl), new PropertyMetadata((object) null, new PropertyChangedCallback(PivotControl.OnSelectedPivotItemChanged)));
    private Command selectPivotItemCommand;
    private static readonly DependencyProperty ShowPivotHeadingsProperty = DependencyProperty.Register(nameof (ShowPivotHeadings), typeof (bool), typeof (PivotControl), new PropertyMetadata((object) true, new PropertyChangedCallback(PivotControl.OnShowPivotHeadingsChanged)));

    static PivotControl() => FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (PivotControl), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (PivotControl)));

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      try
      {
        this.itemsControl = (ItemsControl) this.GetTemplateChild("PART_ItemsControl");
        this.pivotScrollViewer = (AnimatedScrollViewer) this.GetTemplateChild("PART_PivotScrollViewer");
      }
      catch
      {
        throw new Exception("Unable to access the internal elements of the Pivot control.");
      }
      this.selectPivotItemCommand = new Command(new Action<object>(this.SelectPivotItem));
      this.SizeChanged += new SizeChangedEventHandler(this.PivotControl_SizeChanged);
      this.Loaded += new RoutedEventHandler(this.PivotControl_Loaded);
    }

    private void PivotControl_Loaded(object sender, RoutedEventArgs e)
    {
      if (this.SelectedPivotItem != null || this.PivotItems.Count <= 0)
        return;
      foreach (PivotItem pivotItem in (Collection<PivotItem>) this.PivotItems)
      {
        if (pivotItem.IsInitialPage)
        {
          this.SelectedPivotItem = pivotItem;
          break;
        }
      }
      if (this.SelectedPivotItem != null)
        return;
      this.SelectedPivotItem = this.PivotItems[0];
    }

    private void PivotControl_SizeChanged(object sender, SizeChangedEventArgs e)
    {
      foreach (PivotItem pivotItem in (Collection<PivotItem>) this.PivotItems)
      {
        if (pivotItem.Content is FrameworkElement)
        {
          FrameworkElement content = pivotItem.Content as FrameworkElement;
          content.Width = this.pivotScrollViewer.ActualWidth;
          content.Height = this.pivotScrollViewer.ActualHeight;
        }
      }
      this.UpdatePositioning(true);
    }

    public void SelectPivotItem(object pivotItem)
    {
        foreach (PivotItem pivotItem1 in (Collection<PivotItem>) this.PivotItems)
        {
            pivotItem1.IsSelected = false;
            if (pivotItem is PivotItem)
                pivotItem1.IsSelected = true;
            this.SelectedPivotItem = pivotItem1;
        }
    }

    public ObservableCollection<PivotItem> PivotItems
    {
      get => this.GetValue(PivotControl.PivotItemsProperty) as ObservableCollection<PivotItem>;
      set => this.SetValue(PivotControl.PivotItemsProperty, (object) value);
    }

    public PivotItem SelectedPivotItem
    {
      get => this.GetValue(PivotControl.SelectedPivotItemProperty) as PivotItem;
      set => this.SetValue(PivotControl.SelectedPivotItemProperty, (object) value);
    }

    public ICommand SelectPivotItemCommand => (ICommand) this.selectPivotItemCommand;

    public static void OnSelectedPivotItemChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      PivotControl pivotControl = d as PivotControl;
      PivotItem newValue = e.NewValue as PivotItem;
      if (pivotControl == null || newValue == null)
        return;
      pivotControl.PivotControl_SizeChanged((object) pivotControl, (SizeChangedEventArgs) null);
      pivotControl.UpdatePositioning(e.OldValue == null);
    }

    private void UpdatePositioning(bool immediate)
    {
      if (this.SelectedPivotItem == null || !(this.SelectedPivotItem.Content is FrameworkElement))
        return;
      FrameworkElement content = (FrameworkElement) this.SelectedPivotItem.Content;
      this.itemsControl.UpdateLayout();
      Point point = content.TransformToAncestor((Visual) this).Transform(new Point(0.0, 0.0));
      point.X += content.ActualWidth / 2.0 - this.ActualWidth / 2.0;
      DoubleAnimation doubleAnimation = new DoubleAnimation();
      doubleAnimation.From = new double?(this.pivotScrollViewer.HorizontalOffset);
      doubleAnimation.To = new double?(this.pivotScrollViewer.HorizontalOffset + point.X);
      doubleAnimation.DecelerationRatio = 0.8;
      doubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(immediate ? 0.0 : 300.0));
      Storyboard storyboard = new Storyboard();
      storyboard.Children.Add((Timeline) doubleAnimation);
      Storyboard.SetTarget((DependencyObject) doubleAnimation, (DependencyObject) this.pivotScrollViewer);
      Storyboard.SetTargetProperty((DependencyObject) doubleAnimation, new PropertyPath((object) AnimatedScrollViewer.CurrentHorizontalOffsetProperty));
      storyboard.Begin();
    }

    public bool ShowPivotHeadings
    {
      get => (bool) this.GetValue(PivotControl.ShowPivotHeadingsProperty);
      set => this.SetValue(PivotControl.ShowPivotHeadingsProperty, (object) value);
    }

    private static void OnShowPivotHeadingsChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs args)
    {
    }
  }
}

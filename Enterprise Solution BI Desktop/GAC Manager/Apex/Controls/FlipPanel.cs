// Decompiled with JetBrains decompiler
// Type: Apex.Controls.FlipPanel
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using Apex.MVVM;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Apex.Controls
{
  public class FlipPanel : Control
  {
    public static readonly DependencyProperty ContentFrontProperty = DependencyProperty.Register(nameof (ContentFront), typeof (object), typeof (FlipPanel));
    public static readonly DependencyProperty ContentBackProperty = DependencyProperty.Register(nameof (ContentBack), typeof (object), typeof (FlipPanel));
    public static readonly DependencyProperty AspectRatioProperty = DependencyProperty.Register(nameof (AspectRatio), typeof (double), typeof (FlipPanel), new PropertyMetadata((object) 0.5));
    public static readonly DependencyProperty IsFlippedProperty = DependencyProperty.Register(nameof (IsFlipped), typeof (bool), typeof (FlipPanel), new PropertyMetadata((object) false));
    public static readonly RoutedEvent FlippedFrontToBackEvent = EventManager.RegisterRoutedEvent("FlippedFrontToBack", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (FlipPanel));
    public static readonly RoutedEvent FlippedBackToFrontEvent = EventManager.RegisterRoutedEvent("FlippedBackToFront", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (FlipPanel));
    public Command flipCommand;

    static FlipPanel() => FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (FlipPanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (FlipPanel)));

    public FlipPanel()
    {
      this.SizeChanged += new SizeChangedEventHandler(this.FlipPanel_SizeChanged);
      this.flipCommand = new Command(new Action(this.Flip));
    }

    private void FlipPanel_SizeChanged(object sender, SizeChangedEventArgs e) => this.AspectRatio = this.ActualHeight / this.ActualWidth;

    private void Flip()
    {
      if (this.IsFlipped)
      {
        this.RaiseEvent(new RoutedEventArgs(FlipPanel.FlippedBackToFrontEvent));
        this.IsFlipped = false;
      }
      else
      {
        this.RaiseEvent(new RoutedEventArgs(FlipPanel.FlippedFrontToBackEvent));
        this.IsFlipped = true;
      }
    }

    public object ContentFront
    {
      get => this.GetValue(FlipPanel.ContentFrontProperty);
      set => this.SetValue(FlipPanel.ContentFrontProperty, value);
    }

    public object ContentBack
    {
      get => this.GetValue(FlipPanel.ContentBackProperty);
      set => this.SetValue(FlipPanel.ContentBackProperty, value);
    }

    public double AspectRatio
    {
      get => (double) (float) this.GetValue(FlipPanel.AspectRatioProperty);
      set => this.SetValue(FlipPanel.AspectRatioProperty, (object) value);
    }

    public bool IsFlipped
    {
      get => (bool) this.GetValue(FlipPanel.IsFlippedProperty);
      set => this.SetValue(FlipPanel.IsFlippedProperty, (object) value);
    }

    public Command FlipCommand => this.flipCommand;

    public event RoutedEventHandler FlippedFrontToBack
    {
      add => this.AddHandler(FlipPanel.FlippedFrontToBackEvent, (Delegate) value);
      remove => this.RemoveHandler(FlipPanel.FlippedFrontToBackEvent, (Delegate) value);
    }

    public event RoutedEventHandler FlippedBackToFront
    {
      add => this.AddHandler(FlipPanel.FlippedBackToFrontEvent, (Delegate) value);
      remove => this.RemoveHandler(FlipPanel.FlippedBackToFrontEvent, (Delegate) value);
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Apex.Behaviours.SmoothScrollingBehaviour
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media.Animation;

namespace Apex.Behaviours
{
  public class SmoothScrollingBehaviour : Behavior<ScrollViewer>
  {
    public static readonly DependencyProperty SmoothVerticalOffsetProperty = DependencyProperty.Register(nameof (SmoothVerticalOffset), typeof (double), typeof (SmoothScrollingBehaviour), new PropertyMetadata(new PropertyChangedCallback(SmoothScrollingBehaviour.OnSmoothVerticalOffsetChanged)));
    public static readonly DependencyProperty SmoothHorizonalOffsetProperty = DependencyProperty.Register(nameof (SmoothHorizonalOffset), typeof (double), typeof (SmoothScrollingBehaviour), new PropertyMetadata(new PropertyChangedCallback(SmoothScrollingBehaviour.OnSmoothHorizonalOffsetChanged)));

    protected override void OnAttached() => base.OnAttached();

    public void SmoothScroll(double? horizontalPosition, double? verticalPosition)
    {
      Storyboard storyboard = new Storyboard();
      if (horizontalPosition.HasValue)
      {
        DoubleAnimation doubleAnimation1 = new DoubleAnimation();
        doubleAnimation1.To = new double?(horizontalPosition.Value);
        doubleAnimation1.DecelerationRatio = 0.8;
        doubleAnimation1.Duration = (Duration) TimeSpan.FromMilliseconds(300.0);
        DoubleAnimation doubleAnimation2 = doubleAnimation1;
        storyboard.Children.Add((Timeline) doubleAnimation2);
        Storyboard.SetTarget((DependencyObject) doubleAnimation2, (DependencyObject) this);
        Storyboard.SetTargetProperty((DependencyObject) doubleAnimation2, new PropertyPath((object) SmoothScrollingBehaviour.SmoothHorizonalOffsetProperty));
      }
      if (verticalPosition.HasValue)
      {
        DoubleAnimation doubleAnimation1 = new DoubleAnimation();
        doubleAnimation1.To = new double?(verticalPosition.Value);
        doubleAnimation1.DecelerationRatio = 0.8;
        doubleAnimation1.Duration = (Duration) TimeSpan.FromMilliseconds(300.0);
        DoubleAnimation doubleAnimation2 = doubleAnimation1;
        storyboard.Children.Add((Timeline) doubleAnimation2);
        Storyboard.SetTarget((DependencyObject) doubleAnimation2, (DependencyObject) this);
        Storyboard.SetTargetProperty((DependencyObject) doubleAnimation2, new PropertyPath((object) SmoothScrollingBehaviour.SmoothVerticalOffsetProperty));
      }
      storyboard.Begin();
    }

    private void OnSmoothVerticalOffsetChanged(DependencyPropertyChangedEventArgs e) => this.AssociatedObject.ScrollToVerticalOffset((double) e.NewValue);

    private void OnSmoothHorizonalOffsetChanged(DependencyPropertyChangedEventArgs e) => this.AssociatedObject.ScrollToHorizontalOffset((double) e.NewValue);

    private static void OnSmoothVerticalOffsetChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      if (!(d is SmoothScrollingBehaviour scrollingBehaviour))
        return;
      scrollingBehaviour.OnSmoothVerticalOffsetChanged(e);
    }

    private static void OnSmoothHorizonalOffsetChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      if (!(d is SmoothScrollingBehaviour scrollingBehaviour))
        return;
      scrollingBehaviour.OnSmoothHorizonalOffsetChanged(e);
    }

    public double SmoothHorizonalOffset
    {
      get => (double) this.GetValue(SmoothScrollingBehaviour.SmoothHorizonalOffsetProperty);
      set => this.SetValue(SmoothScrollingBehaviour.SmoothHorizonalOffsetProperty, (object) value);
    }

    public double SmoothVerticalOffset
    {
      get => (double) this.GetValue(SmoothScrollingBehaviour.SmoothVerticalOffsetProperty);
      set => this.SetValue(SmoothScrollingBehaviour.SmoothVerticalOffsetProperty, (object) value);
    }
  }
}

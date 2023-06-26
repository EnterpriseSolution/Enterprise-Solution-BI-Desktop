// Decompiled with JetBrains decompiler
// Type: Apex.Controls.AnimatedScrollViewer
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System.Windows;
using System.Windows.Controls;

namespace Apex.Controls
{
  public class AnimatedScrollViewer : ScrollViewer
  {
    public static DependencyProperty CurrentVerticalOffsetProperty = DependencyProperty.Register(nameof (CurrentVerticalOffset), typeof (double), typeof (AnimatedScrollViewer), new PropertyMetadata(new PropertyChangedCallback(AnimatedScrollViewer.OnVerticalChanged)));
    public static DependencyProperty CurrentHorizontalOffsetProperty = DependencyProperty.Register("CurrentHorizontalOffsetOffset", typeof (double), typeof (AnimatedScrollViewer), new PropertyMetadata(new PropertyChangedCallback(AnimatedScrollViewer.OnHorizontalChanged)));

    public AnimatedScrollViewer() => this.SizeChanged += new SizeChangedEventHandler(this.AnimatedScrollViewer_SizeChanged);

    private void AnimatedScrollViewer_SizeChanged(object sender, SizeChangedEventArgs e)
    {
      double width1 = e.PreviousSize.Width;
      double width2 = e.NewSize.Width;
      double height1 = e.PreviousSize.Height;
      double height2 = e.NewSize.Height;
    }

    private static void OnVerticalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => (d as AnimatedScrollViewer).ScrollToVerticalOffset((double) e.NewValue);

    private static void OnHorizontalChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      (d as AnimatedScrollViewer).ScrollToHorizontalOffset((double) e.NewValue);
    }

    public double CurrentHorizontalOffset
    {
      get => (double) this.GetValue(AnimatedScrollViewer.CurrentHorizontalOffsetProperty);
      set => this.SetValue(AnimatedScrollViewer.CurrentHorizontalOffsetProperty, (object) value);
    }

    public double CurrentVerticalOffset
    {
      get => (double) this.GetValue(AnimatedScrollViewer.CurrentVerticalOffsetProperty);
      set => this.SetValue(AnimatedScrollViewer.CurrentVerticalOffsetProperty, (object) value);
    }
  }
}

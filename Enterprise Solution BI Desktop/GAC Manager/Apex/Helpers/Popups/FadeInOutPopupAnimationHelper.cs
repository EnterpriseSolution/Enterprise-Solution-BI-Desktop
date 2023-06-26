// Decompiled with JetBrains decompiler
// Type: Apex.Helpers.Popups.FadeInOutPopupAnimationHelper
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Apex.Helpers.Popups
{
  public class FadeInOutPopupAnimationHelper : PopupAnimationHelper
  {
    public FadeInOutPopupAnimationHelper()
    {
      this.FadeInDuration = new Duration(TimeSpan.FromMilliseconds(250.0));
      this.FadeOutDuration = new Duration(TimeSpan.FromMilliseconds(250.0));
    }

    protected override void AnimatePopupShow(
      Grid popupHost,
      Grid popupBackground,
      UIElement popupElement)
    {
      popupElement.Opacity = 0.0;
      popupBackground.Opacity = 0.0;
      popupBackground.Background = (Brush) new SolidColorBrush(Color.FromArgb(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue));
      popupHost.Children.Add((UIElement) popupBackground);
      popupHost.Children.Add(popupElement);
      Storyboard storyboard = new Storyboard();
      DoubleAnimation doubleAnimation1 = new DoubleAnimation();
      doubleAnimation1.From = new double?(0.0);
      doubleAnimation1.To = new double?(0.5);
      doubleAnimation1.Duration = this.FadeInDuration;
      DoubleAnimation doubleAnimation2 = doubleAnimation1;
      DoubleAnimation doubleAnimation3 = new DoubleAnimation();
      doubleAnimation3.From = new double?(0.0);
      doubleAnimation3.To = new double?(1.0);
      doubleAnimation3.Duration = this.FadeInDuration;
      DoubleAnimation doubleAnimation4 = doubleAnimation3;
      Storyboard.SetTarget((DependencyObject) doubleAnimation2, (DependencyObject) popupBackground);
      Storyboard.SetTarget((DependencyObject) doubleAnimation4, (DependencyObject) popupElement);
      Storyboard.SetTargetProperty((DependencyObject) doubleAnimation2, new PropertyPath("Opacity", new object[1]
      {
        (object) 0
      }));
      Storyboard.SetTargetProperty((DependencyObject) doubleAnimation4, new PropertyPath("Opacity", new object[1]
      {
        (object) 0
      }));
      storyboard.Children.Add((Timeline) doubleAnimation2);
      storyboard.Children.Add((Timeline) doubleAnimation4);
      storyboard.Begin((FrameworkElement) popupHost);
    }

    protected override void AnimatePopupHide(
      Grid popupHost,
      Grid popupBackground,
      UIElement popupElement)
    {
      Storyboard storyboard = new Storyboard();
      DoubleAnimation doubleAnimation1 = new DoubleAnimation();
      doubleAnimation1.To = new double?(0.0);
      doubleAnimation1.Duration = this.FadeOutDuration;
      DoubleAnimation doubleAnimation2 = doubleAnimation1;
      DoubleAnimation doubleAnimation3 = new DoubleAnimation();
      doubleAnimation3.To = new double?(0.0);
      doubleAnimation3.Duration = this.FadeOutDuration;
      DoubleAnimation doubleAnimation4 = doubleAnimation3;
      Storyboard.SetTarget((DependencyObject) doubleAnimation2, (DependencyObject) popupBackground);
      Storyboard.SetTarget((DependencyObject) doubleAnimation4, (DependencyObject) popupElement);
      Storyboard.SetTargetProperty((DependencyObject) doubleAnimation2, new PropertyPath("Opacity", new object[1]
      {
        (object) 0
      }));
      Storyboard.SetTargetProperty((DependencyObject) doubleAnimation4, new PropertyPath("Opacity", new object[1]
      {
        (object) 0
      }));
      storyboard.Children.Add((Timeline) doubleAnimation2);
      storyboard.Children.Add((Timeline) doubleAnimation4);
      storyboard.Completed += (EventHandler) ((sender, args) =>
      {
        popupHost.Children.Remove((UIElement) popupBackground);
        popupHost.Children.Remove(popupElement);
      });
      storyboard.Begin((FrameworkElement) popupHost);
    }

    public Duration FadeInDuration { get; set; }

    public Duration FadeOutDuration { get; set; }
  }
}

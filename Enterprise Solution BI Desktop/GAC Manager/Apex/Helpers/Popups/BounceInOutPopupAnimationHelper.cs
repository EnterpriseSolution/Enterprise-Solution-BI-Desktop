// Decompiled with JetBrains decompiler
// Type: Apex.Helpers.Popups.BounceInOutPopupAnimationHelper
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
  public class BounceInOutPopupAnimationHelper : PopupAnimationHelper
  {
    private const string TransformationName = "BounceTransformation";

    public BounceInOutPopupAnimationHelper()
    {
      this.BounceInDuration = new Duration(TimeSpan.FromMilliseconds(400.0));
      this.BounceOutDuration = new Duration(TimeSpan.FromMilliseconds(400.0));
      this.BounceInDirection = 315.0;
      this.BounceOutDirection = 45.0;
    }

    protected override void AnimatePopupShow(
      Grid popupHost,
      Grid popupBackground,
      UIElement popupElement)
    {
      if (!(popupElement is FrameworkElement frameworkElement))
        throw new ArgumentException("To use a Bounce Up and Down popup animation, the popup must be a framework element.");
      double num1 = popupHost.ActualHeight + popupHost.ActualWidth;
      double num2 = -num1 * Math.Sin(this.BounceInDirection * Math.PI / 180.0);
      double num3 = num1 * Math.Cos(this.BounceInDirection * Math.PI / 180.0);
      TranslateTransform translateTransform = new TranslateTransform()
      {
        X = num2,
        Y = num3
      };
      frameworkElement.RenderTransform = (Transform) translateTransform;
      popupElement.Opacity = 0.0;
      popupBackground.Opacity = 0.0;
      popupBackground.Background = (Brush) new SolidColorBrush(Color.FromArgb(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue));
      popupHost.Children.Add((UIElement) popupBackground);
      popupHost.Children.Add(popupElement);
      Storyboard storyboard = new Storyboard();
      DoubleAnimation doubleAnimation1 = new DoubleAnimation();
      doubleAnimation1.From = new double?(0.0);
      doubleAnimation1.To = new double?(0.5);
      doubleAnimation1.Duration = this.BounceInDuration;
      DoubleAnimation doubleAnimation2 = doubleAnimation1;
      DoubleAnimation doubleAnimation3 = new DoubleAnimation();
      doubleAnimation3.To = new double?(0.0);
      doubleAnimation3.Duration = this.BounceInDuration;
      DoubleAnimation doubleAnimation4 = doubleAnimation3;
      DoubleAnimation doubleAnimation5 = new DoubleAnimation();
      doubleAnimation5.To = new double?(0.0);
      doubleAnimation5.Duration = this.BounceInDuration;
      DoubleAnimation doubleAnimation6 = doubleAnimation5;
      DoubleAnimation doubleAnimation7 = doubleAnimation4;
      ElasticEase elasticEase1 = new ElasticEase();
      elasticEase1.EasingMode = EasingMode.EaseOut;
      elasticEase1.Oscillations = 2;
      elasticEase1.Springiness = 8.0;
      ElasticEase elasticEase2 = elasticEase1;
      doubleAnimation7.EasingFunction = (IEasingFunction) elasticEase2;
      DoubleAnimation doubleAnimation8 = doubleAnimation6;
      ElasticEase elasticEase3 = new ElasticEase();
      elasticEase3.EasingMode = EasingMode.EaseOut;
      elasticEase3.Oscillations = 2;
      elasticEase3.Springiness = 8.0;
      ElasticEase elasticEase4 = elasticEase3;
      doubleAnimation8.EasingFunction = (IEasingFunction) elasticEase4;
      DoubleAnimation doubleAnimation9 = new DoubleAnimation();
      doubleAnimation9.From = new double?(0.0);
      doubleAnimation9.To = new double?(1.0);
      doubleAnimation9.Duration = this.BounceInDuration;
      DoubleAnimation doubleAnimation10 = doubleAnimation9;
      Storyboard.SetTarget((DependencyObject) doubleAnimation2, (DependencyObject) popupBackground);
      Storyboard.SetTarget((DependencyObject) doubleAnimation4, (DependencyObject) frameworkElement);
      Storyboard.SetTarget((DependencyObject) doubleAnimation6, (DependencyObject) frameworkElement);
      Storyboard.SetTarget((DependencyObject) doubleAnimation10, (DependencyObject) popupElement);
      Storyboard.SetTargetProperty((DependencyObject) doubleAnimation2, new PropertyPath((object) UIElement.OpacityProperty));
      Storyboard.SetTargetProperty((DependencyObject) doubleAnimation4, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)", new object[0]));
      Storyboard.SetTargetProperty((DependencyObject) doubleAnimation6, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.Y)", new object[0]));
      Storyboard.SetTargetProperty((DependencyObject) doubleAnimation10, new PropertyPath((object) UIElement.OpacityProperty));
      storyboard.Children.Add((Timeline) doubleAnimation2);
      storyboard.Children.Add((Timeline) doubleAnimation4);
      storyboard.Children.Add((Timeline) doubleAnimation6);
      storyboard.Children.Add((Timeline) doubleAnimation10);
      storyboard.Begin((FrameworkElement) popupHost);
    }

    protected override void AnimatePopupHide(
      Grid popupHost,
      Grid popupBackground,
      UIElement popupElement)
    {
      if (!(popupElement is FrameworkElement frameworkElement))
        throw new ArgumentException("To use a Bounce Up and Down popup animation, the popup must be a framework element.");
      double num1 = popupHost.ActualHeight + popupHost.ActualWidth;
      double num2 = num1 * Math.Sin(this.BounceOutDirection * Math.PI / 180.0);
      double num3 = -num1 * Math.Cos(this.BounceOutDirection * Math.PI / 180.0);
      Storyboard storyboard = new Storyboard();
      DoubleAnimation doubleAnimation1 = new DoubleAnimation();
      doubleAnimation1.To = new double?(0.0);
      doubleAnimation1.Duration = this.BounceOutDuration;
      DoubleAnimation doubleAnimation2 = doubleAnimation1;
      DoubleAnimation doubleAnimation3 = new DoubleAnimation();
      doubleAnimation3.To = new double?(0.0);
      doubleAnimation3.Duration = this.BounceOutDuration;
      DoubleAnimation doubleAnimation4 = doubleAnimation3;
      DoubleAnimation doubleAnimation5 = new DoubleAnimation();
      doubleAnimation5.To = new double?(num2);
      doubleAnimation5.Duration = this.BounceOutDuration;
      DoubleAnimation doubleAnimation6 = doubleAnimation5;
      DoubleAnimation doubleAnimation7 = new DoubleAnimation();
      doubleAnimation7.To = new double?(num3);
      doubleAnimation7.Duration = this.BounceOutDuration;
      DoubleAnimation doubleAnimation8 = doubleAnimation7;
      Storyboard.SetTarget((DependencyObject) doubleAnimation2, (DependencyObject) popupBackground);
      Storyboard.SetTarget((DependencyObject) doubleAnimation4, (DependencyObject) popupElement);
      Storyboard.SetTarget((DependencyObject) doubleAnimation6, (DependencyObject) frameworkElement);
      Storyboard.SetTarget((DependencyObject) doubleAnimation8, (DependencyObject) frameworkElement);
      Storyboard.SetTargetProperty((DependencyObject) doubleAnimation2, new PropertyPath((object) UIElement.OpacityProperty));
      Storyboard.SetTargetProperty((DependencyObject) doubleAnimation4, new PropertyPath((object) UIElement.OpacityProperty));
      Storyboard.SetTargetProperty((DependencyObject) doubleAnimation6, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)", new object[0]));
      Storyboard.SetTargetProperty((DependencyObject) doubleAnimation8, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.Y)", new object[0]));
      storyboard.Children.Add((Timeline) doubleAnimation2);
      storyboard.Children.Add((Timeline) doubleAnimation4);
      storyboard.Children.Add((Timeline) doubleAnimation6);
      storyboard.Children.Add((Timeline) doubleAnimation8);
      storyboard.Completed += (EventHandler) ((sender, args) =>
      {
        popupHost.Children.Remove((UIElement) popupBackground);
        popupHost.Children.Remove(popupElement);
      });
      storyboard.Begin((FrameworkElement) popupHost);
    }

    public Duration BounceInDuration { get; set; }

    public Duration BounceOutDuration { get; set; }

    public double BounceInDirection { get; set; }

    public double BounceOutDirection { get; set; }
  }
}

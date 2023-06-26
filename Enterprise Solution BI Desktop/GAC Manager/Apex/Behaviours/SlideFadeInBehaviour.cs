// Decompiled with JetBrains decompiler
// Type: Apex.Behaviours.SlideFadeInBehaviour
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using Apex.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Apex.Behaviours
{
  public class SlideFadeInBehaviour : Behavior<UIElement>
  {
    private const double SlideDistance = 40.0;
    public static readonly DependencyProperty DurationProperty = DependencyProperty.Register(nameof (Duration), typeof (Duration), typeof (SlideFadeInBehaviour), new PropertyMetadata((object) new Duration(TimeSpan.FromMilliseconds(750.0))));
    private static readonly DependencyProperty BeginTimeProperty = DependencyProperty.Register(nameof (BeginTime), typeof (TimeSpan), typeof (SlideFadeInBehaviour), new PropertyMetadata((object) TimeSpan.FromMilliseconds(0.0)));

    protected override void OnAttached()
    {
      base.OnAttached();
      this.AssociatedObject.Opacity = 0.0;
    }

    public static void DoSlideFadeIn(FrameworkElement container)
    {
      List<SlideFadeInBehaviour> source = new List<SlideFadeInBehaviour>();
      foreach (UIElement logicalChild in container.GetLogicalChildren<UIElement>())
        source.AddRange(Interaction.GetBehaviors((DependencyObject) logicalChild).Where<Behavior>((Func<Behavior, bool>) (b => b is SlideFadeInBehaviour)).Select<Behavior, SlideFadeInBehaviour>((Func<Behavior, SlideFadeInBehaviour>) (b => b as SlideFadeInBehaviour)));
      IEnumerable<Timeline> timelines = source.SelectMany<SlideFadeInBehaviour, Timeline>((Func<SlideFadeInBehaviour, IEnumerable<Timeline>>) (s => s.CreateAnimations()));
      Storyboard storyboard = new Storyboard();
      foreach (Timeline timeline in timelines)
        storyboard.Children.Add(timeline);
      storyboard.Begin(container);
    }

    private IEnumerable<Timeline> CreateAnimations()
    {
      this.AssociatedObject.RenderTransform = (Transform) new TranslateTransform()
      {
        X = -40.0,
        Y = 0.0
      };
      DoubleAnimation doubleAnimation1 = new DoubleAnimation();
      doubleAnimation1.From = new double?(0.0);
      doubleAnimation1.To = new double?(1.0);
      doubleAnimation1.Duration = this.Duration;
      doubleAnimation1.BeginTime = new TimeSpan?(this.BeginTime);
      DoubleAnimation doubleAnimation2 = doubleAnimation1;
      DoubleAnimation doubleAnimation3 = new DoubleAnimation();
      doubleAnimation3.To = new double?(0.0);
      doubleAnimation3.Duration = this.Duration;
      doubleAnimation3.BeginTime = new TimeSpan?(this.BeginTime);
      DoubleAnimation doubleAnimation4 = doubleAnimation3;
      DoubleAnimation doubleAnimation5 = doubleAnimation4;
      CubicEase cubicEase1 = new CubicEase();
      cubicEase1.EasingMode = EasingMode.EaseOut;
      CubicEase cubicEase2 = cubicEase1;
      doubleAnimation5.EasingFunction = (IEasingFunction) cubicEase2;
      Storyboard.SetTarget((DependencyObject) doubleAnimation2, (DependencyObject) this.AssociatedObject);
      Storyboard.SetTarget((DependencyObject) doubleAnimation4, (DependencyObject) this.AssociatedObject);
      Storyboard.SetTargetProperty((DependencyObject) doubleAnimation2, new PropertyPath((object) UIElement.OpacityProperty));
      Storyboard.SetTargetProperty((DependencyObject) doubleAnimation4, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)", new object[0]));
      return (IEnumerable<Timeline>) new List<Timeline>()
      {
        (Timeline) doubleAnimation2,
        (Timeline) doubleAnimation4
      };
    }

    public Duration Duration
    {
      get => (Duration) this.GetValue(SlideFadeInBehaviour.DurationProperty);
      set => this.SetValue(SlideFadeInBehaviour.DurationProperty, (object) value);
    }

    public TimeSpan BeginTime
    {
      get => (TimeSpan) this.GetValue(SlideFadeInBehaviour.BeginTimeProperty);
      set => this.SetValue(SlideFadeInBehaviour.BeginTimeProperty, (object) value);
    }
  }
}

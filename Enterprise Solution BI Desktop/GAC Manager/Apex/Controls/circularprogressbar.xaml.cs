// Decompiled with JetBrains decompiler
// Type: Apex.Controls.CircularProgressBar
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Apex.Controls
{
  public partial class CircularProgressBar : UserControl, IComponentConnector
  {
    private readonly DispatcherTimer animationTimer;
    public static DependencyProperty ProgressTextProperty = DependencyProperty.Register(nameof (ProgressText), typeof (string), typeof (CircularProgressBar));
    //internal CircularProgressBar circularProgressBar;
    //internal Grid LayoutRoot;
    //internal Ellipse C0;
    //internal Ellipse C1;
    //internal Ellipse C2;
    //internal Ellipse C3;
    //internal Ellipse C4;
    //internal Ellipse C5;
    //internal Ellipse C6;
    //internal Ellipse C7;
    //internal Ellipse C8;
    //internal RotateTransform SpinnerRotate;
    //private bool _contentLoaded;

    public CircularProgressBar()
    {
      this.InitializeComponent();
      this.animationTimer = new DispatcherTimer(DispatcherPriority.ContextIdle, this.Dispatcher);
      this.animationTimer.Interval = new TimeSpan(0, 0, 0, 0, 75);
    }

    private void Start()
    {
      this.animationTimer.Tick += new EventHandler(this.HandleAnimationTick);
      this.animationTimer.Start();
    }

    private void Stop()
    {
      this.animationTimer.Stop();
      this.animationTimer.Tick -= new EventHandler(this.HandleAnimationTick);
    }

    private void HandleAnimationTick(object sender, EventArgs e) => this.SpinnerRotate.Angle = (this.SpinnerRotate.Angle + 36.0) % 360.0;

    private void HandleLoaded(object sender, RoutedEventArgs e)
    {
      this.SetPosition(this.C0, Math.PI, 0.0, Math.PI / 5.0);
      this.SetPosition(this.C1, Math.PI, 1.0, Math.PI / 5.0);
      this.SetPosition(this.C2, Math.PI, 2.0, Math.PI / 5.0);
      this.SetPosition(this.C3, Math.PI, 3.0, Math.PI / 5.0);
      this.SetPosition(this.C4, Math.PI, 4.0, Math.PI / 5.0);
      this.SetPosition(this.C5, Math.PI, 5.0, Math.PI / 5.0);
      this.SetPosition(this.C6, Math.PI, 6.0, Math.PI / 5.0);
      this.SetPosition(this.C7, Math.PI, 7.0, Math.PI / 5.0);
      this.SetPosition(this.C8, Math.PI, 8.0, Math.PI / 5.0);
    }

    private void SetPosition(Ellipse ellipse, double offset, double posOffSet, double step)
    {
      ellipse.SetValue(Canvas.LeftProperty, (object) (50.0 + Math.Sin(offset + posOffSet * step) * 50.0));
      ellipse.SetValue(Canvas.TopProperty, (object) (50.0 + Math.Cos(offset + posOffSet * step) * 50.0));
    }

    private void HandleUnloaded(object sender, RoutedEventArgs e) => this.Stop();

    private void HandleVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      if ((bool) e.NewValue)
        this.Start();
      else
        this.Stop();
    }

    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
    }

    public string ProgressText
    {
      get => (string) this.GetValue(CircularProgressBar.ProgressTextProperty);
      set => this.SetValue(CircularProgressBar.ProgressTextProperty, (object) value);
    }

    //[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    //[DebuggerNonUserCode]
    //public void InitializeComponent()
    //{
    //  if (this._contentLoaded)
    //    return;
    //  this._contentLoaded = true;
    //  Application.LoadComponent((object) this, new Uri("/Apex;component/controls/circularprogressbar.xaml", UriKind.Relative));
    //}

    //[EditorBrowsable(EditorBrowsableState.Never)]
    //[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    //[DebuggerNonUserCode]
    //void IComponentConnector.Connect(int connectionId, object target)
    //{
    //  switch (connectionId)
    //  {
    //    case 1:
    //      this.circularProgressBar = (CircularProgressBar) target;
    //      this.circularProgressBar.IsVisibleChanged += new DependencyPropertyChangedEventHandler(this.HandleVisibleChanged);
    //      this.circularProgressBar.Loaded += new RoutedEventHandler(this.UserControl_Loaded);
    //      break;
    //    case 2:
    //      this.LayoutRoot = (Grid) target;
    //      break;
    //    case 3:
    //      ((FrameworkElement) target).Loaded += new RoutedEventHandler(this.HandleLoaded);
    //      ((FrameworkElement) target).Unloaded += new RoutedEventHandler(this.HandleUnloaded);
    //      break;
    //    case 4:
    //      this.C0 = (Ellipse) target;
    //      break;
    //    case 5:
    //      this.C1 = (Ellipse) target;
    //      break;
    //    case 6:
    //      this.C2 = (Ellipse) target;
    //      break;
    //    case 7:
    //      this.C3 = (Ellipse) target;
    //      break;
    //    case 8:
    //      this.C4 = (Ellipse) target;
    //      break;
    //    case 9:
    //      this.C5 = (Ellipse) target;
    //      break;
    //    case 10:
    //      this.C6 = (Ellipse) target;
    //      break;
    //    case 11:
    //      this.C7 = (Ellipse) target;
    //      break;
    //    case 12:
    //      this.C8 = (Ellipse) target;
    //      break;
    //    case 13:
    //      this.SpinnerRotate = (RotateTransform) target;
    //      break;
    //    default:
    //      this._contentLoaded = true;
    //      break;
    //  }
    //}
  }
}

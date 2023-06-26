// Decompiled with JetBrains decompiler
// Type: Apex.Controls.MultiBorder
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Apex.Controls
{
  public class MultiBorder : ContentControl
  {
    public static DependencyProperty BorderBrushLeftProperty = DependencyProperty.Register(nameof (BorderBrushLeft), typeof (Brush), typeof (MultiBorder));
    public static DependencyProperty BorderBrushTopProperty = DependencyProperty.Register(nameof (BorderBrushTop), typeof (Brush), typeof (MultiBorder));
    public static DependencyProperty BorderBrushRightProperty = DependencyProperty.Register(nameof (BorderBrushRight), typeof (Brush), typeof (MultiBorder));
    public static DependencyProperty BorderBrushBottomProperty = DependencyProperty.Register(nameof (BorderBrushBottom), typeof (Brush), typeof (MultiBorder));
    public static DependencyProperty BorderThicknessLeftProperty = DependencyProperty.Register(nameof (BorderThicknessLeft), typeof (double), typeof (MultiBorder), new PropertyMetadata((object) 1.0));
    public static DependencyProperty BorderThicknessTopProperty = DependencyProperty.Register(nameof (BorderThicknessTop), typeof (double), typeof (MultiBorder), new PropertyMetadata((object) 1.0));
    public static DependencyProperty BorderThicknessRightProperty = DependencyProperty.Register(nameof (BorderThicknessRight), typeof (double), typeof (MultiBorder), new PropertyMetadata((object) 1.0));
    public static DependencyProperty BorderThicknessBottomProperty = DependencyProperty.Register(nameof (BorderThicknessBottom), typeof (double), typeof (MultiBorder), new PropertyMetadata((object) 1.0));

    static MultiBorder() => FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (MultiBorder), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (MultiBorder)));

    public Brush BorderBrushLeft
    {
      get => (Brush) this.GetValue(MultiBorder.BorderBrushLeftProperty);
      set => this.SetValue(MultiBorder.BorderBrushLeftProperty, (object) value);
    }

    public Brush BorderBrushTop
    {
      get => (Brush) this.GetValue(MultiBorder.BorderBrushTopProperty);
      set => this.SetValue(MultiBorder.BorderBrushTopProperty, (object) value);
    }

    public Brush BorderBrushRight
    {
      get => (Brush) this.GetValue(MultiBorder.BorderBrushRightProperty);
      set => this.SetValue(MultiBorder.BorderBrushRightProperty, (object) value);
    }

    public Brush BorderBrushBottom
    {
      get => (Brush) this.GetValue(MultiBorder.BorderBrushBottomProperty);
      set => this.SetValue(MultiBorder.BorderBrushBottomProperty, (object) value);
    }

    public double BorderThicknessLeft
    {
      get => (double) this.GetValue(MultiBorder.BorderThicknessLeftProperty);
      set => this.SetValue(MultiBorder.BorderThicknessLeftProperty, (object) value);
    }

    public double BorderThicknessTop
    {
      get => (double) this.GetValue(MultiBorder.BorderThicknessTopProperty);
      set => this.SetValue(MultiBorder.BorderThicknessTopProperty, (object) value);
    }

    public double BorderThicknessRight
    {
      get => (double) this.GetValue(MultiBorder.BorderThicknessRightProperty);
      set => this.SetValue(MultiBorder.BorderThicknessRightProperty, (object) value);
    }

    public double BorderThicknessBottom
    {
      get => (double) this.GetValue(MultiBorder.BorderThicknessBottomProperty);
      set => this.SetValue(MultiBorder.BorderThicknessBottomProperty, (object) value);
    }
  }
}

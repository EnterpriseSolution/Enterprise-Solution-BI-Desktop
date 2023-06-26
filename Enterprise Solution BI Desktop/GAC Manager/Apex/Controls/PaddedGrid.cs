// Decompiled with JetBrains decompiler
// Type: Apex.Controls.PaddedGrid
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Apex.Controls
{
  public class PaddedGrid : ApexGrid
  {
    private static readonly DependencyProperty PaddingProperty = DependencyProperty.Register(nameof (Padding), typeof (Thickness), typeof (PaddedGrid), (PropertyMetadata) new FrameworkPropertyMetadata((object) new Thickness(0.0), FrameworkPropertyMetadataOptions.AffectsArrange, new PropertyChangedCallback(PaddedGrid.OnPaddingChanged)));

    public PaddedGrid() => this.Loaded += new RoutedEventHandler(this.PaddedGrid_Loaded);

    private void PaddedGrid_Loaded(object sender, RoutedEventArgs e)
    {
      int childrenCount = VisualTreeHelper.GetChildrenCount((DependencyObject) this);
      for (int childIndex = 0; childIndex < childrenCount; ++childIndex)
        BindingOperations.SetBinding(VisualTreeHelper.GetChild((DependencyObject) this, childIndex), FrameworkElement.MarginProperty, (BindingBase) new Binding()
        {
          Source = (object) this,
          Path = new PropertyPath("Padding", new object[0])
        });
    }

    private static void OnPaddingChanged(
      DependencyObject dependencyObject,
      DependencyPropertyChangedEventArgs args)
    {
      if (!(dependencyObject is PaddedGrid paddedGrid))
        return;
      paddedGrid.InvalidateArrange();
    }

    [Category("Common Properties")]
    [Description("The padding property.")]
    public Thickness Padding
    {
      get => (Thickness) this.GetValue(PaddedGrid.PaddingProperty);
      set => this.SetValue(PaddedGrid.PaddingProperty, (object) value);
    }
  }
}

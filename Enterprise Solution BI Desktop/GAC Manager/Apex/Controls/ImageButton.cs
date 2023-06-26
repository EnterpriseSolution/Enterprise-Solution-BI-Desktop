// Decompiled with JetBrains decompiler
// Type: Apex.Controls.ImageButton
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Apex.Controls
{
  public class ImageButton : Button
  {
    public static readonly DependencyProperty NormalImageSourceProperty = DependencyProperty.Register(nameof (NormalImageSource), typeof (ImageSource), typeof (ImageButton), new PropertyMetadata((object) null, new PropertyChangedCallback(ImageButton.OnNormalImageSourceChanged)));
    public static readonly DependencyProperty MouseOverImageSourceProperty = DependencyProperty.Register(nameof (MouseOverImageSource), typeof (ImageSource), typeof (ImageButton), new PropertyMetadata((object) null, new PropertyChangedCallback(ImageButton.OnMouseOverImageSourceChanged)));
    public static readonly DependencyProperty PressedImageSourceProperty = DependencyProperty.Register(nameof (PressedImageSource), typeof (ImageSource), typeof (ImageButton), new PropertyMetadata((object) null, new PropertyChangedCallback(ImageButton.OnPressedImageSourceChanged)));
    public static readonly DependencyProperty DisabledImageSourceProperty = DependencyProperty.Register(nameof (DisabledImageSource), typeof (ImageSource), typeof (ImageButton), new PropertyMetadata((object) null, new PropertyChangedCallback(ImageButton.OnDisabledImageSourceChanged)));

    static ImageButton() => FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (ImageButton), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (ImageButton)));

    public ImageSource NormalImageSource
    {
      get => (ImageSource) this.GetValue(ImageButton.NormalImageSourceProperty);
      set => this.SetValue(ImageButton.NormalImageSourceProperty, (object) value);
    }

    private static void OnNormalImageSourceChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs args)
    {
    }

    public ImageSource MouseOverImageSource
    {
      get => (ImageSource) this.GetValue(ImageButton.MouseOverImageSourceProperty);
      set => this.SetValue(ImageButton.MouseOverImageSourceProperty, (object) value);
    }

    private static void OnMouseOverImageSourceChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs args)
    {
    }

    public ImageSource PressedImageSource
    {
      get => (ImageSource) this.GetValue(ImageButton.PressedImageSourceProperty);
      set => this.SetValue(ImageButton.PressedImageSourceProperty, (object) value);
    }

    private static void OnPressedImageSourceChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs args)
    {
    }

    public ImageSource DisabledImageSource
    {
      get => (ImageSource) this.GetValue(ImageButton.DisabledImageSourceProperty);
      set => this.SetValue(ImageButton.DisabledImageSourceProperty, (object) value);
    }

    private static void OnDisabledImageSourceChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs args)
    {
    }
  }
}

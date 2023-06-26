// Decompiled with JetBrains decompiler
// Type: Apex.Adorners.Adorner
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System.Windows;
using System.Windows.Media;

namespace Apex.Adorners
{
  public class Adorner : DependencyObject
  {
    private TranslateTransform translation = new TranslateTransform();
    private static readonly DependencyProperty UIElementProperty = DependencyProperty.Register(nameof (UIElement), typeof (UIElement), typeof (Adorner), new PropertyMetadata((PropertyChangedCallback) null));

    public TranslateTransform Translation => this.translation;

    public AdornerLayer ParentAdornerLayer { get; set; }

    public UIElement UIElement
    {
      get => (UIElement) this.GetValue(Adorner.UIElementProperty);
      set => this.SetValue(Adorner.UIElementProperty, (object) value);
    }
  }
}

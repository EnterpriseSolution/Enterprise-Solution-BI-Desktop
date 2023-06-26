// Decompiled with JetBrains decompiler
// Type: Apex.Adorners.VisualAdorner
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using Apex.Extensions;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Apex.Adorners
{
  public class VisualAdorner : Adorner
  {
    public VisualAdorner(FrameworkElement visual)
    {
      ImageBrush imageBrush = new ImageBrush((ImageSource) visual.RenderBitmap());
      Rectangle rectangle = new Rectangle();
      rectangle.Width = visual.ActualWidth;
      rectangle.Height = visual.ActualHeight;
      rectangle.Fill = (Brush) imageBrush;
      rectangle.Opacity = 1.0;
      rectangle.IsHitTestVisible = false;
      this.UIElement = (UIElement) rectangle;
    }
  }
}

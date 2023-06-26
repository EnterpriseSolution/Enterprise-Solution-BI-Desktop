// Decompiled with JetBrains decompiler
// Type: Apex.Extensions.FrameworkElementExtensions
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Apex.Extensions
{
  internal static class FrameworkElementExtensions
  {
    public static Window GetParentWindow(this FrameworkElement element)
    {
      DependencyObject parent;
      for (DependencyObject current = (DependencyObject) element; current != null; current = parent)
      {
        parent = LogicalTreeHelper.GetParent(current);
        if (parent is Window)
          return parent as Window;
      }
      return (Window) null;
    }

    public static FrameworkElement GetTopLevelParent(this FrameworkElement element)
    {
      for (FrameworkElement frameworkElement = element; frameworkElement != null; frameworkElement = frameworkElement.Parent as FrameworkElement)
      {
        if (frameworkElement.Parent == null)
          return frameworkElement;
      }
      return (FrameworkElement) null;
    }

    public static BitmapSource RenderBitmap(this FrameworkElement element)
    {
      VisualBrush visualBrush = new VisualBrush((Visual) element);
      DrawingVisual drawingVisual = new DrawingVisual();
      DrawingContext drawingContext = drawingVisual.RenderOpen();
      drawingContext.DrawRectangle((Brush) visualBrush, (Pen) null, new Rect(0.0, 0.0, element.ActualWidth, element.ActualHeight));
      drawingContext.Close();
      double num = 96.0;
      RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int) element.ActualWidth, (int) element.ActualHeight, num, num, PixelFormats.Default);
      renderTargetBitmap.Render((Visual) drawingVisual);
      return (BitmapSource) renderTargetBitmap;
    }
  }
}

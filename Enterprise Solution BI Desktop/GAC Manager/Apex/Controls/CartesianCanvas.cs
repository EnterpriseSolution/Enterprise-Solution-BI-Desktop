// Decompiled with JetBrains decompiler
// Type: Apex.Controls.CartesianCanvas
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System.Windows;
using System.Windows.Controls;

namespace Apex.Controls
{
  public class CartesianCanvas : Canvas
  {
    protected Point origin = new Point(0.0, 0.0);

    public Point AdjustPoint(Point point) => new Point(point.X - this.origin.X, -(point.Y - this.origin.Y));

    protected override Size ArrangeOverride(Size arrangeSize)
    {
      Point point = new Point(arrangeSize.Width / 2.0, arrangeSize.Height / 2.0);
      this.origin = point;
      foreach (UIElement internalChild in this.InternalChildren)
      {
        if (internalChild != null)
        {
          double num1 = 0.0;
          double num2 = 0.0;
          double left = Canvas.GetLeft(internalChild);
          if (!double.IsNaN(left))
            num1 = left;
          double top = Canvas.GetTop(internalChild);
          if (!double.IsNaN(top))
            num2 = top;
          internalChild.Arrange(new Rect(new Point(point.X + num1, point.Y - num2), internalChild.DesiredSize));
        }
      }
      return arrangeSize;
    }
  }
}

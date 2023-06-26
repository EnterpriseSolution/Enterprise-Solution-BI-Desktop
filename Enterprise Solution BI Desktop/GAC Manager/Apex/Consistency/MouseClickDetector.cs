// Decompiled with JetBrains decompiler
// Type: Apex.Consistency.MouseClickDetector
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.Windows;
using System.Windows.Input;

namespace Apex.Consistency
{
  internal static class MouseClickDetector
  {
    private const long k_DoubleClickSpeed = 500;
    private const double k_MaxMoveDistance = 10.0;
    private static long _LastClickTicks = 0;
    private static Point _LastPosition;
    private static WeakReference _LastSender;

    internal static bool IsDoubleClick(object sender, MouseButtonEventArgs e)
    {
      Point position = e.GetPosition((IInputElement) null);
      long ticks = DateTime.Now.Ticks;
      bool flag = (ticks - MouseClickDetector._LastClickTicks) / 10000L <= 500L;
      if (MouseClickDetector._LastSender != null && sender.Equals(MouseClickDetector._LastSender.Target) && flag && position.Distance(MouseClickDetector._LastPosition) <= 10.0)
      {
        MouseClickDetector._LastClickTicks = 0L;
        MouseClickDetector._LastSender = (WeakReference) null;
        return true;
      }
      MouseClickDetector._LastClickTicks = ticks;
      MouseClickDetector._LastPosition = position;
      if (!flag)
        MouseClickDetector._LastSender = new WeakReference(sender);
      return false;
    }

    private static double Distance(this Point pointA, Point pointB)
    {
      double num1 = pointA.X - pointB.X;
      double num2 = pointA.Y - pointB.Y;
      return Math.Sqrt(num1 * num1 + num2 * num2);
    }
  }
}

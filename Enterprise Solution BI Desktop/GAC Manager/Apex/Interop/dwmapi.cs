// Decompiled with JetBrains decompiler
// Type: Apex.Interop.dwmapi
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace Apex.Interop
{
  internal class dwmapi
  {
    [DllImport("dwmapi.dll")]
    internal static extern int DwmSetWindowAttribute(
      IntPtr hwnd,
      int attr,
      ref int attrValue,
      int attrSize);

    [DllImport("dwmapi.dll")]
    internal static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margins pMarInset);

    public static bool DropShadow(IntPtr windowHandle)
    {
      try
      {
        int attrValue = 2;
        if (dwmapi.DwmSetWindowAttribute(windowHandle, 2, ref attrValue, 4) != 0)
          return false;
        Margins pMarInset = new Margins()
        {
          Bottom = 0,
          Left = 0,
          Right = 0,
          Top = 0
        };
        return dwmapi.DwmExtendFrameIntoClientArea(windowHandle, ref pMarInset) == 0;
      }
      catch (Exception ex)
      {
        return false;
      }
    }
  }
}

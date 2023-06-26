// Decompiled with JetBrains decompiler
// Type: Apex.Controls.CustomWindow
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using Apex.Interop;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace Apex.Controls
{
  public class CustomWindow : Window
  {
    private static readonly DependencyProperty HasDropShadowProperty = DependencyProperty.Register(nameof (HasDropShadow), typeof (bool), typeof (CustomWindow), new PropertyMetadata((object) true, new PropertyChangedCallback(CustomWindow.OnHasDropShadowChanged)));

    public CustomWindow()
    {
      this.ResizeMode = ResizeMode.NoResize;
      this.WindowStyle = WindowStyle.None;
      this.SourceInitialized += new EventHandler(this.CustomShell_SourceInitialized);
    }

    private void CustomShell_SourceInitialized(object sender, EventArgs e)
    {
      IntPtr handle = new WindowInteropHelper((Window) this).Handle;
      HwndSource.FromHwnd(handle).AddHook(new HwndSourceHook(CustomWindow.WindowProc));
      dwmapi.DropShadow(handle);
    }

    private static IntPtr WindowProc(
      IntPtr hwnd,
      int msg,
      IntPtr wParam,
      IntPtr lParam,
      ref bool handled)
    {
      if (msg == 36)
      {
        CustomWindow.WmGetMinMaxInfo(hwnd, lParam);
        handled = true;
      }
      return (IntPtr) 0;
    }

    private static void WmGetMinMaxInfo(IntPtr hwnd, IntPtr lParam)
    {
      MINMAXINFO structure = (MINMAXINFO) Marshal.PtrToStructure(lParam, typeof (MINMAXINFO));
      int flags = 2;
      IntPtr hMonitor = User32.MonitorFromWindow(hwnd, flags);
      if (hMonitor != IntPtr.Zero)
      {
        MONITORINFO lpmi = new MONITORINFO();
        User32.GetMonitorInfo(hMonitor, lpmi);
        RECT rcWork = lpmi.rcWork;
        RECT rcMonitor = lpmi.rcMonitor;
        structure.ptMaxPosition.x = Math.Abs(rcWork.left - rcMonitor.left);
        structure.ptMaxPosition.y = Math.Abs(rcWork.top - rcMonitor.top);
        structure.ptMaxSize.x = Math.Abs(rcWork.right - rcWork.left);
        structure.ptMaxSize.y = Math.Abs(rcWork.bottom - rcWork.top);
      }
      Marshal.StructureToPtr((object) structure, lParam, true);
    }

    public bool HasDropShadow
    {
      get => (bool) this.GetValue(CustomWindow.HasDropShadowProperty);
      set => this.SetValue(CustomWindow.HasDropShadowProperty, (object) value);
    }

    private static void OnHasDropShadowChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs args)
    {
    }
  }
}

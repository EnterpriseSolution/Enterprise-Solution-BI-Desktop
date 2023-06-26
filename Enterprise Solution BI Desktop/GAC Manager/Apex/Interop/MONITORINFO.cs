// Decompiled with JetBrains decompiler
// Type: Apex.Interop.MONITORINFO
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System.Runtime.InteropServices;

namespace Apex.Interop
{
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
  internal class MONITORINFO
  {
    public int cbSize = Marshal.SizeOf(typeof (MONITORINFO));
    public RECT rcMonitor = new RECT();
    public RECT rcWork = new RECT();
    public int dwFlags;
  }
}

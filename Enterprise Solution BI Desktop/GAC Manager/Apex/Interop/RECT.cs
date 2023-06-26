// Decompiled with JetBrains decompiler
// Type: Apex.Interop.RECT
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.Windows;

namespace Apex.Interop
{
  internal struct RECT
  {
    public int left;
    public int top;
    public int right;
    public int bottom;
    public static readonly RECT Empty = new RECT();

    public int Width => Math.Abs(this.right - this.left);

    public int Height => this.bottom - this.top;

    public RECT(int left, int top, int right, int bottom)
    {
      this.left = left;
      this.top = top;
      this.right = right;
      this.bottom = bottom;
    }

    public RECT(RECT rcSrc)
    {
      this.left = rcSrc.left;
      this.top = rcSrc.top;
      this.right = rcSrc.right;
      this.bottom = rcSrc.bottom;
    }

    public bool IsEmpty => this.left >= this.right || this.top >= this.bottom;

    public override string ToString()
    {
      if (this == RECT.Empty)
        return "RECT {Empty}";
      return "RECT { left : " + (object) this.left + " / top : " + (object) this.top + " / right : " + (object) this.right + " / bottom : " + (object) this.bottom + " }";
    }

    public override bool Equals(object obj) => obj is Rect && this == (RECT) obj;

    public override int GetHashCode() => this.left.GetHashCode() + this.top.GetHashCode() + this.right.GetHashCode() + this.bottom.GetHashCode();

    public static bool operator ==(RECT rect1, RECT rect2) => rect1.left == rect2.left && rect1.top == rect2.top && rect1.right == rect2.right && rect1.bottom == rect2.bottom;

    public static bool operator !=(RECT rect1, RECT rect2) => !(rect1 == rect2);
  }
}

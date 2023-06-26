// Decompiled with JetBrains decompiler
// Type: Apex.DragAndDrop.DragAndDropEventArgs
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using Apex.Adorners;
using System;
using System.Windows;

namespace Apex.DragAndDrop
{
  public class DragAndDropEventArgs : EventArgs
  {
    public bool Allow { get; set; }

    public FrameworkElement DragSource { get; set; }

    public FrameworkElement DragElement { get; set; }

    public object DragData { get; set; }

    public FrameworkElement DropTarget { get; set; }

    public Adorner DragAdorner { get; set; }

    public Point InitialElementOffset { get; set; }
  }
}

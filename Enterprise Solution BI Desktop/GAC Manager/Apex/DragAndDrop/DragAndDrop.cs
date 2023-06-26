// Decompiled with JetBrains decompiler
// Type: Apex.DragAndDrop.DragAndDrop
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System.Windows;

namespace Apex.DragAndDrop
{
  public static class DragAndDrop
  {
    public static readonly DependencyProperty IsDragSourceProperty = DependencyProperty.RegisterAttached("IsDragSource", typeof (bool), typeof (FrameworkElement), new PropertyMetadata((object) false));
    private static readonly DependencyProperty IsDropTargetProperty = DependencyProperty.RegisterAttached("IsDropTarget", typeof (bool), typeof (FrameworkElement), new PropertyMetadata((object) false));
    private static readonly DependencyProperty IsDraggableProperty = DependencyProperty.RegisterAttached("IsDraggable", typeof (bool), typeof (FrameworkElement), new PropertyMetadata((object) false));

    public static bool GetIsDragSource(FrameworkElement o) => (bool) o.GetValue(Apex.DragAndDrop.DragAndDrop.IsDragSourceProperty);

    public static void SetIsDragSource(FrameworkElement o, bool value) => o.SetValue(Apex.DragAndDrop.DragAndDrop.IsDragSourceProperty, (object) value);

    public static bool GetIsDropTarget(FrameworkElement o) => (bool) o.GetValue(Apex.DragAndDrop.DragAndDrop.IsDropTargetProperty);

    public static void SetIsDropTarget(FrameworkElement o, bool value) => o.SetValue(Apex.DragAndDrop.DragAndDrop.IsDropTargetProperty, (object) value);

    public static bool GetIsDraggable(DependencyObject o) => (bool) o.GetValue(Apex.DragAndDrop.DragAndDrop.IsDraggableProperty);

    public static void SetIsDraggable(DependencyObject o, bool value) => o.SetValue(Apex.DragAndDrop.DragAndDrop.IsDraggableProperty, (object) value);
  }
}

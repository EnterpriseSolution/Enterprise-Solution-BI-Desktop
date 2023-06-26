// Decompiled with JetBrains decompiler
// Type: Apex.DragAndDrop.DragAndDropHost
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using Apex.Adorners;
using Apex.Consistency;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Apex.DragAndDrop
{
  [TemplatePart(Name = "PART_AdornerLayer", Type = typeof (AdornerLayer))]
  [TemplatePart(Name = "PART_Host", Type = typeof (Grid))]
  public class DragAndDropHost : ContentControl
  {
    private Grid host;
    private AdornerLayer adornerLayer;
    private bool dragging;
    private FrameworkElement dragSource;
    private FrameworkElement dragElement;
    private FrameworkElement dropTarget;
    private object dragData;
    private Adorner dragAdorner;
    private Point initialMousePosition;
    private Point initialElementOffset;
    private Point currentMousePosition;
    private static readonly DependencyProperty MinimumHorizontalDragDistanceProperty = DependencyProperty.Register(nameof (MinimumHorizontalDragDistance), typeof (double), typeof (DragAndDropHost), new PropertyMetadata((object) Apex.Consistency.SystemParameters.MinimumHorizontalDragDistance));
    private static readonly DependencyProperty MinimumVerticalDragDistanceProperty = DependencyProperty.Register(nameof (MinimumVerticalDragDistance), typeof (double), typeof (DragAndDropHost), new PropertyMetadata((object) Apex.Consistency.SystemParameters.MinimumVerticalDragDistance));

    static DragAndDropHost() => FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (DragAndDropHost), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (DragAndDropHost)));

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      try
      {
        this.host = (Grid) this.GetTemplateChild("PART_Host");
        this.adornerLayer = (AdornerLayer) this.GetTemplateChild("PART_AdornerLayer");
      }
      catch
      {
        throw new Exception("Unable to access the internal elements of the Drag and Drop host.");
      }
      this.host.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(this.host_MouseDown);
      this.host.MouseMove += new MouseEventHandler(this.host_MouseMove);
      this.host.MouseLeftButtonUp += new MouseButtonEventHandler(this.host_MouseUp);
    }

    private void host_MouseDown(object sender, MouseButtonEventArgs e)
    {
      HitTest hitTest = new HitTest();
      hitTest.DoHitTest((UIElement) this.host, e.GetPosition((IInputElement) this.host));
      foreach (UIElement hit in hitTest.Hits)
      {
        FrameworkElement dragElement;
        FrameworkElement dragSource;
        if (hit is FrameworkElement && this.IsInDraggableElement((FrameworkElement) hit, out dragElement, out dragSource))
        {
          this.dragElement = dragElement;
          this.dragData = this.dragElement.DataContext;
          this.dragSource = dragSource;
          this.initialMousePosition = e.GetPosition((IInputElement) this.host);
          this.initialElementOffset = e.GetPosition((IInputElement) this.dragElement);
          break;
        }
      }
    }

    private void host_MouseMove(object sender, MouseEventArgs e)
    {
      if (this.dragElement == null)
        return;
      this.currentMousePosition = e.GetPosition((IInputElement) this.host);
      if (!this.dragging && (Math.Abs(this.initialMousePosition.X - this.currentMousePosition.X) >= this.MinimumHorizontalDragDistance || Math.Abs(this.initialMousePosition.Y - this.currentMousePosition.Y) >= this.MinimumHorizontalDragDistance))
      {
        this.DoDragAndDropStart(this.dragSource, this.dragElement, this.dragData);
        if (this.dragging)
          this.host.CaptureMouse();
      }
      if (!this.dragging)
        return;
      if (this.dragAdorner != null)
      {
        this.dragAdorner.Translation.X = this.currentMousePosition.X - this.initialElementOffset.X;
        this.dragAdorner.Translation.Y = this.currentMousePosition.Y - this.initialElementOffset.Y;
      }
      FrameworkElement potentialDropTarget = (FrameworkElement) null;
      HitTest hitTest = new HitTest();
      hitTest.DoHitTest((UIElement) this.host, e.GetPosition((IInputElement) this.host));
      foreach (UIElement hit in hitTest.Hits)
      {
        FrameworkElement dropTarget;
        if (hit is FrameworkElement && this.IsInDropTarget((FrameworkElement) hit, out dropTarget))
        {
          potentialDropTarget = dropTarget;
          break;
        }
      }
      if (potentialDropTarget == null)
      {
        this.dropTarget = (FrameworkElement) null;
      }
      else
      {
        if (potentialDropTarget == this.dropTarget)
          return;
        this.DoContinueDragAndDrop(potentialDropTarget);
      }
    }

    private void host_MouseUp(object sender, MouseButtonEventArgs e)
    {
      if (this.dragging)
      {
        this.host.ReleaseMouseCapture();
        if (this.dragAdorner != null)
          this.adornerLayer.RemoveAdorner(this.dragAdorner);
        this.DoDragAndDropEnd(this.dropTarget);
      }
      this.dragData = (object) null;
      this.dragSource = (FrameworkElement) null;
      this.dragElement = (FrameworkElement) null;
      this.dropTarget = (FrameworkElement) null;
      this.dragAdorner = (Adorner) null;
    }

    private void DoDragAndDropStart(
      FrameworkElement dragSource,
      FrameworkElement dragElement,
      object dragData)
    {
      DragAndDropDelegate dragAndDropStart = this.DragAndDropStart;
      if (dragAndDropStart != null)
      {
        DragAndDropEventArgs args = new DragAndDropEventArgs()
        {
          DragSource = dragSource,
          DragElement = dragElement,
          DragData = dragData,
          Allow = true
        };
        dragAndDropStart((object) this, args);
        if (!args.Allow)
        {
          this.dragging = false;
          dragData = (object) null;
          dragElement = (FrameworkElement) null;
          dragSource = (FrameworkElement) null;
          this.dropTarget = (FrameworkElement) null;
          this.dragAdorner = (Adorner) null;
          return;
        }
        if (args.DragAdorner != null)
        {
          this.dragAdorner = args.DragAdorner;
          this.adornerLayer.AddAdorner(this.dragAdorner);
        }
      }
      this.dragging = true;
    }

    private void DoContinueDragAndDrop(FrameworkElement potentialDropTarget)
    {
      DragAndDropDelegate dragAndDropContinue = this.DragAndDropContinue;
      if (dragAndDropContinue != null)
      {
        DragAndDropEventArgs args = new DragAndDropEventArgs()
        {
          DragSource = this.dragSource,
          DragElement = this.dragElement,
          DragData = this.dragData,
          DropTarget = potentialDropTarget,
          Allow = true
        };
        dragAndDropContinue((object) this, args);
        if (!args.Allow)
          return;
      }
      this.dropTarget = potentialDropTarget;
    }

    private void DoDragAndDropEnd(FrameworkElement dropTarget)
    {
      DragAndDropDelegate dragAndDropEnd = this.DragAndDropEnd;
      if (dragAndDropEnd != null)
      {
        DragAndDropEventArgs args = new DragAndDropEventArgs()
        {
          Allow = true,
          DragSource = this.dragSource,
          DragElement = this.dragElement,
          DragData = this.dragData,
          DropTarget = dropTarget,
          InitialElementOffset = this.initialElementOffset
        };
        dragAndDropEnd((object) this, args);
      }
      this.dragging = false;
      this.dragData = (object) null;
      this.dragElement = (FrameworkElement) null;
      this.dragSource = (FrameworkElement) null;
      dropTarget = (FrameworkElement) null;
      this.dragAdorner = (Adorner) null;
    }

    private bool IsInDraggableElement(
      FrameworkElement element,
      out FrameworkElement dragElement,
      out FrameworkElement dragSource)
    {
      dragElement = (FrameworkElement) null;
      dragSource = (FrameworkElement) null;
      FrameworkElement frameworkElement = element;
      while (!Apex.DragAndDrop.DragAndDrop.GetIsDraggable((DependencyObject) frameworkElement))
      {
        if (!(VisualTreeHelper.GetParent((DependencyObject) frameworkElement) is FrameworkElement))
          goto label_4;
      }
      dragElement = frameworkElement;
label_4:
      if (dragElement == null)
        return false;
      FrameworkElement o = dragElement;
      while (!Apex.DragAndDrop.DragAndDrop.GetIsDragSource(o))
      {
        if (!(VisualTreeHelper.GetParent((DependencyObject) o) is FrameworkElement))
          goto label_10;
      }
      dragSource = o;
label_10:
      return dragSource != null;
    }

    private bool IsInDropTarget(FrameworkElement element, out FrameworkElement dropTarget)
    {
      dropTarget = (FrameworkElement) null;
      FrameworkElement o = element;
      while (!Apex.DragAndDrop.DragAndDrop.GetIsDropTarget(o))
      {
        if (!(VisualTreeHelper.GetParent((DependencyObject) o) is FrameworkElement))
          goto label_4;
      }
      dropTarget = o;
label_4:
      return dropTarget != null;
    }

    public double MinimumHorizontalDragDistance
    {
      get => (double) this.GetValue(DragAndDropHost.MinimumHorizontalDragDistanceProperty);
      set => this.SetValue(DragAndDropHost.MinimumHorizontalDragDistanceProperty, (object) value);
    }

    public double MinimumVerticalDragDistance
    {
      get => (double) this.GetValue(DragAndDropHost.MinimumVerticalDragDistanceProperty);
      set => this.SetValue(DragAndDropHost.MinimumVerticalDragDistanceProperty, (object) value);
    }

    public event DragAndDropDelegate DragAndDropStart;

    public event DragAndDropDelegate DragAndDropContinue;

    public event DragAndDropDelegate DragAndDropEnd;
  }
}

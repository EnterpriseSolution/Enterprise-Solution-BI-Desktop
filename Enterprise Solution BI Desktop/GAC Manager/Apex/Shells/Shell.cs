// Decompiled with JetBrains decompiler
// Type: Apex.Shells.Shell
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using Apex.DragAndDrop;
using Apex.Extensions;
using Apex.Helpers.Popups;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Apex.Shells
{
  [TemplatePart(Name = "PART_PopupHost", Type = typeof (Grid))]
  [TemplatePart(Name = "PART_ApplicationHost", Type = typeof (Grid))]
  [TemplatePart(Name = "PART_DragAndDropHost", Type = typeof (DragAndDropHost))]
  public class Shell : ContentControl, IShell
  {
    private Grid applicationHost;
    private DragAndDropHost dragAndDropHost;
    private Grid popupHost;
    private readonly Stack<Shell.PopupState> popupStack = new Stack<Shell.PopupState>();
    private PopupAnimationHelper popupAnimationHelper = (PopupAnimationHelper) new BounceInOutPopupAnimationHelper()
    {
      BounceInDirection = 180.0,
      BounceOutDirection = 180.0
    };
    public static readonly RoutedEvent PopupOpenedEvent = EventManager.RegisterRoutedEvent("PopupOpened", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (Shell));
    public static readonly RoutedEvent PopupClosedEvent = EventManager.RegisterRoutedEvent("PopupClosed", RoutingStrategy.Bubble, typeof (RoutedEventArgs), typeof (Shell));

    static Shell() => FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (Shell), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (Shell)));

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      ApexBroker.RegisterShell((IShell) this);
      this.PopupClosed += new RoutedEventHandler(this.OnPopupClosed);
      try
      {
        this.applicationHost = (Grid) this.GetTemplateChild("PART_ApplicationHost");
        this.dragAndDropHost = (DragAndDropHost) this.GetTemplateChild("PART_DragAndDropHost");
        this.popupHost = (Grid) this.GetTemplateChild("PART_PopupHost");
      }
      catch
      {
        throw new Exception("Unable to access the internal elements of the Application host.");
      }
    }

    public void DoMinimize()
    {
      Window parentWindow = this.GetParentWindow();
      if (parentWindow == null)
        throw new InvalidOperationException("Cannot minimize shell - parent window cannot be found.");
      parentWindow.WindowState = WindowState.Minimized;
    }

    public void DoMaximize()
    {
      Window parentWindow = this.GetParentWindow();
      if (parentWindow == null)
        throw new InvalidOperationException("Cannot maximize shell - parent window cannot be found.");
      parentWindow.WindowState = WindowState.Maximized;
    }

    public void DoRestore()
    {
      Window parentWindow = this.GetParentWindow();
      if (parentWindow == null)
        throw new InvalidOperationException("Cannot restore shell - parent window cannot be found.");
      parentWindow.WindowState = WindowState.Normal;
    }

    public void DoClose() => (this.GetParentWindow() ?? throw new InvalidOperationException("Cannot close shell - parent window cannot be found.")).Close();

    public void DoFullscreen() => throw new NotImplementedException();

    public object ShowPopup(UIElement popup)
    {
      this.RaiseEvent(new RoutedEventArgs(Shell.PopupOpenedEvent));
      Shell.PopupState popupState = new Shell.PopupState()
      {
        PopupElement = popup,
        DispatcherFrame = new DispatcherFrame()
      };
      this.popupStack.Push(popupState);
      this.popupAnimationHelper.ShowPopup(this.popupHost, popup);
      Dispatcher.PushFrame(popupState.DispatcherFrame);
      return popupState.PopupResult;
    }

    private void OnPopupClosed(object sender, RoutedEventArgs e)
    {
      Shell.PopupState popupState = this.popupStack.Peek();
      this.popupStack.Pop();
      popupState.DispatcherFrame.Continue = false;
    }

    public void ClosePopup(UIElement popup, object result)
    {
      if (this.popupStack.Peek().PopupElement != popup)
        throw new InvalidOperationException("Cannot close the specified popup - it is not the top of the popup stack.");
      this.popupStack.Peek().PopupResult = result;
      this.popupAnimationHelper.ClosePopup(this.popupHost, popup);
      this.FirePopupClosed();
    }

    protected virtual void FirePopupOpened() => this.RaiseEvent(new RoutedEventArgs(Shell.PopupOpenedEvent));

    protected virtual void FirePopupClosed() => this.RaiseEvent(new RoutedEventArgs(Shell.PopupClosedEvent));

    public event RoutedEventHandler PopupOpened
    {
      add => this.AddHandler(Shell.PopupOpenedEvent, (Delegate) value);
      remove => this.RemoveHandler(Shell.PopupOpenedEvent, (Delegate) value);
    }

    public event RoutedEventHandler PopupClosed
    {
      add => this.AddHandler(Shell.PopupClosedEvent, (Delegate) value);
      remove => this.RemoveHandler(Shell.PopupClosedEvent, (Delegate) value);
    }

    public PopupAnimationHelper PopupAnimationHelper
    {
      get => this.popupAnimationHelper;
      set
      {
        if (value == null)
          throw new ArgumentException("Popup animation helper cannot be null.");
        this.popupAnimationHelper = this.popupAnimationHelper.OpenPopupsCount <= 0 ? value : throw new InvalidOperationException("Cannot change the popup animation helper - there are popups open.");
      }
    }

    internal class PopupState
    {
      public UIElement PopupElement { get; set; }

      public DispatcherFrame DispatcherFrame { get; set; }

      public object PopupResult { get; set; }
    }
  }
}

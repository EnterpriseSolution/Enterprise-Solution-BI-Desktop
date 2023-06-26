// Decompiled with JetBrains decompiler
// Type: Apex.Commands.ExtendedCommands
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System.Windows;
using System.Windows.Input;

namespace Apex.Commands
{
  public static class ExtendedCommands
  {
    public static readonly DependencyProperty ContextMenuDataContextProperty = DependencyProperty.RegisterAttached("ContextMenuDataContext", typeof (object), typeof (ExtendedCommands), new PropertyMetadata(new PropertyChangedCallback(ExtendedCommands.OnContextMenuDataContextChanged)));
    public static readonly DependencyProperty LeftClickCommandProperty = DependencyProperty.RegisterAttached("LeftClickCommand", typeof (ICommand), typeof (ExtendedCommands), new PropertyMetadata((object) null, new PropertyChangedCallback(ExtendedCommands.OnLeftClickCommandChanged)));
    public static readonly DependencyProperty LeftClickCommandParameterProperty = DependencyProperty.RegisterAttached("LeftClickCommandParameter", typeof (object), typeof (ExtendedCommands), new PropertyMetadata((object) null));
    public static readonly DependencyProperty LeftDoubleClickCommandProperty = DependencyProperty.RegisterAttached("LeftDoubleClickCommand", typeof (ICommand), typeof (ExtendedCommands), new PropertyMetadata((object) null));
    public static readonly DependencyProperty LeftDoubleClickCommandParameterProperty = DependencyProperty.RegisterAttached("LeftDoubleClickCommandParameter", typeof (object), typeof (ExtendedCommands), new PropertyMetadata((object) null));
    public static readonly DependencyProperty RightClickCommandProperty = DependencyProperty.RegisterAttached("RightClickCommand", typeof (ICommand), typeof (ExtendedCommands), new PropertyMetadata((object) null, new PropertyChangedCallback(ExtendedCommands.OnRightClickCommandChanged)));
    public static readonly DependencyProperty RightClickCommandParameterProperty = DependencyProperty.RegisterAttached("RightClickCommandParameter", typeof (object), typeof (ExtendedCommands), new PropertyMetadata((object) null));
    public static readonly DependencyProperty RightDoubleClickCommandProperty = DependencyProperty.RegisterAttached("RightDoubleClickCommand", typeof (ICommand), typeof (ExtendedCommands), new PropertyMetadata((object) null, new PropertyChangedCallback(ExtendedCommands.OnRightDoubleClickCommandChanged)));
    public static readonly DependencyProperty RightDoubleClickCommandParameterProperty = DependencyProperty.RegisterAttached("RightDoubleClickCommandParameter", typeof (object), typeof (ExtendedCommands), new PropertyMetadata((object) null));

    public static object GetContextMenuDataContext(FrameworkElement obj) => obj.GetValue(ExtendedCommands.ContextMenuDataContextProperty);

    public static void SetContextMenuDataContext(FrameworkElement obj, object value) => obj.SetValue(ExtendedCommands.ContextMenuDataContextProperty, value);

    private static void OnContextMenuDataContextChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      if (!(d is FrameworkElement frameworkElement) || frameworkElement.ContextMenu == null)
        return;
      frameworkElement.ContextMenu.DataContext = ExtendedCommands.GetContextMenuDataContext(frameworkElement);
    }

    private static void Control_LeftClickMouseDown(object sender, MouseButtonEventArgs e)
    {
      FrameworkElement element = sender as FrameworkElement;
      if (e.ClickCount != 1 || e.LeftButton != MouseButtonState.Pressed || element == null)
        return;
      ICommand leftClickCommand = ExtendedCommands.GetLeftClickCommand(element);
      object commandParameter = ExtendedCommands.GetLeftClickCommandParameter(element);
      if (leftClickCommand == null || !leftClickCommand.CanExecute(commandParameter))
        return;
      leftClickCommand.Execute(commandParameter);
      e.Handled = true;
    }

    private static void Control_RightClickMouseDown(object sender, MouseButtonEventArgs e)
    {
      FrameworkElement element = sender as FrameworkElement;
      if (e.ClickCount != 1 || e.RightButton != MouseButtonState.Pressed || element == null)
        return;
      ICommand rightClickCommand = ExtendedCommands.GetRightClickCommand(element);
      object commandParameter = ExtendedCommands.GetRightClickCommandParameter(element);
      if (rightClickCommand == null || !rightClickCommand.CanExecute(commandParameter))
        return;
      rightClickCommand.Execute(commandParameter);
      e.Handled = true;
    }

    private static void Control_LeftDoubleClickMouseDown(object sender, MouseButtonEventArgs e)
    {
      FrameworkElement element = sender as FrameworkElement;
      if (e.ClickCount != 2 || e.LeftButton != MouseButtonState.Pressed || element == null)
        return;
      ICommand doubleClickCommand = ExtendedCommands.GetLeftDoubleClickCommand(element);
      object commandParameter = ExtendedCommands.GetLeftDoubleClickCommandParameter(element);
      if (doubleClickCommand == null || !doubleClickCommand.CanExecute(commandParameter))
        return;
      doubleClickCommand.Execute(commandParameter);
      e.Handled = true;
    }

    private static void Control_RightDoubleClickMouseDown(object sender, MouseButtonEventArgs e)
    {
      FrameworkElement element = sender as FrameworkElement;
      if (e.ClickCount != 2 || e.RightButton != MouseButtonState.Pressed || element == null)
        return;
      ICommand doubleClickCommand = ExtendedCommands.GetRightDoubleClickCommand(element);
      object commandParameter = ExtendedCommands.GetRightDoubleClickCommandParameter(element);
      if (doubleClickCommand == null || !doubleClickCommand.CanExecute(commandParameter))
        return;
      doubleClickCommand.Execute(commandParameter);
      e.Handled = true;
    }

    public static ICommand GetLeftClickCommand(FrameworkElement element) => (ICommand) element.GetValue(ExtendedCommands.LeftClickCommandProperty);

    public static void SetLeftClickCommand(FrameworkElement element, ICommand value) => element.SetValue(ExtendedCommands.LeftClickCommandProperty, (object) value);

    private static void OnLeftClickCommandChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      if (!(d is UIElement uiElement))
        return;
      if (e.OldValue == null && e.NewValue != null)
      {
        uiElement.MouseDown += new MouseButtonEventHandler(ExtendedCommands.Control_LeftClickMouseDown);
      }
      else
      {
        if (e.OldValue == null || e.NewValue != null)
          return;
        uiElement.MouseDown -= new MouseButtonEventHandler(ExtendedCommands.Control_LeftClickMouseDown);
      }
    }

    public static object GetLeftClickCommandParameter(FrameworkElement element) => element.GetValue(ExtendedCommands.LeftClickCommandParameterProperty);

    public static void SetLeftClickCommandParameter(FrameworkElement element, object value) => element.SetValue(ExtendedCommands.LeftClickCommandParameterProperty, value);

    public static ICommand GetLeftDoubleClickCommand(FrameworkElement element) => (ICommand) element.GetValue(ExtendedCommands.LeftDoubleClickCommandProperty);

    public static void SetLeftDoubleClickCommand(FrameworkElement element, ICommand value) => element.SetValue(ExtendedCommands.LeftDoubleClickCommandProperty, (object) value);

    private static void OnLeftDoubleClickCommandChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      if (!(d is UIElement uiElement))
        return;
      if (e.OldValue == null && e.NewValue != null)
      {
        uiElement.MouseDown += new MouseButtonEventHandler(ExtendedCommands.Control_LeftDoubleClickMouseDown);
      }
      else
      {
        if (e.OldValue == null || e.NewValue != null)
          return;
        uiElement.MouseDown -= new MouseButtonEventHandler(ExtendedCommands.Control_LeftDoubleClickMouseDown);
      }
    }

    public static object GetLeftDoubleClickCommandParameter(FrameworkElement element) => element.GetValue(ExtendedCommands.LeftDoubleClickCommandParameterProperty);

    public static void SetLeftDoubleClickCommandParameter(FrameworkElement element, object value) => element.SetValue(ExtendedCommands.LeftDoubleClickCommandParameterProperty, value);

    private static void OnLeftDoubleClickCommandParameterChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
    }

    public static ICommand GetRightClickCommand(FrameworkElement element) => (ICommand) element.GetValue(ExtendedCommands.RightClickCommandProperty);

    public static void SetRightClickCommand(FrameworkElement element, ICommand value) => element.SetValue(ExtendedCommands.RightClickCommandProperty, (object) value);

    private static void OnRightClickCommandChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      if (!(d is UIElement uiElement))
        return;
      if (e.OldValue == null && e.NewValue != null)
      {
        uiElement.MouseDown += new MouseButtonEventHandler(ExtendedCommands.Control_RightClickMouseDown);
      }
      else
      {
        if (e.OldValue == null || e.NewValue != null)
          return;
        uiElement.MouseDown -= new MouseButtonEventHandler(ExtendedCommands.Control_RightClickMouseDown);
      }
    }

    public static object GetRightClickCommandParameter(FrameworkElement element) => element.GetValue(ExtendedCommands.RightClickCommandParameterProperty);

    public static void SetRightClickCommandParameter(FrameworkElement element, object value) => element.SetValue(ExtendedCommands.RightClickCommandParameterProperty, value);

    public static ICommand GetRightDoubleClickCommand(FrameworkElement element) => (ICommand) element.GetValue(ExtendedCommands.RightDoubleClickCommandProperty);

    public static void SetRightDoubleClickCommand(FrameworkElement element, ICommand value) => element.SetValue(ExtendedCommands.RightDoubleClickCommandProperty, (object) value);

    private static void OnRightDoubleClickCommandChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      if (!(d is UIElement uiElement))
        return;
      if (e.OldValue == null && e.NewValue != null)
      {
        uiElement.MouseDown += new MouseButtonEventHandler(ExtendedCommands.Control_RightDoubleClickMouseDown);
      }
      else
      {
        if (e.OldValue == null || e.NewValue != null)
          return;
        uiElement.MouseDown -= new MouseButtonEventHandler(ExtendedCommands.Control_RightDoubleClickMouseDown);
      }
    }

    public static object GetRightDoubleClickCommandParameter(FrameworkElement element) => element.GetValue(ExtendedCommands.RightDoubleClickCommandParameterProperty);

    public static void SetRightDoubleClickCommandParameter(FrameworkElement element, object value) => element.SetValue(ExtendedCommands.RightDoubleClickCommandParameterProperty, value);
  }
}

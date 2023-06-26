// Decompiled with JetBrains decompiler
// Type: Apex.Commands.EventBinding
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace Apex.Commands
{
  public class EventBinding : Freezable
  {
    private static readonly DependencyProperty EventNameProperty = DependencyProperty.Register(nameof (EventName), typeof (string), typeof (EventBinding), new PropertyMetadata((PropertyChangedCallback) null));
    public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(nameof (Command), typeof (ICommand), typeof (EventBinding), new PropertyMetadata((PropertyChangedCallback) null));
    public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register(nameof (CommandParameter), typeof (object), typeof (EventBinding), new PropertyMetadata((PropertyChangedCallback) null));

    protected override Freezable CreateInstanceCore() => (Freezable) new EventBinding();

    public string EventName
    {
      get => (string) this.GetValue(EventBinding.EventNameProperty);
      set => this.SetValue(EventBinding.EventNameProperty, (object) value);
    }

    public ICommand Command
    {
      get => (ICommand) this.GetValue(EventBinding.CommandProperty);
      set => this.SetValue(EventBinding.CommandProperty, (object) value);
    }

    public object CommandParameter
    {
      get => this.GetValue(EventBinding.CommandParameterProperty);
      set => this.SetValue(EventBinding.CommandParameterProperty, value);
    }

    public void Bind(object o)
    {
      try
      {
        EventInfo eventInfo = o.GetType().GetEvent(this.EventName);
        MethodInfo method = this.GetType().GetMethod("EventProxy", BindingFlags.Instance | BindingFlags.NonPublic);
        Delegate handler = Delegate.CreateDelegate(eventInfo.EventHandlerType, (object) this, method);
        eventInfo.RemoveEventHandler(o, handler);
        eventInfo.AddEventHandler(o, handler);
      }
      catch (Exception ex)
      {
        ex.ToString();
      }
    }

    private void EventProxy(object o, EventArgs e)
    {
      if (this.Command == null)
        return;
      this.Command.Execute(this.CommandParameter);
    }
  }
}

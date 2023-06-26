// Decompiled with JetBrains decompiler
// Type: Apex.MVVM.Command
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.Windows.Input;

namespace Apex.MVVM
{
  public class Command : ICommand
  {
    protected Action action;
    protected Action<object> parameterizedAction;
    private bool canExecute;

    public Command(Action action, bool canExecute = true)
    {
      this.action = action;
      this.canExecute = canExecute;
    }

    public Command(Action<object> parameterizedAction, bool canExecute = true)
    {
      this.parameterizedAction = parameterizedAction;
      this.canExecute = canExecute;
    }

    public virtual void DoExecute() => this.DoExecute((object) null);

    public virtual void DoExecute(object param)
    {
      CancelCommandEventArgs commandEventArgs = new CancelCommandEventArgs();
      commandEventArgs.Parameter = param;
      commandEventArgs.Cancel = false;
      CancelCommandEventArgs args = commandEventArgs;
      this.InvokeExecuting(args);
      if (args.Cancel)
        return;
      param = args.Parameter;
      this.InvokeAction(param);
      this.InvokeExecuted(new CommandEventArgs()
      {
        Parameter = param
      });
    }

    protected void InvokeAction(object param)
    {
      Action action = this.action;
      Action<object> parameterizedAction = this.parameterizedAction;
      if (action != null)
      {
        action();
      }
      else
      {
        if (parameterizedAction == null)
          return;
        parameterizedAction(param);
      }
    }

    protected void InvokeExecuted(CommandEventArgs args)
    {
      CommandEventHandler executed = this.Executed;
      if (executed == null)
        return;
      executed((object) this, args);
    }

    protected void InvokeExecuting(CancelCommandEventArgs args)
    {
      CancelCommandEventHandler executing = this.Executing;
      if (executing == null)
        return;
      executing((object) this, args);
    }

    public bool CanExecute
    {
      get => this.canExecute;
      set
      {
        if (this.canExecute == value)
          return;
        this.canExecute = value;
        EventHandler canExecuteChanged = this.CanExecuteChanged;
        if (canExecuteChanged == null)
          return;
        canExecuteChanged((object) this, EventArgs.Empty);
      }
    }

    bool ICommand.CanExecute(object parameter) => this.canExecute;

    void ICommand.Execute(object parameter) => this.DoExecute(parameter);

    public event EventHandler CanExecuteChanged;

    public event CancelCommandEventHandler Executing;

    public event CommandEventHandler Executed;
  }
}

// Decompiled with JetBrains decompiler
// Type: Apex.MVVM.AsynchronousCommand
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using Apex.Consistency;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Threading;

namespace Apex.MVVM
{
  public class AsynchronousCommand : Command, INotifyPropertyChanged
  {
    protected Dispatcher callingDispatcher;
    private bool isExecuting;
    private bool isCancellationRequested;
    private Command cancelCommand;

    public AsynchronousCommand(Action action, bool canExecute = true)
      : base(action, canExecute)
      => this.Initialise();

    public AsynchronousCommand(Action<object> parameterizedAction, bool canExecute = true)
      : base(parameterizedAction, canExecute)
      => this.Initialise();

    private void Initialise() => this.cancelCommand = new Command((Action) (() => this.IsCancellationRequested = true));

    public override void DoExecute(object param)
    {
      if (this.IsExecuting)
        return;
      CancelCommandEventArgs commandEventArgs = new CancelCommandEventArgs();
      commandEventArgs.Parameter = param;
      commandEventArgs.Cancel = false;
      CancelCommandEventArgs args = commandEventArgs;
      this.InvokeExecuting(args);
      if (args.Cancel)
        return;
      this.IsExecuting = true;
      this.callingDispatcher = DispatcherHelper.CurrentDispatcher;
      ThreadPool.QueueUserWorkItem((WaitCallback) (state =>
      {
        this.InvokeAction(param);
        this.ReportProgress((Action) (() =>
        {
          this.IsExecuting = false;
          if (this.IsCancellationRequested)
            this.InvokeCancelled(new CommandEventArgs()
            {
              Parameter = param
            });
          else
            this.InvokeExecuted(new CommandEventArgs()
            {
              Parameter = param
            });
          this.IsCancellationRequested = false;
        }));
      }));
    }

    private void NotifyPropertyChanged(string propertyName)
    {
      PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
      if (propertyChanged == null)
        return;
      propertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
    }

    public void ReportProgress(Action action)
    {
      if (!this.IsExecuting)
        return;
      if (this.callingDispatcher.CheckAccess())
        action();
      else
        this.callingDispatcher.BeginInvoke(action);
    }

    public bool CancelIfRequested() => this.IsCancellationRequested;

    protected void InvokeCancelled(CommandEventArgs args)
    {
      CommandEventHandler cancelled = this.Cancelled;
      if (cancelled == null)
        return;
      cancelled((object) this, args);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public event CommandEventHandler Cancelled;

    public bool IsExecuting
    {
      get => this.isExecuting;
      set
      {
        if (this.isExecuting == value)
          return;
        this.isExecuting = value;
        this.NotifyPropertyChanged(nameof (IsExecuting));
      }
    }

    public bool IsCancellationRequested
    {
      get => this.isCancellationRequested;
      set
      {
        if (this.isCancellationRequested == value)
          return;
        this.isCancellationRequested = value;
        this.NotifyPropertyChanged(nameof (IsCancellationRequested));
      }
    }

    public Command CancelCommand => this.cancelCommand;
  }
}

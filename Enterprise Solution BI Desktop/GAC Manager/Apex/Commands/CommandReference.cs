// Decompiled with JetBrains decompiler
// Type: Apex.Commands.CommandReference
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.Windows;
using System.Windows.Input;

namespace Apex.Commands
{
  public class CommandReference : Freezable, ICommand
  {
    public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(nameof (Command), typeof (ICommand), typeof (CommandReference), new PropertyMetadata(new PropertyChangedCallback(CommandReference.OnCommandChanged)));

    public ICommand Command
    {
      get => (ICommand) this.GetValue(CommandReference.CommandProperty);
      set => this.SetValue(CommandReference.CommandProperty, (object) value);
    }

    public bool CanExecute(object parameter) => this.Command != null && this.Command.CanExecute(parameter);

    public void Execute(object parameter) => this.Command.Execute(parameter);

    public event EventHandler CanExecuteChanged;

    private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      CommandReference commandReference = d as CommandReference;
      ICommand oldValue = e.OldValue as ICommand;
      ICommand newValue = e.NewValue as ICommand;
      if (oldValue != null)
        oldValue.CanExecuteChanged -= commandReference.CanExecuteChanged;
      if (newValue == null)
        return;
      newValue.CanExecuteChanged += commandReference.CanExecuteChanged;
    }

    protected override Freezable CreateInstanceCore() => throw new NotImplementedException();
  }
}

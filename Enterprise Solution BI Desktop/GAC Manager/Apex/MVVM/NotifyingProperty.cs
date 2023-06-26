// Decompiled with JetBrains decompiler
// Type: Apex.MVVM.NotifyingProperty
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;

namespace Apex.MVVM
{
  public class NotifyingProperty
  {
    private object initialState;

    public NotifyingProperty(string name, Type type, object value)
    {
      this.Name = name;
      this.Type = type;
      this.Value = value;
    }

    public void SetValue(object newValue)
    {
      object oldValue = this.Value;
      if (oldValue == newValue)
        return;
      this.Value = newValue;
      this.FireNotifyingPropertyChanged(oldValue, newValue);
    }

    public void SaveInitialState() => this.initialState = this.Value;

    public void RestoreInitialState() => this.Value = this.initialState;

    protected virtual void FireNotifyingPropertyChanged(object oldValue, object newValue)
    {
      NotifyingPropertyChangedEvent notifyingPropertyChanged = this.NotifyingPropertyChanged;
      if (notifyingPropertyChanged == null)
        return;
      notifyingPropertyChanged((object) this, new NotifyingPropertyChangedArgs(oldValue, newValue));
    }

    public event NotifyingPropertyChangedEvent NotifyingPropertyChanged;

    public string Name { get; set; }

    public Type Type { get; set; }

    public object Value { get; set; }
  }
}

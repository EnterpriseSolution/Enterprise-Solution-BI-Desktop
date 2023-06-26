// Decompiled with JetBrains decompiler
// Type: Apex.MVVM.ViewModel
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace Apex.MVVM
{
  public class ViewModel : INotifyPropertyChanged
  {
    private bool hasChanges;

    public virtual void NotifyPropertyChanged(string propertyName)
    {
      PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
      if (propertyChanged == null)
        return;
      propertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
    }

    public IEnumerable<NotifyingProperty> GetNotifyingProperties(
      bool declaredOnly = false)
    {
      Type type = this.GetType();
      BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
      if (declaredOnly)
        bindingAttr |= BindingFlags.DeclaredOnly;
      return ((IEnumerable<FieldInfo>) type.GetFields(bindingAttr)).Where<FieldInfo>((Func<FieldInfo, bool>) (field => field.FieldType == typeof (NotifyingProperty))).Select<FieldInfo, NotifyingProperty>((Func<FieldInfo, NotifyingProperty>) (field => field.GetValue((object) this) as NotifyingProperty));
    }

    public void SaveInitialState()
    {
      foreach (NotifyingProperty notifyingProperty in this.GetNotifyingProperties())
        notifyingProperty.SaveInitialState();
      this.HasChanges = false;
    }

    public void RestoreInitialState()
    {
      foreach (NotifyingProperty notifyingProperty in this.GetNotifyingProperties())
        notifyingProperty.RestoreInitialState();
      this.HasChanges = false;
    }

    public void ResetHasChangesFlag() => this.HasChanges = false;

    protected object GetValue(NotifyingProperty notifyingProperty) => notifyingProperty.Value;

    protected void SetValue(NotifyingProperty notifyingProperty, object value) => this.SetValue(notifyingProperty, value, false);

    protected void SetValue(NotifyingProperty notifyingProperty, object value, bool forceUpdate)
    {
      if (notifyingProperty.Value == value && !forceUpdate)
        return;
      notifyingProperty.SetValue(value);
      this.NotifyPropertyChanged(notifyingProperty.Name);
      this.HasChanges = true;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    [XmlIgnore]
    public bool HasChanges
    {
      get => this.hasChanges;
      protected set
      {
        if (this.hasChanges == value)
          return;
        this.hasChanges = value;
        this.NotifyPropertyChanged(nameof (HasChanges));
      }
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Apex.MVVM.ViewAttribute
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;

namespace Apex.MVVM
{
  [AttributeUsage(AttributeTargets.Class)]
  public class ViewAttribute : Attribute
  {
    public ViewAttribute() => this.ViewModelType = typeof (object);

    public ViewAttribute(Type viewModelType) => this.ViewModelType = viewModelType;

    public ViewAttribute(Type viewModelType, string hint)
    {
      this.ViewModelType = viewModelType;
      this.Hint = hint;
    }

    public Type ViewModelType { get; private set; }

    public string Hint { get; private set; }
  }
}

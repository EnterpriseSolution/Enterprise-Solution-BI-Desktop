// Decompiled with JetBrains decompiler
// Type: Apex.MVVM.ViewModel`1
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

namespace Apex.MVVM
{
  public abstract class ViewModel<TModel> : ViewModel
  {
    public abstract void FromModel(TModel model);

    public abstract void ToModel(TModel model);
  }
}

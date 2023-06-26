// Decompiled with JetBrains decompiler
// Type: Apex.Controls.NameValue
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

namespace Apex.Controls
{
  internal class NameValue
  {
    public NameValue()
    {
    }

    public NameValue(string name, object value)
    {
      this.Name = name;
      this.Value = value;
    }

    public string Name { get; set; }

    public object Value { get; set; }
  }
}

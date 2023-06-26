// Decompiled with JetBrains decompiler
// Type: Apex.Extensions.EnumExtensions
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Apex.Extensions
{
  public static class EnumExtensions
  {
    public static string GetDescription(this Enum me) => !(((IEnumerable<object>) me.GetType().GetField(me.ToString()).GetCustomAttributes(typeof (DescriptionAttribute), false)).FirstOrDefault<object>() is DescriptionAttribute descriptionAttribute) ? me.ToString() : descriptionAttribute.Description;
  }
}

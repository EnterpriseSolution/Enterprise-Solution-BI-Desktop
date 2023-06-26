// Decompiled with JetBrains decompiler
// Type: Apex.Helpers.EnumHelper
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Apex.Helpers
{
  public class EnumHelper
  {
    public static object[] GetValues(Type enumType)
    {
      if (!enumType.IsEnum)
        throw new ArgumentException("Type '" + enumType.Name + "' is not an enum");
      return ((IEnumerable<FieldInfo>) enumType.GetFields()).Where<FieldInfo>((Func<FieldInfo, bool>) (field => field.IsLiteral)).Select<FieldInfo, object>((Func<FieldInfo, object>) (field => field.GetValue((object) enumType))).ToArray<object>();
    }
  }
}

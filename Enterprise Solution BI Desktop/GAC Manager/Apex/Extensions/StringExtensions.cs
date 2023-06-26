// Decompiled with JetBrains decompiler
// Type: Apex.Extensions.StringExtensions
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;

namespace Apex.Extensions
{
  public static class StringExtensions
  {
    public static bool ContainsCaseInsensitive(this string source, string value) => source.IndexOf(value, StringComparison.CurrentCultureIgnoreCase) != -1;
  }
}

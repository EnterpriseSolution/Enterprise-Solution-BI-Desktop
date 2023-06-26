// Decompiled with JetBrains decompiler
// Type: Apex.Converters.StringCaseConverter
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.Globalization;
using System.Windows.Data;

namespace Apex.Converters
{
  public class StringCaseConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (!(value is string) || parameter == null)
        return (object) null;
      string str = value as string;
      if (parameter.ToString() == "Upper")
        return (object) str.ToUpper();
      return parameter.ToString() == "Lower" ? (object) str.ToLower() : (object) str;
    }

    public object ConvertBack(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Apex.Converters.StringNullOrEmptyToVisibilityConverter
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Apex.Converters
{
  public class StringNullOrEmptyToVisibilityConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (!(value is string))
        return (object) Visibility.Collapsed;
      string str = (string) value;
      bool flag1 = parameter is string && ((string) parameter).IndexOf("Invert", StringComparison.OrdinalIgnoreCase) != -1;
      bool flag2 = string.IsNullOrEmpty(str);
      if (flag1)
        flag2 = !flag2;
      return (object) (Visibility) (flag2 ? 2 : 0);
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

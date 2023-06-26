// Decompiled with JetBrains decompiler
// Type: Apex.Converters.DivideByTwoConverter
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.Globalization;
using System.Windows.Data;

namespace Apex.Converters
{
  public class DivideByTwoConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value == null || !(value is double))
        return (object) 0.0;
      return parameter != null && parameter is string && (string) parameter == "Negative" ? (object) (-(double) value / 2.0) : (object) ((double) value / 2.0);
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

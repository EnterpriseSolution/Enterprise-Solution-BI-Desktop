// Decompiled with JetBrains decompiler
// Type: Apex.Converters.NullToVisibilityConverter
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Apex.Converters
{
  public class NullToVisibilityConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (parameter == null)
        return (object) (Visibility) (value == null ? 2 : 0);
      return parameter.ToString() == "Invert" ? (object) (Visibility) (value == null ? 0 : 2) : (object) Visibility.Collapsed;
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

﻿// Decompiled with JetBrains decompiler
// Type: Apex.Converters.BooleanToVisibilityConverter
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Apex.Converters
{
  public class BooleanToVisibilityConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (!(value is bool flag))
        return (object) null;
      return parameter != null && parameter.ToString() == "Invert" ? (object) (Visibility) (flag ? 2 : 0) : (object) (Visibility) (flag ? 0 : 2);
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
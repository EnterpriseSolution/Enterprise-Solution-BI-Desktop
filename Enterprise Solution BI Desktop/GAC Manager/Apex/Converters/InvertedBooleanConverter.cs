﻿// Decompiled with JetBrains decompiler
// Type: Apex.Converters.InvertedBooleanConverter
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.Globalization;
using System.Windows.Data;

namespace Apex.Converters
{
  public class InvertedBooleanConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (!(value is bool flag))
        throw new Exception("An InvertedBooleanConverter must be passed a boolean value.");
      return (object) !flag;
    }

    public object ConvertBack(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      if (!(value is bool flag))
        throw new Exception("An InvertedBooleanConverter must be passed a boolean value.");
      return (object) !flag;
    }
  }
}

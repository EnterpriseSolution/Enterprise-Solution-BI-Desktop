// Decompiled with JetBrains decompiler
// Type: Apex.Converters.DateTimeToSensibleStringConverter
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.Globalization;
using System.Windows.Data;

namespace Apex.Converters
{
  public class DateTimeToSensibleStringConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value == null || !(value is DateTime dateTime))
        return (object) null;
      string str = dateTime.ToShortDateString() + " ";
      if (dateTime.Date == DateTime.Now.AddDays(1.0).Date)
        str = "Tomorrow at ";
      else if (dateTime.Date == DateTime.Now.Date)
        str = "Today at ";
      else if (dateTime.Date == DateTime.Now.Subtract(TimeSpan.FromDays(1.0)).Date)
        str = "Yesterday at ";
      return (object) (str + dateTime.ToShortTimeString());
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

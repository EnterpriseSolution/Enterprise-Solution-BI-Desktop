// Decompiled with JetBrains decompiler
// Type: Apex.Extensions.DateTimeExtensions
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.Globalization;

namespace Apex.Extensions
{
  public static class DateTimeExtensions
  {
    public static DateTime BeginningOfWeek(this DateTime me)
    {
      int num = me.DayOfWeek - CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
      if (num < 0)
        num += 7;
      return me.AddDays((double) (-1 * num)).Date.BeginningOfDay();
    }

    public static DateTime BeginningOfMonth(this DateTime me) => new DateTime(me.Year, me.Month, 1, 0, 0, 0);

    public static DateTime BeginningOfDay(this DateTime me) => new DateTime(me.Year, me.Month, me.Day, 0, 0, 0);

    public static DateTime EndOfDay(this DateTime me) => new DateTime(me.Year, me.Month, me.Day, 23, 59, 59);

    public static int WorkDaysBetween(DateTime startD, DateTime endD)
    {
      double num = 1.0 + ((endD - startD).TotalDays * 5.0 - (double) ((startD.DayOfWeek - endD.DayOfWeek) * 2)) / 7.0;
      if (endD.DayOfWeek == DayOfWeek.Saturday)
        --num;
      if (startD.DayOfWeek == DayOfWeek.Sunday)
        --num;
      return (int) num;
    }
  }
}

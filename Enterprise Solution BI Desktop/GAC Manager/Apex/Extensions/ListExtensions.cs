// Decompiled with JetBrains decompiler
// Type: Apex.Extensions.ListExtensions
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace Apex.Extensions
{
  public static class ListExtensions
  {
    private static Random rng = new Random();

    public static void Shuffle<T>(this IList<T> list)
    {
      int count = list.Count;
      while (count > 1)
      {
        --count;
        int index = ListExtensions.rng.Next(count + 1);
        T obj = list[index];
        list[index] = list[count];
        list[count] = obj;
      }
    }

    public static T RandomElement<T>(this IList<T> list) => list.ElementAt<T>(ListExtensions.rng.Next(0, list.Count));
  }
}

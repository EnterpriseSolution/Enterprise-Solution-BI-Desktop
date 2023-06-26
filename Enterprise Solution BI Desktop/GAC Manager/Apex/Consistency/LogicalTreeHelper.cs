// Decompiled with JetBrains decompiler
// Type: Apex.Consistency.LogicalTreeHelper
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;

namespace Apex.Consistency
{
  public static class LogicalTreeHelper
  {
    public static IEnumerable GetChildren(DependencyObject current)
    {
      List<DependencyObject> dependencyObjectList = new List<DependencyObject>();
      object content = LogicalTreeHelper.TryGetContent(current);
      IEnumerable children = LogicalTreeHelper.TryGetChildren(current);
      if (content != null && content is DependencyObject)
        dependencyObjectList.Add((DependencyObject) content);
      if (children != null)
      {
        foreach (object obj in children)
        {
          if (obj is DependencyObject)
            dependencyObjectList.Add((DependencyObject) obj);
        }
      }
      return (IEnumerable) dependencyObjectList;
    }

    public static object TryGetContent(DependencyObject dependencyObject)
    {
      PropertyInfo property = dependencyObject.GetType().GetProperty("Content");
      return property != (PropertyInfo) null ? property.GetValue((object) dependencyObject, (object[]) null) : (object) null;
    }

    public static IEnumerable TryGetChildren(DependencyObject dependencyObject)
    {
      PropertyInfo property = dependencyObject.GetType().GetProperty("Children");
      return property != (PropertyInfo) null ? property.GetValue((object) dependencyObject, (object[]) null) as IEnumerable : (IEnumerable) null;
    }
  }
}

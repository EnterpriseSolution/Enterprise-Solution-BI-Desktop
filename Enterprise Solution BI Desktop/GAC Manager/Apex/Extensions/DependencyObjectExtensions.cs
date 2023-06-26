// Decompiled with JetBrains decompiler
// Type: Apex.Extensions.DependencyObjectExtensions
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Apex.Extensions
{
  public static class DependencyObjectExtensions
  {
    public static T GetParent<T>(this DependencyObject child) where T : DependencyObject
    {
      DependencyObject parent = VisualTreeHelper.GetParent(child);
      if (parent == null)
        return default (T);
      return !(parent is T) ? parent.GetParent<T>() : parent as T;
    }

    public static DependencyObject GetTopLevelParent(this DependencyObject child)
    {
      DependencyObject reference = child;
      DependencyObject dependencyObject = (DependencyObject) null;
      while ((reference = VisualTreeHelper.GetParent(reference)) != null)
        dependencyObject = reference;
      return dependencyObject;
    }

    public static IEnumerable<T> GetVisualChildren<T>(this DependencyObject me) where T : DependencyObject
    {
      for (int i = 0; i < VisualTreeHelper.GetChildrenCount(me); ++i)
      {
        DependencyObject child = VisualTreeHelper.GetChild(me, i);
        if (child != null && child is T)
          yield return (T) child;
        foreach (T visualChild in child.GetVisualChildren<T>())
          yield return visualChild;
      }
    }

    public static IEnumerable<T> GetLogicalChildren<T>(this DependencyObject me) where T : DependencyObject
    {
      foreach (object child in LogicalTreeHelper.GetChildren(me))
      {
        if (child is DependencyObject childDependencyObject)
        {
          if (childDependencyObject != null && childDependencyObject is T)
            yield return (T) childDependencyObject;
          foreach (T logicalChild in childDependencyObject.GetLogicalChildren<T>())
            yield return logicalChild;
        }
      }
    }

    public static T FindChild<T>(this DependencyObject me, string childName) where T : DependencyObject
    {
      if (me == null)
        return default (T);
      T obj = default (T);
      int childrenCount = VisualTreeHelper.GetChildrenCount(me);
      for (int childIndex = 0; childIndex < childrenCount; ++childIndex)
      {
        DependencyObject child = VisualTreeHelper.GetChild(me, childIndex);
        if ((object) (child as T) == null)
        {
          obj = child.FindChild<T>(childName);
          if ((object) obj != null)
            break;
        }
        else if (!string.IsNullOrEmpty(childName))
        {
          if (child is FrameworkElement frameworkElement && frameworkElement.Name == childName)
          {
            obj = (T) child;
            break;
          }
        }
        else
        {
          obj = (T) child;
          break;
        }
      }
      return obj;
    }

    public static IEnumerable<Binding> GetBindingObjects(this DependencyObject me) => me.GetDependencyProperties().Select<DependencyProperty, Binding>((Func<DependencyProperty, Binding>) (dp => BindingOperations.GetBinding(me, dp))).Where<Binding>((Func<Binding, bool>) (b => b != null));

    public static IEnumerable<DependencyProperty> GetDependencyProperties(
      this DependencyObject me)
    {
      return TypeDescriptor.GetProperties((object) me, new Attribute[1]
      {
        (Attribute) new PropertyFilterAttribute(PropertyFilterOptions.All)
      }).Cast<PropertyDescriptor>().Select<PropertyDescriptor, DependencyPropertyDescriptor>((Func<PropertyDescriptor, DependencyPropertyDescriptor>) (pd => DependencyPropertyDescriptor.FromProperty(pd))).Where<DependencyPropertyDescriptor>((Func<DependencyPropertyDescriptor, bool>) (dpd => dpd != null)).Select<DependencyPropertyDescriptor, DependencyProperty>((Func<DependencyPropertyDescriptor, DependencyProperty>) (dpd => dpd.DependencyProperty));
    }
  }
}

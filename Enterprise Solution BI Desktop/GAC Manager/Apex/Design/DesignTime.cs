// Decompiled with JetBrains decompiler
// Type: Apex.Design.DesignTime
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System.ComponentModel;
using System.Windows;

namespace Apex.Design
{
  public static class DesignTime
  {
    private static bool? isDesignTime;

    public static bool IsDesignTime
    {
      get
      {
        if (!DesignTime.isDesignTime.HasValue)
          DesignTime.isDesignTime = new bool?((bool) DependencyPropertyDescriptor.FromProperty(DesignerProperties.IsInDesignModeProperty, typeof (FrameworkElement)).Metadata.DefaultValue);
        return DesignTime.isDesignTime.Value;
      }
    }
  }
}

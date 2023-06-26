// Decompiled with JetBrains decompiler
// Type: Apex.Helpers.AssembliesHelper
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Apex.Helpers
{
  public static class AssembliesHelper
  {
    public static IEnumerable<Assembly> GetDomainAssemblies() => (IEnumerable<Assembly>) AppDomain.CurrentDomain.GetAssemblies();

    public static IEnumerable<Type> GetTypesInDomain() => AssembliesHelper.GetDomainAssemblies().Where<Assembly>((Func<Assembly, bool>) (a => !a.GlobalAssemblyCache && !a.IsDynamic)).SelectMany<Assembly, Type, Type>((Func<Assembly, IEnumerable<Type>>) (a => (IEnumerable<Type>) a.GetExportedTypes()), (Func<Assembly, Type, Type>) ((a, t) => t)).ToList<Type>().Distinct<Type>();
  }
}

// Decompiled with JetBrains decompiler
// Type: Apex.ApexBroker
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using Apex.Helpers;
using Apex.MVVM;
using Apex.Shells;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace Apex
{
  public static class ApexBroker
  {
    private static object syncLock = new object();
    private static bool isInitialised;
    private static ExecutionContext? currentExecutionContext;
    private static List<ApexBroker.ViewModelViewMapping> viewModelViewMappings = new List<ApexBroker.ViewModelViewMapping>();
    private static List<object> modelInstances = new List<object>();
    private static Dictionary<Type, object> serviceTypesToInstances = new Dictionary<Type, object>();
    private static IShell shell;

    public static void Initialise()
    {
      lock (ApexBroker.syncLock)
      {
        if (ApexBroker.isInitialised)
          return;
        List<Type> list = AssembliesHelper.GetTypesInDomain().ToList<Type>();
        foreach (var data in list.Where<Type>((Func<Type, bool>) (t => ((IEnumerable<object>) t.GetCustomAttributes(typeof (ModelAttribute), false)).Any<object>())).Select(t => new
        {
          ModelType = t,
          ModelAttribute = (ModelAttribute) ((IEnumerable<object>) t.GetCustomAttributes(typeof (ModelAttribute), false)).Single<object>()
        }))
        {
          object instance = Activator.CreateInstance(data.ModelType);
          if (instance is IModel)
            ((IModel) instance).OnInitialised();
          ApexBroker.modelInstances.Add(instance);
        }
        foreach (var data in list.Where<Type>((Func<Type, bool>) (t => ((IEnumerable<object>) t.GetCustomAttributes(typeof (ViewAttribute), false)).Any<object>())).Select(t => new
        {
          ViewType = t,
          ViewAttribute = (ViewAttribute) ((IEnumerable<object>) t.GetCustomAttributes(typeof (ViewAttribute), false)).Single<object>()
        }))
          ApexBroker.RegisterViewForViewModel(data.ViewAttribute.ViewModelType, data.ViewType);
        ApexBroker.isInitialised = true;
      }
    }

    public static TModel GetModel<TModel>()
    {
      ApexBroker.EnsureInitialised();
      try
      {
        return (TModel) ApexBroker.modelInstances.Single<object>((Func<object, bool>) (m => m is TModel));
      }
      catch
      {
        throw new InvalidOperationException("The Model Type " + typeof (TModel).Name + " has not been registered.");
      }
    }

    public static void RegisterViewForViewModel(Type viewModelType, Type viewType, string hint = null) => ApexBroker.viewModelViewMappings.Add(new ApexBroker.ViewModelViewMapping()
    {
      ViewModelType = viewModelType,
      ViewType = viewType,
      Hint = hint
    });

    public static void RegisterShell(IShell shell) => ApexBroker.shell = ApexBroker.shell == null ? shell : throw new InvalidOperationException("A shell has already been registered. Only shell can be registered.");

    public static void RegisterService<TService>(object serviceInstance)
    {
      lock (ApexBroker.syncLock)
      {
        if (ApexBroker.serviceTypesToInstances.ContainsKey(typeof (TService)))
          throw new InvalidOperationException("A Service of this type has already been registered.");
        ApexBroker.serviceTypesToInstances[typeof (TService)] = serviceInstance;
      }
    }

    public static void RegisterOrOverrideService<TService>(object serviceInstance)
    {
      lock (ApexBroker.syncLock)
        ApexBroker.serviceTypesToInstances[typeof (TService)] = serviceInstance;
    }

    public static TService GetService<TService>()
    {
      TService service = default (TService);
      lock (ApexBroker.syncLock)
      {
        if (ApexBroker.serviceTypesToInstances.ContainsKey(typeof (TService)))
          service = (TService) ApexBroker.serviceTypesToInstances[typeof (TService)];
      }
      return service;
    }

    public static IShell GetShell()
    {
      ApexBroker.EnsureInitialised();
      return ApexBroker.shell != null ? ApexBroker.shell : throw new InvalidOperationException("No shell has been registered.");
    }

    public static Type GetViewForViewModel(Type viewModelType, string hint = null)
    {
      ApexBroker.EnsureInitialised();
      return ApexBroker.viewModelViewMappings.Where<ApexBroker.ViewModelViewMapping>((Func<ApexBroker.ViewModelViewMapping, bool>) (vmm => vmm.ViewModelType.AssemblyQualifiedName == viewModelType.AssemblyQualifiedName && vmm.Hint == hint)).Select<ApexBroker.ViewModelViewMapping, Type>((Func<ApexBroker.ViewModelViewMapping, Type>) (vmm => vmm.ViewType)).FirstOrDefault<Type>();
    }

    private static void EnsureInitialised()
    {
      if (ApexBroker.isInitialised)
        return;
      ApexBroker.Initialise();
    }

    private static ExecutionContext DetermineExecutionContext()
    {
      if ((bool) DependencyPropertyDescriptor.FromProperty(DesignerProperties.IsInDesignModeProperty, typeof (FrameworkElement)).Metadata.DefaultValue)
        return ExecutionContext.Design;
      string unitTestFrameworkMS = "microsoft.visualstudio.qualitytools.unittestframework";
      string unitTestFrameworkNunit = "nunit.framework";
      return AssembliesHelper.GetDomainAssemblies().Any<Assembly>((Func<Assembly, bool>) (a => a.FullName.ToLower().StartsWith(unitTestFrameworkMS) || a.FullName.ToLower().StartsWith(unitTestFrameworkNunit))) ? ExecutionContext.Test : ExecutionContext.Standard;
    }

    public static ExecutionContext CurrentExecutionContext
    {
      get
      {
        if (!ApexBroker.currentExecutionContext.HasValue)
          ApexBroker.currentExecutionContext = new ExecutionContext?(ApexBroker.DetermineExecutionContext());
        return ApexBroker.currentExecutionContext.Value;
      }
    }

    internal class ViewModelViewMapping
    {
      public Type ViewModelType { get; set; }

      public Type ViewType { get; set; }

      public string Hint { get; set; }
    }
  }
}

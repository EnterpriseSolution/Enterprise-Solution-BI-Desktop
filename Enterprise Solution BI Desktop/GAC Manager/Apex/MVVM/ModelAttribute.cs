﻿// Decompiled with JetBrains decompiler
// Type: Apex.MVVM.ModelAttribute
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;

namespace Apex.MVVM
{
  [AttributeUsage(AttributeTargets.Class)]
  public class ModelAttribute : Attribute
  {
    public ModelAttribute() => this.Context = ExecutionContext.Standard;

    public ModelAttribute(ExecutionContext context) => this.Context = context;

    public ExecutionContext Context { get; private set; }
  }
}

﻿// Decompiled with JetBrains decompiler
// Type: Apex.Consistency.DispatcherHelper
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System.Windows.Threading;

namespace Apex.Consistency
{
  public static class DispatcherHelper
  {
    public static Dispatcher CurrentDispatcher => Dispatcher.CurrentDispatcher;
  }
}

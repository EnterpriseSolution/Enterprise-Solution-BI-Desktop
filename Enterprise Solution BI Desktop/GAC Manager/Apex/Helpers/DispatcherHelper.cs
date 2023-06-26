// Decompiled with JetBrains decompiler
// Type: Apex.Helpers.DispatcherHelper
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.Windows.Threading;

namespace Apex.Helpers
{
  public static class DispatcherHelper
  {
    public static void DoEvents()
    {
      DispatcherFrame frame = new DispatcherFrame();
      Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, (Delegate) new DispatcherOperationCallback(DispatcherHelper.ExitFrame), (object) frame);
      Dispatcher.PushFrame(frame);
    }

    private static object ExitFrame(object frame)
    {
      ((DispatcherFrame) frame).Continue = false;
      return (object) null;
    }
  }
}

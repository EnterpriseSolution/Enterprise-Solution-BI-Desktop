// Decompiled with JetBrains decompiler
// Type: Apex.Shells.IShell
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using Apex.Helpers.Popups;
using System.Windows;

namespace Apex.Shells
{
  public interface IShell
  {
    void DoMinimize();

    void DoMaximize();

    void DoRestore();

    void DoClose();

    void DoFullscreen();

    object ShowPopup(UIElement popup);

    void ClosePopup(UIElement popup, object result);

    PopupAnimationHelper PopupAnimationHelper { get; set; }
  }
}

// Decompiled with JetBrains decompiler
// Type: Apex.Helpers.Popups.PopupAnimationHelper
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Apex.Helpers.Popups
{
  public abstract class PopupAnimationHelper
  {
    private readonly List<PopupAnimationHelper.PopupAndBackground> popupsAndBackgrounds = new List<PopupAnimationHelper.PopupAndBackground>();

    public void ShowPopup(Grid popupHost, UIElement popup)
    {
      PopupAnimationHelper.PopupAndBackground popupAndBackground = new PopupAnimationHelper.PopupAndBackground()
      {
        PopupElement = popup,
        Background = new Grid()
      };
      this.popupsAndBackgrounds.Add(popupAndBackground);
      this.AnimatePopupShow(popupHost, popupAndBackground.Background, popup);
    }

    public void ClosePopup(Grid popupHost, UIElement popup)
    {
      PopupAnimationHelper.PopupAndBackground popupAndBackground = this.popupsAndBackgrounds.Where<PopupAnimationHelper.PopupAndBackground>((Func<PopupAnimationHelper.PopupAndBackground, bool>) (pab => pab.PopupElement == popup)).FirstOrDefault<PopupAnimationHelper.PopupAndBackground>();
      if (popupAndBackground == null)
        throw new InvalidOperationException("The popup to be hidden was not shown in this instance. Popups must be shown and then hidden by the same object.");
      this.popupsAndBackgrounds.Remove(popupAndBackground);
      this.AnimatePopupHide(popupHost, popupAndBackground.Background, popup);
    }

    protected abstract void AnimatePopupShow(
      Grid popupHost,
      Grid popupBackground,
      UIElement popupElement);

    protected abstract void AnimatePopupHide(
      Grid popupHost,
      Grid popupBackground,
      UIElement popupElement);

    public int OpenPopupsCount => this.popupsAndBackgrounds.Count;

    internal class PopupAndBackground
    {
      public UIElement PopupElement { get; set; }

      public Grid Background { get; set; }
    }
  }
}

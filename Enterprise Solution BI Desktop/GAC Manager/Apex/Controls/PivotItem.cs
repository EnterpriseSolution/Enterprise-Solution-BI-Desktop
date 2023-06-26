// Decompiled with JetBrains decompiler
// Type: Apex.Controls.PivotItem
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using Apex.MVVM;
using System.Windows;

namespace Apex.Controls
{
  [System.Windows.Markup.ContentProperty("Content")]
  public class PivotItem : DependencyObject
  {
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof (Title), typeof (string), typeof (PivotItem));
    public static readonly DependencyProperty ContentProperty = DependencyProperty.Register(nameof (Content), typeof (object), typeof (PivotItem));
    public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register(nameof (IsSelected), typeof (bool), typeof (PivotItem), new PropertyMetadata((object) false));
    public Command selectedCommand;
    private static readonly DependencyProperty IsInitialPageProperty = DependencyProperty.Register(nameof (IsInitialPage), typeof (bool), typeof (PivotItem), new PropertyMetadata((object) false, new PropertyChangedCallback(PivotItem.OnIsInitialPageChanged)));

    private void Select()
    {
    }

    public string Title
    {
      get => this.GetValue(PivotItem.TitleProperty) as string;
      set => this.SetValue(PivotItem.TitleProperty, (object) value);
    }

    public object Content
    {
      get => this.GetValue(PivotItem.ContentProperty);
      set => this.SetValue(PivotItem.ContentProperty, value);
    }

    public bool IsSelected
    {
      get => (bool) this.GetValue(PivotItem.IsSelectedProperty);
      set => this.SetValue(PivotItem.IsSelectedProperty, (object) value);
    }

    public bool IsInitialPage
    {
      get => (bool) this.GetValue(PivotItem.IsInitialPageProperty);
      set => this.SetValue(PivotItem.IsInitialPageProperty, (object) value);
    }

    private static void OnIsInitialPageChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs args)
    {
    }
  }
}

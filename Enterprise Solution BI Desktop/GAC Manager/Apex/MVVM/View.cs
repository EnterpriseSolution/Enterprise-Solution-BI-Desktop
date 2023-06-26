// Decompiled with JetBrains decompiler
// Type: Apex.MVVM.View
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System.Windows;

namespace Apex.MVVM
{
  public static class View
  {
    private static readonly DependencyProperty ViewModelProperty = DependencyProperty.RegisterAttached("ViewModel", typeof (object), typeof (FrameworkElement), new PropertyMetadata((object) null, new PropertyChangedCallback(View.OnViewModelChanged)));

    public static object GetViewModel(DependencyObject o) => o.GetValue(View.ViewModelProperty);

    public static void SetViewModel(DependencyObject o, object value) => o.SetValue(View.ViewModelProperty, value);

    private static void OnViewModelChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs args)
    {
      FrameworkElement frameworkElement = o as FrameworkElement;
      frameworkElement.DataContext = View.GetViewModel((DependencyObject) frameworkElement);
    }
  }
}

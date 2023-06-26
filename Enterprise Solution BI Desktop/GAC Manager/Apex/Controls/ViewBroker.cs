// Decompiled with JetBrains decompiler
// Type: Apex.Controls.ViewBroker
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using Apex.MVVM;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Apex.Controls
{
  public class ViewBroker : ContentControl
  {
    private static readonly DependencyProperty BrokerHintProperty = DependencyProperty.Register(nameof (BrokerHint), typeof (string), typeof (ViewBroker), new PropertyMetadata((PropertyChangedCallback) null));
    public static readonly DependencyProperty AllowUnknownViewModelsProperty = DependencyProperty.Register(nameof (AllowUnknownViewModels), typeof (bool), typeof (ViewBroker), new PropertyMetadata((object) false));
    private static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof (ViewModel), typeof (object), typeof (ViewBroker), new PropertyMetadata((object) null, new PropertyChangedCallback(ViewBroker.OnViewModelChanged)));

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      if (this.ViewModel == null)
        return;
      this.ActivateView(this.GetViewForViewModel(this.ViewModel));
    }

    public string BrokerHint
    {
      get => (string) this.GetValue(ViewBroker.BrokerHintProperty);
      set => this.SetValue(ViewBroker.BrokerHintProperty, (object) value);
    }

    public bool AllowUnknownViewModels
    {
      get => (bool) this.GetValue(ViewBroker.AllowUnknownViewModelsProperty);
      set => this.SetValue(ViewBroker.AllowUnknownViewModelsProperty, (object) value);
    }

    public object ViewModel
    {
      get => this.GetValue(ViewBroker.ViewModelProperty);
      set => this.SetValue(ViewBroker.ViewModelProperty, value);
    }

    private static void OnViewModelChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs args)
    {
      ViewBroker viewBroker = o as ViewBroker;
      if (viewBroker.ViewModel == null)
        return;
      object viewForViewModel = viewBroker.GetViewForViewModel(viewBroker.ViewModel);
      viewBroker.ActivateView(viewForViewModel);
    }

    private void ActivateView(object view)
    {
      if (this.Content is IView)
        ((IView) this.Content).OnDeactivated();
      this.Content = view;
      if (!(view is IView))
        return;
      ((IView) view).OnActivated();
    }

    private object GetViewForViewModel(object viewModel)
    {
      Type viewForViewModel = ApexBroker.GetViewForViewModel(viewModel.GetType(), this.BrokerHint);
      if (viewForViewModel == (Type) null && this.AllowUnknownViewModels)
        return (object) null;
      object obj = !(viewForViewModel == (Type) null) ? Activator.CreateInstance(viewForViewModel) : throw new InvalidOperationException("Cannot broker a view for the view model type " + viewModel.GetType().Name);
      if (!(obj is FrameworkElement))
        throw new InvalidOperationException("A View must be a FrameworkElement");
      ((FrameworkElement) obj).DataContext = viewModel;
      return obj;
    }
  }
}

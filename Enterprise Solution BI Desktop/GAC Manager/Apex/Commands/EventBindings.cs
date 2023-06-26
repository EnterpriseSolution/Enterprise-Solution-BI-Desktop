// Decompiled with JetBrains decompiler
// Type: Apex.Commands.EventBindings
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System.Windows;

namespace Apex.Commands
{
  public static class EventBindings
  {
    private static readonly DependencyProperty EventBindingsProperty = DependencyProperty.RegisterAttached(nameof (EventBindings), typeof (EventBindingCollection), typeof (EventBindings), new PropertyMetadata((object) null, new PropertyChangedCallback(EventBindings.OnEventBindingsChanged)));

    public static EventBindingCollection GetEventBindings(DependencyObject o) => (EventBindingCollection) o.GetValue(EventBindings.EventBindingsProperty);

    public static void SetEventBindings(DependencyObject o, EventBindingCollection value) => o.SetValue(EventBindings.EventBindingsProperty, (object) value);

    public static void OnEventBindingsChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs args)
    {
      object oldValue = args.OldValue;
      if (!(args.NewValue is EventBindingCollection newValue))
        return;
      foreach (EventBinding eventBinding in (FreezableCollection<EventBinding>) newValue)
        eventBinding.Bind((object) o);
    }
  }
}

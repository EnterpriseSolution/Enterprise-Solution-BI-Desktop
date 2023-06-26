// Decompiled with JetBrains decompiler
// Type: Apex.Controls.EnumerationComboBox
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using Apex.Extensions;
using Apex.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Apex.Controls
{
  public class EnumerationComboBox : ComboBox
  {
    public static readonly DependencyProperty SelectedEnumerationProperty = DependencyProperty.Register(nameof (SelectedEnumeration), typeof (object), typeof (EnumerationComboBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(EnumerationComboBox.OnSelectedEnumerationChanged)));
    private List<NameValue> enumerations;

    private void EnumerationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (e.AddedItems.Count == 0 || !(e.AddedItems[0] is NameValue))
        return;
      this.SelectedEnumeration = (e.AddedItems[0] as NameValue).Value;
    }

    private void PopulateItemsSource()
    {
      if (this.ItemsSource != null || !(this.SelectedEnumeration is Enum))
        return;
      object[] values = EnumHelper.GetValues(this.SelectedEnumeration.GetType());
      this.enumerations = new List<NameValue>();
      foreach (object obj in values)
        this.enumerations.Add(new NameValue(((Enum) obj).GetDescription(), obj));
      this.ItemsSource = (IEnumerable) this.enumerations;
      this.Initialise();
    }

    private void Initialise()
    {
      this.DisplayMemberPath = "Name";
      this.SelectedValuePath = "Value";
      if (this.enumerations != null && this.SelectedEnumeration != null)
        this.SelectedItem = (object) this.enumerations.Where<NameValue>((Func<NameValue, bool>) (enumeration => enumeration.Value.ToString() == this.SelectedEnumeration.ToString())).FirstOrDefault<NameValue>();
      this.SelectionChanged += new SelectionChangedEventHandler(this.EnumerationComboBox_SelectionChanged);
    }

    public object SelectedEnumeration
    {
      get => this.GetValue(EnumerationComboBox.SelectedEnumerationProperty);
      set => this.SetValue(EnumerationComboBox.SelectedEnumerationProperty, value);
    }

    private static void OnSelectedEnumerationChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs args)
    {
      (o as EnumerationComboBox).PopulateItemsSource();
    }
  }
}

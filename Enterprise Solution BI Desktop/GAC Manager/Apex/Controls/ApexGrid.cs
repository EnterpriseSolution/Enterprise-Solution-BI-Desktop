// Decompiled with JetBrains decompiler
// Type: Apex.Controls.ApexGrid
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Apex.Controls
{
  public class ApexGrid : Grid
  {
    private static readonly DependencyProperty rowsProperty = DependencyProperty.Register(nameof (Rows), typeof (string), typeof (ApexGrid), new PropertyMetadata((object) null, new PropertyChangedCallback(ApexGrid.OnRowsChanged)));
    private static readonly DependencyProperty columnsProperty = DependencyProperty.Register(nameof (Columns), typeof (string), typeof (ApexGrid), new PropertyMetadata((object) null, new PropertyChangedCallback(ApexGrid.OnColumnsChanged)));

    private static void OnRowsChanged(
      DependencyObject dependencyObject,
      DependencyPropertyChangedEventArgs args)
    {
      ApexGrid apexGrid = dependencyObject as ApexGrid;
      apexGrid.RowDefinitions.Clear();
      foreach (GridLength gridLength in ApexGrid.StringLengthsToGridLengths(apexGrid.Rows))
        apexGrid.RowDefinitions.Add(new RowDefinition()
        {
          Height = gridLength
        });
    }

    private static void OnColumnsChanged(
      DependencyObject dependencyObject,
      DependencyPropertyChangedEventArgs args)
    {
      ApexGrid apexGrid = dependencyObject as ApexGrid;
      apexGrid.ColumnDefinitions.Clear();
      foreach (GridLength gridLength in ApexGrid.StringLengthsToGridLengths(apexGrid.Columns))
        apexGrid.ColumnDefinitions.Add(new ColumnDefinition()
        {
          Width = gridLength
        });
    }

    private static List<GridLength> StringLengthsToGridLengths(string lengths)
    {
      List<GridLength> gridLengthList = new List<GridLength>();
      if (string.IsNullOrEmpty(lengths))
        return gridLengthList;
      string[] strArray = lengths.Split(',');
      Apex.Consistency.GridLengthConverter gridLengthConverter = new Apex.Consistency.GridLengthConverter();
      foreach (string gridLength in strArray)
        gridLengthList.Add(gridLengthConverter.ConvertFromString(gridLength));
      return gridLengthList;
    }

    [Description("The rows property.")]
    [Category("Common Properties")]
    public string Rows
    {
      get => (string) this.GetValue(ApexGrid.rowsProperty);
      set => this.SetValue(ApexGrid.rowsProperty, (object) value);
    }

    [Category("Common Properties")]
    [Description("The columns property.")]
    public string Columns
    {
      get => (string) this.GetValue(ApexGrid.columnsProperty);
      set => this.SetValue(ApexGrid.columnsProperty, (object) value);
    }
  }
}

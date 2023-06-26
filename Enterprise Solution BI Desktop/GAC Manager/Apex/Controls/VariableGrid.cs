// Decompiled with JetBrains decompiler
// Type: Apex.Controls.VariableGrid
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Apex.Controls
{
  public class VariableGrid : Grid
  {
    private static readonly DependencyProperty rowsProperty = DependencyProperty.Register(nameof (Rows), typeof (int), typeof (VariableGrid), new PropertyMetadata((object) 1, new PropertyChangedCallback(VariableGrid.OnGridPropertyChanged)));
    private static readonly DependencyProperty columnsProperty = DependencyProperty.Register(nameof (Columns), typeof (int), typeof (VariableGrid), new PropertyMetadata((object) 1, new PropertyChangedCallback(VariableGrid.OnGridPropertyChanged)));
    private static readonly DependencyProperty rowHeightProperty = DependencyProperty.Register(nameof (RowHeight), typeof (string), typeof (VariableGrid), new PropertyMetadata((object) "Auto", new PropertyChangedCallback(VariableGrid.OnGridPropertyChanged)));
    private static readonly DependencyProperty columnsWidthProperty = DependencyProperty.Register(nameof (ColumnWidth), typeof (string), typeof (VariableGrid), new PropertyMetadata((object) "Auto", new PropertyChangedCallback(VariableGrid.OnGridPropertyChanged)));

    private static void OnGridPropertyChanged(
      DependencyObject dependencyObject,
      DependencyPropertyChangedEventArgs args)
    {
      VariableGrid variableGrid = dependencyObject as VariableGrid;
      variableGrid.RowDefinitions.Clear();
      variableGrid.ColumnDefinitions.Clear();
      if (variableGrid.Rows < 0 || variableGrid.Columns < 0)
        return;
      Apex.Consistency.GridLengthConverter gridLengthConverter = new Apex.Consistency.GridLengthConverter();
      for (int index = 0; index < variableGrid.Rows; ++index)
        variableGrid.RowDefinitions.Add(new RowDefinition()
        {
          Height = gridLengthConverter.ConvertFromString(variableGrid.RowHeight)
        });
      for (int index = 0; index < variableGrid.Columns; ++index)
        variableGrid.ColumnDefinitions.Add(new ColumnDefinition()
        {
          Width = gridLengthConverter.ConvertFromString(variableGrid.ColumnWidth)
        });
    }

    [Category("Common Properties")]
    [Description("The number of rows.")]
    public int Rows
    {
      get => (int) this.GetValue(VariableGrid.rowsProperty);
      set => this.SetValue(VariableGrid.rowsProperty, (object) value);
    }

    [Category("Common Properties")]
    [Description("The number of columns.")]
    public int Columns
    {
      get => (int) this.GetValue(VariableGrid.columnsProperty);
      set => this.SetValue(VariableGrid.columnsProperty, (object) value);
    }

    [Description("The row height property (used for all rows).")]
    [Category("Common Properties")]
    public string RowHeight
    {
      get => (string) this.GetValue(VariableGrid.rowHeightProperty);
      set => this.SetValue(VariableGrid.rowHeightProperty, (object) value);
    }

    [Category("Common Properties")]
    [Description("The column width property (used for all columns).")]
    public string ColumnWidth
    {
      get => (string) this.GetValue(VariableGrid.columnsWidthProperty);
      set => this.SetValue(VariableGrid.columnsWidthProperty, (object) value);
    }
  }
}

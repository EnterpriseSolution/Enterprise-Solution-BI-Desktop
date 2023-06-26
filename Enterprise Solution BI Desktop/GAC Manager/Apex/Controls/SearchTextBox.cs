// Decompiled with JetBrains decompiler
// Type: Apex.Controls.SearchTextBox
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System.Windows;

namespace Apex.Controls
{
  public class SearchTextBox : CueTextBox
  {
    public static readonly DependencyProperty SearchModeProperty = DependencyProperty.Register(nameof (SearchMode), typeof (SearchMode), typeof (SearchTextBox), new PropertyMetadata((object) SearchMode.Immediate));

    static SearchTextBox() => FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (SearchTextBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (SearchTextBox)));

    public SearchMode SearchMode
    {
      get => (SearchMode) this.GetValue(SearchTextBox.SearchModeProperty);
      set => this.SetValue(SearchTextBox.SearchModeProperty, (object) value);
    }
  }
}

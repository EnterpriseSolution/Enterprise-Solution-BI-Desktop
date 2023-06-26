// Decompiled with JetBrains decompiler
// Type: Apex.Controls.CueTextBox
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.Windows;
using System.Windows.Controls;

namespace Apex.Controls
{
  [TemplatePart(Name = "PART_CueLabel", Type = typeof (Label))]
  public class CueTextBox : TextBox
  {
    private Label cueLabel;
    public static readonly DependencyProperty CueTextProperty = DependencyProperty.Register(nameof (CueText), typeof (string), typeof (CueTextBox), new PropertyMetadata((object) null));
    public static readonly DependencyProperty CueDisplayModeProperty = DependencyProperty.Register(nameof (CueDisplayMode), typeof (CueDisplayMode), typeof (CueTextBox), new PropertyMetadata((object) CueDisplayMode.HideWhenHasTextOrFocus, new PropertyChangedCallback(CueTextBox.OnCueDisplayModeChanged)));

    static CueTextBox() => FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (CueTextBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (CueTextBox)));

    protected override void OnLostFocus(RoutedEventArgs e)
    {
      base.OnLostFocus(e);
      this.UpdateCueVisiblity();
    }

    protected override void OnGotFocus(RoutedEventArgs e)
    {
      base.OnGotFocus(e);
      this.UpdateCueVisiblity();
    }

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      try
      {
        this.cueLabel = (Label) this.GetTemplateChild("PART_CueLabel");
      }
      catch
      {
        throw new Exception("Unable to access the internal elements of the CueTextBox.");
      }
    }

    protected override void OnTextChanged(TextChangedEventArgs e)
    {
      base.OnTextChanged(e);
      this.UpdateCueVisiblity();
    }

    private void UpdateCueVisiblity()
    {
      switch (this.CueDisplayMode)
      {
        case CueDisplayMode.HideWhenHasText:
          this.cueLabel.Visibility = string.IsNullOrEmpty(this.Text) ? Visibility.Visible : Visibility.Hidden;
          break;
        case CueDisplayMode.HideWhenHasTextOrFocus:
          this.cueLabel.Visibility = this.IsFocused || !string.IsNullOrEmpty(this.Text) ? Visibility.Hidden : Visibility.Visible;
          break;
      }
    }

    public string CueText
    {
      get => (string) this.GetValue(CueTextBox.CueTextProperty);
      set => this.SetValue(CueTextBox.CueTextProperty, (object) value);
    }

    public CueDisplayMode CueDisplayMode
    {
      get => (CueDisplayMode) this.GetValue(CueTextBox.CueDisplayModeProperty);
      set => this.SetValue(CueTextBox.CueDisplayModeProperty, (object) value);
    }

    private static void OnCueDisplayModeChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs args)
    {
      ((CueTextBox) o).UpdateCueVisiblity();
    }
  }
}

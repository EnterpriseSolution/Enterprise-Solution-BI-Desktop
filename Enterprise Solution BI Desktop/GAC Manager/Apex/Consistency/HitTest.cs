// Decompiled with JetBrains decompiler
// Type: Apex.Consistency.HitTest
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Apex.Consistency
{
  public class HitTest
  {
    private List<UIElement> results = new List<UIElement>();

    public void DoHitTest(UIElement rootElement, Point point)
    {
      this.results.Clear();
      VisualTreeHelper.HitTest((Visual) rootElement, (HitTestFilterCallback) null, new HitTestResultCallback(this.HitTestCallback), (HitTestParameters) new PointHitTestParameters(point));
    }

    private HitTestResultBehavior HitTestCallback(HitTestResult result)
    {
      if (result.VisualHit is UIElement)
        this.results.Add(result.VisualHit as UIElement);
      return HitTestResultBehavior.Continue;
    }

    public List<UIElement> Hits => this.results;
  }
}

// Decompiled with JetBrains decompiler
// Type: Apex.Adorners.AdornerLayer
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using Apex.Extensions;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace Apex.Adorners
{
  public partial class AdornerLayer : UserControl, IComponentConnector
  {
    private static Dictionary<DependencyObject, AdornerLayer> adornerLayers = new Dictionary<DependencyObject, AdornerLayer>();
    //internal AdornerLayer adornerLayer;
    //internal Canvas adornerCanvas;
    //private bool _contentLoaded;

    public AdornerLayer()
    {
      this.InitializeComponent();
      this.IsHitTestVisible = false;
    }

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      DependencyObject topLevelParent = (DependencyObject) FrameworkElementExtensions.GetTopLevelParent(this);
      if (AdornerLayer.adornerLayers.ContainsKey(topLevelParent))
        return;
      AdornerLayer.adornerLayers.Add(topLevelParent, this);
    }

    public static AdornerLayer GetAdornerLayer(DependencyObject obj)
    {
      DependencyObject topLevelParent = obj.GetTopLevelParent();
      return AdornerLayer.adornerLayers.ContainsKey(topLevelParent) ? AdornerLayer.adornerLayers[topLevelParent] : (AdornerLayer) null;
    }

    public void AddAdorner(Adorner adorner)
    {
      adorner.ParentAdornerLayer = this;
      adorner.UIElement.RenderTransform = (Transform) adorner.Translation;
      this.adornerCanvas.Children.Add(adorner.UIElement);
    }

    public void RemoveAdorner(Adorner adorner) => this.adornerCanvas.Children.Remove(adorner.UIElement);

    //[DebuggerNonUserCode]
    //[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    //public void InitializeComponent()
    //{
    //  if (this._contentLoaded)
    //    return;
    //  this._contentLoaded = true;
    //  Application.LoadComponent((object) this, new Uri("/Apex;component/adorners/adornerlayer.xaml", UriKind.Relative));
    //}

    //[EditorBrowsable(EditorBrowsableState.Never)]
    //[DebuggerNonUserCode]
    //[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    //void IComponentConnector.Connect(int connectionId, object target)
    //{
    //  switch (connectionId)
    //  {
    //    case 1:
    //      this.adornerLayer = (AdornerLayer) target;
    //      break;
    //    case 2:
    //      this.adornerCanvas = (Canvas) target;
    //      break;
    //    default:
    //      this._contentLoaded = true;
    //      break;
    //  }
    //}
  }
}

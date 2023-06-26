using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace EnterpriseSolutionBIDesktop
{
    public class Office2007Renderer : ToolStripProfessionalRenderer
    {
        #region GradientItemColors
        private class GradientItemColors
        {
            #region Public Fields
            public Color InsideTop1;
            public Color InsideTop2;
            public Color InsideBottom1;
            public Color InsideBottom2;
            public Color FillTop1;
            public Color FillTop2;
            public Color FillBottom1;
            public Color FillBottom2;
            public Color Border1;
            public Color Border2;
            #endregion

            #region Identity
            public GradientItemColors(Color insideTop1, Color insideTop2,
                                      Color insideBottom1, Color insideBottom2,
                                      Color fillTop1, Color fillTop2,
                                      Color fillBottom1, Color fillBottom2,
                                      Color border1, Color border2)
            {
                InsideTop1 = insideTop1;
                InsideTop2 = insideTop2;
                InsideBottom1 = insideBottom1;
                InsideBottom2 = insideBottom2;
                FillTop1 = fillTop1;
                FillTop2 = fillTop2;
                FillBottom1 = fillBottom1;
                FillBottom2 = fillBottom2;
                Border1 = border1;
                Border2 = border2;
            }
            #endregion
        }
        #endregion

        #region Static Metrics
        private static int _gripOffset = 1;
        private static int _gripSquare = 2;
        private static int _gripSize = 3;
        private static int _gripMove = 4;
        private static int _gripLines = 3;
        private static int _checkInset = 1;
        private static int _marginInset = 2;
        private static int _separatorInset = 31;
        private static float _cutToolItemMenu = 1.0f;
        private static float _cutContextMenu = 0f;
        private static float _cutMenuItemBack = 1.2f;
        private static float _contextCheckTickThickness = 1.6f;
        private static Blend _statusStripBlend;
        #endregion

        #region Static Colors
        private static Color _c1 = Color.FromArgb(167, 167, 167);
        private static Color _c2 = Color.FromArgb(21, 66, 139);
        private static Color _c3 = Color.FromArgb(76, 83, 92);
        private static Color _c4 = Color.FromArgb(250, 250, 250);
        private static Color _c5 = Color.FromArgb(248, 248, 248);
        private static Color _c6 = Color.FromArgb(243, 243, 243);
        private static Color _r1 = Color.FromArgb(255, 255, 251);
        private static Color _r2 = Color.FromArgb(255, 249, 227);
        private static Color _r3 = Color.FromArgb(255, 242, 201);
        private static Color _r4 = Color.FromArgb(255, 248, 181);
        private static Color _r5 = Color.FromArgb(255, 252, 229);
        private static Color _r6 = Color.FromArgb(255, 235, 166);
        private static Color _r7 = Color.FromArgb(255, 213, 103);
        private static Color _r8 = Color.FromArgb(255, 228, 145);
        private static Color _r9 = Color.FromArgb(160, 188, 228);
        private static Color _rA = Color.FromArgb(121, 153, 194);
        private static Color _rB = Color.FromArgb(182, 190, 192);
        private static Color _rC = Color.FromArgb(155, 163, 167);
        private static Color _rD = Color.FromArgb(233, 168, 97);
        private static Color _rE = Color.FromArgb(247, 164, 39);
        private static Color _rF = Color.FromArgb(246, 156, 24);
        private static Color _rG = Color.FromArgb(253, 173, 17);
        private static Color _rH = Color.FromArgb(254, 185, 108);
        private static Color _rI = Color.FromArgb(253, 164, 97);
        private static Color _rJ = Color.FromArgb(252, 143, 61);
        private static Color _rK = Color.FromArgb(255, 208, 134);
        private static Color _rL = Color.FromArgb(249, 192, 103);
        private static Color _rM = Color.FromArgb(250, 195, 93);
        private static Color _rN = Color.FromArgb(248, 190, 81);
        private static Color _rO = Color.FromArgb(255, 208, 49);
        private static Color _rP = Color.FromArgb(254, 214, 168);
        private static Color _rQ = Color.FromArgb(252, 180, 100);
        private static Color _rR = Color.FromArgb(252, 161, 54);
        private static Color _rS = Color.FromArgb(254, 238, 170);
        private static Color _rT = Color.FromArgb(249, 202, 113);
        private static Color _rU = Color.FromArgb(250, 205, 103);
        private static Color _rV = Color.FromArgb(248, 200, 91);
        private static Color _rW = Color.FromArgb(255, 218, 59);
        private static Color _rX = Color.FromArgb(254, 185, 108);
        private static Color _rY = Color.FromArgb(252, 161, 54);
        private static Color _rZ = Color.FromArgb(254, 238, 170);

        // Color scheme values
        private static Color _textDisabled = _c1;
        private static Color _textMenuStripItem = _c2;
        private static Color _textStatusStripItem = _c2;
        private static Color _textContextMenuItem = _c2;
        private static Color _arrowDisabled = _c1;
        private static Color _arrowLight = Color.FromArgb(106, 126, 197);
        private static Color _arrowDark = Color.FromArgb(64, 70, 90);
        private static Color _separatorMenuLight = Color.FromArgb(245, 245, 245);
        private static Color _separatorMenuDark = Color.FromArgb(197, 197, 197);
        private static Color _contextMenuBack = _c4;
        private static Color _contextCheckBorder = Color.FromArgb(242, 149, 54);
        private static Color _contextCheckTick = Color.FromArgb(66, 75, 138);
        private static Color _statusStripBorderDark = Color.FromArgb(86, 125, 176);
        private static Color _statusStripBorderLight = Color.White;
        private static Color _gripDark = Color.FromArgb(114, 152, 204);
        private static Color _gripLight = _c5;
        private static GradientItemColors _itemContextItemEnabledColors = new GradientItemColors(_r1, _r2, _r3, _r4, _r5, _r6, _r7, _r8, Color.FromArgb(217, 203, 150), Color.FromArgb(192, 167, 118));
        private static GradientItemColors _itemDisabledColors = new GradientItemColors(_c4, _c6, Color.FromArgb(236, 236, 236), Color.FromArgb(230, 230, 230), _c6, Color.FromArgb(224, 224, 224), Color.FromArgb(200, 200, 200), Color.FromArgb(210, 210, 210), Color.FromArgb(212, 212, 212), Color.FromArgb(195, 195, 195));
        private static GradientItemColors _itemToolItemSelectedColors = new GradientItemColors(_r1, _r2, _r3, _r4, _r5, _r6, _r7, _r8, _r9, _rA);
        private static GradientItemColors _itemToolItemPressedColors = new GradientItemColors(_rD, _rE, _rF, _rG, _rH, _rI, _rJ, _rK, _r9, _rA);
        private static GradientItemColors _itemToolItemCheckedColors = new GradientItemColors(_rL, _rM, _rN, _rO, _rP, _rQ, _rR, _rS, _r9, _rA);
        private static GradientItemColors _itemToolItemCheckPressColors = new GradientItemColors(_rT, _rU, _rV, _rW, _rX, _rI, _rY, _rZ, _r9, _rA);
        #endregion

        #region Identity
        static Office2007Renderer()
        {
            _statusStripBlend = new Blend();
            _statusStripBlend.Positions = new float[] { 0.0f, 0.25f, 0.25f, 0.57f, 0.86f, 1.0f };
            _statusStripBlend.Factors = new float[] { 0.1f, 0.6f, 1.0f, 0.4f, 0.0f, 0.95f };
        }

        public Office2007Renderer()
            : base(new Office2007ColorTable())
        {
            RoundedEdges = false;
        }
        #endregion

        #region OnRenderArrow

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            if ((e.ArrowRectangle.Width > 0) &&
                (e.ArrowRectangle.Height > 0))
            {
                using (GraphicsPath arrowPath = CreateArrowPath(e.Item, e.ArrowRectangle, e.Direction))
                {
                    RectangleF boundsF = arrowPath.GetBounds();
                    boundsF.Inflate(1f, 1f);

                    Color color1 = (e.Item.Enabled ? _arrowLight : _arrowDisabled);
                    Color color2 = (e.Item.Enabled ? _arrowDark : _arrowDisabled);

                    float angle = 0;
                    switch (e.Direction)
                    {
                        case ArrowDirection.Right:
                            angle = 0;
                            break;
                        case ArrowDirection.Left:
                            angle = 180f;
                            break;
                        case ArrowDirection.Down:
                            angle = 90f;
                            break;
                        case ArrowDirection.Up:
                            angle = 270f;
                            break;
                    }
                    using (LinearGradientBrush arrowBrush = new LinearGradientBrush(boundsF, color1, color2, angle))
                        e.Graphics.FillPath(arrowBrush, arrowPath);
                }
            }
        }
        #endregion

        #region OnRenderButtonBackground
        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            ToolStripButton button = (ToolStripButton)e.Item;
            if (button.Selected || button.Pressed || button.Checked)
                RenderToolButtonBackground(e.Graphics, button, e.ToolStrip);
        }
        #endregion

        #region OnRenderDropDownButtonBackground

        protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected || e.Item.Pressed)
                RenderToolDropButtonBackground(e.Graphics, e.Item, e.ToolStrip);
        }
        #endregion

        #region OnRenderItemCheck
        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            Rectangle checkBox = e.ImageRectangle;
            checkBox.Inflate(1, 1);
            if (checkBox.Top > _checkInset)
            {
                int diff = checkBox.Top - _checkInset;
                checkBox.Y -= diff;
                checkBox.Height += diff;
                //yuterz
                checkBox.Width += 2;
            }

            if (checkBox.Height <= (e.Item.Bounds.Height - (_checkInset * 2)))
            {
                int diff = e.Item.Bounds.Height - (_checkInset * 2) - checkBox.Height;
                checkBox.Height += diff;
            }

            using (UseAntiAlias uaa = new UseAntiAlias(e.Graphics))
            {
                using (GraphicsPath borderPath = CreateBorderPath(checkBox, _cutMenuItemBack))
                {
                    using (SolidBrush fillBrush = new SolidBrush(ColorTable.CheckBackground))
                        e.Graphics.FillPath(fillBrush, borderPath);

                    using (Pen borderPen = new Pen(_contextCheckBorder))
                        e.Graphics.DrawPath(borderPen, borderPath);

                    if (e.Image != null)
                    {
                        CheckState checkState = CheckState.Unchecked;

                        if (e.Item is ToolStripMenuItem)
                        {
                            ToolStripMenuItem item = (ToolStripMenuItem)e.Item;
                            checkState = item.CheckState;
                        }

                        switch (checkState)
                        {
                            case CheckState.Checked:
                                using (GraphicsPath tickPath = CreateTickPath(checkBox))
                                {
                                    using (Pen tickPen = new Pen(_contextCheckTick, _contextCheckTickThickness))
                                        e.Graphics.DrawPath(tickPen, tickPath);
                                }
                                break;
                            case CheckState.Indeterminate:
                                using (GraphicsPath tickPath = CreateIndeterminatePath(checkBox))
                                {
                                    using (SolidBrush tickBrush = new SolidBrush(_contextCheckTick))
                                        e.Graphics.FillPath(tickBrush, tickPath);
                                }
                                break;
                        }
                    }
                }
            }
        }
        #endregion

        #region OnRenderItemText
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if ((e.ToolStrip is MenuStrip) ||
                (e.ToolStrip is ToolStrip) ||
                (e.ToolStrip is ContextMenuStrip) ||
                (e.ToolStrip is ToolStripDropDownMenu))
            {
                // We set the color depending on the enabled state
                if (!e.Item.Enabled)
                    e.TextColor = _textDisabled;
                else
                {
                    if ((e.ToolStrip is MenuStrip) && !e.Item.Pressed && !e.Item.Selected)
                        e.TextColor = _textMenuStripItem;
                    else if ((e.ToolStrip is System.Windows.Forms.StatusStrip) && !e.Item.Pressed && !e.Item.Selected)
                        e.TextColor = _textStatusStripItem;
                    else
                        e.TextColor = _textContextMenuItem;
                }

                using (UseClearTypeGridFit clearTypeGridFit = new UseClearTypeGridFit(e.Graphics))
                    base.OnRenderItemText(e);
            }
            else
            {
                base.OnRenderItemText(e);
            }
        }
        #endregion

        #region OnRenderItemImage
        protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
        {
            //if ((e.ToolStrip is ContextMenuStrip) ||
            //    (e.ToolStrip is ToolStripDropDownMenu))
            //{
            //    if (e.Image != null)
            //    {
            //        if (e.Item.Enabled)
            //            e.Graphics.DrawImage(e.Image, e.ImageRectangle);
            //        else
            //           System.Windows.Forms.ControlPaint.DrawImageDisabled(e.Graphics, e.Image,
            //                                           e.ImageRectangle.X,
            //                                           e.ImageRectangle.Y,
            //                                           Color.Transparent);
            //    }
            //}
            //else
            //{
                base.OnRenderItemImage(e);
           // }
        }
        #endregion

        #region OnRenderMenuItemBackground
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if ((e.ToolStrip is MenuStrip) ||
                (e.ToolStrip is ContextMenuStrip) ||
                (e.ToolStrip is ToolStripDropDownMenu))
            {
                if ((e.Item.Pressed) && (e.ToolStrip is MenuStrip))
                {
                    DrawContextMenuHeader(e.Graphics, e.Item);
                }
                else
                {
                    if (e.Item.Selected)
                    {
                        if (e.Item.Enabled)
                        {
                            if (e.ToolStrip is MenuStrip)
                                DrawGradientToolItem(e.Graphics, e.Item, _itemToolItemSelectedColors);
                            else
                                DrawGradientContextMenuItem(e.Graphics, e.Item, _itemContextItemEnabledColors);
                        }
                        else
                        {
                            Point mousePos = e.ToolStrip.PointToClient(Control.MousePosition);
                            if (!e.Item.Bounds.Contains(mousePos))
                            {
                                if (e.ToolStrip is MenuStrip)
                                    DrawGradientToolItem(e.Graphics, e.Item, _itemDisabledColors);
                                else
                                    DrawGradientContextMenuItem(e.Graphics, e.Item, _itemDisabledColors);
                            }
                        }
                    }
                }
            }
            else
            {
                base.OnRenderMenuItemBackground(e);
            }
        }
        #endregion

        #region OnRenderSplitButtonBackground
        protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected || e.Item.Pressed)
            {
                // Cast to correct type
                ToolStripSplitButton splitButton = (ToolStripSplitButton)e.Item;

                // Draw the border and background
                RenderToolSplitButtonBackground(e.Graphics, splitButton, (System.Windows.Forms.ToolStrip)(e.ToolStrip));

                // Get the rectangle that needs to show the arrow
                Rectangle arrowBounds = splitButton.DropDownButtonBounds;

                // Draw the arrow on top of the background
                OnRenderArrow(new ToolStripArrowRenderEventArgs(e.Graphics,
                                                                splitButton,
                                                                arrowBounds,
                                                                SystemColors.ControlText,
                                                                ArrowDirection.Down));
            }
            else
            {
                base.OnRenderSplitButtonBackground(e);
            }
        }
        #endregion

        #region OnRenderStatusStripSizingGrip
        protected override void OnRenderStatusStripSizingGrip(ToolStripRenderEventArgs e)
        {
            using (SolidBrush darkBrush = new SolidBrush(_gripDark),
                            lightBrush = new SolidBrush(_gripLight))
            {
                bool rtl = (e.ToolStrip.RightToLeft == RightToLeft.Yes);

                int y = e.AffectedBounds.Bottom - _gripSize * 2 + 1;

                for (int i = _gripLines; i >= 1; i--)
                {
                    int x = (rtl ? e.AffectedBounds.Left + 1 :
                                   e.AffectedBounds.Right - _gripSize * 2 + 1);
                    for (int j = 0; j < i; j++)
                    {
                        DrawGripGlyph(e.Graphics, x, y, darkBrush, lightBrush);
                        x -= (rtl ? -_gripMove : _gripMove);
                    }
                    y -= _gripMove;
                }
            }
        }
        #endregion

        #region OnRenderToolStripContentPanelBackground
        protected override void OnRenderToolStripContentPanelBackground(ToolStripContentPanelRenderEventArgs e)
        {
            base.OnRenderToolStripContentPanelBackground(e);
            if ((e.ToolStripContentPanel.Width > 0) &&
                (e.ToolStripContentPanel.Height > 0))
            {
                using (LinearGradientBrush backBrush = new LinearGradientBrush(e.ToolStripContentPanel.ClientRectangle, ColorTable.ToolStripContentPanelGradientEnd, ColorTable.ToolStripContentPanelGradientBegin, 90f))
                {
                    e.Graphics.FillRectangle(backBrush, e.ToolStripContentPanel.ClientRectangle);
                }
            }
        }
        #endregion

        #region OnRenderSeparator

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            if ((e.ToolStrip is ContextMenuStrip) ||
                (e.ToolStrip is ToolStripDropDownMenu))
            {
                using (Pen lightPen = new Pen(_separatorMenuLight), darkPen = new Pen(_separatorMenuDark))
                {
                    DrawSeparator(e.Graphics, e.Vertical, e.Item.Bounds, lightPen, darkPen, _separatorInset, (e.ToolStrip.RightToLeft == RightToLeft.Yes));


                }
            }
            else if (e.ToolStrip is System.Windows.Forms.StatusStrip)
            {
                using (Pen lightPen = new Pen(ColorTable.SeparatorLight), darkPen = new Pen(ColorTable.SeparatorDark))
                {
                    DrawSeparator(e.Graphics, e.Vertical, e.Item.Bounds, lightPen, darkPen, 0, false);

                }
            }
            else
            {
                base.OnRenderSeparator(e);
            }
        }
        #endregion

        #region OnRenderToolStripBackground

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            if ((e.ToolStrip is ContextMenuStrip) ||
                (e.ToolStrip is ToolStripDropDownMenu))
            {
                using (GraphicsPath borderPath = CreateBorderPath(e.AffectedBounds, _cutContextMenu),
                                      clipPath = CreateClipBorderPath(e.AffectedBounds, _cutContextMenu))
                {
                    using (UseClipping clipping = new UseClipping(e.Graphics, clipPath))
                    {
                        using (SolidBrush backBrush = new SolidBrush(_contextMenuBack)) e.Graphics.FillPath(backBrush, borderPath);

                    }
                }
            }
            else if (e.ToolStrip is System.Windows.Forms.StatusStrip)
            {
                RectangleF backRect = new RectangleF(0, 1.5f, e.ToolStrip.Width, e.ToolStrip.Height - 2);
                if ((backRect.Width > 0) && (backRect.Height > 0))
                {
                    using (LinearGradientBrush backBrush = new LinearGradientBrush(backRect, ColorTable.StatusStripGradientBegin, ColorTable.StatusStripGradientEnd, 90f))
                    {
                        backBrush.Blend = _statusStripBlend;
                        e.Graphics.FillRectangle(backBrush, backRect);
                    }
                }
            }
            else
            {
                base.OnRenderToolStripBackground(e);
            }
        }
        #endregion

        #region OnRenderImageMargin

        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            if ((e.ToolStrip is ContextMenuStrip) || (e.ToolStrip is ToolStripDropDownMenu))
            {
                Rectangle marginRect = e.AffectedBounds;
                bool rtl = (e.ToolStrip.RightToLeft == RightToLeft.Yes);
                marginRect.Y += _marginInset;
                marginRect.Height -= _marginInset * 2;

                if (!rtl)
                    marginRect.X += _marginInset;
                else
                    marginRect.X += _marginInset / 2;

                using (SolidBrush backBrush = new SolidBrush(ColorTable.ImageMarginGradientBegin))
                    e.Graphics.FillRectangle(backBrush, marginRect);

                using (Pen lightPen = new Pen(_separatorMenuLight), darkPen = new Pen(_separatorMenuDark))
                {
                    if (!rtl)
                    {
                        e.Graphics.DrawLine(lightPen, marginRect.Right, marginRect.Top, marginRect.Right, marginRect.Bottom);
                        e.Graphics.DrawLine(darkPen, marginRect.Right - 1, marginRect.Top, marginRect.Right - 1, marginRect.Bottom);
                    }
                    else
                    {
                        e.Graphics.DrawLine(lightPen, marginRect.Left - 1, marginRect.Top, marginRect.Left - 1, marginRect.Bottom);
                        e.Graphics.DrawLine(darkPen, marginRect.Left, marginRect.Top, marginRect.Left, marginRect.Bottom);
                    }
                }
            }
            else
            {
                base.OnRenderImageMargin(e);
            }
        }
        #endregion

        #region OnRenderToolStripBorder
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            if ((e.ToolStrip is ContextMenuStrip) ||
                (e.ToolStrip is ToolStripDropDownMenu))
            {
                if (!e.ConnectedArea.IsEmpty)
                    using (SolidBrush excludeBrush = new SolidBrush(_contextMenuBack)) e.Graphics.FillRectangle(excludeBrush, e.ConnectedArea);

                using (GraphicsPath borderPath = CreateBorderPath(e.AffectedBounds, e.ConnectedArea, _cutContextMenu),
                                    insidePath = CreateInsideBorderPath(e.AffectedBounds, e.ConnectedArea, _cutContextMenu),
                                      clipPath = CreateClipBorderPath(e.AffectedBounds, e.ConnectedArea, _cutContextMenu))
                {
                    using (Pen borderPen = new Pen(ColorTable.MenuBorder), insidePen = new Pen(_separatorMenuLight))
                    {

                        using (UseClipping clipping = new UseClipping(e.Graphics, clipPath))
                        {
                            using (UseAntiAlias uaa = new UseAntiAlias(e.Graphics))
                            {
                                e.Graphics.DrawPath(insidePen, insidePath);
                                e.Graphics.DrawPath(borderPen, borderPath);
                            }
                            e.Graphics.DrawLine(borderPen, e.AffectedBounds.Right, e.AffectedBounds.Bottom, e.AffectedBounds.Right - 1, e.AffectedBounds.Bottom - 1);
                        }
                    }
                }
            }
            else if (e.ToolStrip is System.Windows.Forms.StatusStrip)
            {
                using (Pen darkBorder = new Pen(_statusStripBorderDark), lightBorder = new Pen(_statusStripBorderLight))
                {
                    e.Graphics.DrawLine(darkBorder, 0, 0, e.ToolStrip.Width, 0);
                    e.Graphics.DrawLine(lightBorder, 0, 1, e.ToolStrip.Width, 1);
                }
            }
            else
            {
                base.OnRenderToolStripBorder(e);
            }
        }
        #endregion

        #region Implementation
        private void RenderToolButtonBackground(Graphics g, ToolStripButton button, System.Windows.Forms.ToolStrip toolstrip)
        {
            if (button.Enabled)
            {
                if (button.Checked)
                {
                    if (button.Pressed)
                        DrawGradientToolItem(g, button, _itemToolItemPressedColors);
                    else if (button.Selected)
                        DrawGradientToolItem(g, button, _itemToolItemCheckPressColors);
                    else
                        DrawGradientToolItem(g, button, _itemToolItemCheckedColors);
                }
                else
                {
                    if (button.Pressed)
                        DrawGradientToolItem(g, button, _itemToolItemPressedColors);
                    else if (button.Selected)
                        DrawGradientToolItem(g, button, _itemToolItemSelectedColors);
                }
            }
            else
            {
                if (button.Selected)
                {
                    Point mousePos = toolstrip.PointToClient(Control.MousePosition);
                    if (!button.Bounds.Contains(mousePos))
                        DrawGradientToolItem(g, button, _itemDisabledColors);

                }
            }
        }

        private void RenderToolDropButtonBackground(Graphics g, ToolStripItem item, System.Windows.Forms.ToolStrip toolstrip)
        {
            if (item.Selected || item.Pressed)
            {
                if (item.Enabled)
                {
                    if (item.Pressed)
                        DrawContextMenuHeader(g, item);
                    else
                        DrawGradientToolItem(g, item, _itemToolItemSelectedColors);
                }
                else
                {
                    Point mousePos = toolstrip.PointToClient(Control.MousePosition);
                    if (!item.Bounds.Contains(mousePos))
                        DrawGradientToolItem(g, item, _itemDisabledColors);
                }
            }

        }

        private void RenderToolSplitButtonBackground(Graphics g, ToolStripSplitButton splitButton, System.Windows.Forms.ToolStrip toolstrip)
        {
            if (splitButton.Selected || splitButton.Pressed)
            {
                if (splitButton.Enabled)
                {
                    if (!splitButton.Pressed && splitButton.ButtonPressed)
                        DrawGradientToolSplitItem(g, splitButton, _itemToolItemPressedColors, _itemToolItemSelectedColors, _itemContextItemEnabledColors);



                    else if (splitButton.Pressed && !splitButton.ButtonPressed)
                        DrawContextMenuHeader(g, splitButton);
                    else
                        DrawGradientToolSplitItem(g, splitButton, _itemToolItemSelectedColors, _itemToolItemSelectedColors, _itemContextItemEnabledColors);



                }
                else
                {
                    Point mousePos = toolstrip.PointToClient(Control.MousePosition);
                    if (!splitButton.Bounds.Contains(mousePos))
                        DrawGradientToolItem(g, splitButton, _itemDisabledColors);
                }
            }

        }

        private void DrawGradientToolItem(Graphics g, ToolStripItem item, GradientItemColors colors)
        {
            DrawGradientItem(g, new Rectangle(Point.Empty, item.Bounds.Size), colors);
            //yuterz
            using (GraphicsPath borderPath = CreateBorderPath(new Rectangle(0, 0, item.Width, item.Height), 1))
            {
                using (SolidBrush fillBrush = new SolidBrush(ColorTable.CheckBackground))
                    g.FillPath(fillBrush, borderPath);
                using (Pen borderPen = new Pen(_contextCheckBorder))
                    g.DrawPath(borderPen, borderPath);
            }
        }

        private void DrawGradientToolSplitItem(Graphics g, ToolStripSplitButton splitButton, GradientItemColors colorsButton, GradientItemColors colorsDrop, GradientItemColors colorsSplit)
        {
            Rectangle backRect = new Rectangle(Point.Empty, splitButton.Bounds.Size);
            Rectangle backRectDrop = splitButton.DropDownButtonBounds;

            if ((backRect.Width > 0) && (backRectDrop.Width > 0) &&
                (backRect.Height > 0) && (backRectDrop.Height > 0))
            {
                Rectangle backRectButton = backRect;
                int splitOffset;

                if (backRectDrop.X > 0)
                {
                    backRectButton.Width = backRectDrop.Left;
                    backRectDrop.X -= 1;
                    backRectDrop.Width++;
                    splitOffset = backRectDrop.X;
                }
                else
                {
                    backRectButton.Width -= backRectDrop.Width - 2;
                    backRectButton.X = backRectDrop.Right - 1;
                    backRectDrop.Width++;
                    splitOffset = backRectDrop.Right - 1;
                }

                using (GraphicsPath borderPath = CreateBorderPath(backRect, _cutMenuItemBack))
                {
                    DrawGradientBack(g, backRectButton, colorsButton);
                    DrawGradientBack(g, backRectDrop, colorsDrop);
                    using (LinearGradientBrush splitBrush = new LinearGradientBrush(new Rectangle(backRect.X + splitOffset, backRect.Top, 1, backRect.Height + 1),
                                                                                    colorsSplit.Border1, colorsSplit.Border2, 90f))
                    {

                        splitBrush.SetSigmaBellShape(0.5f);
                        using (Pen splitPen = new Pen(splitBrush))
                            g.DrawLine(splitPen, backRect.X + splitOffset, backRect.Top + 1, backRect.X + splitOffset, backRect.Bottom - 1);
                    }

                    DrawGradientBorder(g, backRect, colorsButton);
                }
            }
        }

        private void DrawContextMenuHeader(Graphics g, ToolStripItem item)
        {
            Rectangle itemRect = new Rectangle(Point.Empty, item.Bounds.Size);
            using (GraphicsPath borderPath = CreateBorderPath(itemRect, _cutToolItemMenu),
                                insidePath = CreateInsideBorderPath(itemRect, _cutToolItemMenu),
                                  clipPath = CreateClipBorderPath(itemRect, _cutToolItemMenu))
            {
                using (UseClipping clipping = new UseClipping(g, clipPath))
                {
                    using (SolidBrush backBrush = new SolidBrush(_separatorMenuLight))
                        g.FillPath(backBrush, borderPath);

                    using (Pen borderPen = new Pen(ColorTable.MenuBorder))
                        g.DrawPath(borderPen, borderPath);
                }
            }

            //yuterz
            using (GraphicsPath borderPath = CreateBorderPath(new Rectangle(0, 0, item.Width, item.Height), 1))
            {
                using (SolidBrush fillBrush = new SolidBrush(ColorTable.CheckBackground))
                    g.FillPath(fillBrush, borderPath);
                using (Pen borderPen = new Pen(_contextCheckBorder))
                    g.DrawPath(borderPen, borderPath);
            }
        }

        private void DrawGradientContextMenuItem(Graphics g, ToolStripItem item, GradientItemColors colors)
        {
            Rectangle backRect = new Rectangle(2, 0, item.Bounds.Width - 3, item.Bounds.Height);
            DrawGradientItem(g, backRect, colors);
        }

        private void DrawGradientItem(Graphics g, Rectangle backRect, GradientItemColors colors)
        {
            if ((backRect.Width > 0) && (backRect.Height > 0))
            {
                DrawGradientBack(g, backRect, colors);
                DrawGradientBorder(g, backRect, colors);
            }
        }

        private void DrawGradientBack(Graphics g, Rectangle backRect, GradientItemColors colors)
        {
            backRect.Inflate(-1, -1);

            int y2 = backRect.Height / 2;
            Rectangle backRect1 = new Rectangle(backRect.X, backRect.Y, backRect.Width, y2);
            Rectangle backRect2 = new Rectangle(backRect.X, backRect.Y + y2, backRect.Width, backRect.Height - y2);
            Rectangle backRect1I = backRect1;
            Rectangle backRect2I = backRect2;
            backRect1I.Inflate(1, 1);
            backRect2I.Inflate(1, 1);

            using (LinearGradientBrush insideBrush1 = new LinearGradientBrush(backRect1I, colors.InsideTop1, colors.InsideTop2, 90f),
                                       insideBrush2 = new LinearGradientBrush(backRect2I, colors.InsideBottom1, colors.InsideBottom2, 90f))
            {
                g.FillRectangle(insideBrush1, backRect1);
                g.FillRectangle(insideBrush2, backRect2);
            }

            y2 = backRect.Height / 2;
            backRect1 = new Rectangle(backRect.X, backRect.Y, backRect.Width, y2);
            backRect2 = new Rectangle(backRect.X, backRect.Y + y2, backRect.Width, backRect.Height - y2);
            backRect1I = backRect1;
            backRect2I = backRect2;
            backRect1I.Inflate(1, 1);
            backRect2I.Inflate(1, 1);

            using (LinearGradientBrush fillBrush1 = new LinearGradientBrush(backRect1I, colors.FillTop1, colors.FillTop2, 90f),
                                       fillBrush2 = new LinearGradientBrush(backRect2I, colors.FillBottom1, colors.FillBottom2, 90f))
            {
                backRect.Inflate(-1, -1);

                y2 = backRect.Height / 2;
                backRect1 = new Rectangle(backRect.X, backRect.Y, backRect.Width, y2);
                backRect2 = new Rectangle(backRect.X, backRect.Y + y2, backRect.Width, backRect.Height - y2);

                g.FillRectangle(fillBrush1, backRect1);
                g.FillRectangle(fillBrush2, backRect2);
            }
        }

        private void DrawGradientBorder(Graphics g, Rectangle backRect, GradientItemColors colors)
        {
            using (UseAntiAlias uaa = new UseAntiAlias(g))
            {
                Rectangle backRectI = backRect;
                backRectI.Inflate(1, 1);

                using (LinearGradientBrush borderBrush = new LinearGradientBrush(backRectI, colors.Border1, colors.Border2, 90f))
                {
                    borderBrush.SetSigmaBellShape(0.5f);
                    using (Pen borderPen = new Pen(borderBrush))
                    {
                        using (GraphicsPath borderPath = CreateBorderPath(backRect, _cutMenuItemBack))
                            g.DrawPath(borderPen, borderPath);
                    }
                }
            }
        }

        private void DrawGripGlyph(Graphics g, int x, int y, Brush darkBrush, Brush lightBrush)
        {
            g.FillRectangle(lightBrush, x + _gripOffset, y + _gripOffset, _gripSquare, _gripSquare);
            g.FillRectangle(darkBrush, x, y, _gripSquare, _gripSquare);
        }

        private void DrawSeparator(Graphics g, bool vertical, Rectangle rect, Pen lightPen, Pen darkPen, int horizontalInset, bool rtl)
        {
            if (vertical)
            {
                int l = rect.Width / 2;
                int t = rect.Y;
                int b = rect.Bottom;
                g.DrawLine(darkPen, l, t, l, b);
                g.DrawLine(lightPen, l + 1, t, l + 1, b);
            }
            else
            {
                int y = rect.Height / 2;
                int l = rect.X + (rtl ? 0 : horizontalInset);
                int r = rect.Right - (rtl ? horizontalInset : 0);

                g.DrawLine(darkPen, l, y, r, y);
                g.DrawLine(lightPen, l, y + 1, r, y + 1);
            }
        }

        private GraphicsPath CreateBorderPath(Rectangle rect, Rectangle exclude, float cut)
        {
            if (exclude.IsEmpty)
                return CreateBorderPath(rect, cut);

            rect.Width--;
            rect.Height--;

            List<PointF> pts = new List<PointF>();

            float l = rect.X;
            float t = rect.Y;
            float r = rect.Right;
            float b = rect.Bottom;
            float x0 = rect.X + cut;
            float x3 = rect.Right - cut;
            float y0 = rect.Y + cut;
            float y3 = rect.Bottom - cut;
            float cutBack = (cut == 0f ? 1 : cut);

            if ((rect.Y >= exclude.Top) && (rect.Y <= exclude.Bottom))
            {
                float x1 = exclude.X - 1 - cut;
                float x2 = exclude.Right + cut;

                if (x0 <= x1)
                {
                    pts.Add(new PointF(x0, t));
                    pts.Add(new PointF(x1, t));
                    pts.Add(new PointF(x1 + cut, t - cutBack));
                }
                else
                {
                    x1 = exclude.X - 1;
                    pts.Add(new PointF(x1, t));
                    pts.Add(new PointF(x1, t - cutBack));
                }

                if (x3 > x2)
                {
                    pts.Add(new PointF(x2 - cut, t - cutBack));
                    pts.Add(new PointF(x2, t));
                    pts.Add(new PointF(x3, t));
                }
                else
                {
                    x2 = exclude.Right;
                    pts.Add(new PointF(x2, t - cutBack));
                    pts.Add(new PointF(x2, t));
                }
            }
            else
            {
                pts.Add(new PointF(x0, t));
                pts.Add(new PointF(x3, t));
            }

            pts.Add(new PointF(r, y0));
            pts.Add(new PointF(r, y3));
            pts.Add(new PointF(x3, b));
            pts.Add(new PointF(x0, b));
            pts.Add(new PointF(l, y3));
            pts.Add(new PointF(l, y0));

            GraphicsPath path = new GraphicsPath();

            for (int i = 1; i < pts.Count; i++)
                path.AddLine(pts[i - 1], pts[i]);

            path.AddLine(pts[pts.Count - 1], pts[0]);

            return path;
        }

        private GraphicsPath CreateBorderPath(Rectangle rect, float cut)
        {
            rect.Width--;
            rect.Height--;
            GraphicsPath path = new GraphicsPath();
            path.AddLine(rect.Left + cut, rect.Top, rect.Right - cut, rect.Top);
            path.AddLine(rect.Right - cut, rect.Top, rect.Right, rect.Top + cut);
            path.AddLine(rect.Right, rect.Top + cut, rect.Right, rect.Bottom - cut);
            path.AddLine(rect.Right, rect.Bottom - cut, rect.Right - cut, rect.Bottom);
            path.AddLine(rect.Right - cut, rect.Bottom, rect.Left + cut, rect.Bottom);
            path.AddLine(rect.Left + cut, rect.Bottom, rect.Left, rect.Bottom - cut);
            path.AddLine(rect.Left, rect.Bottom - cut, rect.Left, rect.Top + cut);
            path.AddLine(rect.Left, rect.Top + cut, rect.Left + cut, rect.Top);
            return path;
        }

        private GraphicsPath CreateInsideBorderPath(Rectangle rect, float cut)
        {
            rect.Inflate(-1, -1);
            return CreateBorderPath(rect, cut);
        }

        private GraphicsPath CreateInsideBorderPath(Rectangle rect, Rectangle exclude, float cut)
        {
            rect.Inflate(-1, -1);
            return CreateBorderPath(rect, exclude, cut);
        }

        private GraphicsPath CreateClipBorderPath(Rectangle rect, float cut)
        {
            rect.Width++;
            rect.Height++;
            return CreateBorderPath(rect, cut);
        }

        private GraphicsPath CreateClipBorderPath(Rectangle rect, Rectangle exclude, float cut)
        {
            rect.Width++;
            rect.Height++;
            return CreateBorderPath(rect, exclude, cut);
        }

        private GraphicsPath CreateArrowPath(ToolStripItem item, Rectangle rect, ArrowDirection direction)
        {
            int x, y;

            if ((direction == ArrowDirection.Left) ||
                (direction == ArrowDirection.Right))
            {
                x = rect.Right - (rect.Width - 4) / 2;
                y = rect.Y + rect.Height / 2;
            }
            else
            {
                x = rect.X + rect.Width / 2;
                y = rect.Bottom - (rect.Height - 3) / 2;

                if ((item is ToolStripDropDownButton) &&
                    (item.RightToLeft == RightToLeft.Yes))
                    x++;
            }

            GraphicsPath path = new GraphicsPath();

            switch (direction)
            {
                case ArrowDirection.Right:
                    path.AddLine(x, y, x - 4, y - 4);
                    path.AddLine(x - 4, y - 4, x - 4, y + 4);
                    path.AddLine(x - 4, y + 4, x, y);
                    break;
                case ArrowDirection.Left:
                    path.AddLine(x - 4, y, x, y - 4);
                    path.AddLine(x, y - 4, x, y + 4);
                    path.AddLine(x, y + 4, x - 4, y);
                    break;
                case ArrowDirection.Down:
                    path.AddLine(x + 3f, y - 3f, x - 2f, y - 3f);
                    path.AddLine(x - 2f, y - 3f, x, y);
                    path.AddLine(x, y, x + 3f, y - 3f);
                    break;
                case ArrowDirection.Up:
                    path.AddLine(x + 3f, y, x - 3f, y);
                    path.AddLine(x - 3f, y, x, y - 4f);
                    path.AddLine(x, y - 4f, x + 3f, y);
                    break;
            }

            return path;
        }

        private GraphicsPath CreateTickPath(Rectangle rect)
        {
            int x = rect.X + rect.Width / 2;
            int y = rect.Y + rect.Height / 2;

            GraphicsPath path = new GraphicsPath();
            path.AddLine(x - 4, y, x - 2, y + 4);
            path.AddLine(x - 2, y + 4, x + 3, y - 5);
            return path;
        }

        private GraphicsPath CreateIndeterminatePath(Rectangle rect)
        {
            int x = rect.X + rect.Width / 2;
            int y = rect.Y + rect.Height / 2;

            GraphicsPath path = new GraphicsPath();
            path.AddLine(x - 3, y, x, y - 3);
            path.AddLine(x, y - 3, x + 3, y);
            path.AddLine(x + 3, y, x, y + 3);
            path.AddLine(x, y + 3, x - 3, y);
            return path;
        }

        #endregion
    }
}

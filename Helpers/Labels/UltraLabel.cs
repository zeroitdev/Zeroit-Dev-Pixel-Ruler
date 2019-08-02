// ***********************************************************************
// Assembly         : Zeroit.Framework.Labels
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-18-2018
// ***********************************************************************
// <copyright file="UltraLabel.cs" company="Zeroit Dev Technologies">
//    This program is for creating Label controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit_Dev_Pixel_Ruler
{
    /// <summary>
    /// A class collection for rendering a label with nice features.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(UltraLabelDesigner))]
    public partial class ZeroitUltraLabel : Control
    {

        #region Private Variables
        //Add all of the Property Backing Feilds for the Properties added to the LabelEx class
        /// <summary>
        /// The out line pen
        /// </summary>
        private Pen _OutLinePen = new Pen(Color.Black);
        /// <summary>
        /// The border pen
        /// </summary>
        private Pen _BorderPen = new Pen(Color.Black);
        /// <summary>
        /// The center brush
        /// </summary>
        private SolidBrush _CenterBrush = new SolidBrush(Color.White);
        /// <summary>
        /// The background brush
        /// </summary>
        private SolidBrush _BackgroundBrush = new SolidBrush(Color.Transparent);
        /// <summary>
        /// The border style
        /// </summary>
        private BorderType _BorderStyle = BorderType.None;
        /// <summary>
        /// The image
        /// </summary>
        private Bitmap _Image = null;
        /// <summary>
        /// The image align
        /// </summary>
        private ContentAlignment _ImageAlign = ContentAlignment.MiddleCenter;
        /// <summary>
        /// The text align
        /// </summary>
        private ContentAlignment _TextAlign = ContentAlignment.MiddleCenter;
        /// <summary>
        /// The text pattern image
        /// </summary>
        private Bitmap _TextPatternImage = null;
        /// <summary>
        /// The text pattern image layout
        /// </summary>
        private PatternLayout _TextPatternImageLayout = PatternLayout.Stretch;
        /// <summary>
        /// The shadow brush
        /// </summary>
        private SolidBrush _ShadowBrush = new SolidBrush(Color.FromArgb(128, Color.Black));
        /// <summary>
        /// The shadow pen
        /// </summary>
        private Pen _ShadowPen = new Pen(Color.FromArgb(128, Color.Black));
        /// <summary>
        /// The shadow color
        /// </summary>
        private Color _ShadowColor = Color.Black;
        /// <summary>
        /// The show text shadow
        /// </summary>
        private bool _ShowTextShadow = false;
        /// <summary>
        /// The shadow position
        /// </summary>
        private ShadowArea _ShadowPosition = ShadowArea.BottomRight;
        /// <summary>
        /// The shadow depth
        /// </summary>
        private int _ShadowDepth = 2;
        /// <summary>
        /// The shadow transparency
        /// </summary>
        private int _ShadowTransparency = 128;
        /// <summary>
        /// The shadow style
        /// </summary>
        private ShadowDrawingType _ShadowStyle = ShadowDrawingType.FillShadow;
        /// <summary>
        /// The fore color transparency
        /// </summary>
        private int _ForeColorTransparency = 255;
        /// <summary>
        /// The outline thickness
        /// </summary>
        private int _OutlineThickness = 1;

        #endregion

        #region Enums
        //Declare the Enums used for some of the special selections we want to use for some of the properties

        /// <summary>
        /// Enum of BorderTypes used for the Labels BorderStyle.
        /// </summary>
        public enum BorderType : int
        {
            /// <summary>
            /// Set the border type to none.
            /// </summary>
            None = 0,
            /// <summary>
            /// Set the border type to squared.
            /// </summary>
            Squared = 1,
            /// <summary>
            /// Set the border type to rounded.
            /// </summary>
            Rounded = 2
        }

        /// <summary>
        /// Enum of layout styles used for the Labels TextPaternImage.
        /// </summary>
        public enum PatternLayout : int
        {
            /// <summary>
            /// Set the pattern layout to normal.
            /// </summary>
            Normal = 0,
            /// <summary>
            /// Set the pattern layout to center.
            /// </summary>
            Center = 1,
            /// <summary>
            /// Set the pattern layout to stretch.
            /// </summary>
            Stretch = 2,
            /// <summary>
            /// Set the pattern layout to title.
            /// </summary>
            Tile = 3
        }

        /// <summary>
        /// Enum of areas used for the Labels ShadowPosition.
        /// </summary>
        public enum ShadowArea : int
        {
            /// <summary>
            /// Set the Shadow area to Top Left.
            /// </summary>
            TopLeft = 0,
            /// <summary>
            /// Set the Shadow area to Top Right.
            /// </summary>
            TopRight = 1,
            /// <summary>
            /// Set the Shadow area to Bottom Left.
            /// </summary>
            BottomLeft = 2,
            /// <summary>
            /// Set the Shadow area to Bottom Right.
            /// </summary>
            BottomRight = 3
        }

        /// <summary>
        /// Enum of drawing types used for the Labels ShadowStyle.
        /// </summary>
        public enum ShadowDrawingType : int
        {
            /// <summary>
            /// Set the shadow drawing type to <c>DrawShadow</c>.
            /// </summary>
            DrawShadow = 0,
            /// <summary>
            /// Set the shadow drawing type to <c>FillShadow</c>.
            /// </summary>
            FillShadow = 1
        }

        #endregion

        #region Constructor

        //In the constructor we set all the styles we want the LabelEx control to have when it is created.
        //We also set a few properties that we want the control to have set by default when a new instance is created.
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitUltraLabel" /> class.
        /// </summary>
        public ZeroitUltraLabel()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.Font = new Font("Comic Sans MS", 18, FontStyle.Bold);
            this.Size = new Size(130, 38);
            this.ForeColor = Color.White;
            this.BackColor = Color.Transparent;

            SlideIncludeInConstructor();
        }

        #endregion

        #region Properties
        //Create all of the properties we want the control to have and Override the ones it already has if they need to be used for special reasons. 

        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <value>The color of the back.</value>
        [Category("Appearance"), Description("The background color of the Label.")]
        [Browsable(true), DefaultValue(typeof(Color), "Transparent")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                _BackgroundBrush.Color = value;
            }
        }

        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        /// <value>The color of the text.</value>
        [Category("Appearance"), Description("The center color of the text.")]
        [Browsable(true), DefaultValue(typeof(Color), "White")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                if (value == Color.Transparent)
                    _ForeColorTransparency = 0;
                _CenterBrush.Color = Color.FromArgb(_ForeColorTransparency, value);
            }
        }

        /// <summary>
        /// Gets or sets the fore color transparency.
        /// </summary>
        /// <value>The fore color transparency.</value>
        /// <remarks>A value between 0 and 255 that sets the transparency of the ForeColor.</remarks>
        [Category("Appearance"), Description("A value between 0 and 255 that sets the transparency of the ForeColor.")]
        [Browsable(true), DefaultValue(255)]
        public int ForeColorTransparency
        {
            get { return _ForeColorTransparency; }
            set
            {
                if (value > 255)
                    value = 255;
                if (value < 0 | this.ForeColor == Color.Transparent)
                    value = 0;
                _ForeColorTransparency = value;
                _CenterBrush.Color = Color.FromArgb(value, this.ForeColor);
                this.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the text alignment.
        /// </summary>
        /// <value>The text alignment.</value>
        /// <remarks>Aligns the text to the left, right, top, or bottom of the Label.</remarks>
        [Category("Appearance"), Description("Aligns the text to the left, right, top, or bottom of the Label.")]
        [Browsable(true), DefaultValue(typeof(ContentAlignment), "MiddleCenter")]
        public ContentAlignment TextAlign
        {
            get { return _TextAlign; }
            set
            {
                _TextAlign = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        [Category("Appearance"), Description("The Image for the Label.")]
        [Browsable(true)]
        public Bitmap Image
        {
            get { return _Image; }
            set
            {
                _Image = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the image alignment.
        /// </summary>
        /// <value>The image align.</value>
        /// <remarks>Aligns the Image to the left, right, top, or bottom.</remarks>
        [Category("Appearance"), Description("Aligns the Image to the left, right, top, or bottom.")]
        [Browsable(true), DefaultValue(typeof(ContentAlignment), "MiddleCenter")]
        public ContentAlignment ImageAlign
        {
            get { return _ImageAlign; }
            set
            {
                _ImageAlign = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the outline color of the text.
        /// </summary>
        /// <value>The outline color of the text.</value>
        [Category("Appearance"), Description("The outline color of the text.")]
        [Browsable(true), DefaultValue(typeof(Color), "Black")]
        public Color OutlineColor
        {
            get { return _OutLinePen.Color; }
            set
            {
                _OutLinePen.Color = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the outline thickness.
        /// </summary>
        /// <value>The outline thickness.</value>
        /// <remarks>The thickness of the text outline. Limited to a number between 1 and 10.</remarks>
        [Category("Appearance"), Description("The thickness of the text outline. Limited to a number between 1 and 10.")]
        [Browsable(true), DefaultValue(1)]
        public int OutlineThickness
        {
            get { return _OutlineThickness; }
            set
            {
                if (value < 1)
                    value = 1;
                //Dont let the user set lower than 1
                if (value > 10)
                    value = 10;
                //Dont let the user set higher than 10
                _OutlineThickness = value;
                _OutLinePen.Width = value;
                _ShadowPen.Width = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        /// <exception cref="Exception">The border color does not support the Transparent color</exception>
        [Category("Appearance"), Description("The color of the Labels border.")]
        [Browsable(true), DefaultValue(typeof(Color), "Black")]
        public Color BorderColor
        {
            get { return _BorderPen.Color; }
            set
            {
                if (value == Color.Transparent)
                {
                    value = _BorderPen.Color;
                    //Set it back to the prior color
                    //Alert the user that Color.Transparent is not supported for this property
                    throw new Exception("The border color does not support the Transparent color");
                }
                _BorderPen.Color = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the border style.
        /// </summary>
        /// <value>The border style.</value>
        [Category("Appearance"), Description("The style of the border around the Label.")]
        [Browsable(true), DefaultValue(typeof(BorderType), "None")]
        public BorderType BorderStyle
        {
            get { return _BorderStyle; }
            set
            {
                _BorderStyle = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the text pattern image.
        /// </summary>
        /// <value>The text pattern image.</value>
        /// <remarks>An image used as a fill pattern for the center of the text.</remarks>
        [Category("Appearance"), Description("An image used as a fill pattern for the center of the text.")]
        [Browsable(true)]
        public Bitmap TextPatternImage
        {
            get { return _TextPatternImage; }
            set
            {
                _TextPatternImage = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the text pattern image layout.
        /// </summary>
        /// <value>The text pattern image layout.</value>
        [Category("Appearance"), Description("The layout of the pattern image inside the text.")]
        [Browsable(true), DefaultValue(typeof(PatternLayout), "Stretch")]
        public PatternLayout TextPatternImageLayout
        {
            get { return _TextPatternImageLayout; }
            set
            {
                _TextPatternImageLayout = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show text shadow.
        /// </summary>
        /// <value><c>true</c> if show text shadow; otherwise, <c>false</c>.</value>
        [Category("Appearance"), Description("Show a shadow behind the text.")]
        [Browsable(true), DefaultValue(false)]
        public bool ShowTextShadow
        {
            get { return _ShowTextShadow; }
            set
            {
                _ShowTextShadow = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the color of the shadow.
        /// </summary>
        /// <value>The color of the shadow.</value>
        /// <exception cref="Exception">The Shadow color does not support using Color.Transparent</exception>
        [Category("Appearance"), Description("The color of the shadow behind the text.")]
        [Browsable(true), DefaultValue(typeof(Color), "Black")]
        public Color ShadowColor
        {
            get { return _ShadowColor; }
            set
            {
                if (value == Color.Transparent)
                {
                    value = _ShadowBrush.Color;
                    //Set it back to the prior color
                    //Alert the user that Color.Transparent is not supported for this property
                    throw new Exception("The Shadow color does not support using Color.Transparent");
                }
                _ShadowColor = value;
                _ShadowBrush.Color = Color.FromArgb(_ShadowTransparency, value);
                _ShadowPen.Color = Color.FromArgb(_ShadowTransparency, value);
                this.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the shadow position.
        /// </summary>
        /// <value>The shadow position.</value>
        [Category("Appearance"), Description("The position of the shadow behind the text.")]
        [Browsable(true), DefaultValue(typeof(ShadowArea), "BottomRight")]
        public ShadowArea ShadowPosition
        {
            get { return _ShadowPosition; }
            set
            {
                _ShadowPosition = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the shadow depth.
        /// </summary>
        /// <value>The shadow depth.</value>
        /// <remarks>A value between 1-10 that controls the depth of the shadow behind the text.</remarks>
        [Category("Appearance"), Description("A value between 1-10 that controls the depth of the shadow behind the text.")]
        [Browsable(true), DefaultValue(2)]
        public int ShadowDepth
        {
            get { return _ShadowDepth; }
            set
            {
                if (value < 1)
                    value = 1;
                //Dont let user set this property lower than 1
                if (value > 10)
                    value = 10;
                //Dont let user set this property higher than 10
                _ShadowDepth = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the shadow transparency.
        /// </summary>
        /// <value>The shadow transparency.</value>
        /// <remarks>A value between 0 and 255 that sets the transparency of the shadow.</remarks>
        [Category("Appearance"), Description("A value between 0 and 255 that sets the transparency of the shadow.")]
        [Browsable(true), DefaultValue(128)]
        public int ShadowTransparency
        {
            get { return _ShadowTransparency; }
            set
            {
                if (value < 0)
                    value = 0;
                //Dont let user set this property lower than 0
                if (value > 255)
                    value = 255;
                //Dont let user set this property higher than 255
                _ShadowTransparency = value;
                _ShadowBrush.Color = Color.FromArgb(value, _ShadowColor);
                _ShadowPen.Color = Color.FromArgb(value, _ShadowColor);
                this.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the shadow style.
        /// </summary>
        /// <value>The shadow style.</value>
        [Category("Appearance"), Description("The style used to draw the shadow.")]
        [Browsable(true), DefaultValue(typeof(ShadowDrawingType), "FillShadow")]
        public ShadowDrawingType ShadowStyle
        {
            get { return _ShadowStyle; }
            set
            {
                _ShadowStyle = value;
                this.Refresh();
            }
        }

        #endregion

        #region TextRenderingHint

        #region Add it to OnPaint / Graphics Rendering component

        //e.Graphics.TextRenderingHint = textrendering;
        #endregion

        /// <summary>
        /// The textrendering
        /// </summary>
        TextRenderingHint textrendering = TextRenderingHint.AntiAlias;

        /// <summary>
        /// Gets or sets the text rendering.
        /// </summary>
        /// <value>The text rendering.</value>
        public TextRenderingHint TextRendering
        {
            get { return textrendering; }
            set
            {
                textrendering = value;
                Invalidate();
            }
        }
        #endregion

        #region Smoothing Mode

        /// <summary>
        /// The smoothing
        /// </summary>
        private SmoothingMode smoothing = SmoothingMode.AntiAlias;

        /// <summary>
        /// Gets or sets the smoothing.
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get { return smoothing; }
            set
            {
                if (value == SmoothingMode.Invalid)
                {
                    value = SmoothingMode.AntiAlias;
                    Invalidate();
                }
                smoothing = value;
                Invalidate();
            }
        }

        #endregion

        #region Overrides and Private Methods
        //Use the OnPaint overrides sub to paint the control to match how all the properties settings have been set by the user
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            TransInPaint(e.Graphics);
            var _with1 = e.Graphics;
            _with1.TextRenderingHint = TextRendering;

            //Fill the background with the BackColor color
            _with1.FillRectangle(_BackgroundBrush, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));

            //If the BackgroundImage property has been set to an image then draw the BackgroundImage
            if (this.BackgroundImage != null)
            {
                DrawBackImage(e.Graphics);
            }

            //If the Image property has been set to an image then draw the image on the control
            if (_Image != null)
            {
                _with1.DrawImage(_Image, AlignImage(new Rectangle(0, 0, this.Width - 1, this.Height - 1)));
            }

            //If the Text property has bet assigned any text then draw the text on the control
            if (!string.IsNullOrEmpty(this.Text))
            {
                //Set the smothing mode of the graphics to make things look smother
                //_with1.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias;
                _with1.SmoothingMode = Smoothing;

                //The Drawing2D.GraphicsPath used for drawing and/or filling the text
                using (GraphicsPath pth = new GraphicsPath())
                {

                    //The StringFormat used to align the text in the Label
                    using (StringFormat sf = new StringFormat())
                    {
                        //Use (ta) which is an integer value of the ContentAlignment integer enum to set the
                        //Alignment of the text that will be added to the Drawing2D.GraphicsPath
                        int ta = Convert.ToInt32(_TextAlign);
                        if (ta < 8)
                        {
                            sf.LineAlignment = StringAlignment.Near;
                        }
                        else if (ta < 128)
                        {
                            sf.LineAlignment = StringAlignment.Center;
                            ta = ta / 16;
                        }
                        else
                        {
                            sf.LineAlignment = StringAlignment.Far;
                            ta = ta / 256;
                        }
                        if (ta == Convert.ToInt32(ContentAlignment.TopLeft))
                        {
                            sf.Alignment = StringAlignment.Near;
                        }
                        else if (ta == Convert.ToInt32(ContentAlignment.TopCenter))
                        {
                            sf.Alignment = StringAlignment.Center;
                        }
                        else if (ta == Convert.ToInt32(ContentAlignment.TopRight))
                        {
                            sf.Alignment = StringAlignment.Far;
                        }
                        
                        if(Slide)
                        {
                            DrawSlidingText(_with1, new SolidBrush(ForeColor), pth, sf);
                        }
                        else
                        {
                            //Add the text to the Drawing2D.GraphicsPath using the StringFormat
                            pth.AddString(this.Text, this.Font.FontFamily, Convert.ToInt32(this.Font.Style), Convert.ToSingle((_with1.DpiY * this.Font.Size) / 72), new Rectangle(this.Padding.Left, this.Padding.Top, (this.ClientSize.Width - 1) - (this.Padding.Left + this.Padding.Right), (this.ClientSize.Height - 1) - (this.Padding.Top + this.Padding.Bottom)), sf);

                        }
                    }

                    //If the ShowTextShadow property is set to true then draw the shadow
                    if (_ShowTextShadow)
                    {
                        //Use the ShadowPosition property to set the Graphics.TranslateTransform to draw the
                        //shadow at the correct offset position.
                        if (_ShadowPosition == ShadowArea.TopLeft)
                        {
                            _with1.TranslateTransform(-_ShadowDepth, -_ShadowDepth);
                        }
                        else if (_ShadowPosition == ShadowArea.TopRight)
                        {
                            _with1.TranslateTransform(+_ShadowDepth, -_ShadowDepth);
                        }
                        else if (_ShadowPosition == ShadowArea.BottomLeft)
                        {
                            _with1.TranslateTransform(-_ShadowDepth, +_ShadowDepth);
                        }
                        else
                        {
                            _with1.TranslateTransform(+_ShadowDepth, +_ShadowDepth);
                        }

                        if (_ShadowStyle == ShadowDrawingType.DrawShadow)
                        {
                            //Draw the Drawing2D.GraphicsPath with the _ShadowPen that is set to the ShadowColor having the ShadowTransparency
                            _with1.DrawPath(_ShadowPen, pth);
                            //Draws the shadow
                        }
                        else
                        {
                            //Fill the Drawing2D.GraphicsPath with the _ShadowBrush that is set to the ShadowColor having the ShadowTransparency
                            _with1.FillPath(_ShadowBrush, pth);
                            //Draws the shadow
                        }


                        //Now use the Graphics.TranslateTransform to shift the graphics back in the opposite
                        //direction before Drawing and Filling the Drawing2D.GraphicsPath again with text colors
                        if (_ShadowPosition == ShadowArea.TopLeft)
                        {
                            _with1.TranslateTransform(+(_ShadowDepth * 2), +(_ShadowDepth * 2));
                        }
                        else if (_ShadowPosition == ShadowArea.TopRight)
                        {
                            _with1.TranslateTransform(-(_ShadowDepth * 2), +(_ShadowDepth * 2));
                        }
                        else if (_ShadowPosition == ShadowArea.BottomLeft)
                        {
                            _with1.TranslateTransform(+(_ShadowDepth * 2), -(_ShadowDepth * 2));
                        }
                        else
                        {
                            _with1.TranslateTransform(-(_ShadowDepth * 2), -(_ShadowDepth * 2));
                        }
                    }

                    //If the TextPatternImage property has been set to an image then fill the center of the text with the image
                    //else the center will be filled with a soloid color of the ForeColor property.
                    if (_TextPatternImage != null)
                    {
                        //Use the TextPatternImageLayout property to resize and/or position the TextPatternImage
                        Rectangle br = new Rectangle();
                        RectangleF r = pth.GetBounds();
                        if (_TextPatternImageLayout == PatternLayout.Normal | _TextPatternImageLayout == PatternLayout.Tile)
                        {
                            br = new Rectangle(Convert.ToInt32(r.X) + 1, Convert.ToInt32(r.Y + 1), _TextPatternImage.Width + 1, _TextPatternImage.Height + 1);
                        }
                        else if (_TextPatternImageLayout == PatternLayout.Center)
                        {
                            int xx = Convert.ToInt32((r.X + 1) + ((r.Width / 2) - (_TextPatternImage.Width / 2)));
                            int yy = Convert.ToInt32((r.Y + 1) + ((r.Height / 2) - (_TextPatternImage.Height / 2)));
                            br = new Rectangle(xx, yy, _TextPatternImage.Width + 1, _TextPatternImage.Height + 1);
                        }
                        else if (_TextPatternImageLayout == PatternLayout.Stretch)
                        {
                            br = new Rectangle(Convert.ToInt32(r.X) + 1, Convert.ToInt32(r.Y + 1), Convert.ToInt32(r.Width) + 1, Convert.ToInt32(r.Height) + 1);
                        }
                        using (Bitmap patBmp = new Bitmap(_TextPatternImage, br.Width, br.Height))
                        {
                            //Use a TextureBrush with the TextPatternImage assigned as the texture image
                            using (TextureBrush tb = new TextureBrush(patBmp))
                            {
                                //If the TextPatternImageLayout property is not set to Tile then set the set the
                                //TextureBrush`s WrapMode to Clamp to stop it from tiling the image.
                                if (!(_TextPatternImageLayout == PatternLayout.Tile))
                                    tb.WrapMode = WrapMode.Clamp;
                                tb.TranslateTransform(br.X, br.Y);
                                //Fill the GraphicsPath with the TextureBrush.
                                _with1.FillPath(tb, pth);
                            }
                        }
                    }
                    else
                    {
                        //Fill the GraphicsPath with a soloid color of the ForeColor property.
                        _with1.FillPath(_CenterBrush, pth);
                    }
                    //Draw the GraphicsPath with the OutlineColor.
                    _with1.DrawPath(_OutLinePen, pth);
                }
            }

            //If the BorderStyle property is other than None then call the DrawBorder sub to draw the border
            if (_BorderStyle != BorderType.None)
            {
                DrawLabelBorder(e.Graphics, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            }
        }

        //A private sub used to position, resize, and draw the BackgroundImage according to the BackgroundImageLayout
        /// <summary>
        /// Draws the back image.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawBackImage(Graphics g)
        {
            if (this.BackgroundImageLayout == ImageLayout.None)
            {
                g.DrawImage(this.BackgroundImage, 0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height);
            }
            else if (this.BackgroundImageLayout == ImageLayout.Tile)
            {
                int tc = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(this.Width / this.BackgroundImage.Width)));
                int tr = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(this.Height / this.BackgroundImage.Height)));
                for (int y = 0; y <= tr; y++)
                {
                    for (int x = 0; x <= tc; x++)
                    {
                        g.DrawImage(this.BackgroundImage, (x * this.BackgroundImage.Width), (y * this.BackgroundImage.Height), this.BackgroundImage.Width, this.BackgroundImage.Height);
                    }
                }
            }
            else if (this.BackgroundImageLayout == ImageLayout.Center)
            {
                int xx = Convert.ToInt32((this.Width / 2) - (this.BackgroundImage.Width / 2));
                int yy = Convert.ToInt32((this.Height / 2) - (this.BackgroundImage.Height / 2));
                g.DrawImage(this.BackgroundImage, xx, yy, this.BackgroundImage.Width, this.BackgroundImage.Height);
            }
            else if (this.BackgroundImageLayout == ImageLayout.Stretch)
            {
                g.DrawImage(this.BackgroundImage, 0, 0, this.Width, this.Height);
            }
            else if (this.BackgroundImageLayout == ImageLayout.Zoom)
            {
                double meratio = this.Width / this.Height;
                double imgratio = this.BackgroundImage.Width / this.BackgroundImage.Height;
                Rectangle imgrect = new Rectangle(0, 0, this.Width, this.Height);
                if (imgratio > meratio)
                {
                    imgrect.Width = this.Width;
                    imgrect.Height = Convert.ToInt32(this.Width / imgratio);
                }
                else if (imgratio < meratio)
                {
                    imgrect.Height = this.Height;
                    imgrect.Width = Convert.ToInt32(this.Height * imgratio);
                }
                imgrect.X = Convert.ToInt32((this.Width / 2) - (imgrect.Width / 2));
                imgrect.Y = Convert.ToInt32((this.Height / 2) - (imgrect.Height / 2));
                g.DrawImage(this.BackgroundImage, imgrect);
            }
        }

        //A private sub used for drawing the Border part of the control
        /// <summary>
        /// Draws the label border.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="rec">The record.</param>
        private void DrawLabelBorder(Graphics g, Rectangle rec)
        {
            //If the ShowTextShadow property is true and the Text property is not an empty string then because of the
            //prior calls to the Graphics.TranslateTransform used for the shadow effect the Graphics must be shifted
            //back to its center position before drawing the border.
            if (_ShowTextShadow & !string.IsNullOrEmpty(this.Text))
            {
                if (_ShadowPosition == ShadowArea.TopLeft)
                {
                    g.TranslateTransform(-_ShadowDepth, -_ShadowDepth);
                }
                else if (_ShadowPosition == ShadowArea.TopRight)
                {
                    g.TranslateTransform(+_ShadowDepth, -_ShadowDepth);
                }
                else if (_ShadowPosition == ShadowArea.BottomLeft)
                {
                    g.TranslateTransform(-_ShadowDepth, +_ShadowDepth);
                }
                else
                {
                    g.TranslateTransform(+_ShadowDepth, +_ShadowDepth);
                }
            }

            //If the BorderStyle property is set to Rounded then draw the border with rounded corners
            //else just draw a Rectangle
            if (_BorderStyle == BorderType.Rounded)
            {
                g.SmoothingMode = Smoothing;
                using (GraphicsPath gp = new GraphicsPath())
                {
                    int rad = Convert.ToInt32(rec.Height / 3);
                    if (rec.Width < rec.Height)
                        rad = Convert.ToInt32(rec.Width / 3);
                    gp.AddArc(rec.X, rec.Y, rad, rad, 180, 90);
                    gp.AddArc(rec.Right - (rad), rec.Y, rad, rad, 270, 90);
                    gp.AddArc(rec.Right - (rad), rec.Bottom - (rad), rad, rad, 0, 90);
                    gp.AddArc(rec.X, rec.Bottom - (rad), rad, rad, 90, 90);
                    gp.CloseFigure();
                    g.DrawPath(_BorderPen, gp);
                }
            }
            else
            {
                g.DrawRectangle(_BorderPen, rec.X, rec.Y, rec.Width, rec.Height);
            }
        }

        //A private function used for calculating the rectagle area of the Label to draw the Image in
        /// <summary>
        /// Aligns the image.
        /// </summary>
        /// <param name="Rect">The rect.</param>
        /// <returns>Rectangle.</returns>
        private Rectangle AlignImage(Rectangle Rect)
        {
            //Use the value of the ContentAlignment assigned to the ImageAlign property to set the X and Y
            //values of the returned rectangle for the image.
            int xp = 0;
            int yp = 0;
            int ia = Convert.ToInt32(_ImageAlign);
            if (ia < 8)
            {
                yp = 0 + this.Padding.Top;
            }
            else if (ia < 128)
            {
                yp = Convert.ToInt32(Rect.Height / 2) - Convert.ToInt32(_Image.Height / 2);
                ia = ia / 16;
            }
            else
            {
                yp = Rect.Height - _Image.Height - this.Padding.Bottom;
                ia = ia / 256;
            }
            if (ia == Convert.ToInt32(ContentAlignment.TopLeft))
            {
                xp = 0 + this.Padding.Left;
            }
            else if (ia == Convert.ToInt32(ContentAlignment.TopCenter))
            {
                xp = Convert.ToInt32(Rect.Width / 2) - Convert.ToInt32(_Image.Width / 2);
            }
            else if (ia == Convert.ToInt32(ContentAlignment.TopRight))
            {
                xp = Rect.Width - _Image.Width - this.Padding.Right;
            }
            return new Rectangle(xp, yp, _Image.Width, _Image.Height);
        }

        //Need to use the OnTextChanged overrides sub to make the Label repaint itself when the text is changed
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.TextChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnTextChanged(System.EventArgs e)
        {
            SlideOnTextChanged(e);
            this.Refresh();
            base.OnTextChanged(e);
        }

        //Need to use the Dispose Overides sub to make sure all of the New brushes and pens created for the
        //property backing feilds are disposed.
        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control" /> and its child controls and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            //SliderTimer
            SlideDispose();


            this._BackgroundBrush.Dispose();
            this._BorderPen.Dispose();
            this._CenterBrush.Dispose();
            this._OutLinePen.Dispose();
            this._ShadowBrush.Dispose();
            this._ShadowPen.Dispose();
            base.Dispose(disposing);
        }

        #endregion

        #region Include in Private Field

        /// <summary>
        /// The timer
        /// </summary>
        Timer timer = new Timer();
        /// <summary>
        /// The slide
        /// </summary>
        private bool slide = false;
        /// <summary>
        /// The sliding a
        /// </summary>
        int slidingA = 0;
        /// <summary>
        /// The art
        /// </summary>
        bool art = false;
        /// <summary>
        /// The sliding limit
        /// </summary>
        private int slidingLimit = 5;
        /// <summary>
        /// The correct width
        /// </summary>
        private int correctWidth = 75;

        #endregion

        #region Include in Public Properties

        /// <summary>
        /// Gets or sets the width of the correct.
        /// </summary>
        /// <value>The width of the correct.</value>
        public int CorrectWidth
        {
            get { return correctWidth; }
            set
            {
                if(value > 100)
                {
                    value = 100;
                    Invalidate();
                }
                
                if(value < 75)
                {
                    value = 75;
                }
                correctWidth = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the sliding limit.
        /// </summary>
        /// <value>The sliding limit.</value>
        public int SlidingLimit
        {
            get { return slidingLimit; }
            set
            {

                slidingLimit = value;
                this.OnSlidingLimitChanged(EventArgs.Empty);
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitUltraLabel"/> is slide.
        /// </summary>
        /// <value><c>true</c> if slide; otherwise, <c>false</c>.</value>
        public bool Slide
        {
            get { return slide; }
            set
            {
                if(value)
                {
                    this.Width = TextRenderer.MeasureText(Text, Font).Width - SlidingLimit;
                    this.Height = TextRenderer.MeasureText(Text, Font).Height;
                    Invalidate();
                }
                slide = value;
                timer.Enabled = slide;
                if (!slide)
                {
                    slidingA = 0;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the sliding speed.
        /// </summary>
        /// <value>The sliding speed.</value>
        public int SlidingSpeed
        {
            get { return timer.Interval; }
            set
            {
                timer.Interval = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value>The text.</value>
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                timer.Start();
            }
        }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value>The font.</value>
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                timer.Start();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitUltraLabel"/> is art.
        /// </summary>
        /// <value><c>true</c> if art; otherwise, <c>false</c>.</value>
        public bool Art
        {
            get { return art; }
            set
            {
                art = value;

                Invalidate();

            }
        }

        #endregion

        #region Include in Constructor

        /// <summary>
        /// Slides the include in constructor.
        /// </summary>
        private void SlideIncludeInConstructor()
        {
            timer.Interval = 120;
            timer.Tick += Sliding_Timer_Tick;
            slide = false;
            timer.Enabled = false;
        }


        #endregion

        #region Sliding Timer

        /// <summary>
        /// Handles the Tick event of the Sliding_Timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Sliding_Timer_Tick(object sender, EventArgs e)
        {
            Size tSize = TextRenderer.MeasureText(Text, Font);
            if (tSize.Width <= Width)
            {
                timer.Stop();
                slidingA = 1;
                Invalidate();
                return;
            }
            int maxFar = tSize.Width >= Width ? tSize.Width - Width : 0;
            if (slidingA >= 1)
                art = false;
            if (-slidingA >= maxFar + Font.Height)
                art = true;
            slidingA = art ? slidingA + 1 : slidingA - 1;
            Invalidate();
        }


        #endregion

        #region Paint Method

        /// <summary>
        /// Draws the sliding text.
        /// </summary>
        /// <param name="_with1">The with1.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="pth">The PTH.</param>
        /// <param name="sf">The sf.</param>
        private void DrawSlidingText(Graphics _with1, Brush brush, GraphicsPath pth, StringFormat sf)
        {

            Size tSize = TextRenderer.MeasureText(Text, Font);
            int y = Height / 2 - tSize.Height / 2;


            //pth.AddString(this.Text, this.Font.FontFamily, Convert.ToInt32(this.Font.Style), Convert.ToSingle((_with1.DpiY * this.Font.Size) / 72), new Point(slidingA, y),sf);

            pth.AddString(this.Text, this.Font.FontFamily, Convert.ToInt32(this.Font.Style), Convert.ToSingle((_with1.DpiY * this.Font.Size)  / CorrectWidth), new Rectangle(Padding.Left + slidingA + SlidingLimit, Padding.Top, (this.ClientSize.Width - 1) - (this.Padding.Left + this.Padding.Right), (this.ClientSize.Height - 1) - (this.Padding.Top + this.Padding.Bottom)), sf);

            //using (brush)
            //    g.DrawString(Text, Font, brush, slidingA, y);

        }


        #endregion

        #region Overrides


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            if(Slide)
            {
                this.Width = TextRenderer.MeasureText(Text, Font).Width - SlidingLimit;
                this.Height = TextRenderer.MeasureText(Text, Font).Height;
                timer.Enabled = true;
            }
            
            base.OnResize(e);
        }

        /// <summary>
        /// Slides the on text changed.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SlideOnTextChanged(EventArgs e)
        {
            if(Slide)
            {
                this.Width = TextRenderer.MeasureText(Text, Font).Width - SlidingLimit;
                this.Height = TextRenderer.MeasureText(Text, Font).Height;
            }
            
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.FontChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            if(Slide)
            {
                this.Width = TextRenderer.MeasureText(Text, Font).Width - SlidingLimit;
                this.Height = TextRenderer.MeasureText(Text, Font).Height;
            }
            
        }

        /// <summary>
        /// Slides the dispose.
        /// </summary>
        private void SlideDispose()
        {
            timer.Stop();
            
        }





        #region Event Creation

        /////Implement this in the Property you want to trigger the event///////////////////////////
        // 
        //  For Example this will be triggered by the Value Property
        //
        //  public int Value
        //   { 
        //      get { return _value;}
        //      set
        //         {
        //          
        //              _value = value;
        //
        //              this.OnValueChanged(EventArgs.Empty);
        //              Invalidate();
        //          }
        //    }
        //
        ////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// The sliding limit changed
        /// </summary>
        private EventHandler slidingLimitChanged;

        /// <summary>
        /// Triggered when the Value changes
        /// </summary>

        public event EventHandler SlidingLimitChanged
        {
            add
            {
                this.slidingLimitChanged = this.slidingLimitChanged + value;
            }
            remove
            {
                this.slidingLimitChanged = this.slidingLimitChanged - value;
            }
        }

        /// <summary>
        /// Handles the <see cref="E:SlidingLimitChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnSlidingLimitChanged(EventArgs e)
        {
            if (this.slidingLimitChanged == null)
                return;

            this.Width = TextRenderer.MeasureText(Text, Font).Width - SlidingLimit;
            this.Height = TextRenderer.MeasureText(Text, Font).Height;

            this.slidingLimitChanged((object)this, e);
        }

        #endregion




        #endregion

        
        #region Transparency


        #region Include in Paint

        private void TransInPaint(Graphics g)
        {
            if (AllowTransparency)
            {
                MakeTransparent(this, g);
            }
        }

        #endregion

        #region Include in Private Field

        private bool allowTransparency = true;

        #endregion

        #region Include in Public Properties

        public bool AllowTransparency
        {
            get { return allowTransparency; }
            set
            {
                allowTransparency = value;

                Invalidate();
            }
        }

        #endregion

        #region Method

        //-----------------------------Include in Paint--------------------------//
        //
        // if(AllowTransparency)
        //  {
        //    MakeTransparent(this,g);
        //  }
        //
        //-----------------------------Include in Paint--------------------------//

        private static void MakeTransparent(Control control, Graphics g)
        {
            var parent = control.Parent;
            if (parent == null) return;
            var bounds = control.Bounds;
            var siblings = parent.Controls;
            int index = siblings.IndexOf(control);
            Bitmap behind = null;
            for (int i = siblings.Count - 1; i > index; i--)
            {
                var c = siblings[i];
                if (!c.Bounds.IntersectsWith(bounds)) continue;
                if (behind == null)
                    behind = new Bitmap(control.Parent.ClientSize.Width, control.Parent.ClientSize.Height);
                c.DrawToBitmap(behind, c.Bounds);
            }
            if (behind == null) return;
            g.DrawImage(behind, control.ClientRectangle, bounds, GraphicsUnit.Pixel);
            behind.Dispose();
        }

        #endregion


        #endregion




    }
}

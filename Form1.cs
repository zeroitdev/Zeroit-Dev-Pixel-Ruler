// ***********************************************************************
// Assembly         : Zeroit Dev Pixel Ruler
// Author           : ZEROIT
// Created          : 06-24-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 08-02-2019
// ***********************************************************************
// <copyright file="Form1.cs" company="Zeroit Dev Technologies">
//     Copyright © 2019 Zeroit Dev Technologies. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;


namespace Zeroit_Dev_Pixel_Ruler
{
    public partial class Form1 : ResizableBorderlesForm
    {
        const int staticWidth = 80;

        const int staticHeight = 70;

        bool turned = true;

        AngleForm angleForm = new AngleForm();

        string lengthToCopy = String.Empty;

        public Form1()
        {
            InitializeComponent();

            ZeroitRulerKanta();

            int height = 4 + sizeHeight[sizeHeight.Count - 1];
            int width = 4 + sizeWidth[sizeWidth.Count - 1];

            PixelCalculator();

            angleForm.Load += AngleForm_Load;
        }

        private void AngleForm_Load(object sender, EventArgs e)
        {
            angleForm.changeKnob.Value = (float)this.Opacity;

            angleForm.valueLabel.Text = string.Format("{0}%", Convert.ToInt32(Opacity * 100));
        }

        List<int> sizeWidth = new List<int>() {80,80};
        List<int> sizeHeight = new List<int>() { 50, 50 };

        private void Form1_Resize(object sender, EventArgs e)
        {
            sizeWidth.Add(this.Width);
            sizeHeight.Add(this.Height);

            if(Width < 10)
            {
                Width = 10;
                this.Controls.Remove(pixelDisplay);

            }
            else
            {
                this.Controls.Add(pixelDisplay);
            }

            if(Height < 10)
            {
                Height = 10;
                this.Controls.Remove(pixelDisplay);
            }
            else
            {
                this.Controls.Add(pixelDisplay);
            }

            PixelCalculator();

        }

        private int getHeight = 0;
        private int getWidth = 0;

        private void PixelCalculator()
        {
            float screenWidth = Screen.PrimaryScreen.Bounds.Width;
            float screenHeight = Screen.PrimaryScreen.Bounds.Height;
                        
            float height =  sizeHeight[sizeHeight.Count - 1];
            float width  =  sizeWidth[sizeWidth.Count - 1];

            float pixelConvertWidth = (width / screenWidth) * width;
            float pixelConvertHeight = (height / screenHeight) * height;

            getHeight = Convert.ToInt32(pixelConvertHeight);
            getWidth = Convert.ToInt32(pixelConvertWidth);

            Graphics g = CreateGraphics();

            SizeF FS = g.MeasureString(pixelDisplay.Text, pixelDisplay.Font, pixelDisplay.Width).ToSize();

            int fontWidth = (int)FS.Width;
            int fontHeight = (int)FS.Height;

            if (turned)
            {
                this.Height = staticHeight;

            }
            else
            {
                this.Width = staticWidth;
            }

            if (!turned)
            {
                //Height
                //pixelDisplay.Text = string.Format("{0}px", Convert.ToInt32(pixelConvertHeight).ToString());

                pixelDisplay.Location = new Point((this.Width / 2) - (fontWidth / 2), (this.Height / 2));

            }
            else
            {
                //Width
                //pixelDisplay.Text = string.Format("{0}px", Convert.ToInt32(pixelConvertWidth).ToString());

                pixelDisplay.Location = new Point((this.Width / 2) - (fontWidth/2), (this.Height / 2) - (fontHeight/2));

            }
        }

        private void rotate_Click(object sender, EventArgs e)
        {
            turned = !turned;
            
            if(!turned)
            {
                
                this.Height = sizeWidth[sizeWidth.Count - 1];
                this.Width = staticWidth;

                rotate.Image = Zeroit.Framework.PixelRuler.Properties.Resources.rotate_Right_16px;
                toolTip.SetToolTip(rotate, "Rotate Horizontally");
            }
            else
            {
                
                this.Width = sizeHeight[sizeHeight.Count - 1];
                this.Height = staticHeight;

                rotate.Image = Zeroit.Framework.PixelRuler.Properties.Resources.rotate_Left_16px;

                toolTip.SetToolTip(rotate, "Rotate Vertically");
            }

            menuItemFlip_Click(e);
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void CopyCode()
        {

            #region Old Code
            //if(turned)
            //{
            //    Clipboard.SetData(DataFormats.Text, (Object)getWidth.ToString());


            //}
            //else
            //{
            //    Clipboard.SetData(DataFormats.Text, (Object)getHeight.ToString());

            //} 
            #endregion

            if (turned)
            {
                Clipboard.SetData(DataFormats.Text, (Object)lengthToCopy);


            }
            else
            {
                Clipboard.SetData(DataFormats.Text, (Object)lengthToCopy);

            }

        }
                
        private void opacityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(angleForm.ShowDialog() == DialogResult.OK)
            {
                                
                this.Opacity = angleForm.changeKnob.Value;
                this.Invalidate();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyCode();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

                
        Point lastClick;
        

        public void DragForm_MouseDown(object sender, MouseEventArgs e)
        {

            lastClick = new Point(e.X, e.Y); //We'll need this for when the Form starts to move
        }

        public void DragForm_MouseMove(object sender, MouseEventArgs e)
        {

            //Point newLocation = new Point(e.X - lastE.X, e.Y - lastE.Y);
            if (e.Button == MouseButtons.Left) //Only when mouse is clicked
            {
                //Move the Form the same difference the mouse cursor moved;
                this.Left += e.X - lastClick.X;
                this.Top += e.Y - lastClick.Y;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            DoubleBuffered = true;
            this.StartPosition = FormStartPosition.CenterParent;

            Ruler_Load(e);

            base.OnLoad(e);
        }

        private void aboutPixelRuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();

            if(about.ShowDialog() == DialogResult.OK)
            {

            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            Ruler_KeyDown(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            Ruler_MouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            Ruler_MouseUp(e);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Ruler_Paint(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            Ruler_MouseMove(e);
        }

        #region Ruler Kanta


        /// <summary>
        /// The context menu
        /// </summary>
        private System.Windows.Forms.ContextMenu contextMenu;
        /// <summary>
        /// The menu item flip
        /// </summary>
        private System.Windows.Forms.MenuItem menuItemFlip;
        /// <summary>
        /// The menu item separator1
        /// </summary>
        private System.Windows.Forms.MenuItem menuItemSeparator1;
        /// <summary>
        /// The menu item pixel
        /// </summary>
        private System.Windows.Forms.MenuItem menuItemPixel;
        /// <summary>
        /// The menu item inch
        /// </summary>
        private System.Windows.Forms.MenuItem menuItemInch;
        /// <summary>
        /// The menu item centimeter
        /// </summary>
        private System.Windows.Forms.MenuItem menuItemCentimeter;
        /// <summary>
        /// The menu item separator2
        /// </summary>
        private System.Windows.Forms.MenuItem menuItemSeparator2;
        
        /// <summary>
        /// The menu item exit
        /// </summary>
        //private System.Windows.Forms.MenuItem menuItemExit;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitRulerKanta" /> class.
        /// </summary>
        public void ZeroitRulerKanta()
        {
            //
            // Required for Windows Form Designer support
            //
            KantaInitializeComponent();

            this.size = new Size(this.Width, this.Width);
            this.pen = new Pen(Color.White, float.Epsilon);
            this.format = new StringFormat(StringFormat.GenericTypographic);
            this.format.FormatFlags = StringFormatFlags.NoWrap;
            this.format.Trimming = StringTrimming.Character;
        }

        /// <summary>
        /// Handles the Load event of the Ruler control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Ruler_Load(System.EventArgs e)
        {
            this.ContextMenu = this.contextMenu;
            this.Horizontal = true;
        }

        #region Windows Form Designer generated code
        
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void KantaInitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
            this.contextMenu = new System.Windows.Forms.ContextMenu();
            this.menuItemFlip = new System.Windows.Forms.MenuItem();
            this.menuItemSeparator1 = new System.Windows.Forms.MenuItem();
            this.menuItemPixel = new System.Windows.Forms.MenuItem();
            this.menuItemInch = new System.Windows.Forms.MenuItem();
            this.menuItemCentimeter = new System.Windows.Forms.MenuItem();
            this.menuItemSeparator2 = new System.Windows.Forms.MenuItem();
            
            //this.menuItemExit = new System.Windows.Forms.MenuItem();
            // 
            // contextMenu
            // 
            //this.contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.menuItemExit});
            // 
            // menuItemFlip
            // 
            this.menuItemFlip.Index = 0;
            this.menuItemFlip.Text = "Flip ZeroitCodeTextBoxRuler";
            //this.menuItemFlip.Click += new System.EventHandler(this.menuItemFlip_Click);
            // 
            // menuItemSeparator1
            // 
            this.menuItemSeparator1.Index = 1;
            this.menuItemSeparator1.Text = "-";
            // 
            // menuItemPixel
            // 
            this.menuItemPixel.Checked = true;
            this.menuItemPixel.Index = 2;
            this.menuItemPixel.Text = "Pixels";
            this.menuItemPixel.Click += new System.EventHandler(this.menuItemPixel_Click);
            // 
            // menuItemInch
            // 
            this.menuItemInch.Index = 3;
            this.menuItemInch.Text = "Inches";
            this.menuItemInch.Click += new System.EventHandler(this.menuItemInch_Click);
            // 
            // menuItemCentimeter
            // 
            this.menuItemCentimeter.Index = 4;
            this.menuItemCentimeter.Text = "Centimeters";
            this.menuItemCentimeter.Click += new System.EventHandler(this.menuItemCentimeter_Click);
            // 
            // menuItemSeparator2
            // 
            this.menuItemSeparator2.Index = 5;
            this.menuItemSeparator2.Text = "-";
            
            //// 
            //// menuItemExit
            //// 
            //this.menuItemExit.Index = 7;
            //this.menuItemExit.Text = "Exit ZeroitCodeTextBoxRuler";
            //this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            

            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ruler_KeyDown);
            //this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Ruler_MouseDown);
            //this.Load += new System.EventHandler(this.Ruler_Load);
            //this.DoubleClick += new System.EventHandler(this.menuItemFlip_Click);
            //this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Ruler_MouseUp);
            //this.Paint += new System.Windows.Forms.PaintEventHandler(this.Ruler_Paint);
            //this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Ruler_MouseMove);

        }

        #endregion


        //---------------------------------------------------------------------

        /// <summary>
        /// The size
        /// </summary>
        private Size size;

        /// <summary>
        /// Ensures the visible.
        /// </summary>
        private void EnsureVisible()
        {
            Rectangle screen = Screen.FromControl(this).Bounds;
            Rectangle ruler = this.Bounds;
            Rectangle r = Rectangle.Intersect(screen, ruler);
            int w = this.MinimumSize.Width / 2;
            if (r.Width < w)
            {
                this.Location = new Point(
                    Math.Max(screen.X - ruler.Width + w, Math.Min(ruler.X, screen.Right - w)),
                    this.Location.Y
                );
            }
            int h = this.MinimumSize.Height / 2;
            if (r.Height < h)
            {
                this.Location = new Point(
                    this.Location.X,
                    Math.Max(screen.Y - ruler.Height + h, Math.Min(ruler.Y, screen.Bottom - h))
                );
            }
        }

        /// <summary>
        /// The horizontal
        /// </summary>
        private bool horizontal;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitRulerKanta" /> is horizontal.
        /// </summary>
        /// <value><c>true</c> if horizontal; otherwise, <c>false</c>.</value>
        public bool Horizontal
        {
            get { return this.horizontal; }
            set
            {
                this.horizontal = value;
                if (this.horizontal)
                {
                    this.Size = new Size(this.size.Width, this.MinimumSize.Height);
                }
                else
                {
                    this.Size = new Size(this.MinimumSize.Width, this.size.Height);
                }
                this.EnsureVisible();
            }
        }

        //---------------------------------------------------------------------

        /// <summary>
        /// The move point
        /// </summary>
        private Point movePoint;
        /// <summary>
        /// The is moving
        /// </summary>
        private bool isMoving = false;
        /// <summary>
        /// The is left sizing
        /// </summary>
        private bool isLeftSizing = false;
        /// <summary>
        /// The is right sizing
        /// </summary>
        private bool isRightSizing = false;
        /// <summary>
        /// The is top sizing
        /// </summary>
        private bool isTopSizing = false;
        /// <summary>
        /// The is bottom sizing
        /// </summary>
        private bool isBottomSizing = false;

        /// <summary>
        /// Handles the MouseDown event of the Ruler control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void Ruler_MouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Clicks <= 1 && e.Button == MouseButtons.Left)
            {
                if (this.Horizontal)
                {
                    if (e.X <= 3)
                    {
                        this.isLeftSizing = this.Capture = true;
                    }
                    else if (e.X >= this.Width - 3)
                    {
                        this.isRightSizing = this.Capture = true;
                    }
                    else
                    {
                        this.isMoving = this.Capture = true;
                    }
                }
                else
                {
                    if (e.Y <= 3)
                    {
                        this.isTopSizing = this.Capture = true;
                    }
                    else if (e.Y >= this.Height - 3)
                    {
                        this.isBottomSizing = this.Capture = true;
                    }
                    else
                    {
                        this.isMoving = this.Capture = true;
                    }
                }
                this.movePoint = this.PointToScreen(new Point(e.X, e.Y));
            }
        }
        /// <summary>
        /// Handles the MouseUp event of the Ruler control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void Ruler_MouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            if (this.Capture && e.Button == MouseButtons.Left)
            {
                this.isMoving =
                this.isLeftSizing =
                this.isRightSizing =
                this.isTopSizing =
                this.isBottomSizing =
                this.Capture = false;
                this.EnsureVisible();
                this.Invalidate();
            }
        }
        /// <summary>
        /// Handles the MouseMove event of the Ruler control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void Ruler_MouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            if (this.Capture)
            {
                Point p = this.PointToScreen(new Point(e.X, e.Y));
                Rectangle ruler = this.Bounds;
                Size min = this.MinimumSize;
                if (this.isMoving)
                {
                    this.Location = new Point(
                        ruler.X + p.X - this.movePoint.X,
                        ruler.Y + p.Y - this.movePoint.Y
                    );
                }
                else if (this.isLeftSizing)
                {
                    this.Bounds = new Rectangle(
                        ruler.X + p.X - this.movePoint.X,
                        ruler.Y,
                        ruler.Width - p.X + this.movePoint.X,
                        min.Height
                    );
                    this.size.Width = this.Width;
                }
                else if (this.isRightSizing)
                {
                    this.Size = new Size(ruler.Width + p.X - this.movePoint.X, ruler.Height);
                    this.size.Width = this.Width;
                }
                else if (this.isTopSizing)
                {
                    this.Bounds = new Rectangle(
                        ruler.X,
                        ruler.Y + p.Y - this.movePoint.Y,
                        min.Width,
                        ruler.Height - p.Y + this.movePoint.Y
                    );
                    this.size.Height = this.Height;
                }
                else if (this.isBottomSizing)
                {
                    this.Size = new Size(min.Width, ruler.Height + p.Y - this.movePoint.Y);
                    this.size.Height = this.Height;
                }
                this.movePoint = p;
                //this.Invalidate();
            }
            else
            {
                if (this.Horizontal)
                {
                    if (e.X <= 3 || e.X >= this.Width - 3)
                    {
                        this.Cursor = Cursors.SizeWE;
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
                else
                {
                    if (e.Y <= 3 || e.Y >= this.Height - 3)
                    {
                        this.Cursor = Cursors.SizeNS;
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the Ruler control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void Ruler_KeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            int step = e.Shift ? 10 : 1;
            if (e.KeyCode == Keys.Left)
            {
                if (e.Control && this.Horizontal)
                {
                    this.Width -= step;
                    this.size.Width = this.Width;
                }
                else
                {
                    this.Location = new Point(this.Location.X - step, this.Location.Y);
                }
                this.EnsureVisible();
                this.Invalidate();
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (e.Control && this.Horizontal)
                {
                    this.Width += step;
                    this.size.Width = this.Width;
                }
                else
                {
                    this.Location = new Point(this.Location.X + step, this.Location.Y);
                }
                this.EnsureVisible();
                this.Invalidate();
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (e.Control && !this.Horizontal)
                {
                    this.Height -= step;
                    this.size.Height = this.Height;
                }
                else
                {
                    this.Location = new Point(this.Location.X, this.Location.Y - step);
                }
                this.EnsureVisible();
                this.Invalidate();
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (e.Control && !this.Horizontal)
                {
                    this.Height += step;
                    this.size.Height = this.Height;
                }
                else
                {
                    this.Location = new Point(this.Location.X, this.Location.Y + step);
                }
                this.EnsureVisible();
                this.Invalidate();
            }
        }

        //---------------------------------------------------------------------

        /// <summary>
        /// Handles the Click event of the menuItemFlip control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void menuItemFlip_Click(System.EventArgs e)
        {
            this.Horizontal = !this.Horizontal;
            this.Invalidate();
        }
        /// <summary>
        /// Handles the Click event of the menuItemPixel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void menuItemPixel_Click(object sender, System.EventArgs e)
        {
            this.menuItemPixel.Checked = true;
            this.menuItemInch.Checked = false;
            this.menuItemCentimeter.Checked = false;
            this.Invalidate();
        }
        /// <summary>
        /// Handles the Click event of the menuItemInch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void menuItemInch_Click(object sender, System.EventArgs e)
        {
            this.menuItemPixel.Checked = false;
            this.menuItemInch.Checked = true;
            this.menuItemCentimeter.Checked = false;
            this.Invalidate();
        }
        /// <summary>
        /// Handles the Click event of the menuItemCentimeter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void menuItemCentimeter_Click(object sender, System.EventArgs e)
        {
            this.menuItemPixel.Checked = false;
            this.menuItemInch.Checked = false;
            this.menuItemCentimeter.Checked = true;
            this.Invalidate();
        }
        
        /// <summary>
        /// Handles the Click event of the menuItemExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void menuItemExit_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }

        //---------------------------------------------------------------------

        /// <summary>
        /// The pen
        /// </summary>
        private Pen pen;
        /// <summary>
        /// The format
        /// </summary>
        private StringFormat format;
        /// <summary>
        /// Handles the Paint event of the Ruler control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void Ruler_Paint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int scale;
            int step;
            int small;
            int big;
            int number;
            string unit;
            if (this.menuItemPixel.Checked)
            {
                step = 5;
                small = 10;
                big = 50;
                number = 100;
                scale = 1;
                unit = " Pixels";
            }
            else if (this.menuItemInch.Checked)
            {
                g.PageUnit = GraphicsUnit.Inch;
                g.PageScale = 1f / 12f;
                step = 1;
                small = 2;
                big = 6;
                number = 12;
                scale = 12;
                unit = "\"";
            }
            else
            { //Cm.
                g.PageUnit = GraphicsUnit.Millimeter;
                g.PageScale = 1f;
                step = 1;
                small = 5;
                big = 10;
                number = 10;
                scale = 10;
                unit = " Cm.";
            }
            PointF[] point = new PointF[] {
                new PointF(2, 2), new PointF(5, 5), new Point(this.Size), this.Location
            };
            g.TransformPoints(CoordinateSpace.World, CoordinateSpace.Device, point);
            float infoDelta = this.Horizontal ? point[0].Y : point[0].X;
            float stroke = this.Horizontal ? point[1].Y : point[1].X;
            int length = (int)(point[2].X + point[2].Y);

            if (!this.Horizontal)
            {
                g.RotateTransform(90, MatrixOrder.Prepend);
                g.TranslateTransform(point[2].X, 0, MatrixOrder.Append);
            }

            for (int i = 0; i < length; i += step)
            {
                float d = 1;
                if (i % small == 0)
                {
                    if (i % big == 0)
                    {
                        d = 3;
                    }
                    else
                    {
                        d = 2;
                    }
                }
                g.DrawLine(this.pen, i + 1, 0f, i+1, d * stroke);
                if ((i % number) == 0)
                {
                    string text = (i / scale).ToString(CultureInfo.InvariantCulture);
                    SizeF size = g.MeasureString(text, this.Font, length, this.format);
                    g.DrawString(text, this.Font, new SolidBrush(ForeColor), (i - size.Width / 2) + 1, d * stroke, this.format);
                }
            }

            string info = string.Format(CultureInfo.InvariantCulture,
                "X={0} Y={1} Length={2}{3}",
                Math.Round(point[3].X / scale, 1),
                Math.Round(point[3].Y / scale, 1),
                Math.Round((float)(this.Horizontal ? point[2].X : point[2].Y) / scale, 1),
                unit
            );

            
            SizeF infoSize = g.MeasureString(info, this.Font, length, this.format);
            float y = (float)(this.Horizontal ? point[2].Y : point[2].X);
            g.DrawString(info, this.Font, new SolidBrush(ForeColor),
                (y - infoSize.Height) / 2, y - infoSize.Height - infoDelta, this.format
            );


            string middleInfo = string.Format(CultureInfo.InvariantCulture,
                "{0}",                
                Math.Round((float)(this.Horizontal ? point[2].X : point[2].Y) / scale, 1)                
            );

            lengthToCopy = middleInfo;

            SizeF middleInfoSize = g.MeasureString(middleInfo, this.Font, length, this.format);
            float middleInfoY = (float)(this.Horizontal ? point[2].Y : point[2].X);

            Font font = new Font("Comic Sans MS", 15);
            if(Horizontal)
            {
                g.DrawString(middleInfo, font, new SolidBrush(Color.Cyan),
                (this.Horizontal ? (Width / 2) - (middleInfoSize.Width / 2) : 0), middleInfoY - middleInfoSize.Height - infoDelta - (this.Horizontal ? (Height / 2) - middleInfoSize.Height / 2 : (Height / 2) - (middleInfoSize.Height / 2)), this.format
            );
            }
            else
            {
                
                g.DrawString(middleInfo, font, new SolidBrush(Color.Cyan),
                (Height/2) - (middleInfoSize.Width/2), middleInfoY - middleInfoSize.Height - infoDelta - ((Width / 2) - middleInfoSize.Height / 2), this.format
            );
            }
            


        }

        

        #endregion

    }
}

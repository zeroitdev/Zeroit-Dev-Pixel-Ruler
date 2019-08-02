namespace Zeroit_Dev_Pixel_Ruler
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rotate = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutPixelRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dragForm = new Zeroit_Dev_Pixel_Ruler.ZeroitFormHandle();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pixelDisplay = new Zeroit_Dev_Pixel_Ruler.ZeroitUltraLabel();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rotate
            // 
            this.rotate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rotate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.rotate.ContextMenuStrip = this.contextMenuStrip1;
            this.rotate.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.rotate.FlatAppearance.BorderSize = 0;
            this.rotate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rotate.ForeColor = System.Drawing.Color.White;
            this.rotate.Image = global::Zeroit.Framework.PixelRuler.Properties.Resources.rotate_Right_16px;
            this.rotate.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rotate.Location = new System.Drawing.Point(79, 45);
            this.rotate.Name = "rotate";
            this.rotate.Size = new System.Drawing.Size(18, 23);
            this.rotate.TabIndex = 0;
            this.toolTip.SetToolTip(this.rotate, "Rotate Vertically");
            this.rotate.UseVisualStyleBackColor = false;
            this.rotate.Click += new System.EventHandler(this.rotate_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.contextMenuStrip1.Font = new System.Drawing.Font("Verdana", 9F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.opacityToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.aboutPixelRuleToolStripMenuItem});
            this.contextMenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(156, 92);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // opacityToolStripMenuItem
            // 
            this.opacityToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.opacityToolStripMenuItem.Name = "opacityToolStripMenuItem";
            this.opacityToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.opacityToolStripMenuItem.Text = "Opacity";
            this.opacityToolStripMenuItem.Click += new System.EventHandler(this.opacityToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutPixelRuleToolStripMenuItem
            // 
            this.aboutPixelRuleToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.aboutPixelRuleToolStripMenuItem.Name = "aboutPixelRuleToolStripMenuItem";
            this.aboutPixelRuleToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.aboutPixelRuleToolStripMenuItem.Text = "About Pixel Ruler";
            this.aboutPixelRuleToolStripMenuItem.Click += new System.EventHandler(this.aboutPixelRuleToolStripMenuItem_Click);
            // 
            // dragForm
            // 
            this.dragForm.DockAtTop = true;
            this.dragForm.HandleControl = this;
            // 
            // pixelDisplay
            // 
            this.pixelDisplay.AllowTransparency = false;
            this.pixelDisplay.Art = true;
            this.pixelDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pixelDisplay.CorrectWidth = 75;
            this.pixelDisplay.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Bold);
            this.pixelDisplay.Image = null;
            this.pixelDisplay.Location = new System.Drawing.Point(4, 15);
            this.pixelDisplay.Name = "pixelDisplay";
            this.pixelDisplay.ShowTextShadow = true;
            this.pixelDisplay.Size = new System.Drawing.Size(93, 33);
            this.pixelDisplay.Slide = false;
            this.pixelDisplay.SlidingLimit = 5;
            this.pixelDisplay.SlidingSpeed = 120;
            this.pixelDisplay.Smoothing = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.pixelDisplay.TabIndex = 2;
            this.pixelDisplay.Text = "0px";
            this.pixelDisplay.TextPatternImage = null;
            this.pixelDisplay.TextRendering = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.pixelDisplay.Visible = false;
            this.pixelDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragForm_MouseDown);
            this.pixelDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DragForm_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(100, 70);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.pixelDisplay);
            this.Controls.Add(this.rotate);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Name = "Form1";
            this.Opacity = 0.5D;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DoubleClick += new System.EventHandler(this.Form1_DoubleClick);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button rotate;
        private ZeroitFormHandle dragForm;
        private System.Windows.Forms.ToolTip toolTip;
        private ZeroitUltraLabel pixelDisplay;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opacityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutPixelRuleToolStripMenuItem;
    }
}


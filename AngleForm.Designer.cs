// ***********************************************************************
// Assembly         : Zeroit Dev Pixel Ruler
// Author           : ZEROIT
// Created          : 06-24-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 06-24-2019
// ***********************************************************************
// <copyright file="AngleForm.Designer.cs" company="Zeroit Dev Technologies">
//     Copyright © 2019 Zeroit Dev Technologies. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace Zeroit_Dev_Pixel_Ruler
{
    partial class AngleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AngleForm));
            this.changeKnob = new Zeroit_Dev_Pixel_Ruler.ZeroitLBKnob();
            this.label1 = new System.Windows.Forms.Label();
            this.valueLabel = new Zeroit_Dev_Pixel_Ruler.ZeroitUltraLabel();
            this.closeBtn = new System.Windows.Forms.Button();
            this.dragForm = new Zeroit_Dev_Pixel_Ruler.ZeroitFormHandle();
            this.SuspendLayout();
            // 
            // changeKnob
            // 
            this.changeKnob.BackColor = System.Drawing.Color.Transparent;
            this.changeKnob.DrawRatio = 0.55F;
            this.changeKnob.IndicatorColor = System.Drawing.Color.Gray;
            this.changeKnob.IndicatorOffset = 20F;
            this.changeKnob.KnobCenter = ((System.Drawing.PointF)(resources.GetObject("changeKnob.KnobCenter")));
            this.changeKnob.KnobColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.changeKnob.KnobRect = ((System.Drawing.RectangleF)(resources.GetObject("changeKnob.KnobRect")));
            this.changeKnob.Location = new System.Drawing.Point(3, 38);
            this.changeKnob.MaxValue = 1F;
            this.changeKnob.MinValue = 0F;
            this.changeKnob.Name = "changeKnob";
            this.changeKnob.Renderer = null;
            this.changeKnob.ScaleColor = System.Drawing.Color.Gray;
            this.changeKnob.Size = new System.Drawing.Size(110, 120);
            this.changeKnob.StepValue = 0.01F;
            this.changeKnob.Style = Zeroit_Dev_Pixel_Ruler.ZeroitLBKnob.KnobStyle.Circular;
            this.changeKnob.TabIndex = 0;
            this.changeKnob.Value = 0.5F;
            this.changeKnob.KnobChangeValue += new Zeroit_Dev_Pixel_Ruler.KnobChangeValue(this.changeKnob_KnobChangeValue);
            this.changeKnob.MouseDown += new System.Windows.Forms.MouseEventHandler(this.changeKnob_MouseDown);
            this.changeKnob.MouseUp += new System.Windows.Forms.MouseEventHandler(this.changeKnob_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(95, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Opacity";
            // 
            // valueLabel
            // 
            this.valueLabel.AllowTransparency = true;
            this.valueLabel.Art = false;
            this.valueLabel.CorrectWidth = 75;
            this.valueLabel.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Bold);
            this.valueLabel.Image = null;
            this.valueLabel.Location = new System.Drawing.Point(128, 68);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.ShowTextShadow = true;
            this.valueLabel.Size = new System.Drawing.Size(85, 50);
            this.valueLabel.Slide = false;
            this.valueLabel.SlidingLimit = 5;
            this.valueLabel.SlidingSpeed = 120;
            this.valueLabel.Smoothing = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.valueLabel.TabIndex = 2;
            this.valueLabel.Text = "100%";
            this.valueLabel.TextPatternImage = null;
            this.valueLabel.TextRendering = System.Drawing.Text.TextRenderingHint.AntiAlias;
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Red;
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("Verdana", 8F);
            this.closeBtn.ForeColor = System.Drawing.Color.White;
            this.closeBtn.Location = new System.Drawing.Point(219, 6);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(18, 19);
            this.closeBtn.TabIndex = 28;
            this.closeBtn.Text = "x";
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closeBtn.UseCompatibleTextRendering = true;
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // dragForm
            // 
            this.dragForm.DockAtTop = true;
            this.dragForm.HandleControl = this;
            // 
            // AngleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(246, 174);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.valueLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.changeKnob);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AngleForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "AngleForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeBtn;
        public ZeroitLBKnob changeKnob;
        private ZeroitFormHandle dragForm;
        public ZeroitUltraLabel valueLabel;
    }
}
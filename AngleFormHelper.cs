// ***********************************************************************
// Assembly         : Zeroit Dev Pixel Ruler
// Author           : ZEROIT
// Created          : 06-24-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 08-02-2019
// ***********************************************************************
// <copyright file="AngleFormHelper.cs" company="Zeroit Dev Technologies">
//     Copyright © 2019 Zeroit Dev Technologies. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit_Dev_Pixel_Ruler
{
    public class AngleFormHelper :Form
    {

        public AngleFormHelper()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            g.DrawRectangle(new Pen(Color.Cyan, 1), new Rectangle(0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1));

            base.OnPaint(e);
        }
    }
}

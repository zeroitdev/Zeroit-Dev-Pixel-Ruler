// ***********************************************************************
// Assembly         : Zeroit Dev Pixel Ruler
// Author           : ZEROIT
// Created          : 06-24-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 06-25-2019
// ***********************************************************************
// <copyright file="AngleForm.cs" company="Zeroit Dev Technologies">
//     Copyright © 2019 Zeroit Dev Technologies. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit_Dev_Pixel_Ruler
{
    public partial class AngleForm : AngleFormHelper
    {

        private int percent = 0;

        
        public AngleForm()
        {
            InitializeComponent();
            
        }

        private void changeKnob_KnobChangeValue(object sender, ZeroitLBKnobEventArgs e)
        {


            float percent = Convert.ToInt32(changeKnob.Value * (1 / changeKnob.MaxValue) * 100);

            
            valueLabel.Text = string.Format("{0}%",Convert.ToInt32(percent));
        }

        private void changeKnob_MouseDown(object sender, MouseEventArgs e)
        {
            changeKnob.ScaleColor = Color.Cyan;
        }

        private void changeKnob_MouseUp(object sender, MouseEventArgs e)
        {
            changeKnob.ScaleColor = Color.Gray;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}

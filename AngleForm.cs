using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

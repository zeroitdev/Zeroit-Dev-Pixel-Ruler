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
    public partial class About : AngleFormHelper
    {

        private int percent = 0;

        
        public About()
        {
            InitializeComponent();
            
        }
        

        private void closeBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
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

            base.OnLoad(e);
        }
    }
}

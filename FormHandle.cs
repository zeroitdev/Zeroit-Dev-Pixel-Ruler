// ***********************************************************************
// Assembly         : Zeroit.Framework.Component
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="FormHandle.cs" company="Zeroit Dev Technologies">
//    This program is program that contains helping components.
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
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Zeroit_Dev_Pixel_Ruler
{
    /// <summary>
    /// Class ZeroitFormHandle.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component" />
    public class ZeroitFormHandle : Component
	{
        /// <summary>
        /// The handle control
        /// </summary>
        private Control handleControl;

        /// <summary>
        /// The dock at top
        /// </summary>
        private bool dockAtTop = true;

        /// <summary>
        /// The wm nclbuttondown
        /// </summary>
        public const int WM_NCLBUTTONDOWN = 161;

        /// <summary>
        /// The ht caption
        /// </summary>
        public const int HT_CAPTION = 2;

        /// <summary>
        /// Gets or sets a value indicating whether [dock at top].
        /// </summary>
        /// <value><c>true</c> if [dock at top]; otherwise, <c>false</c>.</value>
        [Browsable(true)]
		[Category("Zeroit.Framework.DaggerControls")]
		[Description("Maximize when dragged to top")]
		public bool DockAtTop
		{
			get
			{
				return this.dockAtTop;
			}
			set
			{
				this.dockAtTop = value;
			}
		}

        /// <summary>
        /// Gets or sets the handle control.
        /// </summary>
        /// <value>The handle control.</value>
        [Browsable(true)]
		[Category("Zeroit.Framework.DaggerControls")]
		[Description("The handleControl")]
		public Control HandleControl
		{
			get
			{
				return this.handleControl;
			}
			set
			{
				this.handleControl = value;
				this.handleControl.MouseDown += new MouseEventHandler(this.DragForm_MouseDown);
			}
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitFormHandle"/> class.
        /// </summary>
        public ZeroitFormHandle()
		{
		}

        /// <summary>
        /// Handles the MouseDown event of the DragForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void DragForm_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ZeroitFormHandle.ReleaseCapture();
				ZeroitFormHandle.SendMessage(this.HandleControl.FindForm().Handle, 161, 2, 0);
				if (this.dockAtTop)
				{
					if (this.handleControl.FindForm().FormBorderStyle == FormBorderStyle.None)
					{
						if ((this.HandleControl.FindForm().WindowState == FormWindowState.Maximized ? true : Cursor.Position.Y > 3))
						{
							this.HandleControl.FindForm().WindowState = FormWindowState.Normal;
						}
						else
						{
							this.HandleControl.FindForm().WindowState = FormWindowState.Maximized;
						}
					}
				}
			}
		}

        /// <summary>
        /// Releases the capture.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		public static extern bool ReleaseCapture();

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="Msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
	}
}
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CustomWinForms
{
    // Got this from a stackoverflow post and modified it.
    // Making a ListBox scroll down is very messy and performance consuming if not messy.
    //
    // Post: https://stackoverflow.com/questions/2196097/elegant-log-window-in-winforms-c-sharp/55540909#55540909
    // Answer: https://stackoverflow.com/a/55540909
    // Author: JYelton
    // Date: Apr 5, 2019 at 17:51

    public class ScrollingListBox : ListBox
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(
            IntPtr hWnd,
            uint Msg,
            IntPtr wParam,
            IntPtr LParam);

        private const int _WM_VSCROLL = 277;
        private const int _SB_BOTTOM = 7;

        /// <summary>
        /// Scrolls to the bottom of the <see cref="ScrollingListBox"/>.
        /// </summary>
        public void ScrollToBottom()
        {
            SendMessage(Handle, _WM_VSCROLL, new IntPtr(_SB_BOTTOM), new IntPtr(0));
        }
    }
}

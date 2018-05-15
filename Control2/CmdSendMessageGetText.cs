using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace control2
{
    class CmdSendMessageGetText : Win32API, ICmd
    {
        private IntPtr ParentHWND;
        private IntPtr HWND;

        public void setParameter(params string[] param)
        {
            if (param.Length != 2) return;
            ParentHWND = new IntPtr(Convert.ToInt32(param[0]));
            HWND = new IntPtr(Convert.ToInt32(param[1]));
        }

        public void execute()
        {
            SetForegroundWindow(ParentHWND);
            StringBuilder sb = new StringBuilder(256);
            SendMessage(HWND, WM_GETTEXT, new IntPtr(255), sb);
            Console.WriteLine(sb.ToString());
        }
    }
}
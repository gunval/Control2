using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace control2
{
    class CmdSendMessageText : Win32API, ICmd
    {
        private IntPtr ParentHWND;
        private IntPtr HWND;
        private string message;

        public void setParameter(params string[] param)
        {
            if (param.Length != 3) return;
            ParentHWND = new IntPtr(Convert.ToInt32(param[0]));
            HWND = new IntPtr(Convert.ToInt32(param[1]));
            message = param[2];
        }

        public void execute()
        {
            SetForegroundWindow(ParentHWND);
            IntPtr text = Marshal.StringToCoTaskMemUni(message);
            SendMessage(HWND, WM_SETTEXT, IntPtr.Zero, text);
            Marshal.FreeCoTaskMem(text);
        }
    }
}
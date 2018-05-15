using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace control2
{
    class CmdSendMessageGetIEDoument : Win32API, ICmd
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
            if (WM_HTML_GETOBJECT == 0x0)
            {
                WM_HTML_GETOBJECT = RegisterWindowMessage("WM_HTML_GETOBJECT");
            }
            SetForegroundWindow(ParentHWND);
            UIntPtr Result = UIntPtr.Zero;
            SendMessageTimeout(HWND, WM_HTML_GETOBJECT, IntPtr.Zero, IntPtr.Zero, SendMessageTimeoutFlags.SMTO_ABORTIFHUNG, 1000, out Result);
            if (Result != UIntPtr.Zero)
            {
                var dom = ObjectFromLresult(Result, typeof(MSHTML.IHTMLDocument2).GUID, IntPtr.Zero) as MSHTML.IHTMLDocument2;
                Console.WriteLine(dom.title);
                Console.WriteLine(dom.url);
                var dom7 = dom as MSHTML.IHTMLDocument7;
                
                Console.WriteLine(dom7.body.innerHTML);

                Console.ReadLine();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace control2
{
    class CmdSearchWord : Win32API, ICmd
    {
        private IntPtr HWND;

        public void setParameter(params string[] param)
        {
            if (param.Length != 1) return;
            HWND = new IntPtr(Convert.ToInt32(param[0]));
        }

        public void execute()
        {
            Table t = new Table();
            List<string> list = new List<string>();
            t.header("hWnd", "WindowText", "ClassName");
            if (HWND == IntPtr.Zero) return;
            EnumChildWindows(HWND, new WNDENUMPROC(delegate(IntPtr hWnd, int lParam)
            {
                StringBuilder Text = new StringBuilder(256);
                StringBuilder Class = new StringBuilder(256);
                //if (IsWindowVisible(hWnd) != 0 && GetWindowText(hWnd, sb, sb.Capacity) != 0)
                if (IsWindowVisible(hWnd) != 0)
                {
                    GetWindowText(hWnd, Text, Text.Capacity);
                    GetClassName(hWnd, Class, Class.Capacity);
                    t.Add(hWnd.ToString());
                    t.Add(Text.ToString());
                    t.Add(Class.ToString());
                }
                return 1;
            }), 0);

            t.export();
        }
    }
}
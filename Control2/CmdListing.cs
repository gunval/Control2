using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace control2
{
    class CmdListing : Win32API, ICmd
    {
        public void setParameter(params string[] param)
        {
        }

        public void execute()
        {
            Table t = new Table();
            List<string> list = new List<string>();
            t.header("MainWindowsHandle", "MainWindowsTitle", "WindowTitle", "ProcessName", "HWND", "PID");
            EnumWindows(new EnumWindowsDelegate(delegate(IntPtr hWnd, int lParam)
            {
                StringBuilder sb = new StringBuilder(256);
                if (IsWindowVisible(hWnd) != 0 && GetWindowText(hWnd, sb, sb.Capacity) != 0)
                {
                    //関連ウインドウは同じプロセスIDでウインドウハンドル飲み異なる。
                    //親子関係はどうやってわかるのかな？
                    string title = sb.ToString();
                    int pid;
                    GetWindowThreadProcessId(hWnd, out pid);
                    Process p1 = Process.GetProcessById(pid);
                    //MainWindowsHandleでわかるか。
                    t.Add(p1.MainWindowHandle.ToString());
                    t.Add(p1.MainWindowTitle);
                    t.Add(title);
                    t.Add(p1.ProcessName);
                    t.Add(hWnd.ToString());
                    t.Add(pid.ToString());
                }
                return 1;
            }), 0);
            t.export();
        }
    }
}
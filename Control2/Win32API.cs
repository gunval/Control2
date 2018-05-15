using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace control2
{
    class Win32API
    {
        public delegate int EnumWindowsDelegate(IntPtr hWnd, int lParam);
        public delegate int WNDENUMPROC(IntPtr hwnd, int lParam);

        public const int EM_SETPASSWORDCHAR = 0xCC;
        public const UInt32 WM_GETTEXT = 0x000D;
        public const UInt32 WM_SETTEXT = 0x000C;
        public const UInt32 BM_CLICK = 0x00F5;
        public static UInt32 WM_HTML_GETOBJECT = 0x0;

        [Flags]
        public enum SendMessageTimeoutFlags : uint
        {
            SMTO_NORMAL = 0x0000,
            SMTO_BLOCK = 0x0001,
            SMTO_ABORTIFHUNG = 0x0002,
            SMTO_NOTIMEOUTIFNOTHUNG = 0x0008,
            SMTO_ERRORONEXIT = 0x0020
        }

        [DllImport("user32.dll")]
        public static extern int EnumChildWindows(IntPtr hWndParent, WNDENUMPROC lpEnumFunc, int lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int EnumWindows(EnumWindowsDelegate lpEnumFunc, int lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int IsWindowVisible(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, out IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, StringBuilder lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern UInt32 RegisterWindowMessage(string lpString);
        [DllImport("oleacc.dll", PreserveSig = false)]
        [return: MarshalAs(UnmanagedType.Interface)]
        public static extern object ObjectFromLresult(UIntPtr lResult, [MarshalAs(UnmanagedType.LPStruct)] Guid refiid, IntPtr wParam);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessageTimeout(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam, SendMessageTimeoutFlags flags, UInt32 timeout, out UIntPtr result);
    }
}
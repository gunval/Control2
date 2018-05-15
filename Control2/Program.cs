using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace control2
{
    class Program : Win32API
    {
        /*
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr FindWindowEx(IntPtr pWnd, IntPtr cWnd, string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        static extern int GlobalAddAtom(string lpMessage);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        
        const int EM_SETPASSWORDCHAR = 0xCC;

        delegate int WNDENUMPROC(IntPtr hwnd, int lParam);

        [DllImport("user32.dll")]
        private static extern int EnumChildWindows(IntPtr hWndParent, WNDENUMPROC lpEnumFunc, int lParam);

        [DllImport("user32.dll")]
        static extern int PostMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        */

        private static ICmd command = null;

        static void Main(string[] args)
        {
            if (!argumentsAnlyzer(args))
            {
                Console.WriteLine("argument error!");
                return;
            }

            /* * http://www.youtube.com/watch?v=ibmU7xfgcMk
            ダイアログ上のボタンのウィンドウハンドル（HWND）を取得し、そのHWNDに対して
            ボタンクリックのメッセージを送信すればよい。

            (1) ダイアログのHWNDを取得する。
            (2) ボタン上のテキスト等からボタンのHWNDを取得する。
            (3) ボタンのHWNDからIDを取得する。
            (4) ボタンをクリックするメッセージを送信する。
             * */

            command.execute();

        }
        /// <summary>
        /// 初期化処理
        /// </summary>
        private static void init()
        {

        }
        /// <summary>
        /// 引数チェック
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static bool argumentsAnlyzer(string[] args)
        {
            bool ret = false;
            ICmdFactory factory = ICmdFactory.getInstance();

            //-w 検索
            //引数：ウインドウタイトル(部分一致)
            //検索結果のプロセスIDハンドルID
            if (args.Length == 2 && args[0] == "-w")
            {
                command = factory.create(args[0]);
                command.setParameter(args[1]);
                ret = true;
            }

            //-l リスト
            //ウインドウ情報一覧の表示
            if (args.Length == 1 && args[0] == "-l")
            {
                command = factory.create(args[0]);
                command.setParameter();
                ret = true;
            }

            //-m メッセージ出力1
            //引数：親ウインドウのハンドル、コントロールハンドル
            if (args.Length == 3 && args[0] == "-m")
            {
                command = factory.create(args[0]);
                command.setParameter(args[1], args[2]);
                ret = true;
            }

            //-s メッセージ出力2
            //引数：親ウインドウのハンドル、コントロールハンドル
            if (args.Length == 4 && args[0] == "-s")
            {
                command = factory.create(args[0]);
                command.setParameter(args[1], args[2], args[3]);
                ret = true;
            }

            //-g メッセージ出力3
            //引数：親ウインドウのハンドル、コントロールハンドル
            if (args.Length == 3 && args[0] == "-g")
            {
                command = factory.create(args[0]);
                command.setParameter(args[1], args[2]);
                ret = true;
            }

            //-ie メッセージ出力2
            //引数：親ウインドウのハンドル、コントロールハンドル
            if (args.Length == 3 && args[0] == "-ie")
            {
                command = factory.create(args[0]);
                command.setParameter(args[1], args[2]);
                ret = true;
            }

            return ret;
        }
    }
}


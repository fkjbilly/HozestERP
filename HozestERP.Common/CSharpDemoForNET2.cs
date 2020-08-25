using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace HozestERP.Common
{
    public class CSharpDemoForNET2
    {

        [DllImport("kernel32.dll", EntryPoint = "LoadLibrary", SetLastError = true)]
        public static extern IntPtr LoadLibrary(
           [MarshalAs(UnmanagedType.LPStr)] string lpLibFileName);

        [DllImport("kernel32.dll", EntryPoint = "GetProcAddress", SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule,
                   [MarshalAs(UnmanagedType.LPStr)] string lpProcName);

        [DllImport("kernel32.dll", EntryPoint = "FreeLibrary")]
        public static extern bool FreeLibrary(IntPtr hModule);


        public delegate int InitPrinterManager();
        public delegate void _onMessage_func(IntPtr str);
        public delegate void SetRecvDataCallback(_onMessage_func callback);
        public delegate int SendMessage(char[] str);
        public delegate int ClosePrinterManager();

        static void onMessage(IntPtr str)
        {
            string message = Marshal.PtrToStringAnsi(str);
            Console.Write(message);
        }
        static void Main(string[] args)
        {
            //用于接口返回
            int Res = -1;
            //以下动态载入dll库
            IntPtr hLib = LoadLibrary("PrinterManager.dll");
            if (hLib == IntPtr.Zero)
            {
                Console.WriteLine("loadlibrary failed! ErrorNuber:" + Marshal.GetLastWin32Error().ToString());
                System.Threading.Thread.Sleep(2000);
                System.Environment.Exit(-1);
            }
            //以下载入初始化函数initPrinterManager
            IntPtr hapi = GetProcAddress(hLib, "initPrinterManager");
            if (hapi == IntPtr.Zero)
            {
                Console.WriteLine("load initPrinterManager failed! ErrorNuber:" + Marshal.GetLastWin32Error().ToString());
                System.Threading.Thread.Sleep(2000);
                System.Environment.Exit(-1);
            }
            //将初始化函数指针封装成委托，并调用
            InitPrinterManager initPrinterManager =
                (InitPrinterManager)Marshal.GetDelegateForFunctionPointer(hapi, typeof(InitPrinterManager));
            Res = initPrinterManager();
            if (Res != 0)
            {
                Console.WriteLine("run initPrinterManager failed! \n");
                System.Threading.Thread.Sleep(2000);
                System.Environment.Exit(-1);
            }

            //以下载入设定回调函数的函数，并调用
            IntPtr hapi2 = GetProcAddress(hLib, "setRecvDataCallback");
            if (hapi2 == IntPtr.Zero)
            {
                Console.WriteLine("load setRecvDataCallback failed! ErrorNuber:" + Marshal.GetLastWin32Error().ToString());
            }
            SetRecvDataCallback setRecvDataCallback =
                (SetRecvDataCallback)Marshal.GetDelegateForFunctionPointer(hapi2, typeof(SetRecvDataCallback));
            setRecvDataCallback(onMessage);

            //以下载入发送数据函数，并发送数据
            string str = "{\"cmd\":\"getPrinters\",\"requestID\":\"123458976\",\"version\":\"1.0\"}";
            IntPtr hapi3 = GetProcAddress(hLib, "sendMessage");
            if (hapi3 == IntPtr.Zero)
            {
                Console.WriteLine("load sendMessage failed! ErrorNuber:" + Marshal.GetLastWin32Error().ToString());
            }
            SendMessage sendMessage =
                (SendMessage)Marshal.GetDelegateForFunctionPointer(hapi3, typeof(SendMessage));
            Res = sendMessage(str.ToCharArray());
            if (Res != 0)
            {
                Console.WriteLine("sendMessage failed! \n");
                System.Threading.Thread.Sleep(2000);
                System.Environment.Exit(-1);
            }

            System.Threading.Thread.Sleep(1000);
            //以下载入关闭连接函数，并调用
            IntPtr hapi4 = GetProcAddress(hLib, "closePrinterManager");
            if (hapi4 == IntPtr.Zero)
            {
                Console.WriteLine("load closePrinterManager failed! ErrorNuber:" + Marshal.GetLastWin32Error().ToString());
            }
            ClosePrinterManager closePrinterManager =
                (ClosePrinterManager)Marshal.GetDelegateForFunctionPointer(hapi4, typeof(ClosePrinterManager));
            Res = closePrinterManager();
            if (Res != 0)
            {
                Console.WriteLine("closePrinterManager failed! \n");
                System.Threading.Thread.Sleep(2000);
                System.Environment.Exit(-1);
            }
            //释放动态链接库
            FreeLibrary(hLib);
            Console.Read();

        }

        //回调函数，打印出接收的数据
        static void printMesssage(string message)
        {
            Console.Write("\n" + message);
        }
    }
}

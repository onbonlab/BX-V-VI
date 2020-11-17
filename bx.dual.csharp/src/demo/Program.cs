using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;

namespace LedSDKDemo_CSharp
{
    class Program
    {
        //控制卡IP
        public static byte[] ip = Encoding.GetEncoding("GBK").GetBytes("192.168.89.181");
        //控制卡端口
        public static ushort port = 5005;
        //串口号 "COM1",大于9以上做特殊处理，如"\\\\.\\COM17"
        public static byte[] com = Encoding.GetEncoding("GBK").GetBytes("\\\\.\\COM17");
        //串口波特率 1：9600  2：57600
        public static byte baudRate = 2;
        //控制卡服务器IP
        public static byte[] server_ip = Encoding.GetEncoding("GBK").GetBytes("127.0.0.1");

                public delegate int MethodCaller(int name);//定义个代理 
        static void Main(string[] args)
        {
            //初始化动态库
            int err = bxdualsdk.bxDual_InitSdk();
            Program_Send_clock.Send_program_clock_5();


            //释放动态库
            bxdualsdk.bxDual_ReleaseSdk();
            Console.ReadKey();
        }


    }
}

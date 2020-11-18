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
        public static byte[] ip = Encoding.GetEncoding("GBK").GetBytes("192.168.89.123");
        //控制卡端口
        public static ushort port = 5005;
        //串口号 "COM1",大于9以上做特殊处理，如"\\\\.\\COM17"
        public static byte[] com = Encoding.GetEncoding("GBK").GetBytes("\\\\.\\COM17");
        //串口波特率 1：9600  2：57600
        public static byte baudRate = 2;

        public delegate int MethodCaller(int name);//定义个代理 
        static void Main(string[] args)
        {
            //初始化动态库
            int err = bxdualsdk.bxDual_InitSdk();

            //BX-5代控制卡
            if (false)
            {
                //Program_Send_clock文本调用示例代码
                Program_Send_txt.Send_program_txt_5();

                //Program_Send_png图片调用示例代码
                //Program_Send_png.Send_program_png_5();

                //Program_Send_time时间调用示例代码
                //Program_Send_time.Send_program_time_5();

                //Program_Send_clock表盘调用示例代码
                //Program_Send_clock.Send_program_clock_5();

                //Program_Send_Areas节目多个区域调用示例代码
                //Program_Send_clock.Send_program_clock_5();

                //动态区调用示例，仅限BX-5E系列使用
                //Dynamic_5.updata_dynamic_pages();
                //删除动态区
                //Dynamic_5.delete_dynamic();
            }
            //BX-6代控制卡
            if (true)
            {
                //Program_Send_clock文本调用示例代码
                //Program_Send_txt.Send_program_txt_6();

                //Program_Send_png图片调用示例代码
                //Program_Send_png.Send_program_png_6();

                //Program_Send_time时间调用示例代码
                //Program_Send_time.Send_program_time_6();

                //Program_Send_clock表盘调用示例代码
                //Program_Send_clock.Send_program_clock_6();

                //Program_Send_Areas节目多个区域调用示例代码
                //Program_Send_clock.Send_program_clock_6(); 


                //动态区调用示例，部分控制卡支持
                Dynamic_6.dynamicArea_str_2();
                //删除动态区
                Dynamic_6.delete_dynamic();
            }

            //服务器模式调用示例
            if (false)
            {
                Server.Server_get();
            }

            //释放动态库
            bxdualsdk.bxDual_ReleaseSdk();
            Console.ReadKey();
        }


    }
}

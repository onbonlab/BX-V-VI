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
        public static byte[] ip = Encoding.GetEncoding("GBK").GetBytes("192.168.89.66");
        //控制卡端口
        public static ushort port = 5005;
        //串口号 "COM1",大于9以上做特殊处理，如"\\\\.\\COM17"
        public static byte[] com = Encoding.GetEncoding("GBK").GetBytes("COM4");
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
                //Program_Send_txt.Send_program_txt_5();

                //Program_Send_png图片调用示例代码
                //Program_Send_png.Send_program_png_5();

                //Program_Send_time时间调用示例代码
                //Program_Send_time.Send_program_time_5();

                //Program_Send_clock表盘调用示例代码
                //Program_Send_clock.Send_program_clock_5();

                //Program_Send_Areas节目多个区域调用示例代码
                //Program_Send_Areas.Send_program_areas_5();

                //动态区调用示例，仅限BX-5E系列使用
                //Dynamic_5.updata_dynamic_pages();
                //删除动态区
                //Dynamic_5.delete_dynamic();
                Random ra = new Random();
                for(int i = 0; i < 10000; i++)
                {
                    string str = "ab" + ra.Next(1,4999);
                    Dynamic_5.updata_tests(0,64,0,44,16, str);
                     str = "是d" + ra.Next(4999,9999);
                    Dynamic_5.updata_tests(1,64, 16, 64, 16, str);
                     str = "gf" + ra.Next(1, 99);
                    Dynamic_5.updata_tests(2, 108, 0, 20, 16, str);
                    Thread.Sleep(2000);
                }
            }
            //BX-6代控制卡
            if (true)
            {
                //Program_Send_txt文本调用示例代码
                //Program_Send_txt.Send_program_txt_6();
                //common_56.deleteprogram();
                //Program_Send_png图片调用示例代码
                //Program_Send_png.Send_program_png_6();

                //Program_Send_time时间调用示例代码
                //Program_Send_time.Send_program_time_6();

                //Program_Send_clock表盘调用示例代码
                //Program_Send_clock.Send_program_clock_6();

                //Program_Send_Areas节目多个区域调用示例代码
                //Program_Send_Areas.Send_program_areas_6(); 


                //动态区调用示例，部分控制卡支持
                //Dynamic_6.dynamicArea_pages_1();
                Dynamic_6.dynamicArea_str_3();

                //删除动态区
                //Dynamic_6.delete_dynamic();
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

        public static void updata_dynamic_pages(string nnn)
        {
            int err = 0;
            byte uAreaId = 0;
            byte RunMode = 0;
            ushort Timeout = 10;
            byte RelateAllPro = 1;
            ushort RelateProNum = 0;
            ushort[] RelateProSerial = null;
            byte ImmePlay = 1;
            ushort uAreaX = 16;
            ushort uAreaY = 0;
            ushort uWidth = 64;
            ushort uHeight = 32;
            bxdualsdk.EQareaframeHeader oFrame;
            oFrame.AreaFFlag = 0;
            oFrame.AreaFDispStyle = 0;
            oFrame.AreaFDispSpeed = 0;
            oFrame.AreaFMoveStep = 0;
            oFrame.AreaFWidth = 0;
            oFrame.AreaFBackup = 0;
            bxdualsdk.DynamicAreaBaseInfo_5G pheader = new bxdualsdk.DynamicAreaBaseInfo_5G();
            pheader.nType = 0x01;
            pheader.DisplayMode = 2;
            pheader.ClearMode = 0x01;
            pheader.Speed = 100;
            pheader.StayTime = 100;
            pheader.RepeatTime = 0;
            pheader.oFont.arrMode = bxdualsdk.E_arrMode.eMULTILINE;
            pheader.oFont.fontSize = 10;
            pheader.oFont.color = 1;
            pheader.oFont.fontBold = 0;
            pheader.oFont.fontItalic = 0;
            pheader.oFont.tdirection = bxdualsdk.E_txtDirection.pNORMAL;
            pheader.oFont.txtSpace = 0;
            pheader.oFont.Halign = 1;
            pheader.oFont.Valign = 2;
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("宋体");
            pheader.fontName = Class1.BytesToIntptr(Font);
            byte[] str = Encoding.GetEncoding("GBK").GetBytes($"{nnn}\0");
            pheader.strAreaTxtContent = Class1.BytesToIntptr(str);
            bxdualsdk.DynamicAreaBaseInfo_5G[] Params = new bxdualsdk.DynamicAreaBaseInfo_5G[1];
            Params[0] = pheader;

            //网口
            if (true)
            {
                //该接口调用报错
                //err = bxdualsdk.bxDual_dynamicArea_AddAreaInfos_5G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                //                    ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, (byte)Params.Length, Params);

                err = bxdualsdk.bxDual_dynamicArea_AddAreaInfos_5G_Point(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, (byte)Params.Length, Params);
            }
            //串口
            if (false)
            {
                //该接口调用报错
                err = bxdualsdk.bxDual_dynamicArea_AddAreaInfos_5G_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                                ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, (byte)Params.Length, Params);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaInfos_5G_Point = " + err);
        }


    }
}

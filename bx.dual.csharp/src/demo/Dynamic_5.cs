using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LedSDKDemo_CSharp
{
    class Dynamic_5
    {
        public static void dynamicArea_5()
        {
            int err = 0;
            //Console.Write("输入IP:");
            //byte[] ip = Encoding.Default.GetBytes(Console.ReadLine());
            byte[] ip = Encoding.Default.GetBytes("192.168.89.123");
            //删除单个动态区 zc
            err = bxdualsdk.bxDual_dynamicArea_DelArea_5G(ip, 5005, 0xff);
            Console.WriteLine("dynamicArea_DelArea_5G = " + err);
            //单区域文本 zc
            byte uAreaId = 0;
            byte RunMode = 0;
            ushort Timeout = 10;
            byte RelateAllPro = 1;
            ushort RelateProNum = 0;
            ushort[] RelateProSerial = null;
            byte ImmePlay = 1;
            ushort uAreaX = 0;
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
            //PageStyle begin--------
            byte DisplayMode = 3;
            byte ClearMode = 0;
            byte Speed = 10;
            ushort StayTime = 10;
            byte RepeatTime = 0;
            //PageStyle End.
            //显示内容和字体格式 begin---------
            bxdualsdk.EQfontData oFont;

            oFont.arrMode = bxdualsdk.E_arrMode.eMULTILINE;
            oFont.fontSize = 10;
            oFont.color = 1;
            oFont.fontBold = 0;
            oFont.fontItalic = 0; oFont.tdirection = bxdualsdk.E_txtDirection.pNORMAL; oFont.txtSpace = 0; oFont.Halign = 1; oFont.Valign = 2;
            byte[] fontName = Encoding.Default.GetBytes("宋体");
            byte[] strAreaTxtContent = Encoding.Default.GetBytes("111测试");
            err = bxdualsdk.bxDual_dynamicArea_AddAreaWithTxt_5G(ip, 5005, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                            ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime, oFont, fontName, strAreaTxtContent);
            Console.WriteLine("dynamicArea_AddAreaWithTxt_5G = " + err);
            //单区域图片 zc
            byte[] filePath = Encoding.Default.GetBytes("32.png");
            //err = bxdualsdk.bxDual_dynamicArea_AddAreaWithPic_5G(ip, 5005, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                            //ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime, filePath);
            Console.WriteLine("dynamicArea_AddAreaWithPic_5G = " + err);


        }

        public static void dynamicArea_51()
        {
            int err = 0;
            //Console.Write("输入IP:");
            //byte[] ip = Encoding.Default.GetBytes(Console.ReadLine());
            byte[] ip = Encoding.Default.GetBytes("192.168.89.123");
            //删除单个动态区 zc
            //err = bxdualsdk.bxDual_dynamicArea_DelArea_5G(ip, 5005, 0xff);
            //Console.WriteLine("dynamicArea_DelArea_5G = " + err);
            bxdualsdk.EQareaframeHeader oFrame;
            oFrame.AreaFFlag = 0;
            oFrame.AreaFDispStyle = 0;
            oFrame.AreaFDispSpeed = 0;
            oFrame.AreaFMoveStep = 0;
            oFrame.AreaFWidth = 0;
            oFrame.AreaFBackup = 0;
            bxdualsdk.DynamicAreaBaseInfo_5G pheader = new bxdualsdk.DynamicAreaBaseInfo_5G();
            pheader.nType = 0x01;
            pheader.DisplayMode = 4;
            pheader.ClearMode = 0x01;
            pheader.Speed = 10;
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
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("111111\0");
            pheader.strAreaTxtContent = Class1.BytesToIntptr(str);
            byte[] img = Encoding.GetEncoding("GBK").GetBytes("123.png\0");
            pheader.filePath = Class1.BytesToIntptr(img);
            bxdualsdk.DynamicAreaBaseInfo_5G pheader1 = new bxdualsdk.DynamicAreaBaseInfo_5G();
            pheader1.nType = 0x01;
            pheader1.DisplayMode = 4;
            pheader1.ClearMode = 0x01;
            pheader1.Speed = 10;
            pheader1.StayTime = 100;
            pheader1.RepeatTime = 0;
            pheader1.oFont.arrMode = bxdualsdk.E_arrMode.eMULTILINE;
            pheader1.oFont.fontSize = 10;
            pheader1.oFont.color = 1;
            pheader1.oFont.fontBold = 0;
            pheader1.oFont.fontItalic = 0;
            pheader1.oFont.tdirection = bxdualsdk.E_txtDirection.pNORMAL;
            pheader1.oFont.txtSpace = 0;
            pheader1.oFont.Halign = 1;
            pheader1.oFont.Valign = 2;
            pheader1.fontName = Class1.BytesToIntptr(Encoding.GetEncoding("GBK").GetBytes("宋体"));
            pheader1.strAreaTxtContent = Class1.BytesToIntptr(Encoding.GetEncoding("GBK").GetBytes("222222\0"));
            pheader1.filePath = Class1.BytesToIntptr(Encoding.GetEncoding("GBK").GetBytes("123.png\0"));
            bxdualsdk.DynamicAreaBaseInfo_5G[] Params = new bxdualsdk.DynamicAreaBaseInfo_5G[2];
            Params[0] = pheader;
            Params[1] = pheader1;

            err = bxdualsdk.bxDual_dynamicArea_AddAreaInfos_5G_Point(ip, 5005, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, 
                0, 0,10, 1, 0, null, 1, 0, 0, 64, 32, oFrame, 2, Params);
            Console.WriteLine("bxDual_dynamicArea_AddAreaInfos_5G_Point = " + err);


        }

        public static void dyna()
        {
            int err = 0;
            byte[] ipAdder = Encoding.GetEncoding("GBK").GetBytes("192.168.89.199");
            ushort port = 5005;
            byte AreaId = 0;
            ushort AreaX = 0;
            ushort AreaY = 0;
            ushort AreaWidth = 64;
            ushort AreaHeight = 32;
            //播放优先级
            byte RunMode = 0;
            ushort Timeout = 2;
            byte ImmePlay = 1;
            byte RelateAllPro = 1;
            ushort RelateProNum = 0;
            ushort[] RelateProSerial = new ushort[0];
            RelateProSerial = null;

            bxdualsdk.EQareaframeHeader oFrame;
            oFrame.AreaFFlag = 0;
            oFrame.AreaFDispStyle = 0;
            oFrame.AreaFDispSpeed = 0;
            oFrame.AreaFMoveStep = 0;
            oFrame.AreaFWidth = 0;
            oFrame.AreaFBackup = 0;

            string[] imglist = new string[] { "0.png", "1.png", "2.png", "3.png", "4.png", };
            bxdualsdk.DynamicAreaBaseInfo_5G[] Params = new bxdualsdk.DynamicAreaBaseInfo_5G[5];
            for (int i=0;i<5;i++) {
                bxdualsdk.DynamicAreaBaseInfo_5G pheader = new bxdualsdk.DynamicAreaBaseInfo_5G();
                pheader.nType = 0x02;
                pheader.DisplayMode = 4;
                pheader.ClearMode = 0x01;
                pheader.Speed = 5;
                pheader.StayTime = 100;
                pheader.RepeatTime = 0;
                pheader.oFont.arrMode = bxdualsdk.E_arrMode.eMULTILINE;
                pheader.oFont.fontSize = 10;
                pheader.oFont.color = 1;
                pheader.oFont.fontBold = 0;
                pheader.oFont.fontItalic = 0;
                pheader.oFont.tdirection = bxdualsdk.E_txtDirection.pNORMAL;
                pheader.oFont.txtSpace = 0;
                pheader.oFont.Valign = 0;
                pheader.oFont.Halign = 0;
                pheader.fontName = Class1.BytesToIntptr(Encoding.GetEncoding("GB2312").GetBytes("宋体\0"));
                pheader.strAreaTxtContent = Class1.BytesToIntptr(Encoding.GetEncoding("GBK").GetBytes("12快解决3456\0"));
                pheader.filePath = Class1.BytesToIntptr(Encoding.GetEncoding("GBK").GetBytes(imglist[i]));
                Params[i] = pheader;
            }
            //err = bxdualsdk.bxDual_dynamicArea_SetDualPixel(bxdualsdk.E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
            //err = bxdualsdk.bxDual_dynamicArea_AddAreaInfos_5G_Point(ipAdder, 5005, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE,
            //    AreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, AreaX, AreaY, AreaWidth, AreaHeight, oFrame, 2, Params);

            err = bxdualsdk.bxDual_dynamicArea_AddAreaInfos_5G_Point(ipAdder, 5005, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE,
                AreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial, ImmePlay, AreaX, AreaY, AreaWidth, AreaHeight, oFrame, (byte)Params.Length, Params);
            Console.WriteLine("bxDual_dynamicArea_AddAreaInfos_5G_Point:" + err);

            //err = bxdualsdk.bxDual_dynamicArea_DelArea_5G(ipAdder, port, 0xff);
        }
    }
}

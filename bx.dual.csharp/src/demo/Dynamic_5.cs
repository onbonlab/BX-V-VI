using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LedSDKDemo_CSharp
{
    /// <summary>
    /// 动态区相关命令，仅支持BX-5E系列
    /// </summary>
    class Dynamic_5
    {
        /// <summary>
        /// 删除动态区，单个操作
        /// </summary>
        public static void delete_dynamic()
        {
            //第三个参数给动态区ID指定删除，给0xff删除所有动态区
            int err = 0;
            //网口
            if (true)
            {
                err = bxdualsdk.bxDual_dynamicArea_DelArea_5G(Program.ip, Program.port, 0xff);
            }
            //串口
            if (false)
            {
                err = bxdualsdk.bxDual_dynamicArea_DelArea_G5_Serial(Program.com, Program.baudRate, 0xff);
            }
            Console.WriteLine("dynamicArea_DelArea_5G = " + err);
        }

        /// <summary>
        /// 删除动态区，多区域操作
        /// </summary>
        public static void delete_dynamic_s()
        {
            byte[] id = new byte[] { 0,1};
            int err = 0;
            //网口
            if (true)
            {
                err = bxdualsdk.bxDual_dynamicArea_DelAreaS_5G(Program.ip, Program.port, (byte)id.Length, id);
            }
            //串口
            if (false)
            {
                id = new byte[] { 0 };
                err = bxdualsdk.bxDual_dynamicArea_DelAreaS_G5_Serial(Program.com, Program.baudRate, (byte)id.Length, id);
            }
            Console.WriteLine("dynamicArea_DelArea_5G = " + err);
        }

        /// <summary>
        /// 动态区更新文本，单条文本
        /// </summary>
        public static void updata_dynamic_txt()
        {
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
            byte[] strAreaTxtContent = Encoding.Default.GetBytes("测试文本");
            int err = 0;
            //网口
            if (true)
            {
                err = bxdualsdk.bxDual_dynamicArea_AddAreaWithTxt_5G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                                ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime, oFont, fontName, strAreaTxtContent);
                //功能一样，只是结构体为指针参数
                //err = bxdualsdk.bxDual_dynamicArea_AddAreaWithTxt_Point_5G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                                //ImmePlay, uAreaX, uAreaY, uWidth, uHeight,ref oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime,ref oFont, fontName, strAreaTxtContent);
            }
            //串口
            if (false)
            {
                err = bxdualsdk.bxDual_dynamicArea_AddAreaWithTxt_5G_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                                ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime, oFont, fontName, strAreaTxtContent);
                //功能一样，只是结构体为指针参数
                //err = bxdualsdk.bxDual_dynamicArea_AddAreaWithTxt_Point_5G_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                //ImmePlay, uAreaX, uAreaY, uWidth, uHeight,ref oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime,ref oFont, fontName, strAreaTxtContent);
            }
            Console.WriteLine("dynamicArea_AddAreaWithTxt_5G = " + err);
        }

        /// <summary>
        /// 动态区更新图片，单张图片
        /// </summary>
        public static void updata_dynamic_png()
        {
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
            byte[] filePath = Encoding.Default.GetBytes("456.png");
            int err = 0;
            //网口
            if (true)
            {
                err = bxdualsdk.bxDual_dynamicArea_AddAreaWithPic_5G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime, filePath);
            }
            //串口
            if (false)
            {
                err = bxdualsdk.bxDual_dynamicArea_AddAreaWithPic_5G_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime, filePath);
            }
            Console.WriteLine("dynamicArea_AddAreaWithPic_5G = " + err);
        }

        /// <summary>
        /// 动态区更新多页数据
        /// </summary>
        public static void updata_dynamic_pages()
        {
            int err = 0;
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
            bxdualsdk.DynamicAreaBaseInfo_5G pheader = new bxdualsdk.DynamicAreaBaseInfo_5G();
            pheader.nType = 0x02;
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

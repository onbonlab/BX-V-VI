using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace LedSDKDemo_CSharp
{
    /// <summary>
    /// 动态区相关命令，6E系列，6E1X，6E2X，6Q1，6Q2，6Q3，6QX-YD，6Q2L，6Q3L系列支持
    /// </summary>
    class Dynamic_6
    {
        public static int err = 0;
        //5E系列支持 0-3，6E，6Q系列支持 0-31
        public static byte AreaId = 0;
        public static byte RunMode = 0;
        public static ushort Timeout = 10;
        public static byte RelateAllPro = 1;
        public static ushort RelateProNum = 0;
        public static ushort[] RelateProSerial = null;
        public static byte ImmePlay = 1;
        //动态区域左上角在LED显示屏的位置/坐标；
        public static ushort AreaX = 0;
        public static ushort AreaY = 0;
        //动态区域的宽度，高度
        public static ushort Width = 64;
        public static ushort Height = 32;
        //字体名称，如"宋体";
        public static IntPtr fontName;
        //public static byte[] fontName = Encoding.GetEncoding("GBK").GetBytes("宋体");
        //字体大小
        public static byte FontSize = 12;
        //要显示的文本内容
        public static IntPtr strAreaTxtContent;
        //public static byte[] strAreaTxtContent = Encoding.GetEncoding("GBK").GetBytes("12345565648");
        //要显示的图片 只支持png类型，图片像素大小和区域坐标1：1，一般黑底红字
        public static IntPtr img;
        //public static byte[] img = Encoding.GetEncoding("GBK").GetBytes("0.png");

        /// <summary>
        /// 删除动态区，单个操作
        /// </summary>
        public static void delete_dynamic()
        {
            //第三个参数给动态区ID指定删除，给0xff删除所有动态区
            //网口
            if (true)
            {
                err = bxdualsdk.bxDual_dynamicArea_DelArea_6G(Program.ip, Program.port, 0xff);
            }
            //串口
            if (false)
            {
                err = bxdualsdk.bxDual_dynamicArea_DelArea_G6_Serial(Program.com, Program.baudRate, 0xff);
            }
            Console.WriteLine("dynamicArea_DelArea = " + err);
        }

        /// <summary>
        /// 删除动态区，多区域操作
        /// </summary>
        public static void delete_dynamic_s()
        {
            byte[] id = new byte[] { 0, 1 };
            //网口
            if (true)
            {
                err = bxdualsdk.bxDual_dynamicArea_DelAreas_6G(Program.ip, Program.port, (byte)id.Length, id);
            }
            //串口
            if (false)
            {
                id = new byte[] { 0 };
                err = bxdualsdk.bxDual_dynamicArea_DelAreas_G6_Serial(Program.com, Program.baudRate, (byte)id.Length, id);
            }
            Console.WriteLine("dynamicArea_DelArea = " + err);
        }

        /// <summary>
        /// 设置双色屏点阵类型,双色屏时，如果发送红色显示黄色，就是点阵类型参数不对，该接口5代，6代通用
        /// </summary>
        public static void dynamic_pixel()
        {
            bxdualsdk.bxDual_dynamicArea_SetDualPixel(bxdualsdk.E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
        }

        /// <summary>
        /// 单区域文本，不能设置特效
        /// </summary>
        public static void dynamicArea_str_1()
        {
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("宋体");
            fontName = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, fontName, Font.Length);
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("111111\0");
            strAreaTxtContent = Marshal.AllocHGlobal(str.Length);
            Marshal.Copy(str, 0, strAreaTxtContent, str.Length);
            err = bxdualsdk.bxDual_dynamicArea_AddAreaTxt_6G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, AreaX, AreaY,
                                                      Width, Height, fontName, FontSize, strAreaTxtContent);
            Console.WriteLine("bxDual_dynamicArea_AddAreaTxt_6G:" + err);
        }
        /// <summary>
        /// 单区域文本，能设置特效
        /// </summary>
        public static void dynamicArea_str_2()
        {
            bxdualsdk.EQareaHeader_G6 aheader;
            aheader.AreaType = 0x10;
            aheader.AreaX = AreaX;
            aheader.AreaY = AreaY;
            aheader.AreaWidth = Width;
            aheader.AreaHeight = Height;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            bxdualsdk.EQSound_6G stSoundData = new bxdualsdk.EQSound_6G();
            byte[] strSoundTxt = Encoding.GetEncoding("GB2312").GetBytes("插入ab34测试语音");
            stSoundData.SoundFlag = 0x00;
            stSoundData.SoundPerson = 0x01;
            stSoundData.SoundVolum = 6;
            stSoundData.SoundSpeed = 0x2;
            stSoundData.SoundDataMode = 0x00;
            stSoundData.SoundReplayTimes = 0x01;
            stSoundData.SoundReplayDelay = 200;
            stSoundData.SoundReservedParaLen = 0x03;
            stSoundData.Soundnumdeal = 0x00;
            stSoundData.Soundlanguages = 0x00;
            stSoundData.Soundwordstyle = 0x00;
            stSoundData.SoundDataLen = strSoundTxt.Length;
            stSoundData.SoundData = Class1.BytesToIntptr(strSoundTxt);
            aheader.stSoundData = stSoundData;

            bxdualsdk.EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 2;
            pheader.ClearMode = 0x00;
            pheader.Speed = 15;
            pheader.StayTime = 0;
            pheader.RepeatTime = 1;
            pheader.ValidLen = 0;
            pheader.CartoonFrameRate = 0x00;
            pheader.BackNotValidFlag = 0x00;
            pheader.arrMode = bxdualsdk.E_arrMode.eMULTILINE;
            pheader.fontSize = 12;
            pheader.color = (uint)0x01;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = bxdualsdk.E_txtDirection.pNORMAL;
            pheader.txtSpace = 0;
            pheader.Valign = 1;
            pheader.Halign = 1;
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("宋体");
            fontName = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, fontName, Font.Length);
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("111111\0");
            strAreaTxtContent = Marshal.AllocHGlobal(str.Length);
            Marshal.Copy(str, 0, strAreaTxtContent, str.Length);
            //网口
            if (true)
            {
                err = bxdualsdk.bxDual_dynamicArea_AddAreaTxtDetails_6G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_SINGLE, AreaId, 
                    ref aheader, ref pheader, fontName, strAreaTxtContent);
            }
            //串口
            if (false)
            {
                err = bxdualsdk.bxDual_dynamicArea_AddAreaTxtDetails_6G_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, 
                    AreaId, ref aheader, ref pheader, fontName, strAreaTxtContent);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaTxtDetails_6G:" + err);
        }

        /// <summary>
        /// 单区域文本，能设置特效,可选择是否和节目内容一起播放【一起播放时动态区和节目区域不能有重叠】
        /// </summary>
        public static void dynamicArea_str_3()
        {
            bxdualsdk.EQareaHeader_G6 aheader;
            aheader.AreaType = 0x10;
            aheader.AreaX = AreaX;
            aheader.AreaY = AreaY;
            aheader.AreaWidth = Width;
            aheader.AreaHeight = Height;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            bxdualsdk.EQSound_6G stSoundData = new bxdualsdk.EQSound_6G();
            byte[] strSoundTxt = Encoding.GetEncoding("GB2312").GetBytes("插入ab34测试语音");
            stSoundData.SoundFlag = 0x00;
            stSoundData.SoundPerson = 0x01;
            stSoundData.SoundVolum = 6;
            stSoundData.SoundSpeed = 0x2;
            stSoundData.SoundDataMode = 0x00;
            stSoundData.SoundReplayTimes = 0x01;
            stSoundData.SoundReplayDelay = 200;
            stSoundData.SoundReservedParaLen = 0x03;
            stSoundData.Soundnumdeal = 0x00;
            stSoundData.Soundlanguages = 0x00;
            stSoundData.Soundwordstyle = 0x00;
            stSoundData.SoundDataLen = strSoundTxt.Length;
            stSoundData.SoundData = Class1.BytesToIntptr(strSoundTxt);
            aheader.stSoundData = stSoundData;

            bxdualsdk.EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 4;
            pheader.ClearMode = 0x00;
            pheader.Speed = 10;
            pheader.StayTime = 0;
            pheader.RepeatTime = 1;
            pheader.ValidLen = 0;
            pheader.CartoonFrameRate = 0x00;
            pheader.BackNotValidFlag = 0x00;
            pheader.arrMode = bxdualsdk.E_arrMode.eSINGLELINE;
            pheader.fontSize = 18;
            pheader.color = (uint)0xffff00;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = bxdualsdk.E_txtDirection.pNORMAL;
            pheader.txtSpace = 0;
            pheader.Valign = 1;
            pheader.Halign = 1;
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("宋体");
            fontName = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, fontName, Font.Length);
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("111111\0");
            strAreaTxtContent = Marshal.AllocHGlobal(str.Length);
            Marshal.Copy(str, 0, strAreaTxtContent, str.Length);
            //网口
            if (true)
            {
                //动态区优先播放，节目停止播放
                err = bxdualsdk.bxDual_dynamicArea_AddAreaTxtDetails_6G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, 
                    ref aheader, ref pheader, fontName, strAreaTxtContent);
                //是否关联节目
                //err = bxdualsdk.bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_SINGLE, AreaId,
                //ref aheader, ref pheader, fontName, strAreaTxtContent, RelateProNum, RelateProSerial);
            }
            //串口
            if (false)
            {
                //动态区优先播放，节目停止播放
                err = bxdualsdk.bxDual_dynamicArea_AddAreaTxtDetails_6G_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, 
                    ref aheader, ref pheader, fontName, strAreaTxtContent);
                //是否关联节目
                //err = bxdualsdk.bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId,
                //ref aheader, ref pheader, fontName, strAreaTxtContent, RelateProNum, RelateProSerial);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaTxtDetails_6G:" + err);
        }
        /// <summary>
        /// 单区域多文本，能设置特效,可选择是否和节目内容一起播放【一起播放时动态区和节目区域不能有重叠】
        /// </summary>
        public static void dynamicArea_str_4()
        {
            bxdualsdk.EQareaHeader_G6 aheader;
            aheader.AreaType = 0x10;
            aheader.AreaX = AreaX;
            aheader.AreaY = AreaY;
            aheader.AreaWidth = Width;
            aheader.AreaHeight = Height;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            bxdualsdk.EQSound_6G stSoundData = new bxdualsdk.EQSound_6G();
            byte[] strSoundTxt = Encoding.GetEncoding("GB2312").GetBytes("插入ab34测试语音");
            stSoundData.SoundFlag = 0x00;
            stSoundData.SoundPerson = 0x01;
            stSoundData.SoundVolum = 6;
            stSoundData.SoundSpeed = 0x2;
            stSoundData.SoundDataMode = 0x00;
            stSoundData.SoundReplayTimes = 0x01;
            stSoundData.SoundReplayDelay = 200;
            stSoundData.SoundReservedParaLen = 0x03;
            stSoundData.Soundnumdeal = 0x00;
            stSoundData.Soundlanguages = 0x00;
            stSoundData.Soundwordstyle = 0x00;
            stSoundData.SoundDataLen = strSoundTxt.Length;
            stSoundData.SoundData = Class1.BytesToIntptr(strSoundTxt);
            aheader.stSoundData = stSoundData;

            bxdualsdk.EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 4;
            pheader.ClearMode = 0x00;
            pheader.Speed = 15;
            pheader.StayTime = 0;
            pheader.RepeatTime = 1;
            pheader.ValidLen = 0;
            pheader.CartoonFrameRate = 0x00;
            pheader.BackNotValidFlag = 0x00;
            pheader.arrMode = bxdualsdk.E_arrMode.eSINGLELINE;
            pheader.fontSize = 12;
            pheader.color = (uint)0x01;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = bxdualsdk.E_txtDirection.pNORMAL;
            pheader.txtSpace = 0;
            pheader.Valign = 1;
            pheader.Halign = 1;
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("宋体");
            fontName = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, fontName, Font.Length);
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("111111\0");
            strAreaTxtContent = Marshal.AllocHGlobal(str.Length);
            Marshal.Copy(str, 0, strAreaTxtContent, str.Length);
            //网口
            if (true)
            {
                //动态区优先播放，节目停止播放
                err = bxdualsdk.bxDual_dynamicArea_AddAreaTxtDetails_6G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId,
                    ref aheader, ref pheader, fontName, strAreaTxtContent);
                //是否关联节目
                //err = bxdualsdk.bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId,
                //ref aheader, ref pheader, fontName, strAreaTxtContent, RelateProNum, RelateProSerial);
            }
            //串口
            if (false)
            {
                //动态区优先播放，节目停止播放
                err = bxdualsdk.bxDual_dynamicArea_AddAreaTxtDetails_6G_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId,
                    ref aheader, ref pheader, fontName, strAreaTxtContent);
                //是否关联节目
                //err = bxdualsdk.bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId,
                //ref aheader, ref pheader, fontName, strAreaTxtContent, RelateProNum, RelateProSerial);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaTxtDetails_6G:" + err);
        }
        /// <summary>
        /// 单区域图片，能设置特效
        /// </summary>
        public static void dynamicArea_png_1()
        {
            bxdualsdk.EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 4;
            pheader.ClearMode = 0x00;
            pheader.Speed = 15;
            pheader.StayTime = 0;
            pheader.RepeatTime = 1;
            pheader.ValidLen = 0;
            pheader.CartoonFrameRate = 0x00;
            pheader.BackNotValidFlag = 0x00;
            pheader.arrMode = bxdualsdk.E_arrMode.eSINGLELINE;
            pheader.fontSize = 12;
            pheader.color = (uint)0x01;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = bxdualsdk.E_txtDirection.pNORMAL;
            pheader.txtSpace = 0;
            pheader.Valign = 1;
            pheader.Halign = 1;
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("1.png\0");
            img = Marshal.AllocHGlobal(str.Length);
            Marshal.Copy(str, 0, img, str.Length);
            //网口
            if (true)
            {
                //动态区优先播放，节目停止播放
                err = bxdualsdk.bxDual_dynamicArea_AddAreaPic_6G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, AreaX, AreaY,
                                                          Width, Height, ref pheader, img);
                //是否关联节目
                //err = bxdualsdk.bxDual_dynamicArea_AddAreaPic_WithProgram_6G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, AreaX, AreaY,
                //                                          Width, Height, ref pheader, img, RelateProNum, RelateProSerial);

            }
            //串口
            if (false)
            {
                //动态区优先播放，节目停止播放
                err = bxdualsdk.bxDual_dynamicArea_AddAreaPic_6G_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, AreaX, AreaY,
                                                          Width, Height, ref pheader, strAreaTxtContent);
                //是否关联节目
                //err = bxdualsdk.bxDual_dynamicArea_AddAreaPic_WithProgram_G6_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, 
                //    AreaX, AreaY,Width, Height, ref pheader, strAreaTxtContent, RelateProNum, RelateProSerial);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaTxtDetails_6G:" + err);
        }
        /// <summary>
        /// 同时更新多个动态区文本
        /// </summary>
        public static void dynamicArea_str_5()
        {
            bxdualsdk.EQareaHeader_G6 aheader;
            aheader.AreaType = 0x10;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = 64;
            aheader.AreaHeight = 16;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            bxdualsdk.EQareaHeader_G6 aheader1;
            aheader1.AreaType = 0x10;
            aheader1.AreaX = 0;
            aheader1.AreaY = 16;
            aheader1.AreaWidth = 64;
            aheader1.AreaHeight = 16;
            aheader1.BackGroundFlag = 0x00;
            aheader1.Transparency = 101;
            aheader1.AreaEqual = 0x00;
            bxdualsdk.EQSound_6G stSoundData = new bxdualsdk.EQSound_6G();
            byte[] strSoundTxt = Encoding.GetEncoding("GB2312").GetBytes("插入ab34测试语音");
            stSoundData.SoundFlag = 0x00;
            stSoundData.SoundPerson = 0x01;
            stSoundData.SoundVolum = 6;
            stSoundData.SoundSpeed = 0x2;
            stSoundData.SoundDataMode = 0x00;
            stSoundData.SoundReplayTimes = 0x01;
            stSoundData.SoundReplayDelay = 200;
            stSoundData.SoundReservedParaLen = 0x03;
            stSoundData.Soundnumdeal = 0x00;
            stSoundData.Soundlanguages = 0x00;
            stSoundData.Soundwordstyle = 0x00;
            stSoundData.SoundDataLen = strSoundTxt.Length;
            stSoundData.SoundData = Class1.BytesToIntptr(strSoundTxt);

            aheader.stSoundData = stSoundData;
            aheader1.stSoundData = stSoundData;

            bxdualsdk.EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 2;
            pheader.ClearMode = 0x00;
            pheader.Speed = 5;
            pheader.StayTime = 100;
            pheader.RepeatTime = 1;
            pheader.ValidLen = 0;
            pheader.CartoonFrameRate = 0x00;
            pheader.BackNotValidFlag = 0x00;
            pheader.arrMode = bxdualsdk.E_arrMode.eMULTILINE;
            pheader.fontSize = 14;
            pheader.color = (uint)0x01;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = bxdualsdk.E_txtDirection.pNORMAL;
            pheader.txtSpace = 0;
            pheader.Valign = 1;
            pheader.Halign = 1;
            bxdualsdk.EQpageHeader_G6 pheader1;
            pheader1.PageStyle = 0x00;
            pheader1.DisplayMode = 0x03;
            pheader1.ClearMode = 0x01;
            pheader1.Speed = 15;
            pheader1.StayTime = 500;
            pheader1.RepeatTime = 1;
            pheader1.ValidLen = 0;
            pheader1.CartoonFrameRate = 0x00;
            pheader1.BackNotValidFlag = 0x00;
            pheader1.arrMode = bxdualsdk.E_arrMode.eSINGLELINE;
            pheader1.fontSize = 18;
            pheader1.color = (uint)0x01;
            pheader1.fontBold = 0;
            pheader1.fontItalic = 0;
            pheader1.tdirection = bxdualsdk.E_txtDirection.pNORMAL;
            pheader1.txtSpace = 0;
            pheader1.Valign = 1;
            pheader1.Halign = 0;
            bxdualsdk.DynamicAreaParams[] Params = new bxdualsdk.DynamicAreaParams[2];
            Params[0].uAreaId = 0;
            Params[0].oAreaHeader_G6 = aheader;
            Params[0].stPageHeader = pheader;
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("宋体");
            Params[0].fontName = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, Params[0].fontName, Font.Length);
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("111111\0");
            Params[0].strAreaTxtContent = Marshal.AllocHGlobal(str.Length);
            Marshal.Copy(str, 0, Params[0].strAreaTxtContent, str.Length);
            Params[1].uAreaId = 1;
            Params[1].oAreaHeader_G6 = aheader1;
            Params[1].stPageHeader = pheader1;
            Params[1].fontName = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, Params[1].fontName, Font.Length);
            byte[] str1 = Encoding.GetEncoding("GBK").GetBytes("22222\0");
            Params[1].strAreaTxtContent = Marshal.AllocHGlobal(str1.Length);
            Marshal.Copy(str1, 0, Params[1].strAreaTxtContent, str1.Length);
            //网口
            if (true)
            {
                //动态区优先播放，节目停止播放
                //err = bxdualsdk.bxDual_dynamicAreaS_AddTxtDetails_6G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, (byte)Params.Length, Params);
                //是否关联节目
                Console.WriteLine(DateTime.Now.ToString());
                err = bxdualsdk.bxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE,
                (byte)Params.Length, Params, RelateProNum, RelateProSerial);
                Console.WriteLine(DateTime.Now.ToString());

            }
            //串口
            if (false)
            {
                //动态区优先播放，节目停止播放
                err = bxdualsdk.bxDual_dynamicAreaS_AddTxtDetails_6G_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, (byte)Params.Length, Params);
                //是否关联节目
                //err = bxdualsdk.bxDual_dynamicAreaS_AddTxtDetails_WithProgram_G6_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE,
                //(byte)Params.Length, Params, RelateProNum, RelateProSerial);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaTxtDetails_6G:" + err);
        }
        /// <summary>
        /// 同时更新多个动态区图片
        /// </summary>
        public static void dynamicArea_png_2()
        {
            bxdualsdk.EQareaHeader_G6 aheader;
            aheader.AreaType = 0x10;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = 64;
            aheader.AreaHeight = 16;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            bxdualsdk.EQareaHeader_G6 aheader1;
            aheader1.AreaType = 0x10;
            aheader1.AreaX = 0;
            aheader1.AreaY = 16;
            aheader1.AreaWidth = 64;
            aheader1.AreaHeight = 16;
            aheader1.BackGroundFlag = 0x00;
            aheader1.Transparency = 101;
            aheader1.AreaEqual = 0x00;
            bxdualsdk.EQSound_6G stSoundData = new bxdualsdk.EQSound_6G();
            byte[] strSoundTxt = Encoding.GetEncoding("GB2312").GetBytes("插入ab34测试语音");
            stSoundData.SoundFlag = 0x00;
            stSoundData.SoundPerson = 0x01;
            stSoundData.SoundVolum = 6;
            stSoundData.SoundSpeed = 0x2;
            stSoundData.SoundDataMode = 0x00;
            stSoundData.SoundReplayTimes = 0x01;
            stSoundData.SoundReplayDelay = 200;
            stSoundData.SoundReservedParaLen = 0x03;
            stSoundData.Soundnumdeal = 0x00;
            stSoundData.Soundlanguages = 0x00;
            stSoundData.Soundwordstyle = 0x00;
            stSoundData.SoundDataLen = strSoundTxt.Length;
            stSoundData.SoundData = Class1.BytesToIntptr(strSoundTxt);

            aheader.stSoundData = stSoundData;
            aheader1.stSoundData = stSoundData;

            bxdualsdk.EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 4;
            pheader.ClearMode = 0x00;
            pheader.Speed = 5;
            pheader.StayTime = 100;
            pheader.RepeatTime = 1;
            pheader.ValidLen = 0;
            pheader.CartoonFrameRate = 0x00;
            pheader.BackNotValidFlag = 0x00;
            pheader.arrMode = bxdualsdk.E_arrMode.eMULTILINE;
            pheader.fontSize = 14;
            pheader.color = (uint)0x01;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = bxdualsdk.E_txtDirection.pNORMAL;
            pheader.txtSpace = 0;
            pheader.Valign = 1;
            pheader.Halign = 1;
            bxdualsdk.EQpageHeader_G6 pheader1;
            pheader1.PageStyle = 0x00;
            pheader1.DisplayMode = 0x03;
            pheader1.ClearMode = 0x01;
            pheader1.Speed = 15;
            pheader1.StayTime = 500;
            pheader1.RepeatTime = 1;
            pheader1.ValidLen = 0;
            pheader1.CartoonFrameRate = 0x00;
            pheader1.BackNotValidFlag = 0x00;
            pheader1.arrMode = bxdualsdk.E_arrMode.eSINGLELINE;
            pheader1.fontSize = 18;
            pheader1.color = (uint)0x01;
            pheader1.fontBold = 0;
            pheader1.fontItalic = 0;
            pheader1.tdirection = bxdualsdk.E_txtDirection.pNORMAL;
            pheader1.txtSpace = 0;
            pheader1.Valign = 1;
            pheader1.Halign = 0;
            bxdualsdk.DynamicAreaParams[] Params = new bxdualsdk.DynamicAreaParams[2];
            Params[0].uAreaId = 0;
            Params[0].oAreaHeader_G6 = aheader;
            Params[0].stPageHeader = pheader;
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("宋体");
            Params[0].fontName = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, Params[0].fontName, Font.Length);
            byte[] img = Encoding.GetEncoding("GBK").GetBytes("123.png\0");
            Params[0].strAreaTxtContent = Marshal.AllocHGlobal(img.Length);
            Marshal.Copy(img, 0, Params[0].strAreaTxtContent, img.Length);
            Params[1].uAreaId = 1;
            Params[1].oAreaHeader_G6 = aheader1;
            Params[1].stPageHeader = pheader1;
            Params[1].fontName = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, Params[1].fontName, Font.Length);
            byte[] img1 = Encoding.GetEncoding("GBK").GetBytes("1.png\0");
            Params[1].strAreaTxtContent = Marshal.AllocHGlobal(img1.Length);
            Marshal.Copy(img1, 0, Params[1].strAreaTxtContent, img1.Length);
            //网口
            if (true)
            {
                //动态区优先播放，节目停止播放
                err = bxdualsdk.bxDual_dynamicAreaS_AddAreaPic_6G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, (byte)Params.Length, Params);
                //是否关联节目
                //err = bxdualsdk.bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE,
                //(byte)Params.Length, Params, RelateProNum, RelateProSerial);

            }
            //串口
            if (false)
            {
                //动态区优先播放，节目停止播放
                err = bxdualsdk.bxDual_dynamicAreaS_AddAreaPic_6G_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, (byte)Params.Length, Params);
                //是否关联节目
                //err = bxdualsdk.bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE,
                //(byte)Params.Length, Params, RelateProNum, RelateProSerial);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaTxtDetails_6G:" + err);
        }
        /// <summary>
        /// 一次向一个动态区发送/更新多条信息（文字或图片）及语音
        /// 该接口有问题，不建议使用
        /// </summary>
        public static void dynamicArea_pages()
        {
            int err = 0;
            byte DisplayMode = 2;
            byte Speed = 1;
            ushort StayTime = 100;
            byte RepeatTime = 0;
            ushort ValidLen = 0;
            byte CartoonFrameRate = 0;
            bxdualsdk.E_arrMode arrMode = 0;
            ushort fontSize = 10;
            uint color = 1;
            byte fontBold = 0;
            byte fontItalic = 0;
            bxdualsdk.E_txtDirection tdirection = 0;
            ushort txtSpace = 0;
            byte Valign = 2;
            byte Halign = 2;
            bxdualsdk.EQSound_6G stSoundData = new bxdualsdk.EQSound_6G();
            stSoundData.SoundFlag = 0;
            stSoundData.SoundPerson = 0;
            stSoundData.SoundVolum = 0;
            stSoundData.SoundSpeed = 0;
            stSoundData.SoundDataMode = 0;
            stSoundData.SoundReplayTimes = 0;
            stSoundData.SoundReplayDelay = 0;
            stSoundData.SoundReservedParaLen = 0;
            stSoundData.Soundnumdeal = 0;
            stSoundData.Soundlanguages = 0;
            stSoundData.Soundwordstyle = 0;
            stSoundData.SoundDataLen = 0;
            stSoundData.SoundData = IntPtr.Zero;

            bxdualsdk.EQareaframeHeader Frame = new bxdualsdk.EQareaframeHeader();
            Frame.AreaFFlag = 0;
            Frame.AreaFDispStyle = 0x03;
            Frame.AreaFDispSpeed = 0x10;
            Frame.AreaFMoveStep = 0x01;
            Frame.AreaFWidth = 2;
            Frame.AreaFBackup = 0;
            //Frame.pStrFramePathFile = Encoding.Default.GetBytes("F:\\黄10.png");// Class1.BytesToIntptr(Encoding.Default.GetBytes("F:\\黄10.png"));

            bxdualsdk.DynamicAreaBaseInfo_5G pheader = new bxdualsdk.DynamicAreaBaseInfo_5G();
            pheader.nType = 0x01;
            pheader.DisplayMode = DisplayMode;
            pheader.ClearMode = 0x01;
            pheader.Speed = Speed;
            pheader.StayTime = StayTime;
            pheader.RepeatTime = RepeatTime;
            pheader.oFont.arrMode = arrMode;
            pheader.oFont.fontSize = fontSize;
            pheader.oFont.color = color;
            pheader.oFont.fontBold = fontBold;
            pheader.oFont.fontItalic = fontItalic;
            pheader.oFont.tdirection = tdirection;
            pheader.oFont.txtSpace = txtSpace;
            pheader.oFont.Valign = Valign;
            pheader.oFont.Halign = Halign;
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("宋体");
            pheader.fontName = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, pheader.fontName, Font.Length);
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("111111\0");
            pheader.strAreaTxtContent = Marshal.AllocHGlobal(str.Length);
            Marshal.Copy(str, 0, pheader.strAreaTxtContent, str.Length);
            byte[] img = Encoding.GetEncoding("GBK").GetBytes("123.png\0");
            pheader.filePath = Marshal.AllocHGlobal(img.Length);
            Marshal.Copy(img, 0, pheader.filePath, img.Length);
            bxdualsdk.DynamicAreaBaseInfo_5G[] Params = new bxdualsdk.DynamicAreaBaseInfo_5G[1];
            Params[0] = pheader;
            //网口
            if (true)
            {
                //动态区优先播放，节目停止播放
                err = bxdualsdk.bxDual_dynamicArea_AddAreaInfos_6G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, RunMode, Timeout, RelateAllPro,
             RelateProNum, RelateProSerial, ImmePlay, AreaX, AreaY, Width, Height, Frame, (byte)Params.Length, ref Params);
            }
            //串口
            if (false)
            {
                //动态区优先播放，节目停止播放
                err = bxdualsdk.bxDual_dynamicArea_AddAreaInfos_G6_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, RunMode, Timeout, RelateAllPro,
             RelateProNum, RelateProSerial, ImmePlay, AreaX, AreaY, Width, Height, Frame, (byte)Params.Length, ref Params);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaInfos_6G_V2 = " + err);
        }
        /// <summary>
        /// 一次向一个动态区发送/更新多条信息（文字或图片）及语音
        /// </summary>
        public static void dynamicArea_pages_1()
        {
            int err = 0;
            byte DisplayMode = 2;
            byte Speed = 1;
            ushort StayTime = 100;
            byte RepeatTime = 0;
            bxdualsdk.E_arrMode arrMode = 0;
            ushort fontSize = 10;
            uint color = 1;
            byte fontBold = 0;
            byte fontItalic = 0;
            bxdualsdk.E_txtDirection tdirection = 0;
            ushort txtSpace = 0;
            byte Valign = 1;
            byte Halign = 1;
            bxdualsdk.EQSound_6G stSoundData = new bxdualsdk.EQSound_6G();
            stSoundData.SoundFlag = 0;
            stSoundData.SoundPerson = 0;
            stSoundData.SoundVolum = 0;
            stSoundData.SoundSpeed = 0;
            stSoundData.SoundDataMode = 0;
            stSoundData.SoundReplayTimes = 0;
            stSoundData.SoundReplayDelay = 0;
            stSoundData.SoundReservedParaLen = 0;
            stSoundData.Soundnumdeal = 0;
            stSoundData.Soundlanguages = 0;
            stSoundData.Soundwordstyle = 0;
            stSoundData.SoundDataLen = 0;
            stSoundData.SoundData = IntPtr.Zero;

            bxdualsdk.BxAreaFrmae_Dynamic_G6 Frame;
            bxdualsdk.EQscreenframeHeader_G6 oFrame;//暂时不支持
            Frame.AreaFFlag = 0;
            oFrame.FrameDispStype = 0x03;    //边框显示方式0x00 –闪烁 0x01 –顺时针转动 0x02 –逆时针转动 0x03 –闪烁加顺时针转动 0x04 –闪烁加逆时针转动 0x05 –红绿交替闪烁 0x06 –红绿交替转动 0x07 –静止打出
            oFrame.FrameDispSpeed = 0x10;    //边框显示速度
            oFrame.FrameMoveStep = 0x01;     //边框移动步长，单位为点，此参 数范围为 1~16 
            oFrame.FrameUnitLength = 2;   //边框组元长度
            oFrame.FrameUnitWidth = 2;    //边框组元宽度
            oFrame.FrameDirectDispBit = 0;//上下左右边框显示标志位，目前只支持6QX-M卡 
            Frame.oAreaFrame = oFrame;
            Frame.pStrFramePathFile = Encoding.Default.GetBytes("F:\\黄10.png");//Class1.BytesToIntptr(Encoding.Default.GetBytes("F:\\黄10.png"));

            bxdualsdk.DynamicAreaBaseInfo_5G pheader = new bxdualsdk.DynamicAreaBaseInfo_5G();
            pheader.nType = 0x01;
            pheader.DisplayMode = DisplayMode;
            pheader.ClearMode = 0x01;
            pheader.Speed = Speed;
            pheader.StayTime = StayTime;
            pheader.RepeatTime = RepeatTime;
            pheader.oFont.arrMode = arrMode;
            pheader.oFont.fontSize = fontSize;
            pheader.oFont.color = color;
            pheader.oFont.fontBold = fontBold;
            pheader.oFont.fontItalic = fontItalic;
            pheader.oFont.tdirection = tdirection;
            pheader.oFont.txtSpace = txtSpace;
            pheader.oFont.Valign = Valign;
            pheader.oFont.Halign = Halign;
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("宋体");
            pheader.fontName = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, pheader.fontName, Font.Length);
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("111111\0");
            pheader.strAreaTxtContent = Marshal.AllocHGlobal(str.Length);
            Marshal.Copy(str, 0, pheader.strAreaTxtContent, str.Length);
            byte[] img = Encoding.GetEncoding("GBK").GetBytes("123.png\0");
            pheader.filePath = Marshal.AllocHGlobal(img.Length);
            Marshal.Copy(img, 0, pheader.filePath, img.Length);
            bxdualsdk.DynamicAreaBaseInfo_5G pheader1 = new bxdualsdk.DynamicAreaBaseInfo_5G();
            pheader1.nType = 0x02;
            pheader1.DisplayMode = DisplayMode;
            pheader1.ClearMode = 0x01;
            pheader1.Speed = Speed;
            pheader1.StayTime = StayTime;
            pheader1.RepeatTime = RepeatTime;
            pheader1.oFont.arrMode = arrMode;
            pheader1.oFont.fontSize = fontSize;
            pheader1.oFont.color = color;
            pheader1.oFont.fontBold = fontBold;
            pheader1.oFont.fontItalic = fontItalic;
            pheader1.oFont.tdirection = tdirection;
            pheader1.oFont.txtSpace = txtSpace;
            pheader1.oFont.Valign = Valign;
            pheader1.oFont.Halign = Halign;
            pheader.fontName = Marshal.AllocHGlobal(Font.Length);
            Marshal.Copy(Font, 0, pheader.fontName, Font.Length);
            byte[] str1 = Encoding.GetEncoding("GBK").GetBytes("111111\0");
            pheader.strAreaTxtContent = Marshal.AllocHGlobal(str1.Length);
            Marshal.Copy(str1, 0, pheader.strAreaTxtContent, str1.Length);
            byte[] img1 = Encoding.GetEncoding("GBK").GetBytes("123.png\0");
            pheader.filePath = Marshal.AllocHGlobal(img1.Length);
            Marshal.Copy(img1, 0, pheader.filePath, img1.Length);
            bxdualsdk.DynamicAreaBaseInfo_5G[] Params = new bxdualsdk.DynamicAreaBaseInfo_5G[2];
            Params[0] = pheader;
            Params[1] = pheader1;
            //网口
            if (true)
            {
                err = bxdualsdk.bxDual_dynamicArea_AddAreaInfos_6G_V2(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_THREE, AreaId, RunMode, Timeout, RelateAllPro,
             RelateProNum, RelateProSerial, ImmePlay, AreaX, AreaY, Width, Height, Frame, 1, Params, ref stSoundData);//(byte)Params.Length
            }
            //串口
            if (false)
            {
                bxdualsdk.EQareaframeHeader Frame1 = new bxdualsdk.EQareaframeHeader();
                Frame1.AreaFFlag = 0;
                Frame1.AreaFDispStyle = 0x03;
                Frame1.AreaFDispSpeed = 0x10;
                Frame1.AreaFMoveStep = 0x01;
                Frame1.AreaFWidth = 2;
                Frame1.AreaFBackup = 0;
                err = bxdualsdk.bxDual_dynamicArea_AddAreaInfos_6G_V2_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, RunMode, Timeout, RelateAllPro,
             RelateProNum, RelateProSerial, ImmePlay, AreaX, AreaY, Width, Height, Frame1, (byte)Params.Length, Params);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaInfos_6G_V2 = " + err);
        }
    }
}

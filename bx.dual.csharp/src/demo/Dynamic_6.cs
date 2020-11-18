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
        public static byte[] fontName = Encoding.GetEncoding("GBK").GetBytes("宋体");
        //字体大小
        public static byte FontSize = 28;
        //要显示的文本内容
        public static byte[] strAreaTxtContent = Encoding.GetEncoding("GBK").GetBytes("测试123-测试123");
        //要显示的图片 只支持png类型，图片像素大小和区域坐标1：1，一般黑底红字
        byte[] img1 = Encoding.GetEncoding("GBK").GetBytes("0.png");

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
            //网口
            if (true)
            {
                err = bxdualsdk.bxDual_dynamicArea_AddAreaTxtDetails_6G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, ref aheader, ref pheader, fontName, strAreaTxtContent);
            }
            //串口
            if (false)
            {
                err = bxdualsdk.bxDual_dynamicArea_AddAreaTxtDetails_6G_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, ref aheader, ref pheader, fontName, strAreaTxtContent);
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
            //网口
            if (true)
            {
                err = bxdualsdk.bxDual_dynamicArea_AddAreaTxtDetails_6G(Program.ip, Program.port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, ref aheader, ref pheader, fontName, strAreaTxtContent);
            }
            //串口
            if (false)
            {
                err = bxdualsdk.bxDual_dynamicArea_AddAreaTxtDetails_6G_Serial(Program.com, Program.baudRate, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, ref aheader, ref pheader, fontName, strAreaTxtContent);
            }
            Console.WriteLine("bxDual_dynamicArea_AddAreaTxtDetails_6G:" + err);
        }
        //单区域图片
        public static void dynamicArea_png(byte[] ip, ushort port)
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
            err = bxdualsdk.bxDual_dynamicArea_AddAreaPic_6G(ip, port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, AreaId, AreaX, AreaY,
                                                      Width, Height,ref pheader, strAreaTxtContent);




            //byte[] font = Encoding.Default.GetBytes("宋体");
            //bxdualsdk.EQareaHeader_G6 aheader;
            //aheader.AreaType = 0x10;
            //aheader.AreaX = 0;
            //aheader.AreaY = 0;
            //aheader.AreaWidth = 80;
            //aheader.AreaHeight = 32;
            //aheader.BackGroundFlag = 0x00;
            //aheader.Transparency = 101;
            //aheader.AreaEqual = 0x00;
            //bxdualsdk.EQSound_6G stSoundData = new bxdualsdk.EQSound_6G();
            //byte[] strSoundTxt = Encoding.GetEncoding("GB2312").GetBytes("插入ab34测试语音");
            //stSoundData.SoundFlag = 0x00;
            //stSoundData.SoundPerson = 0x01;
            //stSoundData.SoundVolum = 6;
            //stSoundData.SoundSpeed = 0x2;
            //stSoundData.SoundDataMode = 0x00;
            //stSoundData.SoundReplayTimes = 0x01;
            //stSoundData.SoundReplayDelay = 200;
            //stSoundData.SoundReservedParaLen = 0x03;
            //stSoundData.Soundnumdeal = 0x00;
            //stSoundData.Soundlanguages = 0x00;
            //stSoundData.Soundwordstyle = 0x00;
            //stSoundData.SoundDataLen = strSoundTxt.Length;
            //stSoundData.SoundData = Class1.BytesToIntptr(strSoundTxt);
            //aheader.stSoundData = stSoundData;
            //bxdualsdk.EQpageHeader_G6 pheader;
            //pheader.PageStyle = 0x00;
            //pheader.DisplayMode = 4;
            //pheader.ClearMode = 0x00;
            //pheader.Speed = 10;
            //pheader.StayTime = 0;
            //pheader.RepeatTime = 0xff;
            //pheader.ValidLen = 80;
            //pheader.CartoonFrameRate = 0x00;
            //pheader.BackNotValidFlag = 0x00;
            //pheader.arrMode = bxdualsdk.E_arrMode.eSINGLELINE;
            //pheader.fontSize = 12;
            //pheader.color = (uint)0x01;
            //pheader.fontBold = 0;
            //pheader.fontItalic = 0;
            //pheader.tdirection = bxdualsdk.E_txtDirection.pNORMAL;
            //pheader.txtSpace = 0;
            //pheader.Valign = 0;
            //pheader.Halign = 0;
            //byte[] see = Encoding.Default.GetBytes("锄禾日当午 汗滴禾下土 谁知盘中餐 粒粒");
            //err = bxdualsdk.bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G(ip, 5005, (bxdualsdk.E_ScreenColor_G56)cmb_ping_Color, 0, ref aheader, ref pheader, font, see, 0, null);
            //err = bxdualsdk.bxDual_dynamicArea_AddAreaTxtDetails_6G(ip, 5005, (bxdualsdk.E_ScreenColor_G56)cmb_ping_Color, 0, ref aheader, ref pheader, font, see);
            //err = bxdualsdk.bxDual_dynamicArea_AddAreaTxtDetails_6G_Serial(com, 2, (bxdualsdk.E_ScreenColor_G56)cmb_ping_Color, 0, ref aheader, ref pheader, font, see);
            Console.WriteLine("bxDual_dynamicArea_AddAreaTxtDetails_6G:" + err);
        }
        //单区域图片文本
        public static void dynamicArea_pngandtxt(byte[] ip, ushort port)
        {
            int err = 0;
            bxdualsdk.EQareaframeHeader oFrame;
            oFrame.AreaFFlag = 0;
            oFrame.AreaFDispStyle = 0;
            oFrame.AreaFDispSpeed = 0;
            oFrame.AreaFMoveStep = 0;
            oFrame.AreaFWidth = 0;
            oFrame.AreaFBackup = 0;
            ushort RelateProNum = 0;
            ushort[] RelateProSerial = new ushort[0];

            bxdualsdk.DynamicAreaBaseInfo_5G pheader = new bxdualsdk.DynamicAreaBaseInfo_5G();
            pheader.nType = 0x01;
            pheader.DisplayMode = 4;
            pheader.ClearMode = 0x01;
            pheader.Speed = 10;
            pheader.StayTime = 100;
            pheader.RepeatTime = 1;
            pheader.oFont.arrMode = bxdualsdk.E_arrMode.eSINGLELINE;
            pheader.oFont.fontSize = 12;
            pheader.oFont.color = 1;
            pheader.oFont.fontBold = 0;
            pheader.oFont.fontItalic = 0;
            pheader.oFont.tdirection = bxdualsdk.E_txtDirection.pNORMAL;
            pheader.oFont.txtSpace = 0;
            pheader.oFont.Valign = 0;
            pheader.oFont.Halign = 0;
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes("宋体");
            pheader.fontName = Class1.BytesToIntptr(Font);
            byte[] str = Encoding.Default.GetBytes("显示内容");
            pheader.strAreaTxtContent = Class1.BytesToIntptr(str);
            byte[] img = Encoding.GetEncoding("GBK").GetBytes("1.png");
            pheader.filePath = Class1.BytesToIntptr(img);
            bxdualsdk.DynamicAreaBaseInfo_5G[] Params = new bxdualsdk.DynamicAreaBaseInfo_5G[1];
            Params[0] = pheader;

            err = bxdualsdk.bxDual_dynamicArea_AddAreaInfos_6G(ip, port, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, 0, 0, 0, 0,
             RelateProNum, RelateProSerial, 1, 0, 0, 64, 32, oFrame, 1, Params);
        
        }
        public static void dynamicArea_6()
        {
            int err = 0;
            //Console.Write("输入IP:");
            //byte[] ip = Encoding.Default.GetBytes(Console.ReadLine());
            byte[] ip = Encoding.Default.GetBytes("192.168.89.182");
            byte[] img = Encoding.Default.GetBytes("32.png");
            byte[] img1 = Encoding.Default.GetBytes("0.png");
            byte[] str = Encoding.Default.GetBytes("123456");
            byte[] str1 = Encoding.Default.GetBytes("2019-01-13 23:56:452019-01-13 23:56:452019-01-13 23:56:45");
            byte[] font = Encoding.Default.GetBytes("宋体");
            StringBuilder text = new StringBuilder();
            text.Append("预约类型\n");
            text.Append("独\0");
            bxdualsdk.EQareaHeader_G6 aheader;
            aheader.AreaType = 0x10;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = 64;
            aheader.AreaHeight = 32;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            bxdualsdk.EQareaHeader_G6 aheader1;
            aheader1.AreaType = 0x10;
            aheader1.AreaX = 1200;
            aheader1.AreaY = 0;
            aheader1.AreaWidth = 1200;
            aheader1.AreaHeight = 96;
            aheader1.BackGroundFlag = 0x00;
            aheader1.Transparency = 101;
            aheader1.AreaEqual = 0x00;
            bxdualsdk.EQareaHeader_G6 aheader2;
            aheader2.AreaType = 0x10;
            aheader2.AreaX = 2400;
            aheader2.AreaY = 0;
            aheader2.AreaWidth = 1200;
            aheader2.AreaHeight = 96;
            aheader2.BackGroundFlag = 0x00;
            aheader2.Transparency = 101;
            aheader2.AreaEqual = 0x00;
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
            aheader2.stSoundData = stSoundData;
            Random ran = new Random();
            //string str = "Hello,LED789";
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
            //删除单个动态区 zc
            //err = bxdualsdk.dynamicArea_DelArea_6G(ip, 5005, 0xff);
            //Console.WriteLine("dynamicArea_DelArea_6G = " + err);
            //单区域文本 zc
            //err = bxdualsdk.dynamicArea_AddAreaTxt_6G(ip, 5005, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_FULLCOLOR, 0, 0, 0,
            //64, 32, font, 12, str);
            //Console.WriteLine("dynamicArea_AddAreaTxt_6G = " + err);
            //单区域图片 zc
            //if (str1 % 2 == 0)
            //{
            //err = bxdualsdk.dynamicArea_AddAreaPic_6G(ip, 5005, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_FULLCOLOR, 0, 0, 0,
            //256, 128, bb, img);
            //}
            //else
            //{
            //    err = bxdualsdk.dynamicArea_AddAreaPic_6G(ip, 5005, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, 0, 0, 0,
            //        32, 32, bb, img1);
            //}
            //Console.WriteLine("dynamicArea_AddAreaPic_6G = " + err);

            //更新动态区，可设置属性 zc
            //err = bxdualsdk.dynamicArea_AddAreaTxtDetails_6G(ip, 5005, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_FULLCOLOR, 0,
            //    ref aheader, ref pheader, font, str);
            //Console.WriteLine("dynamicArea_AddAreaTxtDetails_6G = " + err);

            //关联节目 zc
            //ushort[] RelateProSerial = new ushort[1];
            //RelateProSerial[0] = 0;
            ////err = bxdualsdk.dynamicArea_AddAreaTxtDetails_6G(ip, 5005, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, 0, ref aheader, ref pheader, font, str);
            //err = bxdualsdk.dynamicArea_AddAreaTxtDetails_WithProgram_6G(ip, 5005, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, 0, aa, bb, font, str1, 1, RelateProSerial);
            //Console.WriteLine("dynamicArea_AddAreaTxtDetails_6G = " + err);


            bxdualsdk.DynamicAreaParams[] Params = new bxdualsdk.DynamicAreaParams[3];
            Params[0].uAreaId = 0;
            Params[0].oAreaHeader_G6 = aheader;
            Params[0].stPageHeader = pheader;
            Params[0].fontName = Class1.BytesToIntptr(font);
            byte[] see = Encoding.Default.GetBytes(text.ToString());
            Params[0].strAreaTxtContent = Class1.BytesToIntptr(str);
            Params[1].uAreaId = 1;
            Params[1].oAreaHeader_G6 = aheader1;
            Params[1].stPageHeader = pheader1;
            Params[1].fontName = Class1.BytesToIntptr(font);
            Params[1].strAreaTxtContent = Class1.BytesToIntptr(see);
            Params[2].uAreaId = 2;
            Params[2].oAreaHeader_G6 = aheader1;
            Params[2].stPageHeader = pheader1;
            Params[2].fontName = Class1.BytesToIntptr(font);
            Params[2].strAreaTxtContent = Class1.BytesToIntptr(see);

            //err = bxdualsdk.dynamicAreaS_AddTxtDetails_WithProgram_6G(ip, 5005, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_SINGLE, 1, Params, 0, null);
            err = bxdualsdk.bxDual_dynamicAreaS_AddTxtDetails_6G(ip, 5005, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_FULLCOLOR, 1, Params);
            err = bxdualsdk.bxDual_dynamicAreaS_AddAreaPic_6G(ip, 5005, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_FULLCOLOR, 1, Params);

            Console.WriteLine("dynamicAreaS_AddTxtDetails_6G = " + err);
            err = bxdualsdk.bxDual_dynamicArea_DelArea_6G(ip, 5005, 0xff);
            Console.WriteLine("dynamicArea_DelArea_6G = " + err);
        }
        public static void dynamicAreaimg_6()
        {
            int err = 0;
            byte[] ip = Encoding.Default.GetBytes("192.168.89.123");
            byte[] img = Encoding.Default.GetBytes("32.png");
            byte[] img1 = Encoding.Default.GetBytes("0.png");
            byte[] font = Encoding.Default.GetBytes("宋体");
            bxdualsdk.EQareaHeader_G6 aheader;
            aheader.AreaType = 0x10;
            aheader.AreaX = 576;
            aheader.AreaY = 0;
            aheader.AreaWidth = 40;
            aheader.AreaHeight = 32;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            bxdualsdk.EQareaHeader_G6 aheader1;
            aheader1.AreaType = 0x10;
            aheader1.AreaX = 40;
            aheader1.AreaY = 0;
            aheader1.AreaWidth = 40;
            aheader1.AreaHeight = 32;
            aheader1.BackGroundFlag = 0x00;
            aheader1.Transparency = 101;
            aheader1.AreaEqual = 0x00;
            bxdualsdk.EQSound_6G stSoundData = new bxdualsdk.EQSound_6G();
            stSoundData.SoundFlag = 0;
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
            byte[] t = new byte[1];
            t[0] = 0;
            stSoundData.SoundData = IntPtr.Zero;
            aheader.stSoundData = stSoundData;
            aheader1.stSoundData = stSoundData;
            Random ran = new Random();
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

            //err = bxdualsdk.dynamicArea_AddAreaPic_6G(ip, 5005, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, 0, 16, 0,
            //32, 32, bb, img);
            //Console.WriteLine("dynamicArea_AddAreaPic_6G = " + err);

            bxdualsdk.DynamicAreaParams[] Params = new bxdualsdk.DynamicAreaParams[2];
            Params[0].uAreaId = 0;
            Params[0].oAreaHeader_G6 = aheader;
            Params[0].stPageHeader = pheader;
            Params[0].fontName = Class1.BytesToIntptr(font);
            Params[0].strAreaTxtContent = Class1.BytesToIntptr(img);
            Params[1].uAreaId = 1;
            Params[1].oAreaHeader_G6 = aheader1;
            Params[1].stPageHeader = pheader1;
            Params[1].fontName = Class1.BytesToIntptr(font);
            Params[1].strAreaTxtContent = Class1.BytesToIntptr(img1);

            err = bxdualsdk.bxDual_dynamicAreaS_AddAreaPic_6G(ip, 5005, bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_FULLCOLOR, 1, Params);
            Console.WriteLine("dynamicAreaS_AddTxtDetails_6G = " + err);
            err = bxdualsdk.bxDual_dynamicArea_DelArea_6G(ip, 5005, 0xff);
            Console.WriteLine("dynamicArea_DelArea_6G = " + err);
        }


        public static void V2()
        {
            int err = 0;
            byte[] ipAdder = Encoding.GetEncoding("GBK").GetBytes("192.168.89.128");
            ushort port = 5005;
            byte ScreenColor = 2;
            byte AreaId = 0;
            string strAreaTxtContent = "1234583456789123456789\0";
            string fontName = "宋体";
            ushort AreaX = 0;
            ushort AreaY = 0;
            ushort AreaWidth = 64;
            ushort AreaHeight = 32;
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
            byte Valign = 1;
            byte Halign = 1;
            //播放优先级
            byte RunMode = 0;
            ushort Timeout = 10;
            byte PlayImmediately = 1;
            byte RelateAllPro = 1;
            ushort RelateProNum = 0;
            ushort[] RelateProSerial = new ushort[1];//RelateAllPro = 1;
                RelateProSerial[0] = 0;
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
            bxdualsdk.EQscreenframeHeader_G6 oFrame;
            Frame.AreaFFlag = 1;
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
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes(fontName);
            pheader.fontName = Class1.BytesToIntptr(Font);
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("123546\0");
            pheader.strAreaTxtContent = Class1.BytesToIntptr(str);
            byte[] img = Encoding.GetEncoding("GBK").GetBytes("123.png\0");
            pheader.filePath = Class1.BytesToIntptr(img);
            pheader.strAreaTxtContent = Class1.BytesToIntptr(str);
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
            pheader1.fontName = Class1.BytesToIntptr(Font);
            pheader1.filePath = Class1.BytesToIntptr(Encoding.GetEncoding("GBK").GetBytes("2.png"));
            pheader1.strAreaTxtContent = Class1.BytesToIntptr(Encoding.GetEncoding("GBK").GetBytes("黄.png"));
            bxdualsdk.DynamicAreaBaseInfo_5G pheader2 = new bxdualsdk.DynamicAreaBaseInfo_5G();
            pheader2.nType = 0x02;
            pheader2.DisplayMode = DisplayMode;
            pheader2.ClearMode = 0x01;
            pheader2.Speed = Speed;
            pheader2.StayTime = StayTime;
            pheader2.RepeatTime = RepeatTime;
            pheader2.oFont.arrMode = arrMode;
            pheader2.oFont.fontSize = fontSize;
            pheader2.oFont.color = color;
            pheader2.oFont.fontBold = fontBold;
            pheader2.oFont.fontItalic = fontItalic;
            pheader2.oFont.tdirection = tdirection;
            pheader2.oFont.txtSpace = txtSpace;
            pheader2.oFont.Valign = Valign;
            pheader2.oFont.Halign = Halign;
            pheader2.fontName = Class1.BytesToIntptr(Font);
            pheader2.filePath = Class1.BytesToIntptr(Encoding.GetEncoding("GBK").GetBytes("3.png"));
            pheader2.strAreaTxtContent = Class1.BytesToIntptr(Encoding.GetEncoding("GBK").GetBytes("红.png"));
            bxdualsdk.DynamicAreaBaseInfo_5G pheader3 = new bxdualsdk.DynamicAreaBaseInfo_5G();
            pheader3.nType = 0x02;
            pheader3.DisplayMode = DisplayMode;
            pheader3.ClearMode = 0x01;
            pheader3.Speed = Speed;
            pheader3.StayTime = StayTime;
            pheader3.RepeatTime = RepeatTime;
            pheader3.oFont.arrMode = arrMode;
            pheader3.oFont.fontSize = fontSize;
            pheader3.oFont.color = color;
            pheader3.oFont.fontBold = fontBold;
            pheader3.oFont.fontItalic = fontItalic;
            pheader3.oFont.tdirection = tdirection;
            pheader3.oFont.txtSpace = txtSpace;
            pheader3.oFont.Valign = Valign;
            pheader3.oFont.Halign = Halign;
            pheader3.fontName = Class1.BytesToIntptr(Font);
            pheader3.filePath = Class1.BytesToIntptr(Encoding.GetEncoding("GBK").GetBytes("4.png"));
            pheader3.strAreaTxtContent = Class1.BytesToIntptr(Encoding.GetEncoding("GBK").GetBytes("红.png"));
            bxdualsdk.DynamicAreaBaseInfo_5G pheader4 = new bxdualsdk.DynamicAreaBaseInfo_5G();
            pheader4.nType = 0x02;
            pheader4.DisplayMode = DisplayMode;
            pheader4.ClearMode = 0x01;
            pheader4.Speed = Speed;
            pheader4.StayTime = StayTime;
            pheader4.RepeatTime = RepeatTime;
            pheader4.oFont.arrMode = arrMode;
            pheader4.oFont.fontSize = fontSize;
            pheader4.oFont.color = color;
            pheader4.oFont.fontBold = fontBold;
            pheader4.oFont.fontItalic = fontItalic;
            pheader4.oFont.tdirection = tdirection;
            pheader4.oFont.txtSpace = txtSpace;
            pheader4.oFont.Valign = Valign;
            pheader4.oFont.Halign = Halign;
            pheader4.fontName = Class1.BytesToIntptr(Font);
            pheader4.filePath = Class1.BytesToIntptr(Encoding.GetEncoding("GBK").GetBytes("a.png"));
            pheader4.strAreaTxtContent = Class1.BytesToIntptr(Encoding.GetEncoding("GBK").GetBytes("红.png"));
            bxdualsdk.DynamicAreaBaseInfo_5G pheader5 = new bxdualsdk.DynamicAreaBaseInfo_5G();
            pheader5.nType = 0x02;
            pheader5.DisplayMode = DisplayMode;
            pheader5.ClearMode = 0x01;
            pheader5.Speed = Speed;
            pheader5.StayTime = StayTime;
            pheader5.RepeatTime = RepeatTime;
            pheader5.oFont.arrMode = arrMode;
            pheader5.oFont.fontSize = fontSize;
            pheader5.oFont.color = color;
            pheader5.oFont.fontBold = fontBold;
            pheader5.oFont.fontItalic = fontItalic;
            pheader5.oFont.tdirection = tdirection;
            pheader5.oFont.txtSpace = txtSpace;
            pheader5.oFont.Valign = Valign;
            pheader5.oFont.Halign = Halign;
            pheader5.fontName = Class1.BytesToIntptr(Font);
            pheader5.filePath = Class1.BytesToIntptr(Encoding.GetEncoding("GBK").GetBytes("b.png"));
            pheader5.strAreaTxtContent = Class1.BytesToIntptr(Encoding.GetEncoding("GBK").GetBytes("红.png"));
            bxdualsdk.DynamicAreaBaseInfo_5G[] Params = new bxdualsdk.DynamicAreaBaseInfo_5G[6];
            Params[0] = pheader;
            Params[1] = pheader1;
            Params[2] = pheader2;
            Params[3] = pheader3;
            Params[4] = pheader4;
            Params[5] = pheader5;


            err = bxdualsdk.bxDual_dynamicArea_AddAreaInfos_6G_V2(ipAdder, port, (bxdualsdk.E_ScreenColor_G56)ScreenColor, AreaId, RunMode, Timeout, RelateAllPro,
             RelateProNum, RelateProSerial, PlayImmediately, AreaX, AreaY, AreaWidth, AreaHeight, Frame, 1, Params,ref stSoundData);
            Console.WriteLine("bxDual_dynamicArea_AddAreaInfos_6G_V2 = " + err);
            
            Console.WriteLine("bxDual_dynamicArea_AddAreaInfos_6G_V2 = " + err);
            err = bxdualsdk.bxDual_dynamicArea_DelArea_6G(ipAdder, 5005, 0xff);
            //Console.WriteLine("dynamicArea_DelArea_6G = " + err);
        }
        public static void V21()
        {
            int err = 0;
            byte[] ipAdder = Encoding.GetEncoding("GBK").GetBytes("192.168.89.121");
            ushort port = 5005;
            byte ScreenColor = 2;
            byte AreaId = 0;
            string strAreaTxtContent = "1234583456789123456789\0";
            string fontName = "宋体";
            ushort AreaX = 0;
            ushort AreaY = 0;
            ushort AreaWidth = 64;
            ushort AreaHeight = 32;
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
            //播放优先级
            byte RunMode = 0;
            ushort Timeout = 10;
            byte PlayImmediately = 1;
            byte RelateAllPro = 1;
            ushort RelateProNum = 0;
            ushort[] RelateProSerial = new ushort[1];//RelateAllPro = 1;
            RelateProSerial[0] = 0;
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
            bxdualsdk.EQscreenframeHeader_G6 oFrame;
            Frame.AreaFFlag = 1;
            oFrame.FrameDispStype = 0x03;    //边框显示方式0x00 –闪烁 0x01 –顺时针转动 0x02 –逆时针转动 0x03 –闪烁加顺时针转动 0x04 –闪烁加逆时针转动 0x05 –红绿交替闪烁 0x06 –红绿交替转动 0x07 –静止打出
            oFrame.FrameDispSpeed = 0x10;    //边框显示速度
            oFrame.FrameMoveStep = 0x01;     //边框移动步长，单位为点，此参 数范围为 1~16 
            oFrame.FrameUnitLength = 2;   //边框组元长度
            oFrame.FrameUnitWidth = 2;    //边框组元宽度
            oFrame.FrameDirectDispBit = 0;//上下左右边框显示标志位，目前只支持6QX-M卡 
            Frame.oAreaFrame = oFrame;
            Frame.pStrFramePathFile = Encoding.Default.GetBytes("F:\\黄10.png");// Class1.BytesToIntptr(Encoding.Default.GetBytes("F:\\黄10.png"));

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
            byte[] Font = Encoding.GetEncoding("GBK").GetBytes(fontName);
            pheader.fontName = Class1.BytesToIntptr(Font);
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("111111\0");
            pheader.strAreaTxtContent = Class1.BytesToIntptr(str);
            byte[] img = Encoding.GetEncoding("GBK").GetBytes("123.png\0");
            pheader.filePath = Class1.BytesToIntptr(img);
            pheader.strAreaTxtContent = Class1.BytesToIntptr(str);
            bxdualsdk.DynamicAreaBaseInfo_5G[] Params = new bxdualsdk.DynamicAreaBaseInfo_5G[1];
            Params[0] = pheader;


            err = bxdualsdk.bxDual_dynamicArea_AddAreaInfos_6G_V2(ipAdder, port, (bxdualsdk.E_ScreenColor_G56)ScreenColor, AreaId, RunMode, Timeout, RelateAllPro,
             RelateProNum, RelateProSerial, PlayImmediately, AreaX, AreaY, AreaWidth, AreaHeight, Frame, 1, Params, ref stSoundData);
            Console.WriteLine("bxDual_dynamicArea_AddAreaInfos_6G_V2 = " + err);

            Console.WriteLine("bxDual_dynamicArea_AddAreaInfos_6G_V2 = " + err);
            err = bxdualsdk.bxDual_dynamicArea_DelArea_6G(ipAdder, 5005, 0xff);
            //Console.WriteLine("dynamicArea_DelArea_6G = " + err);
        }
    }
}

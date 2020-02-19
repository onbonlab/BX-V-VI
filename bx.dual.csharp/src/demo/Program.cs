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
        static void Main(string[] args)
        {
            int err = bx_sdk_dual.bxDual_InitSdk();
            byte[] ip = Encoding.GetEncoding("GBK").GetBytes("192.168.89.182");
            //dynamicArea_6();
            bx_sdk_dual.Ping_data data = new bx_sdk_dual.Ping_data();
            err = bx_sdk_dual.bxDual_cmd_tcpPing(ip, 5005, ref data);
            Console.WriteLine("ControllerType:0x" + data.ControllerType.ToString("X2"));
            Console.WriteLine("FirmwareVersion:V" + System.Text.Encoding.Default.GetString(data.FirmwareVersion));
            Console.WriteLine("ipAdder:" + System.Text.Encoding.Default.GetString(data.ipAdder));
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }
            Console.WriteLine("\r\n");
            err = bx_sdk_dual.bxDual_program_setScreenParams_G56((bx_sdk_dual.E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, bx_sdk_dual.E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
            Console.WriteLine("program_setScreenParams_G56:" + err);
            Creat_Program_6();
            Creat_Area_6(0, 16, 0, 64, 32, 0);
            Creat_AddStr_6(0, "Καλώς ", "Arial");
            //Creat_AddStr_6(0, "Välkommen.", "微软雅黑");
            Net_SengProgram_6(ip);
            //BX-5 发送节目
            {
                Creat_Program_5();
                Creat_Area_5(2, 0, 0, 80, 32, 0);
                Creat_Addtime_5(0);
                Net_SengProgram_5(ip);
            }
            //BX-5 发送动态区
            {
                dynamicArea_5();
            }
            //BX-6 发送节目
            {
                Creat_Program_6();
                Creat_Area_6(0, 16, 0, 64, 32, 0);
                Creat_AddStr_6(0, "卡了是的","宋体");
                Net_SengProgram_6(ip);
            }
            //BX-6 发送动态区
            {
                dynamicArea_6();
                dynamicAreaimg_6();
            }

            bx_sdk_dual.bxDual_ReleaseSdk();
            Console.ReadKey();
        }
        public static void Net_FILELIST(byte[] ip)
        {
            byte[] DirBlock = new byte[Marshal.SizeOf(typeof(bx_sdk_dual.GetDirBlock_G56))];
            bx_sdk_dual.GetDirBlock_G56 driBlock;
            int err = bx_sdk_dual.bxDual_cmd_ofsReedDirBlock(ip, 5005, DirBlock);
            IntPtr dec = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.GetDirBlock_G56)));
            Marshal.Copy(DirBlock, Marshal.SizeOf(typeof(bx_sdk_dual.GetDirBlock_G56)) * 0, dec, Marshal.SizeOf(typeof(bx_sdk_dual.GetDirBlock_G56)));
            driBlock = (bx_sdk_dual.GetDirBlock_G56)Marshal.PtrToStructure(dec, typeof(bx_sdk_dual.GetDirBlock_G56));
            Marshal.FreeHGlobal(dec);
            Console.WriteLine("fileNumber:" + driBlock.fileNumber);
            Console.WriteLine("dataAddre:" + driBlock.dataAddre);
            Console.WriteLine("\r\n");

            for (int i = 0; i < driBlock.fileNumber; i++)
            {
                byte[] FileAttribute = new byte[Marshal.SizeOf(typeof(bx_sdk_dual.FileAttribute_G56))];
                bx_sdk_dual.FileAttribute_G56 fileAttr;
                err = bx_sdk_dual.bxDual_cmd_getFileAttr(DirBlock, i, FileAttribute);
                dec = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.FileAttribute_G56)));
                Marshal.Copy(FileAttribute, Marshal.SizeOf(typeof(bx_sdk_dual.FileAttribute_G56)) * 0, dec, Marshal.SizeOf(typeof(bx_sdk_dual.FileAttribute_G56)));
                fileAttr = (bx_sdk_dual.FileAttribute_G56)Marshal.PtrToStructure(dec, typeof(bx_sdk_dual.FileAttribute_G56));
                Marshal.FreeHGlobal(dec);
                Console.WriteLine("fileName:" + Encoding.Default.GetString(fileAttr.fileName));
                Console.WriteLine("fileType:" + fileAttr.fileType);
                Console.WriteLine("fileLen:" + fileAttr.fileLen);
                Console.WriteLine("fileCRC:" + fileAttr.fileCRC);
                Console.WriteLine("\r\n");

                err = bx_sdk_dual.bxDual_cmd_ofsDeleteFormatFile(ip, 5005, 1, Encoding.Default.GetString(fileAttr.fileName));
            }
        }
        //网口搜索
        public static void Net_search()
        {
            byte[] arrPointer = new byte[Marshal.SizeOf(typeof(bx_sdk_dual.Ping_data))];
            bx_sdk_dual.Ping_data data;
            int err = bx_sdk_dual.bxDual_cmd_udpPing(arrPointer);
            IntPtr dec = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.Ping_data)));
            Marshal.Copy(arrPointer, Marshal.SizeOf(typeof(bx_sdk_dual.Ping_data)) * 0, dec, Marshal.SizeOf(typeof(bx_sdk_dual.Ping_data)));
            data = (bx_sdk_dual.Ping_data)Marshal.PtrToStructure(dec, typeof(bx_sdk_dual.Ping_data));
            Marshal.FreeHGlobal(dec);
            Console.WriteLine("ControllerType:0x" + data.ControllerType.ToString("X2"));
            Console.WriteLine("FirmwareVersion:V" + System.Text.Encoding.Default.GetString(data.FirmwareVersion));
            Console.WriteLine("ipAdder:" + System.Text.Encoding.Default.GetString(data.ipAdder));
            Console.WriteLine("\r\n");
        }

        //串口搜索
        public static void COM_search()
        {
            byte[] COMPort = Encoding.Default.GetBytes("COM7");
            byte[] arrPointer = new byte[Marshal.SizeOf(typeof(bx_sdk_dual.Ping_data))];
            bx_sdk_dual.Ping_data data;
            int ret = bx_sdk_dual.bxDual_cmd_uart_searchController(arrPointer, COMPort);
            IntPtr dec = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.Ping_data)));
            Marshal.Copy(arrPointer, Marshal.SizeOf(typeof(bx_sdk_dual.Ping_data)) * 0, dec, Marshal.SizeOf(typeof(bx_sdk_dual.Ping_data)));
            data = (bx_sdk_dual.Ping_data)Marshal.PtrToStructure(dec, typeof(bx_sdk_dual.Ping_data));
            Marshal.FreeHGlobal(dec);
            Console.WriteLine("ControllerType:0x" + data.ControllerType.ToString("X2"));
            Console.WriteLine("FirmwareVersion:V" + System.Text.Encoding.Default.GetString(data.FirmwareVersion));
            Console.WriteLine("ipAdder:" + System.Text.Encoding.Default.GetString(data.ipAdder));
            Console.WriteLine("\r\n");
        }

        //更新动态区
        public static void dynamicArea_6()
        {
            int err = 0;
            //Console.Write("输入IP:");
            //byte[] ip = Encoding.Default.GetBytes(Console.ReadLine());
            byte[] ip = Encoding.Default.GetBytes("192.168.89.182");
            byte[] img = Encoding.Default.GetBytes("32.png");
            byte[] img1 = Encoding.Default.GetBytes("0.png");
            byte[] str = Encoding.Default.GetBytes("123456");
            byte[] str1 = Encoding.Default.GetBytes("2019-01-13 23:56:452019-01-13 23:56:452019-01-13 23:56:4555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555552019-01-13 23:56:452019-01-13 23:56:452019-01-13 23:56:455555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555");
            byte[] font = Encoding.Default.GetBytes("宋体");
            StringBuilder text = new StringBuilder();
            text.Append(" 序号  日 期  场馆名称  场地名称  项目名称  预约人   开始时间  结束时间  剩余时间  预约类型\n");
            text.Append(" 0001  10-12   网球馆   网1场地    网球     王文礼    15:00    16:00      60       独占  \n");
            text.Append(" 0002  10-12   网球馆   网1场地    网球     王文礼    16:00    17:00      60       独占  \n");
            text.Append(" 0003  10-12   网球馆   网1场地    网球     王文礼    11:00    12:00      60       独占  \n");
            text.Append(" 0004  10-12   网球馆   网1场地    网球      韩磊     12:00    13:00      60       独占  \n");
            text.Append(" 0005  10-12   网球馆   网1场地    网球      韩磊     13:00    14:00      60       独占  \0");
            bx_sdk_dual.EQareaHeader_G6 aheader;
            aheader.AreaType = 0x10;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = 64;
            aheader.AreaHeight = 32;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            bx_sdk_dual.EQareaHeader_G6 aheader1;
            aheader1.AreaType = 0x10;
            aheader1.AreaX = 1200;
            aheader1.AreaY = 0;
            aheader1.AreaWidth = 1200;
            aheader1.AreaHeight = 96;
            aheader1.BackGroundFlag = 0x00;
            aheader1.Transparency = 101;
            aheader1.AreaEqual = 0x00;
            bx_sdk_dual.EQareaHeader_G6 aheader2;
            aheader2.AreaType = 0x10;
            aheader2.AreaX = 2400;
            aheader2.AreaY = 0;
            aheader2.AreaWidth = 1200;
            aheader2.AreaHeight = 96;
            aheader2.BackGroundFlag = 0x00;
            aheader2.Transparency = 101;
            aheader2.AreaEqual = 0x00;
            bx_sdk_dual.EQSound_6G stSoundData = new bx_sdk_dual.EQSound_6G();
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
            stSoundData.SoundData = BytesToIntptr(strSoundTxt);

            aheader.stSoundData = stSoundData;
            aheader1.stSoundData = stSoundData;
            aheader2.stSoundData = stSoundData;
            Random ran = new Random();
            //string str = "Hello,LED789";
            bx_sdk_dual.EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 4;
            pheader.ClearMode = 0x00;
            pheader.Speed = 5;
            pheader.StayTime = 100;
            pheader.RepeatTime = 1;
            pheader.ValidLen = 0;
            pheader.CartoonFrameRate = 0x00;
            pheader.BackNotValidFlag = 0x00;
            pheader.arrMode = bx_sdk_dual.E_arrMode.eMULTILINE;
            pheader.fontSize = 14;
            pheader.color = (uint)0x01;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = bx_sdk_dual.E_txtDirection.pNORMAL;
            pheader.txtSpace = 0;
            pheader.Valign = 1;
            pheader.Halign = 1;
            IntPtr aa = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.EQareaHeader_G6)));
            Marshal.StructureToPtr(aheader, aa, false);
            IntPtr bb = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.EQpageHeader_G6)));
            Marshal.StructureToPtr(pheader, bb, false);
            bx_sdk_dual.EQpageHeader_G6 pheader1;
            pheader1.PageStyle = 0x00;
            pheader1.DisplayMode = 0x03;
            pheader1.ClearMode = 0x01;
            pheader1.Speed = 15;
            pheader1.StayTime = 500;
            pheader1.RepeatTime = 1;
            pheader1.ValidLen = 0;
            pheader1.CartoonFrameRate = 0x00;
            pheader1.BackNotValidFlag = 0x00;
            pheader1.arrMode = bx_sdk_dual.E_arrMode.eSINGLELINE;
            pheader1.fontSize = 18;
            pheader1.color = (uint)0x01;
            pheader1.fontBold = 0;
            pheader1.fontItalic = 0;
            pheader1.tdirection = bx_sdk_dual.E_txtDirection.pNORMAL;
            pheader1.txtSpace = 0;
            pheader1.Valign = 1;
            pheader1.Halign = 0;
            IntPtr aa1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.EQareaHeader_G6)));
            Marshal.StructureToPtr(aheader1, aa1, false);
            IntPtr bb1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.EQpageHeader_G6)));
            Marshal.StructureToPtr(pheader1, bb1, false);
            //删除单个动态区 zc
            //err = bx_sdk_dual.dynamicArea_DelArea_6G(ip, 5005, 0xff);
            //Console.WriteLine("dynamicArea_DelArea_6G = " + err);
            //单区域文本 zc
            //err = bx_sdk_dual.dynamicArea_AddAreaTxt_6G(ip, 5005, bx_sdk_dual.E_ScreenColor_G56.eSCREEN_COLOR_FULLCOLOR, 0, 0, 0,
            //64, 32, font, 12, str);
            //Console.WriteLine("dynamicArea_AddAreaTxt_6G = " + err);
            //单区域图片 zc
            //if (str1 % 2 == 0)
            //{
            //err = bx_sdk_dual.dynamicArea_AddAreaPic_6G(ip, 5005, bx_sdk_dual.E_ScreenColor_G56.eSCREEN_COLOR_FULLCOLOR, 0, 0, 0,
            //256, 128, bb, img);
            //}
            //else
            //{
            //    err = bx_sdk_dual.dynamicArea_AddAreaPic_6G(ip, 5005, bx_sdk_dual.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, 0, 0, 0,
            //        32, 32, bb, img1);
            //}
            //Console.WriteLine("dynamicArea_AddAreaPic_6G = " + err);

            //更新动态区，可设置属性 zc
            //err = bx_sdk_dual.dynamicArea_AddAreaTxtDetails_6G(ip, 5005, bx_sdk_dual.E_ScreenColor_G56.eSCREEN_COLOR_FULLCOLOR, 0,
            //    ref aheader, ref pheader, font, str);
            //Console.WriteLine("dynamicArea_AddAreaTxtDetails_6G = " + err);

            //关联节目 zc
            //ushort[] RelateProSerial = new ushort[1];
            //RelateProSerial[0] = 0;
            ////err = bx_sdk_dual.dynamicArea_AddAreaTxtDetails_6G(ip, 5005, bx_sdk_dual.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, 0, ref aheader, ref pheader, font, str);
            //err = bx_sdk_dual.dynamicArea_AddAreaTxtDetails_WithProgram_6G(ip, 5005, bx_sdk_dual.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, 0, aa, bb, font, str1, 1, RelateProSerial);
            //Console.WriteLine("dynamicArea_AddAreaTxtDetails_6G = " + err);


            bx_sdk_dual.DynamicAreaParams[] Params = new bx_sdk_dual.DynamicAreaParams[3];
            Params[0].uAreaId = 0;
            Params[0].oAreaHeader_G6 = aheader;
            Params[0].stPageHeader = pheader;
            Params[0].fontName = BytesToIntptr(font);
            byte[] see = Encoding.Default.GetBytes(text.ToString());
            Params[0].strAreaTxtContent = BytesToIntptr(str);
            Params[1].uAreaId = 1;
            Params[1].oAreaHeader_G6 = aheader1;
            Params[1].stPageHeader = pheader1;
            Params[1].fontName = BytesToIntptr(font);
            Params[1].strAreaTxtContent = BytesToIntptr(see);
            Params[2].uAreaId = 2;
            Params[2].oAreaHeader_G6 = aheader1;
            Params[2].stPageHeader = pheader1;
            Params[2].fontName = BytesToIntptr(font);
            Params[2].strAreaTxtContent = BytesToIntptr(see);

            //err = bx_sdk_dual.dynamicAreaS_AddTxtDetails_WithProgram_6G(ip, 5005, bx_sdk_dual.E_ScreenColor_G56.eSCREEN_COLOR_SINGLE, 1, Params, 0, null);
            err = bx_sdk_dual.bxDual_dynamicAreaS_AddTxtDetails_6G(ip, 5005, bx_sdk_dual.E_ScreenColor_G56.eSCREEN_COLOR_FULLCOLOR, 1, Params);
           // err = bx_sdk_dual.dynamicAreaS_AddAreaPic_6G(ip, 5005, bx_sdk_dual.E_ScreenColor_G56.eSCREEN_COLOR_FULLCOLOR, 1, Params);

            Console.WriteLine("dynamicAreaS_AddTxtDetails_6G = " + err);
            err = bx_sdk_dual.bxDual_dynamicArea_DelArea_6G(ip, 5005, 0xff);
            Console.WriteLine("dynamicArea_DelArea_6G = " + err);
        }
        public static void dynamicAreaimg_6()
        {
            int err = 0;
            byte[] ip = Encoding.Default.GetBytes("192.168.89.182");
            byte[] img = Encoding.Default.GetBytes("32.png");
            byte[] img1 = Encoding.Default.GetBytes("0.png");
            byte[] font = Encoding.Default.GetBytes("宋体");
            bx_sdk_dual.EQareaHeader_G6 aheader;
            aheader.AreaType = 0x10;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = 40;
            aheader.AreaHeight = 32;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            bx_sdk_dual.EQareaHeader_G6 aheader1;
            aheader1.AreaType = 0x10;
            aheader1.AreaX = 40;
            aheader1.AreaY = 0;
            aheader1.AreaWidth = 40;
            aheader1.AreaHeight = 32;
            aheader1.BackGroundFlag = 0x00;
            aheader1.Transparency = 101;
            aheader1.AreaEqual = 0x00;
            bx_sdk_dual.EQSound_6G stSoundData = new bx_sdk_dual.EQSound_6G();
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
            bx_sdk_dual.EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 4;
            pheader.ClearMode = 0x00;
            pheader.Speed = 15;
            pheader.StayTime = 0;
            pheader.RepeatTime = 1;
            pheader.ValidLen = 0;
            pheader.CartoonFrameRate = 0x00;
            pheader.BackNotValidFlag = 0x00;
            pheader.arrMode = bx_sdk_dual.E_arrMode.eSINGLELINE;
            pheader.fontSize = 12;
            pheader.color = (uint)0x01;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = bx_sdk_dual.E_txtDirection.pNORMAL;
            pheader.txtSpace = 0;
            pheader.Valign = 1;
            pheader.Halign = 1;
            IntPtr aa = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.EQareaHeader_G6)));
            Marshal.StructureToPtr(aheader, aa, false);
            IntPtr bb = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.EQpageHeader_G6)));
            Marshal.StructureToPtr(pheader, bb, false);
            bx_sdk_dual.EQpageHeader_G6 pheader1;
            pheader1.PageStyle = 0x00;
            pheader1.DisplayMode = 0x03;
            pheader1.ClearMode = 0x01;
            pheader1.Speed = 15;
            pheader1.StayTime = 500;
            pheader1.RepeatTime = 1;
            pheader1.ValidLen = 0;
            pheader1.CartoonFrameRate = 0x00;
            pheader1.BackNotValidFlag = 0x00;
            pheader1.arrMode = bx_sdk_dual.E_arrMode.eSINGLELINE;
            pheader1.fontSize = 18;
            pheader1.color = (uint)0x01;
            pheader1.fontBold = 0;
            pheader1.fontItalic = 0;
            pheader1.tdirection = bx_sdk_dual.E_txtDirection.pNORMAL;
            pheader1.txtSpace = 0;
            pheader1.Valign = 1;
            pheader1.Halign = 0;
            IntPtr aa1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.EQareaHeader_G6)));
            Marshal.StructureToPtr(aheader1, aa1, false);
            IntPtr bb1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.EQpageHeader_G6)));
            Marshal.StructureToPtr(pheader1, bb1, false);

            //err = bx_sdk_dual.dynamicArea_AddAreaPic_6G(ip, 5005, bx_sdk_dual.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, 0, 16, 0,
            //32, 32, bb, img);
            //Console.WriteLine("dynamicArea_AddAreaPic_6G = " + err);

            bx_sdk_dual.DynamicAreaParams[] Params = new bx_sdk_dual.DynamicAreaParams[2];
            Params[0].uAreaId = 0;
            Params[0].oAreaHeader_G6 = aheader;
            Params[0].stPageHeader = pheader;
            Params[0].fontName = BytesToIntptr(font);
            Params[0].strAreaTxtContent = BytesToIntptr(img);
            Params[1].uAreaId = 1;
            Params[1].oAreaHeader_G6 = aheader1;
            Params[1].stPageHeader = pheader1;
            Params[1].fontName = BytesToIntptr(font);
            Params[1].strAreaTxtContent = BytesToIntptr(img1);

            err = bx_sdk_dual.bxDual_dynamicAreaS_AddAreaPic_6G(ip, 5005, bx_sdk_dual.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, 2, Params);
            Console.WriteLine("dynamicAreaS_AddTxtDetails_6G = " + err);
            err = bx_sdk_dual.bxDual_dynamicArea_DelArea_6G(ip, 5005, 0xff);
            Console.WriteLine("dynamicArea_DelArea_6G = " + err);
        }

        //byte[]转换为Intptr
        public static IntPtr BytesToIntptr(byte[] bytes)
        {
            int size = bytes.Length;
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(bytes, 0, buffer, size);
                return buffer;
            }
            finally
            {
                //Marshal.FreeHGlobal(buffer);
            }
        }
        public static void dynamicArea_5()
        {
            int err = 0;
            //Console.Write("输入IP:");
            //byte[] ip = Encoding.Default.GetBytes(Console.ReadLine());
            byte[] ip = Encoding.Default.GetBytes("192.168.89.182");
            //删除单个动态区 zc
            err = bx_sdk_dual.bxDual_dynamicArea_DelArea_5G(ip, 5005, 0xff);
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
            bx_sdk_dual.EQareaframeHeader oFrame;
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
            bx_sdk_dual.EQfontData oFont;

            oFont.arrMode = bx_sdk_dual.E_arrMode.eMULTILINE;
            oFont.fontSize = 10;
            oFont.color = 1;
            oFont.fontBold = 0;
            oFont.fontItalic = 0; oFont.tdirection = bx_sdk_dual.E_txtDirection.pNORMAL; oFont.txtSpace = 0; oFont.Halign = 1; oFont.Valign = 2;
            byte[] fontName = Encoding.Default.GetBytes("宋体");
            byte[] strAreaTxtContent = Encoding.Default.GetBytes("111测试");
            err = bx_sdk_dual.bxDual_dynamicArea_AddAreaWithTxt_5G(ip, 5005, bx_sdk_dual.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                            ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime, oFont, fontName, strAreaTxtContent);
            Console.WriteLine("dynamicArea_AddAreaWithTxt_5G = " + err);
            //单区域图片 zc
            byte[] filePath = Encoding.Default.GetBytes("32.png");
            err = bx_sdk_dual.bxDual_dynamicArea_AddAreaWithPic_5G(ip, 5005, bx_sdk_dual.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, uAreaId, RunMode, Timeout, RelateAllPro, RelateProNum, RelateProSerial,
                            ImmePlay, uAreaX, uAreaY, uWidth, uHeight, oFrame, DisplayMode, ClearMode, Speed, StayTime, RepeatTime,filePath);
            Console.WriteLine("dynamicArea_AddAreaWithPic_5G = " + err);


        }
        public static void deleteprogram()
        {
            byte[] ip = Encoding.Default.GetBytes("192.168.89.105");
            //获取节目列表
            byte[] arrPointer = new byte[Marshal.SizeOf(typeof(bx_sdk_dual.GetDirBlock_G56))];
            bx_sdk_dual.GetDirBlock_G56 driBlock;
            int err = bx_sdk_dual.bxDual_cmd_ofsReedDirBlock(ip, 5005, arrPointer);
            IntPtr dec = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.GetDirBlock_G56)));
            Marshal.Copy(arrPointer, Marshal.SizeOf(typeof(bx_sdk_dual.GetDirBlock_G56)) * 0, dec, Marshal.SizeOf(typeof(bx_sdk_dual.GetDirBlock_G56)));
            driBlock = (bx_sdk_dual.GetDirBlock_G56)Marshal.PtrToStructure(dec, typeof(bx_sdk_dual.GetDirBlock_G56));
            Marshal.FreeHGlobal(dec);
            //获取节目详细信息
            IntPtr aa = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.GetDirBlock_G56)));
            Marshal.StructureToPtr(driBlock, aa, false);
            for (int i = 0; i < driBlock.fileNumber; i++)
            {
                byte[] fileAttrdata = new byte[Marshal.SizeOf(typeof(bx_sdk_dual.FileAttribute_G56))];
                bx_sdk_dual.FileAttribute_G56 fileAttr;
                err = bx_sdk_dual.bxDual_cmd_getFileAttr(aa, (ushort)i, fileAttrdata);
                IntPtr dec1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.FileAttribute_G56)));
                Marshal.Copy(fileAttrdata, Marshal.SizeOf(typeof(bx_sdk_dual.FileAttribute_G56)) * 0, dec1, Marshal.SizeOf(typeof(bx_sdk_dual.FileAttribute_G56)));
                fileAttr = (bx_sdk_dual.FileAttribute_G56)Marshal.PtrToStructure(dec1, typeof(bx_sdk_dual.FileAttribute_G56));
                Marshal.FreeHGlobal(dec1);
                //删除指定节目
                err = bx_sdk_dual.bxDual_cmd_ofsDeleteFormatFile(ip, 5005, 1, fileAttr.fileName);
            }
        }


        //创建节目
        public static void Creat_Program_5()
        {
            bx_sdk_dual.EQprogramHeader header;
            header.FileType = 0x00;
            header.ProgramID = 0;
            header.ProgramStyle = 0x00;
            header.ProgramPriority = 0x00;
            header.ProgramPlayTimes = 1;
            header.ProgramTimeSpan = 0;
            header.ProgramWeek = 0xff;
            header.ProgramLifeSpan_sy = 0xffff;
            header.ProgramLifeSpan_sm = 0x03;
            header.ProgramLifeSpan_sd = 0x05;
            header.ProgramLifeSpan_ey = 0xffff;
            header.ProgramLifeSpan_em = 0x04;
            header.ProgramLifeSpan_ed = 0x12;
            //header.PlayPeriodGrpNum = 0;
            IntPtr aa = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.EQprogramHeader)));
            Marshal.StructureToPtr(header, aa, false);
            int err = bx_sdk_dual.bxDual_program_addProgram(aa);
            Console.WriteLine("program_addProgram:" + err);
        }
        public static void Creat_Program_6()
        {
            bx_sdk_dual.EQprogramHeader_G6 header;
            header.FileType = 0x00;
            header.ProgramID = 0;
            header.ProgramStyle = 0x00;
            header.ProgramPriority = 0x00;
            header.ProgramPlayTimes = 1;
            header.ProgramTimeSpan = 0;
            header.SpecialFlag = 0;
            header.CommExtendParaLen = 0x00;
            header.ScheduNum = 0;
            header.LoopValue = 0;
            header.Intergrate = 0x00;
            header.TimeAttributeNum = 0x00;
            header.TimeAttribute0Offset = 0x0000;
            header.ProgramWeek = 0xff;
            header.ProgramLifeSpan_sy = 0xffff;
            header.ProgramLifeSpan_sm = 0x03;
            header.ProgramLifeSpan_sd = 0x14;
            header.ProgramLifeSpan_ey = 0xffff;
            header.ProgramLifeSpan_em = 0x03;
            header.ProgramLifeSpan_ed = 0x14;
            header.PlayPeriodGrpNum = 0;
            IntPtr aa = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.EQprogramHeader_G6)));
            Marshal.StructureToPtr(header, aa, false);
            int err = bx_sdk_dual.bxDual_program_addProgram_G6(aa);
            Console.WriteLine("program_addProgram:" + err);
        }
        //添加时段
        public static void Creat_ProgramaddPlayPeriod_5()
        {
            bx_sdk_dual.EQprogrampTime_G56 Time;
            Time.StartHour = 0x14;
            Time.StartMinute = 0x37;
            Time.StartSecond = 0x00;
            Time.EndHour = 0x14;
            Time.EndMinute = 0x38;
            Time.EndSecond = 0x00;

            bx_sdk_dual.EQprogramppGrp_G56 headerGrp;
            headerGrp.playTimeGrpNum = 1;
            headerGrp.timeGrp0 = Time;
            headerGrp.timeGrp1 = Time;
            headerGrp.timeGrp2 = Time;
            headerGrp.timeGrp3 = Time;
            headerGrp.timeGrp4 = Time;
            headerGrp.timeGrp5 = Time;
            headerGrp.timeGrp6 = Time;
            headerGrp.timeGrp7 = Time;
            int err = bx_sdk_dual.bxDual_program_addPlayPeriodGrp(ref headerGrp);
            Console.WriteLine("program_addPlayPeriodGrp:" + err);
        }
        public static void Creat_ProgramaddPlayPeriod_6()
        {
            bx_sdk_dual.EQprogrampTime_G56 Time;
            Time.StartHour = 0x10;
            Time.StartMinute=0x00;
            Time.StartSecond=0x00;
            Time.EndHour = 0x11;
            Time.EndMinute = 0x00;
            Time.EndSecond = 0x00;

            bx_sdk_dual.EQprogramppGrp_G56 headerGrp;
            headerGrp.playTimeGrpNum = 1;
            headerGrp.timeGrp0 = Time;
            headerGrp.timeGrp1 = Time;
            headerGrp.timeGrp2 = Time;
            headerGrp.timeGrp3 = Time;
            headerGrp.timeGrp4 = Time;
            headerGrp.timeGrp5 = Time;
            headerGrp.timeGrp6 = Time;
            headerGrp.timeGrp7 = Time;
            int err = bx_sdk_dual.bxDual_program_addPlayPeriodGrp_G6(ref headerGrp);
            Console.WriteLine("program_addPlayPeriodGrp:" + err);
        }
        //节目添加边框
        public static void ProgramAddFrame_5()
        {
            bx_sdk_dual.EQscreenframeHeader sfheader;
            sfheader.FrameDispFlag = 0x01;
            sfheader.FrameDispStyle = 0x01;
            sfheader.FrameDispSpeed = 0x10;
            sfheader.FrameMoveStep = 0x01;
            sfheader.FrameWidth = 2;
            sfheader.FrameBackup = 0;
            byte[] img = Encoding.Default.GetBytes("F:\\黄10.png");
            bx_sdk_dual.bxDual_program_addFrame(ref sfheader, img);
        }
        public static void ProgramAddFrame_6()
        {
            bx_sdk_dual.EQscreenframeHeader_G6 sfheader;
            sfheader.FrameDispStype = 0x01;    //边框显示方式
            sfheader.FrameDispSpeed = 0x10;    //边框显示速度
            sfheader.FrameMoveStep = 0x01;     //边框移动步长
            sfheader.FrameUnitLength=2;   //边框组元长度
            sfheader.FrameUnitWidth=2;    //边框组元宽度
            sfheader.FrameDirectDispBit=0;//上下左右边框显示标志位，目前只支持6QX-M卡 
            byte[] img = Encoding.Default.GetBytes("F:\\黄10.png");
            bx_sdk_dual.bxDual_program_addFrame_G6(ref sfheader, img);
        }
        //创建区域
        public static void Creat_Area_5(byte AreaType, ushort x, ushort y, ushort w, ushort h, ushort areaID)
        {
            bx_sdk_dual.EQareaHeader aheader;
            aheader.AreaType = AreaType;
            aheader.AreaX = x;
            aheader.AreaY = y;
            aheader.AreaWidth = w;
            aheader.AreaHeight = h;
            IntPtr bb = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.EQareaHeader)));
            Marshal.StructureToPtr(aheader, bb, false);
            int err = bx_sdk_dual.bxDual_program_AddArea(areaID, bb);  //添加图文区域
            Console.WriteLine("program_AddArea:" + err);
        }
        public static void Creat_Area_6(byte AreaType, ushort x, ushort y, ushort w, ushort h, ushort areaID)
        {
            bx_sdk_dual.EQareaHeader_G6 aheader;
            aheader.AreaType = AreaType;
            aheader.AreaX = x;
            aheader.AreaY = y;
            aheader.AreaWidth = w;
            aheader.AreaHeight = h;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            bx_sdk_dual.EQSound_6G stSoundData = new bx_sdk_dual.EQSound_6G();
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
            IntPtr bb = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.EQareaHeader_G6)));
            Marshal.StructureToPtr(aheader, bb, false);
            int err = bx_sdk_dual.bxDual_program_addArea_G6(areaID, bb);  //添加图文区域
            Console.WriteLine("program_AddArea:" + err);
        }
        //区域添加边框
        public static void AreaAddFrame_5(ushort areaID)
        {
            bx_sdk_dual.EQareaframeHeader afheader;
            afheader.AreaFFlag = 0x01;
            afheader.AreaFDispStyle = 0x01;
            afheader.AreaFDispSpeed = 0x08;
            afheader.AreaFMoveStep = 0x01;
            afheader.AreaFWidth = 3;
            afheader.AreaFBackup = 0;
            byte[] img = Encoding.Default.GetBytes("黄10.png");
            bx_sdk_dual.bxDual_program_picturesAreaAddFrame(areaID, ref afheader, img);
        }
        public static void AreaAddFrame_6(ushort areaID)
        {
        }
        //添加内容
        public static void Creat_AddStr_5(ushort areaID,string txt)
        {
            byte[] str = Encoding.Default.GetBytes(txt);
            byte[] font = Encoding.Default.GetBytes("宋体");
            //string str = "Hello,LED789";
            bx_sdk_dual.EQpageHeader pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 0x02;
            pheader.ClearMode = 0x01;
            pheader.Speed = 10;
            pheader.StayTime = 0;
            pheader.RepeatTime = 1;
            pheader.ValidLen = 64;
            pheader.arrMode = bx_sdk_dual.E_arrMode.eMULTILINE;
            pheader.fontSize = 12;
            pheader.color = (uint)0x01;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = bx_sdk_dual.E_txtDirection.pNORMAL;
            pheader.txtSpace = 0;
            pheader.Valign = 1;
            pheader.Halign = 1;
            IntPtr cc = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.EQpageHeader)));
            Marshal.StructureToPtr(pheader, cc, false);
            int err = bx_sdk_dual.bxDual_program_picturesAreaAddTxt(areaID, str, font, cc);
            Console.WriteLine("program_picturesAreaAddTxt:" + err);
        }
        public static void Creat_AddStr_6(ushort areaID, string txt,string fontname)
        {
            byte[] str = Encoding.GetEncoding("GBK").GetBytes(txt);
            byte[] font = Encoding.Default.GetBytes(fontname);
            //string str = "Hello,LED\n789";
            bx_sdk_dual.EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 0x04;//移动模式
            pheader.ClearMode = 0x01;
            pheader.Speed = 15;//速度
            pheader.StayTime = 0;//停留时间
            pheader.RepeatTime = 1;
            pheader.ValidLen = 0;
            pheader.CartoonFrameRate = 0x00;
            pheader.BackNotValidFlag = 0x00;
            pheader.arrMode = bx_sdk_dual.E_arrMode.eSINGLELINE;
            pheader.fontSize = 12;
            pheader.color = (uint)0x01;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = bx_sdk_dual.E_txtDirection.pNORMAL;
            pheader.txtSpace = 0;
            pheader.Valign = 0;
            pheader.Halign = 0;
            IntPtr cc = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.EQpageHeader_G6)));
            Marshal.StructureToPtr(pheader, cc, false);
            int err = bx_sdk_dual.bxDual_program_picturesAreaAddTxt_G6(areaID, str, font, cc);
            //int err = bx_sdk_dual.bxDual_program_fontPath_picturesAreaAddTxt_G6(areaID, str, font, cc);
            Console.WriteLine("program_picturesAreaAddTxt:" + err);
        }
        //添加图片
        public static void Creat_Addimg_5(ushort areaID)
        {
            byte[] str = Encoding.Default.GetBytes("Hello,123");
            byte[] font = Encoding.Default.GetBytes("宋体");
            bx_sdk_dual.EQpageHeader pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 0x01;
            pheader.ClearMode = 0x01;
            pheader.Speed = 30;
            pheader.StayTime = 0;
            pheader.RepeatTime = 1;
            pheader.ValidLen = 0;
            pheader.arrMode = bx_sdk_dual.E_arrMode.eSINGLELINE;
            pheader.fontSize = 12;
            pheader.color = (uint)bx_sdk_dual.E_Color_G56.eGREEN;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = bx_sdk_dual.E_txtDirection.pNORMAL;
            pheader.txtSpace = 0;
            pheader.Valign = 2;
            pheader.Halign = 2;
            //err = bx_sdk_dual.program_picturesAreaAddTxt(0, str, font, ref pheader);
            //Console.WriteLine("program_picturesAreaAddTxt:" + err);
            byte[] img = Encoding.Default.GetBytes("32.png");
            IntPtr cc = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.EQpageHeader)));
            Marshal.StructureToPtr(pheader, cc, false);
            int err = bx_sdk_dual.bxDual_program_pictureAreaAddPic(areaID, 0, cc, img);
            Console.WriteLine("program_picturesAreaAddTxt:" + err);
        }
        public static void Creat_Addimg_6(ushort areaID, string txt)
        {
            byte[] str = Encoding.Default.GetBytes("Hello,123");
            byte[] font = Encoding.Default.GetBytes("宋体");
            //string str = "Hello,LED789";
            bx_sdk_dual.EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 0x03;
            pheader.ClearMode = 0x01;
            pheader.Speed = 15;
            pheader.StayTime = 500;
            pheader.RepeatTime = 1;
            pheader.ValidLen = 0;
            pheader.CartoonFrameRate = 0x00;
            pheader.BackNotValidFlag = 0x00;
            pheader.arrMode = bx_sdk_dual.E_arrMode.eSINGLELINE;
            pheader.fontSize = 10;
            pheader.color = (uint)0x01;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = bx_sdk_dual.E_txtDirection.pNORMAL;
            pheader.txtSpace = 0;
            pheader.Valign = 2;
            pheader.Halign = 2;
            byte[] img = Encoding.Default.GetBytes(txt);
            IntPtr cc = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.EQpageHeader_G6)));
            Marshal.StructureToPtr(pheader, cc, false);
            int err = bx_sdk_dual.bxDual_program_pictureAreaAddPic_G6(areaID, 0, cc, img);
            Console.WriteLine("program_pictureAreaAddPic_G6:" + err);
        }
        //添加时间
        public static void Creat_Addtime_5(ushort areaID)
        {
            bx_sdk_dual.EQtimeAreaData_G56 timeData2;
            timeData2.linestyle = bx_sdk_dual.E_arrMode.eMULTILINE;
            timeData2.color = (uint)bx_sdk_dual.E_Color_G56.eRED;
            //timeData2.fontName = BytesToIntptr(Encoding.Default.GetBytes("宋体"));
            timeData2.fontName = @"C:\Windows\Fonts\simsun.ttc";
            timeData2.fontSize = 12;
            timeData2.fontBold = 0;
            timeData2.fontItalic = 0;
            timeData2.fontUnderline = 0;
            timeData2.fontAlign = 0;  //0--左对齐，1-居中，2-右对齐
            timeData2.date_enable = 1;
            timeData2.datestyle = bx_sdk_dual.E_DateStyle.eYYYY_MM_DD_MINUS;
            timeData2.time_enable = 0;
            timeData2.timestyle = bx_sdk_dual.E_TimeStyle.eHH_MM_SS_COLON;
            timeData2.week_enable = 1;
            timeData2.weekstyle = bx_sdk_dual.E_WeekStyle.eMonday_CHS;
            //program_timeAreaAddContent_G6(1,&timeData);
            IntPtr cc = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.EQtimeAreaData_G56)));
            Marshal.StructureToPtr(timeData2, cc, false);
            int err = bx_sdk_dual.bxDual_program_fontPath_timeAreaAddContent(areaID, cc);
            //int err = bx_sdk_dual.program_timeAreaAddContent_G6(areaID, cc);
            Console.WriteLine("program_fontPath_timeAreaAddContent:" + err);
        }
        public static void Creat_Addtime_6(ushort areaID)
        {
            bx_sdk_dual.EQtimeAreaData_G56 timeData2;
            timeData2.linestyle = bx_sdk_dual.E_arrMode.eSINGLELINE;
            timeData2.color = (uint)bx_sdk_dual.E_Color_G56.eRED;
            //timeData2.fontName = BytesToIntptr(Encoding.Default.GetBytes("宋体"));
            timeData2.fontName = "宋体";
            timeData2.fontSize = 12;
            timeData2.fontBold = 0;
            timeData2.fontItalic = 0;
            timeData2.fontUnderline = 0;
            timeData2.fontAlign = 1;  //0--左对齐，1-居中，2-右对齐
            timeData2.date_enable = 1;
            timeData2.datestyle = bx_sdk_dual.E_DateStyle.eYYYY_MM_DD_CHS;
            timeData2.time_enable = 0;
            timeData2.timestyle = bx_sdk_dual.E_TimeStyle.eHH_MM_SS_COLON;
            timeData2.week_enable = 1;
            timeData2.weekstyle = bx_sdk_dual.E_WeekStyle.eMonday_CHS;
            //program_timeAreaAddContent_G6(1,&timeData);
            IntPtr cc = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.EQtimeAreaData_G56)));
            Marshal.StructureToPtr(timeData2, cc, false);
            int err = bx_sdk_dual.bxDual_program_timeAreaAddContent_G6(areaID, cc);
            Console.WriteLine("program_fontPath_timeAreaAddContent_G6:" + err);
        }
        //添加表盘
        public static void Creat_AddClock_5(ushort areaID)
        {
            bx_sdk_dual.EQAnalogClockHeader_G56 acheader;
            acheader.OrignPointX = 32;
            acheader.OrignPointY = 16;
            acheader.UnitMode = 0x00;
            acheader.HourHandWidth = 0x02;
            acheader.HourHandLen = 0x08;
            acheader.HourHandColor = 0x01;
            acheader.MinHandWidth = 0x02;
            acheader.MinHandLen = 0x0b;
            acheader.MinHandColor = 0x01;
            acheader.SecHandWidth = 0x02;
            acheader.SecHandLen = 0x0d;
            acheader.SecHandColor = 0x01;
            IntPtr cc = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.EQAnalogClockHeader_G56)));
            Marshal.StructureToPtr(acheader, cc, false);
            bx_sdk_dual.ClockColor_G56 ClockColor;
            ClockColor.Color369 = 0xff0000;
            ClockColor.ColorDot = 0xff0000;
            ClockColor.ColorBG = 0xff0000;
            int err = bx_sdk_dual.bxDual_program_timeAreaAddAnalogClock(areaID, cc, bx_sdk_dual.E_ClockStyle.eCIRCLE, ref ClockColor);
        }
        public static void Creat_AddClock_6(ushort areaID)
        {
            bx_sdk_dual.EQAnalogClockHeader_G56 acheader;
            acheader.OrignPointX = 32;
            acheader.OrignPointY = 16;
            acheader.UnitMode = 0x00;
            acheader.HourHandWidth = 0x02;
            acheader.HourHandLen = 0x08;
            acheader.HourHandColor = 0x01;
            acheader.MinHandWidth = 0x02;
            acheader.MinHandLen = 0x0b;
            acheader.MinHandColor = 0x01;
            acheader.SecHandWidth = 0x02;
            acheader.SecHandLen = 0x0d;
            acheader.SecHandColor = 0x01;
            IntPtr cc = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.EQAnalogClockHeader_G56)));
            Marshal.StructureToPtr(acheader, cc, false);
            bx_sdk_dual.ClockColor_G56 ClockColor;
            ClockColor.Color369 = 0xff0000;
            ClockColor.ColorDot = 0xff0000;
            ClockColor.ColorBG = 0xff0000;
            int err = bx_sdk_dual.bxDual_program_timeAreaAddAnalogClock_G6(areaID, cc, bx_sdk_dual.E_ClockStyle.eCIRCLE, ref ClockColor);
        }
        //发送 节目
        public static void Net_SengProgram_5(byte[] ipAdder)
        {
            int err = bx_sdk_dual.bxDual_cmd_ofsStartFileTransf(ipAdder, 5005);
            Console.WriteLine("cmd_ofsStartFileTransf:" + err);
            byte[] arrProgram = new byte[100];//[Marshal.SizeOf(typeof(bx_sdk_dual.EQprogram))];
            bx_sdk_dual.EQprogram program;
            err = bx_sdk_dual.bxDual_program_IntegrateProgramFile(arrProgram);
            Console.WriteLine("program_IntegrateProgramFile:" + err);
            IntPtr dec = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.EQprogram)));
            Marshal.Copy(arrProgram, Marshal.SizeOf(typeof(bx_sdk_dual.EQprogram)) * 0, dec, Marshal.SizeOf(typeof(bx_sdk_dual.EQprogram)));
            program = (bx_sdk_dual.EQprogram)Marshal.PtrToStructure(dec, typeof(bx_sdk_dual.EQprogram));
            Marshal.FreeHGlobal(dec);

            err = bx_sdk_dual.bxDual_cmd_ofsWriteFile(ipAdder, 5005, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
            Console.WriteLine("cmd_ofsWriteFile:" + err);
            err = bx_sdk_dual.bxDual_cmd_ofsEndFileTransf(ipAdder, 5005);
            Console.WriteLine("cmd_ofsEndFileTransf:" + err);
            err = bx_sdk_dual.bxDual_program_deleteProgram();
            Console.WriteLine("program_deleteProgram:" + err);
        }
        public static void Net_SengProgram_6(byte[] ipAdder)
        {
            int err = 0;
            //byte[] arrProgram = new byte[100];//[Marshal.SizeOf(typeof(bx_sdk_dual.EQprogram))];
            //bx_sdk_dual.EQprogram_G6 program;
            //err = bx_sdk_dual.program_IntegrateProgramFile_G6(arrProgram);
            //Console.WriteLine("program_IntegrateProgramFile:" + err);
            //IntPtr dec = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.EQprogram_G6)));
            //Marshal.Copy(arrProgram, Marshal.SizeOf(typeof(bx_sdk_dual.EQprogram_G6)) * 0, dec, Marshal.SizeOf(typeof(bx_sdk_dual.EQprogram_G6)));
            //program = (bx_sdk_dual.EQprogram_G6)Marshal.PtrToStructure(dec, typeof(bx_sdk_dual.EQprogram_G6));
            //Marshal.FreeHGlobal(dec);
            bx_sdk_dual.EQprogram_G6 program = new bx_sdk_dual.EQprogram_G6();
            program.fileName = Encoding.GetEncoding("GBK").GetBytes("P000");
            program.fileType = 0;
            program.fileLen = 0;
            program.fileAddre = IntPtr.Zero;
            program.dfileName = Encoding.GetEncoding("GBK").GetBytes("D000");
            program.dfileType = 0;
            program.dfileLen = 0;
            program.dfileAddre = IntPtr.Zero;
            err = bx_sdk_dual.bxDual_program_IntegrateProgramFile_G6(ref program);

            err = bx_sdk_dual.bxDual_cmd_ofsStartFileTransf(ipAdder, 5005);
            Console.WriteLine("cmd_ofsStartFileTransf:" + err);

            err = bx_sdk_dual.bxDual_cmd_ofsWriteFile(ipAdder, 5005, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
            Console.WriteLine("cmd_ofsWriteFile:" + err);
            err = bx_sdk_dual.bxDual_cmd_ofsWriteFile(ipAdder, 5005, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
            Console.WriteLine("cmd_ofsWriteFile:" + err);
            err = bx_sdk_dual.bxDual_cmd_ofsEndFileTransf(ipAdder, 5005);
            Console.WriteLine("cmd_ofsEndFileTransf:" + err);
            err = bx_sdk_dual.bxDual_program_deleteProgram_G6();
            Console.WriteLine("program_deleteProgram:" + err);
        }
        public static void Com_SengProgram_5(byte[] com)
        {
            byte[] arrProgram = new byte[100];//[Marshal.SizeOf(typeof(bx_sdk_dual.EQprogram))];
            bx_sdk_dual.EQprogram program;
            int err = bx_sdk_dual.bxDual_program_IntegrateProgramFile(arrProgram);
            Console.WriteLine("program_IntegrateProgramFile:" + err);
            IntPtr dec = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.EQprogram)));
            Marshal.Copy(arrProgram, Marshal.SizeOf(typeof(bx_sdk_dual.EQprogram)) * 0, dec, Marshal.SizeOf(typeof(bx_sdk_dual.EQprogram)));
            program = (bx_sdk_dual.EQprogram)Marshal.PtrToStructure(dec, typeof(bx_sdk_dual.EQprogram));
            Marshal.FreeHGlobal(dec);

            err = bx_sdk_dual.bxDual_cmd_uart_ofsStartFileTransf(com, 2);
            Console.WriteLine("cmd_uart_ofsStartFileTransf:" + err);

            err = bx_sdk_dual.bxDual_cmd_uart_ofsWriteFile(com, 2, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
            Console.WriteLine("cmd_uart_ofsWriteFile:" + err);
            err = bx_sdk_dual.bxDual_cmd_uart_ofsEndFileTransf(com, 2);
            Console.WriteLine("cmd_uart_ofsEndFileTransf:" + err);
            err = bx_sdk_dual.bxDual_program_deleteProgram();
            Console.WriteLine("program_deleteProgram:" + err);
        }
        public static void Com_SengProgram_6(byte[] com)
        {
            int err = 0;
            byte[] arrProgram = new byte[100];//[Marshal.SizeOf(typeof(bx_sdk_dual.EQprogram))];
            bx_sdk_dual.EQprogram_G6 program;
            //err = bx_sdk_dual.program_IntegrateProgramFile_G6(arrProgram);
            Console.WriteLine("program_IntegrateProgramFile:" + err);
            IntPtr dec = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(bx_sdk_dual.EQprogram_G6)));
            Marshal.Copy(arrProgram, Marshal.SizeOf(typeof(bx_sdk_dual.EQprogram_G6)) * 0, dec, Marshal.SizeOf(typeof(bx_sdk_dual.EQprogram_G6)));
            program = (bx_sdk_dual.EQprogram_G6)Marshal.PtrToStructure(dec, typeof(bx_sdk_dual.EQprogram_G6));
            Marshal.FreeHGlobal(dec);

            err = bx_sdk_dual.bxDual_cmd_uart_ofsStartFileTransf(com, 2);
            Console.WriteLine("cmd_uart_ofsStartFileTransf:" + err);

            err = bx_sdk_dual.bxDual_cmd_uart_ofsWriteFile(com, 2, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
            Console.WriteLine("cmd_uart_ofsWriteFile:" + err);
            err = bx_sdk_dual.bxDual_cmd_uart_ofsWriteFile(com, 2, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
            Console.WriteLine("cmd_uart_ofsWriteFile:" + err);
            err = bx_sdk_dual.bxDual_cmd_uart_ofsEndFileTransf(com, 2);
            Console.WriteLine("cmd_uart_ofsEndFileTransf:" + err);
            err = bx_sdk_dual.bxDual_program_deleteProgram_G6();
            Console.WriteLine("program_deleteProgram:" + err);
        }
        //调整亮度
        public static void Net_Bright(byte[] ipAdder,byte num)
        {
            bx_sdk_dual.Brightness brightness;
            brightness.BrightnessMode=0;
            brightness.HalfHourValue0 = num;
            brightness.HalfHourValue1 = num;
            brightness.HalfHourValue2 = num;
            brightness.HalfHourValue3 = num;
            brightness.HalfHourValue4 = num;
            brightness.HalfHourValue5 = num;
            brightness.HalfHourValue6 = num;
            brightness.HalfHourValue7 = num;
            brightness.HalfHourValue8 = num;
            brightness.HalfHourValue9 = num;
            brightness.HalfHourValue10 = num;
            brightness.HalfHourValue11 = num;
            brightness.HalfHourValue12 = num;
            brightness.HalfHourValue13 = num;
            brightness.HalfHourValue14 = num;
            brightness.HalfHourValue15 = num;
            brightness.HalfHourValue16 = num;
            brightness.HalfHourValue17 = num;
            brightness.HalfHourValue18 = num;
            brightness.HalfHourValue19 = num;
            brightness.HalfHourValue20 = num;
            brightness.HalfHourValue21 = num;
            brightness.HalfHourValue22 = num;
            brightness.HalfHourValue23 = num;
            brightness.HalfHourValue24 = num;
            brightness.HalfHourValue25 = num;
            brightness.HalfHourValue26 = num;
            brightness.HalfHourValue27 = num;
            brightness.HalfHourValue28 = num;
            brightness.HalfHourValue29 = num;
            brightness.HalfHourValue30 = num;
            brightness.HalfHourValue31 = num;
            brightness.HalfHourValue32 = num;
            brightness.HalfHourValue33 = num;
            brightness.HalfHourValue34 = num;
            brightness.HalfHourValue35 = num;
            brightness.HalfHourValue36 = num;
            brightness.HalfHourValue37 = num;
            brightness.HalfHourValue38 = num;
            brightness.HalfHourValue39 = num;
            brightness.HalfHourValue40 = num;
            brightness.HalfHourValue41 = num;
            brightness.HalfHourValue42 = num;
            brightness.HalfHourValue43 = num;
            brightness.HalfHourValue44 = num;
            brightness.HalfHourValue45 = num;
            brightness.HalfHourValue46 = num;
            brightness.HalfHourValue47 = num;

            int err = bx_sdk_dual.bxDual_cmd_setBrightness(ipAdder, 5005, ref brightness);
            Console.WriteLine("cmd_setBrightness:" + err);
        }
        //添加语音
        public static void Creat_sound_5(ushort areaID)
        {
        }
        public static void Creat_sound_6(ushort areaID)
        {
            byte[] str = Encoding.GetEncoding("gb2312").GetBytes("请张三到1号窗口取药");
            bx_sdk_dual.EQPicAreaSoundHeader_G6 pheader;
            pheader.SoundPerson=3;
            pheader.SoundVolum=5;
            pheader.SoundSpeed=5;
            pheader.SoundDataMode=0;
            pheader.SoundReplayTimes=0;
            pheader.SoundReplayDelay=1000;
            pheader.SoundReservedParaLen=3;
            pheader.Soundnumdeal = 1;
            pheader.Soundlanguages = 1;
            pheader.Soundwordstyle = 1;
            int err = bx_sdk_dual.bxDual_program_pictureAreaEnableSound_G6(areaID, pheader, str);
            Console.WriteLine("program_pictureAreaEnableSound_G6:" + err);
        }
    }
}

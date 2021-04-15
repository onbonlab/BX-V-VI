using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace LedSDKDemo_CSharp
{
    class Class1
    {
        //struct转换为byte[]
        public static byte[] StructToBytes(object structObj)
        {
            int size = Marshal.SizeOf(structObj);
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(structObj, buffer, false);
                byte[] bytes = new byte[size];
                Marshal.Copy(buffer, bytes, 0, size);
                return bytes;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }
        //byte[]转换为Intptr
        public static IntPtr BytesToIntptr(byte[] bytes)
        {
            GCHandle hObject = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            IntPtr pObject = hObject.AddrOfPinnedObject();

            if (hObject.IsAllocated)
                hObject.Free();
            return pObject;
        }
        //byte[]转换为string  回读数据使用
        public static string BytesToString(byte[] bytes)
        {
            string str = "";
            for (int a = 0; a < bytes.Length; a++)
            {
                if (a == 0)
                {
                    str = Convert.ToUInt16(bytes[a]).ToString();
                }
                else
                {
                    str += "." + Convert.ToUInt16(bytes[a]).ToString();
                }
            }
            return str;
        }
        //byte转换为BCD码
        private static byte ConvertBCD(byte b)
        {
            //高四位  
            byte b1 = (byte)(b / 10);
            //低四位  
            byte b2 = (byte)(b % 10);
            return (byte)((b1 << 4) | b2);
        }
        /// <summary>  
        /// 将BCD一字节数据转换到byte 十进制数据  
        /// </summary>  
        /// <param name="b" />字节数  
        /// <returns>返回转换后的BCD码</returns>  
        public static byte ConvertBCDToInt(byte b)
        {
            //高四位  
            byte b1 = (byte)((b >> 4) & 0xF);
            //低四位  
            byte b2 = (byte)(b & 0xF);

            return (byte)(b1 * 10 + b2);
        }
        public static string getStr(bool b, int n)//b：是否有复杂字符，n：生成的字符串长度
        {

            string str = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (b == true)
            {
                str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";//复杂字符
            }
            StringBuilder SB = new StringBuilder();
            Random rd = new Random();
            for (int i = 0; i < n; i++)
            {
                SB.Append(str.Substring(rd.Next(0, str.Length), 1));
            }
            return SB.ToString();

        }

        public class sdk_err
        {
            public const int ERR_NO = 0;
            public const int ERR_OUTOFGROUP = 1;
            public const int ERR_NOCMD = 2;
            public const int ERR_BUSY = 3;
            public const int ERR_MEMORYVOLUME = 4;
            public const int ERR_CHECKSUM = 5;
            public const int ERR_FILENOTEXIST = 6;
            public const int ERR_FLASH = 7;
            public const int ERR_FILE_DOWNLOAD = 8;
            public const int ERR_FILE_NAME = 9;
            public const int ERR_FILE_TYPE = 10;
            public const int ERR_FILE_CRC16 = 11;
            public const int ERR_FONT_NOT_EXIST = 12;
            public const int ERR_FIRMWARE_TYPE = 13;
            public const int ERR_DATE_TIME_FORMAT = 14;
            public const int ERR_FILE_EXIST = 15;
            public const int ERR_FILE_BLOCK_NUM = 16;
            public const int ERR_CONTROLLER_TYPE = 17;
            public const int ERR_SCREEN_PARA = 18;
            public const int ERR_CONTROLLER_ID = 19;
            public const int ERR_USER_SECRET = 20;
            public const int ERR_OLD_USER_SECRET = 21;
            public const int ERR_PHY1_NO_SECRET = 22;
            public const int ERR_PHY1_USE_SECRET = 23;
            public const int ERR_RTC = 24;
            public const int ERR_CMD_PARA = 25;
            public const int ERR_CASCADE_COMM = 26;
            public const int ERR_NO_BATTLE_AREA = 27;
            public const int ERR_NO_TIMER_AREA = 28;
            public const int ERR_FPGA_COMM = 29;
            public const int ERR_SET_MODBUS_PARA = 60;

            public const int ERR_TCP = -1;
        }
        public static string GetError(int err)
        {
            string str = "";
            switch (err)
            {
                case sdk_err.ERR_TCP:
                    str = "通讯错误";
                    break;
                case sdk_err.ERR_NO:
                    str = "没有错误";
                    break;
                case sdk_err.ERR_OUTOFGROUP:
                    str = "命令组错误";
                    break;
                case sdk_err.ERR_NOCMD:
                    str = "此命令不存在";
                    break;
                case sdk_err.ERR_BUSY:
                    str = "控制器忙";
                    break;
                case sdk_err.ERR_MEMORYVOLUME:
                    str = "存储器容量越界";
                    break;
                case sdk_err.ERR_CHECKSUM:
                    str = "数据包 CRC 校验错误";
                    break;
                case sdk_err.ERR_FILENOTEXIST:
                    str = "此文件不存在";
                    break;
                case sdk_err.ERR_FLASH:
                    str = "Flash 访问错误";
                    break;
                case sdk_err.ERR_FILE_DOWNLOAD:
                    str = "文件下载错误";
                    break;
                case sdk_err.ERR_FILE_NAME:
                    str = "文件名错误";
                    break;
                case sdk_err.ERR_FILE_TYPE:
                    str = "文件类型错误";
                    break;
                case sdk_err.ERR_FILE_CRC16:
                    str = "文件校验错误";
                    break;
                case sdk_err.ERR_FONT_NOT_EXIST:
                    str = "字库文件不存在";
                    break;
                case sdk_err.ERR_FIRMWARE_TYPE:
                    str = "Firmware 与控制器类型不匹配";
                    break;
                case sdk_err.ERR_DATE_TIME_FORMAT:
                    str = "日期时间格式错误 ";
                    break;
                case sdk_err.ERR_FILE_EXIST:
                    str = "此文件已存在";
                    break;
                case sdk_err.ERR_FILE_BLOCK_NUM:
                    str = "文件 Block 号错误";
                    break;
                case sdk_err.ERR_CONTROLLER_TYPE:
                    str = "控制器类型不匹配";
                    break;
                case sdk_err.ERR_SCREEN_PARA:
                    str = "控制器参数越界或错误";
                    break;
                case sdk_err.ERR_CONTROLLER_ID:
                    str = "控制器 ID 错误";
                    break;
                case sdk_err.ERR_USER_SECRET:
                    str = "用户密码错误";
                    break;
                case sdk_err.ERR_OLD_USER_SECRET:
                    str = "设置新密码时，输入的旧密码不正确";
                    break;
                case sdk_err.ERR_PHY1_NO_SECRET:
                    str = "底层无密码，上位机有密码";
                    break;
                case sdk_err.ERR_PHY1_USE_SECRET:
                    str = " 底层有密码，上位机无密码";
                    break;
                case sdk_err.ERR_RTC:
                    str = "时钟芯片故障";
                    break;
                case sdk_err.ERR_CMD_PARA:
                    str = "命令参数错误";
                    break;
                case sdk_err.ERR_CASCADE_COMM:
                    str = "级联系统通讯故障";
                    break;
                case sdk_err.ERR_NO_BATTLE_AREA:
                    str = "无战斗时间区域";
                    break;
                case sdk_err.ERR_NO_TIMER_AREA:
                    str = "无秒表区域";
                    break;
                case sdk_err.ERR_FPGA_COMM:
                    str = "与后级扫描模块通讯故障";
                    break;
                case sdk_err.ERR_SET_MODBUS_PARA:
                    str = "设置 MODBUS 参数错误";
                    break;
                default:
                    str = "未知错误：" + err;
                    break;
            }
            return str;
        }
    }
    public class ServerList
    {
        public byte[] barcode = { 0 };
        public int port = 0;

        public ServerList(byte[] _barcode, int _port)
        {
            barcode = _barcode;
            port = _port;
        }
    }

    public class ControlType
    {
        // 控制器类型
        private const ushort BX_5AT = 0x0051;
        private const ushort BX_5A0 = 0x0151;
        private const ushort BX_5A1 = 0x0251;
        private const ushort BX_5A2 = 0x0351;
        private const ushort BX_5A3 = 0x0451;
        private const ushort BX_5A4 = 0x0551;
        private const ushort BX_5A1_WIFI = 0x0651;
        private const ushort BX_5A2_WIFI = 0x0751;
        private const ushort BX_5A4_WIFI = 0x0851;
        private const ushort BX_5A = 0x0951;
        private const ushort BX_5A2_RF = 0x1351;
        private const ushort BX_5A4_RF = 0x1551;
        private const ushort BX_5AT_WIFI = 0x1651;
        private const ushort BX_5AL = 0x1851;

        private const ushort AX_AT = 0x2051;
        private const ushort AX_A0 = 0x2151;

        private const ushort BX_5MT = 0x0552;
        private const ushort BX_5M1 = 0x0052;
        private const ushort BX_5M1X = 0x0152;
        private const ushort BX_5M2 = 0x0252;
        private const ushort BX_5M3 = 0x0352;
        private const ushort BX_5M4 = 0x0452;

        private const ushort BX_5E1 = 0x0154;
        private const ushort BX_5E2 = 0x0254;
        private const ushort BX_5E3 = 0x0354;

        private const ushort BX_5UT = 0x0055;
        private const ushort BX_5U0 = 0x0155;
        private const ushort BX_5U1 = 0x0255;
        private const ushort BX_5U2 = 0x0355;
        private const ushort BX_5U3 = 0x0455;
        private const ushort BX_5U4 = 0x0555;
        private const ushort BX_5U5 = 0x0655;
        private const ushort BX_5U = 0x0755;
        private const ushort BX_5UL = 0x0855;

        private const ushort AX_UL = 0x2055;
        private const ushort AX_UT = 0x2155;
        private const ushort AX_U0 = 0x2255;
        private const ushort AX_U1 = 0x2355;
        private const ushort AX_U2 = 0x2455;

        private const ushort BX_5Q0 = 0x0056;
        private const ushort BX_5Q1 = 0x0156;
        private const ushort BX_5Q2 = 0x0256;
        private const ushort BX_5Q0P = 0x1056;
        private const ushort BX_5Q1P = 0x1156;
        private const ushort BX_5Q2P = 0x1256;
        private const ushort BX_5QL = 0x1356;

        private const ushort BX_5QS1 = 0x0157;
        private const ushort BX_5QS2 = 0x0257;
        private const ushort BX_5QS = 0x0357;
        private const ushort BX_5QS1P = 0x1157;
        private const ushort BX_5QS2P = 0x1257;
        private const ushort BX_5QSP = 0x1357;

        private const ushort BX_6M0 = 0x0062;
        private const ushort BX_6M1 = 0x0162;
        private const ushort BX_6M2 = 0x0262;
        private const ushort BX_6M3 = 0x0362;
        private const ushort BX_6M = 0x0462;
        private const ushort BX_6MT = 0x0562;

        private const ushort BX_6M0_YY = 0x1062;
        private const ushort BX_6M1_YY = 0x1162;
        private const ushort BX_6M2_YY = 0x1262;
        private const ushort BX_6M3_YY = 0x1362;
        private const ushort BX_6M_YY = 0x1462;

        private const ushort BX_6X1 = 0x2162;
        private const ushort BX_6X2 = 0x2262;
        private const ushort BX_6X3 = 0x2362;

        private const ushort BX_6U0 = 0x0063;
        private const ushort BX_6U1 = 0x0163;
        private const ushort BX_6U2 = 0x0263;
        private const ushort BX_6U3 = 0x0363;
        private const ushort BX_6U = 0x0463;
        private const ushort BX_6UT = 0x0563;

        private const ushort BX_6U0_YY = 0x1063;
        private const ushort BX_6U1_YY = 0x1163;
        private const ushort BX_6U2_YY = 0x1263;
        private const ushort BX_6U3_YY = 0x1363;
        private const ushort BX_6U_YY = 0x1463;

        private const ushort BX_6A0 = 0x2063;
        private const ushort BX_6A1 = 0x2163;
        private const ushort BX_6A2 = 0x2263;
        private const ushort BX_6A3 = 0x2363;
        private const ushort BX_6A = 0x2463;

        private const ushort BX_6A0_YY = 0x3063;
        private const ushort BX_6A1_YY = 0x3163;
        private const ushort BX_6A2_YY = 0x3263;
        private const ushort BX_6A3_YY = 0x3363;
        private const ushort BX_6A_YY = 0x3463;

        private const ushort BX_6A0_G = 0x4063;
        private const ushort BX_6A1_G = 0x4163;
        private const ushort BX_6A2_G = 0x4263;
        private const ushort BX_6A3_G = 0x4363;
        private const ushort BX_6AT_G = 0x4463;

        private const ushort BX_6S1 = 0x5163;
        private const ushort BX_6S2 = 0x5263;
        private const ushort BX_6S3 = 0x5363;

        private const ushort BX_6W0 = 0x0064;
        private const ushort BX_6W1 = 0x0164;
        private const ushort BX_6W2 = 0x0264;
        private const ushort BX_6W3 = 0x0364;
        private const ushort BX_6W = 0x0464;
        private const ushort BX_6WT = 0x0564;

        private const ushort BX_6E1 = 0x0174;
        private const ushort BX_6E2 = 0x0274;
        private const ushort BX_6E3 = 0x0374;
        private const ushort BX_6E1X = 0x0474;
        private const ushort BX_6E2X = 0x0574;

        private const ushort BX_6Q1 = 0x0166;
        private const ushort BX_6Q2 = 0x0266;
        private const ushort BX_6Q2L = 0x0466;
        private const ushort BX_6Q3 = 0x0366;
        private const ushort BX_6Q3L = 0x0566;

        public static ushort[] controlType = new ushort[111] { BX_5AT, BX_5A0, BX_5A1, BX_5A2, BX_5A3, BX_5A4, BX_5A1_WIFI, BX_5A2_WIFI,BX_5A4_WIFI,BX_5A,
                                        BX_5A2_RF,BX_5A4_RF,BX_5AT_WIFI,BX_5AL,AX_AT,AX_A0,BX_5MT,BX_5M1,BX_5M1X,BX_5M2,BX_5M3,BX_5M4,
                                        BX_5E1,BX_5E2,BX_5E3,BX_5UT,BX_5U0,BX_5U1,BX_5U2,BX_5U3,BX_5U4,BX_5U5,BX_5U,BX_5UL,
                                        AX_UL,AX_UT,AX_U0,AX_U1,AX_U2,BX_5Q0,BX_5Q1,BX_5Q2,BX_5Q0P,BX_5Q1P,BX_5Q2P,BX_5QL,BX_5QS1,
                                        BX_5QS2,BX_5QS,BX_5QS1P,BX_5QS2P,BX_5QSP,
                                        BX_6M0,BX_6M1,BX_6M2,BX_6M3,BX_6M,BX_6MT,BX_6M0_YY,BX_6M1_YY,BX_6M2_YY,BX_6M3_YY,BX_6M_YY,BX_6X1,BX_6X2,BX_6X3,
                                        BX_6U0,BX_6U1,BX_6U2,BX_6U3,BX_6U,BX_6UT,BX_6U0_YY,BX_6U1_YY,BX_6U2_YY,BX_6U3_YY,BX_6U_YY,
                                        BX_6A0,BX_6A1,BX_6A2,BX_6A3,BX_6A,BX_6A0_YY,BX_6A1_YY,BX_6A2_YY,BX_6A3_YY,BX_6A_YY,BX_6A0_G,BX_6A1_G,BX_6A2_G,BX_6A3_G,BX_6AT_G,
                                        BX_6S1,BX_6S2,BX_6S3,BX_6W0,BX_6W1,BX_6W2,BX_6W3,BX_6W,BX_6WT,
                                        BX_6E1,BX_6E2,BX_6E3,BX_6E1X,BX_6E2X,BX_6Q1,BX_6Q2,BX_6Q2L,BX_6Q3,BX_6Q3L};
    }

    
}

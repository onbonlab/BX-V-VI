﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LedSDKDemo_CSharp
{
    class common_56
    {
        public static int err = 0;
        public static byte[] uartPort = Encoding.GetEncoding("GBK").GetBytes("\\\\.\\COM17");
        //串口波特率 1：9600  2：57600
        public static byte baudRate = 2;
        //常规设置
        public static void set(byte[] ipAdder, ushort portp)
        {
            //设置屏号，不做通讯
            err = bxdualsdk.bxDual_set_screenNum_G56(1);
            //设置控制各种通讯方式每一包最大长度
            err = bxdualsdk.bxDual_set_packetLen(1024);
            //文件系统格式化
            err = bxdualsdk.bxDual_cmd_uart_ofsFormat(uartPort, baudRate);
        }
        //网口广播搜索
        public static void Net_search()
        {
            bxdualsdk.Ping_data data = new bxdualsdk.Ping_data();
            err = bxdualsdk.bxDual_cmd_udpPing(ref data);
            Console.WriteLine("ControllerType:0x" + data.ControllerType.ToString("X2"));
            Console.WriteLine("FirmwareVersion:V" + System.Text.Encoding.Default.GetString(data.FirmwareVersion));
            Console.WriteLine("ipAdder:" + System.Text.Encoding.Default.GetString(data.ipAdder));
            Console.WriteLine("\r\n");
        }

        //串口搜索
        public static void COM_search()
        {
            byte[] COMPort = Encoding.Default.GetBytes("COM7");
            bxdualsdk.Ping_data data=new bxdualsdk.Ping_data();
            //全搜索，udp-tcp-com
            err = bxdualsdk.bxDual_cmd_searchController(ref data);
            //根据串口搜索
            int ret = bxdualsdk.bxDual_cmd_uart_searchController(ref data, COMPort);
            Console.WriteLine("ControllerType:0x" + data.ControllerType.ToString("X2"));
            Console.WriteLine("FirmwareVersion:V" + System.Text.Encoding.Default.GetString(data.FirmwareVersion));
            Console.WriteLine("ipAdder:" + System.Text.Encoding.Default.GetString(data.ipAdder));
            Console.WriteLine("\r\n");
        }
        //删除节目 网口
        public static void deleteprogram_net()
        {
            byte[] ip = Encoding.Default.GetBytes("192.168.89.105");
            //获取节目列表
            bxdualsdk.GetDirBlock_G56 driBlock=new bxdualsdk.GetDirBlock_G56();
            err = bxdualsdk.bxDual_cmd_ofsReedDirBlock(ip, 5005,ref driBlock);
            //获取节目详细信息
            for (int i = 0; i < driBlock.fileNumber; i++)
            {
                bxdualsdk.FileAttribute_G56 fileAttr=new bxdualsdk.FileAttribute_G56();
                err = bxdualsdk.bxDual_cmd_getFileAttr(ref driBlock, (ushort)i,ref fileAttr);
                //删除指定节目
                err = bxdualsdk.bxDual_cmd_ofsDeleteFormatFile(ip, 5005, 1, fileAttr.fileName);
                //err = bxdualsdk.bxDual_cmd_uart_ofsDeleteFormatFile(uartPort, baudRate, 1, fileAttr.fileName);
            }
        }
        //删除节目 串口
        public static void deleteprogram_com()
        {
            byte[] ip = Encoding.Default.GetBytes("192.168.89.105");
            //获取节目列表
            bxdualsdk.GetDirBlock_G56 driBlock = new bxdualsdk.GetDirBlock_G56();
            err = bxdualsdk.bxDual_cmd_uart_ofsReedDirBlock(uartPort, baudRate, ref driBlock);
            //获取节目详细信息
            for (int i = 0; i < driBlock.fileNumber; i++)
            {
                bxdualsdk.FileAttribute_G56 fileAttr = new bxdualsdk.FileAttribute_G56();
                err = bxdualsdk.bxDual_cmd_getFileAttr(ref driBlock, (ushort)i, ref fileAttr);
                //删除指定节目
                err = bxdualsdk.bxDual_cmd_uart_ofsDeleteFormatFile(uartPort, baudRate, 1, fileAttr.fileName);
            }
        }
        //调整亮度
        public static void Net_Bright(byte[] ipAdder, byte num)
        {
            bxdualsdk.Brightness brightness;
            brightness.BrightnessMode = 0;
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

            err = bxdualsdk.bxDual_cmd_setBrightness(ipAdder, 5005, ref brightness);
            Console.WriteLine("cmd_setBrightness:" + err);
        }
        //系统复位
        public static void Reset(byte[] ipAdder)
        {
            err = bxdualsdk.bxDual_cmd_sysReset(ipAdder, 5005);
            Console.WriteLine("bxDual_cmd_sysReset:" + err);
        }
        //强制开关机
        public static void coerceOnOff(byte[] ipAdder)
        {
            //err = bxdualsdk.bxDual_cmd_coerceOnOff(ipAdder, 5005, 0);//关机
            err = bxdualsdk.bxDual_cmd_coerceOnOff(ipAdder, 5005, 1);//开机
            Console.WriteLine("bxDual_cmd_coerceOnOff:" + err);
        }
        //定时开关机
        public static void timingOnOff(byte[] ipAdder)
        {
            bxdualsdk.TimingOnOff[] time = new bxdualsdk.TimingOnOff[1];
            time[0].onHour = 11;   // 开机小时
            time[0].onMinute = 27; // 开机分钟
            time[0].offHour = 11;  // 关机小时
            time[0].offMinute = 40; // 关机分钟
            byte[] Time = Class1.StructToBytes(time[0]);
            err = bxdualsdk.bxDual_cmd_timingOnOff(ipAdder, 5005, 1, Time);
            //取消定时开关机
            //err = bxdualsdk.bxDual_cmd_cancelTimingOnOff(ipAdder, 5005);
            Console.WriteLine("bxDual_cmd_timingOnOff:" + err);
        }
        //屏幕锁定
        public static void screenLock(byte[] ipAdder)
        {
            err = bxdualsdk.bxDual_cmd_screenLock(ipAdder, 5005, 1, 1);//屏幕锁定
            //err = bxdualsdk.bxDual_cmd_screenLock(ipAdder, 5005, 1,0);//屏幕解锁
            Console.WriteLine("bxDual_cmd_screenLock:" + err);
        }
        //节目锁定
        public static void programLock(byte[] ipAdder)
        {
            //节目名格式类型为P***，如P000，P001
            byte[] name = Encoding.GetEncoding("GBK").GetBytes("P000");
            err = bxdualsdk.bxDual_cmd_programLock(ipAdder, 5005, 1, 1, name, 0xffffffff);//锁定
            //err = bxdualsdk.bxDual_cmd_uart_programLock(Program.com, 2, 1, 1, name, 0xffffffff);//锁定-串口
            //err = bxdualsdk.bxDual_cmd_programLock(ipAdder, 5005, 1,0, name, 0xffffffff);//解锁
            Console.WriteLine("bxDual_cmd_programLock:" + err);
        }
        //获取控制空间大小和剩余空间
        public static void GetMemoryVolume(byte[] ipAdder)
        {
            int totalMemVolume = 0, availableMemVolume = 0;
            err = bxdualsdk.bxDual_cmd_ofsGetMemoryVolume(ipAdder, 5005,ref totalMemVolume,ref availableMemVolume); 
             err = bxdualsdk.bxDual_cmd_uart_ofsGetMemoryVolume(uartPort, baudRate, ref totalMemVolume, ref availableMemVolume);
        }
        //网络搜索
        public static void search_Net(byte[] ipAdder)
        {
            bxdualsdk.NetSearchCmdRet retData = new bxdualsdk.NetSearchCmdRet();
            byte[] uartPort = new byte[] { 0};
            ushort nBaudRateType = 0;
            err = bxdualsdk.bxDual_cmd_uart_search_Net_6G(ref retData, uartPort, nBaudRateType);
            bxdualsdk.NetSearchCmdRet_Web data = new bxdualsdk.NetSearchCmdRet_Web();
             err = bxdualsdk.bxDual_cmd_uart_search_Net_6G_Web(ref data, uartPort, nBaudRateType);
        }
        //网络搜索-传感器
        private static void btn_NetworkSearch_Click(byte[] ipAdder)
        {
            bxdualsdk.NetSearchCmdRet CmdRet = new bxdualsdk.NetSearchCmdRet();
            err = bxdualsdk.bxDual_cmd_tcpNetworkSearch_6G(ipAdder, 5005, ref CmdRet);
            err = bxdualsdk.bxDual_cmd_udpNetworkSearch_6G(ref CmdRet);
            string str = "";
            if (err == 0)
            {
                //Mac 地址
                str = "Mac:" + CmdRet.Mac[0].ToString("X2") + CmdRet.Mac[1].ToString("X2") + CmdRet.Mac[2].ToString("X2") + CmdRet.Mac[3].ToString("X2") + CmdRet.Mac[4].ToString("X2") + CmdRet.Mac[5].ToString("X2") + System.Environment.NewLine;
                //控制器 IP 地址
                str += "IP:" + Class1.BytesToString(CmdRet.IP) + System.Environment.NewLine;
                //子网掩码
                str += "SubNetMask:" + Class1.BytesToString(CmdRet.SubNetMask) + System.Environment.NewLine;
                //网关
                str += "Gate:" + Class1.BytesToString(CmdRet.Gate) + System.Environment.NewLine;
                //端口
                str += "Port:" + CmdRet.Port + System.Environment.NewLine;
                //1 表示 DHCP 2 表示手动设置
                if (CmdRet.IPMode == 1)
                {
                    str += "IPMode:DHCP" + System.Environment.NewLine;
                }
                else
                {
                    str += "IPMode:表示手动设置" + System.Environment.NewLine;
                }
                //0 表示 IP 设置失败 1 表示 IP 设置成功
                if (CmdRet.IPMode == 0)
                {
                    str += "IPStatus:IP 设置失败" + System.Environment.NewLine;
                }
                else
                {
                    str += "IPStatus:IP 设置成功" + System.Environment.NewLine;
                }
                //0 Bit[0]表示服务器模式是否使能：1 –使能，0 –禁止 Bit[1]表示服务器模式：1 –web 模式，0 –普通模式
                if (CmdRet.ServerMode == 0)
                {
                    str += "ServerMode:服务器模式使能    普通模式" + System.Environment.NewLine;
                }
                else if (CmdRet.ServerMode == 1)
                {
                    str += "ServerMode:服务器模式禁止    普通模式" + System.Environment.NewLine;
                }
                else if (CmdRet.ServerMode == 2)
                {
                    str += "ServerMode:服务器模式禁止    web模式" + System.Environment.NewLine;
                }
                else
                {
                    str += "ServerMode:服务器模式使能    web模式" + System.Environment.NewLine;
                }
                //服务器 IP 地址
                str += "ServerIPAddress:" + Class1.BytesToString(CmdRet.ServerIPAddress) + System.Environment.NewLine;
                //服务器端口号
                str += "ServerPort:" + CmdRet.ServerPort + System.Environment.NewLine;
                //服务器访问密码
                str += "ServerAccessPassword:" + System.Text.Encoding.Default.GetString(CmdRet.ServerAccessPassword) + System.Environment.NewLine;
                //20S 心跳时间间隔（单位：秒）
                str += "HeartBeatInterval:" + CmdRet.HeartBeatInterval + System.Environment.NewLine;
                //用户自定义 ID，作为网络 ID 的前半部分，便于用户识别其控制卡
                str += "CustomID:" + System.Text.Encoding.Default.GetString(CmdRet.CustomID) + System.Environment.NewLine;
                //条形码，作为网络 ID 的后半部分，用以实现网络 ID 的唯一性
                str += "BarCode:" + System.Text.Encoding.Default.GetString(CmdRet.BarCode) + System.Environment.NewLine;
                //其中低位字节表示设备系列，而高位字节表示设备编号，例如 BX - 6Q2 应表示为[0x66, 0x02]，其它型号依此类推。
                str += "ControllerType:" + (CmdRet.ControllerType[1] * 256 + CmdRet.ControllerType[0]) / 10 + System.Environment.NewLine;
                //Firmware 版本号
                str += "FirmwareVersion:" + System.Text.Encoding.Default.GetString(CmdRet.FirmwareVersion) + System.Environment.NewLine;
                //控制器参数文件状态 0x00 –控制器中没有参数配置文件，以下返回的是控制器的默认参数。此时，PC软件应提示用户必须先加载屏参。0x01 –控制器中有参数配置文件
                if (CmdRet.ScreenParaStatus == 0)
                {
                    str += "ScreenParaStatus:控制器中没有参数配置文件，必须先加载屏参" + System.Environment.NewLine;
                }
                else
                {
                    str += "ScreenParaStatus:控制器中有参数配置文件" + System.Environment.NewLine;
                }
                //0x0001 控制器地址控制器出厂默认地址为 0x0001(0x0000 地址将保留)控制除了对发送给自身地址的数据包进行处理外，还需对广播数据包进行处理。
                str += "Address:" + CmdRet.Address + System.Environment.NewLine;
                //0x00 波特率 0x00 –保持原有波特率不变 0x01 –强制设置为 9600 0x02 –强制设置为 57600
                if (CmdRet.Baudrate == 1)
                {
                    str += "Baudrate:9600" + System.Environment.NewLine;
                }
                else if (CmdRet.Baudrate == 2)
                {
                    str += "Baudrate:57600" + System.Environment.NewLine;
                }
                else
                {
                    str += "Baudrate:保持原有波特率不变" + System.Environment.NewLine;
                }
                //显示屏宽度
                str += "ScreenWidth:" + CmdRet.ScreenWidth + System.Environment.NewLine;
                //显示屏高度
                str += "ScreenHeight:" + CmdRet.ScreenHeight + System.Environment.NewLine;
                //0x01 对于无灰度系统，单色时返回 1，双色时返回 3，三色时返回 7；对于有灰度系统，返回 255
                if (CmdRet.Color == 1)
                {
                    str += "Color:单色" + System.Environment.NewLine;
                }
                else if (CmdRet.Color == 3)
                {
                    str += "Color:双色" + System.Environment.NewLine;
                }
                else if (CmdRet.Color == 7)
                {
                    str += "Color:三色" + System.Environment.NewLine;
                }
                else
                {
                    str += "Color:灰度全彩" + System.Environment.NewLine;
                }
                //调亮模式 0x00 –手动调亮 0x01 –定时调亮 0x02 –自动调亮
                if (CmdRet.BrightnessAdjMode == 0)
                {
                    str += "BrightnessAdjMode:手动调亮" + System.Environment.NewLine;
                }
                else if (CmdRet.BrightnessAdjMode == 1)
                {
                    str += "BrightnessAdjMode:定时调亮" + System.Environment.NewLine;
                }
                else
                {
                    str += "BrightnessAdjMode:自动调亮" + System.Environment.NewLine;
                }
                //当前亮度值
                str += "CurrentBrigtness:" + CmdRet.CurrentBrigtness + System.Environment.NewLine;
                //Bit0 –定时开关机状态，0 表示无定时开关机，1 表示有定时开关机
                if (CmdRet.TimingOnOff == 0)
                {
                    str += "TimingOnOff:无定时开关机" + System.Environment.NewLine;
                }
                else
                {
                    str += "TimingOnOff:有定时开关机" + System.Environment.NewLine;
                }
                //开关机状态
                if (CmdRet.CurrentOnOffStatus == 0)
                {
                    str += "CurrentOnOffStatus:开机" + System.Environment.NewLine;
                }
                else
                {
                    str += "CurrentOnOffStatus:关机" + System.Environment.NewLine;
                }
                //扫描配置编号
                str += "ScanConfNumber:扫描配置编号 " + CmdRet.ScanConfNumber + System.Environment.NewLine;
                //一路数据带几行
                str += "RowsPerChanel:" + CmdRet.RowsPerChanel + System.Environment.NewLine;
                //对于无灰度系统，返回 0；对于有灰度系 1
                if (CmdRet.GrayFlag == 0)
                {
                    str += "GrayFlag:无灰度系统" + System.Environment.NewLine;
                }
                else
                {
                    str += "GrayFlag:有灰度系统" + System.Environment.NewLine;
                }
                //最小单元宽度
                str += "UnitWidth:最小单元宽度 " + CmdRet.UnitWidth + System.Environment.NewLine;
                //6Q 显示模式 : 0 为 888, 1 为 565，其余卡为 0
                if (CmdRet.modeofdisp == 0)
                {
                    str += "modeofdisp:6Q 显示模式 888 " + System.Environment.NewLine;
                }
                else
                {
                    str += "modeofdisp:6Q 显示模式 565 " + System.Environment.NewLine;
                }
                //当该字节为 0 时，网口通讯使用老的模式，即 UDP 和 TCP 均根据下面的PackageMode 字节确定包长，并且 UDP通讯时，将大包分为小包，每发送一小包做一下延时当该字节不为 0 时，网口通讯使用新的模式，即 UDP 的包长等于UDPPackageMode * 8KBYTE，且不再分为小包，将整包数据丢给协议栈TCP 的包长等于 PackageMode * 16KBYTE
                str += "NetTranMode:" + CmdRet.NetTranMode + System.Environment.NewLine;
                //包模式。0 小包模式，分包 600 byte。1 大包模式，分包 16K byte。
                if (CmdRet.PackageMode == 0)
                {
                    str += "PackageMode:小包模式，分包 600 byte" + System.Environment.NewLine;
                }
                else
                {
                    str += "PackageMode:大包模式，分包 16K byte" + System.Environment.NewLine;
                }
                //是否设置了条码 ID如果设置了，该字节第 0 位为 1，否则为0
                if (CmdRet.BarcodeFlag == 0)
                {
                    str += "BarcodeFlag:无条码" + System.Environment.NewLine;
                }
                else
                {
                    str += "BarcodeFlag:有条码" + System.Environment.NewLine;
                }
                //控制器上已有节目个数
                str += "ProgramNumber:控制器上已有节目个数 " + CmdRet.ProgramNumber + System.Environment.NewLine;
                //当前节目名
                str += "CurrentProgram:当前节目名 " + System.Text.Encoding.Default.GetString(CmdRet.CurrentProgram) + System.Environment.NewLine;
                //Bit0 –是否屏幕锁定，1b’0 –无屏幕锁定，1b’1 –屏幕锁定
                if (CmdRet.ScreenLockStatus == 0)
                {
                    str += "ScreenLockStatus:无屏幕锁定" + System.Environment.NewLine;
                }
                else
                {
                    str += "ScreenLockStatus:屏幕锁定" + System.Environment.NewLine;
                }
                //Bit0 –是否节目锁定，1b’0 –无节目锁定，1’b1 –节目锁定
                if (CmdRet.ProgramLockStatus == 0)
                {
                    str += "ProgramLockStatus:无节目锁定" + System.Environment.NewLine;
                }
                else
                {
                    str += "ProgramLockStatus:节目锁定" + System.Environment.NewLine;
                }
                //控制器运行模式
                str += "RunningMode:" + CmdRet.RunningMode + System.Environment.NewLine;
                //RTC 状态 0x00 – RTC 异常 0x01 – RTC 正常
                if (CmdRet.RTCStatus == 0)
                {
                    str += "RTCStatus:RTC 异常" + System.Environment.NewLine;
                }
                else
                {
                    str += "RTCStatus:RTC 正常" + System.Environment.NewLine;
                }
                //年
                str += "RTCYear:" + (Class1.ConvertBCDToInt(CmdRet.RTCYear[1]) * 100 + Class1.ConvertBCDToInt(CmdRet.RTCYear[0])) + System.Environment.NewLine;
                //月
                str += "RTCMonth:" + Class1.ConvertBCDToInt(CmdRet.RTCMonth) + System.Environment.NewLine;
                //日
                str += "RTCDate:" + Class1.ConvertBCDToInt(CmdRet.RTCDate) + System.Environment.NewLine;
                //时
                str += "RTCHour:" + Class1.ConvertBCDToInt(CmdRet.RTCHour) + System.Environment.NewLine;
                //分
                str += "RTCMinute:" + Class1.ConvertBCDToInt(CmdRet.RTCMinute) + System.Environment.NewLine;
                //秒
                str += "RTCSecond:" + Class1.ConvertBCDToInt(CmdRet.RTCSecond) + System.Environment.NewLine;
                //星期，范围为 1~7，7 表示周日
                str += "RTCWeek:星期" + CmdRet.RTCWeek + System.Environment.NewLine;
                //温度传感器当前值 第一个字节0为正1为负 数值/10
                if ((CmdRet.Temperature1[2] * 256 + CmdRet.Temperature1[1]) != 0xffff)
                {
                    if (CmdRet.Temperature1[0] == 0)
                    {
                        str += "Temperature1:+" + (CmdRet.Temperature1[2] * 256 + CmdRet.Temperature1[1]) / 10 + System.Environment.NewLine;
                    }
                    else
                    {
                        str += "Temperature1:-" + (CmdRet.Temperature1[2] * 256 + CmdRet.Temperature1[1]) / 10 + System.Environment.NewLine;
                    }
                }
                else
                {
                    str += "Temperature1:无温度传感器" + System.Environment.NewLine;
                }
                //温湿度传感器温度当前值 第一个字节0为正1为负 数值/10
                if ((CmdRet.Temperature2[2] * 256 + CmdRet.Temperature2[1]) != 0xffff)
                {
                    if (CmdRet.Temperature2[0] == 0)
                    {
                        str += "Temperature2:+" + (CmdRet.Temperature2[2] * 256 + CmdRet.Temperature2[1]) / 10 + System.Environment.NewLine;
                    }
                    else
                    {
                        str += "Temperature2:-" + (CmdRet.Temperature2[2] * 256 + CmdRet.Temperature2[1]) / 10 + System.Environment.NewLine;
                    }
                }
                else
                {
                    str += "Temperature2:无温度传感器" + System.Environment.NewLine;
                }
                //湿度传感器当前值  数值/10
                if ((CmdRet.Humidity[1] * 256 + CmdRet.Humidity[0]) != 0xffff)
                {
                    str += "Humidity:" + (CmdRet.Humidity[1] * 256 + CmdRet.Humidity[0]) / 10 + System.Environment.NewLine;
                }
                else
                {
                    str += "Humidity:无湿度传感器" + System.Environment.NewLine;
                }
                //噪声传感器当前值(除以 10 为当前值)针对 BX - ZS(485) 0xffff 时无效
                if ((CmdRet.Noise[1] * 256 + CmdRet.Noise[0]) != 0xffff)
                {
                    str += "Noise:" + (CmdRet.Noise[1] * 256 + CmdRet.Noise[0]) / 10 + System.Environment.NewLine;
                }
                else
                {
                    str += "Noise:无噪声传感器+" + System.Environment.NewLine;
                }
                //0：表示未设置 Logo 节目 1：表示设置了 Logo 节目
                if (CmdRet.LogoFlag == 0)
                {
                    str += "LogoFlag:未设置 Logo 节目" + System.Environment.NewLine;
                }
                else
                {
                    str += "LogoFlag:设置了 Logo 节目" + System.Environment.NewLine;
                }
                //0：未设置开机延时 1：开机延时时长
                if (CmdRet.PowerOnDelay == 0)
                {
                    str += "PowerOnDelay:未设置开机延时" + System.Environment.NewLine;
                }
                else
                {
                    str += "PowerOnDelay:开机延时时长 " + CmdRet.PowerOnDelay + System.Environment.NewLine;
                }
                //风速(除以 10 为当前值) 0xfffff 时无效
                if ((CmdRet.WindSpeed[1] * 256 + CmdRet.WindSpeed[0]) != 0xffff)
                {
                    str += "WindSpeed:" + (CmdRet.WindSpeed[1] * 256 + CmdRet.WindSpeed[0]) / 10 + System.Environment.NewLine;
                }
                else
                {
                    str += "WindSpeed:无风速传感器" + System.Environment.NewLine;
                }
                //风向(当前值) 0xfffff 时无效
                if ((CmdRet.WindDirction[1] * 256 + CmdRet.WindDirction[0]) != 0xffff)
                {
                    str += "WindDirction:(0:0°北风 1:45°东北风 2:90°东风 3:135°东南风 4:180°南风 5:225°西南风 6:270°西风 7:315°西北风)" + (CmdRet.WindDirction[1] * 256 + CmdRet.WindDirction[0]) + System.Environment.NewLine;
                }
                else
                {
                    str += "WindDirction:无风向传感器" + System.Environment.NewLine;
                }
                //PM2.5 值(当前值)0xfffff 时无效
                if ((CmdRet.PM2_5[1] * 256 + CmdRet.PM2_5[0]) != 0xffff)
                {
                    str += "PM2_5:" + (CmdRet.PM2_5[1] * 256 + CmdRet.PM2_5[0]) + System.Environment.NewLine;
                }
                else
                {
                    str += "PM2_5:无PM2_5传感器" + System.Environment.NewLine;
                }
                //PM10 值(当前值)0xfffff 时无效
                if ((CmdRet.PM10[1] * 256 + CmdRet.PM10[0]) != 0xffff)
                {
                    str += "PM10:" + (CmdRet.PM10[1] * 256 + CmdRet.PM10[0]) + System.Environment.NewLine;
                }
                else
                {
                    str += "PM10:无PM10传感器" + System.Environment.NewLine;
                }
                //LEDCON01 控制器名称限制为 16 个字节长度(全是 0x00 表示屏参丢失，参数无效，上位机空白显示)
                string ControllerName = "";
                for (int i = 0; i < CmdRet.ControllerName.Length; i++) { ControllerName += CmdRet.ControllerName[i].ToString("X2").ToUpper(); }
                str += "ControllerName:" + ControllerName + System.Environment.NewLine;
                //屏幕安装地址限制为 44 个字节长度(全是 0x00 表示屏参丢失，参数无效，上位机空白显示)
                string ScreenLocation = "";
                for (int i = 0; i < CmdRet.ScreenLocation.Length; i++) { ScreenLocation += CmdRet.ScreenLocation[i].ToString("X2").ToUpper(); }
                str += "ScreenLocation:" + ScreenLocation + System.Environment.NewLine;
                //控制器和屏幕安装地址共 60 个字节的CRC32 校验值，该值是为了便于上位机区分此处 64 个字节是表示控制器名称还是用来表示控制器名称和屏幕安装地址，进而采取不同的处理策略为了保持兼容，下位机不对该值进行验证
                string NameLocalationCRC32 = "";
                for (int i = 0; i < CmdRet.NameLocalationCRC32.Length; i++) { NameLocalationCRC32 += CmdRet.NameLocalationCRC32[i].ToString("X2").ToUpper(); }
                str += "NameLocalationCRC32:" + NameLocalationCRC32 + System.Environment.NewLine;
            }
        }
        //IP设置
        public static void udpSetI()
        {
            byte mode = 2;
            byte[] ip1 = Encoding.GetEncoding("GBK").GetBytes("192.168.89.178");
            byte[] subnetMask = Encoding.GetEncoding("GBK").GetBytes("255.255.255.0");
            byte[] gateway = Encoding.GetEncoding("GBK").GetBytes("192.168.89.100");
            short port1 = 5005;
            byte serverMode = 0;
            byte[] serverIP = Encoding.GetEncoding("GBK").GetBytes("127.0.0.1");
            short serverPort = 5005;
            byte[] password = Encoding.GetEncoding("GBK").GetBytes("00000000");
            short heartbeat = 20;
            byte[] netID = Encoding.GetEncoding("GBK").GetBytes("BX-NET000001");

            err = bxdualsdk.bxDual_cmd_udpSetIP(mode, ip1, subnetMask, gateway, port1, serverMode, serverIP, serverPort, password, heartbeat, netID);
        }

    }
}

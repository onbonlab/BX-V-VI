using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace LedSDKDemo_CSharp
{
    class Server
    {
        public static void Server_get()
        {
            int err = 0;
            int ServerPort = 8135;
            int port = 5005;
            //启动服务器
            int pServer = bxdualsdk.bxDual_Start_Server(ServerPort);
            byte[] cards = new byte[2048];
            //控制卡上线个数
            int count = 0;
            Thread.Sleep(2000);
            List<ServerList> server_list = new List<ServerList>();
            count = 0;
            server_list.Clear();
            
            for (int i = 0; i < 2048; i++) { cards[i] = 0; }
            while (count == 0)
            {
                //获取控制卡数据与上线数量
                count = bxdualsdk.bxDual_Get_CardList(cards);
            }
            server_list.Clear();
            //一个控制卡数据20个长度
            for (int i = 0; i < count; i++)
            {
                //前16位数据是控制卡网络ID编号
                byte[] barcodevalue = cards.Skip(0 + i * 20).Take(16).ToArray();
                //根据网络ID获取通讯使用端口
                port = bxdualsdk.bxDual_Get_Port_Barcode(barcodevalue);
                ServerList price = new ServerList(barcodevalue, port);
                server_list.Add(price);
                string ssss = Encoding.Default.GetString(barcodevalue);
                Console.WriteLine("barcode:" + i + "：" + System.Text.Encoding.Default.GetString(barcodevalue) + "   port:" + port);
                server_list.Add(price);
            }
            //启动线程，判断控制卡在线情况
            Thread thread = new Thread(t => get());
            thread.Start();

            //以第一张上线控制卡做通信示例
            //服务器IP
            byte[] server_ip = Encoding.GetEncoding("GBK").GetBytes("192.168.89.100");
            //控制卡网络ID
            byte[] barcode1 = cards.Skip(0).Take(16).ToArray();
            //控制卡通信端口
            int port1 = bxdualsdk.bxDual_Get_Port_Barcode(barcode1);

            //通信获取该控制卡信息，接口函数调用步骤与固定IP调用步骤一致，参数换成服务器IP和通信端口
            bxdualsdk.Ping_data data = new bxdualsdk.Ping_data();
            err = bxdualsdk.bxDual_cmd_tcpPing(server_ip, (ushort)port1, ref data);
            if (err == 0)
            {
                //控制卡型号值
                Console.WriteLine("ControllerType:0x" + data.ControllerType.ToString("X2"));
                //控制卡固件版本
                Console.WriteLine("FirmwareVersion:V" + System.Text.Encoding.Default.GetString(data.FirmwareVersion));
                //控制卡IP
                Console.WriteLine("ipAdder:" + System.Text.Encoding.Default.GetString(data.ipAdder));
            }
            else { Console.WriteLine("通信失败："+err); }
            while (false)
            {
                string[] s = new string[] { "装载中","未装载", "不加装" };
                for (int i = 0; i < 3; i++) { SendTextMsg(s[i], (ushort)port1);
                    Thread.Sleep(2000);
                }
            }
            

            //关闭服务器
            err = bxdualsdk.bxDual_Stop_Server(pServer);
            //结束线程
            //thread.Abort();
            //while (thread.ThreadState != ThreadState.Aborted)
            //{
            //    Thread.Sleep(100);
            //}
        }
        public static void get()
        {
            byte[] cards = new byte[2048];
            //控制卡上线个数
            int count = 0;
            Thread.Sleep(2000);
            List<ServerList> server_list = new List<ServerList>();
            count = 0;
            server_list.Clear();
            for (int i = 0; i < 2048; i++) { cards[i] = 0; }
            while (count == 0)
            {
                //获取控制卡数据与上线数量
                count = bxdualsdk.bxDual_Get_CardList(cards);
            }
            Console.WriteLine();
            server_list.Clear();
            //一个控制卡数据20个长度
            for (int i = 0; i < count; i++)
            {
                //前16位数据是控制卡网络ID编号
                byte[] barcodevalue = cards.Skip(0 + i * 20).Take(16).ToArray();
                //根据网络ID获取通讯使用端口
                int port = bxdualsdk.bxDual_Get_Port_Barcode(barcodevalue);
                ServerList price = new ServerList(barcodevalue, port);
                server_list.Add(price);
                Console.WriteLine("barcode:" + i + "：" + System.Text.Encoding.Default.GetString(barcodevalue) + "   port:" + port);
                server_list.Add(price);
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="client"></param>
        private static void SendTextMsg(string data, ushort port)
        {
            try
            {
                var content = Encoding.GetEncoding("GBK").GetBytes(data);
                var contentIntptr = Class1.BytesToIntptr(content);
                bxdualsdk.DynamicAreaParams[] Params = new bxdualsdk.DynamicAreaParams[]{
                    new bxdualsdk.DynamicAreaParams(){
                        uAreaId = 0,
                        oAreaHeader_G6 = new bxdualsdk.EQareaHeader_G6()
                        {
                            AreaType = 0x10,
                            AreaX = 64,
                            AreaY = 0,
                            AreaWidth = 64,
                            AreaHeight = 16,
                            BackGroundFlag = 0x00,
                            Transparency = 101,
                            AreaEqual = 0x00
                        },
                        stPageHeader = new bxdualsdk.EQpageHeader_G6()
                        {
                            PageStyle = 0x00,
                            DisplayMode = 1,
                            ClearMode = 1,
                            Speed = 1,
                            StayTime = 100,
                            RepeatTime = 1,
                            ValidLen = 0,
                            CartoonFrameRate = 0x00,
                            BackNotValidFlag = 0x00,
                            arrMode = bxdualsdk.E_arrMode.eSINGLELINE,
                            fontSize = 12,
                            color = (uint)0x02,
                            fontBold = 0,
                            fontItalic = 0,
                            tdirection = bxdualsdk.E_txtDirection.pNORMAL,
                            txtSpace = 0,
                            Valign = 1,
                            Halign = 1
                        },
                        fontName = Class1.BytesToIntptr(Encoding.GetEncoding("GBK").GetBytes("宋体")),
                        strAreaTxtContent = contentIntptr
                    }
                };
                byte[] server_ip = Encoding.GetEncoding("GBK").GetBytes("192.168.89.100");
                var err = bxdualsdk.bxDual_dynamicAreaS_AddTxtDetails_6G(server_ip, port
                    , bxdualsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, 1, Params);
                Console.WriteLine("bxDual_dynamicAreaS_AddTxtDetails_6G   err = " + err);
            }
            catch (Exception ex)
            {
                
            }

        }
    }
}

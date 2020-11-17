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
                Console.WriteLine("barcode:" + i + "：" + System.Text.Encoding.Default.GetString(barcodevalue) + "   port:" + port);
                server_list.Add(price);
            }
            //启动线程，判断控制卡在线情况
            Thread thread = new Thread(t => get());
            thread.Start();

            //以第一张上线控制卡做通信示例
            //服务器IP
            byte[] server_ip = Encoding.GetEncoding("GBK").GetBytes("127.0.0.1");
            //控制卡网络ID
            byte[] barcode1 = cards.Skip(0 + 20).Take(16).ToArray();
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

            

            //关闭服务器
            err = bxdualsdk.bxDual_Stop_Server(pServer);
            //结束线程
            thread.Abort();
            while (thread.ThreadState != ThreadState.Aborted)
            {
                Thread.Sleep(100);
            }
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
    }
}

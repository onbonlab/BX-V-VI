using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LedSDKDemo_CSharp
{
    /// <summary>
    /// 向控制卡发送节目文本调用示例
    /// </summary>
    class Program_Send_txt
    {
        /// <summary>
        /// BX-5代控制卡发送节目文本
        /// </summary>
        public static void Send_program_txt_5()
        {
            //指定IP ping控制卡获取控制卡数据，屏参相关参数已知的情况可省略该步骤
            bxdualsdk.Ping_data data = new bxdualsdk.Ping_data();
            int err = 0;
            if (true)
            {
                err = bxdualsdk.bxDual_cmd_tcpPing(Program.ip, Program.port, ref data);
            }
            else
            {
                err = bxdualsdk.bxDual_cmd_uart_searchController(ref data, Program.com);
            }

            //显示屏屏基色
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //第一步.设置屏幕参数相关  发送节目必要接口，发送动态区可忽略
            err = bxdualsdk.bxDual_program_setScreenParams_G56((bxdualsdk.E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, bxdualsdk.E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //第二步，创建节目，设置节目属性
            bxdualsdk.EQprogramHeader header;
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
            err = bxdualsdk.bxDual_program_addProgram(ref header);
            Console.WriteLine("bxDual_program_addProgram:" + err);
            //节目添加边框属性
            if(false)
            {
                bxdualsdk.EQscreenframeHeader sfheader;
                sfheader.FrameDispFlag = 0x01;
                sfheader.FrameDispStyle = 0x01;
                sfheader.FrameDispSpeed = 0x10;
                sfheader.FrameMoveStep = 0x01;
                sfheader.FrameWidth = 2;
                sfheader.FrameBackup = 0;
                byte[] img = Encoding.Default.GetBytes("F:\\黄10.png");
                bxdualsdk.bxDual_program_addFrame(ref sfheader, img);
            }
            //节目添加播放时段,目前仅支持一组时间，多组不支持，Time有效，Time1无效
            if(false)
            {
                bxdualsdk.EQprogrampTime_G56 Time;
                Time.StartHour = 0x13;
                Time.StartMinute = 0x25;
                Time.StartSecond = 0x00;
                Time.EndHour = 0x13;
                Time.EndMinute = 0x26;
                Time.EndSecond = 0x00;
                bxdualsdk.EQprogrampTime_G56 Time1;
                Time1.StartHour = 0x13;
                Time1.StartMinute = 0x27;
                Time1.StartSecond = 0x00;
                Time1.EndHour = 0x13;
                Time1.EndMinute = 0x28;
                Time1.EndSecond = 0x00;

                bxdualsdk.EQprogramppGrp_G56 headerGrp;
                headerGrp.playTimeGrpNum = 2;
                headerGrp.timeGrp0 = Time;
                headerGrp.timeGrp1 = Time1;
                headerGrp.timeGrp2 = Time;
                headerGrp.timeGrp3 = Time;
                headerGrp.timeGrp4 = Time;
                headerGrp.timeGrp5 = Time;
                headerGrp.timeGrp6 = Time;
                headerGrp.timeGrp7 = Time;
                err = bxdualsdk.bxDual_program_addPlayPeriodGrp(ref headerGrp);
                Console.WriteLine("program_addPlayPeriodGrp:" + err);
            }

            //第三步，创建显示分区，设置区域显示位置，示例创建一个区域编号为0，区域大小64*32的图文分区
            bxdualsdk.EQareaHeader aheader;
            aheader.AreaType = 0;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = 64;
            aheader.AreaHeight = 32;
            err = bxdualsdk.bxDual_program_AddArea(0, ref aheader);
            Console.WriteLine("bxDual_program_AddArea:" + err);
            //区域添加边框
            if (false)
            {
                bxdualsdk.EQareaframeHeader afheader;
                afheader.AreaFFlag = 0x01;
                afheader.AreaFDispStyle = 0x01;
                afheader.AreaFDispSpeed = 0x08;
                afheader.AreaFMoveStep = 0x01;
                afheader.AreaFWidth = 3;
                afheader.AreaFBackup = 0;
                byte[] img = Encoding.Default.GetBytes("黄10.png");
                bxdualsdk.bxDual_program_picturesAreaAddFrame(0, ref afheader, img);
            }

            //第四步，添加显示内容，此处为图文分区0添加字符串
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("显示内容");
            byte[] font = Encoding.GetEncoding("GBK").GetBytes("宋体");
            bxdualsdk.EQpageHeader pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 0x04;
            pheader.ClearMode = 0x01;
            pheader.Speed = 10;
            pheader.StayTime = 0;
            pheader.RepeatTime = 1;
            pheader.ValidLen = 0;
            pheader.arrMode = bxdualsdk.E_arrMode.eMULTILINE;
            pheader.fontSize = 16;
            pheader.color = (uint)0x01;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = bxdualsdk.E_txtDirection.pNORMAL;
            pheader.txtSpace = 0;
            pheader.Valign = 1;
            pheader.Halign = 1;
            err = bxdualsdk.bxDual_program_picturesAreaAddTxt(0, str, font, ref pheader);
            Console.WriteLine("bxDual_program_picturesAreaAddTxt:" + err);

            //第五步，发送节目到显示屏
            bxdualsdk.EQprogram program = new bxdualsdk.EQprogram();
            err = bxdualsdk.bxDual_program_IntegrateProgramFile(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile:" + err);
            err = bxdualsdk.bxDual_program_deleteProgram();
            Console.WriteLine("bxDual_program_deleteProgram:" + err);

            if (true)//网口
            {
                err = bxdualsdk.bxDual_cmd_ofsStartFileTransf(Program.ip, Program.port);
                Console.WriteLine("bxDual_cmd_ofsStartFileTransf:" + err);

                err = bxdualsdk.bxDual_cmd_ofsWriteFile(Program.ip, Program.port, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.bxDual_cmd_ofsEndFileTransf(Program.ip, Program.port);
                Console.WriteLine("bxDual_cmd_ofsEndFileTransf:" + err);
            }
            else//串口
            {

                err = bxdualsdk.bxDual_cmd_uart_ofsStartFileTransf(Program.com, Program.baudRate);
                Console.WriteLine("bxDual_cmd_uart_ofsStartFileTransf:" + err);

                err = bxdualsdk.bxDual_cmd_uart_ofsWriteFile(Program.com, Program.baudRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.bxDual_cmd_uart_ofsEndFileTransf(Program.com, Program.baudRate);
                Console.WriteLine("bxDual_cmd_uart_ofsEndFileTransf:" + err);
            }

            err = bxdualsdk.bxDual_program_freeBuffer(ref program);
            Console.WriteLine("bxDual_program_freeBuffer:" + err);
        }

        /// <summary>
        /// BX-6代控制卡发送节目文本
        /// </summary>
        public static void Send_program_txt_6()
        {
            //指定IP ping控制卡获取控制卡数据，屏参相关参数已知的情况可省略该步骤
            bxdualsdk.Ping_data data = new bxdualsdk.Ping_data();
            int err = 0;
            if (true)
            {
                err = bxdualsdk.bxDual_cmd_tcpPing(Program.ip, Program.port, ref data);
            }
            else
            {
                err = bxdualsdk.bxDual_cmd_uart_searchController(ref data, Program.com);
            }
            Console.WriteLine("ControllerType:0x" + data.ControllerType.ToString("X2"));
            Console.WriteLine("FirmwareVersion:V" + System.Text.Encoding.Default.GetString(data.FirmwareVersion));
            Console.WriteLine("ipAdder:" + System.Text.Encoding.Default.GetString(data.ipAdder));
            Console.WriteLine("ScreenWidth:" + data.ScreenWidth.ToString());
            Console.WriteLine("ScreenHeight:" + data.ScreenHeight.ToString());
            Console.WriteLine("cmb_ping_Color:" + data.Color.ToString());
            Console.WriteLine("\r\n");

            //显示屏屏基色
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //第一步.设置屏幕参数相关  发送节目必要接口，发送动态区可忽略
            err = bxdualsdk.bxDual_program_setScreenParams_G56((bxdualsdk.E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, bxdualsdk.E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //第二步，创建节目，设置节目属性
            bxdualsdk.EQprogramHeader_G6 header;
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
            err = bxdualsdk.bxDual_program_addProgram_G6(ref header);
            Console.WriteLine("bxDual_program_addProgram_G6:" + err);
            //节目添加播放时段,目前仅支持一组时间，多组不支持
            if (false)
            {
                bxdualsdk.EQprogrampTime_G56 Time;
                Time.StartHour = 0x17;
                Time.StartMinute = 0x29;
                Time.StartSecond = 0x00;
                Time.EndHour = 0x17;
                Time.EndMinute = 0x30;
                Time.EndSecond = 0x00;

                bxdualsdk.EQprogramppGrp_G56 headerGrp;
                headerGrp.playTimeGrpNum = 1;
                headerGrp.timeGrp0 = Time;
                headerGrp.timeGrp1 = Time;
                headerGrp.timeGrp2 = Time;
                headerGrp.timeGrp3 = Time;
                headerGrp.timeGrp4 = Time;
                headerGrp.timeGrp5 = Time;
                headerGrp.timeGrp6 = Time;
                headerGrp.timeGrp7 = Time;
                err = bxdualsdk.bxDual_program_addPlayPeriodGrp_G6(ref headerGrp);
                Console.WriteLine("program_addPlayPeriodGrp:" + err);
            }
            //节目添加边框
            if(false)
            {
                bxdualsdk.EQscreenframeHeader_G6 sfheader;
                sfheader.FrameDispStype = 0x01;    //边框显示方式
                sfheader.FrameDispSpeed = 0x10;    //边框显示速度
                sfheader.FrameMoveStep = 0x01;     //边框移动步长
                sfheader.FrameUnitLength = 2;   //边框组元长度
                sfheader.FrameUnitWidth = 2;    //边框组元宽度
                sfheader.FrameDirectDispBit = 0;//上下左右边框显示标志位，目前只支持6QX-M卡 
                byte[] img = Encoding.Default.GetBytes("F:\\黄10.png");
                bxdualsdk.bxDual_program_addFrame_G6(ref sfheader, img);
            }

            //第三步，创建显示分区，设置区域显示位置，示例创建一个区域编号为0，区域大小64*32的图文分区
            bxdualsdk.EQareaHeader_G6 aheader;
            aheader.AreaType = 0;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = data.ScreenWidth;
            aheader.AreaHeight = data.ScreenHeight;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
            bxdualsdk.EQSound_6G stSoundData = new bxdualsdk.EQSound_6G();//该语音属性在节目无效
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
            err = bxdualsdk.bxDual_program_addArea_G6(0, ref aheader);  //添加图文区域
            Console.WriteLine("bxDual_program_addArea_G6:" + err);
            //区域添加边框
            if(false)
            {
                bxdualsdk.EQscreenframeHeader_G6 sfheader;
                sfheader.FrameDispStype = 0x01;    //边框显示方式0x00 –闪烁 0x01 –顺时针转动 0x02 –逆时针转动 0x03 –闪烁加顺时针转动 0x04 –闪烁加逆时针转动 0x05 –红绿交替闪烁 0x06 –红绿交替转动 0x07 –静止打出
                sfheader.FrameDispSpeed = 0x10;    //边框显示速度
                sfheader.FrameMoveStep = 0x01;     //边框移动步长，单位为点，此参 数范围为 1~16 
                sfheader.FrameUnitLength = 2;   //边框组元长度
                sfheader.FrameUnitWidth = 2;    //边框组元宽度
                sfheader.FrameDirectDispBit = 0;//上下左右边框显示标志位，目前只支持6QX-M卡 
                byte[] img = Encoding.Default.GetBytes("E:\\黄10.png");
                bxdualsdk.bxDual_program_picturesAreaAddFrame_G6(0, ref sfheader, img);
            }

            //第四步，添加显示内容，此处为图文分区0添加字符串
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("\\FKB00خۇش كەپسىز");
            byte[] font = Encoding.GetEncoding("GBK").GetBytes("宋体");
            bxdualsdk.EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 0x04;//移动模式
            pheader.ClearMode = 0x01;
            pheader.Speed = 2;//速度
            pheader.StayTime = 100;//停留时间
            pheader.RepeatTime = 1;
            pheader.ValidLen = 0;
            pheader.CartoonFrameRate = 0x00;
            pheader.BackNotValidFlag = 0x00;
            pheader.arrMode = bxdualsdk.E_arrMode.eSINGLELINE;
            pheader.fontSize = 20;
            pheader.color = (uint)0x01;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = bxdualsdk.E_txtDirection.pNORMAL;
            pheader.txtSpace = 0;
            pheader.Valign = 1;
            pheader.Halign = 0;
            err = bxdualsdk.bxDual_program_picturesAreaAddTxt_G6(0, str, font, ref pheader);
            Console.WriteLine("bxDual_program_picturesAreaAddTxt_G6:" + err);

            //添加语音,该功能仅部分控制卡支持，一个节目只能在一个图文区添加语音播报
            if (false)
            {
                byte[] soundstr = Encoding.GetEncoding("gb2312").GetBytes("请张三到1号窗口取药");
                bxdualsdk.EQPicAreaSoundHeader_G6 psoundheader;
                psoundheader.SoundPerson = 3;
                psoundheader.SoundVolum = 5;
                psoundheader.SoundSpeed = 5;
                psoundheader.SoundDataMode = 0;
                psoundheader.SoundReplayTimes = 0;
                psoundheader.SoundReplayDelay = 1000;
                psoundheader.SoundReservedParaLen = 3;
                psoundheader.Soundnumdeal = 1;
                psoundheader.Soundlanguages = 1;
                psoundheader.Soundwordstyle = 1;
                err = bxdualsdk.bxDual_program_pictureAreaEnableSound_G6(0, psoundheader, soundstr);
                Console.WriteLine("program_pictureAreaEnableSound_G6:" + err);
            }

            //第五步，发送节目到显示屏
            bxdualsdk.EQprogram_G6 program = new bxdualsdk.EQprogram_G6();
            err = bxdualsdk.bxDual_program_IntegrateProgramFile_G6(ref program);
            Console.WriteLine("bxDual_program_IntegrateProgramFile_G6:" + err);
            err = bxdualsdk.bxDual_program_deleteProgram_G6();
            Console.WriteLine("bxDual_program_deleteProgram_G6:" + err);

            if (true)//网口
            {
                err = bxdualsdk.bxDual_cmd_ofsStartFileTransf(Program.ip, Program.port);
                Console.WriteLine("bxDual_cmd_ofsStartFileTransf:" + err);

                err = bxdualsdk.bxDual_cmd_ofsWriteFile(Program.ip, Program.port, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.bxDual_cmd_ofsWriteFile(Program.ip, Program.port, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_ofsWriteFile:" + err);
                err = bxdualsdk.bxDual_cmd_ofsEndFileTransf(Program.ip, Program.port);
                Console.WriteLine("bxDual_cmd_ofsEndFileTransf:" + err);
            }
            else//串口
            {
                err = bxdualsdk.bxDual_cmd_uart_ofsStartFileTransf(Program.com, Program.baudRate);
                Console.WriteLine("bxDual_cmd_uart_ofsStartFileTransf:" + err);

                err = bxdualsdk.bxDual_cmd_uart_ofsWriteFile(Program.com, Program.baudRate, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.bxDual_cmd_uart_ofsWriteFile(Program.com, Program.baudRate, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
                Console.WriteLine("bxDual_cmd_uart_ofsWriteFile:" + err);
                err = bxdualsdk.bxDual_cmd_uart_ofsEndFileTransf(Program.com, Program.baudRate);
            }

            err = bxdualsdk.bxDual_program_freeBuffer_G6(ref program);
            Console.WriteLine("bxDual_program_freeBuffer_G6:" + err);
        }
    }
}

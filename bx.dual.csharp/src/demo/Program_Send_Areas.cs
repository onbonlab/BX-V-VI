using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LedSDKDemo_CSharp
{
    /// <summary>
    /// 向控制卡发送节目，多区域
    /// </summary>
    class Program_Send_Areas
    {

        /// <summary>
        /// BX-5代控制卡发送节目多区域
        /// </summary>
        public static void Send_program_areas_5()
        {
            //指定IP ping控制卡获取控制卡数据，屏参相关参数已知的情况可省略该步骤
            bxdualsdk.Ping_data data = new bxdualsdk.Ping_data();
            int err = bxdualsdk.bxDual_cmd_tcpPing(Program.ip, Program.port, ref data);

            //显示屏屏基色
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //设置屏幕参数相关  发送节目必要接口，发送动态区可忽略
            err = bxdualsdk.bxDual_program_setScreenParams_G56((bxdualsdk.E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, bxdualsdk.E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //创建节目，设置节目属性
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

            //创建显示分区，设置区域显示位置，示例创建一个区域编号为0，区域大小64*32的图文分区
            bxdualsdk.EQareaHeader aheader;
            aheader.AreaType = 0;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = 64;
            aheader.AreaHeight = 16;
            err = bxdualsdk.bxDual_program_AddArea(0, ref aheader);
            Console.WriteLine("bxDual_program_AddArea:" + err);

            //添加显示内容，此处为图文分区0添加字符串
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("显示数据");
            byte[] font = Encoding.GetEncoding("GBK").GetBytes("宋体");
            bxdualsdk.EQpageHeader pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 0x02;
            pheader.ClearMode = 0x01;
            pheader.Speed = 10;
            pheader.StayTime = 0;
            pheader.RepeatTime = 1;
            pheader.ValidLen = 0;
            pheader.arrMode = bxdualsdk.E_arrMode.eMULTILINE;
            pheader.fontSize = 12;
            pheader.color = (uint)0x01;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = bxdualsdk.E_txtDirection.pNORMAL;
            pheader.txtSpace = 0;
            pheader.Valign = 1;
            pheader.Halign = 1;
            err = bxdualsdk.bxDual_program_picturesAreaAddTxt(0, str, font, ref pheader);
            Console.WriteLine("bxDual_program_picturesAreaAddTxt:" + err);

            //创建显示分区，设置区域显示位置，示例创建一个区域编号为1，区域大小64 * 32的时间分区，Y轴64，区域之间不可重叠
            bxdualsdk.EQareaHeader aheader1;
            aheader1.AreaType = 2;
            aheader1.AreaX = 0;
            aheader1.AreaY = 16;
            aheader1.AreaWidth = 64;
            aheader1.AreaHeight = 16;
            err = bxdualsdk.bxDual_program_AddArea(1, ref aheader1);
            Console.WriteLine("bxDual_program_AddArea:" + err);

            //添加时间区域显示内容
            bxdualsdk.EQtimeAreaData_G56 timeData2;
            timeData2.linestyle = bxdualsdk.E_arrMode.eMULTILINE;
            timeData2.color = (uint)bxdualsdk.E_Color_G56.eRED;
            timeData2.fontName = "宋体";
            timeData2.fontSize = 12;
            timeData2.fontBold = 0;
            timeData2.fontItalic = 0;
            timeData2.fontUnderline = 0;
            timeData2.fontAlign = 0;  //0--左对齐，1-居中，2-右对齐
            timeData2.date_enable = 0;
            timeData2.datestyle = bxdualsdk.E_DateStyle.eYYYY_MM_DD_MINUS;
            timeData2.time_enable = 1;
            timeData2.timestyle = bxdualsdk.E_TimeStyle.eHH_MM_AM;
            timeData2.week_enable = 0;
            timeData2.weekstyle = bxdualsdk.E_WeekStyle.eMonday_CHS;
            err = bxdualsdk.bxDual_program_timeAreaAddContent(1, ref timeData2);
            Console.WriteLine("bxDual_program_timeAreaAddContent:" + err);

            //发送节目到显示屏
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
        /// BX-6代控制卡发送节目多区域
        /// </summary>
        public static void Send_program_areas_6()
        {
            //指定IP ping控制卡获取控制卡数据，屏参相关参数已知的情况可省略该步骤
            bxdualsdk.Ping_data data = new bxdualsdk.Ping_data();
            int err = bxdualsdk.bxDual_cmd_tcpPing(Program.ip, Program.port, ref data);

            //显示屏屏基色
            byte cmb_ping_Color = 1;
            if (data.Color == 1) { cmb_ping_Color = 1; }
            else if (data.Color == 3) { cmb_ping_Color = 2; }
            else if (data.Color == 7) { cmb_ping_Color = 3; }
            else { cmb_ping_Color = 4; }

            //设置屏幕参数相关  发送节目必要接口，发送动态区可忽略
            err = bxdualsdk.bxDual_program_setScreenParams_G56((bxdualsdk.E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, bxdualsdk.E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
            Console.WriteLine("bxDual_program_setScreenParams_G56:" + err);

            //创建节目，设置节目属性
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

            //创建显示分区，设置区域显示位置，示例创建一个区域编号为0，区域大小64*32的图文分区
            bxdualsdk.EQareaHeader_G6 aheader;
            aheader.AreaType = 0;
            aheader.AreaX = 0;
            aheader.AreaY = 0;
            aheader.AreaWidth = 64;
            aheader.AreaHeight = 16;
            aheader.BackGroundFlag = 0x00;
            aheader.Transparency = 101;
            aheader.AreaEqual = 0x00;
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
            err = bxdualsdk.bxDual_program_addArea_G6(0, ref aheader);  //添加图文区域
            Console.WriteLine("bxDual_program_addArea_G6:" + err);

            //添加显示内容，此处为图文分区0添加字符串
            byte[] str = Encoding.GetEncoding("GBK").GetBytes("显示数据");
            byte[] font = Encoding.GetEncoding("GBK").GetBytes("宋体");
            bxdualsdk.EQpageHeader_G6 pheader;
            pheader.PageStyle = 0x00;
            pheader.DisplayMode = 0x04;//移动模式
            pheader.ClearMode = 0x01;
            pheader.Speed = 15;//速度
            pheader.StayTime = 0;//停留时间
            pheader.RepeatTime = 1;
            pheader.ValidLen = 10;
            pheader.CartoonFrameRate = 0x00;
            pheader.BackNotValidFlag = 0x00;
            pheader.arrMode = bxdualsdk.E_arrMode.eSINGLELINE;
            pheader.fontSize = 10;
            pheader.color = (uint)0x01;
            pheader.fontBold = 0;
            pheader.fontItalic = 0;
            pheader.tdirection = bxdualsdk.E_txtDirection.pNORMAL;
            pheader.txtSpace = 0;
            pheader.Valign = 1;
            pheader.Halign = 0;
            err = bxdualsdk.bxDual_program_picturesAreaAddTxt_G6(0, str, font, ref pheader);
            Console.WriteLine("bxDual_program_picturesAreaAddTxt_G6:" + err);
            
            //创建显示分区，设置区域显示位置，示例创建一个区域编号为1，区域大小64 * 32的时间分区，Y轴64，区域之间不可重叠
            bxdualsdk.EQareaHeader_G6 aheader1;
            aheader1.AreaType = 2;
            aheader1.AreaX = 0;
            aheader1.AreaY = 16;
            aheader1.AreaWidth = 64;
            aheader1.AreaHeight = 16;
            aheader1.BackGroundFlag = 0x00;
            aheader1.Transparency = 101;
            aheader1.AreaEqual = 0x00;
            aheader1.stSoundData = stSoundData;
            err = bxdualsdk.bxDual_program_addArea_G6(1, ref aheader1);
            Console.WriteLine("bxDual_program_addArea_G6:" + err);

            //添加时间区域显示内容
            bxdualsdk.EQtimeAreaData_G56 timeData2;
            timeData2.linestyle = bxdualsdk.E_arrMode.eMULTILINE;
            timeData2.color = (uint)bxdualsdk.E_Color_G56.eRED;
            timeData2.fontName = "simsun";
            timeData2.fontSize = 10;
            timeData2.fontBold = 0;
            timeData2.fontItalic = 0;
            timeData2.fontUnderline = 0;
            timeData2.fontAlign = 1;  //0--左对齐，1-居中，2-右对齐
            timeData2.date_enable = 0;
            timeData2.datestyle = bxdualsdk.E_DateStyle.eYYYY_MM_DD_MINUS;
            timeData2.time_enable = 1;
            timeData2.timestyle = bxdualsdk.E_TimeStyle.eHH_MM_COLON;
            timeData2.week_enable = 0;
            timeData2.weekstyle = bxdualsdk.E_WeekStyle.eMonday;
            err = bxdualsdk.bxDual_program_timeAreaAddContent_G6(1, ref timeData2);
            Console.WriteLine("bxDual_program_timeAreaAddContent_G6:" + err);

            //发送节目到显示屏
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

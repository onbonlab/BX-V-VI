Imports System.Runtime.InteropServices
Imports System.Text

Module Module1

    Dim err As Integer
    Sub Main()
        err = Ledsdk.bxDual_InitSdk()
        Console.WriteLine("InitSdk：" + err.ToString())

        Dim arr As Ledsdk.Ping_data
        arr.ControllerType = 0
        arr.FirmwareVersion = {0, 0, 0, 0, 0, 0, 0, 0}
        arr.ScreenParaStatus = 0
        arr.uAddress = 0
        arr.Baudrate = 0
        arr.ScreenWidth = 0
        arr.ScreenHeight = 0
        arr.Color = 0
        arr.CurrentBrigtness = 0
        arr.CurrentOnOffStatus = 0
        arr.ScanConfNumber = 0
        arr.reversed = {0, 0, 0, 0, 0, 0, 0, 0, 0}
        arr.ipAdder = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        err = Ledsdk.bxDual_cmd_udpPing(arr)
        Console.WriteLine("cmd_udpPing：" + err.ToString())
        Console.WriteLine("ControllerType:&H" + arr.ControllerType.ToString("X2"))
        Console.WriteLine("FirmwareVersion:V" + System.Text.Encoding.Default.GetString(arr.FirmwareVersion))
        Console.WriteLine("ipAdder:" + System.Text.Encoding.Default.GetString(arr.ipAdder))

        Ledsdk.bxDual_program_setScreenParams_G56(Ledsdk.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, arr.ControllerType, Ledsdk.E_DoubleColorPixel.eDOUBLE_COLOR_PIXTYPE_2)
        Creat_Program_6()
        Creat_Area_6(0)
        Creat_AddStr_6()
        Creat_AddSound_6()
        Net_SengProgram_6(arr.ipAdder)

        Ledsdk.bxDual_ReleaseSdk()
        Console.WriteLine("ReleaseSdk：" + err.ToString())
    End Sub

    '创建节目
    Public Sub Creat_Program_5()
        Dim header As Ledsdk.EQprogramHeader
        header.FileType = &H0
        header.ProgramID = 0
        header.ProgramStyle = &H0
        header.ProgramPriority = &H0
        header.ProgramPlayTimes = 1
        header.ProgramTimeSpan = 0
        header.ProgramWeek = &HFF
        header.ProgramLifeSpan_sy = &HFFFF
        header.ProgramLifeSpan_sm = &H3
        header.ProgramLifeSpan_sd = &H14
        header.ProgramLifeSpan_ey = &HFFFF
        header.ProgramLifeSpan_em = &H3
        header.ProgramLifeSpan_ed = &H14
        header.PlayPeriodGrpNum = 0
        err = Ledsdk.bxDual_program_addProgram(header)
        Console.WriteLine("program_addProgram:" + err.ToString())
    End Sub
    Public Sub Creat_Program_6()
        Dim header As Ledsdk.EQprogramHeader_G6
        header.FileType = &H0
        header.ProgramID = 0
        header.ProgramStyle = &H0
        header.ProgramPriority = &H0
        header.ProgramPlayTimes = 1
        header.ProgramTimeSpan = 0
        header.SpecialFlag = 0
        header.CommExtendParaLen = &H0
        header.ScheduNum = 0
        header.LoopValue = 0
        header.Intergrate = &H0
        header.TimeAttributeNum = &H0
        header.TimeAttribute0Offset = &H0
        header.ProgramWeek = &HFF
        header.ProgramLifeSpan_sy = &HFFFF
        header.ProgramLifeSpan_sm = &H3
        header.ProgramLifeSpan_sd = &H14
        header.ProgramLifeSpan_ey = &HFFFF
        header.ProgramLifeSpan_em = &H3
        header.ProgramLifeSpan_ed = &H14
        header.PlayPeriodGrpNum = 0
        err = Ledsdk.bxDual_program_addProgram_G6(header)
        Console.WriteLine("program_addProgram_G6:" + err.ToString())
    End Sub
    '创建区域
    Public Sub Creat_Area_5(ByVal AreaType As Byte)
        Dim aheader As Ledsdk.EQareaHeader
        aheader.AreaType = AreaType
        aheader.AreaX = 16
        aheader.AreaY = 0
        aheader.AreaWidth = 64
        aheader.AreaHeight = 32

        err = Ledsdk.bxDual_program_AddArea(0, aheader)  '添加图文区域
        Console.WriteLine("program_addArea:" + err.ToString())
    End Sub
    Public Sub Creat_Area_6(ByVal AreaType As Byte)
        Dim aheader As Ledsdk.EQareaHeader_G6
        aheader.AreaType = AreaType
        aheader.AreaX = 0
        aheader.AreaY = 0
        aheader.AreaWidth = 64
        aheader.AreaHeight = 32
        aheader.BackGroundFlag = &H0
        aheader.Transparency = 101
        aheader.AreaEqual = &H0
        Dim stSoundData As Ledsdk.EQSound_6G
        stSoundData.SoundFlag = 0
        stSoundData.SoundVolum = 0
        stSoundData.SoundSpeed = 0
        stSoundData.SoundDataMode = 0
        stSoundData.SoundReplayTimes = 0
        stSoundData.SoundReplayDelay = 0
        stSoundData.SoundReservedParaLen = 0
        stSoundData.Soundnumdeal = 0
        stSoundData.Soundlanguages = 0
        stSoundData.Soundwordstyle = 0
        stSoundData.SoundDataLen = 0

        Dim AreaText As String
        AreaText = "你好"
        Dim code As Encoding = Encoding.GetEncoding("gb2312")
        stSoundData.SoundData = System.Text.Encoding.Unicode.GetBytes(AreaText)
        aheader.stSoundData = stSoundData
        err = Ledsdk.bxDual_program_addArea_G6(0, aheader)  '添加图文区域
        Console.WriteLine("program_addArea_G6:" + err.ToString())
    End Sub
    '添加内容
    Public Sub Creat_AddStr_5()
        Dim AreaText As String
        Dim code As Encoding = Encoding.GetEncoding("gb2312")
        Dim str(), font() As Byte
        AreaText = "Hello,123"
        str = code.GetBytes(AreaText)
        AreaText = "宋体"
        font = code.GetBytes(AreaText)
        Dim pheader As Ledsdk.EQpageHeader
        pheader.PageStyle = &H0
        pheader.DisplayMode = &H3
        pheader.ClearMode = &H1
        pheader.Speed = 15
        pheader.StayTime = 500
        pheader.RepeatTime = 1
        pheader.ValidLen = 0
        pheader.arrMode = Ledsdk.E_arrMode.eSINGLELINE
        pheader.fontSize = 18
        pheader.color = Ledsdk.E_Color.eRED
        pheader.fontBold = False
        pheader.fontItalic = False
        pheader.tdirection = Ledsdk.E_txtDirection.pNORMAL
        pheader.txtSpace = 0
        pheader.Valign = 2
        pheader.Halign = 2
        err = Ledsdk.bxDual_program_picturesAreaAddTxt(0, str, font, pheader)
        Console.WriteLine("program_picturesAreaAddTxt:" + err.ToString())
    End Sub
    Public Sub Creat_AddStr_6()
        Dim AreaText As String
        Dim code As Encoding = Encoding.GetEncoding("gb2312")
        Dim str(), font() As Byte
        AreaText = "Hello,123"
        str = code.GetBytes(AreaText)
        AreaText = "宋体"
        font = code.GetBytes(AreaText)
        Dim pheader As Ledsdk.EQpageHeader_G6
        pheader.PageStyle = &H0
        pheader.DisplayMode = &H3
        pheader.ClearMode = &H1
        pheader.Speed = 15
        pheader.StayTime = 500
        pheader.RepeatTime = 1
        pheader.ValidLen = 0
        pheader.CartoonFrameRate = &H0
        pheader.BackNotValidFlag = &H0
        pheader.arrMode = Ledsdk.E_arrMode.eSINGLELINE
        pheader.fontSize = 18
        pheader.color = Ledsdk.E_Color.eRED
        pheader.fontBold = False
        pheader.fontItalic = False
        pheader.tdirection = Ledsdk.E_txtDirection.pNORMAL
        pheader.txtSpace = 0
        pheader.Valign = 2
        pheader.Halign = 2
        err = Ledsdk.bxDual_program_picturesAreaAddTxt_G6(0, str, font, pheader)
        Console.WriteLine("program_picturesAreaAddTxt_G6:" + err.ToString())
    End Sub
    '添加图片
    Public Sub Creat_Addimg_5()
        Dim AreaText As String
        Dim code As Encoding = Encoding.GetEncoding("gb2312")
        Dim str(), font() As Byte
        AreaText = "32.png"
        str = code.GetBytes(AreaText)
        AreaText = "宋体"
        font = code.GetBytes(AreaText)
        Dim pheader As Ledsdk.EQpageHeader
        pheader.PageStyle = &H0
        pheader.DisplayMode = &H3
        pheader.ClearMode = &H1
        pheader.Speed = 15
        pheader.StayTime = 500
        pheader.RepeatTime = 1
        pheader.ValidLen = 0
        pheader.arrMode = Ledsdk.E_arrMode.eSINGLELINE
        pheader.fontSize = 18
        pheader.color = Ledsdk.E_Color.eRED
        pheader.fontBold = False
        pheader.fontItalic = False
        pheader.tdirection = Ledsdk.E_txtDirection.pNORMAL
        pheader.txtSpace = 0
        pheader.Valign = 2
        pheader.Halign = 2
        err = Ledsdk.bxDual_program_pictureAreaAddPic(0, 0, pheader, str)
        Console.WriteLine("program_pictureAreaAddPic:" + err.ToString())
    End Sub
    Public Sub Creat_Addimg_6()
        Dim AreaText As String
        Dim code As Encoding = Encoding.GetEncoding("gb2312")
        Dim str(), font() As Byte
        AreaText = "32.png"
        str = code.GetBytes(AreaText)
        AreaText = "宋体"
        font = code.GetBytes(AreaText)
        Dim pheader As Ledsdk.EQpageHeader_G6
        pheader.PageStyle = &H0
        pheader.DisplayMode = &H3
        pheader.ClearMode = &H1
        pheader.Speed = 15
        pheader.StayTime = 500
        pheader.RepeatTime = 1
        pheader.ValidLen = 0
        pheader.CartoonFrameRate = &H0
        pheader.BackNotValidFlag = &H0
        pheader.arrMode = Ledsdk.E_arrMode.eSINGLELINE
        pheader.fontSize = 18
        pheader.color = Ledsdk.E_Color.eRED
        pheader.fontBold = False
        pheader.fontItalic = False
        pheader.tdirection = Ledsdk.E_txtDirection.pNORMAL
        pheader.txtSpace = 0
        pheader.Valign = 2
        pheader.Halign = 2
        err = Ledsdk.bxDual_program_pictureAreaAddPic_G6(0, 0, pheader, str)
        Console.WriteLine("program_pictureAreaAddPic_G6:" + err.ToString())
    End Sub
    '添加时间
    Public Sub Creat_Addtime_5()
        Dim AreaText As String
        Dim code As Encoding = Encoding.GetEncoding("gb2312")
        Dim str(), font() As Byte
        AreaText = "Hello,123"
        str = code.GetBytes(AreaText)
        AreaText = "宋体"
        font = code.GetBytes(AreaText)
        Dim timeData As Ledsdk.EQtimeAreaData_G56
        timeData.linestyle = Ledsdk.E_arrMode.eMULTILINE
        timeData.color = &HFF0000
        timeData.fontName = font
        timeData.fontSize = 16
        timeData.fontBold = 0
        timeData.fontItalic = 0
        timeData.fontUnderline = 0
        timeData.fontAlign = 1 '0--左对齐，1-居中，2-右对齐
        timeData.date_enable = 0
        timeData.datestyle = Ledsdk.E_DateStyle.eYYYY_MM_DD_MINUS
        timeData.time_enable = 0
        timeData.timestyle = Ledsdk.E_TimeStyle.eHH_MM_SS_COLON
        timeData.week_enable = 0
        timeData.weekstyle = Ledsdk.E_WeekStyle.eMonday_CHS
        err = Ledsdk.bxDual_program_fontPath_timeAreaAddContent(0, timeData)
        Console.WriteLine("program_fontPath_timeAreaAddContent:" + err.ToString())
    End Sub
    Public Sub Creat_Addtime_6()
        Dim AreaText As String
        Dim code As Encoding = Encoding.GetEncoding("gb2312")
        Dim str(), font() As Byte
        AreaText = "Hello,123"
        str = code.GetBytes(AreaText)
        AreaText = "宋体"
        font = code.GetBytes(AreaText)
        Dim timeData As Ledsdk.EQtimeAreaData_G56
        timeData.linestyle = Ledsdk.E_arrMode.eMULTILINE
        timeData.color = &HFF0000
        timeData.fontName = font
        timeData.fontSize = 16
        timeData.fontBold = 0
        timeData.fontItalic = 0
        timeData.fontUnderline = 0
        timeData.fontAlign = 1 '0--左对齐，1-居中，2-右对齐
        timeData.date_enable = 0
        timeData.datestyle = Ledsdk.E_DateStyle.eYYYY_MM_DD_MINUS
        timeData.time_enable = 0
        timeData.timestyle = Ledsdk.E_TimeStyle.eHH_MM_SS_COLON
        timeData.week_enable = 0
        timeData.weekstyle = Ledsdk.E_WeekStyle.eMonday_CHS
        err = Ledsdk.bxDual_program_fontPath_timeAreaAddContent_G6(0, timeData)
        Console.WriteLine("program_fontPath_timeAreaAddContent_G6:" + err.ToString())
    End Sub
    '添加表盘
    Public Sub Creat_AddClock_5()
        Dim acheader As Ledsdk.EQAnalogClockHeader_G56
        acheader.OrignPointX = 32
        acheader.OrignPointY = 16
        acheader.UnitMode = &H0
        acheader.HourHandWidth = &H2
        acheader.HourHandLen = &H8
        acheader.HourHandColor = &H1
        acheader.MinHandWidth = &H2
        acheader.MinHandLen = &HB
        acheader.MinHandColor = &H1
        acheader.SecHandWidth = &H2
        acheader.SecHandLen = &HD
        acheader.SecHandColor = &H1

        Dim ClockColor As Ledsdk.ClockColor_G56
        ClockColor.Color369 = &HFF0000
        ClockColor.ColorDot = &HFF0000
        ClockColor.ColorBG = &HFF0000
        err = Ledsdk.bxDual_program_timeAreaAddAnalogClock(0, acheader, Ledsdk.E_ClockStyle.eSQUARE, ClockColor)
        Console.WriteLine("program_timeAreaAddAnalogClock:" + err.ToString())
    End Sub
    Public Sub Creat_AddClock_6()
        Dim acheader As Ledsdk.EQAnalogClockHeader_G56
        acheader.OrignPointX = 32
        acheader.OrignPointY = 16
        acheader.UnitMode = &H0
        acheader.HourHandWidth = &H2
        acheader.HourHandLen = &H8
        acheader.HourHandColor = &H1
        acheader.MinHandWidth = &H2
        acheader.MinHandLen = &HB
        acheader.MinHandColor = &H1
        acheader.SecHandWidth = &H2
        acheader.SecHandLen = &HD
        acheader.SecHandColor = &H1

        Dim ClockColor As Ledsdk.ClockColor_G56
        ClockColor.Color369 = &HFF0000
        ClockColor.ColorDot = &HFF0000
        ClockColor.ColorBG = &HFF0000
        err = Ledsdk.bxDual_program_timeAreaAddAnalogClock_G6(0, acheader, Ledsdk.E_ClockStyle.eSQUARE, ClockColor)
        Console.WriteLine("program_timeAreaAddAnalogClock_G6:" + err.ToString())
    End Sub
    '发送 节目
    Public Sub Net_SengProgram_5(ByVal ipAdder() As Byte)
        Dim AreaText As String
        Dim code As Encoding = Encoding.GetEncoding("gb2312")
        Dim program As Ledsdk.EQprogram
        AreaText = "P000"
        program.fileName = code.GetBytes(AreaText)
        program.fileType = 0
        program.fileLen = 0
        program.fileAddre = IntPtr.Zero
        program.fileCRC32 = 0
        err = Ledsdk.bxDual_program_IntegrateProgramFile(program)

        err = Ledsdk.bxDual_cmd_ofsStartFileTransf(ipAdder, 5005)
        Console.WriteLine("cmd_ofsStartFileTransf:" + err.ToString())

        err = Ledsdk.bxDual_cmd_ofsWriteFile(ipAdder, 5005, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre)
        Console.WriteLine("cmd_ofsWriteFile:" + err.ToString())
        err = Ledsdk.bxDual_cmd_ofsEndFileTransf(ipAdder, 5005)
        Console.WriteLine("cmd_ofsEndFileTransf:" + err.ToString())
        err = Ledsdk.bxDual_program_deleteProgram()
        Console.WriteLine("program_deleteProgram:" + err.ToString())
    End Sub
    Public Sub Net_SengProgram_6(ByVal ipAdder() As Byte)
        Dim AreaText As String
        Dim code As Encoding = Encoding.GetEncoding("gb2312")
        Dim program As Ledsdk.EQprogram_G6
        AreaText = "P000"
        program.fileName = code.GetBytes(AreaText)
        program.fileType = 0
        program.fileLen = 0
        program.fileAddre = IntPtr.Zero
        program.dfileName = code.GetBytes(AreaText)
        program.dfileType = 0
        program.dfileLen = 0
        program.dfileAddre = IntPtr.Zero
        err = Ledsdk.bxDual_program_IntegrateProgramFile_G6(program)

        err = Ledsdk.bxDual_cmd_ofsStartFileTransf(ipAdder, 5005)
        Console.WriteLine("cmd_ofsStartFileTransf:" + err.ToString())

        err = Ledsdk.bxDual_cmd_ofsWriteFile(ipAdder, 5005, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre)
        Console.WriteLine("cmd_ofsWriteFile:" + err.ToString())
        err = Ledsdk.bxDual_cmd_ofsWriteFile(ipAdder, 5005, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre)
        Console.WriteLine("cmd_ofsWriteFile:" + err.ToString())
        err = Ledsdk.bxDual_cmd_ofsEndFileTransf(ipAdder, 5005)
        Console.WriteLine("cmd_ofsEndFileTransf:" + err.ToString())
        err = Ledsdk.bxDual_program_deleteProgram_G6()
        Console.WriteLine("program_deleteProgram:" + err.ToString())
    End Sub
    '发送语音
    Public Sub Creat_AddSound_6()
        Dim AreaText As String
        Dim code As Encoding = Encoding.GetEncoding("gb2312")
        Dim str() As Byte
        AreaText = "请张三到一号窗口取药"
        str = code.GetBytes(AreaText)
        Dim psound As Ledsdk.EQPicAreaSoundHeader_G6
        psound.SoundPerson = 3
        psound.SoundVolum = 5
        psound.SoundSpeed = 5
        psound.SoundDataMode = 0
        psound.SoundReplayTimes = 0
        psound.SoundReplayDelay = 1000
        psound.SoundReservedParaLen = 3
        psound.Soundnumdeal = 0
        psound.Soundlanguages = 0
        psound.Soundwordstyle = 0
        err = Ledsdk.bxDual_program_pictureAreaEnableSound_G6(0, psound, str)
        Console.WriteLine("program_pictureAreaEnableSound_G6:" + err.ToString())
    End Sub
End Module

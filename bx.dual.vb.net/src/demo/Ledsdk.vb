Imports System.Runtime.InteropServices

Public Class Ledsdk
    Public Enum E_ScreenColor_G56 As Byte
        eSCREEN_COLOR_SINGLE = 1    '单基色
        eSCREEN_COLOR_DOUBLE = 2      '双基色
        eSCREEN_COLOR_THREE = 3       '七彩色
        eSCREEN_COLOR_FULLCOLOR = 4   '全彩色
    End Enum
    Public Enum E_DoubleColorPixel As Byte
        eDOUBLE_COLOR_PIXTYPE_1 = 1 '双基色1：G+R
        eDOUBLE_COLOR_PIXTYPE_2   '双基色2：R+G
    End Enum
    Public Enum E_arrMode As UInteger
        eSINGLELINE   '单行
        eMULTILINE    '多行
    End Enum
    Public Enum E_Color As UInteger
        eBLACK     '黑色
        eRED       '红色
        eGREEN     '绿色
        eYELLOW    '黄色
    End Enum
    Public Enum E_txtDirection As UInteger
        pNORMAL       '正常
        pROTATERIGHT  '向右旋转
        pMIRROR       '镜像
        pROTATELEFT   '向左旋转
    End Enum

    Public Enum E_DateStyle As UInteger
        eYYYY_MM_DD_MINUS    'YYYY-MM-DD
        eYYYY_MM_DD_VIRGURE  'YYYY/MM/DD
        eDD_MM_YYYY_MINUS    'DD-MM-YYYY
        eDD_MM_YYYY_VIRGURE  'DD/MM/YYYY
        eMM_DD_MINUS         'MM-DD
        eMM_DD_VIRGURE       'MM/DD
        eMM_DD_CHS           'MM月DD日
        eYYYY_MM_DD_CHS      'YYYY年MM月DD日
    End Enum

    Public Enum E_TimeStyle As UInteger
        eHH_MM_SS_COLON   'HH:MM:SS
        eHH_MM_SS_CHS     'HH时MM分SS秒
        eHH_MM_COLON      'HH:MM
        eHH_MM_CHS        'HH时MM分
        eAM_HH_MM         'AM HH:MM
        eHH_MM_AM         'HH:MM AM
    End Enum

    Public Enum E_WeekStyle As UInteger
            eMonday = 1'Monday
            eMon'Mon.
            eMonday_CHS'星期一
    End Enum

    Public Enum E_Color_G56
        eBLACK '黑色
        eRED '红色
        eGREEN '绿色
        eYELLOW '黄色
        eBLUE '蓝色
        eMAGENTA '品红/洋红
        eCYAN '青色
        eWHITE '白色
    '5代时间区只支持四种颜色
    End Enum

    Public Enum E_ClockStyle
        eLINE       '线形
        eSQUARE     '方形
        eCIRCLE     '圆形
    '表盘样式
    End Enum



    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure EQSound_6G
        '1 0x00 是否使能语音播放;0 表示不使能语音; 1 表示播放下文中 SoundData 部分内容;
        Dim SoundFlag As Byte
        'SoundData 部分内容---------------------------------------------------------------------------------------------------------------------------------------------------
        '1 0x00 发音人 该值范围是 0 - 5，共 6 种选择只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 0
        Dim SoundPerson As Byte
        '1 0x05 音量该值范围是 0~10，共 11 种，0表示静音只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 5
        Dim SoundVolum As Byte
        '1 0x05 语速该值范围是 0~10，共 11 种只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 5
        Dim SoundSpeed As Byte
        '1 0x00 SoundData 的编码格式：该值意义如下：0x00 GB2312; 0x01 GBK; 0x02 BIG5; 0x03 UNICODE只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送
        Dim SoundDataMode As Byte
        ' 4 0x00000000 重播次数该值为 0，表示播放 1 次该值为 1，表示播放 2 次
        Dim SoundReplayTimes As Integer
        '......
        '该值为 0xffffffff，表示播放无限次只有 SoundFlag（是否使能语播放）为 1 时才发送该字节，否则不发送该值默认为 0
        ' 4 0x00000000 重播时间间隔该值表示两次播放语音的时间间隔，单位为 10ms只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 0
        Dim SoundReplayDelay As Integer
        ' 1 0x03 语音参数保留参数长度
        Dim SoundReservedParaLen As Byte
        ' 1 0 0：自动判断1：数字作号码处理 2：数字作数值处理只有当 SoundFlag 为 1 且SoundReservedParaLen不为 0才发送此参数
        Dim Soundnumdeal As Byte
        ' 1 0 0：自动判断语种1：阿拉伯数字、度量单位、特殊符号等合成为中文2：阿拉伯数字、度量单位、特殊符号等合成为英文只有当 SoundFlag 为 1 且 SoundReservedParaLen不为 0才发送此参数（目前只支持中英文）
        Dim Soundlanguages As Byte
        ' 1 0 0：自动判断发音方式1：字母发音方式2：单词发音方式；只有当 SoundFlag 为 1 且SoundReservedParaLen不为 0才发送此参数
        Dim Soundwordstyle As Byte
        ' 4 语音数据长度; 只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送
        Dim SoundDataLen As Integer
        ' N 语音数据只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送
        Dim SoundData() As Byte
    End Structure
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure EQtimeAreaData_G56
        '排列方式，单行还是多行
        Dim linestyle As E_arrMode
        '字体颜色
        Dim color As UInteger
        '字体名字
        Dim fontName() As Byte
        '字体大小
        Dim fontSize As UShort
        '字体加粗
        Dim fontBold As Byte
        '斜体
        Dim fontItalic As Byte
        '字体加下划线
        Dim fontUnderline As Byte
        '对齐方式--多行有效
        Dim fontAlign As Byte
        '是否添加日期
        Dim date_enable As Byte
        '日期格式
        Dim datestyle As E_DateStyle
        '是否添加时间---默认添加
        Dim time_enable As Byte
        '时间格式
        Dim timestyle As E_TimeStyle
        '是否添加星期
        Dim week_enable As Byte
        '星期格式
        Dim weekstyle As E_WeekStyle
    End Structure
    Public Structure EQAnalogClockHeader_G56
        '原点横坐标
        Dim OrignPointX As UShort
        '原点纵坐标
        Dim OrignPointY As UShort
        '表针模式
        Dim UnitMode As Byte
        '时针宽度
        Dim HourHandWidth As Byte
        '时针长度
        Dim HourHandLen As Byte
        '时针颜色
        Dim HourHandColor As UInteger
        '分针宽度
        Dim MinHandWidth As Byte
        '分针长度
        Dim MinHandLen As Byte
        '分针颜色
        Dim MinHandColor As UInteger
        '秒针宽度
        Dim SecHandWidth As Byte
        '秒针长度
        Dim SecHandLen As Byte
        '秒针颜色
        Dim SecHandColor As UInteger
    End Structure
    Public Structure ClockColor_G56
        '369点颜色
        Dim Color369 As UInteger
        '点颜色
        Dim ColorDot As UInteger
        '表盘外圈颜色 模式没有圈泽此颜色无效
        Dim ColorBG As UInteger
    End Structure


    '**************************************************************************************
    '5代、6代通用接口
    '**************************************************************************************
    '初始化函数库
    Public Declare Auto Function bxDual_InitSdk Lib "bx_sdk_dual.dll" () As Integer
    '释放函数库
    Public Declare Auto Sub bxDual_ReleaseSdk Lib "bx_sdk_dual.dll" ()
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure Ping_data
        ' 控制器类型
        '小端存储低位在前高位在后， 比如 0x254 反着取，低位表示系列，高位编号  [0x54, 0x02] 【系列，编号】
        Dim ControllerType As UShort
        ' 固件版本号            
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)> _
        Dim FirmwareVersion() As Byte
        ' 控制器参数文件状态 0x00 –控制器中没有参数配置文件，以下返回的是控制器的默认参数。 此时， PC 软件应提示用户必须先加载屏参。0x01 –控制器中有参数配置文件
        Dim ScreenParaStatus As Byte
        ' 控制器地址
        Dim uAddress As UShort
        ' 波特率
        Dim Baudrate As Byte
        ' 屏宽
        Dim ScreenWidth As UShort
        ' 屏高
        Dim ScreenHeight As UShort
        ' 显示屏颜色定义
        Dim Color As Byte
        '当前亮度值   整数1-16
        Dim CurrentBrigtness As Byte
        ' 控制器开关机状态   0 关机  1开机？
        Dim CurrentOnOffStatus As Byte
        ' 扫描配置编号
        Dim ScanConfNumber As UShort
        ' 第一个自己一路数据代几行，其他基本用不上，如有需要可参考协议取相应的字节
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=9)> _
        Dim reversed() As Byte
        ' 控制器ip地址
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=20)> _
        Dim ipAdder() As Byte
    End Structure
    '广播ping
    Public Declare Auto Function bxDual_cmd_udpPing Lib "bx_sdk_dual.dll" (ByRef retData As Ping_data) As Integer
    '设置屏相关属性
    Public Declare Auto Function bxDual_program_setScreenParams_G56 Lib "bx_sdk_dual.dll" (ByVal color As E_ScreenColor_G56, ByVal ControllerType As UShort, ByVal doubleColor As E_DoubleColorPixel) As Integer
    '写文件
    Public Declare Auto Function bxDual_cmd_ofsWriteFile Lib "bx_sdk_dual.dll" (ByVal ip() As Byte, ByVal port As UShort, ByVal fileName() As Byte, ByVal fileType As Byte,
                                                                         ByVal fileLen As Integer, ByVal overwrite As Byte, ByVal fileAddre As IntPtr) As Integer
    '开始写文件
    Public Declare Auto Function bxDual_cmd_ofsStartFileTransf Lib "bx_sdk_dual.dll" (ByVal ip() As Byte, ByVal port As UShort) As Integer
    '结束写文件
    Public Declare Auto Function bxDual_cmd_ofsEndFileTransf Lib "bx_sdk_dual.dll" (ByVal ip() As Byte, ByVal port As UShort) As Integer

    '**************************************************************************************
    '5代控制卡接口
    '**************************************************************************************
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure EQprogramHeader
        '文件类型
        '默认：0x00
        'LOGO文件:0x08
        '扫描配置文件:0x02
        '日志文件:0x06
        '字库文件:0x05
        '提示信息库文件: 0x07
        Dim FileType As Byte
        '节目ID   Bit0 –全局节目标志位 Bit1 –动态节目标志位 Bit2 –屏保节目标志位
        Dim ProgramID As UInteger
        '节目类型 
        Dim ProgramStyle As Byte
        '节目等级 注:带播放时段的节目优先级为 1，不带播放时段的节目优先级为 0
        Dim ProgramPriority As Byte
        '节目重播放次数
        Dim ProgramPlayTimes As Byte
        '播放的方式
        Dim ProgramTimeSpan As UShort
        '节目星期属性
        Dim ProgramWeek As Byte
        '年
        Dim ProgramLifeSpan_sy As UShort
        '月
        Dim ProgramLifeSpan_sm As Byte
        '日
        Dim ProgramLifeSpan_sd As Byte
        '结束年
        Dim ProgramLifeSpan_ey As UShort
        '结束日
        Dim ProgramLifeSpan_em As Byte
        '结束天
        Dim ProgramLifeSpan_ed As Byte
        '播放时段的组数
        Dim PlayPeriodGrpNum As Byte
    End Structure
    '创建节目
    Public Declare Auto Function bxDual_program_addProgram Lib "bx_sdk_dual.dll" (ByRef programH As EQprogramHeader) As Integer
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure EQareaHeader

        '区域类型
        Dim AreaType As Byte
        '区域左上角横坐标
        Dim AreaX As UShort
        '区域左上角纵坐标
        Dim AreaY As UShort
        '区域宽度
        Dim AreaWidth As UShort
        '区域高度
        Dim AreaHeight As UShort
    End Structure
    '添加区域
    Public Declare Auto Function bxDual_program_AddArea Lib "bx_sdk_dual.dll" (ByVal areaID As UShort, ByRef programH As EQareaHeader) As Integer
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure EQpageHeader
        '数据页类型
        Dim PageStyle As Byte
        '显示方式
        Dim DisplayMode As Byte
        '退出方式/清屏方式
        Dim ClearMode As Byte
        '速度等级
        Dim Speed As Byte
        '停留时间
        Dim StayTime As UShort
        '重复次数
        Dim RepeatTime As Byte
        '此字段只在左移右移方式下有效
        Dim ValidLen As UShort
        '排列方式--单行多行
        Dim arrMode As E_arrMode
        '字体大小
        Dim fontSize As UShort
        '字体颜色
        Dim color As E_Color
        '是否为粗体
        Dim fontBold As Boolean
        '是否为斜体
        Dim fontItalic As Boolean
        '文字方向
        Dim tdirection As E_txtDirection
        '文字间隔   
        Dim txtSpace As UShort
        Dim Valign As Byte
        Dim Halign As Byte
    End Structure
    '添加文本
    Public Declare Auto Function bxDual_program_picturesAreaAddTxt Lib "bx_sdk_dual.dll" (ByVal areaID As UShort, ByVal str() As Byte, ByVal fontName() As Byte, ByRef programH As EQpageHeader) As Integer
    '添加图片
    Public Declare Auto Function bxDual_program_pictureAreaAddPic Lib "bx_sdk_dual.dll" (ByVal areaID As UShort, ByVal picID As UShort, ByRef pheader As EQpageHeader, ByVal picPath() As Byte) As Integer
    '添加时间
    Public Declare Auto Function bxDual_program_fontPath_timeAreaAddContent Lib "bx_sdk_dual.dll" (ByVal areaID As UShort, ByRef pheader As EQtimeAreaData_G56) As Integer
    '添加表盘
    Public Declare Auto Function bxDual_program_timeAreaAddAnalogClock Lib "bx_sdk_dual.dll" (ByVal areaID As UShort, ByRef pheader As EQAnalogClockHeader_G56, ByRef cStyle As E_ClockStyle, ByRef cColor As ClockColor_G56)
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure EQprogram
        '节目参数文件名
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> _
        Dim fileName() As Byte
        '文件类型
        Dim fileType As Byte
        '参数文件长度
        Dim fileLen As Integer
        '文件所在的缓存地址
        Dim fileAddre As IntPtr
        '文件CRC32校验码
        Dim fileCRC32 As Integer
    End Structure
    '获取节目缓存
    Public Declare Auto Function bxDual_program_IntegrateProgramFile Lib "bx_sdk_dual.dll" (ByRef program As EQprogram) As Integer
    '删除节目缓存
    Public Declare Auto Function bxDual_program_deleteProgram Lib "bx_sdk_dual.dll" () As Integer
    '**************************************************************************************
    '6代控制卡接口
    '**************************************************************************************
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure EQprogramHeader_G6
        '文件类型
        '默认：0x00
        'LOGO文件:0x08
        '扫描配置文件:0x02
        '日志文件:0x06
        '字库文件:0x05
        '提示信息库文件: 0x07
        Dim FileType As Byte
        '节目ID   Bit0 –全局节目标志位 Bit1 –动态节目标志位 Bit2 –屏保节目标志位
        Dim ProgramID As UInteger
        '节目类型 
        Dim ProgramStyle As Byte
        '节目等级 注:带播放时段的节目优先级为 1，不带播放时段的节目优先级为 0
        Dim ProgramPriority As Byte
        '节目重播放次数
        Dim ProgramPlayTimes As Byte
        '播放的方式
        Dim ProgramTimeSpan As UShort
        '特殊节目标
        Dim SpecialFlag As Byte
        '扩展参数长度，默认为0x00
        Dim CommExtendParaLen As Byte
        '节目调度  
        Dim ScheduNum As UShort
        '调度规则循环次数
        Dim LoopValue As UShort
        '调度相关
        Dim Intergrate As Byte
        '时间属性组数
        Dim TimeAttributeNum As Byte
        '第一组时间属性偏移量--目前只支持一组
        Dim TimeAttribute0Offset As UShort
        '节目星期属性
        Dim ProgramWeek As Byte
        '年
        Dim ProgramLifeSpan_sy As UShort
        '月
        Dim ProgramLifeSpan_sm As Byte
        '日
        Dim ProgramLifeSpan_sd As Byte
        '结束年
        Dim ProgramLifeSpan_ey As UShort
        '结束日
        Dim ProgramLifeSpan_em As Byte
        '结束天
        Dim ProgramLifeSpan_ed As Byte
        '播放时段的组数
        Dim PlayPeriodGrpNum As Byte
    End Structure
    '添加节目
    Public Declare Auto Function bxDual_program_addProgram_G6 Lib "bx_sdk_dual.dll" (ByRef programH As EQprogramHeader_G6) As Integer
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure EQareaHeader_G6

        '区域类型
        Dim AreaType As Byte
        '区域左上角横坐标
        Dim AreaX As UShort
        '区域左上角纵坐标
        Dim AreaY As UShort
        '区域宽度
        Dim AreaWidth As UShort
        '区域高度
        Dim AreaHeight As UShort
        '是否有背景
        Dim BackGroundFlag As Byte
        '透明度
        Dim Transparency As Byte
        '前景、背景区域大小是否相同
        Dim AreaEqual As Byte

        '语音内容
        '使用语音功能时：部分卡需要配置串口为语音模式！！！
        Dim stSoundData As EQSound_6G
    End Structure
    '添加区域
    Public Declare Auto Function bxDual_program_addArea_G6 Lib "bx_sdk_dual.dll" (ByVal areaID As UShort, ByRef programH As EQareaHeader_G6) As Integer
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure EQpageHeader_G6
        '数据页类型
        Dim PageStyle As Byte
        '显示方式
        Dim DisplayMode As Byte
        '退出方式/清屏方式
        Dim ClearMode As Byte
        '速度等级
        Dim Speed As Byte
        '停留时间
        Dim StayTime As UShort
        '重复次数
        Dim RepeatTime As Byte
        '此字段只在左移右移方式下有效
        Dim ValidLen As UShort
        '特技为动画方式时，该值代表其帧率
        Dim CartoonFrameRate As Byte
        '背景无效标志
        Dim BackNotValidFlag As Byte
        '排列方式--单行多行
        Dim arrMode As E_arrMode
        '字体大小
        Dim fontSize As UShort
        '字体颜色
        Dim color As E_Color
        '是否为粗体
        Dim fontBold As Boolean
        '是否为斜体
        Dim fontItalic As Boolean
        '文字方向
        Dim tdirection As E_txtDirection
        '文字间隔   
        Dim txtSpace As UShort
        Dim Valign As Byte
        Dim Halign As Byte
    End Structure
    '添加文本
    Public Declare Auto Function bxDual_program_picturesAreaAddTxt_G6 Lib "bx_sdk_dual.dll" (ByVal areaID As UShort, ByVal str() As Byte, ByVal fontName() As Byte, ByRef programH As EQpageHeader_G6) As Integer
    '添加图片
    Public Declare Auto Function bxDual_program_pictureAreaAddPic_G6 Lib "bx_sdk_dual.dll" (ByVal areaID As UShort, ByVal picID As UShort, ByRef pheader As EQpageHeader_G6, ByVal picPath() As Byte) As Integer
    '添加时间
    Public Declare Auto Function bxDual_program_fontPath_timeAreaAddContent_G6 Lib "bx_sdk_dual.dll" (ByVal areaID As UShort, ByRef pheader As EQtimeAreaData_G56) As Integer
    '添加表盘
    Public Declare Auto Function bxDual_program_timeAreaAddAnalogClock_G6 Lib "bx_sdk_dual.dll" (ByVal areaID As UShort, ByRef pheader As EQAnalogClockHeader_G56, ByRef cStyle As E_ClockStyle, ByRef cColor As ClockColor_G56)
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure EQprogram_G6
        '节目参数文件名
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> _
        Dim fileName() As Byte
        '文件类型
        Dim fileType As Byte
        '参数文件长度
        Dim fileLen As Integer
        '文件所在的缓存地址
        Dim fileAddre As IntPtr
        '节目数据文件名
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> _
        Dim dfileName() As Byte
        '节目数据文件类型
        Dim dfileType As Byte
        '数据文件长度
        Dim dfileLen As Integer
        '数据文件缓存地址
        Dim dfileAddre As IntPtr
    End Structure
    '获取节目缓存
    Public Declare Auto Function bxDual_program_IntegrateProgramFile_G6 Lib "bx_sdk_dual.dll" (ByRef program As EQprogram_G6) As Integer
    '删除节目缓存
    Public Declare Auto Function bxDual_program_deleteProgram_G6 Lib "bx_sdk_dual.dll" () As Integer
    '语音接口
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure EQPicAreaSoundHeader_G6
        '1 0x00 发音人 该值范围是 0 - 5，共 6 种选择只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 0
        Dim SoundPerson As Byte
        '1 0x05 音量该值范围是 0~10，共 11 种，0表示静音只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 5
        Dim SoundVolum As Byte
        '1 0x05 语速该值范围是 0~10，共 11 种只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 5
        Dim SoundSpeed As Byte
        '1 0x00 SoundData 的编码格式：该值意义如下：0x00 GB2312; 0x01 GBK; 0x02 BIG5; 0x03 UNICODE只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送
        Dim SoundDataMode As Byte
        ' 4 0x00000000 重播次数该值为 0，表示播放 1 次该值为 1，表示播放 2 次
        Dim SoundReplayTimes As Integer
        '......
        '该值为 0xffffffff，表示播放无限次只有 SoundFlag（是否使能语播放）为 1 时才发送该字节，否则不发送该值默认为 0
        ' 4 0x00000000 重播时间间隔该值表示两次播放语音的时间间隔，单位为 10ms只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 0
        Dim SoundReplayDelay As Integer
        ' 1 0x03 语音参数保留参数长度
        Dim SoundReservedParaLen As Byte
        ' 1 0 0：自动判断1：数字作号码处理 2：数字作数值处理只有当 SoundFlag 为 1 且SoundReservedParaLen不为 0才发送此参数
        Dim Soundnumdeal As Byte
        ' 1 0 0：自动判断语种1：阿拉伯数字、度量单位、特殊符号等合成为中文2：阿拉伯数字、度量单位、特殊符号等合成为英文只有当 SoundFlag 为 1 且 SoundReservedParaLen不为 0才发送此参数（目前只支持中英文）
        Dim Soundlanguages As Byte
        ' 1 0 0：自动判断发音方式1：字母发音方式2：单词发音方式；只有当 SoundFlag 为 1 且SoundReservedParaLen不为 0才发送此参数
        Dim Soundwordstyle As Byte
    End Structure
    Public Declare Auto Function bxDual_program_pictureAreaEnableSound_G6 Lib "bx_sdk_dual.dll" (ByVal areaID As UShort, ByVal pheader As EQPicAreaSoundHeader_G6, ByVal soundData() As Byte) As Integer

End Class

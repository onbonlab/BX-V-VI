using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace LedSDKDemo_CSharp
{
    public class bx_sdk_dual
    {
        public enum E_ScreenColor_G56
        {
            eSCREEN_COLOR_SINGLE = 1,    //单基色
            eSCREEN_COLOR_DOUBLE,      //双基色
            eSCREEN_COLOR_THREE,       //七彩色
            eSCREEN_COLOR_FULLCOLOR,   //全彩色
        }
        public enum E_DoubleColorPixel_G56:int
        {
            eDOUBLE_COLOR_PIXTYPE_1 = 1, //双基色1：G+R
            eDOUBLE_COLOR_PIXTYPE_2,   //双基色2：R+G
        }

        public enum E_arrMode : int
        {
            eSINGLELINE,   //单行
            eMULTILINE,    //多行
        }

        public enum E_DateStyle : int
        {
            eYYYY_MM_DD_MINUS,   //YYYY-MM-DD
            eYYYY_MM_DD_VIRGURE, //YYYY/MM/DD
            eDD_MM_YYYY_MINUS,   //DD-MM-YYYY
            eDD_MM_YYYY_VIRGURE, //DD/MM/YYYY
            eMM_DD_MINUS,        //MM-DD
            eMM_DD_VIRGURE,      //MM/DD
            eMM_DD_CHS,          //MM月DD日
            eYYYY_MM_DD_CHS,     //YYYY年MM月DD日
        }

        public enum E_TimeStyle : int
        {
            eHH_MM_SS_COLON,  //HH:MM:SS
            eHH_MM_SS_CHS,    //HH时MM分SS秒
            eHH_MM_COLON,     //HH:MM
            eHH_MM_CHS,       //HH时MM分
            eAM_HH_MM,        //AM HH:MM
            eHH_MM_AM,        //HH:MM AM
        };

        public enum E_WeekStyle:int
        {
            eMonday = 1,    //Monday
            eMon,         //Mon.
            eMonday_CHS,  //星期一
        }

        public enum E_Color_G56
        {
            eBLACK,     //黑色
            eRED,       //红色
            eGREEN,     //绿色
            eYELLOW,    //黄色
            eBLUE,		//蓝色
            eMAGENTA,	//品红/洋红
            eCYAN,		//青色
            eWHITE,		//白色
        }  //5代时间区只支持四种颜色

        public enum E_ClockStyle
        {
            eLINE,     //线形
            eSQUARE,   //方形
            eCIRCLE,   //圆形
        };//表盘样式

        public enum E_txtDirection
        {
            pNORMAL,       //正常
            pROTATERIGHT,  //向右旋转
            pMIRROR,       //镜像
            pROTATELEFT,   //向左旋转
        };//图文区文字方向---暂不支持

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct ConfigFile
        {
            public byte FileType; //文件类型
            public byte[] ControllerName; // 控制器名称
            ushort Address; //控制器地址
            public byte Baudrate; /* 串口波特率 
						     0x00 –保持原有波特率不变
						     0x01 –强制设置为 9600
						     0x02 –强制设置为 57600*/
            ushort ScreenWidth; //显示屏宽度
            ushort ScreenHeight; // 显示屏高度
            public byte Color; /* 显示屏颜色定义 Bit0 表示红， bit1 表示绿， bit2 表示
					         蓝， 对于每一个 Bit， 0 表示灭， 1 表示亮*/
            public byte MirrorMode; // 0x00 –无镜向 0x01 –镜向
            public byte OEPol; //OE 极性，0x00 – OE 低有效   0x01 – OE 高有效
            public byte DAPol; // 数据极性， 0x00 –数据低有效， 0x01 –数据高有效
            public byte RowOrder; /*行序模式， 该值范围为 0-31
						     0-15 代表正序
						     0 代表从第 0 行开始顺序扫描
						     1 代表从第 1 行开始顺序扫描
						     .....
						     16-31 代表逆序
						     0 代表从第 0 行开始逆序扫描
						     1 代表从第 1 行开始逆序扫描*/
            public byte FreqPar; /*CLK 分频倍数
						    注意： 针对于 AX 系列， 为后级分频
						    数值为 0~15， 共 16 个等级。*/
            public byte OEWidth; // OE 宽度
            public byte OEAngle; // OE 提前角
            public byte FaultProcessMode; /*控制器的错误处理模式
								     0x00 –自动处理
								     0x01 –手动处理(此模式仅供调试人员
								     使用)*/
            public byte CommTimeoutValue; /*通讯超时设置（单位秒）
								     建议值：
								     串口– 2S
								     TCP/IP – 6S
								     GPRS – 30S*/
            public byte RunningMode; /*控制器运行模式， 具体定义如下：
							    0x00 –正常模式
							    0x01 –调试模式*/
            public byte LoggingMode; /*日志记录模式
							    0x00 –无日志
							    0x01 –只对控制器错误及对错误进行
							    的错误进行记录
							    0x02 –对控制器的所有操作进行记
							    录， 包括： 控制器接收的各条指令、
							    发生的错误及错误处理*/
            public byte GrayFlag; /*灰度标志(仅 5Q 卡时有该字节)
						     0x00–无灰度
						     0x01–灰度*/
            public byte CascadeMode; /*级联模式： (仅 5Q 卡时有该字节)
							    0x00–非级联模式
							    0x01–级联模式*/
            public byte Default_brightness; /*AX 系列控制器专用， 表示上电时， 默
								       认的亮度等级值。 根据不同的屏幕类
								       型有所不同。*/
            public byte HUBConfig;  /*HUB 板设置(仅 6E 控制器支持)
						       0x00–HUB512 默认项
						       0x01–HUB256*/
            public byte Language; /*控制器多语言显示区。
						     0x00 ----简体中文显示。
						     0x01 ----非中文显示， 控制器显示图
						     形加英文字符。
						     其他值保留。*/
            public byte Backup; // 备用字节
            ushort CRC16; //整个文件的 CRC16 校验
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Ping_data
        {
            // 控制器类型
            //小端存储低位在前高位在后， 比如 0x254 反着取，低位表示系列，高位编号  [0x54, 0x02] 【系列，编号】
            public ushort ControllerType;
            // 固件版本号            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] FirmwareVersion;
            // 控制器参数文件状态 0x00 –控制器中没有参数配置文件，以下返回的是控制器的默认参数。 此时， PC 软件应提示用户必须先加载屏参。0x01 –控制器中有参数配置文件
            public byte ScreenParaStatus;
            // 控制器地址
            public ushort uAddress;
            // 波特率
            public byte Baudrate;
            // 屏宽
            public ushort ScreenWidth;
            // 屏高
            public ushort ScreenHeight;
            // 显示屏颜色定义
            public byte Color;
            //当前亮度值   整数1-16
            public byte CurrentBrigtness;
            // 控制器开关机状态   0 关机  1开机？
            public byte CurrentOnOffStatus;
            // 扫描配置编号
            public ushort ScanConfNumber;
            // 第一个自己一路数据代几行，其他基本用不上，如有需要可参考协议取相应的字节
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
            public byte[] reversed;
            // 控制器ip地址
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public byte[] ipAdder;
        }


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct heartbeatData
        {
            public string password;    //密码
            public string ip;          //控制器IP地址
            public string subNetMask;  // 子网掩码
            public string gate;           // 网关
            public short port;            // 端口
            public string mac;           // MAC地址
            public string netID;       // 控制器网络ID
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct TimingOnOff
        {
            public byte onHour;   // 开机小时
            public byte onMinute; // 开机分钟
            public byte offHour;  // 关机小时
            public byte offMinute; // 关机分钟
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct Brightness
        {
            /*
             0x00 –手动调亮
             0x01 –定时调亮 注:以下的亮度值表，在定时调亮和手 动调亮时控制器才需处理。但在协议上 不论什么模式，此表都需要发送给控制 器
             0x00 –手动调亮
             0x01 –定时调亮 注:以下的亮度值表，在定时调亮和手 动调亮时控制器才需处理。但在协议上 不论什么模式，此表都需要发送给控制 器
             */
            public byte BrightnessMode;

            //00:00 – 00:29 的亮度值， 0x00 – 0x0f
            public byte HalfHourValue0;
            public byte HalfHourValue1;
            public byte HalfHourValue2;
            public byte HalfHourValue3;
            public byte HalfHourValue4;
            public byte HalfHourValue5;
            public byte HalfHourValue6;
            public byte HalfHourValue7;
            public byte HalfHourValue8;
            public byte HalfHourValue9;
            public byte HalfHourValue10;
            public byte HalfHourValue11;
            public byte HalfHourValue12;
            public byte HalfHourValue13;
            public byte HalfHourValue14;
            public byte HalfHourValue15;
            public byte HalfHourValue16;
            public byte HalfHourValue17;
            public byte HalfHourValue18;
            public byte HalfHourValue19;
            public byte HalfHourValue20;
            public byte HalfHourValue21;
            public byte HalfHourValue22;
            public byte HalfHourValue23;
            public byte HalfHourValue24;
            public byte HalfHourValue25;
            public byte HalfHourValue26;
            public byte HalfHourValue27;
            public byte HalfHourValue28;
            public byte HalfHourValue29;
            public byte HalfHourValue30;
            public byte HalfHourValue31;
            public byte HalfHourValue32;
            public byte HalfHourValue33;
            public byte HalfHourValue34;
            public byte HalfHourValue35;
            public byte HalfHourValue36;
            public byte HalfHourValue37;
            public byte HalfHourValue38;
            public byte HalfHourValue39;
            public byte HalfHourValue40;
            public byte HalfHourValue41;
            public byte HalfHourValue42;
            public byte HalfHourValue43;
            public byte HalfHourValue44;
            public byte HalfHourValue45;
            public byte HalfHourValue46;
            public byte HalfHourValue47;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct ControllerStatus_G56
        {
            public byte onoffStatus; // 开关机状态 Bit 0 –开机/关机， 0 表示关机， 1 表示开机
            public byte timingOnOff; // 定时开关机状态 0 表示无定时开关机， 1 表示有定时开关机
            public byte brightnessAdjMode; //亮度模式 0x00 –手动调亮 0x01 –定时调亮 0x02 –自动调亮
            public byte brightness;// 当前亮度值
            short programeNumber;// 控制器上已有节目个数
            public byte[] currentProgram;//当前节目名
            public byte screenLockStatus;//是否屏幕锁定，0 –无屏幕锁定， 1 –屏幕锁定
            public byte programLockStatus; //是否节目锁定， 0 –无节目锁定，1 –节目锁定
            public byte runningMode;//控制器运行模式
            public byte RTCStatus;//RTC 状态0x00 – RTC 异常 0x01 – RTC 正常
            short RTCYear;//年
            public byte RTCMonth;//月
            public byte RTCDate;//日
            public byte RTCHour;//时
            public byte RTCMinute;//分
            public byte RTCSecond;//秒
            public byte RTCWeek;//星期 1--7
            public byte[] temperature1;//温度1传感器当前值
            public byte[] temperature2;//温度2传感器当前值
            short humidity;//湿度传感器当前值
            short noise;//噪声传感器当前值
            public byte switchStatus; //测试按钮状态 0 –打开 1 –闭合
		public byte CustomID; //用户自定义 ID，作为网络 ID 的前半部分，便于用户识别其控制卡
		public byte BarCode; //条形码，作为网络 ID 的后半部分，用以实现网络 ID 的唯一性
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct TimingReset
        {
            public byte rstMode; //复位模式 0x00 –取消定时复位功能 0x01 –周期复位， 此时 RstInterval 字段有效 0x02 –只在指定时间复位
            uint RstInterval;//复位周期， 单位： 分钟如此字段为 0， 不进行复位操作
            public byte rstHour1; //小时 0Xff–表示此组无效， 下同
            public byte rstMin1;
            public byte rstHour2;
            public byte rstMin2;
            public byte rstHour3;
            public byte rstMin3;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct BattleTime
        {
            public short BattleRTCYear; //年
            public byte BattleRTCMonth;//月
            public byte BattleRTCDate;//日
            public byte BattleRTCHour;//时
            public byte BattleRTCMinute;//分
            public byte BattleRTCSecond;//秒
            public byte BattleRTCWeek;//星期
        }
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct EQprogrampTime_G56
        {
            public byte StartHour;
            public byte StartMinute;
            public byte StartSecond;
            public byte EndHour;
            public byte EndMinute;
            public byte EndSecond;
        };//节目的播放时段
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct EQprogramppGrp_G56
        {
            public byte playTimeGrpNum; //播放时间有效组数 0 没有播放时段全天播放 最大值8 
            public EQprogrampTime_G56 timeGrp0;
            public EQprogrampTime_G56 timeGrp1;
            public EQprogrampTime_G56 timeGrp2;
            public EQprogrampTime_G56 timeGrp3;
            public EQprogrampTime_G56 timeGrp4;
            public EQprogrampTime_G56 timeGrp5;
            public EQprogrampTime_G56 timeGrp6;
            public EQprogrampTime_G56 timeGrp7;
        };//播放时段共有8组

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct EQprogramHeader
        {
            /*
             默认：0x00
             LOGO文件:0x08
             扫描配置文件:0x02
             日志文件:0x06
             字库文件:0x05
             提示信息库文件: 0x07
             */
            public byte FileType; //文件类型
            public uint ProgramID;//节目ID

            /*
             Bit0 –全局节目标志位
             Bit1 –动态节目标志位
             Bit2 –屏保节目标志位
             */
            public byte ProgramStyle;//节目类型

            //注:带播放时段的节目优先级为 1，不 带播放时段的节目优先级为 0
            public byte ProgramPriority; //节目等级
            public byte ProgramPlayTimes;//节目重播放次数
            public ushort ProgramTimeSpan; //播放的方式
            public byte ProgramWeek;      //节目星期属性
            public ushort ProgramLifeSpan_sy;//年
            public byte ProgramLifeSpan_sm;//月
            public byte ProgramLifeSpan_sd;//日
            public ushort ProgramLifeSpan_ey;//结束年
            public byte ProgramLifeSpan_em;//结束日
            public byte ProgramLifeSpan_ed;//结束天
            //public byte PlayPeriodGrpNum;//播放时段的组数
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct EQscreenframeHeader
        {
            public byte FrameDispFlag;
            public byte FrameDispStyle;
            public byte FrameDispSpeed;
            public byte FrameMoveStep;
            public byte FrameWidth;
            public ushort FrameBackup;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct EQareaframeHeader
        {
            public byte AreaFFlag;
            public byte AreaFDispStyle;
            public byte AreaFDispSpeed;
            public byte AreaFMoveStep;
            public byte AreaFWidth;
            public ushort AreaFBackup;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct EQareaHeader
        {
            /*
             字库区域:0x01
             透明文本：0x06
         
             时间区:0x02
         
             图文字幕:0x00
         
             战斗时间：0x09
             噪声区：0x05
             温度区：0x03
             霓虹区：0x08
             湿度区：0x04
             */
            public byte AreaType; //区域类型

            public ushort AreaX; //区域X坐标
            public ushort AreaY; //区域Y坐标
            public ushort AreaWidth; //区域宽
            public ushort AreaHeight;//区域高
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct EQpageHeader
        {
            //请参考协议 图文字幕区数据格式
            public byte PageStyle; //数据页类型
            public byte DisplayMode; //显示方式 （特效）
            public byte ClearMode; // 退出方式/清屏方式
            public byte Speed; // 速度等级/背景速度等级
            public ushort StayTime; // 停留时间， 单位为 10ms
            public byte RepeatTime;//重复次数/背景拼接步长(左右拼接下为宽度， 上下拼接为高度)
            public ushort ValidLen;  //用法比较复杂请参考协议
            public E_arrMode arrMode; //排列方式--单行多行
            public ushort fontSize; //字体大小
            public uint color;//字体颜色
            public byte fontBold; //是否为粗体
            public byte fontItalic;//是否为斜体
            public E_txtDirection tdirection;//文字方向
            public ushort txtSpace; //文字间隔  	
            public byte Valign;
            public byte Halign;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct EQprogram
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] fileName; //文件名
            public byte fileType; //文件类型
            public uint fileLen; //文件长度
            public IntPtr fileAddre; // 文件所在的缓存地址
            public uint fileCRC32; //文件CRC32校验码
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct getPageData
        {
            ushort allPageNub;
            uint pageLen;
            public byte[] fileAddre;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct EQunitHeader
        {
            ushort UnitX;
            ushort UnitY;
            public byte UnitType;
            public byte Align;
            public byte UnitColor;
            public byte UnitMode;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct EQtimeAreaData_G56
        {
            public E_arrMode linestyle;			//排列方式，单行还是多行
            public uint color;				//字体颜色
            public string fontName;           //字体名字
            public ushort fontSize;           //字体大小
            public byte fontBold;           //字体加粗
            public byte fontItalic;         //斜体
            public byte fontUnderline;      //字体加下划线
            public byte fontAlign;          //对齐方式--多行有效
            public byte date_enable;        //是否添加日期
            public E_DateStyle datestyle;			//日期格式
            public byte time_enable;        //是否添加时间---默认添加
            public E_TimeStyle timestyle;			//时间格式
            public byte week_enable;        //是否添加星期
            public E_WeekStyle weekstyle;			//星期格式
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct EQAnalogClockHeader_G56
        {
            public ushort OrignPointX;    //原点横坐标
            public ushort OrignPointY;    //原点纵坐标
            public byte UnitMode;       //表针模式
            public byte HourHandWidth;  //时针宽度
            public byte HourHandLen;    //时针长度
            public uint HourHandColor;  //时针颜色
            public byte MinHandWidth;   //分针宽度
            public byte MinHandLen;     //分针长度
            public uint MinHandColor;   //分针颜色
            public byte SecHandWidth;   //秒针宽度
            public byte SecHandLen;     //秒针长度
            public uint SecHandColor;   //秒针颜色
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct EQprogramHeader_G6
        {
            /*
             默认：0x00
             LOGO文件:0x08
             扫描配置文件:0x02
             日志文件:0x06
             字库文件:0x05
             提示信息库文件: 0x07
             */
            public byte FileType; //文件类型
            public uint ProgramID;//节目ID

            /*
             Bit0 –全局节目标志位
             Bit1 –动态节目标志位
             Bit2 –屏保节目标志位
             */
            public byte ProgramStyle;			//节目类型

            //注:带播放时段的节目优先级为 1，不带播放时段的节目优先级为 0
            public byte ProgramPriority;		//节目等级
            public byte ProgramPlayTimes;		//节目重播放次数
            public ushort ProgramTimeSpan;		//播放的方式
            public byte SpecialFlag;			//特殊节目标
            public byte CommExtendParaLen;	//扩展参数长度，默认为0x00
            public ushort ScheduNum;			//节目调度  
            public ushort LoopValue;			//调度规则循环次数
            public byte Intergrate;			//调度相关
            public byte TimeAttributeNum;		//时间属性组数
            public ushort TimeAttribute0Offset; //第一组时间属性偏移量--目前只支持一组
            public byte ProgramWeek;			//节目星期属性
            public ushort ProgramLifeSpan_sy;	//年
            public byte ProgramLifeSpan_sm;	//月
            public byte ProgramLifeSpan_sd;	//日
            public ushort ProgramLifeSpan_ey;	//结束年
            public byte ProgramLifeSpan_em;	//结束日
            public byte ProgramLifeSpan_ed;	//结束天
            public byte PlayPeriodGrpNum;		//播放时段的组数
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct EQscreenframeHeader_G6
        {
            public byte FrameDispStype;    //边框显示方式
            public byte FrameDispSpeed;    //边框显示速度
            public byte FrameMoveStep;     //边框移动步长
            public byte FrameUnitLength;   //边框组元长度
            public byte FrameUnitWidth;    //边框组元宽度
            public byte FrameDirectDispBit;//上下左右边框显示标志位，目前只支持6QX-M卡    
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct EQSound_6G
        {
            public byte SoundFlag;		//1 0x00 是否使能语音播放;0 表示不使能语音; 1 表示播放下文中 SoundData 部分内容;
            //SoundData 部分内容---------------------------------------------------------------------------------------------------------------------------------------------------
            public byte SoundPerson;		//1 0x00 发音人 该值范围是 0 - 5，共 6 种选择只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 0
            public byte SoundVolum;		//1 0x05 音量该值范围是 0~10，共 11 种，0表示静音只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 5
            public byte SoundSpeed;		//1 0x05 语速该值范围是 0~10，共 11 种只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 5
            public byte SoundDataMode;	//1 0x00 SoundData 的编码格式：该值意义如下：0x00 GB2312; 0x01 GBK; 0x02 BIG5; 0x03 UNICODE只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送
            public int SoundReplayTimes;	// 4 0x00000000 重播次数该值为 0，表示播放 1 次该值为 1，表示播放 2 次
            //......
            //该值为 0xffffffff，表示播放无限次只有 SoundFlag（是否使能语播放）为 1 时才发送该字节，否则不发送该值默认为 0
            public int SoundReplayDelay;// 4 0x00000000 重播时间间隔该值表示两次播放语音的时间间隔，单位为 10ms只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 0
            public byte SoundReservedParaLen;// 1 0x03 语音参数保留参数长度
            public byte Soundnumdeal;		// 1 0 0：自动判断1：数字作号码处理 2：数字作数值处理只有当 SoundFlag 为 1 且SoundReservedParaLen不为 0才发送此参数
            public byte Soundlanguages;	// 1 0 0：自动判断语种1：阿拉伯数字、度量单位、特殊符号等合成为中文2：阿拉伯数字、度量单位、特殊符号等合成为英文只有当 SoundFlag 为 1 且 SoundReservedParaLen不为 0才发送此参数（目前只支持中英文）
            public byte Soundwordstyle;	// 1 0 0：自动判断发音方式1：字母发音方式2：单词发音方式；只有当 SoundFlag 为 1 且SoundReservedParaLen不为 0才发送此参数
            public int SoundDataLen;	// 4 语音数据长度; 只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送
            public IntPtr SoundData;		// N 语音数据只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct ClockColor_G56
        {
            public uint Color369; //369点颜色
            public uint ColorDot; //点颜色
            public uint ColorBG;  //表盘外圈颜色 模式没有圈泽此颜色无效
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct EQareaHeader_G6
        {
            public byte AreaType;		//区域类型
            public ushort AreaX;			//区域左上角横坐标
            public ushort AreaY;			//区域左上角纵坐标
            public ushort AreaWidth;		//区域宽度
            public ushort AreaHeight;		//区域高度
            public byte BackGroundFlag; //是否有背景
            public byte Transparency;   //透明度
            public byte AreaEqual;      //前景、背景区域大小是否相同

            //语音内容
            //使用语音功能时：部分卡需要配置串口为语音模式！！！
            public EQSound_6G stSoundData;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct EQPicAreaSoundHeader_G6
        {
            public byte SoundPerson;           //发音人，范围0～5，共6种选择
            public byte SoundVolum;            //音量，范围0～10
            public byte SoundSpeed;            //语速，范围0～10
            public byte SoundDataMode;         //语音数据的编码格式
            public uint SoundReplayTimes;      //重播次数
            public uint SoundReplayDelay;      //重播时间间隔
            public byte SoundReservedParaLen;  //语音参数保留参数长度，默认0x03
            public byte Soundnumdeal;          //详情见协议
            public byte Soundlanguages;        //详情见协议
            public byte Soundwordstyle;        //详情见协议
        }//图文分区播放语音

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct EQTimeAreaBattle_G6
        {
            public ushort BattleStartYear;     //起始年份（BCD格式，下同）
            public byte BattleStartMonth;    //起始月份
            public byte BattleStartDate;     //起始日期
            public byte BattleStartHour;     //起始小时
            public byte BattleStartMinute;   //起始分钟
            public byte BattleStartSecond;   //起始秒钟
            public byte BattleStartWeek;     //起始星期值
            public byte StartUpMode;         //启动模式
        } //时间分区战斗时间

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct EQpageHeader_G6
        {
            public byte PageStyle;			//数据页类型
            public byte DisplayMode;		//显示方式
            public byte ClearMode;			//退出方式/清屏方式
            public byte Speed;				//速度等级
            public ushort StayTime;			//停留时间
            public byte RepeatTime;		//重复次数
            public ushort ValidLen;			//此字段只在左移右移方式下有效
            public byte CartoonFrameRate;  //特技为动画方式时，该值代表其帧率
            public byte BackNotValidFlag;  //背景无效标志
            public E_arrMode arrMode;			//排列方式--单行多行
            public ushort fontSize;			//字体大小
            public uint color;				//字体颜色
            public byte fontBold;			//是否为粗体 0:false 1:true
            public byte fontItalic;		//是否为斜体
            public E_txtDirection tdirection;	//文字方向
            public ushort txtSpace;			//文字间隔   	
            public byte Valign;
            public byte Halign;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct EQprogram_G6
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] fileName; //节目参数文件名
            public byte fileType;	 //文件类型
            public uint fileLen;	 //参数文件长度
            public IntPtr fileAddre;   //文件所在的缓存地址
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] dfileName;//节目数据文件名
            public byte dfileType;   //节目数据文件类型
            public uint dfileLen;	 //数据文件长度
            public IntPtr dfileAddre;  //数据文件缓存地址
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct GetDirBlock_G56
        {
            public byte fileType;   //要获取的文件类型
            public ushort fileNumber; //返回有多少个文件
            public IntPtr dataAddre;  //返回文件列表地址
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct FileAttribute_G56
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] fileName;  //文件名
            public byte fileType;     //文件类型
            public int fileLen;      //文件长度
            public int fileCRC;      //文件CRC校验
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct EQdynamicHeader
        {
            public byte RunMode;
            ushort Timeout;
            public byte ImmePlay;
            public byte AreaType;
            ushort AreaX;
            ushort AreaY;
            ushort AreaWidth;
            ushort AreaHeight;
        }

        
    /**************************************************************************************
    ***5代、6代通用接口
    **************************************************************************************/
        //初始化动态库
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_InitSdk();

        //释放动态库
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern void bxDual_ReleaseSdk();

        /*! ***************************************************************
        * 函数名：       cmd_udpPing（）
        * 参数名：retData 请参考结构体Ping_data 所有回读参数都会通过结构体回调
        * 返回值：0 成功， 其他值为错误号
        * 功 能：UDP ping 命令
        * 注：
        * 此命令用来搜索加屏使用
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_udpPing(byte[] retData); //UDP ping命令并返回IP地址
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_tcpPing(byte[] ip, ushort port,ref Ping_data retData); 

        /*! ***************************************************************
        * 函数名：       program_setScreenParams_G56（）
        * 返回值：0 成功， 其他值为错误号
        * 功 能：设置屏相关属性
        * 注：
        * 三个参数请参考各自枚举值
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_setScreenParams_G56(E_ScreenColor_G56 color, ushort ControllerType, E_DoubleColorPixel_G56 doubleColor); //设置屏相关属性

        /*! ***************************************************************
        * 函数名：       cmd_ofsWriteFile（）
        * 参数名：ip：控制器IP， port：控制器端口
        *	fileName：文件名
        *	fileType：文件类型
        *	fileLen：文件长度
        *	fileAddre：文件所在的缓存地址
        *	overwrite：是否覆盖控制上的文件 1覆盖 0不覆盖 建议发1
        * 返回值：0 成功， 其他值为错误号
        * 功 能：写文件到控制
        * 注：用于对存储在 OFS 中的文件的处理， 例如： 节目文件， 字库文件、 播放列表文件等
        * 内部包含多条命令注意返回状态方便查找问题
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_ofsWriteFile(byte[] ip, ushort port, byte[] fileName, byte fileType, uint fileLen, byte overwrite, IntPtr fileAddre);

        /*! ***************************************************************
        * 函数名：       cmd_ofsStartFileTransf（）
        * 参数名：ip：控制器IP， port：控制器端口
        * 返回值：0 成功， 其他值为错误号
        * 功 能：开始批量写文件
        * 注：
        * 发送节目前调用
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_ofsStartFileTransf(byte[] ip, ushort port);

        /*! ***************************************************************
        * 函数名：       cmd_ofsEndFileTransf（）
        * 参数名：ip：控制器IP， port：控制器端口
        * 返回值：0 成功， 其他值为错误号
        * 功 能：写文件结束
        * 注：
        * 发送节目后调用
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_ofsEndFileTransf(byte[] ip, ushort port);

        /*! ***************************************************************
        * 函数名：       cmd_ofsReedDirBlock（）
        * 参数名：ip：控制器IP， port：控制器端口
        *	dirBlock: 读会的文件列表，具体的具体参考GetDirBlock_G56结构体
        * 返回值：0 成功， 其他值为错误号
        * 功 能：获取文件列表
        * 注：
        * 下面几条命令用法比较复杂请配合协议使用不做嗷述
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_ofsReedDirBlock(byte[] ip, ushort port, byte[] dirBlock);

        /*! ***************************************************************
        * 函数名：  cmd_getFileAttr（）
        * 参数名：
        *	dirBlock: 上一条命令的回传结构体
        *	number: 要获取的第几个文件的属性
        *	fileAttr： 获取到的文件属性存放位置参考结构体FileAttribute_G56；
        * 返回值：0 成功， 其他值为错误号
        * 功 能：获取指定文件的属性
        * 注：
        * number：此参数值小于fileAttr.fileName 从0开始
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_getFileAttr(byte[] dirBlock, int number, byte[] fileAttr);

        /*! ***************************************************************
        * 函数名：       cmd_ofsDeleteFormatFile（）
        * 参数名：ip：控制器IP， port：控制器端口
        *	fileNub:要删除的文件个数
        *	fileName：要删除的文件名
        * 返回值：0 成功， 其他值为错误号
        * 功 能：删除文件
        * 注：
        * fileName是4个字节 fileNub值为N就要把N个fileName拼接 fileName大小 = fileName（4byte）*N
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_ofsDeleteFormatFile(byte[] ip, ushort port, short fileNub, string fileName);

        /*! ***************************************************************
        * 函数名：       cmd_uart_searchController（）
        * 参数名：retData 请参考结构体Ping_data 所有回读参数都会通过结构体回调
        * 返回值：0 成功， 其他值为错误号
        * 功 能：搜索控制器命令
        * 注：
        * 通过串口通讯方式（9600、57600）搜索控制器
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_searchController(byte[] retData, byte[] uartPort);

        /*! ***************************************************************
        * 函数名：       cmd_uart_ofsStartFileTransf（）
        * 参数名：uartPort：串口端口号， baudRate：波特率
        * 返回值：0 成功， 其他值为错误号
        * 功 能：开始批量写文件
        * 注：
        * 发送节目前调用
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_ofsStartFileTransf(byte[] uartPort, byte baudRate);

        /*! ***************************************************************
        * 函数名：       cmd_uart_ofsWriteFile（）
        * 参数名：uartPort：串口端口号， baudRate：波特率
        *	fileName：文件名
        *	fileType：文件类型
        *	fileLen：文件长度
        *	fileAddre：文件所在的缓存地址
        *	overwrite：是否覆盖控制上的文件 1覆盖 0不覆盖 建议发1
        * 返回值：0 成功， 其他值为错误号
        * 功 能：写文件到控制
        * 注：用于对存储在 OFS 中的文件的处理， 例如： 节目文件， 字库文件、 播放列表文件等
        * 内部包含多条命令注意返回状态方便查找问题
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_ofsWriteFile(byte[] uartPort, byte baudRate, byte[] fileName, byte fileType, uint fileLen, byte overwrite, IntPtr fileAddre);

        /*! ***************************************************************
        * 函数名：       cmd_uart_confWriteFile（）
	        * 参数名：uartPort：串口端口号， baudRate：波特率
        *	fileName：文件名
        *	fileType：文件类型
        *	fileLen：文件长度
        *	fileAddre：文件所在的缓存地址
        *	overwrite：是否覆盖控制上的文件 1覆盖 0不覆盖 建议发1
        * 返回值：0 成功， 其他值为错误号
        * 功 能：写文件到控制
        * 注：此函数用于对存储在固定位置的文件进行处理， 例
	          如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
        * 内部包含多条命令注意返回状态方便查找问题
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_confWriteFile(byte[] uartPort, byte baudRate, byte[] fileName, byte fileType, uint fileLen, byte overwrite, IntPtr fileAddre);

        /*! ***************************************************************
        * 函数名：       cmd_uart_ofsEndFileTransf（）
        * 参数名：uartPort：串口端口号， baudRate：波特率
        * 返回值：0 成功， 其他值为错误号
        * 功 能：写文件结束
        * 注：
        * 发送节目后调用
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_ofsEndFileTransf(byte[] uartPort, byte baudRate);

        /*! ***************************************************************
        * 函数名：       cmd_sysReset（）
        * 参数名：ip， 控制器IP， port 控制器端口
        * 返回值：0 成功， 其他值为错误号
        * 功 能：让系统复位
        * 注：
        * 此命令调用后所有参数全部会丢失
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_sysReset(byte[] ip, ushort port);

        /*! ***************************************************************
        * 函数名：       cmd_coerceOnOff（）
        * 参数名：ip：控制器IP， port：控制器端口，onOff：控制器状态：0x01 –开机 0x00 –关机
        * 返回值：0 成功， 其他值为错误号
        * 功 能：强制开挂机命令
        * 注：
        *
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_coerceOnOff(byte[] ip, ushort port, byte onOff);

        /*! ***************************************************************
        * 函数名：       cmd_timingOnOff（）
        * 参数名：ip：控制器IP， port：控制器端口，groupNum：有几组定时开关机 data：TimingOnOff结构体的地址
        * 返回值：0 成功， 其他值为错误号
        * 功 能：定时开关机命令
        * 注：
        * groupNum值是n组情况,data大小 = n * TimingOnOff
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_timingOnOff(byte[] ip, ushort port, byte groupNum, TimingOnOff[] data);

        /*! ***************************************************************
        * 函数名：       cmd_cancelTimingOnOff（）
        * 参数名：ip：控制器IP， port：控制器端口
        * 返回值：0 成功， 其他值为错误号
        * 功 能：取消定时开关机
        * 注：
        *
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_cancelTimingOnOff(byte[] ip, ushort port);

        /*! ***************************************************************
        * 函数名：       cmd_readControllerID（）
        * 参数名：ip：控制器IP， port：控制器端口， ControllerID：传回控制器ID
        * 返回值：0 成功， 其他值为错误号
        * 功 能：读控制器ID
        * 注：
        * ControllerID是8个字节 请定义char data[8];
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_readControllerID(byte[] ip, ushort port, byte[] ControllerID);


        /*! ***************************************************************
        * 函数名：       cmd_screenLock（）
        * 参数名：ip：控制器IP， port：控制器端口
        *         nonvolatile：状态是否掉电保存 0x00 –掉电不保存 0x01 –掉电保存
        *         lock： 0x00 –解锁  0x01 –锁定
        * 返回值：0 成功， 其他值为错误号
        * 功 能：屏幕锁定
        * 注：
        *
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_screenLock(byte[] ip, ushort port, byte nonvolatile, byte locked);


        /*! ***************************************************************
        * 函数名：       cmd_programLock（）
        * 参数名：ip：控制器IP， port：控制器端口
        *         nonvolatile： 状态是否掉电保存 0x00 –掉电不保存  0x01 –掉电保存
        *         lock：0x00 –解锁  0x01 –锁定
        *         name： 节目名称4（byte）个字节
        *         lockDuration: 节目锁定时间长度， 单位为 10 毫秒， 例
        *         如当该值为 100 时表示锁定节目 1 秒.注意： 当该值为 0xffffffff 时表示节目锁定无时间长度限制
        * 返回值：0 成功， 其他值为错误号
        * 功 能：节目锁定
        * 注：
        * 具体使用方法参考协议
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_programLock(byte[] ip, ushort port, byte nonvolatile, byte locked, byte[] name, uint lockDuration);


        /*! ***************************************************************
        * 函数名：       cmd_check_controllerStatus（）
        * 参数名：ip：控制器IP， port：控制器端口， controllerStatus：请参考结构体ControllerStatus_G56
        * 返回值：0 成功， 其他值为错误号
        * 功 能：读控制器状态
        * 注：
        * ControllerStatus_G56和协议时对应的可以参考协议的具体用法
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_check_controllerStatus(byte[] ip, ushort port, ref ControllerStatus_G56 controllerStatus);

        /*! ***************************************************************
        * 函数名：       cmd_setPassword（）
        * 参数名：ip：控制器IP， port：控制器端口， oldPassword：老密码， newPassword新密码
        * 返回值：0 成功， 其他值为错误号
        * 功 能：设置控制器密码
        * 注：
        * 设置后一定要记住，设置后就不在能明码通讯
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_setPassword(byte[] ip, ushort port, byte[] oldPassword, byte[] newPassword);

        /*! ***************************************************************
        * 函数名：       cmd_deletePassword（）
        * 参数名：ip：控制器IP， port：控制器端口， password：输出当前控制密码
        * 返回值：0 成功， 其他值为错误号
        * 功 能：删除当前控制器密码
        * 注：
        *
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_deletePassword(byte[] ip, ushort port, byte[] password);

        /*! ***************************************************************
        * 函数名：       cmd_setDelayTime（）
        * 参数名：ip：控制器IP， port：控制器端口， delayTime：开机延时单位秒
        * 返回值：0 成功， 其他值为错误号
        * 功 能：设置控制开机延时时间
        * 注：
        *
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_setDelayTime(byte[] ip, ushort port, short delayTime);

        /*! ***************************************************************
        * 函数名：       cmd_setBtnFunc（）
        * 参数名：ip：控制器IP， port：控制器端口， btnMode：按钮模式 0x00–测试按钮 0x01 –沿触发切换节目 0x02 –电平触发切换节目
        * 返回值：0 成功， 其他值为错误号
        * 功 能：设置控制测试按钮功能
        * 注：
        * 具体细节参考协议
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_setBtnFunc(byte[] ip, ushort port, byte btnMode);

        /*! ***************************************************************
        * 函数名：       cmd_setTimingReset（）
        * 参数名：ip：控制器IP， port：控制器端口， cmdData：参考结构体TimingReset
        * 返回值：0 成功， 其他值为错误号
        * 功 能：设置控制重启重启时间
        * 注：
        * 具体细节参考协议
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_setTimingReset(byte[] ip, ushort port,ref TimingReset cmdData);

        /*! ***************************************************************
        * 函数名：       cmd_setDispMode（）
        * 参数名：ip：控制器IP， port：控制器端口
        *		dispMode：控制器的显示模式（目前只针对 BX-5E系列控制器）
        *		Bit0 –串/并行， 0 表示并行， 1 表示并行
        *		Bit1–同步使能， 1 使能同步， 0 禁止同步
        * 返回值：0 成功， 其他值为错误号
        * 功 能：设置控制重启重启时间
        * 注：
        * 具体细节参考协议
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_setDispMode(byte[] ip, ushort port, byte dispMode);

    /**************************************************************************************
    ***5代控制卡接口
    **************************************************************************************/
        /*! ***************************************************************
        * 函数名：       program_addProgram（）
        *	programH：参考结构体EQprogramHeader
        * 返回值：0 成功， 其他值为错误
        * 功 能：添加节目句柄
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_addProgram(IntPtr programH); //添加节目句柄

        /*! ***************************************************************
        * 函数名：       program_AddArea（）
        * 参数名：
        *	areaID：区域的ID号
        *	aheader：参考结构体EQareaHeader
        * 返回值：0 成功， 其他值为错误号
        * 功 能：添加区域句柄
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_AddArea(ushort areaID, IntPtr aheader);//添加区域句柄

        /*! ***************************************************************
        * 函数名：       program_picturesAreaAddTxt（）
        *	areaID：区域的ID号
        *	str：需要画的字符
        *	fontName：字体名称
        *	pheader：参考结构体EQpageHeader
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：画字符到图文区
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_picturesAreaAddTxt(ushort areaID, byte[] str, byte[] fontName, IntPtr pheader);//画字符到区域

        /*! ***************************************************************
        * 函数名：       program_picturesAreaAddPic（）
        *	areaID：区域的ID号
        *   picID：图片的ID号
        *	EQpageHeader：参考结构体EQpageHeader
        *	picPath：添加的图片路径
        * 返回值：0 成功， 其他值为错误号
        * 功 能：添加图片到区域
        * 注：
        * 
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_pictureAreaAddPic(ushort areaID, ushort picID, IntPtr pheader, byte[] picPath);

        /*! ***************************************************************
        * 函数名：       program_fontPath_timeAreaAddContent()
        *	areaID：区域的ID号
        *   timeData:详情请见时间区数据格式结构体EQtimeAreaData_G56
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区添加内容EQtimeAreaData::fontName == 字库名称
        * 注：ios下无法使用program_timeAreaAddContent请使用program_fontPath_timeAreaAddContent()
        * 
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_fontPath_timeAreaAddContent(ushort areaID, IntPtr timeData);

        /*! ***************************************************************
        * 函数名：       program_timeAreaAddAnalogClock(）
        * 参数名：
        *	areaID：区域ID
        *   header: 详情见EQAnalogClockHeader_G56结构体
        *   cStyle: 表盘样式，详情见E_ClockStyle
        *   cColor: 表盘颜色，详情见E_Color
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区添加模拟时钟
        * 注：
        *
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaAddAnalogClock(ushort areaID, IntPtr header, E_ClockStyle cStyle, ref  ClockColor_G56 cColor);

        /*! ***************************************************************
        * 函数名：       program_IntegrateProgramFile（）
        * 参数名：
        *	program：参考结构体EQprogram
        * 返回值：0 成功， 其他值为错误号
        * 功 能：合成节目文件返回节目文件属性及地址
        * 注：
        * EQprogram 结构体是用来回调发送文件所需要参数
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_IntegrateProgramFile(byte[] program);

        /*! ***************************************************************
        * 函数名：       program_deleteProgram（）
        * 返回值：0 成功， 其他值为错误
        * 功 能：删除节目
        * 注：
        * 
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_deleteProgram();

    /**************************************************************************************
    ***6代控制卡接口
    **************************************************************************************/
        /*! ***************************************************************
        * 函数名：       program_addProgram_G6(）
        * 参数名：
        *	EQprogramHeader_G6：参考结构体EQprogramHeader_G6
        * 返回值：0 成功， 其他值为错误号
        * 功 能：添加节目
        * 注：
        *
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_addProgram_G6(IntPtr programH);

        /*! ***************************************************************
        * 函数名：       program_addArea_G6（）
        * 参数名：areaID：区域的ID号
        *	aheader：参考结构体EQareaHeader_G6
        *   
        * 返回值：0 成功， 其他值为错误号
        * 功 能：节目添加区域
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_addArea_G6(ushort areaID, IntPtr aheader);

        /*! ***************************************************************
        * 函数名：       program_picturesAreaAddTxt_G6（）
        *	areaID：区域的ID号
        *	str：需要画的文字
        *	fontName：字体名称
        *	pheader：参考结构体EQpageHeader_G6
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：画文字到图文区域
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_picturesAreaAddTxt_G6(ushort areaID, byte[] str, byte[] fontName, IntPtr pheader);

        /*! ***************************************************************
        * 函数名：       program_picturesAreaAddTxt_G6（）
        *	areaID：区域的ID号
        *	str：需要画的文字
        *	fontName：字体名称
        *	pheader：参考结构体EQpageHeader_G6
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：画文字到图文区域
        * 注：
        * 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_fontPath_picturesAreaAddTxt_G6(ushort areaID, byte[] str, byte[] fontName, IntPtr pheader);

        /*! ***************************************************************
        * 函数名：       program_pictureAreaAddPic_G6（）
        *	areaID：区域的ID号
        *   picID：图片编号，从0开始，第一次添加图片为0，第二次添加图片为1，依次累加，每个id对应一张图片
        *	EQpageHeader_G6：参考结构体EQpageHeader_G6
        *	picPath：图片的绝对路径加图片名称
        * 返回值：0 成功， 其他值为错误号
        * 功 能：添加图片到图文区域
        * 注：下位机播放图片的次序与picID一致，即最先播放picID为0的图片，依次播放
        * 
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_pictureAreaAddPic_G6(ushort areaID, ushort picID, IntPtr pheader, byte[] picPath);

        /*! ***************************************************************
        * 函数名：       program_fontPath_timeAreaAddContent_G6()
        *	areaID：区域的ID号
        *   timeData:详情请见时间区数据格式结构体EQtimeAreaData_G56
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区添加内容EQtimeAreaData::fontName == 字库名称
        * 注：ios下无法使用program_timeAreaAddContent_G6请使用program_fontPath_timeAreaAddContent_G6()
        * 
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_fontPath_timeAreaAddContent_G6(ushort areaID, IntPtr timeData);
        /*! ***************************************************************
        * 函数名：       program_timeAreaAddContent_G6（）
        *	areaID：区域的ID号
        *   timeData：参考结构体EQtimeAreaData_G56
        *
        *
        * 返回值：0 成功， 其他值为错误
        * 功 能：时间分区添加时间等内容，详情请参考结构体EQtimeAreaData_G56
        * 注：
        * 
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaAddContent_G6(ushort areaID, IntPtr timeData);

        /*! ***************************************************************
        * 函数名：       program_timeAreaAddAnalogClock_G6(）
        * 参数名：
        *	areaID：区域ID
        *   header: 详情见EQAnalogClockHeader_G56结构体
        *   cStyle: 表盘样式，详情见E_ClockStyle
        *   cColor: 表盘颜色，详情见E_Color_G56通过此枚举值可以直接配置七彩色，如果大于枚举范围使用RGB888模式 
        * 返回值：0 成功， 其他值为错误号
        * 功 能：时间分区添加模拟时钟
        * 注：
        *
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaAddAnalogClock_G6(ushort areaID, IntPtr header, E_ClockStyle cStyle,ref ClockColor_G56 cColor);

        /*! ***************************************************************
        * 函数名：       program_IntegrateProgramFile_G6（）
        * 参数名：
        *	program：参考结构体EQprogram_G6
        * 返回值：0 成功， 其他值为错误号
        * 功 能：合成节目文件返回节目文件属性及地址
        * 注：
        * EQprogram 结构体是用来回调发送文件所需要参数
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        //public static extern int bxDual_program_IntegrateProgramFile_G6(byte[] program);
        public static extern int bxDual_program_IntegrateProgramFile_G6(ref EQprogram_G6 program);

        /*! ***************************************************************
        * 函数名：       program_deleteProgram_G6(）
        * 参数名：
        *
        * 返回值：0 成功， 其他值为错误号
        * 功 能：删除节目
        * 注：
        *
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_deleteProgram_G6();

        /*! ***************************************************************
        * 函数名：       program_timeAreaSetBattleTime_G6（）
        *	areaID：区域的ID号
        *   header：参考结构体EQTimeAreaBattle_G6
        *
        *
        * 返回值：0 成功， 其他值为错误
        * 功 能：时间分区设置战斗时间和战斗时间的启动模式
        * 注：
        * 
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaSetBattleTime_G6(ushort areaID, IntPtr header);

        /*! ***************************************************************
        * 函数名：       program_timeAreaCancleBattleTime_G6（）
        *	areaID：区域的ID号
        * 
        *
        *
        * 返回值：0 成功， 其他值为错误
        * 功 能：时间分区取消战斗时间
        * 注：取消后的时间分区将作为普通时间
        * 
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaCancleBattleTime_G6(ushort areaID);











        /*! ***************************************************************
        * 函数名：       program_pictureAreaGetOnePage(）
        * 参数名：
        *	areaID：区域ID
        *   pageNum: 第几页，从0开始计算
        * 返回值：0 成功， 其他值为错误号
        * 功 能：返回区域第n张图片
        * 注：
        *
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_pictureAreaGetOnePage(ushort areaID, uint pageNum, IntPtr pageData);



        /*****************************以下为六代接口*******************************************/


        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        功能：6代更新动态区最基本功能：仅显示动态区：即不与节目一起显示，如果当前有节目显示，调用此函数后，LED屏幕上会清空原来的内容，显示此函数中 strAreaTxtContent 参数的内容；
	         如果要与屏幕上原来显示的节目一起显示，请调用下面的 动态区文本关联节目 函数；
        参数：
        pIP,nPort	  :控制卡IP; 端口号;
        color		  :LED屏颜色类型，详见 E_ScreenColor_G56 声明； 
        uAreaId		  :区域号; 如果控制卡只支持4个动态区，则uAreaId的取值范围：0-3；共4个；且只能是0-3之间的值；
        uAreaX,uAreaY :显示区域坐标，即动态区域左上角在LED显示屏的位置/坐标；如：（0，0）则是从LED显示屏幕的最左上角开始显示动态区；
                       注意:不同控制卡的最小LED屏宽不同，如BX-6E2X最小屏宽为80个显示单位，所以连接的LED屏如果只有64宽度，则在坐标为（0，0）且是靠左显示的情况下，最左边的16个单元会显示不完整；
        uWidth,uHeight:动态区域的宽度，高度
        fontName	  :字体名称，如"宋体";  nFontSize:字体大小，如12;
        strAreaTxtContent:要显示的文本内容
        -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaTxt_6G(byte[] ip, int port, E_ScreenColor_G56 color, byte uAreaId, ushort uAreaX, ushort uAreaY,
                                                     ushort uWidth, ushort uHeight, byte[] fontName, byte nFontSize, byte[] strAreaTxtContent);

        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaTxtDetails_6G(byte[] ip, int nPort, E_ScreenColor_G56 color, byte uAreaId,
            ref EQareaHeader_G6 oAreaHeader_G6,ref EQpageHeader_G6 stPageHeader, byte[] fontName, byte[] strAreaTxtContent);
        //动态区文本关联节目: 
        //RelateProNum = 0 时，关联所有节目，与所有节目一起播放，如果没有节目，则不播放该动态区；
        //			   > 0 时, 指定关联节目，要关联的节目ID存放在RelateProSerial[]中；
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G(byte[] ip, int nPort, E_ScreenColor_G56 color, byte uAreaId, IntPtr oAreaHeader_G6,
                                    IntPtr stPageHeader, byte[] fontName, byte[] strAreaTxtContent, ushort RelateProNum, ushort[] RelateProSerial);


        //更新动态区图片：仅显示动态区;
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaPic_6G(byte[] ip, int nPort, E_ScreenColor_G56 color, byte uAreaId, ushort AreaX, ushort AreaY,
                                                     ushort AreaWidth, ushort AreaHeight, IntPtr pheader, byte[] picPath);


        //动态区图片关联节目: 
        //RelateProNum = 0 时，关联所有节目，与所有节目一起播放，如果没有节目，则不播放该动态区；
        //			   > 0 时, 指定关联节目，要关联的节目ID存放在RelateProSerial[]中；
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaPic_WithProgram_6G(byte[] ip, int nPort, E_ScreenColor_G56 color, byte uAreaId, ushort[] AreaX, ushort[] AreaY,
                                                     ushort[] AreaWidth, ushort[] AreaHeight, IntPtr pheader, byte[] picPath, ushort RelateProNum, ushort[] RelateProSerial);
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicAreaS_AddAreaPic_6G(byte[] ip, int nPort, E_ScreenColor_G56 color, byte uAreaCount, [In] DynamicAreaParams[] pParams);
        //删除动态区：
        //uAreaId = 0xff:删除所有区域
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_DelArea_6G(byte[] ip, int nPort, byte uAreaId);
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_DelAreas_6G(byte[] ip, int nPort, byte uAreaCount, byte[] pAreaID);


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct DynamicAreaParams
        {
            public byte uAreaId;
            public EQareaHeader_G6 oAreaHeader_G6;
            public EQpageHeader_G6 stPageHeader;
            public IntPtr fontName;
            public IntPtr strAreaTxtContent;
        }



        //同时更新多个动态区:仅显示动态区，不显示节目
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicAreaS_AddTxtDetails_6G(byte[] ip, int nPort, E_ScreenColor_G56 color, byte uAreaCount, [In] DynamicAreaParams[] pParams);


        //同时更新多个动态区:并与节目关联，即与节目一起显示
        //RelateProNum = 0 时，关联所有节目，与所有节目一起播放，如果没有节目，则不播放该动态区；
        //			   > 0 时, 指定关联节目，要关联的节目ID存放在RelateProSerial[]中；
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G(byte[] ip, int nPort, E_ScreenColor_G56 color, byte uAreaCount, [In] DynamicAreaParams[] pParams, ushort RelateProNum, ushort[] RelateProSerial);



        /*! ***************************************************************
        * 函数名：       cmd_ofsReedDirBlock（）
        * 参数名：ip：控制器IP， port：控制器端口
        *	dirBlock: 读会的文件列表，具体的具体参考GetDirBlock_G56结构体
        * 返回值：0 成功， 其他值为错误号
        * 功 能：获取文件列表
        * 注：
        * 下面几条命令用法比较复杂请配合协议使用不做嗷述
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_ofsReedDirBlock(byte[] ip, int nPort, byte[] dirBlock);

        /*! ***************************************************************
        * 函数名：  cmd_getFileAttr（）
        * 参数名：
        *	dirBlock: 上一条命令的回传结构体
        *	number: 要获取的第几个文件的属性
        *	fileAttr： 获取到的文件属性存放位置参考结构体FileAttribute_G56；
        * 返回值：0 成功， 其他值为错误号
        * 功 能：获取指定文件的属性
        * 注：
        * number：此参数值小于fileAttr.fileName 从0开始
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_getFileAttr(IntPtr dirBlock, ushort number, byte[] fileAttr);
        /*! ***************************************************************
        * 函数名：       cmd_ofsDeleteFormatFile（）
        * 参数名：ip：控制器IP， port：控制器端口
        *	fileNub:要删除的文件个数
        *	fileName：要删除的文件名
        * 返回值：0 成功， 其他值为错误号
        * 功 能：删除文件
        * 注：
        * fileName是4个字节 fileNub值为N就要把N个fileName拼接 fileName大小 = fileName（4byte）*N
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_ofsDeleteFormatFile(byte[] ip, int port, short fileNub, byte[] fileName);

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct EQfontData
        {
            public E_arrMode arrMode; //排列方式--单行多行  E_arrMode::	eSINGLELINE,   //单行 eMULTILINE,    //多行
            public ushort fontSize; //字体大小
            public uint color;//字体颜色 E_Color_G56 此通过此枚举值可以直接配置七彩色，如果大于枚举范围使用RGB888模式
            public byte fontBold; //是否为粗体
            public byte fontItalic;//是否为斜体
            public E_txtDirection tdirection;//文字方向
            public ushort txtSpace;  //文字间隔   
            public byte Halign; //横向对齐方式（0系统自适应、1左对齐、2居中、3右对齐）
            public byte Valign; //纵向对齐方式（0系统自适应、1上对齐、2居中、3下对齐）
        }
//5代控制卡动态区功能开始:====================================================================================================================================================================================================================
/*
功能说明：增加一条文件信息到指定的动态区，并可以关联这个动态区到指定的节目；其它参考信息参见 上面的 6代控制卡动态区功能 函数 dynamicArea_AddAreaTxt_6G 上面的说明；
参数说明：
strAreaTxtContent - 动态区域内要显示的文本内容
*/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaWithTxt_5G(byte[] ip, int nPort, E_ScreenColor_G56 color,
	byte uAreaId,
	byte RunMode,
	ushort Timeout,
	byte RelateAllPro,
    ushort RelateProNum,
    ushort[] RelateProSerial,
	byte ImmePlay,
    ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, 
	EQareaframeHeader oFrame,	
	//PageStyle begin--------
	byte DisplayMode,
	byte ClearMode,
	byte Speed,
    ushort StayTime,
	byte RepeatTime,
	//PageStyle End.
	//显示内容和字体格式 begin---------
	EQfontData oFont,
    byte[] fontName,
    byte[] strAreaTxtContent
	//end.
);

/*
功能说明：增加一个图片到指定的动态区，并可以关联这个动态区到指定的节目；
*/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaWithPic_5G(byte[] ip, int nPort, E_ScreenColor_G56 color,byte uAreaId,byte RunMode,ushort Timeout,byte RelateAllPro, ushort RelateProNum,
            ushort[] RelateProSerial,byte ImmePlay,ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight,EQareaframeHeader oFrame,byte DisplayMode,byte ClearMode,
            byte Speed, ushort StayTime,byte RepeatTime,byte[] filePath);


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct DynamicAreaBaseInfo_5G
        {
            byte nType; // nType=1:文本； nType=2:图片；

            //PageStyle begin---------------
            byte DisplayMode;
            byte ClearMode;
            byte Speed;
            ushort StayTime;
            byte RepeatTime;
            //PageStyle End.

            //文本显示内容和字体格式 begin---------
            EQfontData oFont;
            byte[] fontName;
            byte[] strAreaTxtContent;
            //end.

            //图片路径 begin---------
            byte[] filePath;
            //end.

        }
/*
功能说明：增加多条信息（文本/图片）到指定的动态区，并可以关联这个动态区到指定的节目；
*/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaInfos_5G(byte[] ip, int nPort, E_ScreenColor_G56 color,byte uAreaId,byte RunMode, ushort Timeout,
            byte RelateAllPro,ushort RelateProNum,ushort[] RelateProSerial, byte ImmePlay,ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight,
            EQareaframeHeader oFrame,byte nInfoCount,[In] DynamicAreaBaseInfo_5G[] pInfo);


//删除动态区：
/*
功能：删除单个动态区：
参数：uAreaId = 0xff:删除所有区域
*/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_DelArea_5G(byte[] ip, int nPort, byte uAreaId);

/*
功能：删除多个动态区：
*/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_DelAreaS_5G(byte[] ip, int nPort, byte uAreaCount, byte[] pAreaID);


//5代控制卡动态区功能结束:====================================================================================================================================================================================================================
        
/*! ***************************************************************
* 函数名：       program_addFrame（）
*	EQscreenframeHeader：参考结构体EQscreenframeHeader
*	picPath：添加的边框图片路径
* 返回值：0 成功， 其他值为错误号
* 功 能：节目添加边框
* 注：
* 
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_addFrame(ref EQscreenframeHeader sfHeader, byte[] picPath);
/*! ***************************************************************
* 函数名：       program_picturesAreaAddFrame(）
* 参数名：areaID：区域的ID号
*	EQareaframeHeader：参考结构体EQareaframeHeader
*   picPath: 边框图片文件的路径
* 返回值：0 成功， 其他值为错误号
* 功 能：区域添加边框
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_picturesAreaAddFrame(ushort areaID,ref  EQareaframeHeader afHeader, byte[] picPath);

        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_picturesAreaAddFrame_G6(ushort areaID, ref EQscreenframeHeader_G6 afHeader, byte[] picPath);
/*! ***************************************************************
* 函数名：       program_addFrame_G6（）
*	sfHeader：参考结构体EQscreenframeHeader_G6
*	picPath：添加的边框图片路径
* 返回值：0 成功， -1 不成功
* 功 能：节目添加边框
* 注：节目添加边框后，区域的坐标随即发生变化，添加区域的时候需注意
* 
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_addFrame_G6(ref EQscreenframeHeader_G6 sfHeader, byte[] picPath);
        /*! ***************************************************************
* 函数名：       cmd_setBrightness（）
* 参数名：ip：控制器IP， port：控制器端口， brightness：亮度度表
* 返回值：0 成功， 其他值为错误号
* 功 能：设置亮度和相关模式
* 注：
* 参考协议对应每一个表格，注意第一个字节模式的配置
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_setBrightness(byte[] ip, ushort port, ref Brightness brightness);
/*! ***************************************************************
* 函数名：       program_pictureAreaEnableSound_G6（）
*	areaID：区域的ID号
*	sheader：参考结构体EQPicAreaSoundHeader_G6
*   soundData:语音数据
*
* 返回值：0 成功， 其他值为错误
* 功 能：图文分区使能语音播放
* 注：
* 
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_pictureAreaEnableSound_G6(ushort areaID, EQPicAreaSoundHeader_G6 sheader, byte[] soundData);
/*! ***************************************************************
* 函数名：       cmd_check_time（）
* 参数名：ip：控制器IP， port：控制器端口
* 返回值：0 成功， 其他值为错误号
* 功 能：校时，让控制器和当前上位机所在系统时间一致
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_check_time(byte[] ip, ushort port);
/*! ***************************************************************
* 函数名：       program_addPlayPeriodGrp（）
* 返回值：0 成功， 其他值为错误
* 功 能：添加节目播放时段
* 注：
* 
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_addPlayPeriodGrp(ref EQprogramppGrp_G56 header);
        /*! ***************************************************************
        * 函数名：       program_addPlayPeriodGrp（）
        * 返回值：0 成功， 其他值为错误
        * 功 能：添加节目播放时段
        * 注：
        * 
        ******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_addPlayPeriodGrp_G6(ref EQprogramppGrp_G56 header);


        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct NetSearchCmdRet
        {
            //Oint8 CmdGroup;		//1 0xA4 命令组 //public byte Cmd;		//1 0x83 命令编号 //public ushort Status;	//2 控制器状态//public ushort Error;	//2 错误状态寄存器//public ushort DataLen;	//		2 0xA4 数据长度
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Mac;			//6 Mac 地址
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] IP;			//4 控制器 IP 地址
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] SubNetMask;	//4 子网掩码
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Gate;			//4 网关
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Port;			//2 端口
            public byte IPMode;			//1 1 表示 DHCP 2 表示手动设置
            public byte IPStatus;			//1 0 表示 IP 设置失败 1 表示 IP 设置成功
            public byte ServerMode;		//1 0 Bit[0]表示服务器模式是否使能：1 –使能，0 –禁止 Bit[1]表示服务器模式：1 –web 模式，0 –普通模式
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ServerIPAddress;// 4 服务器 IP 地址
            public ushort ServerPort;		//2 服务器端口号
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] ServerAccessPassword;//	8 服务器访问密码
            public ushort HeartBeatInterval;//2 20S 心跳时间间隔（单位：秒）
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
            public byte[] CustomID;		//12 用户自定义 ID，作为网络 ID 的前半部分，便于用户识别其控制卡
            //Web 模式下参见下面的数据结构：NetSearchCmdRet_Web   返回下述 5 项的实际值，否则不上传下述 5 项
            //public byte WebUserID[128];//		128 0 WEB 平台用户 id//Oint32 GroupNum;//		4 0 屏幕组号//public byte DomainFlag;//		1 0 域名标志 0 - 无域名，1—域名//public byte DomainName[128];//		128 域名名称 当 DomainFlag 为 1 时下发//public byte WebControllerName[128];// 128 LED00001 WEB 平台控制器名称
            //Web 模式下返回结束 ==================================================
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] BarCode;		//16 条形码，作为网络 ID 的后半部分，用以实现网络 ID 的唯一性
            public ushort ControllerType;	//2 其中低位字节表示设备系列，而高位字节表示设备编号，例如 BX - 6Q2 应表示为[0x66, 0x02]，其它型号依此类推。
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] FirmwareVersion;// 8 Firmware 版本号
            public byte ScreenParaStatus;	//1 控制器参数文件状态 0x00 –控制器中没有参数配置文件，以下返回的是控制器的默认参数。此时，PC软件应提示用户必须先加载屏参。0x01 –控制器中有参数配置文件
            public ushort Address;			//2 0x0001 控制器地址控制器出厂默认地址为 0x0001(0x0000 地址将保留)控制除了对发送给自身地址的数据包进行处理外，还需对广播数据包进行处理。
            public byte Baudrate;			//1 0x00 波特率 0x00 –保持原有波特率不变 0x01 –强制设置为 9600 0x02 –强制设置为 57600
            public ushort ScreenWidth;		//2 192 显示屏宽度
            public ushort ScreenHeight;	//2 96 显示屏高度
            public byte Color;			//1 0x01 对于无灰度系统，单色时返回 1，双色时返回 3，三色时返回 7；对于有灰度系统，返回 255
            public byte BrightnessAdjMode;// 1 调亮模式 0x00 –手动调亮 0x01 –定时调亮 0x02 –自动调亮
            public byte CurrentBrigtness;	// 1 当前亮度值
            public byte TimingOnOff;		//1 Bit0 –定时开关机状态，0 表示无定时开关机，1 表示有定时开关机
            public byte CurrentOnOffStatus;//1 开关机状态
            public ushort ScanConfNumber;	//2 扫描配置编号
            public byte RowsPerChanel;	//1 一路数据带几行
            public byte GrayFlag;			//1 对于无灰度系统，返回 0；对于有灰度系
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnitWidth;		//2 最小单元宽度
            public byte modeofdisp;		//1 6Q 显示模式 : 0 为 888, 1 为 565，其余卡为 0
            public byte NetTranMode;		//1 当该字节为 0 时，网口通讯使用老的模式，即 UDP 和 TCP 均根据下面的PackageMode 字节确定包长，并且 UDP通讯时，将大包分为小包，每发送一小包做一下延时当该字节不为 0 时，网口通讯使用新的模式，即 UDP 的包长等于UDPPackageMode * 8KBYTE，且不再分为小包，将整包数据丢给协议栈TCP 的包长等于 PackageMode * 16KBYTE
            public byte PackageMode;		//1 包模式。0 小包模式，分包 600 byte。1 大包模式，分包 16K byte。
            public byte BarcodeFlag;		//1 是否设置了条码 ID如果设置了，该字节第 0 位为 1，否则为0
            public ushort ProgramNumber;	//2 控制器上已有节目个数
            public uint CurrentProgram;	//4 当前节目名
            public byte ScreenLockStatus;	//1 Bit0 –是否屏幕锁定，1b’0 –无屏幕锁定，1b’1 –屏幕锁定
            public byte ProgramLockStatus;//1 Bit0 –是否节目锁定，1b’0 –无节目锁定，1’b1 –节目锁定
            public byte RunningMode;		//1 控制器运行模式
            public byte RTCStatus;		//1 RTC 状态 0x00 – RTC 异常 0x01 – RTC 正常
            public ushort RTCYear;			//2 年
            public byte RTCMonth;			//1 月
            public byte RTCDate;			//1 日
            public byte RTCHour;			//1 小时
            public byte RTCMinute;		//1 分钟
            public byte RTCSecond;		//1 秒
            public byte RTCWeek;			//1 星期，范围为 1~7，7 表示周日
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Temperature1;	//3 温度传感器当前值
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Temperature2;	//3 温度传感器当前值
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Humidity;		//2 湿度传感器当前值
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Noise;			//2 噪声传感器当前值(除以 10 为当前值)针对 BX - ZS(485) 0xffff 时无效
            public byte Reserved;			//1 保留字节
            public byte LogoFlag;			//1 0：表示未设置 Logo 节目 1：表示设置了 Logo 节目
            public ushort PowerOnDelay;	//2 0：未设置开机延时 1：开机延时时长
            public ushort WindSpeed;		//2 风速(除以 10 为当前值) 0xfffff 时无效
            public ushort WindDirction;	//2 风向(当前值) 0xfffff 时无效
            public ushort PM2_5;			//2 PM2.5 值(当前值)0xfffff 时无效
            public ushort PM10;			//2 PM10 值(当前值)0xfffff 时无效
            public ushort ExtendParaLen;	// 2 0x40 扩展参数长度
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] ControllerName;	// 16 LEDCON01 控制器名称限制为 16 个字节长度(全是 0x00 表示屏参丢失，参数无效，上位机空白显示)
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 44)]
            public byte[] ScreenLocation;	// 44 0 屏幕安装地址限制为 44 个字节长度(全是 0x00 表示屏参丢失，参数无效，上位机空白显示)
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] NameLocalationCRC32;// 4 控制器和屏幕安装地址共 60 个字节的CRC32 校验值，该值是为了便于上位机区分此处 64 个字节是表示控制器名称还是用来表示控制器名称和屏幕安装地址，进而采取不同的处理策略为了保持兼容，下位机不对该值进行验证
        }
/*! ********************************************************************************************************************
* 函数名：cmd_tcpNetworkSearch_6G（）
* 参数名：ip：控制器IP， port：控制器端口; 
*		 命令结果放在了 retData 中；NetSearchCmdRet:参考结构体声明中的注释；
* 返回值：0 成功， 其他值为错误号
* 功 能： 网络搜索命令，返回：温度传感器，空气，PM2.5等信息，详见 NetSearchCmdRet:参考结构体声明中的注释；
* 注：   针对 6代卡 的网络搜索命令
***********************************************************************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_tcpNetworkSearch_6G(byte[] ip, ushort port, ref NetSearchCmdRet retData);

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct NetSearchCmdRet_Web
        {
            //Oint8 CmdGroup;		//1 0xA4 命令组 //Oint8 Cmd;		//1 0x83 命令编号 //Oint16 Status;	//2 控制器状态//Oint16 Error;	//2 错误状态寄存器//Oint16 DataLen;	//		2 0xA4 数据长度
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Mac;			//6 Mac 地址
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] IP;			//4 控制器 IP 地址
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] SubNetMask;	//4 子网掩码
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Gate;			//4 网关
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Port;			//2 端口
            public byte IPMode;			//1 1 表示 DHCP 2 表示手动设置
            public byte IPStatus;			//1 0 表示 IP 设置失败 1 表示 IP 设置成功
            public byte ServerMode;		//1 0 Bit[0]表示服务器模式是否使能：1 –使能，0 –禁止 Bit[1]表示服务器模式：1 –web 模式，0 –普通模式
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ServerIPAddress;// 4 服务器 IP 地址
            public ushort ServerPort;		//2 服务器端口号
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] ServerAccessPassword;//	8 服务器访问密码
            public ushort HeartBeatInterval;//2 20S 心跳时间间隔（单位：秒）
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
            public byte[] CustomID;		//12 用户自定义 ID，作为网络 ID 的前半部分，便于用户识别其控制卡
            //Web 模式下返回下述 5 项的实际值，否则不上传下述 5 项
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
            public byte[] WebUserID;	//		128 0 WEB 平台用户 id
            public uint GroupNum;		//		4 0 屏幕组号
            public byte DomainFlag;		//		1 0 域名标志 0 - 无域名，1—域名
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
            public byte[] DomainName;	//		128 域名名称 当 DomainFlag 为 1 时下发
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
            public byte[] WebControllerName;// 128 LED00001 WEB 平台控制器名称
            //Web 模式下返回下述 5 项 结束 ###################
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] BarCode;		//16 条形码，作为网络 ID 的后半部分，用以实现网络 ID 的唯一性
            public ushort ControllerType;	//2 其中低位字节表示设备系列，而高位字节表示设备编号，例如 BX - 6Q2 应表示为[0x66, 0x02]，其它型号依此类推。
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] FirmwareVersion;// 8 Firmware 版本号
            public byte ScreenParaStatus;	//1 控制器参数文件状态 0x00 –控制器中没有参数配置文件，以下返回的是控制器的默认参数。此时，PC软件应提示用户必须先加载屏参。0x01 –控制器中有参数配置文件
            public ushort Address;			//2 0x0001 控制器地址控制器出厂默认地址为 0x0001(0x0000 地址将保留)控制除了对发送给自身地址的数据包进行处理外，还需对广播数据包进行处理。
            public byte Baudrate;			//1 0x00 波特率 0x00 –保持原有波特率不变 0x01 –强制设置为 9600 0x02 –强制设置为 57600
            public ushort ScreenWidth;		//2 192 显示屏宽度
            public ushort ScreenHeight;	//2 96 显示屏高度
            public byte Color;			//1 0x01 对于无灰度系统，单色时返回 1，双色时返回 3，三色时返回 7；对于有灰度系统，返回 255
            public byte BrightnessAdjMode;//1 调亮模式 0x00 –手动调亮 0x01 –定时调亮 0x02 –自动调亮
            public byte CurrentBrigtness;	//1 当前亮度值
            public byte TimingOnOff;		//1 Bit0 –定时开关机状态，0 表示无定时开关机，1 表示有定时开关机
            public byte CurrentOnOffStatus;//1 开关机状态
            public ushort ScanConfNumber;	//2 扫描配置编号
            public byte RowsPerChanel;	//1 一路数据带几行
            public byte GrayFlag;			//1 对于无灰度系统，返回 0；对于有灰度系
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnitWidth;		//2 最小单元宽度
            public byte modeofdisp;		//1 6Q 显示模式 : 0 为 888, 1 为 565，其余卡为 0
            public byte NetTranMode;		//1 当该字节为 0 时，网口通讯使用老的模式，即 UDP 和 TCP 均根据下面的PackageMode 字节确定包长，并且 UDP通讯时，将大包分为小包，每发送一小包做一下延时当该字节不为 0 时，网口通讯使用新的模式，即 UDP 的包长等于UDPPackageMode * 8KBYTE，且不再分为小包，将整包数据丢给协议栈TCP 的包长等于 PackageMode * 16KBYTE
            public byte PackageMode;		//1 包模式。0 小包模式，分包 600 byte。1 大包模式，分包 16K byte。
            public byte BarcodeFlag;		//1 是否设置了条码 ID如果设置了，该字节第 0 位为 1，否则为0
            public ushort ProgramNumber;	//2 控制器上已有节目个数
            public uint CurrentProgram;	//4 当前节目名
            public byte ScreenLockStatus;	//1 Bit0 –是否屏幕锁定，1b’0 –无屏幕锁定，1b’1 –屏幕锁定
            public byte ProgramLockStatus;//1 Bit0 –是否节目锁定，1b’0 –无节目锁定，1’b1 –节目锁定
            public byte RunningMode;		//1 控制器运行模式
            public byte RTCStatus;		//1 RTC 状态 0x00 – RTC 异常 0x01 – RTC 正常
            public ushort RTCYear;			//2 年
            public byte RTCMonth;			//1 月
            public byte RTCDate;			//1 日
            public byte RTCHour;			//1 小时
            public byte RTCMinute;		//1 分钟
            public byte RTCSecond;		//1 秒
            public byte RTCWeek;			//1 星期，范围为 1~7，7 表示周日
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Temperature1;	//3 温度传感器当前值
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Temperature2;	//3 温度传感器当前值
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Humidity;		//2 湿度传感器当前值
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Noise;			//2 噪声传感器当前值(除以 10 为当前值)针对 BX - ZS(485) 0xffff 时无效
            public byte Reserved;			//1 保留字节
            public byte LogoFlag;			//1 0：表示未设置 Logo 节目 1：表示设置了 Logo 节目
            public ushort PowerOnDelay;	//2 0：未设置开机延时 1：开机延时时长
            public ushort WindSpeed;		//2 风速(除以 10 为当前值) 0xfffff 时无效
            public ushort WindDirction;	//2 风向(当前值) 0xfffff 时无效
            public ushort PM2_5;			//2 PM2.5 值(当前值)0xfffff 时无效
            public ushort PM10;			//2 PM10 值(当前值)0xfffff 时无效
            public ushort ExtendParaLen;	// 2 0x40 扩展参数长度
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] ControllerName;	// 16 LEDCON01 控制器名称限制为 16 个字节长度(全是 0x00 表示屏参丢失，参数无效，上位机空白显示)
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 44)]
            public byte[] ScreenLocation;	// 44 0 屏幕安装地址限制为 44 个字节长度(全是 0x00 表示屏参丢失，参数无效，上位机空白显示)
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] NameLocalationCRC32;// 4 控制器和屏幕安装地址共 60 个字节的CRC32 校验值，该值是为了便于上位机区分此处 64 个字节是表示控制器名称还是用来表示控制器名称和屏幕安装地址，进而采取不同的处理策略为了保持兼容，下位机不对该值进行验证
        }
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_tcpNetworkSearch_6G_Web(byte[] ip, ushort port, ref NetSearchCmdRet_Web retData);
        /*! ***********************************************************************************************************************
* 函数名：cmd_uart_search_Net_6G()
* 参数名：
*        uartPort 端口号,如："COM3"
*		 nBaudRateType 1：9600;   2：57600;
*		 命令结果放在了 retData 中；NetSearchCmdRet:参考结构体声明中的注释；
* 返回值：0 成功， 其他值为错误号
* 功  能： 网络搜索命令，返回：温度传感器，空气，PM2.5等信息，详见 NetSearchCmdRet:参考结构体声明中的注释；
* 注：   针对 6代卡 的网络搜索命令
***************************************************************************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_search_Net_6G(ref NetSearchCmdRet retData, byte[] uartPort, byte nBaudRateType);
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_search_Net_6G_Web(ref NetSearchCmdRet retData, byte[] uartPort, byte nBaudRateType);

/*****************************************************************************************************************************************************************************************************/
        
/*
* 功  能：设置目标地址，即设置屏号/设置屏地址/设置控制器的屏号;
* 参  数：usDstAddr,2个字节长度，默认值0xfffe 为地址通配符;
* 返回值：0 成功;
*/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_set_screenNum_G56(ushort usDstAddr);




/*! ***************************************************************
* 函数名：set_packetLen（）
* 参数名：packetLen 数据包长度
* 返回值：0 成功， 其他值为错误
* 功 能：用于设置控制各种通讯方式每一包最大长度
* 注：5E，6E，6Q系列最大数据长途64K（建议最大不要超过63*1024）
*     其他系列最大长度1K（1204）
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_set_packetLen(ushort packetLen);



/*! ***************************************************************
* 函数名：       cmd_searchController（）
* 参数名：retData 请参考结构体Ping_data 所有回读参数都会通过结构体回调
* 返回值：0 成功， 其他值为错误号
* 功 能：搜索控制器命令
* 注：
* 通过各种通讯方式（AT、UDP、TCP）搜索控制器
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_searchController(ref Ping_data retData);


/*! ***************************************************************
**  串口通讯命令 **
/*! ***************************************************************/
/*! ***************************************************************
* 函数名：       bxDual_cmd_uart_searchController（）
* 参数名：retData 请参考结构体Ping_data 所有回读参数都会通过结构体回调
* 返回值：0 成功， 其他值为错误号
* 功 能：搜索控制器命令
* 注：
* 通过串口通讯方式（9600、57600）搜索控制器
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_searchController(ref Ping_data retData, byte[] uartPort);


/*! ***************************************************************
* 函数名：       bxDual_cmd_uart_ofsFormat（）
* 参数名：uartPort：串口端口号， baudRate：波特率
* 返回值：0 成功， 其他值为错误号
* 功 能：文件系统格式化
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_ofsFormat(byte[] uartPort, byte baudRate);


/*! ***************************************************************
* 函数名：       bxDual_cmd_uart_ofsDeleteFormatFile（）
* 参数名：uartPort：串口端口号， baudRate：波特率
*	fileNub:要删除的文件个数
*	fileName：要删除的文件名
* 返回值：0 成功， 其他值为错误号
* 功 能：删除文件
* 注：
* fileName是4个字节 fileNub值为N就要把N个fileName拼接 fileName大小 = fileName（4byte）*N
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_ofsDeleteFormatFile(Oint8* uartPort, Ouint8 baudRate, short fileNub, Ouint8 *fileName);


/*! ***************************************************************
* 函数名：       bxDual_cmd_uart_confDeleteFormatFile（）
* 参数名：uartPort：串口端口号， baudRate：波特率
*	fileNub:要删除的文件个数
*	fileName：要删除的文件名
* 返回值：0 成功， 其他值为错误号
* 功 能：删除文件
* 注：此函数用于对存储在固定位置的文件进行处理， 例
如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
* fileName是4个字节 fileNub值为N就要把N个fileName拼接 fileName大小 = fileName（4byte）*N
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_confDeleteFormatFile(Oint8* uartPort, Ouint8 baudRate, short fileNub, Ouint8 *fileName);


/*! ***************************************************************
* 函数名：       bxDual_cmd_uart_ofsGetMemoryVolume（）
* 参数名：uartPort：串口端口号， baudRate：波特率
*	totalMemVolume：全部空间大小
*	availableMemVolume：剩余空间大小
* 返回值：0 成功， 其他值为错误号
* 功 能：获取控制空间大小和剩余空间
* 注：
* 发节目前需要查询防止空间不够用
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_ofsGetMemoryVolume(Oint8* uartPort, Ouint8 baudRate, Ouint32 *totalMemVolume, Ouint32 *availableMemVolume);

/*! ***************************************************************
* 函数名：       bxDual_cmd_ofsStartReedFile（）
* 参数名：ip：控制器IP， port：控制器端口
*	fileName：需要读取的文件名
*	fileSize：回读文件大小
*	fileCrc：回读的文件CRC
* 返回值：0 成功， 其他值为错误号
* 功 能：开始读文件
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_ofsStartReedFile(Oint8* uartPort, Ouint8 baudRate, Ouint8 *fileName, Ouint32* fileSize, Ouint32 *fileCrc);

/*! ***************************************************************
* 函数名：       bxDual_cmd_uart_confStartReedFile（）
* 参数名：uartPort：串口端口号， baudRate：波特率
*	fileName：需要读取的文件名
*	fileSize：回读文件大小
*	fileCrc：回读的文件CRC
* 返回值：0 成功， 其他值为错误号
* 功 能：开始读文件
* 注：此函数用于对存储在固定位置的文件进行处理， 例
如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_confStartReedFile(Oint8* uartPort, Ouint8 baudRate, Ouint8 *fileName, Ouint32* fileSize, Ouint32 *fileCrc);


/*! ***************************************************************
* 函数名：       bxDual_cmd_uart_ofsReedFileBlock（）
* 参数名：uartPort：串口端口号， baudRate：波特率
*	fileName：需要读取的文件名
*	fileAddre：传入读文件写的位置
* 返回值：0 成功， 其他值为错误号
* 功 能：读文件
* 注：用于对存储在 OFS 中的文件的处理， 例如： 节目文件， 字库文件、 播放列表文件等
* fileAddre大小根据cmd_ofsStartReedFile函数回调值确定
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_ofsReedFileBlock(Oint8* uartPort, Ouint8 baudRate, Ouint8 *fileName, Ouint8* fileAddre);

/*! ***************************************************************
* 函数名：       bxDual_cmd_uart_confReedFileBlock(）
* 参数名：uartPort：串口端口号， baudRate：波特率
*	fileName：需要读取的文件名
*	fileAddre：传入读文件写的位置
* 返回值：0 成功， 其他值为错误号
* 功 能：读文件
* 注：此函数用于对存储在固定位置的文件进行处理， 例
如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
* fileAddre大小根据cmd_ofsStartReedFile函数回调值确定
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_confReedFileBlock(Oint8* uartPort, Ouint8 baudRate, Ouint8 *fileName, Ouint8* fileAddre);

/*! ***************************************************************
* 函数名：       bxDual_cmd_uart_ofsReedDirBlock（）
* 参数名：uartPort：串口端口号， baudRate：波特率
*	fileName：需要读取的文件名
*	fileAddre：传入读文件写的位置
* 返回值：0 成功， 其他值为错误号
* 功 能：下面两条命令搭配使用可以获取所有文件名
* 注：
* 下面两条命令用法比较复杂请配合协议使用不做嗷述
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_ofsReedDirBlock(Oint8* uartPort, Ouint8 baudRate, GetDirBlock_G56 *dirBlock);

/*! ***************************************************************
* 函数名：  bxDual_cmd_ofs_freeDirBlock（）
* 参数名：
*	dirBlock: 上述两条命令所有使用的结构体
* 返回值：0 成功， 其他值为错误号
* 功 能：释放cmd_ofsReedDirBlock所创建的节目列表dirBlock
* 注：
* dirBlock 上述两条命令调用完成后dirBlock不再使用时用此函数释放文件列表
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_ofsFreeDirBlock(GetDirBlock_G56 *dirBlock);

        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_ofsGetTransStatus(Oint8* uartPort, Ouint8 baudRate, Ouint8 *r_w, Ouint8* fileName, Ouint32 *fileCrc, Ouint32 *fileOffset);


/*! ***************************************************************
* 函数名：       bxDual_cmd_uart_sendConfigFile(）
* 参数名：uartPort：串口端口号， baudRate：波特率
configData 请参考结构体ConfigFile
* 返回值：0 成功， 其他值为错误号
* 功 能：发送配置文件到控制器
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_sendConfigFile(Oint8* uartPort, Ouint8 baudRate, ConfigFile *configData);

/*! ***************************************************************
* 函数名：       bxDual_cmd_uart_programLock（）
* 参数名：uartPort：串口端口号， baudRate：波特率
*         nonvolatile： 状态是否掉电保存 0x00 –掉电不保存  0x01 –掉电保存
*         lock：0x00 –解锁  0x01 –锁定
*         name： 节目名称4（byte）个字节
*         lockDuration: 节目锁定时间长度， 单位为 10 毫秒， 例
*         如当该值为 100 时表示锁定节目 1 秒.注意： 当该值为 0xffffffff 时表示节目锁定无时间长度限制
* 返回值：0 成功， 其他值为错误号
* 功 能：节目锁定
* 注：
* 具体使用方法参考协议
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_programLock(Oint8* uartPort, Ouint8 baudRate, Ouint8 nonvolatile, Ouint8 lock, Ouint8 *name, Ouint32 lockDuration);


        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_uart_programLock_6G(Oint8* uartPort, Ouint8 baudRate, Ouint8 nonvolatile, Ouint8 lock, Ouint8 *name, Ouint32 lockDuration);

/*! ***************************************************************
**  串口通讯命令 end **
/*! ***************************************************************/


/*! ***************************************************************
* 函数名：       cmd_AT_setWifiSsidPwd（）
* 参数名：ssid：控制器WIFI ssid，pwd：控制WIFI密码
* 返回值：0 成功， 其他值为错误号
* 功 能：设置wifi卡的 ssid pwd
* 注：
* 通讯方式（UDP
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_AT_setWifiSsidPwd(Ouint8* ssid, Ouint8* pwd);


/*! ***************************************************************
* 函数名：       cmd_AT_getWifiSsidPwd（）
* 参数名：ssid：控制器WIFI ssid，pwd：控制WIFI密码
* 返回值：0 成功， 其他值为错误号
* 功 能：获取WIFI卡ssid pwd
* 注：
* 通讯方式（UDP）
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_AT_getWifiSsidPwd(Ouint8* ssid, Ouint8* pwd);




/*! ***************************************************************
**  UDP通讯命令 **
/*! ***************************************************************/

/*! ***************************************************************
* 函数名：       cmd_udpNetworkSearch（）
* 参数名：retData 请参考结构体heartbeatData 所有回读参数都会通过结构体回调
* 返回值：0 成功， 其他值为错误号
* 功 能：
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_udpNetworkSearch(heartbeatData *retData); //网络搜索


/*! ********************************************************************************************************************
* 函数名：cmd_udpNetworkSearch_6G（）
* 参数名：retData : 存放网络搜索结果; 具体参考结构体:NetSearchCmdRet 声明中的注释；
* 返回值：0 成功， 其他值为错误号;
* 功  能： 网络搜索命令，返回：温度传感器，空气，PM2.5等信息，详见 NetSearchCmdRet:参考结构体声明中的注释；
* 注：    针对 6代卡 的网络搜索命令
***********************************************************************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_udpNetworkSearch_6G(NetSearchCmdRet *retData);
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_udpNetworkSearch_6G_Web(NetSearchCmdRet_Web *retData);



/*! ***************************************************************
* 函数名：       cmd_udpSetMac（）
* 参数名：mac 传入的MAC地址
* 返回值：0 成功， 其他值为错误号
* 功 能：设置 MAC 地址命令
* 注：
* 需要修改MAC地址的时候调用
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_udpSetMac(Ouint8 *mac);

/*! ***************************************************************
* 函数名：       cmd_udpSetIP（）
* 参数名
Ouint8 mode; 控制器连接模式：
0x00 –单机直连（PC 与控制器直接连
接）
0x01 –自动获取IP（DHCP）
0x02 –手动设置IP（Static IP）
0x03 –服务器模式（动态 IP）
Ouint8 ip[] ； // 要设置的IP地址//设置IP
Ouint8 subnetMask[] ; 子网掩码
Ouint8 gateway[]; 默认网关
short port; 端口号
Ouint8 serverMode; 服务器模式
Ouint8 serverIP[]; 服务IP
short serverPort; 服务器端口号
Ouint8 password[]; 服务器访问密码
short heartbeat; 心跳间隔时间单位秒 默认值20
Ouint8 netID[12]; 控制器网络ID
* 返回值：0 成功， 其他值为错误号
* 功 能：设置 IP 地址相关参数命令
* 注：
*  IP 地址 MAC地址都赋字符串 例：Ouint8 ip[] = "192.168.0.199"  具体使用细节请参考协议
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_udpSetIP(Ouint8 mode, Ouint8 *ip, Ouint8 *subnetMask, Ouint8 *gateway, short port, Ouint8 serverMode, Ouint8 *serverIP, short serverPort, Ouint8 *password, short heartbeat, Ouint8 *netID);// 由于传入参数到内部都需要转换没有使用结构体

/*! ***************************************************************
/**UDP CMD END**/
/*! ***************************************************************/





/*! ***************************************************************
/** TCP命令 控制器维护命令 **/
/*! ***************************************************************/


/*! ***************************************************************
* 函数名：       cmd_battieTime（）
* 参数名：ip：控制器IP， port：控制器端口，
*	mode：战斗时间控制命令
*		0x00:启动战斗时间
*		0x01:暂停战斗时间
*		0x02:复位战斗时间
*	battieData： 命令回读参数请参考结构体BattleTime
* 返回值：0 成功， 其他值为错误号
* 功 能：战斗时间管理命令
* 注：
* 具体细节参考协议
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_battieTime(Ouint8* ip, Ouint16 port, Ouint8 mode, BattleTime *battieData);

/*! ***************************************************************
* 函数名：       cmd_getStopwatch（）
* 参数名：ip：控制器IP， port：控制器端口，
*	mode：秒表控制命令
*		0x00:启动秒表
*		0x01:暂停秒表
*		0x02:复位秒表
*	timeValue：回读回来的当前秒表时间单位毫秒
* 返回值：0 成功， 其他值为错误号
* 功 能：秒表控制并获取秒表时间
* 注：
* 具体细节参考协议
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_getStopwatch(Ouint8* ip, Ouint16 port, Ouint8 mode, Ouint32 *timeValue);

/*! ***************************************************************
* 函数名：       cmd_getSensorBrightnessValue（）
* 参数名：ip：控制器IP， port：控制器端口
*		brightnessValue：当前亮度传感器值
* 返回值：0 成功， 其他值为错误号
* 功 能：获取亮度读传感器值
* 注：
* 具体细节参考协议
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_getSensorBrightnessValue(Ouint8* ip, Ouint16 port, Ouint32 *brightnessValue);

/*! ***************************************************************
* 函数名：       cmd_setSpeedAdjust（）
* 参数名：ip：控制器IP， port：控制器端口
*		speed：速度微调参数值
该值以 0.1 毫秒为单位， 共 256 级， 上
位机下发时该值为 0-255， 这样刚好使
用一个低位字节， 高位字节为 0， 留作
以后扩展使用。 下位机根据该参数在每
次循环中延时相应的时间， 以改善 LED
屏幕的显示效果。 当该参数为 0 时， 下
位机延时为 0， 该参数为 1 时， 下位机
延时 0.1 毫秒， 以此类推
* 返回值：0 成功， 其他值为错误号
* 功 能：速度微调命令
* 注：
* 具体细节参考协议
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_setSpeedAdjust(Ouint8* ip, Ouint16 port, short speed);

/*! ***************************************************************
* 函数名：       cmd_setScreenAddress（）
* 参数名：ip：控制器IP， port：控制器端口
*		address：屏幕号
* 返回值：0 成功， 其他值为错误号
* 功 能：设置屏幕号
* 注：
* 具体细节参考协议
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_setScreenAddress(Ouint8* ip, Ouint16 port, short address);

/** TCP OFS_CMD**/
/*! ***************************************************************
* 函数名：       cmd_ofsFormat（）
* 参数名：ip：控制器IP， port：控制器端口
* 返回值：0 成功， 其他值为错误号
* 功 能：文件系统格式化
* 注：
* 具体细节参考协议
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_ofsFormat(Ouint8* ip, Ouint16 port);



/*! ***************************************************************
* 函数名：       bxDual_cmd_confDeleteFormatFile（）
* 参数名：ip：控制器IP， port：控制器端口
*	fileNub:要删除的文件个数
*	fileName：要删除的文件名
* 返回值：0 成功， 其他值为错误号
* 功 能：删除文件
* 注：此函数用于对存储在固定位置的文件进行处理， 例
如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
* fileName是4个字节 fileNub值为N就要把N个fileName拼接 fileName大小 = fileName（4byte）*N
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_confDeleteFormatFile(Ouint8* ip, Ouint16 port, short fileNub, Ouint8 *fileName);


/*! ***************************************************************
* 函数名：       bxDual_cmd_ofsGetMemoryVolume（）
* 参数名：ip：控制器IP， port：控制器端口
*	totalMemVolume：全部空间大小
*	availableMemVolume：剩余空间大小
* 返回值：0 成功， 其他值为错误号
* 功 能：获取控制空间大小和剩余空间
* 注：
* 发节目前需要查询防止空间不够用
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_ofsGetMemoryVolume(Ouint8* ip, Ouint16 port, Ouint32 *totalMemVolume, Ouint32 *availableMemVolume);


/*! ***************************************************************
* 函数名：       bxDual_cmd_ofsWriteFile（）
* 参数名：ip：控制器IP， port：控制器端口
*	fileName：文件名
*	fileType：文件类型
*	fileLen：文件长度
*	fileAddre：文件所在的缓存地址
*	overwrite：是否覆盖控制上的文件 1覆盖 0不覆盖 建议发1
* 返回值：0 成功， 其他值为错误号
* 功 能：写文件到控制
* 注：此函数用于对存储在固定位置的文件进行处理， 例
如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
* 内部包含多条命令注意返回状态方便查找问题
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_confWriteFile(Ouint8* ip, Ouint16 port, Ouint8 *fileName, Ouint8 fileType, Ouint32 fileLen, Ouint8 overwrite, Ouint8 *fileAddre);

/*! ***************************************************************
* 函数名：       bxDual_cmd_ofsStartReedFile（）
* 参数名：ip：控制器IP， port：控制器端口
*	fileName：需要读取的文件名
*	fileSize：回读文件大小
*	fileCrc：回读的文件CRC
* 返回值：0 成功， 其他值为错误号
* 功 能：开始读文件
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_ofsStartReedFile(Ouint8* ip, Ouint16 port, Ouint8 *fileName, Ouint32* fileSize, Ouint32 *fileCrc);

/*! ***************************************************************
* 函数名：       bxDual_cmd_confStartReedFile（）
* 参数名：ip：控制器IP， port：控制器端口
*	fileName：需要读取的文件名
*	fileSize：回读文件大小
*	fileCrc：回读的文件CRC
* 返回值：0 成功， 其他值为错误号
* 功 能：开始读文件
* 注：此函数用于对存储在固定位置的文件进行处理， 例
如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_confStartReedFile(Ouint8* ip, Ouint16 port, Ouint8 *fileName, Ouint32* fileSize, Ouint32 *fileCrc);


/*! ***************************************************************
* 函数名：       bxDual_cmd_ofsReedFileBlock（）
* 参数名：ip：控制器IP， port：控制器端口
*	fileName：需要读取的文件名
*	fileAddre：传入读文件写的位置
* 返回值：0 成功， 其他值为错误号
* 功 能：读文件
* 注：用于对存储在 OFS 中的文件的处理， 例如： 节目文件， 字库文件、 播放列表文件等
* fileAddre大小根据bxDual_cmd_ofsStartReedFile函数回调值确定
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_ofsReedFileBlock(Ouint8* ip, Ouint16 port, Ouint8 *fileName, Ouint8* fileAddre);

/*! ***************************************************************
* 函数名：       bxDual_cmd_confReedFileBlock(）
* 参数名：ip：控制器IP， port：控制器端口
*	fileName：需要读取的文件名
*	fileAddre：传入读文件写的位置
* 返回值：0 成功， 其他值为错误号
* 功 能：读文件
* 注：此函数用于对存储在固定位置的文件进行处理， 例
如： Firmware 文件、 控制器参数配置文件、 扫描配置文件等。
* fileAddre大小根据bxDual_cmd_ofsStartReedFile函数回调值确定
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_confReedFileBlock(Ouint8* ip, Ouint16 port, Ouint8 *fileName, Ouint8* fileAddre);


/*! ***************************************************************
* 函数名：  bxDual_cmd_ofs_freeDirBlock（）
* 参数名：
*	dirBlock: 上述两条命令所有使用的结构体
* 返回值：0 成功， 其他值为错误号
* 功 能：释放bxDual_cmd_ofsReedDirBlock所创建的节目列表dirBlock
* 注：
* dirBlock 上述两条命令调用完成后dirBlock不再使用时用此函数释放文件列表
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_ofs_freeDirBlock(GetDirBlock_G56 *dirBlock);

        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_ofsGetTransStatus(Ouint8* ip, Ouint16 port, Ouint8 *r_w, Ouint8* fileName, Ouint32 *fileCrc, Ouint32 *fileOffset);


/*! ***************************************************************
* 函数名：       bxDual_cmd_firmwareActivate（）
* 参数名：ip：控制器IP， port：控制器端口，firmwareFileName要激活的固件名称
* 返回值：0 成功， 其他值为错误号
* 功 能：激活指定固件
* 注：
* firmwareFileName 缺省值为4个字节字符串“F001”
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_firmwareActivate(Ouint8* ip, Ouint16 port, Ouint8* firmwareFileName);



/*! ***************************************************************
* 函数名：       bxDual_cmd_sendConfigFile(）
* 参数名：ip：控制器IP， port：控制器端口
configData 请参考结构体ConfigFile
* 返回值：0 成功， 其他值为错误号
* 功 能：发送5代卡配置文件到控制器
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_sendConfigFile(Ouint8* ip, Ouint16 port, ConfigFile *configData);

/*! ***************************************************************
* 函数名：       bxDual_cmd_sendConfigFile_G6(）
* 参数名：ip：控制器IP， port：控制器端口
configData 请参考结构体ConfigFile
* 返回值：0 成功， 其他值为错误号
* 功 能：发送5代卡配置文件到控制器
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_cmd_sendConfigFile_G6(Ouint8* ip, Ouint16 port, ConfigFile_G6 *configData);




/*! ***************************************************************
/** TCP命令 END **/
/*! ***************************************************************/





/*! ***************************************************************
* 函数名：       get_crc16（）
* 参数名：
* 返回值：0 成功， 其他值为错误号
* 功 能：用来计算CRC16值
* 注：
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_get_crc16(FileCRC16_G56 *crc16);

/*! ***************************************************************
* 函数名：       get_crc32（）
* 参数名：
* 返回值：0 成功， 其他值为错误号
* 功 能：用来计算CRC32值
* 注：
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_get_crc32(FileCRC32_G56 *crc32);

/*! ***************************************************************
***                  以下是节目相关函数
*** 注意事项：
***
***
/*! ***************************************************************/


        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_freeBuffer(EQprogram* program);

/*! ***************************************************************
* 函数名：       bxDual_program_pictureArea（）
* 参数名：ip：控制器IP， port：控制器端口
*	programID：节目的ID号
* 返回值：0 成功， 其他值为错误号
* 功 能：只是用来测试图文区
* 注：
* 屏幕大小为1024X80 输出26个字母
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_pictureArea(Ouint32 programID, Ouint8* ip, Ouint16 port);

/*! ***************************************************************
* 函数名：       bxDual_program_changeProgramParams（）
*	programH：参考结构体EQprogramHeader
* 返回值：0 成功， 其他值为错误
* 功 能：修改已添加节目的一些参数
* 注：
* 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_changeProgramParams(EQprogramHeader *programH);

/*! ***************************************************************
* 函数名：       bxDual_program_deleteArea（）
* 参数名：
*	areaID：区域的ID号
* 返回值：0 成功， 其他值为错误号
* 功 能：用来删除编号为areaID的区域
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_deleteArea(Ouint16 areaID);
					/*! ***************************************************************
					* 函数名：       bxDual_program_picturesAreaChangeTxt（）
					*	areaID：区域的ID号
					*	str：需要画的字符
					*	pheader：参考结构体EQpageHeader
					*
					* 返回值：0 成功， 其他值为错误号
					* 功 能：修改图文区域内容
					* 注：
					* 只可以修改文字内容和EQpageHeader结构体里面的参数，不可以修改字体，如需修改，需要删除区域后重新添加文本设置字体
					******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_picturesAreaChangeTxt(Ouint16 areaID, Ouint8* str, EQpageHeader* pheader);
/*! ***************************************************************
* 函数名：       bxDual_program_fontPath_picturesAreaAddTxt（）
*	areaID：区域的ID号
*	str：需要画的字符
*	fontPathName：字体绝对路径加字库文件名称
*	pheader：参考结构体EQpageHeader
*
* 返回值：0 成功， 其他值为错误号
* 功 能：图文区添加字符串--使用字库
* 注：
* 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_fontPath_picturesAreaAddTxt(Ouint16 areaID, Ouint8* str, Ouint8* fontPathName, EQpageHeader* pheader);
/*! ***************************************************************
* 函数名：       bxDual_program_fontPath_picturesAreaChangeTxt（）
*	areaID：区域的ID号
*	str：需要更换的字符串
*	pheader：参考结构体EQpageHeader
* 返回值：0 成功， 其他值为错误号
* 功 能：图文区修改字符串--使用字库
* 注：
* 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_fontPath_picturesAreaChangeTxt(Ouint16 areaID, Ouint8* str, EQpageHeader* pheader);

/*! ***************************************************************
* 函数名：       bxDual_program_changeFrame（）
*	EQscreenframeHeader：参考结构体EQscreenframeHeader
*	picPath：边框图片路径
* 返回值：0 成功， 其他值为错误号
* 功 能：节目修改已添加边框的一些参数
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_changeFrame(EQscreenframeHeader* sfHeader, Ouint8* picPath);
/*! ***************************************************************
* 函数名：       bxDual_program_removeFrame（）
*
*
* 返回值：0 成功， 其他值为错误号
* 功 能：节目去掉边框
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_removeFrame();
/*! ***************************************************************
* 函数名：       bxDual_program_pictureAreaRemoveFrame（）
*	areaID：区域的ID号
*
* 返回值：0 成功， 其他值为错误号
* 功 能：区域去掉边框
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_pictureAreaRemoveFrame(Ouint16 areaID);

/*! ***************************************************************
* 函数名：       bxDual_program_MoveArea()
*	areaID：区域的ID号
*   x:区域left坐标
*   y:区域top坐标
*   width:区域宽度
*   height:区域高度
*
* 返回值：0 成功， 其他值为错误号
* 功 能：改变区域坐标大小
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_MoveArea(Ouint16 areaID, Oint32 x, Oint32 y, Oint32 width, Oint32 height);

/*! ***************************************************************
* 函数名：       bxDual_program_timeAreaAddContent()
*	areaID：区域的ID号
*   timeData:详情请见时间区数据格式结构体EQtimeAreaData_G56
*
* 返回值：0 成功， 其他值为错误号
* 功 能：时间分区添加内容
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaAddContent(Ouint16 areaID, EQtimeAreaData_G56* timeData);


/*! ***************************************************************
* 函数名：       bxDual_program_timeAreaChangeContent()
*	areaID：区域的ID号
*   timeData:详情请见时间区数据格式结构体EQtimeAreaData_G56
*
* 返回值：0 成功， 其他值为错误号
* 功 能：时间分区修改内容EQtimeAreaData::fontName == 字库的路径加字库文件名（字库地址）
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaChangeContent(Ouint16 areaID, EQtimeAreaData_G56* timeData);

/*! ***************************************************************
* 函数名：       bxDual_program_timeAreaGetOnePage(）
* 参数名：
*	areaID：区域ID
*   pageNum: 第几页，从0开始计算
* 返回值：0 成功， 其他值为错误号
* 功 能：返回时间区域第n张图片
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaGetOnePage(Ouint16 areaID, getPageData* pageData);
/*! ***************************************************************
* 函数名：       bxDual_program_timeAreaChangeAnalogClock(）
* 参数名：
*	areaID：区域ID
*   header: 详情见EQAnalogClockHeader_G56结构体
*   cStyle: 表盘样式，详情见E_ClockStyle
*   cColor: 表盘颜色，详情见E_Color_G56通过此枚举值可以直接配置七彩色，如果大于枚举范围使用RGB888模式
* 返回值：0 成功， 其他值为错误号
* 功 能：时间分区修改模拟时钟的一些设置参数
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaChangeAnalogClock(Ouint16 areaID, EQAnalogClockHeader_G56 *header, E_ClockStyle cStyle, ClockColor_G56* cColor);
/*! ***************************************************************
* 函数名：       bxDual_program_timeAreaChangeDialPic(）
* 参数名：
*	areaID： 区域ID
*   picPath: 表盘图片位置
* 返回值：0 成功， 其他值为错误号
* 功 能：时间分区从外部添加表盘图片
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaChangeDialPic(Ouint16 areaID, Ouint8* picPath);


/*! ***************************************************************
* 函数名：       bxDual_program_timeAreaChangeDialPicAdd_G56(）
* 参数名：
*	areaID： 区域ID
*   picPath: 表盘图片位置
* 返回值：0 成功， 其他值为错误号
* 功 能：时间分区从外部添加表盘图片
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaChangeDialPicAdd_G56(Ouint16 areaID, Ouint8* picAdd, Ouint32 picLen);


/*! ***************************************************************
* 函数名：       bxDual_program_timeAreaRemoveDialPic(）
* 参数名：
*	areaID：区域ID
* 返回值：0 成功， 其他值为错误号
* 功 能：时间分区移除外部添加的表盘图片
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaRemoveDialPic(Ouint16 areaID);




//6代控制卡动态区功能开始:====================================================================================================================================================================================================================

/*
功能：设置动态区
*/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_SetDualPixel(E_DoubleColorPixel_G56 ePixelRGorGR);


//动态区图片关联节目: 
//RelateProNum = 0 时，关联所有节目，与所有节目一起播放，如果没有节目，则不播放该动态区；
//			   > 0 时, 指定关联节目，要关联的节目ID存放在RelateProSerial[]中；
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G(Ouint8* pIP, Ouint32 nPort, E_ScreenColor_G56 color, Ouint8 uAreaCount, DynamicAreaParams* pParams, Ouint16 RelateProNum, Ouint16* RelateProSerial);


/*
功能说明：增加多条信息（文本/图片）到指定的动态区，并可以关联这个动态区到指定的节目；
*/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaInfos_6G(Ouint8* pIP, Ouint32 nPort, E_ScreenColor_G56 color,
	Ouint8 uAreaId,
	Ouint8 RunMode,
	Ouint16 Timeout,
	Ouint8 RelateAllPro,
	Ouint16 RelateProNum,
	Ouint16* RelateProSerial,
	Ouint8 ImmePlay,
	Ouint16 uAreaX, Ouint16 uAreaY, Ouint16 uWidth, Ouint16 uHeight,
	EQareaframeHeader oFrame,

	Ouint8 nInfoCount,
	DynamicAreaBaseInfo_5G** pInfo
);



/*
功能：插入独立语音
参数：
Ouint8 VoiceFlg;		//1 1 语音属性 0：此条语音从头插入队列，且停止当前正在播放的语音 1：此条语音从头插入队列，不停止当前播报的语音 2：此条语音从尾插入队列
Ouint8 StoreFlag;		//1 0 该值为 1 表示需要存储到 FLASH 中，掉电信息不丢失该值为 0 表示需要存储到 RAM 中，掉电信息丢失
*/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_InsertSoundIndepend(Ouint8* pIP, Ouint32 nPort, EQSoundDepend_6G stSoundData, Ouint8 VoiceFlg, Ouint8 StoreFlag);

/*
功能：5.4.3 更新独立语音命令
stSoundData：指向存放EQSoundDepend_6G结构的一段内存首地址指针；
nSoundDataCount:指示stSoundData指向内存地址空间中存放EQSoundDepend_6G个数；
StoreFlag:该值为 1 表示需要存储到 FLASH 中，掉电信息不丢失;该值为 0 表示需要存储到 RAM 中，掉电信息丢失
*/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int  bxDual_dynamicArea_UpdateSoundIndepend(Ouint8* pIP, Ouint32 nPort, EQSoundDepend_6G* stSoundData, Ouint16 nSoundDataCount, Ouint8 StoreFlag);


//6代控制卡动态区功能结束.==============================================================================================================================================================================================================================



//5代控制卡动态区功能开始:====================================================================================================================================================================================================================

        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_dynamicArea_AddAreaWithTxt_Point_5G(Ouint8* pIP, Ouint32 nPort, E_ScreenColor_G56 color,
	Ouint8 uAreaId,
	Ouint8 RunMode,
	Ouint16 Timeout,
	Ouint8 RelateAllPro,
	Ouint16 RelateProNum,
	Ouint16* RelateProSerial,
	Ouint8 ImmePlay,
	Ouint16 uAreaX, Ouint16 uAreaY, Ouint16 uWidth, Ouint16 uHeight,
	EQareaframeHeader* oFrame,
	//PageStyle begin--------
	Ouint8 DisplayMode,
	Ouint8 ClearMode,
	Ouint8 Speed,
	Ouint16 StayTime,
	Ouint8 RepeatTime,
	//PageStyle End.
	//显示内容和字体格式 begin---------
	EQfontData* oFont,
	Ouint8* fontName,
	Ouint8* strAreaTxtContent
	//end.
);


//5代控制卡动态区功能结束:====================================================================================================================================================================================================================


/*****************************以下为六代接口*******************************************/
/*! ***************************************************************
* 函数名：       bxDual_program_freeBuffer_G6(）
* 参数名：
*
* 返回值：0 成功， 其他值为错误号
* 功 能：释放生成节目文件的缓冲区
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_freeBuffer_G6(EQprogram_G6* program);

/*! ***************************************************************
* 函数名：       bxDual_program_changeProgramParams_G6（）
*	EQprogramHeader_G6：参考结构体EQprogramHeader_G6
* 返回值：0 成功， 其他值为错误号
* 功 能：修改已添加节目的一些参数
* 注：
* 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_changeProgramParams_G6(EQprogramHeader_G6 *programH);
/*! ***************************************************************
* 函数名：       bxDual_program_changeFrame_G6（）
*	sfHeader：参考结构体EQscreenframeHeader_G6
*	picPath：边框图片路径
* 返回值：0 成功， -1 不成功
* 功 能：节目修改已添加边框的一些参数
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_changeFrame_G6(EQscreenframeHeader_G6* sfHeader, Ouint8* picPath);
/*! ***************************************************************
* 函数名：       bxDual_program_removeFrame_G6（）
* 返回值：0 成功
* 功 能：节目去掉边框
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_removeFrame_G6();
/*! ***************************************************************
* 函数名：       bxDual_program_deleteArea_G6（）
* 参数名：
*   areaID：区域ID号
*
* 返回值：0 成功， 其他值为错误号
* 功 能：节目删除已添加的区域
* 注：
* 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_deleteArea_G6(Ouint16 areaID);

/*! ***************************************************************
* 函数名：       bxDual_program_MoveArea_G6()
*	areaID：区域的ID号
*   x:区域left坐标
*   y:区域top坐标
*   width:区域宽度
*   height:区域高度
*
* 返回值：0 成功， 其他值为错误号
* 功 能：改变区域坐标大小
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_MoveArea_G6(Ouint16 areaID, Oint32 x, Oint32 y, Oint32 width, Oint32 height);
/*! ***************************************************************
* 函数名：       bxDual_program_picturesAreaChangeTxt_G6（）
*	areaID：区域的ID号
*	str：需要画的文字
*	pheader：参考结构体EQpageHeader_G6
*
* 返回值：0 成功， 其他值为错误号
* 功 能：修改图文区域已添加过的文字内容及EQpageHeader_G6结构体中的参数
* 注：
* 如需修改字体，需要将区域删除，重新添加区域和文字
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_picturesAreaChangeTxt_G6(Ouint16 areaID, Ouint8* str, EQpageHeader_G6* pheader);
/*! ***************************************************************
* 函数名：       bxDual_program_fontPath_picturesAreaChangeTxt_G6（）
*	areaID：区域的ID号
*	str：需要画的文字
*	pheader：参考结构体EQpageHeader_G6
*
* 返回值：0 成功， 其他值为错误号
* 功 能：图文区修改字符串--使用字库
* 注：
* 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_fontPath_picturesAreaChangeTxt_G6(Ouint16 areaID, Ouint8* str, EQpageHeader_G6* pheader);
/*! ***************************************************************
* 函数名：       bxDual_program_backGroundPic_G6（）
*	areaID：区域的ID号
*   picID：图片编号，从0开始，第一次添加图片为0，第二次添加图片为1，依次累加，每个id对应一张图片
*	EQpageHeader_G6：参考结构体EQpageHeader_G6
*	picPath：图片的绝对路径加图片名称
* 返回值：0 成功， 其他值为错误号
* 功 能：添加图片到图文区域
* 注：下位机播放图片的次序与picID一致，即最先播放picID为0的图片，依次播放
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_backGroundPic_G6(Ouint16 areaID, Ouint16 picID, EQpageHeader_G6* pheader, Ouint8* picPath);

/*! ***************************************************************
* 函数名：       bxDual_program_backGroundColor_G6（）
*	areaID：区域的ID号
*   picID：图片编号，从0开始，第一次添加图片为0，第二次添加图片为1，依次累加，每个id对应一张图片
*	EQpageHeader_G6：参考结构体EQpageHeader_G6
*	BGColor：区域背景颜色值（RGB888）
* 返回值：0 成功， 其他值为错误号
* 功 能：添加图片到图文区域
* 注：下位机播放图片的次序与picID一致，即最先播放picID为0的图片，依次播放
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_backGroundColor_G6(Ouint16 areaID, EQpageHeader_G6* pheader, Ouint32 BGColor);

/*! **************************************************************** 函数名：       bxDual_program_pictureAreaChangePic_G6（）
*	areaID：区域的ID号
*   picID：图片编号，传入需要修改的图片编号
*	EQpageHeader_G6：参考结构体EQpageHeader_G6
*	picPath：图片的绝对路径加图片名称
* 返回值：0 成功， 其他值为错误号
* 功 能：修改当前picID对应的图片和一些参数
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_pictureAreaChangePic_G6(Ouint16 areaID, Ouint16 picID, EQpageHeader_G6* pheader, Ouint8* picPath);
/*! ***************************************************************
* 函数名：       bxDual_program_pictureAreaChangeSoundSettings_G6（）
*	areaID：区域的ID号
*	sheader：参考结构体EQPicAreaSoundHeader_G6
*   soundData:语音数据
*
* 返回值：0 成功， 其他值为错误
* 功 能：图文分区修改语音播放的一些参数或数据
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_pictureAreaChangeSoundSettings_G6(Ouint16 areaID, EQPicAreaSoundHeader_G6 sheader, Ouint8* soundData);
/*! ***************************************************************
* 函数名：       bxDual_program_pictureAreaDisableSound_G6（）
*	areaID：区域的ID号
*
*
*
* 返回值：0 成功， 其他值为错误
* 功 能：图文分区取消语音播放
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_pictureAreaDisableSound_G6(Ouint16 areaID);
/*! ***************************************************************
* 函数名：       bxDual_program_timeAreaChangeContent_G6（）
*	areaID：区域的ID号
*   timeData：参考结构体EQtimeAreaData_G56
*
*
* 返回值：0 成功， 其他值为错误
* 功 能：时间分区修改时间等内容，详情请参考结构体EQtimeAreaData_G56
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaChangeContent_G6(Ouint16 areaID, EQtimeAreaData_G56* timeData);
/*! ***************************************************************
* 函数名：       bxDual_program_timeAreaChangeAnalogClock_G6(）
* 参数名：
*	areaID：区域ID
*   header: 详情见EQAnalogClockHeader_G56结构体
*   cStyle: 表盘样式，详情见E_ClockStyle
*   cColor: 表盘颜色，详情见E_Color_G56通过此枚举值可以直接配置七彩色，如果大于枚举范围使用RGB888模式
* 返回值：0 成功， 其他值为错误号
* 功 能：时间分区修改模拟时钟的一些设置参数
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaChangeAnalogClock_G6(Ouint16 areaID, EQAnalogClockHeader_G56 *header, E_ClockStyle cStyle, ClockColor_G56* cColor);
/*! ***************************************************************
* 函数名：       bxDual_program_timeAreaChangeDialPic_G6(）
* 参数名：
*	areaID： 区域ID
*   picPath: 表盘图片位置
* 返回值：0 成功， 其他值为错误号
* 功 能：时间分区从外部添加表盘图片
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaChangeDialPic_G6(Ouint16 areaID, Ouint8* picPath);
/*! ***************************************************************
* 函数名：       bxDual_program_timeAreaRemoveDialPic_G6(）
* 参数名：
*	areaID： 区域ID
*
* 返回值：0 成功， 其他值为错误号
* 功 能：时间分区移除添加的表盘图片
* 注：
*
******************************************************************/
        [DllImport("bx_sdk_dual.dll", CharSet = CharSet.Unicode)]
        public static extern int bxDual_program_timeAreaRemoveDialPic_G6(Ouint16 areaID);
    }
}

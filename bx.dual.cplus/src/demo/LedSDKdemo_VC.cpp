#include <iostream>
#include"iostream"
#include "windows.h"
#include "Obasic_types.h"
using namespace std;

#pragma region
typedef enum
{
eSCREEN_COLOR_SINGLE = 1,    //单基色
eSCREEN_COLOR_DOUBLE,      //双基色
eSCREEN_COLOR_THREE,       //七彩色
eSCREEN_COLOR_FULLCOLOR,   //全彩色
}E_ScreenColor_G56;
typedef enum
{
eDOUBLE_COLOR_PIXTYPE_1 = 1, //双基色1：R+G
eDOUBLE_COLOR_PIXTYPE_2,   //双基色2：G+R
}E_DoubleColorPixel_G56;

typedef enum : int   //加上 :int 则元素是 int 类型
{
eSINGLELINE,   //单行
eMULTILINE,    //多行
}E_arrMode;

typedef enum
{
eYYYY_MM_DD_MINUS,   //YYYY-MM-DD
eYYYY_MM_DD_VIRGURE, //YYYY/MM/DD
eDD_MM_YYYY_MINUS,   //DD-MM-YYYY
eDD_MM_YYYY_VIRGURE, //DD/MM/YYYY
eMM_DD_MINUS,        //MM-DD
eMM_DD_VIRGURE,      //MM/DD
eMM_DD_CHS,          //MM月DD日
eYYYY_MM_DD_CHS,     //YYYY年MM月DD日
}E_DateStyle;

typedef enum
{
eHH_MM_SS_COLON,  //HH:MM:SS
eHH_MM_SS_CHS,    //HH时MM分SS秒
eHH_MM_COLON,     //HH:MM
eHH_MM_CHS,       //HH时MM分
eAM_HH_MM,        //AM HH:MM
eHH_MM_AM,        //HH:MM AM
}E_TimeStyle;

typedef enum
{
eMonday = 1,    //Monday
eMon,         //Mon.
eMonday_CHS,  //星期一
}E_WeekStyle;

typedef enum
{
eBLACK,     //黑色
eRED,       //红色
eGREEN,     //绿色
eYELLOW,    //黄色
eBLUE,		//蓝色
eMAGENTA,	//品红/洋红
eCYAN,		//青色
eWHITE,		//白色
}E_Color_G56;  //5代只支持前面四种颜色

typedef enum
{
eLINE,     //线形
eSQUARE,   //方形
eCIRCLE,   //圆形
}E_ClockStyle;//表盘样式

typedef enum
{
pNORMAL,       //正常
pROTATERIGHT,  //向右旋转
pMIRROR,       //镜像
pROTATELEFT,   //向左旋转
}E_txtDirection;//图文区文字方向---暂不支持

#pragma pack (push,1)

typedef struct {
Ouint8 FileType; //文件类型
Oint8 ControllerName[8]; // 控制器名称
Ouint16 Address; //控制器地址
Ouint8 Baudrate; /* 串口波特率
0x00 –保持原有波特率不变
0x01 –强制设置为 9600
0x02 –强制设置为 57600*/
Ouint16 ScreenWidth; //显示屏宽度
Ouint16 ScreenHeight; // 显示屏高度
Ouint8 Color; /* 显示屏颜色定义 Bit0 表示红， bit1 表示绿， bit2 表示
蓝， 对于每一个 Bit， 0 表示灭， 1 表示亮*/
Ouint8 MirrorMode; // 0x00 –无镜向 0x01 –镜向
Ouint8 OEPol; //OE 极性，0x00 – OE 低有效   0x01 – OE 高有效
Ouint8 DAPol; // 数据极性， 0x00 –数据低有效， 0x01 –数据高有效
Ouint8 RowOrder; /*行序模式， 该值范围为 0-31
0-15 代表正序
0 代表从第 0 行开始顺序扫描
1 代表从第 1 行开始顺序扫描
.....
16-31 代表逆序
0 代表从第 0 行开始逆序扫描
1 代表从第 1 行开始逆序扫描*/
Ouint8 FreqPar; /*CLK 分频倍数
注意： 针对于 AX 系列， 为后级分频
数值为 0~15， 共 16 个等级。*/
Ouint8 OEWidth; // OE 宽度
Ouint8 OEAngle; // OE 提前角
Ouint8 FaultProcessMode; /*控制器的错误处理模式
0x00 –自动处理
0x01 –手动处理(此模式仅供调试人员
使用)*/
Ouint8 CommTimeoutValue; /*通讯超时设置（单位秒）
建议值：
串口– 2S
TCP/IP – 6S
GPRS – 30S*/
Ouint8 RunningMode; /*控制器运行模式， 具体定义如下：
0x00 –正常模式
0x01 –调试模式*/
Ouint8 LoggingMode; /*日志记录模式
0x00 –无日志
0x01 –只对控制器错误及对错误进行
的错误进行记录
0x02 –对控制器的所有操作进行记
录， 包括： 控制器接收的各条指令、
发生的错误及错误处理*/
Ouint8 GrayFlag; /*灰度标志(仅 5Q 卡时有该字节)
0x00–无灰度
0x01–灰度*/
Ouint8 CascadeMode; /*级联模式： (仅 5Q 卡时有该字节)
0x00–非级联模式
0x01–级联模式*/
Ouint8 Default_brightness; /*AX 系列控制器专用， 表示上电时， 默
认的亮度等级值。 根据不同的屏幕类
型有所不同。*/
Ouint8 HUBConfig;  /*HUB 板设置(仅 6E 控制器支持)
0x00–HUB512 默认项
0x01–HUB256*/
Ouint8 Language; /*控制器多语言显示区。
0x00 ----简体中文显示。
0x01 ----非中文显示， 控制器显示图
形加英文字符。
其他值保留。*/
Ouint8 Backup[3]; // 备用字节
Ouint16 CRC16; //整个文件的 CRC16 校验
}ConfigFile;

typedef struct {
Ouint8 FileType; //文件类型
Oint8 ControllerName[16]; // 控制器名称
Oint8 ScreenAddress[48]; //屏幕安装地址限制为 24个字节长度

Ouint16 Address; //控制器地址
Ouint8 Baudrate; /* 串口波特率
0x00 –保持原有波特率不变
0x01 –强制设置为 9600
0x02 –强制设置为 57600*/
Ouint16 ScreenWidth; //显示屏宽度
Ouint16 ScreenHeight; // 显示屏高度
Ouint8 Color; /* 显示屏颜色定义 Bit0 表示红， bit1 表示绿， bit2 表示
蓝， 对于每一个 Bit， 0 表示灭， 1 表示亮*/
Ouint8 modeofdisp; // 6Q 系列显示模式： 0为888, 1为565，对其余控制卡该字节为0
Ouint8 TipLanguage; //0 表示上位机软件是中文版，底层固件在显示提示信息时需调用内置的中文提示信息
//1 表示上位机软件是英文版，底层固件在显示提示信息时需调用内置的英文提示信息
//255 表示上位机软件是其他语言版，底层固件在显示提示信息时需调用自定义提示信息
Ouint8 Reserved[5]; // 5个备用字节
Ouint8 FaultProcessMode; /*控制器的错误处理模式
0x00 –自动处理
0x01 –手动处理(此模式仅供调试人员使用)*/
Ouint8 CommTimeoutValue; /*通讯超时设置（单位秒）
建议值：
串口– 2S
TCP/IP – 6S
GPRS – 30S*/
Ouint8 RunningMode; /* 控制器运行模式，具体定义如下：
0x00 –正常模式
0x01 –调试模式*/
Ouint8 LoggingMode; /*日志记录模式
0x00 –无日志
0x01 –只对控制器错误及对错误进行
的错误进行记录
0x02 –对控制器的所有操作进行记
录， 包括： 控制器接收的各条指令、
发生的错误及错误处理*/
Ouint8 DevideScreenMode; /*针对 6Q2 卡的分屏模式
对其余的卡为保留字节 0*/
Ouint8 Reserved2; //备用字节
Ouint8 Default_brightness;  /*AX 系列控制器专用，表示上电时，默
认的亮度等级值。其余的控制卡该字
节为保留字 0*/
Ouint8 Backup[5]; // 备用值字节
Ouint16 CRC16; //整个文件的 CRC16 校验
}ConfigFile_G6;

typedef struct {
// 控制器类型
//小端存储低位在前高位在后， 比如 0x254 反着取，低位表示系列，高位编号  [0x54, 0x02] 【系列，编号】
Ouint16 ControllerType;
// 固件版本号
Ouint8 FirmwareVersion[8];
// 控制器参数文件状态 0x00 –控制器中没有参数配置文件，以下返回的是控制器的默认参数。 此时， PC 软件应提示用户必须先加载屏参。0x01 –控制器中有参数配置文件
Ouint8 ScreenParaStatus;
// 控制器地址
Ouint16 uAddress;
// 波特率
Ouint8 Baudrate;
// 屏宽
Ouint16 ScreenWidth;
// 屏高
Ouint16 ScreenHeight;
// 显示屏颜色定义
Ouint8 Color;
//当前亮度值   整数1-16
Ouint8 CurrentBrigtness;
// 控制器开关机状态   0 关机  1开机？
Ouint8 CurrentOnOffStatus;
// 扫描配置编号
Ouint16 ScanConfNumber;
// 第一个自己一路数据代几行，其他基本用不上，如有需要可参考协议取相应的字节
Ouint8 reversed[9];
// 控制器ip地址
Ouint8 ipAdder[20];
}Ping_data;


typedef struct {
Ouint8 password[8];    //密码
Ouint8 ip[4];          //控制器IP地址
Ouint8 subNetMask[4];  // 子网掩码
Ouint8 gate[4];           // 网关
short port;            // 端口
Ouint8 mac[6];           // MAC地址
Ouint8 netID[12];       // 控制器网络ID
}heartbeatData;


//typedef struct APPLICATION_LAYER_LED_HEADER_56
//{
//	Ouint8 reserved;
//	Ouint8 cmdgroup;//命令组
//	Ouint8 cmd;//命令编号
//	Ouint16 status;//控制器状态 返回ACK,则status=0,NACK,则status=1
//	Ouint16 Error;//错误状态
//	Ouint16 datalen;//数据长度
//}response_header_56;


typedef struct {
//Oint8 CmdGroup;		//1 0xA4 命令组 //Oint8 Cmd;		//1 0x83 命令编号 //Oint16 Status;	//2 控制器状态//Oint16 Error;	//2 错误状态寄存器//Oint16 DataLen;	//		2 0xA4 数据长度
Oint8 Mac[6];			//6 Mac 地址
Ouint8 IP[4];			//4 控制器 IP 地址
Ouint8 SubNetMask[4];	//4 子网掩码
Ouint8 Gate[4];			//4 网关
Ouint8 Port[2];			//2 端口
Oint8 IPMode;			//1 1 表示 DHCP 2 表示手动设置
Oint8 IPStatus;			//1 0 表示 IP 设置失败 1 表示 IP 设置成功
Oint8 ServerMode;		//1 0 Bit[0]表示服务器模式是否使能：1 –使能，0 –禁止 Bit[1]表示服务器模式：1 –web 模式，0 –普通模式
Ouint8 ServerIPAddress[4];// 4 服务器 IP 地址
Oint16 ServerPort;		//2 服务器端口号
Oint8 ServerAccessPassword[8];//	8 服务器访问密码
Oint16 HeartBeatInterval;//2 20S 心跳时间间隔（单位：秒）
Oint8 CustomID[12];		//12 用户自定义 ID，作为网络 ID 的前半部分，便于用户识别其控制卡
//Web 模式下参见下面的数据结构：NetSearchCmdRet_Web   返回下述 5 项的实际值，否则不上传下述 5 项
//Oint8 WebUserID[128];//		128 0 WEB 平台用户 id//Oint32 GroupNum;//		4 0 屏幕组号//Oint8 DomainFlag;//		1 0 域名标志 0 - 无域名，1—域名//Oint8 DomainName[128];//		128 域名名称 当 DomainFlag 为 1 时下发//Oint8 WebControllerName[128];// 128 LED00001 WEB 平台控制器名称
//Web 模式下返回结束 ==================================================
Oint8 BarCode[16];		//16 条形码，作为网络 ID 的后半部分，用以实现网络 ID 的唯一性
Oint16 ControllerType;	//2 其中低位字节表示设备系列，而高位字节表示设备编号，例如 BX - 6Q2 应表示为[0x66, 0x02]，其它型号依此类推。
Oint8 FirmwareVersion[8];// 8 Firmware 版本号
Oint8 ScreenParaStatus;	//1 控制器参数文件状态 0x00 –控制器中没有参数配置文件，以下返回的是控制器的默认参数。此时，PC软件应提示用户必须先加载屏参。0x01 –控制器中有参数配置文件
Oint16 Address;			//2 0x0001 控制器地址控制器出厂默认地址为 0x0001(0x0000 地址将保留)控制除了对发送给自身地址的数据包进行处理外，还需对广播数据包进行处理。
Oint8 Baudrate;			//1 0x00 波特率 0x00 –保持原有波特率不变 0x01 –强制设置为 9600 0x02 –强制设置为 57600
Oint16 ScreenWidth;		//2 192 显示屏宽度
Oint16 ScreenHeight;	//2 96 显示屏高度
Oint8 Color;			//1 0x01 对于无灰度系统，单色时返回 1，双色时返回 3，三色时返回 7；对于有灰度系统，返回 255
Oint8 BrightnessAdjMode;// 1 调亮模式 0x00 –手动调亮 0x01 –定时调亮 0x02 –自动调亮
Oint8 CurrentBrigtness;	// 1 当前亮度值
Oint8 TimingOnOff;		//1 Bit0 –定时开关机状态，0 表示无定时开关机，1 表示有定时开关机
Oint8 CurrentOnOffStatus;//1 开关机状态
Oint16 ScanConfNumber;	//2 扫描配置编号
Oint8 RowsPerChanel;	//1 一路数据带几行
Oint8 GrayFlag;			//1 对于无灰度系统，返回 0；对于有灰度系
Oint8 UnitWidth[2];		//2 最小单元宽度
Oint8 modeofdisp;		//1 6Q 显示模式 : 0 为 888, 1 为 565，其余卡为 0
Oint8 NetTranMode;		//1 当该字节为 0 时，网口通讯使用老的模式，即 UDP 和 TCP 均根据下面的PackageMode 字节确定包长，并且 UDP通讯时，将大包分为小包，每发送一小包做一下延时当该字节不为 0 时，网口通讯使用新的模式，即 UDP 的包长等于UDPPackageMode * 8KBYTE，且不再分为小包，将整包数据丢给协议栈TCP 的包长等于 PackageMode * 16KBYTE
Oint8 PackageMode;		//1 包模式。0 小包模式，分包 600 byte。1 大包模式，分包 16K byte。
Oint8 BarcodeFlag;		//1 是否设置了条码 ID如果设置了，该字节第 0 位为 1，否则为0
Oint16 ProgramNumber;	//2 控制器上已有节目个数
Oint32 CurrentProgram;	//4 当前节目名
Oint8 ScreenLockStatus;	//1 Bit0 –是否屏幕锁定，1b’0 –无屏幕锁定，1b’1 –屏幕锁定
Oint8 ProgramLockStatus;//1 Bit0 –是否节目锁定，1b’0 –无节目锁定，1’b1 –节目锁定
Oint8 RunningMode;		//1 控制器运行模式
Oint8 RTCStatus;		//1 RTC 状态 0x00 – RTC 异常 0x01 – RTC 正常
Oint16 RTCYear;			//2 年
Oint8 RTCMonth;			//1 月
Oint8 RTCDate;			//1 日
Oint8 RTCHour;			//1 小时
Oint8 RTCMinute;		//1 分钟
Oint8 RTCSecond;		//1 秒
Oint8 RTCWeek;			//1 星期，范围为 1~7，7 表示周日
Oint8 Temperature1[3];	//3 温度传感器当前值
Oint8 Temperature2[3];	//3 温度传感器当前值
Oint8 Humidity[2];		//2 湿度传感器当前值
Oint8 Noise[2];			//2 噪声传感器当前值(除以 10 为当前值)针对 BX - ZS(485) 0xffff 时无效
Oint8 Reserved;			//1 保留字节
Oint8 LogoFlag;			//1 0：表示未设置 Logo 节目 1：表示设置了 Logo 节目
Oint16 PowerOnDelay;	//2 0：未设置开机延时 1：开机延时时长
Oint16 WindSpeed;		//2 风速(除以 10 为当前值) 0xfffff 时无效
Oint16 WindDirction;	//2 风向(当前值) 0xfffff 时无效
Oint16 PM2_5;			//2 PM2.5 值(当前值)0xfffff 时无效
Oint16 PM10;			//2 PM10 值(当前值)0xfffff 时无效
//Oint8 Reserved2[24];	//24 保留字
Oint16 ExtendParaLen;	// 2 0x40 扩展参数长度
Oint8 ControllerName[16];	// 16 LEDCON01 控制器名称限制为 16 个字节长度(全是 0x00 表示屏参丢失，参数无效，上位机空白显示)
Oint8 ScreenLocation[44];	// 44 0 屏幕安装地址限制为 44 个字节长度(全是 0x00 表示屏参丢失，参数无效，上位机空白显示)
Oint8 NameLocalationCRC32[4];// 4 控制器和屏幕安装地址共 60 个字节的CRC32 校验值，该值是为了便于上位机区分此处 64 个字节是表示控制器名称还是用来表示控制器名称和屏幕安装地址，进而采取不同的处理策略为了保持兼容，下位机不对该值进行验证
}NetSearchCmdRet;


typedef struct {
//Oint8 CmdGroup;		//1 0xA4 命令组 //Oint8 Cmd;		//1 0x83 命令编号 //Oint16 Status;	//2 控制器状态//Oint16 Error;	//2 错误状态寄存器//Oint16 DataLen;	//		2 0xA4 数据长度
Oint8 Mac[6];			//6 Mac 地址
Ouint8 IP[4];			//4 控制器 IP 地址
Ouint8 SubNetMask[4];	//4 子网掩码
Ouint8 Gate[4];			//4 网关
Ouint8 Port[2];			//2 端口
Oint8 IPMode;			//1 1 表示 DHCP 2 表示手动设置
Oint8 IPStatus;			//1 0 表示 IP 设置失败 1 表示 IP 设置成功
Oint8 ServerMode;		//1 0 Bit[0]表示服务器模式是否使能：1 –使能，0 –禁止 Bit[1]表示服务器模式：1 –web 模式，0 –普通模式
Ouint8 ServerIPAddress[4];// 4 服务器 IP 地址
Oint16 ServerPort;		//2 服务器端口号
Oint8 ServerAccessPassword[8];//	8 服务器访问密码
Oint16 HeartBeatInterval;//2 20S 心跳时间间隔（单位：秒）
Oint8 CustomID[12];		//12 用户自定义 ID，作为网络 ID 的前半部分，便于用户识别其控制卡
//Web 模式下返回下述 5 项的实际值，否则不上传下述 5 项
Oint8 WebUserID[128];	//		128 0 WEB 平台用户 id
Oint32 GroupNum;		//		4 0 屏幕组号
Oint8 DomainFlag;		//		1 0 域名标志 0 - 无域名，1—域名
Oint8 DomainName[128];	//		128 域名名称 当 DomainFlag 为 1 时下发
Oint8 WebControllerName[128];// 128 LED00001 WEB 平台控制器名称
//Web 模式下返回下述 5 项 结束 ###################
Oint8 BarCode[16];		//16 条形码，作为网络 ID 的后半部分，用以实现网络 ID 的唯一性
Oint16 ControllerType;	//2 其中低位字节表示设备系列，而高位字节表示设备编号，例如 BX - 6Q2 应表示为[0x66, 0x02]，其它型号依此类推。
Oint8 FirmwareVersion[8];// 8 Firmware 版本号
Oint8 ScreenParaStatus;	//1 控制器参数文件状态 0x00 –控制器中没有参数配置文件，以下返回的是控制器的默认参数。此时，PC软件应提示用户必须先加载屏参。0x01 –控制器中有参数配置文件
Oint16 Address;			//2 0x0001 控制器地址控制器出厂默认地址为 0x0001(0x0000 地址将保留)控制除了对发送给自身地址的数据包进行处理外，还需对广播数据包进行处理。
Oint8 Baudrate;			//1 0x00 波特率 0x00 –保持原有波特率不变 0x01 –强制设置为 9600 0x02 –强制设置为 57600
Oint16 ScreenWidth;		//2 192 显示屏宽度
Oint16 ScreenHeight;	//2 96 显示屏高度
Oint8 Color;			//1 0x01 对于无灰度系统，单色时返回 1，双色时返回 3，三色时返回 7；对于有灰度系统，返回 255
Oint8 BrightnessAdjMode;//1 调亮模式 0x00 –手动调亮 0x01 –定时调亮 0x02 –自动调亮
Oint8 CurrentBrigtness;	//1 当前亮度值
Oint8 TimingOnOff;		//1 Bit0 –定时开关机状态，0 表示无定时开关机，1 表示有定时开关机
Oint8 CurrentOnOffStatus;//1 开关机状态
Oint16 ScanConfNumber;	//2 扫描配置编号
Oint8 RowsPerChanel;	//1 一路数据带几行
Oint8 GrayFlag;			//1 对于无灰度系统，返回 0；对于有灰度系
Oint8 UnitWidth[2];		//2 最小单元宽度
Oint8 modeofdisp;		//1 6Q 显示模式 : 0 为 888, 1 为 565，其余卡为 0
Oint8 NetTranMode;		//1 当该字节为 0 时，网口通讯使用老的模式，即 UDP 和 TCP 均根据下面的PackageMode 字节确定包长，并且 UDP通讯时，将大包分为小包，每发送一小包做一下延时当该字节不为 0 时，网口通讯使用新的模式，即 UDP 的包长等于UDPPackageMode * 8KBYTE，且不再分为小包，将整包数据丢给协议栈TCP 的包长等于 PackageMode * 16KBYTE
Oint8 PackageMode;		//1 包模式。0 小包模式，分包 600 byte。1 大包模式，分包 16K byte。
Oint8 BarcodeFlag;		//1 是否设置了条码 ID如果设置了，该字节第 0 位为 1，否则为0
Oint16 ProgramNumber;	//2 控制器上已有节目个数
Oint32 CurrentProgram;	//4 当前节目名
Oint8 ScreenLockStatus;	//1 Bit0 –是否屏幕锁定，1b’0 –无屏幕锁定，1b’1 –屏幕锁定
Oint8 ProgramLockStatus;//1 Bit0 –是否节目锁定，1b’0 –无节目锁定，1’b1 –节目锁定
Oint8 RunningMode;		//1 控制器运行模式
Oint8 RTCStatus;		//1 RTC 状态 0x00 – RTC 异常 0x01 – RTC 正常
Oint16 RTCYear;			//2 年
Oint8 RTCMonth;			//1 月
Oint8 RTCDate;			//1 日
Oint8 RTCHour;			//1 小时
Oint8 RTCMinute;		//1 分钟
Oint8 RTCSecond;		//1 秒
Oint8 RTCWeek;			//1 星期，范围为 1~7，7 表示周日
Oint8 Temperature1[3];	//3 温度传感器当前值
Oint8 Temperature2[3];	//3 温度传感器当前值
Oint8 Humidity[2];		//2 湿度传感器当前值
Oint8 Noise[2];			//2 噪声传感器当前值(除以 10 为当前值)针对 BX - ZS(485) 0xffff 时无效
Oint8 Reserved;			//1 保留字节
Oint8 LogoFlag;			//1 0：表示未设置 Logo 节目 1：表示设置了 Logo 节目
Oint16 PowerOnDelay;	//2 0：未设置开机延时 1：开机延时时长
Oint16 WindSpeed;		//2 风速(除以 10 为当前值) 0xfffff 时无效
Oint16 WindDirction;	//2 风向(当前值) 0xfffff 时无效
Oint16 PM2_5;			//2 PM2.5 值(当前值)0xfffff 时无效
Oint16 PM10;			//2 PM10 值(当前值)0xfffff 时无效
//Oint8 Reserved2[24];	//24 保留字
Oint16 ExtendParaLen;	// 2 0x40 扩展参数长度
Oint8 ControllerName[16];	// 16 LEDCON01 控制器名称限制为 16 个字节长度(全是 0x00 表示屏参丢失，参数无效，上位机空白显示)
Oint8 ScreenLocation[44];	// 44 0 屏幕安装地址限制为 44 个字节长度(全是 0x00 表示屏参丢失，参数无效，上位机空白显示)
Oint8 NameLocalationCRC32[4];// 4 控制器和屏幕安装地址共 60 个字节的CRC32 校验值，该值是为了便于上位机区分此处 64 个字节是表示控制器名称还是用来表示控制器名称和屏幕安装地址，进而采取不同的处理策略为了保持兼容，下位机不对该值进行验证
}NetSearchCmdRet_Web;

typedef struct {
Ouint8 onHour;   // 开机小时
Ouint8 onMinute; // 开机分钟
Ouint8 offHour;  // 关机小时
Ouint8 offMinute; // 关机分钟
}TimingOnOff;

typedef struct {
/*
0x00 –手动调亮
0x01 –定时调亮 注:以下的亮度值表，在定时调亮和手 动调亮时控制器才需处理。但在协议上 不论什么模式，此表都需要发送给控制 器
0x00 –手动调亮
0x01 –定时调亮 注:以下的亮度值表，在定时调亮和手 动调亮时控制器才需处理。但在协议上 不论什么模式，此表都需要发送给控制 器
*/
Ouint8 BrightnessMode;

//00:00 – 00:29 的亮度值， 0x00 – 0x0f
Ouint8 HalfHourValue0;
Ouint8 HalfHourValue1;
Ouint8 HalfHourValue2;
Ouint8 HalfHourValue3;
Ouint8 HalfHourValue4;
Ouint8 HalfHourValue5;
Ouint8 HalfHourValue6;
Ouint8 HalfHourValue7;
Ouint8 HalfHourValue8;
Ouint8 HalfHourValue9;
Ouint8 HalfHourValue10;
Ouint8 HalfHourValue11;
Ouint8 HalfHourValue12;
Ouint8 HalfHourValue13;
Ouint8 HalfHourValue14;
Ouint8 HalfHourValue15;
Ouint8 HalfHourValue16;
Ouint8 HalfHourValue17;
Ouint8 HalfHourValue18;
Ouint8 HalfHourValue19;
Ouint8 HalfHourValue20;
Ouint8 HalfHourValue21;
Ouint8 HalfHourValue22;
Ouint8 HalfHourValue23;
Ouint8 HalfHourValue24;
Ouint8 HalfHourValue25;
Ouint8 HalfHourValue26;
Ouint8 HalfHourValue27;
Ouint8 HalfHourValue28;
Ouint8 HalfHourValue29;
Ouint8 HalfHourValue30;
Ouint8 HalfHourValue31;
Ouint8 HalfHourValue32;
Ouint8 HalfHourValue33;
Ouint8 HalfHourValue34;
Ouint8 HalfHourValue35;
Ouint8 HalfHourValue36;
Ouint8 HalfHourValue37;
Ouint8 HalfHourValue38;
Ouint8 HalfHourValue39;
Ouint8 HalfHourValue40;
Ouint8 HalfHourValue41;
Ouint8 HalfHourValue42;
Ouint8 HalfHourValue43;
Ouint8 HalfHourValue44;
Ouint8 HalfHourValue45;
Ouint8 HalfHourValue46;
Ouint8 HalfHourValue47;
}Brightness;

typedef struct {
Ouint8 onoffStatus; // 开关机状态 Bit 0 –开机/关机， 0 表示关机， 1 表示开机
Ouint8 timingOnOff; // 定时开关机状态 0 表示无定时开关机， 1 表示有定时开关机
Ouint8 brightnessAdjMode; //亮度模式 0x00 –手动调亮 0x01 –定时调亮 0x02 –自动调亮
Ouint8 brightness;// 当前亮度值
short programeNumber;// 控制器上已有节目个数
Ouint8 currentProgram[4];//当前节目名
Ouint8 screenLockStatus;//是否屏幕锁定，0 –无屏幕锁定， 1 –屏幕锁定
Ouint8 programLockStatus; //是否节目锁定， 0 –无节目锁定，1 –节目锁定
Ouint8 runningMode;//控制器运行模式
Ouint8 RTCStatus;//RTC 状态0x00 – RTC 异常 0x01 – RTC 正常
short RTCYear;//年
Ouint8 RTCMonth;//月
Ouint8 RTCDate;//日
Ouint8 RTCHour;//时
Ouint8 RTCMinute;//分
Ouint8 RTCSecond;//秒
Ouint8 RTCWeek;//星期 1--7
Ouint8 temperature1[3];//温度1传感器当前值
Ouint8 temperature2[3];//温度2传感器当前值
short humidity;//湿度传感器当前值
short noise;//噪声传感器当前值
Ouint8 switchStatus; //测试按钮状态 0 –打开 1 –闭合
Ouint8 CustomID[12]; //用户自定义 ID，作为网络 ID 的前半部分，便于用户识别其控制卡
Ouint8 BarCode[16]; //条形码，作为网络 ID 的后半部分，用以实现网络 ID 的唯一性
}ControllerStatus_G56;

typedef struct {
Ouint8 rstMode; //复位模式 0x00 –取消定时复位功能 0x01 –周期复位， 此时 RstInterval 字段有效 0x02 –只在指定时间复位
Ouint32 RstInterval;//复位周期， 单位： 分钟如此字段为 0， 不进行复位操作
Ouint8 rstHour1; //小时 0Xff–表示此组无效， 下同
Ouint8 rstMin1;
Ouint8 rstHour2;
Ouint8 rstMin2;
Ouint8 rstHour3;
Ouint8 rstMin3;
}TimingReset;

typedef struct {
short BattleRTCYear; //年
Ouint8 BattleRTCMonth;//月
Ouint8 BattleRTCDate;//日
Ouint8 BattleRTCHour;//时
Ouint8 BattleRTCMinute;//分
Ouint8 BattleRTCSecond;//秒
Ouint8 BattleRTCWeek;//星期
}BattleTime;

typedef struct {
/*
默认：0x00
LOGO文件:0x08
扫描配置文件:0x02
日志文件:0x06
字库文件:0x05
提示信息库文件: 0x07
*/
Ouint8     FileType; //文件类型
Ouint32    ProgramID;//节目ID

/*
Bit0 –全局节目标志位
Bit1 –动态节目标志位
Bit2 –屏保节目标志位
*/
Ouint8    ProgramStyle;//节目类型

//注:带播放时段的节目优先级为 1，不 带播放时段的节目优先级为 0
Ouint8    ProgramPriority; //节目等级
Ouint8    ProgramPlayTimes;//节目重播放次数
Ouint16   ProgramTimeSpan; //播放的方式
Ouint8    ProgramWeek;      //节目星期属性
Ouint16   ProgramLifeSpan_sy;//年
Ouint8    ProgramLifeSpan_sm;//月
Ouint8    ProgramLifeSpan_sd;//日
Ouint16   ProgramLifeSpan_ey;//结束年
Ouint8    ProgramLifeSpan_em;//结束日
Ouint8    ProgramLifeSpan_ed;//结束天
//Ouint8    PlayPeriodGrpNum;//播放时段的组数
}BXprogramHeader,EQprogramHeader;

typedef struct
{
Ouint8 StartHour;
Ouint8 StartMinute;
Ouint8 StartSecond;
Ouint8 EndHour;
Ouint8 EndMinute;
Ouint8 EndSecond;
}BXprogrampTime_G56,EQprogrampTime_G56;//节目的播放时段

typedef struct
{
Ouint8 playTimeGrpNum; //播放时间有效组数 0 没有播放时段全天播放 最大值8 
EQprogrampTime_G56 timeGrp0;
EQprogrampTime_G56 timeGrp1;
EQprogrampTime_G56 timeGrp2;
EQprogrampTime_G56 timeGrp3;
EQprogrampTime_G56 timeGrp4;
EQprogrampTime_G56 timeGrp5;
EQprogrampTime_G56 timeGrp6;
EQprogrampTime_G56 timeGrp7;
}BXprogramppGrp_G56,EQprogramppGrp_G56;//播放时段共有8组

typedef struct {
Ouint8   FrameDispFlag;
Ouint8   FrameDispStyle;
Ouint8   FrameDispSpeed;
Ouint8   FrameMoveStep;
Ouint8   FrameWidth;
Ouint16  FrameBackup;
}BXscreenframeHeader,EQscreenframeHeader;

typedef struct {
Ouint8   AreaFFlag;
Ouint8   AreaFDispStyle;
Ouint8   AreaFDispSpeed;
Ouint8   AreaFMoveStep;
Ouint8   AreaFWidth;
Ouint16  AreaFBackup;
}BXareaframeHeader,EQareaframeHeader;

typedef struct {
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
Ouint8    AreaType; //区域类型

Ouint16    AreaX; //区域X坐标
Ouint16    AreaY; //区域Y坐标
Ouint16    AreaWidth; //区域宽
Ouint16    AreaHeight;//区域高
}BXareaHeader,EQareaHeader;

typedef struct { //请参考协议 图文字幕区数据格式
Ouint8   PageStyle; //数据页类型
Ouint8   DisplayMode; //显示方式 （特效）:0x00 –随机显示; 0x01–静止显示; 0x02–快速打出; 0x03–向左移动; ...0x25 –向右移动  0x26 –向右连移  0x27 –向下移动  0x28 –向下连移
Ouint8   ClearMode; // 退出方式/清屏方式
Ouint8   Speed; // 速度等级/背景速度等级
Ouint16  StayTime; // 停留时间， 单位为 10ms
Ouint8   RepeatTime;//重复次数/背景拼接步长(左右拼接下为宽度， 上下拼接为高度)
Ouint16  ValidLen;  //用法比较复杂请参考协议
E_arrMode arrMode; //排列方式--单行多行
Ouint16  fontSize; //字体大小
Ouint32  color; //字体颜色 E_Color_G56此通过此枚举值可以直接配置七彩色，如果大于枚举范围使用RGB888模式
Obool    fontBold; //是否为粗体
Obool    fontItalic;//是否为斜体
E_txtDirection tdirection;//文字方向
Ouint16   txtSpace; //文字间隔   
Ouint8 Halign; //横向对齐方式（0系统自适应、1左对齐、2居中、3右对齐）
Ouint8 Valign; //纵向对齐方式（0系统自适应、1上对齐、2居中、3下对齐）
}BXpageHeader,EQpageHeader;

typedef struct
{
E_arrMode arrMode; //排列方式--单行多行  E_arrMode::	eSINGLELINE,   //单行 eMULTILINE,    //多行
Ouint16  fontSize; //字体大小
Ouint32 color;//字体颜色 E_Color_G56 此通过此枚举值可以直接配置七彩色，如果大于枚举范围使用RGB888模式
Obool    fontBold; //是否为粗体
Obool    fontItalic;//是否为斜体
E_txtDirection tdirection;//文字方向
Ouint16   txtSpace;  //文字间隔   
Ouint8 Halign; //横向对齐方式（0系统自适应、1左对齐、2居中、3右对齐）
Ouint8 Valign; //纵向对齐方式（0系统自适应、1上对齐、2居中、3下对齐）
}BXfontData,EQfontData;

typedef struct {
Ouint8 fileName[4]; //文件名
Ouint8 fileType; //文件类型
Ouint32 fileLen; //文件长度
Ouint8* fileAddre; // 文件所在的缓存地址
Ouint32 fileCRC32; //文件CRC32校验码
}BXprogram,EQprogram;

typedef struct {
Ouint16 allPageNub;
Ouint32 pageLen;
Oint8* fileAddre;
}getPageData;

typedef struct
{
Ouint16  UnitX;
Ouint16  UnitY;
Ouint8   UnitType;
Ouint8   Align;
Ouint8   UnitColor;
Ouint8   UnitMode;
}BXunitHeader,EQunitHeader;

typedef struct
{
E_arrMode       linestyle;			//排列方式，单行还是多行
Ouint32         color;				//字体颜色 E_Color_G56此通过此枚举值可以直接配置七彩色，如果大于枚举范围使用RGB888模式
Ouint8*         fontName;           //字体名字
Ouint16         fontSize;           //字体大小
Ouint8			fontBold;           //字体加粗
Ouint8			fontItalic;         //斜体
Ouint8			fontUnderline;      //字体加下划线
Ouint8			fontAlign;          //对齐方式--多行有效
Obool			date_enable;        //是否添加日期
E_DateStyle		datestyle;			//日期格式
Obool			time_enable;        //是否添加时间---默认添加
E_TimeStyle		timestyle;			//时间格式
Obool			week_enable;        //是否添加星期
E_WeekStyle		weekstyle;			//星期格式
}BXtimeAreaData_G56,EQtimeAreaData_G56;

typedef struct
{
Ouint16  OrignPointX;    //原点横坐标
Ouint16  OrignPointY;    //原点纵坐标
Ouint8   UnitMode;       //表针模式
Ouint8   HourHandWidth;  //时针宽度
Ouint8   HourHandLen;    //时针长度
Ouint32   HourHandColor;  //时针颜色
Ouint8   MinHandWidth;   //分针宽度
Ouint8   MinHandLen;     //分针长度
Ouint32  MinHandColor;   //分针颜色
Ouint8   SecHandWidth;   //秒针宽度
Ouint8   SecHandLen;     //秒针长度
Ouint32   SecHandColor;   //秒针颜色
}BXAnalogClockHeader_G56,EQAnalogClockHeader_G56;

typedef struct {
/*
默认：0x00
LOGO文件:0x08
扫描配置文件:0x02
日志文件:0x06
字库文件:0x05
提示信息库文件: 0x07
*/
Ouint8    FileType; //文件类型
Ouint32   ProgramID;//节目ID

/*
Bit0 –全局节目标志位
Bit1 –动态节目标志位
Bit2 –屏保节目标志位
*/
Ouint8    ProgramStyle;			//节目类型
//注:带播放时段的节目优先级为 1，不带播放时段的节目优先级为 0
Ouint8    ProgramPriority;		//节目等级
Ouint8    ProgramPlayTimes;		//节目重播放次数
Ouint16   ProgramTimeSpan;		//播放的方式
Ouint8    SpecialFlag;			//特殊节目标
Ouint8    CommExtendParaLen;	//扩展参数长度，默认为0x00
Ouint16   ScheduNum;			//节目调度  
Ouint16   LoopValue;			//调度规则循环次数
Ouint8    Intergrate;			//调度相关
Ouint8    TimeAttributeNum;		//时间属性组数
Ouint16   TimeAttribute0Offset; //第一组时间属性偏移量--目前只支持一组
Ouint8    ProgramWeek;			//节目星期属性
Ouint16   ProgramLifeSpan_sy;	//年
Ouint8    ProgramLifeSpan_sm;	//月
Ouint8    ProgramLifeSpan_sd;	//日
Ouint16   ProgramLifeSpan_ey;	//结束年
Ouint8    ProgramLifeSpan_em;	//结束日
Ouint8    ProgramLifeSpan_ed;	//结束天
//Ouint8    PlayPeriodGrpNum;		//播放时段的组数
}BXprogramHeader_G6,EQprogramHeader_G6;

typedef struct
{
Ouint8 FrameDispStype;    //边框显示方式
Ouint8 FrameDispSpeed;    //边框显示速度
Ouint8 FrameMoveStep;     //边框移动步长
Ouint8 FrameUnitLength;   //边框组元长度
Ouint8 FrameUnitWidth;    //边框组元宽度
Ouint8 FrameDirectDispBit;//上下左右边框显示标志位，目前只支持6QX-M卡    
}BXscreenframeHeader_G6,EQscreenframeHeader_G6;

/*下面的这个语音结构体EQSound_6G仅在动态区时使用；图文分区播放语音请使用：EQPicAreaSoundHeader_G6;*/
typedef struct
{
Oint8 SoundFlag;		//1 0x00 是否使能语音播放;0 表示不使能语音; 1 表示播放下文中 SoundData 部分内容;
//SoundData 部分内容---------------------------------------------------------------------------------------------------------------------------------------------------
Oint8 SoundPerson;		//1 0x00 发音人 该值范围是 0 - 5，共 6 种选择只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 0
Oint8 SoundVolum;		//1 0x05 音量该值范围是 0~10，共 11 种，0表示静音只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 5
Oint8 SoundSpeed;		//1 0x05 语速该值范围是 0~10，共 11 种只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 5
Oint8 SoundDataMode;	//1 0x00 SoundData 的编码格式：该值意义如下：0x00 GB2312; 0x01 GBK; 0x02 BIG5; 0x03 UNICODE只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送
Oint32 SoundReplayTimes;	// 4 0x00000000 重播次数该值为 0，表示播放 1 次该值为 1，表示播放 2 次
//......
//该值为 0xffffffff，表示播放无限次只有 SoundFlag（是否使能语播放）为 1 时才发送该字节，否则不发送该值默认为 0
Oint32 SoundReplayDelay;// 4 0x00000000 重播时间间隔该值表示两次播放语音的时间间隔，单位为 10ms只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 0
Oint8 SoundReservedParaLen;// 1 0x03 语音参数保留参数长度
Oint8 Soundnumdeal;		// 1 0 0：自动判断1：数字作号码处理 2：数字作数值处理只有当 SoundFlag 为 1 且SoundReservedParaLen不为 0才发送此参数
Oint8 Soundlanguages;	// 1 0 0：自动判断语种1：阿拉伯数字、度量单位、特殊符号等合成为中文2：阿拉伯数字、度量单位、特殊符号等合成为英文只有当 SoundFlag 为 1 且 SoundReservedParaLen不为 0才发送此参数（目前只支持中英文）
Oint8 Soundwordstyle;	// 1 0 0：自动判断发音方式1：字母发音方式2：单词发音方式；只有当 SoundFlag 为 1 且SoundReservedParaLen不为 0才发送此参数
Ouint32 SoundDataLen;	// 4 语音数据长度; 只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送
Ouint8* SoundData;		// N 语音数据只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送
}
EQSound_6G;/*这个语音结构体EQSound_6G仅在动态区时使用；图文分区播放语音请使用：EQPicAreaSoundHeader_G6;*/

//动态区独立语音队列功能
//5.4.3 更新语音队列命令
typedef struct
{
Ouint8 VoiceID;	// 1 1 语音队列中每个语音的 ID，从 0 开始
EQSound_6G stSound;
}BXSoundDepend_6G,EQSoundDepend_6G;

typedef struct
{
Ouint8	AreaType;		//区域类型；动态区时，固定为0x10;
Ouint16	AreaX;			//区域左上角横坐标
Ouint16	AreaY;			//区域左上角纵坐标
Ouint16	AreaWidth;		//区域宽度
Ouint16	AreaHeight;		//区域高度
Ouint8  BackGroundFlag; //是否有背景
Ouint8  Transparency;   //透明度
Ouint8  AreaEqual;      //前景、背景区域大小是否相同

/*下面的这个语音结构体EQSound_6G仅在动态区时使用；图文分区播放语音请使用单独的结构体：EQPicAreaSoundHeader_G6;*/
//语音内容
//使用语音功能时：部分卡需要配置串口为语音模式！！！
EQSound_6G stSoundData;

}BXareaHeader_G6,EQareaHeader_G6;


typedef struct
{
Ouint8  SoundPerson;           //发音人，范围0～5，共6种选择
Ouint8  SoundVolum;            //音量，范围0～10
Ouint8  SoundSpeed;            //语速，范围0～10
Ouint8  SoundDataMode;         //语音数据的编码格式
Ouint32 SoundReplayTimes;      //重播次数
Ouint32 SoundReplayDelay;      //重播时间间隔
Ouint8  SoundReservedParaLen;  //语音参数保留参数长度，默认0x03
Ouint8  Soundnumdeal;          //详情见协议
Ouint8  Soundlanguages;        //详情见协议
Ouint8  Soundwordstyle;        //详情见协议
}BXPicAreaSoundHeader_G6,EQPicAreaSoundHeader_G6;//图文分区播放语音

typedef struct
{
Ouint16 BattleStartYear;     //起始年份（BCD格式，下同）
Ouint8  BattleStartMonth;    //起始月份
Ouint8  BattleStartDate;     //起始日期
Ouint8  BattleStartHour;     //起始小时
Ouint8  BattleStartMinute;   //起始分钟
Ouint8  BattleStartSecond;   //起始秒钟
Ouint8  BattleStartWeek;     //起始星期值
Ouint8  StartUpMode;         //启动模式
}BXTimeAreaBattle_G6,EQTimeAreaBattle_G6; //时间分区战斗时间

typedef struct
{
Ouint8   PageStyle;			//数据页类型
Ouint8   DisplayMode;		//显示方式:0x00 –随机显示; 0x01–静止显示; 0x02–快速打出; 0x03–向左移动; ...0x25 –向右移动  0x26 –向右连移  0x27 –向下移动  0x28 –向下连移
Ouint8   ClearMode;			//退出方式/清屏方式
Ouint8   Speed;				//速度等级
Ouint16  StayTime;			//停留时间
Ouint8   RepeatTime;		//重复次数
Ouint16  ValidLen;			//此字段只在左移右移方式下有效
Ouint8   CartoonFrameRate;  //特技为动画方式时，该值代表其帧率
Ouint8   BackNotValidFlag;  //背景无效标志
//字体信息-------------------------------------------------------------------------------------------------------
E_arrMode arrMode;			//排列方式--单行多行
Ouint16  fontSize;			//字体大小
Ouint32  color;				//字体颜色 E_Color_G56此通过此枚举值可以直接配置七彩色，如果大于枚举范围使用RGB888模式
Obool    fontBold;			//是否为粗体
Obool    fontItalic;		//是否为斜体
E_txtDirection tdirection;	//文字方向
Ouint16   txtSpace;			//文字间隔    
Ouint8 Halign; //横向对齐方式（0系统自适应、1左对齐、2居中、3右对齐）
Ouint8 Valign; //纵向对齐方式（0系统自适应、1上对齐、2居中、3下对齐）
//字体信息 结束
}BXpageHeader_G6,EQpageHeader_G6;


typedef struct
{
Ouint8 uAreaId;
EQareaHeader_G6 oAreaHeader_G6;
EQpageHeader_G6 stPageHeader;
Ouint8* fontName;
Ouint8* strAreaTxtContent;     //当调用图片的接口函数时，这个字段中的值为图片的路径文件名；
}DynamicAreaParams;


typedef struct {
Ouint8  fileName[4]; //节目参数文件名
Ouint8  fileType;	 //文件类型
Ouint32 fileLen;	 //参数文件长度
Ouint8* fileAddre;   //文件所在的缓存地址
Ouint8  dfileName[4];//节目数据文件名
Ouint8  dfileType;   //节目数据文件类型
Ouint32 dfileLen;	 //数据文件长度
Ouint8* dfileAddre;  //数据文件缓存地址
}EQprogram_G6;

typedef struct {
Ouint8   fileType;   //要获取的文件类型
Ouint16  fileNumber; //返回有多少个文件
Ouint8*  dataAddre;  //返回文件列表地址
}GetDirBlock_G56;

typedef struct {
Ouint8  fileName[4];  //文件名
Ouint8  fileType;     //文件类型
Ouint32 fileLen;      //文件长度
Ouint32 fileCRC;      //文件CRC校验
}FileAttribute_G56;

typedef struct {
Ouint8*  fileAddre;     //文件地址指針
Ouint32 fileLen;        //文件长度
Ouint16 fileCRC16;      //文件CRC16校验
}FileCRC16_G56;

typedef struct {
Ouint8*  fileAddre;     //文件地址指針
Ouint32 fileLen;        //文件长度
Ouint32 fileCRC32;      //文件CRC32校验
}FileCRC32_G56;

typedef struct {
Ouint32 Color369; //369点颜色
Ouint32 ColorDot; //点颜色
Ouint32 ColorBG;  //表盘外圈颜色 模式没有圈泽此颜色无效
}ClockColor_G56;

typedef struct
{
Ouint8  RunMode;
Ouint16 Timeout;
Ouint8  ImmePlay;
Ouint8  AreaType;
Ouint16 AreaX;
Ouint16 AreaY;
Ouint16 AreaWidth;
Ouint16 AreaHeight;
}BXdynamicHeader,EQdynamicHeader;

typedef struct		//jqb add 20190529
{
Ouint8 AreaId;		//区域序号，从 0 开始
Ouint8 RunMode;		//RunMode			1		0x00	动态区运行模式
//0— 动态区数据循环显示。
//1— 动态区数据显示完成后静止显示最后一页数据。
//2— 动态区数据循环显示，超过设定时间后数据仍未更新时不再显示
//3— 动态区数据循环显示，超过设定

Ouint16 Timeout;	//动态区数据超时时间，单位为秒
Ouint8 RelateAllPro;	//当该字节为 1 时，所有异步节目播放时都允许播放该动态区域；
//为 0 时，由接下来的 RelateProNum 值决定								
Ouint16 RelateProNum;	//RelateProNum 0-N
//动态区域关联了多少个异步节目一旦关联了某个异步节目，则当该异步节目播放时允许播放该动态区域，
//否则，不允许播放该动	态区域以下的节目编号根据RelateProNum的值来确定，当该	值为 0 时不发送;

//vector<Ouint16> vctRelateProSerial;		

Ouint8 ImmePlay;	//ImmePlay		1			是否立即播放
//该字节为 0 时，该动态区域与异步节目一起播放
//该字节为 1 时，异步节目停止播放，仅播放该动态区域
//该字节为 2 时，暂存该动态区域，当播放完节目编号最高的异步节目后播放该动态区域
//注意：当该字节为 0 时，RelateAllPro 到	RelateProSerialN - 1 的参数才有效，否则无效当该参数为 1 或 2 时，由于不与异步节目同时播放，
//为控制该动态区域能及时结束，可选择RunMode 参数为 2 或 4，当然也可通过删除该区域来实现

Ouint32 Reserved;// 4字节 0x00 保留字节
Ouint8  AreaType;
Ouint16 AreaX;
Ouint16 AreaY;
Ouint16 AreaWidth;
Ouint16 AreaHeight;
Ouint8 AreaFFlag;
Ouint16 PageNum;
//Ouint32 PageDataLen;
}Onbon_5E_DynamicHeader;


typedef struct
{
Ouint8 nType; // nType=1:文本； nType=2:图片；

//PageStyle begin---------------
Ouint8 DisplayMode;
Ouint8 ClearMode;
Ouint8 Speed;
Ouint16 StayTime;
Ouint8 RepeatTime;
//PageStyle End.

//文本显示内容和字体格式 begin---------
EQfontData oFont;
Ouint8* fontName;
Ouint8* strAreaTxtContent;
//end.

//图片路径 begin---------
Ouint8* filePath;
//end.

}DynamicAreaBaseInfo_5G, DynamicAreaTxtInfo_5G, DynamicAreaPicInfo_5G;


/*
typedef struct : DynamicAreaBaseInfo_5G
{
//PageStyle begin---------------
//Ouint8 DisplayMode;
//Ouint8 ClearMode;
//Ouint8 Speed;
//Ouint16 StayTime;
//Ouint8 RepeatTime;
//PageStyle End.


//文本显示内容和字体格式 begin---------
EQfontData oFont;
Ouint8* fontName;
Ouint8* strAreaTxtContent;
//end.

}DynamicAreaTxtInfo_5G;



typedef struct : DynamicAreaBaseInfo_5G
{
//PageStyle begin---------------
//Ouint8 DisplayMode;
//Ouint8 ClearMode;
//Ouint8 Speed;
//Ouint16 StayTime;
//Ouint8 RepeatTime;
//PageStyle End.

//图片路径 begin---------
Ouint8* filePath;
//end.

}DynamicAreaPicInfo_5G;
*/
#pragma endregion

//初始化动态链接库
typedef int(__stdcall *PbxDual_InitSdk)();
	PbxDual_InitSdk bxDual_InitSdk;

//释放动态链接库
typedef void(__stdcall *PbxDual_ReleaseSdk)();
	PbxDual_ReleaseSdk bxDual_ReleaseSdk;

/*! ***************************************************************
* 函数名：       cmd_tcpPing（）
* 参数名：ip：控制器IP， port：控制器端口， retData：请参考结构体Ping_data
* 返回值：0 成功， 其他值为错误号
* 功 能：通过TCP方式获取到控制器相关属性和IP地址
* 注：
* 和UDP PING命令获取到的参数相同
******************************************************************/
typedef int(__stdcall *PbxDual_cmd_tcpPing)(Ouint8* ip, Ouint16 port, Ping_data *retData);
	PbxDual_cmd_tcpPing bxDual_cmd_tcpPing;

/*! ***************************************************************
* 函数名：       bxDual_program_setScreenParams_G56（）
* 返回值：0 成功， 其他值为错误号
* 功 能：设置屏相关属性
* 注：
* 三个参数请参考各自枚举值
******************************************************************/
typedef int(__stdcall *PbxDual_program_setScreenParams_G56)(E_ScreenColor_G56 color, Ouint16 ControllerType, E_DoubleColorPixel_G56 doubleColor); //设置屏相关属性
	PbxDual_program_setScreenParams_G56 bxDual_program_setScreenParams_G56;

/*! ***************************************************************
* 函数名：       bxDual_cmd_ofsStartFileTransf（）
* 参数名：ip：控制器IP， port：控制器端口
* 返回值：0 成功， 其他值为错误号
* 功 能：开始批量写文件
* 注：
* 发送节目前调用
******************************************************************/
typedef int(__stdcall *PbxDual_cmd_ofsStartFileTransf)(Ouint8* ip, Ouint16 port);
	PbxDual_cmd_ofsStartFileTransf bxDual_cmd_ofsStartFileTransf;

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
* 注：用于对存储在 OFS 中的文件的处理， 例如： 节目文件， 字库文件、 播放列表文件等
* 内部包含多条命令注意返回状态方便查找问题
******************************************************************/
typedef int(__stdcall *PbxDual_cmd_ofsWriteFile)(Ouint8* ip, Ouint16 port, Ouint8 *fileName, Ouint8 fileType, Ouint32 fileLen, Ouint8 overwrite, Ouint8 *fileAddre);
	PbxDual_cmd_ofsWriteFile bxDual_cmd_ofsWriteFile;

/*! ***************************************************************
* 函数名：       bxDual_cmd_ofsEndFileTransf（）
* 参数名：ip：控制器IP， port：控制器端口
* 返回值：0 成功， 其他值为错误号
* 功 能：写文件结束
* 注：
* 发送节目后调用
******************************************************************/
typedef int(__stdcall *PbxDual_cmd_ofsEndFileTransf)(Ouint8* ip, Ouint16 port);
	PbxDual_cmd_ofsEndFileTransf bxDual_cmd_ofsEndFileTransf;

/*! ***************************************************************
* 函数名：       bxDual_cmd_uart_ofsStartFileTransf（）
* 参数名：uartPort：串口端口号， baudRate：波特率
* 返回值：0 成功， 其他值为错误号
* 功 能：开始批量写文件
* 注：
* 发送节目前调用
******************************************************************/
typedef int(__stdcall *PbxDual_cmd_uart_ofsStartFileTransf)(Oint8* uartPort, Ouint8 baudRate);
	PbxDual_cmd_uart_ofsStartFileTransf bxDual_cmd_uart_ofsStartFileTransf;

/*! ***************************************************************
* 函数名：       bxDual_cmd_uart_ofsEndFileTransf（）
* 参数名：uartPort：串口端口号， baudRate：波特率
* 返回值：0 成功， 其他值为错误号
* 功 能：写文件结束
* 注：
* 发送节目后调用
******************************************************************/
typedef int(__stdcall *PbxDual_cmd_uart_ofsEndFileTransf)(Oint8* uartPort, Ouint8 baudRate);
	PbxDual_cmd_uart_ofsEndFileTransf bxDual_cmd_uart_ofsEndFileTransf;

/**************************************************************BX-6***********************************************************************/

/*! ***************************************************************
* 函数名：       bxDual_program_addProgram_G6(）
* 参数名：
*	EQprogramHeader_G6：参考结构体EQprogramHeader_G6
* 返回值：0 成功， 其他值为错误号
* 功 能：添加节目
* 注：
*
******************************************************************/
typedef int(__stdcall *PbxDual_program_addProgram_G6)(EQprogramHeader_G6 *programH);
	PbxDual_program_addProgram_G6 bxDual_program_addProgram_G6;
	
/*! ***************************************************************
* 函数名：       bxDual_program_addArea_G6（）
* 参数名：areaID：区域的ID号
*	aheader：参考结构体EQareaHeader_G6
*
* 返回值：0 成功， 其他值为错误号
* 功 能：节目添加区域
* 注：
* 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
******************************************************************/
typedef int(__stdcall *PbxDual_program_addArea_G6)(Ouint16 areaID, EQareaHeader_G6 *aheader);
	PbxDual_program_addArea_G6 bxDual_program_addArea_G6;

/*! ***************************************************************
* 函数名：       bxDual_program_pictureAreaAddPic_G6（）
*	areaID：区域的ID号
*   picID：图片编号，从0开始，第一次添加图片为0，第二次添加图片为1，依次累加，每个id对应一张图片
*	EQpageHeader_G6：参考结构体EQpageHeader_G6
*	picPath：图片的绝对路径加图片名称
* 返回值：0 成功， 其他值为错误号
* 功 能：添加图片到图文区域
* 注：下位机播放图片的次序与picID一致，即最先播放picID为0的图片，依次播放
*
******************************************************************/
typedef int(__stdcall *PbxDual_program_pictureAreaAddPic_G6)(Ouint16 areaID, Ouint16 picID, EQpageHeader_G6* pheader, Ouint8* picPath);
	PbxDual_program_pictureAreaAddPic_G6 bxDual_program_pictureAreaAddPic_G6;

/*! ***************************************************************
* 函数名：       bxDual_program_timeAreaAddContent_G6（）
*	areaID：区域的ID号
*   timeData：参考结构体EQtimeAreaData_G56
*
*
* 返回值：0 成功， 其他值为错误
* 功 能：时间分区添加时间等内容，详情请参考结构体EQtimeAreaData_G56
* 注：
*
******************************************************************/
typedef int(__stdcall *PbxDual_program_timeAreaAddContent_G6)(Ouint16 areaID, EQtimeAreaData_G56* timeData);
	PbxDual_program_timeAreaAddContent_G6 bxDual_program_timeAreaAddContent_G6;

/*! ***************************************************************
* 函数名：       bxDual_program_timeAreaAddAnalogClock_G6(）
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
typedef int(__stdcall *PbxDual_program_timeAreaAddAnalogClock_G6)(Ouint16 areaID, EQAnalogClockHeader_G56 *header, E_ClockStyle cStyle, ClockColor_G56* cColor);
	PbxDual_program_timeAreaAddAnalogClock_G6 bxDual_program_timeAreaAddAnalogClock_G6;

/*! ***************************************************************
* 函数名：       bxDual_program_picturesAreaAddTxt_G6（）
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
typedef int(__stdcall *PbxDual_program_picturesAreaAddTxt_G6)(Ouint16 areaID, Ouint8* str, Ouint8* fontName, EQpageHeader_G6* pheader);
	PbxDual_program_picturesAreaAddTxt_G6 bxDual_program_picturesAreaAddTxt_G6;

/*! ***************************************************************
* 函数名：       bxDual_program_IntegrateProgramFile_G6（）
* 参数名：
*	program：参考结构体EQprogram_G6
* 返回值：0 成功， 其他值为错误号
* 功 能：合成节目文件返回节目文件属性及地址
* 注：
* EQprogram 结构体是用来回调发送文件所需要参数
******************************************************************/
typedef int(__stdcall *PbxDual_program_IntegrateProgramFile_G6)(EQprogram_G6* program);
	PbxDual_program_IntegrateProgramFile_G6 bxDual_program_IntegrateProgramFile_G6;

/*! ***************************************************************
* 函数名：       bxDual_program_deleteProgram_G6（）
* 返回值：0 成功， 其他值为错误
* 功 能：删除节目
* 注：
*
******************************************************************/
typedef int(__stdcall *PbxDual_program_deleteProgram_G6)();
	PbxDual_program_deleteProgram_G6 bxDual_program_deleteProgram_G6;

//同时更新多个动态区:仅显示动态区，不显示节目
typedef int(__stdcall *PbxDual_dynamicAreaS_AddTxtDetails_6G)(Ouint8* pIP, Ouint32 nPort, E_ScreenColor_G56 color, Ouint8 uAreaCount, DynamicAreaParams* pParams);
	PbxDual_dynamicAreaS_AddTxtDetails_6G bxDual_dynamicAreaS_AddTxtDetails_6G;

//同时更新多个动态区:并与节目关联，即与节目一起显示
//RelateProNum = 0 时，关联所有节目，与所有节目一起播放，如果没有节目，则不播放该动态区；
//			   > 0 时, 指定关联节目，要关联的节目ID存放在RelateProSerial[]中；
typedef int(__stdcall *PbxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G)(Ouint8* pIP, Ouint32 nPort, E_ScreenColor_G56 color, Ouint8 uAreaCount, DynamicAreaParams* pParams, Ouint16 RelateProNum, Ouint16* RelateProSerial);
	PbxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G bxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G;

//更新动态区图片：仅显示动态区;
typedef int(__stdcall *PbxDual_dynamicAreaS_AddAreaPic_6G)(Ouint8* pIP, Ouint32 nPort, E_ScreenColor_G56 color, Ouint8 uAreaCount, DynamicAreaParams* pParams);
	PbxDual_dynamicAreaS_AddAreaPic_6G bxDual_dynamicAreaS_AddAreaPic_6G;

//动态区图片关联节目: 
//RelateProNum = 0 时，关联所有节目，与所有节目一起播放，如果没有节目，则不播放该动态区；
//			   > 0 时, 指定关联节目，要关联的节目ID存放在RelateProSerial[]中；
typedef int(__stdcall *PbxDual_dynamicAreaS_AddAreaPic_WithProgram_6G)(Ouint8* pIP, Ouint32 nPort, E_ScreenColor_G56 color, Ouint8 uAreaCount, DynamicAreaParams* pParams, Ouint16 RelateProNum, Ouint16* RelateProSerial);
	PbxDual_dynamicAreaS_AddAreaPic_WithProgram_6G bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G;

/*
删除动态区：删除单个动态区：
uAreaId = 0xff:删除所有区域
*/
typedef int(__stdcall *PbxDual_dynamicArea_DelArea_6G)(Ouint8* pIP, Ouint32 nPort, Oint8 uAreaId);
	PbxDual_dynamicArea_DelArea_6G bxDual_dynamicArea_DelArea_6G;
/*
功能：删除多个动态区：
参数：
pAreaID-存放要删除的动态区ID数组；
uAreaCount-动态区ID数组中的个数；
*/
typedef int(__stdcall *PbxDual_dynamicArea_DelAreas_6G)(Ouint8* pIP, Ouint32 nPort, Oint8 uAreaCount, Oint8* pAreaID);
	PbxDual_dynamicArea_DelAreas_6G bxDual_dynamicArea_DelAreas_6G;

	/***********************************************************BX-5**********************************************************/

/*! ***************************************************************
* 函数名：       bxDual_program_addProgram（）
*	programH：参考结构体EQprogramHeader
* 返回值：0 成功， 其他值为错误
* 功 能：添加节目句柄
* 注：
* 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
******************************************************************/
typedef int(__stdcall *PbxDual_program_addProgram)(EQprogramHeader *programH); //添加节目句柄
	PbxDual_program_addProgram bxDual_program_addProgram;

/*! ***************************************************************
* 函数名：       bxDual_program_addArea_G6（）
* 参数名：areaID：区域的ID号
*	aheader：参考结构体EQareaHeader_G6
*
* 返回值：0 成功， 其他值为错误号
* 功 能：节目添加区域
* 注：
* 一定要参考协议对每一个值都不能理解出错否则发下去的内容显示肯定不是自己想要的
******************************************************************/
typedef int(__stdcall *PbxDual_program_AddArea)(Ouint16 areaID, EQareaHeader *aheader);
	PbxDual_program_AddArea bxDual_program_AddArea;
	
/*! ***************************************************************
* 函数名：       bxDual_program_picturesAreaAddTxt（）
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
typedef int(__stdcall *PbxDual_program_picturesAreaAddTxt)(Ouint16 areaID, Ouint8* str, Ouint8* fontName, EQpageHeader* pheader);//画字符到区域
	PbxDual_program_picturesAreaAddTxt bxDual_program_picturesAreaAddTxt;
	
/*! ***************************************************************
* 函数名：       bxDual_program_pictureAreaAddPic_G6（）
*	areaID：区域的ID号
*   picID：图片编号，从0开始，第一次添加图片为0，第二次添加图片为1，依次累加，每个id对应一张图片
*	EQpageHeader_G6：参考结构体EQpageHeader_G6
*	picPath：图片的绝对路径加图片名称
* 返回值：0 成功， 其他值为错误号
* 功 能：添加图片到图文区域
* 注：下位机播放图片的次序与picID一致，即最先播放picID为0的图片，依次播放
*
******************************************************************/
typedef int(__stdcall *PbxDual_program_pictureAreaAddPic)(Ouint16 areaID, Ouint16 picID, EQpageHeader* pheader, Ouint8* picPath);
	PbxDual_program_pictureAreaAddPic bxDual_program_pictureAreaAddPic;

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
typedef int(__stdcall *PbxDual_program_timeAreaAddContent)(Ouint16 areaID, EQtimeAreaData_G56* timeData);
	PbxDual_program_timeAreaAddContent bxDual_program_timeAreaAddContent;

/*! ***************************************************************
* 函数名：       bxDual_program_timeAreaAddAnalogClock_G6(）
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
typedef int(__stdcall *PbxDual_program_timeAreaAddAnalogClock)(Ouint16 areaID, EQAnalogClockHeader_G56 *header, E_ClockStyle cStyle, ClockColor_G56* cColor);
	PbxDual_program_timeAreaAddAnalogClock bxDual_program_timeAreaAddAnalogClock;

/*! ***************************************************************
* 函数名：       bxDual_program_IntegrateProgramFile_G6（）
* 参数名：
*	program：参考结构体EQprogram_G6
* 返回值：0 成功， 其他值为错误号
* 功 能：合成节目文件返回节目文件属性及地址
* 注：
* EQprogram 结构体是用来回调发送文件所需要参数
******************************************************************/
typedef int(__stdcall *PbxDual_program_IntegrateProgramFile)(EQprogram* program);
	PbxDual_program_IntegrateProgramFile bxDual_program_IntegrateProgramFile;

/*! ***************************************************************
* 函数名：       bxDual_program_deleteProgram（）
* 返回值：0 成功， 其他值为错误
* 功 能：删除节目
* 注：
*
******************************************************************/
typedef int(__stdcall *PbxDual_program_deleteProgram)();
	PbxDual_program_deleteProgram bxDual_program_deleteProgram;
/*
功能说明：增加一条文件信息到指定的动态区，并可以关联这个动态区到指定的节目；其它参考信息参见 上面的 6代控制卡动态区功能 函数 bxDual_dynamicArea_AddAreaTxt_6G 上面的说明；
参数说明：
strAreaTxtContent - 动态区域内要显示的文本内容
*/
typedef int(__stdcall *PbxDual_dynamicArea_AddAreaWithTxt_5G)(Ouint8* pIP, Ouint32 nPort, E_ScreenColor_G56 color,Ouint8 uAreaId,Ouint8 RunMode,Ouint16 Timeout,Ouint8 RelateAllPro,Ouint16 RelateProNum,
	Ouint16* RelateProSerial,Ouint8 ImmePlay,Ouint16 uAreaX, Ouint16 uAreaY, Ouint16 uWidth, Ouint16 uHeight,EQareaframeHeader oFrame,Ouint8 DisplayMode,Ouint8 ClearMode,Ouint8 Speed,Ouint16 StayTime,
	Ouint8 RepeatTime,EQfontData oFont,Ouint8* fontName,Ouint8* strAreaTxtContent);
PbxDual_dynamicArea_AddAreaWithTxt_5G bxDual_dynamicArea_AddAreaWithTxt_5G;

/*
功能说明：增加一个图片到指定的动态区，并可以关联这个动态区到指定的节目；
*/
typedef int(__stdcall *PbxDual_dynamicArea_AddAreaWithPic_5G)(Ouint8* pIP, Ouint32 nPort, E_ScreenColor_G56 color,Ouint8 uAreaId,Ouint8 RunMode,Ouint16 Timeout,Ouint8 RelateAllPro,Ouint16 RelateProNum,
	Ouint16* RelateProSerial,Ouint8 ImmePlay,Ouint16 uAreaX, Ouint16 uAreaY, Ouint16 uWidth, Ouint16 uHeight,EQareaframeHeader oFrame,Ouint8 DisplayMode,Ouint8 ClearMode,Ouint8 Speed,Ouint16 StayTime,
	Ouint8 RepeatTime,Ouint8* filePath);
	PbxDual_dynamicArea_AddAreaWithPic_5G bxDual_dynamicArea_AddAreaWithPic_5G;


void addProgram_G5();
void addArea_G5(Ouint16 AreaID,Ouint8 AreaType,Ouint8 AreaX,Ouint8 AreaY,Ouint8 AreaWidth,Ouint8 AreaHeight);
void addAreaTime_G5(Ouint16 AreaID);
void addAreaPicture_G5(Ouint16 AreaID,Ouint8 str[]);
void tcp_send_program_G5(Ouint8* ip, Ouint16 port);
void addAreaPicturePic_G5(Ouint16 areaID);

void addProgram_G6();
void addArea_G6(Ouint16 AreaID,Ouint8 AreaType,Ouint8 AreaX,Ouint8 AreaY,Ouint8 AreaWidth,Ouint8 AreaHeight);
void addAreaTime_G6(Ouint16 AreaID);
void addAreaPicture_G6(Ouint16 AreaID,Ouint8 str[]);
void tcp_send_program_G6(Ouint8* ip, Ouint16 port);
static void Creat_sound_6(Ouint16 areaID);
void addAreaPicturePic_G6(Ouint16 areaID);
void dynamicArea_test_6(Ouint8* ip);
void onbonTest_DynamicArea_6G(void);
int main(int argc, char* argv[])
{
	HINSTANCE hdll = LoadLibrary(L"bx_sdk_dual.dll");
	if(hdll==NULL)
	  {
		  cout<<"NULL";
	  }
	bxDual_InitSdk = (PbxDual_InitSdk)GetProcAddress(hdll,"bxDual_InitSdk");
	bxDual_ReleaseSdk = (PbxDual_ReleaseSdk)GetProcAddress(hdll,"bxDual_ReleaseSdk");
	bxDual_program_setScreenParams_G56 = (PbxDual_program_setScreenParams_G56)GetProcAddress(hdll,"bxDual_program_setScreenParams_G56");
	bxDual_cmd_tcpPing = (PbxDual_cmd_tcpPing)GetProcAddress(hdll,"bxDual_cmd_tcpPing");
	bxDual_cmd_ofsStartFileTransf = (PbxDual_cmd_ofsStartFileTransf)GetProcAddress(hdll,"bxDual_cmd_ofsStartFileTransf");
	bxDual_cmd_ofsWriteFile = (PbxDual_cmd_ofsWriteFile)GetProcAddress(hdll,"bxDual_cmd_ofsWriteFile");
	bxDual_cmd_ofsEndFileTransf = (PbxDual_cmd_ofsEndFileTransf)GetProcAddress(hdll,"bxDual_cmd_ofsEndFileTransf");
	bxDual_program_deleteProgram = (PbxDual_program_deleteProgram)GetProcAddress(hdll,"bxDual_program_deleteProgram");
	bxDual_cmd_uart_ofsStartFileTransf = (PbxDual_cmd_uart_ofsStartFileTransf)GetProcAddress(hdll,"bxDual_cmd_uart_ofsStartFileTransf");
	bxDual_cmd_uart_ofsEndFileTransf = (PbxDual_cmd_uart_ofsEndFileTransf)GetProcAddress(hdll,"bxDual_cmd_uart_ofsEndFileTransf");

	bxDual_dynamicAreaS_AddTxtDetails_6G = (PbxDual_dynamicAreaS_AddTxtDetails_6G)GetProcAddress(hdll,"bxDual_dynamicAreaS_AddTxtDetails_6G");
	bxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G = (PbxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G)GetProcAddress(hdll,"bxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G");
	bxDual_dynamicAreaS_AddAreaPic_6G = (PbxDual_dynamicAreaS_AddAreaPic_6G)GetProcAddress(hdll,"bxDual_dynamicAreaS_AddAreaPic_6G");
	bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G = (PbxDual_dynamicAreaS_AddAreaPic_WithProgram_6G)GetProcAddress(hdll,"bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G");
	bxDual_dynamicArea_DelArea_6G = (PbxDual_dynamicArea_DelArea_6G)GetProcAddress(hdll,"bxDual_dynamicArea_DelArea_6G");
	bxDual_dynamicArea_DelAreas_6G = (PbxDual_dynamicArea_DelAreas_6G)GetProcAddress(hdll,"bxDual_dynamicArea_DelAreas_6G");
	bxDual_program_IntegrateProgramFile_G6 = (PbxDual_program_IntegrateProgramFile_G6)GetProcAddress(hdll,"bxDual_program_IntegrateProgramFile_G6");
	bxDual_program_deleteProgram_G6 = (PbxDual_program_deleteProgram_G6)GetProcAddress(hdll,"bxDual_program_deleteProgram_G6");
	bxDual_program_addArea_G6 = (PbxDual_program_addArea_G6)GetProcAddress(hdll,"bxDual_program_addArea_G6");
	bxDual_program_pictureAreaAddPic_G6 = (PbxDual_program_pictureAreaAddPic_G6)GetProcAddress(hdll,"bxDual_program_pictureAreaAddPic_G6");
	bxDual_program_picturesAreaAddTxt_G6  = (PbxDual_program_picturesAreaAddTxt_G6)GetProcAddress(hdll,"bxDual_program_picturesAreaAddTxt_G6");
	bxDual_program_timeAreaAddContent_G6 = (PbxDual_program_timeAreaAddContent_G6)GetProcAddress(hdll,"bxDual_program_timeAreaAddContent_G6");
	bxDual_program_timeAreaAddAnalogClock_G6 = (PbxDual_program_timeAreaAddAnalogClock_G6)GetProcAddress(hdll,"bxDual_program_timeAreaAddAnalogClock_G6");

	bxDual_program_addProgram = (PbxDual_program_addProgram)GetProcAddress(hdll,"bxDual_program_addProgram");
	bxDual_program_AddArea = (PbxDual_program_AddArea)GetProcAddress(hdll,"bxDual_program_AddArea");
	bxDual_program_picturesAreaAddTxt = (PbxDual_program_picturesAreaAddTxt)GetProcAddress(hdll,"bxDual_program_picturesAreaAddTxt");
	bxDual_program_pictureAreaAddPic = (PbxDual_program_pictureAreaAddPic)GetProcAddress(hdll,"bxDual_program_pictureAreaAddPic");
	bxDual_program_timeAreaAddContent = (PbxDual_program_timeAreaAddContent)GetProcAddress(hdll,"bxDual_program_timeAreaAddContent");
	bxDual_program_timeAreaAddAnalogClock = (PbxDual_program_timeAreaAddAnalogClock)GetProcAddress(hdll,"bxDual_program_timeAreaAddAnalogClock");
	bxDual_dynamicArea_AddAreaWithTxt_5G = (PbxDual_dynamicArea_AddAreaWithTxt_5G)GetProcAddress(hdll,"bxDual_dynamicArea_AddAreaWithTxt_5G");
	bxDual_dynamicArea_AddAreaWithPic_5G = (PbxDual_dynamicArea_AddAreaWithPic_5G)GetProcAddress(hdll,"bxDual_dynamicArea_AddAreaWithPic_5G");
	bxDual_program_IntegrateProgramFile = (PbxDual_program_IntegrateProgramFile)GetProcAddress(hdll,"bxDual_program_IntegrateProgramFile");

	
	unsigned char ip[] = "192.168.89.182";
	unsigned short port = 5005;
	int ret = 0;
	ret = bxDual_InitSdk();//初始化动态库
	Ouint16 c_type = 0;
	Ping_data retdata;
	ret = bxDual_cmd_tcpPing(ip, port, &retdata);
	if(ret != 0){
		printf("cmd_tcpPing run error...");
	}else{
		printf("cmd_tcpPing run succeed...");
		//memset((void*)ip, 0, sizeof(ip));
		//memcpy((void*)ip, (void*)retdata.ipAdder, strlen((char*)retdata.ipAdder));
		printf("retdata.ipAdder =====%s \n", ip);
		printf("retdata.ControllerType == 0x%x \n", retdata.ControllerType);
		c_type = retdata.ControllerType;
	}
	printf("ret =====cmd_tcpPing===== %d \n", ret);
    BYTE cmb_ping_Color = 1;
    if (retdata.Color == 1) { cmb_ping_Color = 1; }
    else if (retdata.Color == 3) { cmb_ping_Color = 2; }
    else if (retdata.Color == 7) { cmb_ping_Color = 3; }
    else { cmb_ping_Color = 4; }
	
    ret = bxDual_program_setScreenParams_G56((E_ScreenColor_G56)cmb_ping_Color, retdata.ControllerType, eDOUBLE_COLOR_PIXTYPE_1);

	dynamicArea_test_6(ip);
}


//添加节目
void addProgram_G5()
{
	EQprogramHeader header;
	header.FileType=0x00;
	header.ProgramID = 0;
	header.ProgramStyle=0x00;
	header.ProgramPriority=0x00;
	header.ProgramPlayTimes=1;
	header.ProgramTimeSpan=0;
	header.ProgramWeek=0xff;
	header.ProgramLifeSpan_sy=0xffff;
	header.ProgramLifeSpan_sm=0x03;
	header.ProgramLifeSpan_sd=0x05;
	header.ProgramLifeSpan_ey=0xffff;
	header.ProgramLifeSpan_em=0x04;
	header.ProgramLifeSpan_ed=0x12;
	bxDual_program_addProgram(&header);
}
void addProgram_G6()
{
	EQprogramHeader_G6 pHeader;
	pHeader.FileType = 0x00;
	pHeader.ProgramID = 0;
	pHeader.ProgramStyle=0x00;
	pHeader.ProgramPriority=0x00;
	pHeader.ProgramPlayTimes=1;
	pHeader.ProgramTimeSpan=0;
	pHeader.SpecialFlag = 0;
	pHeader.CommExtendParaLen = 0x00;
	pHeader.ScheduNum = 0;
	pHeader.LoopValue = 0;
	pHeader.Intergrate = 0x00;
	pHeader.TimeAttributeNum = 0x00;
	pHeader.TimeAttribute0Offset = 0x0000;
	pHeader.ProgramWeek=0xff;
	pHeader.ProgramLifeSpan_sy=0xffff;
	pHeader.ProgramLifeSpan_sm=0x03;
	pHeader.ProgramLifeSpan_sd=0x14;
	pHeader.ProgramLifeSpan_ey=0xffff;
	pHeader.ProgramLifeSpan_em=0x03;
	pHeader.ProgramLifeSpan_ed=0x14;
	//pHeader.PlayPeriodGrpNum=0;

	bxDual_program_addProgram_G6(&pHeader);
}
//添加区域
void addArea_G5(Ouint16 AreaID,Ouint8 AreaType,Ouint8 AreaX,Ouint8 AreaY,Ouint8 AreaWidth,Ouint8 AreaHeight)
{
	Ouint16 nAreaID = AreaID;
	EQareaHeader aheader;
	aheader.AreaType = AreaType;
	aheader.AreaX = AreaX;
	aheader.AreaY = AreaY;
	aheader.AreaWidth = AreaWidth;
	aheader.AreaHeight = AreaHeight;
	bxDual_program_AddArea(nAreaID, &aheader); 
}
void addArea_G6(Ouint16 AreaID,Ouint8 AreaType,Ouint8 AreaX,Ouint8 AreaY,Ouint8 AreaWidth,Ouint8 AreaHeight)
{
	Ouint16 nAreaID = AreaID;
	EQareaHeader_G6 aHeader1;
	aHeader1.AreaType = AreaType;
	aHeader1.AreaX = AreaX;
	aHeader1.AreaY = AreaY;
	aHeader1.AreaWidth = AreaWidth;
	aHeader1.AreaHeight = AreaHeight;
	aHeader1.BackGroundFlag = 0x00;
	aHeader1.Transparency = 101;
	aHeader1.AreaEqual = 0x00;
	bxDual_program_addArea_G6(nAreaID,&aHeader1);
}
//添加时间内容
void addAreaTime_G5(Ouint16 AreaID)
{
	EQtimeAreaData_G56 timeData2;
	timeData2.linestyle = eMULTILINE;
	timeData2.color = eRED;
	timeData2.fontName = (Ouint8*)malloc(40);
	strcpy((Oint8*)timeData2.fontName,"./allfonts/1.ttf");
	timeData2.fontSize = 9;
	timeData2.fontBold = 0;
	timeData2.fontItalic = 0;
	timeData2.fontUnderline = 0;
	timeData2.fontAlign = 1;  //0--左对齐，1-居中，2-右对齐
	timeData2.date_enable = true;
	timeData2.datestyle = (E_DateStyle)eYYYY_MM_DD_MINUS;
	timeData2.time_enable = true;
	timeData2.timestyle = (E_TimeStyle)eHH_MM_SS_COLON;
	timeData2.week_enable = true;
	timeData2.weekstyle = (E_WeekStyle)eMonday_CHS;
	bxDual_program_timeAreaAddContent(AreaID,&timeData2);
}
void addAreaTime_G6(Ouint16 AreaID)
{
	EQtimeAreaData_G56 timeData;
	timeData.linestyle = eMULTILINE;
	timeData.color = eGREEN;
	timeData.fontName = (Ouint8*)malloc(sizeof(Ouint8)*40);
	strcpy((Oint8*)timeData.fontName,"黑体");
	timeData.fontSize = 12;
	timeData.fontBold = 0;
	timeData.fontItalic = 0;
	timeData.fontUnderline = 0;
	timeData.fontAlign = 1;  //0--左对齐，1-居中，2-右对齐
	timeData.date_enable = true;
	timeData.datestyle = (E_DateStyle)eYYYY_MM_DD_CHS;//eMM_DD_CHS;// //eYYYY_MM_DD_VIRGURE;// 
	timeData.week_enable = false;
	timeData.weekstyle = (E_WeekStyle)eMonday_CHS;
	timeData.time_enable = true;
	timeData.timestyle = (E_TimeStyle)eHH_MM_SS_COLON;
	bxDual_program_timeAreaAddContent_G6(AreaID,&timeData);
}
//添加文本
void addAreaPicture_G5(Ouint16 AreaID,Ouint8 str[])
{;
	EQpageHeader pheader;
	pheader.PageStyle = 0x00;
	pheader.DisplayMode = 0x03;
	pheader.ClearMode = 0x01;
	pheader.Speed = 32;
	pheader.StayTime = 0;
	pheader.RepeatTime = 1;
	pheader.ValidLen = 0;
	pheader.arrMode = eSINGLELINE;
	pheader.fontSize = 10;
	pheader.color = eYELLOW;
	pheader.fontBold = false;
	pheader.fontItalic = false;
	pheader.tdirection = pNORMAL;
	pheader.txtSpace = 0; 
	bxDual_program_picturesAreaAddTxt(0, str,(Ouint8*)"宋体",&pheader);
}
void addAreaPicture_G6(Ouint16 AreaID,Ouint8 str[])
{
	Ouint8* str1 =(Ouint8*)"4545\n5656";
	EQpageHeader_G6 pheader1;
	pheader1.PageStyle = 0x00;
	pheader1.DisplayMode = 0x4;
	pheader1.ClearMode = 0x01;
	pheader1.Speed = 1;
	pheader1.StayTime = 0;
	pheader1.RepeatTime = 1;
	pheader1.ValidLen = 1;
	pheader1.CartoonFrameRate = 0x00;
	pheader1.BackNotValidFlag = 0x00;
	pheader1.arrMode = eSINGLELINE; //eMULTILINE;// 
	pheader1.fontSize = 10;
	pheader1.color = E_Color_G56::eRED;   // E_Color_G56
	pheader1.fontBold = false;
	pheader1.fontItalic = false;
	pheader1.tdirection = pNORMAL;
	pheader1.txtSpace = 0;
	pheader1.Valign = 0;
	pheader1.Halign = 0;
	
	bxDual_program_picturesAreaAddTxt_G6(AreaID,str1,(Ouint8*)"宋体",&pheader1);
	//program_fontPath_picturesAreaAddTxt_G6(0,str,(Ouint8*)"C:/Windows/Fonts/simsun.ttc",&pheader1);
}
//添加图片
void addAreaPicturePic_G5(Ouint16 areaID)
{
    EQpageHeader pheader;
    pheader.PageStyle = 0x00;
    pheader.DisplayMode = 0x01;
    pheader.ClearMode = 0x01;
    pheader.Speed = 30;
    pheader.StayTime = 0;
    pheader.RepeatTime = 1;
    pheader.ValidLen = 0;
    pheader.arrMode = E_arrMode::eSINGLELINE;
    pheader.fontSize = 12;
    pheader.color = E_Color_G56::eRED;
    pheader.fontBold = false;
    pheader.fontItalic = false;
    pheader.tdirection = E_txtDirection::pNORMAL;
    pheader.txtSpace = 0;
    pheader.Valign = 2;
    pheader.Halign = 2;
    Ouint8 str1[] = "32.png";
    int err = bxDual_program_pictureAreaAddPic(areaID, 0, &pheader, str1);
}
void addAreaPicturePic_G6(Ouint16 areaID)
{
    EQpageHeader_G6 pheader;
    pheader.PageStyle = 0x00;
    pheader.DisplayMode = 0x03;
    pheader.ClearMode = 0x01;
    pheader.Speed = 15;
    pheader.StayTime = 500;
    pheader.RepeatTime = 1;
    pheader.ValidLen = 0;
    pheader.CartoonFrameRate = 0x00;
    pheader.BackNotValidFlag = 0x00;
    pheader.arrMode = E_arrMode::eSINGLELINE;
    pheader.fontSize = 10;
    pheader.color = E_Color_G56::eRED;
    pheader.fontBold = 0;
    pheader.fontItalic = 0;
    pheader.tdirection = E_txtDirection::pNORMAL;
    pheader.txtSpace = 0;
    pheader.Valign = 2;
    pheader.Halign = 2;
    Ouint8* img = (Ouint8*)"K:/onbon/图片测试文件/3232c.png";
    int err = bxDual_program_pictureAreaAddPic_G6(areaID, 0, &pheader, img);
}
//发送节目
void tcp_send_program_G5(Ouint8* ip, Ouint16 port)
{
	Oint8 ret;
	ret = bxDual_cmd_ofsStartFileTransf(ip, port);
	printf("tcp_send_program_G5L:cmd_ofsStartFileTransf===== %d \n", ret);
	if(ret != 0){
		printf("cmd_ofsStartFileTransf run error...");
	}else{
		printf("cmd_ofsStartFileTransf run succeed...");
	}

	EQprogram program;
	memset((void*)&program, 0, sizeof(program));
	bxDual_program_IntegrateProgramFile(&program);

	ret = bxDual_cmd_ofsWriteFile(ip, port, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
	if(ret != 0){
		printf("cmd_ofsWriteFile run error...");
	}else{
		printf("cmd_ofsWriteFile run succeed...");
	}
	printf("tcp_send_program_G5:cmd_ofsWriteFile===== %d \n", ret);
	printf("fileName_G5 == %s \n", program.fileName);
	printf("fileType_G5 == %d \n", program.fileType);
	printf("fileLen_G5 == %d \n", program.fileLen);
	printf("fileCRC32_G5 == %d \n",program.fileCRC32);
	ret = bxDual_cmd_ofsEndFileTransf(ip, port);
	if(ret != 0){
		printf("cmd_ofsEndFileTransf run error...");
	}else{
		printf("cmd_ofsEndFileTransf run succeed...");
	}
	printf("tcp_send_program_G5:md_ofsWriteFile===== %d \n", ret);
	
}
void tcp_send_program_G6(Ouint8* ip, Ouint16 port)
{
	Oint8 ret;
	EQprogram_G6 program;
	memset((void*)&program, 0, sizeof(program));
	bxDual_program_IntegrateProgramFile_G6(&program);
	
	ret = bxDual_cmd_ofsStartFileTransf(ip, port);
	printf("ret =====cmd_ofsStartFileTransf===== %d \n", ret);
	if(ret != 0){
		printf("cmd_ofsStartFileTransf run error...");
	}else{
		printf("cmd_ofsStartFileTransf run succeed...");
	}

	ret = bxDual_cmd_ofsWriteFile(ip, port, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
	if(ret != 0){
		printf("cmd_ofsWriteFile run error...");
	}else{
		printf("cmd_ofsWriteFile run succeed...");
	}
	printf("ret =====cmd_ofsWriteFile===== %d \n", ret);

	ret = bxDual_cmd_ofsWriteFile(ip, port, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
	if(ret != 0){
		printf("cmd_ofsWriteFile run error...");
	}else{
		printf("cmd_ofsWriteFile run succeed...");
	}
	printf("ret =====cmd_ofsWriteFile===== %d \n", ret);

	ret = bxDual_cmd_ofsEndFileTransf(ip, port);
	if(ret != 0){
		printf("cmd_ofsEndFileTransf run error...");
	}else{
		printf("cmd_ofsEndFileTransf run succeed...");
	}
	printf("ret =====cmd_ofsEndFileTransf===== %d \n", ret);

	//删除本地内存中的节目
	bxDual_program_deleteProgram_G6();

}

//BX-6动态区文本
void dynamicArea_test_6(Ouint8* ip)
{
	EQareaHeader_G6 oAreaHeader_G6;
	oAreaHeader_G6.AreaType = 0x10; //0x10 动态区域

	oAreaHeader_G6.AreaX = 0;
	oAreaHeader_G6.AreaY = 0;
	oAreaHeader_G6.AreaWidth = 32;	
	oAreaHeader_G6.AreaHeight = 32;	
	//AreaFrame N 区域边框属性，详细参考
	oAreaHeader_G6.BackGroundFlag = 0x00;
	oAreaHeader_G6.Transparency = 101;
	oAreaHeader_G6.AreaEqual = 0x00;

	Ouint8* strSoundTxt = (Ouint8*)"仰邦。";
	Ouint8 nSize = sizeof(strSoundTxt);
	Ouint8 nStrLen = strlen((const char*)strSoundTxt);
	oAreaHeader_G6.stSoundData.SoundDataLen = nStrLen;		// 4 语音数据长度; 只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送
	oAreaHeader_G6.stSoundData.SoundData = strSoundTxt;			// N 语音数据只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送

	{
		oAreaHeader_G6.stSoundData.SoundFlag = 0x00;	//1 0x00 是否使能语音播放;0 表示不使能语音; 1 表示播放下文中;
		oAreaHeader_G6.stSoundData.SoundPerson = 0x01;	//1 0x00 发音人 该值范围是 0 - 5，共 6 种选择只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 0
		oAreaHeader_G6.stSoundData.SoundVolum = 1;		//1 0x05 音量该值范围是 0~10，共 11 种，0表示静音只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 5
		oAreaHeader_G6.stSoundData.SoundSpeed = 0x2;	//1 0x05 语速该值范围是 0~10，共 11 种只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 5
		oAreaHeader_G6.stSoundData.SoundDataMode = 0x00;//1 0x00 SoundData 的编码格式：该值意义如下：0x00 GB2312; 0x01 GBK; 0x02 BIG5; 0x03 UNICODE只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送
		oAreaHeader_G6.stSoundData.SoundReplayTimes = 0x01;// 0xffffffff;	//4 0x00000000 重播次数该值为 0，表示播放 1 次该值为 1，表示播放 2 次
		//......
		//该值为 0xffffffff，表示播放无限次只有 SoundFlag（是否使能语播放）为 1 时才发送该字节，否则不发送该值默认为 0
		oAreaHeader_G6.stSoundData.SoundReplayDelay = 200;	//4 0x00000000 重播时间间隔该值表示两次播放语音的时间间隔，单位为 10ms只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 0
		oAreaHeader_G6.stSoundData.SoundReservedParaLen = 0x03;//1 0x03 语音参数保留参数长度
		oAreaHeader_G6.stSoundData.Soundnumdeal = 0x00;		//1 0 0：自动判断1：数字作号码处理 2：数字作数值处理只有当 SoundFlag 为 1 且SoundReservedParaLen不为 0才发送此参数
		oAreaHeader_G6.stSoundData.Soundlanguages = 0x00;		// 1 0 0：自动判断语种1：阿拉伯数字、度量单位、特殊符号等合成为中文2：阿拉伯数字、度量单位、特殊符号等合成为英文只有当 SoundFlag 为 1 且 SoundReservedParaLen不为 0才发送此参数（目前只支持中英文）
		oAreaHeader_G6.stSoundData.Soundwordstyle = 0x00;		// 1 0 0：自动判断发音方式1：字母发音方式2：单词发音方式只有当 SoundFlag 为 1 且SoundReservedParaLen不为 0才发送此参数
		oAreaHeader_G6.stSoundData.SoundDataLen = nStrLen;		// 4 语音数据长度; 只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送
		oAreaHeader_G6.stSoundData.SoundData = strSoundTxt;			// N 语音数据只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送

	}

	EQpageHeader_G6 stPageHeader;
	stPageHeader.PageStyle = 0x00;
	stPageHeader.DisplayMode = 0x04;
	stPageHeader.ClearMode = 0x00;
	stPageHeader.Speed = 5;
	stPageHeader.StayTime = 0;
	stPageHeader.RepeatTime = 1;
	stPageHeader.ValidLen = oAreaHeader_G6.AreaWidth;
	stPageHeader.CartoonFrameRate = 0x00;
	stPageHeader.BackNotValidFlag = 0x00;
	stPageHeader.arrMode = eSINGLELINE; //eMULTILINE;//
	stPageHeader.fontSize = 10;
	stPageHeader.color = eRED;
	stPageHeader.fontBold = false;
	stPageHeader.fontItalic = false;
	stPageHeader.tdirection = pNORMAL;
	stPageHeader.txtSpace = 0;
	stPageHeader.Valign = 1;
	stPageHeader.Halign = 1;

	Ouint16 nAreaID = 0;
	Ouint16 uRelateProgID[1];  uRelateProgID[0] = 0; 
	int err=0;
		DynamicAreaParams oAreaParams_1;
		oAreaParams_1.uAreaId = 0;
		oAreaParams_1.oAreaHeader_G6 = oAreaHeader_G6;
		oAreaParams_1.stPageHeader = stPageHeader;
		oAreaParams_1.strAreaTxtContent = (Ouint8*)"一起来到第3个动态区看看吧abcdefghijklmnopqrst......"; //(Ouint8*)"1中华人民共和国欢迎您。";
		oAreaParams_1.fontName = (Ouint8*)"宋体";
		DynamicAreaParams arrParams[1];
		arrParams[0] = oAreaParams_1;
	err = bxDual_dynamicAreaS_AddTxtDetails_6G(ip, 5005, eSCREEN_COLOR_FULLCOLOR, 1, arrParams);
	printf("err =====dynamicArea_AddAreaTxtDetails_WithProgram_6G===== %d \n", err);
}
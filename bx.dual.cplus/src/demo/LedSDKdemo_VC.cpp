#include <iostream>
#include"iostream"
#include "windows.h"
#include "Obasic_types.h"
using namespace std;

#pragma region
typedef enum
{
eSCREEN_COLOR_SINGLE = 1,    //����ɫ
eSCREEN_COLOR_DOUBLE,      //˫��ɫ
eSCREEN_COLOR_THREE,       //�߲�ɫ
eSCREEN_COLOR_FULLCOLOR,   //ȫ��ɫ
}E_ScreenColor_G56;
typedef enum
{
eDOUBLE_COLOR_PIXTYPE_1 = 1, //˫��ɫ1��R+G
eDOUBLE_COLOR_PIXTYPE_2,   //˫��ɫ2��G+R
}E_DoubleColorPixel_G56;

typedef enum : int   //���� :int ��Ԫ���� int ����
{
eSINGLELINE,   //����
eMULTILINE,    //����
}E_arrMode;

typedef enum
{
eYYYY_MM_DD_MINUS,   //YYYY-MM-DD
eYYYY_MM_DD_VIRGURE, //YYYY/MM/DD
eDD_MM_YYYY_MINUS,   //DD-MM-YYYY
eDD_MM_YYYY_VIRGURE, //DD/MM/YYYY
eMM_DD_MINUS,        //MM-DD
eMM_DD_VIRGURE,      //MM/DD
eMM_DD_CHS,          //MM��DD��
eYYYY_MM_DD_CHS,     //YYYY��MM��DD��
}E_DateStyle;

typedef enum
{
eHH_MM_SS_COLON,  //HH:MM:SS
eHH_MM_SS_CHS,    //HHʱMM��SS��
eHH_MM_COLON,     //HH:MM
eHH_MM_CHS,       //HHʱMM��
eAM_HH_MM,        //AM HH:MM
eHH_MM_AM,        //HH:MM AM
}E_TimeStyle;

typedef enum
{
eMonday = 1,    //Monday
eMon,         //Mon.
eMonday_CHS,  //����һ
}E_WeekStyle;

typedef enum
{
eBLACK,     //��ɫ
eRED,       //��ɫ
eGREEN,     //��ɫ
eYELLOW,    //��ɫ
eBLUE,		//��ɫ
eMAGENTA,	//Ʒ��/���
eCYAN,		//��ɫ
eWHITE,		//��ɫ
}E_Color_G56;  //5��ֻ֧��ǰ��������ɫ

typedef enum
{
eLINE,     //����
eSQUARE,   //����
eCIRCLE,   //Բ��
}E_ClockStyle;//������ʽ

typedef enum
{
pNORMAL,       //����
pROTATERIGHT,  //������ת
pMIRROR,       //����
pROTATELEFT,   //������ת
}E_txtDirection;//ͼ�������ַ���---�ݲ�֧��

#pragma pack (push,1)

typedef struct {
Ouint8 FileType; //�ļ�����
Oint8 ControllerName[8]; // ����������
Ouint16 Address; //��������ַ
Ouint8 Baudrate; /* ���ڲ�����
0x00 �C����ԭ�в����ʲ���
0x01 �Cǿ������Ϊ 9600
0x02 �Cǿ������Ϊ 57600*/
Ouint16 ScreenWidth; //��ʾ�����
Ouint16 ScreenHeight; // ��ʾ���߶�
Ouint8 Color; /* ��ʾ����ɫ���� Bit0 ��ʾ�죬 bit1 ��ʾ�̣� bit2 ��ʾ
���� ����ÿһ�� Bit�� 0 ��ʾ�� 1 ��ʾ��*/
Ouint8 MirrorMode; // 0x00 �C�޾��� 0x01 �C����
Ouint8 OEPol; //OE ���ԣ�0x00 �C OE ����Ч   0x01 �C OE ����Ч
Ouint8 DAPol; // ���ݼ��ԣ� 0x00 �C���ݵ���Ч�� 0x01 �C���ݸ���Ч
Ouint8 RowOrder; /*����ģʽ�� ��ֵ��ΧΪ 0-31
0-15 ��������
0 ����ӵ� 0 �п�ʼ˳��ɨ��
1 ����ӵ� 1 �п�ʼ˳��ɨ��
.....
16-31 ��������
0 ����ӵ� 0 �п�ʼ����ɨ��
1 ����ӵ� 1 �п�ʼ����ɨ��*/
Ouint8 FreqPar; /*CLK ��Ƶ����
ע�⣺ ����� AX ϵ�У� Ϊ�󼶷�Ƶ
��ֵΪ 0~15�� �� 16 ���ȼ���*/
Ouint8 OEWidth; // OE ���
Ouint8 OEAngle; // OE ��ǰ��
Ouint8 FaultProcessMode; /*�������Ĵ�����ģʽ
0x00 �C�Զ�����
0x01 �C�ֶ�����(��ģʽ����������Ա
ʹ��)*/
Ouint8 CommTimeoutValue; /*ͨѶ��ʱ���ã���λ�룩
����ֵ��
���ڨC 2S
TCP/IP �C 6S
GPRS �C 30S*/
Ouint8 RunningMode; /*����������ģʽ�� ���嶨�����£�
0x00 �C����ģʽ
0x01 �C����ģʽ*/
Ouint8 LoggingMode; /*��־��¼ģʽ
0x00 �C����־
0x01 �Cֻ�Կ��������󼰶Դ������
�Ĵ�����м�¼
0x02 �C�Կ����������в������м�
¼�� ������ ���������յĸ���ָ�
�����Ĵ��󼰴�����*/
Ouint8 GrayFlag; /*�Ҷȱ�־(�� 5Q ��ʱ�и��ֽ�)
0x00�C�޻Ҷ�
0x01�C�Ҷ�*/
Ouint8 CascadeMode; /*����ģʽ�� (�� 5Q ��ʱ�и��ֽ�)
0x00�C�Ǽ���ģʽ
0x01�C����ģʽ*/
Ouint8 Default_brightness; /*AX ϵ�п�����ר�ã� ��ʾ�ϵ�ʱ�� Ĭ
�ϵ����ȵȼ�ֵ�� ���ݲ�ͬ����Ļ��
��������ͬ��*/
Ouint8 HUBConfig;  /*HUB ������(�� 6E ������֧��)
0x00�CHUB512 Ĭ����
0x01�CHUB256*/
Ouint8 Language; /*��������������ʾ����
0x00 ----����������ʾ��
0x01 ----��������ʾ�� ��������ʾͼ
�μ�Ӣ���ַ���
����ֵ������*/
Ouint8 Backup[3]; // �����ֽ�
Ouint16 CRC16; //�����ļ��� CRC16 У��
}ConfigFile;

typedef struct {
Ouint8 FileType; //�ļ�����
Oint8 ControllerName[16]; // ����������
Oint8 ScreenAddress[48]; //��Ļ��װ��ַ����Ϊ 24���ֽڳ���

Ouint16 Address; //��������ַ
Ouint8 Baudrate; /* ���ڲ�����
0x00 �C����ԭ�в����ʲ���
0x01 �Cǿ������Ϊ 9600
0x02 �Cǿ������Ϊ 57600*/
Ouint16 ScreenWidth; //��ʾ�����
Ouint16 ScreenHeight; // ��ʾ���߶�
Ouint8 Color; /* ��ʾ����ɫ���� Bit0 ��ʾ�죬 bit1 ��ʾ�̣� bit2 ��ʾ
���� ����ÿһ�� Bit�� 0 ��ʾ�� 1 ��ʾ��*/
Ouint8 modeofdisp; // 6Q ϵ����ʾģʽ�� 0Ϊ888, 1Ϊ565����������ƿ����ֽ�Ϊ0
Ouint8 TipLanguage; //0 ��ʾ��λ����������İ棬�ײ�̼�����ʾ��ʾ��Ϣʱ��������õ�������ʾ��Ϣ
//1 ��ʾ��λ�������Ӣ�İ棬�ײ�̼�����ʾ��ʾ��Ϣʱ��������õ�Ӣ����ʾ��Ϣ
//255 ��ʾ��λ��������������԰棬�ײ�̼�����ʾ��ʾ��Ϣʱ������Զ�����ʾ��Ϣ
Ouint8 Reserved[5]; // 5�������ֽ�
Ouint8 FaultProcessMode; /*�������Ĵ�����ģʽ
0x00 �C�Զ�����
0x01 �C�ֶ�����(��ģʽ����������Աʹ��)*/
Ouint8 CommTimeoutValue; /*ͨѶ��ʱ���ã���λ�룩
����ֵ��
���ڨC 2S
TCP/IP �C 6S
GPRS �C 30S*/
Ouint8 RunningMode; /* ����������ģʽ�����嶨�����£�
0x00 �C����ģʽ
0x01 �C����ģʽ*/
Ouint8 LoggingMode; /*��־��¼ģʽ
0x00 �C����־
0x01 �Cֻ�Կ��������󼰶Դ������
�Ĵ�����м�¼
0x02 �C�Կ����������в������м�
¼�� ������ ���������յĸ���ָ�
�����Ĵ��󼰴�����*/
Ouint8 DevideScreenMode; /*��� 6Q2 ���ķ���ģʽ
������Ŀ�Ϊ�����ֽ� 0*/
Ouint8 Reserved2; //�����ֽ�
Ouint8 Default_brightness;  /*AX ϵ�п�����ר�ã���ʾ�ϵ�ʱ��Ĭ
�ϵ����ȵȼ�ֵ������Ŀ��ƿ�����
��Ϊ������ 0*/
Ouint8 Backup[5]; // ����ֵ�ֽ�
Ouint16 CRC16; //�����ļ��� CRC16 У��
}ConfigFile_G6;

typedef struct {
// ����������
//С�˴洢��λ��ǰ��λ�ں� ���� 0x254 ����ȡ����λ��ʾϵ�У���λ���  [0x54, 0x02] ��ϵ�У���š�
Ouint16 ControllerType;
// �̼��汾��
Ouint8 FirmwareVersion[8];
// �����������ļ�״̬ 0x00 �C��������û�в��������ļ������·��ص��ǿ�������Ĭ�ϲ����� ��ʱ�� PC ���Ӧ��ʾ�û������ȼ������Ρ�0x01 �C���������в��������ļ�
Ouint8 ScreenParaStatus;
// ��������ַ
Ouint16 uAddress;
// ������
Ouint8 Baudrate;
// ����
Ouint16 ScreenWidth;
// ����
Ouint16 ScreenHeight;
// ��ʾ����ɫ����
Ouint8 Color;
//��ǰ����ֵ   ����1-16
Ouint8 CurrentBrigtness;
// ���������ػ�״̬   0 �ػ�  1������
Ouint8 CurrentOnOffStatus;
// ɨ�����ñ��
Ouint16 ScanConfNumber;
// ��һ���Լ�һ·���ݴ����У����������ò��ϣ�������Ҫ�ɲο�Э��ȡ��Ӧ���ֽ�
Ouint8 reversed[9];
// ������ip��ַ
Ouint8 ipAdder[20];
}Ping_data;


typedef struct {
Ouint8 password[8];    //����
Ouint8 ip[4];          //������IP��ַ
Ouint8 subNetMask[4];  // ��������
Ouint8 gate[4];           // ����
short port;            // �˿�
Ouint8 mac[6];           // MAC��ַ
Ouint8 netID[12];       // ����������ID
}heartbeatData;


//typedef struct APPLICATION_LAYER_LED_HEADER_56
//{
//	Ouint8 reserved;
//	Ouint8 cmdgroup;//������
//	Ouint8 cmd;//������
//	Ouint16 status;//������״̬ ����ACK,��status=0,NACK,��status=1
//	Ouint16 Error;//����״̬
//	Ouint16 datalen;//���ݳ���
//}response_header_56;


typedef struct {
//Oint8 CmdGroup;		//1 0xA4 ������ //Oint8 Cmd;		//1 0x83 ������ //Oint16 Status;	//2 ������״̬//Oint16 Error;	//2 ����״̬�Ĵ���//Oint16 DataLen;	//		2 0xA4 ���ݳ���
Oint8 Mac[6];			//6 Mac ��ַ
Ouint8 IP[4];			//4 ������ IP ��ַ
Ouint8 SubNetMask[4];	//4 ��������
Ouint8 Gate[4];			//4 ����
Ouint8 Port[2];			//2 �˿�
Oint8 IPMode;			//1 1 ��ʾ DHCP 2 ��ʾ�ֶ�����
Oint8 IPStatus;			//1 0 ��ʾ IP ����ʧ�� 1 ��ʾ IP ���óɹ�
Oint8 ServerMode;		//1 0 Bit[0]��ʾ������ģʽ�Ƿ�ʹ�ܣ�1 �Cʹ�ܣ�0 �C��ֹ Bit[1]��ʾ������ģʽ��1 �Cweb ģʽ��0 �C��ͨģʽ
Ouint8 ServerIPAddress[4];// 4 ������ IP ��ַ
Oint16 ServerPort;		//2 �������˿ں�
Oint8 ServerAccessPassword[8];//	8 ��������������
Oint16 HeartBeatInterval;//2 20S ����ʱ��������λ���룩
Oint8 CustomID[12];		//12 �û��Զ��� ID����Ϊ���� ID ��ǰ�벿�֣������û�ʶ������ƿ�
//Web ģʽ�²μ���������ݽṹ��NetSearchCmdRet_Web   �������� 5 ���ʵ��ֵ�������ϴ����� 5 ��
//Oint8 WebUserID[128];//		128 0 WEB ƽ̨�û� id//Oint32 GroupNum;//		4 0 ��Ļ���//Oint8 DomainFlag;//		1 0 ������־ 0 - ��������1������//Oint8 DomainName[128];//		128 �������� �� DomainFlag Ϊ 1 ʱ�·�//Oint8 WebControllerName[128];// 128 LED00001 WEB ƽ̨����������
//Web ģʽ�·��ؽ��� ==================================================
Oint8 BarCode[16];		//16 �����룬��Ϊ���� ID �ĺ�벿�֣�����ʵ������ ID ��Ψһ��
Oint16 ControllerType;	//2 ���е�λ�ֽڱ�ʾ�豸ϵ�У�����λ�ֽڱ�ʾ�豸��ţ����� BX - 6Q2 Ӧ��ʾΪ[0x66, 0x02]�������ͺ��������ơ�
Oint8 FirmwareVersion[8];// 8 Firmware �汾��
Oint8 ScreenParaStatus;	//1 �����������ļ�״̬ 0x00 �C��������û�в��������ļ������·��ص��ǿ�������Ĭ�ϲ�������ʱ��PC���Ӧ��ʾ�û������ȼ������Ρ�0x01 �C���������в��������ļ�
Oint16 Address;			//2 0x0001 ��������ַ����������Ĭ�ϵ�ַΪ 0x0001(0x0000 ��ַ������)���Ƴ��˶Է��͸������ַ�����ݰ����д����⣬����Թ㲥���ݰ����д���
Oint8 Baudrate;			//1 0x00 ������ 0x00 �C����ԭ�в����ʲ��� 0x01 �Cǿ������Ϊ 9600 0x02 �Cǿ������Ϊ 57600
Oint16 ScreenWidth;		//2 192 ��ʾ�����
Oint16 ScreenHeight;	//2 96 ��ʾ���߶�
Oint8 Color;			//1 0x01 �����޻Ҷ�ϵͳ����ɫʱ���� 1��˫ɫʱ���� 3����ɫʱ���� 7�������лҶ�ϵͳ������ 255
Oint8 BrightnessAdjMode;// 1 ����ģʽ 0x00 �C�ֶ����� 0x01 �C��ʱ���� 0x02 �C�Զ�����
Oint8 CurrentBrigtness;	// 1 ��ǰ����ֵ
Oint8 TimingOnOff;		//1 Bit0 �C��ʱ���ػ�״̬��0 ��ʾ�޶�ʱ���ػ���1 ��ʾ�ж�ʱ���ػ�
Oint8 CurrentOnOffStatus;//1 ���ػ�״̬
Oint16 ScanConfNumber;	//2 ɨ�����ñ��
Oint8 RowsPerChanel;	//1 һ·���ݴ�����
Oint8 GrayFlag;			//1 �����޻Ҷ�ϵͳ������ 0�������лҶ�ϵ
Oint8 UnitWidth[2];		//2 ��С��Ԫ���
Oint8 modeofdisp;		//1 6Q ��ʾģʽ : 0 Ϊ 888, 1 Ϊ 565�����࿨Ϊ 0
Oint8 NetTranMode;		//1 �����ֽ�Ϊ 0 ʱ������ͨѶʹ���ϵ�ģʽ���� UDP �� TCP �����������PackageMode �ֽ�ȷ������������ UDPͨѶʱ���������ΪС����ÿ����һС����һ����ʱ�����ֽڲ�Ϊ 0 ʱ������ͨѶʹ���µ�ģʽ���� UDP �İ�������UDPPackageMode * 8KBYTE���Ҳ��ٷ�ΪС�������������ݶ���Э��ջTCP �İ������� PackageMode * 16KBYTE
Oint8 PackageMode;		//1 ��ģʽ��0 С��ģʽ���ְ� 600 byte��1 ���ģʽ���ְ� 16K byte��
Oint8 BarcodeFlag;		//1 �Ƿ����������� ID��������ˣ����ֽڵ� 0 λΪ 1������Ϊ0
Oint16 ProgramNumber;	//2 �����������н�Ŀ����
Oint32 CurrentProgram;	//4 ��ǰ��Ŀ��
Oint8 ScreenLockStatus;	//1 Bit0 �C�Ƿ���Ļ������1b��0 �C����Ļ������1b��1 �C��Ļ����
Oint8 ProgramLockStatus;//1 Bit0 �C�Ƿ��Ŀ������1b��0 �C�޽�Ŀ������1��b1 �C��Ŀ����
Oint8 RunningMode;		//1 ����������ģʽ
Oint8 RTCStatus;		//1 RTC ״̬ 0x00 �C RTC �쳣 0x01 �C RTC ����
Oint16 RTCYear;			//2 ��
Oint8 RTCMonth;			//1 ��
Oint8 RTCDate;			//1 ��
Oint8 RTCHour;			//1 Сʱ
Oint8 RTCMinute;		//1 ����
Oint8 RTCSecond;		//1 ��
Oint8 RTCWeek;			//1 ���ڣ���ΧΪ 1~7��7 ��ʾ����
Oint8 Temperature1[3];	//3 �¶ȴ�������ǰֵ
Oint8 Temperature2[3];	//3 �¶ȴ�������ǰֵ
Oint8 Humidity[2];		//2 ʪ�ȴ�������ǰֵ
Oint8 Noise[2];			//2 ������������ǰֵ(���� 10 Ϊ��ǰֵ)��� BX - ZS(485) 0xffff ʱ��Ч
Oint8 Reserved;			//1 �����ֽ�
Oint8 LogoFlag;			//1 0����ʾδ���� Logo ��Ŀ 1����ʾ������ Logo ��Ŀ
Oint16 PowerOnDelay;	//2 0��δ���ÿ�����ʱ 1��������ʱʱ��
Oint16 WindSpeed;		//2 ����(���� 10 Ϊ��ǰֵ) 0xfffff ʱ��Ч
Oint16 WindDirction;	//2 ����(��ǰֵ) 0xfffff ʱ��Ч
Oint16 PM2_5;			//2 PM2.5 ֵ(��ǰֵ)0xfffff ʱ��Ч
Oint16 PM10;			//2 PM10 ֵ(��ǰֵ)0xfffff ʱ��Ч
//Oint8 Reserved2[24];	//24 ������
Oint16 ExtendParaLen;	// 2 0x40 ��չ��������
Oint8 ControllerName[16];	// 16 LEDCON01 ��������������Ϊ 16 ���ֽڳ���(ȫ�� 0x00 ��ʾ���ζ�ʧ��������Ч����λ���հ���ʾ)
Oint8 ScreenLocation[44];	// 44 0 ��Ļ��װ��ַ����Ϊ 44 ���ֽڳ���(ȫ�� 0x00 ��ʾ���ζ�ʧ��������Ч����λ���հ���ʾ)
Oint8 NameLocalationCRC32[4];// 4 ����������Ļ��װ��ַ�� 60 ���ֽڵ�CRC32 У��ֵ����ֵ��Ϊ�˱�����λ�����ִ˴� 64 ���ֽ��Ǳ�ʾ���������ƻ���������ʾ���������ƺ���Ļ��װ��ַ��������ȡ��ͬ�Ĵ������Ϊ�˱��ּ��ݣ���λ�����Ը�ֵ������֤
}NetSearchCmdRet;


typedef struct {
//Oint8 CmdGroup;		//1 0xA4 ������ //Oint8 Cmd;		//1 0x83 ������ //Oint16 Status;	//2 ������״̬//Oint16 Error;	//2 ����״̬�Ĵ���//Oint16 DataLen;	//		2 0xA4 ���ݳ���
Oint8 Mac[6];			//6 Mac ��ַ
Ouint8 IP[4];			//4 ������ IP ��ַ
Ouint8 SubNetMask[4];	//4 ��������
Ouint8 Gate[4];			//4 ����
Ouint8 Port[2];			//2 �˿�
Oint8 IPMode;			//1 1 ��ʾ DHCP 2 ��ʾ�ֶ�����
Oint8 IPStatus;			//1 0 ��ʾ IP ����ʧ�� 1 ��ʾ IP ���óɹ�
Oint8 ServerMode;		//1 0 Bit[0]��ʾ������ģʽ�Ƿ�ʹ�ܣ�1 �Cʹ�ܣ�0 �C��ֹ Bit[1]��ʾ������ģʽ��1 �Cweb ģʽ��0 �C��ͨģʽ
Ouint8 ServerIPAddress[4];// 4 ������ IP ��ַ
Oint16 ServerPort;		//2 �������˿ں�
Oint8 ServerAccessPassword[8];//	8 ��������������
Oint16 HeartBeatInterval;//2 20S ����ʱ��������λ���룩
Oint8 CustomID[12];		//12 �û��Զ��� ID����Ϊ���� ID ��ǰ�벿�֣������û�ʶ������ƿ�
//Web ģʽ�·������� 5 ���ʵ��ֵ�������ϴ����� 5 ��
Oint8 WebUserID[128];	//		128 0 WEB ƽ̨�û� id
Oint32 GroupNum;		//		4 0 ��Ļ���
Oint8 DomainFlag;		//		1 0 ������־ 0 - ��������1������
Oint8 DomainName[128];	//		128 �������� �� DomainFlag Ϊ 1 ʱ�·�
Oint8 WebControllerName[128];// 128 LED00001 WEB ƽ̨����������
//Web ģʽ�·������� 5 �� ���� ###################
Oint8 BarCode[16];		//16 �����룬��Ϊ���� ID �ĺ�벿�֣�����ʵ������ ID ��Ψһ��
Oint16 ControllerType;	//2 ���е�λ�ֽڱ�ʾ�豸ϵ�У�����λ�ֽڱ�ʾ�豸��ţ����� BX - 6Q2 Ӧ��ʾΪ[0x66, 0x02]�������ͺ��������ơ�
Oint8 FirmwareVersion[8];// 8 Firmware �汾��
Oint8 ScreenParaStatus;	//1 �����������ļ�״̬ 0x00 �C��������û�в��������ļ������·��ص��ǿ�������Ĭ�ϲ�������ʱ��PC���Ӧ��ʾ�û������ȼ������Ρ�0x01 �C���������в��������ļ�
Oint16 Address;			//2 0x0001 ��������ַ����������Ĭ�ϵ�ַΪ 0x0001(0x0000 ��ַ������)���Ƴ��˶Է��͸������ַ�����ݰ����д����⣬����Թ㲥���ݰ����д���
Oint8 Baudrate;			//1 0x00 ������ 0x00 �C����ԭ�в����ʲ��� 0x01 �Cǿ������Ϊ 9600 0x02 �Cǿ������Ϊ 57600
Oint16 ScreenWidth;		//2 192 ��ʾ�����
Oint16 ScreenHeight;	//2 96 ��ʾ���߶�
Oint8 Color;			//1 0x01 �����޻Ҷ�ϵͳ����ɫʱ���� 1��˫ɫʱ���� 3����ɫʱ���� 7�������лҶ�ϵͳ������ 255
Oint8 BrightnessAdjMode;//1 ����ģʽ 0x00 �C�ֶ����� 0x01 �C��ʱ���� 0x02 �C�Զ�����
Oint8 CurrentBrigtness;	//1 ��ǰ����ֵ
Oint8 TimingOnOff;		//1 Bit0 �C��ʱ���ػ�״̬��0 ��ʾ�޶�ʱ���ػ���1 ��ʾ�ж�ʱ���ػ�
Oint8 CurrentOnOffStatus;//1 ���ػ�״̬
Oint16 ScanConfNumber;	//2 ɨ�����ñ��
Oint8 RowsPerChanel;	//1 һ·���ݴ�����
Oint8 GrayFlag;			//1 �����޻Ҷ�ϵͳ������ 0�������лҶ�ϵ
Oint8 UnitWidth[2];		//2 ��С��Ԫ���
Oint8 modeofdisp;		//1 6Q ��ʾģʽ : 0 Ϊ 888, 1 Ϊ 565�����࿨Ϊ 0
Oint8 NetTranMode;		//1 �����ֽ�Ϊ 0 ʱ������ͨѶʹ���ϵ�ģʽ���� UDP �� TCP �����������PackageMode �ֽ�ȷ������������ UDPͨѶʱ���������ΪС����ÿ����һС����һ����ʱ�����ֽڲ�Ϊ 0 ʱ������ͨѶʹ���µ�ģʽ���� UDP �İ�������UDPPackageMode * 8KBYTE���Ҳ��ٷ�ΪС�������������ݶ���Э��ջTCP �İ������� PackageMode * 16KBYTE
Oint8 PackageMode;		//1 ��ģʽ��0 С��ģʽ���ְ� 600 byte��1 ���ģʽ���ְ� 16K byte��
Oint8 BarcodeFlag;		//1 �Ƿ����������� ID��������ˣ����ֽڵ� 0 λΪ 1������Ϊ0
Oint16 ProgramNumber;	//2 �����������н�Ŀ����
Oint32 CurrentProgram;	//4 ��ǰ��Ŀ��
Oint8 ScreenLockStatus;	//1 Bit0 �C�Ƿ���Ļ������1b��0 �C����Ļ������1b��1 �C��Ļ����
Oint8 ProgramLockStatus;//1 Bit0 �C�Ƿ��Ŀ������1b��0 �C�޽�Ŀ������1��b1 �C��Ŀ����
Oint8 RunningMode;		//1 ����������ģʽ
Oint8 RTCStatus;		//1 RTC ״̬ 0x00 �C RTC �쳣 0x01 �C RTC ����
Oint16 RTCYear;			//2 ��
Oint8 RTCMonth;			//1 ��
Oint8 RTCDate;			//1 ��
Oint8 RTCHour;			//1 Сʱ
Oint8 RTCMinute;		//1 ����
Oint8 RTCSecond;		//1 ��
Oint8 RTCWeek;			//1 ���ڣ���ΧΪ 1~7��7 ��ʾ����
Oint8 Temperature1[3];	//3 �¶ȴ�������ǰֵ
Oint8 Temperature2[3];	//3 �¶ȴ�������ǰֵ
Oint8 Humidity[2];		//2 ʪ�ȴ�������ǰֵ
Oint8 Noise[2];			//2 ������������ǰֵ(���� 10 Ϊ��ǰֵ)��� BX - ZS(485) 0xffff ʱ��Ч
Oint8 Reserved;			//1 �����ֽ�
Oint8 LogoFlag;			//1 0����ʾδ���� Logo ��Ŀ 1����ʾ������ Logo ��Ŀ
Oint16 PowerOnDelay;	//2 0��δ���ÿ�����ʱ 1��������ʱʱ��
Oint16 WindSpeed;		//2 ����(���� 10 Ϊ��ǰֵ) 0xfffff ʱ��Ч
Oint16 WindDirction;	//2 ����(��ǰֵ) 0xfffff ʱ��Ч
Oint16 PM2_5;			//2 PM2.5 ֵ(��ǰֵ)0xfffff ʱ��Ч
Oint16 PM10;			//2 PM10 ֵ(��ǰֵ)0xfffff ʱ��Ч
//Oint8 Reserved2[24];	//24 ������
Oint16 ExtendParaLen;	// 2 0x40 ��չ��������
Oint8 ControllerName[16];	// 16 LEDCON01 ��������������Ϊ 16 ���ֽڳ���(ȫ�� 0x00 ��ʾ���ζ�ʧ��������Ч����λ���հ���ʾ)
Oint8 ScreenLocation[44];	// 44 0 ��Ļ��װ��ַ����Ϊ 44 ���ֽڳ���(ȫ�� 0x00 ��ʾ���ζ�ʧ��������Ч����λ���հ���ʾ)
Oint8 NameLocalationCRC32[4];// 4 ����������Ļ��װ��ַ�� 60 ���ֽڵ�CRC32 У��ֵ����ֵ��Ϊ�˱�����λ�����ִ˴� 64 ���ֽ��Ǳ�ʾ���������ƻ���������ʾ���������ƺ���Ļ��װ��ַ��������ȡ��ͬ�Ĵ������Ϊ�˱��ּ��ݣ���λ�����Ը�ֵ������֤
}NetSearchCmdRet_Web;

typedef struct {
Ouint8 onHour;   // ����Сʱ
Ouint8 onMinute; // ��������
Ouint8 offHour;  // �ػ�Сʱ
Ouint8 offMinute; // �ػ�����
}TimingOnOff;

typedef struct {
/*
0x00 �C�ֶ�����
0x01 �C��ʱ���� ע:���µ�����ֵ���ڶ�ʱ�������� ������ʱ���������账������Э���� ����ʲôģʽ���˱���Ҫ���͸����� ��
0x00 �C�ֶ�����
0x01 �C��ʱ���� ע:���µ�����ֵ���ڶ�ʱ�������� ������ʱ���������账������Э���� ����ʲôģʽ���˱���Ҫ���͸����� ��
*/
Ouint8 BrightnessMode;

//00:00 �C 00:29 ������ֵ�� 0x00 �C 0x0f
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
Ouint8 onoffStatus; // ���ػ�״̬ Bit 0 �C����/�ػ��� 0 ��ʾ�ػ��� 1 ��ʾ����
Ouint8 timingOnOff; // ��ʱ���ػ�״̬ 0 ��ʾ�޶�ʱ���ػ��� 1 ��ʾ�ж�ʱ���ػ�
Ouint8 brightnessAdjMode; //����ģʽ 0x00 �C�ֶ����� 0x01 �C��ʱ���� 0x02 �C�Զ�����
Ouint8 brightness;// ��ǰ����ֵ
short programeNumber;// �����������н�Ŀ����
Ouint8 currentProgram[4];//��ǰ��Ŀ��
Ouint8 screenLockStatus;//�Ƿ���Ļ������0 �C����Ļ������ 1 �C��Ļ����
Ouint8 programLockStatus; //�Ƿ��Ŀ������ 0 �C�޽�Ŀ������1 �C��Ŀ����
Ouint8 runningMode;//����������ģʽ
Ouint8 RTCStatus;//RTC ״̬0x00 �C RTC �쳣 0x01 �C RTC ����
short RTCYear;//��
Ouint8 RTCMonth;//��
Ouint8 RTCDate;//��
Ouint8 RTCHour;//ʱ
Ouint8 RTCMinute;//��
Ouint8 RTCSecond;//��
Ouint8 RTCWeek;//���� 1--7
Ouint8 temperature1[3];//�¶�1��������ǰֵ
Ouint8 temperature2[3];//�¶�2��������ǰֵ
short humidity;//ʪ�ȴ�������ǰֵ
short noise;//������������ǰֵ
Ouint8 switchStatus; //���԰�ť״̬ 0 �C�� 1 �C�պ�
Ouint8 CustomID[12]; //�û��Զ��� ID����Ϊ���� ID ��ǰ�벿�֣������û�ʶ������ƿ�
Ouint8 BarCode[16]; //�����룬��Ϊ���� ID �ĺ�벿�֣�����ʵ������ ID ��Ψһ��
}ControllerStatus_G56;

typedef struct {
Ouint8 rstMode; //��λģʽ 0x00 �Cȡ����ʱ��λ���� 0x01 �C���ڸ�λ�� ��ʱ RstInterval �ֶ���Ч 0x02 �Cֻ��ָ��ʱ�临λ
Ouint32 RstInterval;//��λ���ڣ� ��λ�� ��������ֶ�Ϊ 0�� �����и�λ����
Ouint8 rstHour1; //Сʱ 0Xff�C��ʾ������Ч�� ��ͬ
Ouint8 rstMin1;
Ouint8 rstHour2;
Ouint8 rstMin2;
Ouint8 rstHour3;
Ouint8 rstMin3;
}TimingReset;

typedef struct {
short BattleRTCYear; //��
Ouint8 BattleRTCMonth;//��
Ouint8 BattleRTCDate;//��
Ouint8 BattleRTCHour;//ʱ
Ouint8 BattleRTCMinute;//��
Ouint8 BattleRTCSecond;//��
Ouint8 BattleRTCWeek;//����
}BattleTime;

typedef struct {
/*
Ĭ�ϣ�0x00
LOGO�ļ�:0x08
ɨ�������ļ�:0x02
��־�ļ�:0x06
�ֿ��ļ�:0x05
��ʾ��Ϣ���ļ�: 0x07
*/
Ouint8     FileType; //�ļ�����
Ouint32    ProgramID;//��ĿID

/*
Bit0 �Cȫ�ֽ�Ŀ��־λ
Bit1 �C��̬��Ŀ��־λ
Bit2 �C������Ŀ��־λ
*/
Ouint8    ProgramStyle;//��Ŀ����

//ע:������ʱ�εĽ�Ŀ���ȼ�Ϊ 1���� ������ʱ�εĽ�Ŀ���ȼ�Ϊ 0
Ouint8    ProgramPriority; //��Ŀ�ȼ�
Ouint8    ProgramPlayTimes;//��Ŀ�ز��Ŵ���
Ouint16   ProgramTimeSpan; //���ŵķ�ʽ
Ouint8    ProgramWeek;      //��Ŀ��������
Ouint16   ProgramLifeSpan_sy;//��
Ouint8    ProgramLifeSpan_sm;//��
Ouint8    ProgramLifeSpan_sd;//��
Ouint16   ProgramLifeSpan_ey;//������
Ouint8    ProgramLifeSpan_em;//������
Ouint8    ProgramLifeSpan_ed;//������
//Ouint8    PlayPeriodGrpNum;//����ʱ�ε�����
}BXprogramHeader,EQprogramHeader;

typedef struct
{
Ouint8 StartHour;
Ouint8 StartMinute;
Ouint8 StartSecond;
Ouint8 EndHour;
Ouint8 EndMinute;
Ouint8 EndSecond;
}BXprogrampTime_G56,EQprogrampTime_G56;//��Ŀ�Ĳ���ʱ��

typedef struct
{
Ouint8 playTimeGrpNum; //����ʱ����Ч���� 0 û�в���ʱ��ȫ�첥�� ���ֵ8 
EQprogrampTime_G56 timeGrp0;
EQprogrampTime_G56 timeGrp1;
EQprogrampTime_G56 timeGrp2;
EQprogrampTime_G56 timeGrp3;
EQprogrampTime_G56 timeGrp4;
EQprogrampTime_G56 timeGrp5;
EQprogrampTime_G56 timeGrp6;
EQprogrampTime_G56 timeGrp7;
}BXprogramppGrp_G56,EQprogramppGrp_G56;//����ʱ�ι���8��

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
�ֿ�����:0x01
͸���ı���0x06

ʱ����:0x02

ͼ����Ļ:0x00

ս��ʱ�䣺0x09
��������0x05
�¶�����0x03
�޺�����0x08
ʪ������0x04
*/
Ouint8    AreaType; //��������

Ouint16    AreaX; //����X����
Ouint16    AreaY; //����Y����
Ouint16    AreaWidth; //�����
Ouint16    AreaHeight;//�����
}BXareaHeader,EQareaHeader;

typedef struct { //��ο�Э�� ͼ����Ļ�����ݸ�ʽ
Ouint8   PageStyle; //����ҳ����
Ouint8   DisplayMode; //��ʾ��ʽ ����Ч��:0x00 �C�����ʾ; 0x01�C��ֹ��ʾ; 0x02�C���ٴ��; 0x03�C�����ƶ�; ...0x25 �C�����ƶ�  0x26 �C��������  0x27 �C�����ƶ�  0x28 �C��������
Ouint8   ClearMode; // �˳���ʽ/������ʽ
Ouint8   Speed; // �ٶȵȼ�/�����ٶȵȼ�
Ouint16  StayTime; // ͣ��ʱ�䣬 ��λΪ 10ms
Ouint8   RepeatTime;//�ظ�����/����ƴ�Ӳ���(����ƴ����Ϊ��ȣ� ����ƴ��Ϊ�߶�)
Ouint16  ValidLen;  //�÷��Ƚϸ�����ο�Э��
E_arrMode arrMode; //���з�ʽ--���ж���
Ouint16  fontSize; //�����С
Ouint32  color; //������ɫ E_Color_G56��ͨ����ö��ֵ����ֱ�������߲�ɫ���������ö�ٷ�Χʹ��RGB888ģʽ
Obool    fontBold; //�Ƿ�Ϊ����
Obool    fontItalic;//�Ƿ�Ϊб��
E_txtDirection tdirection;//���ַ���
Ouint16   txtSpace; //���ּ��   
Ouint8 Halign; //������뷽ʽ��0ϵͳ����Ӧ��1����롢2���С�3�Ҷ��룩
Ouint8 Valign; //������뷽ʽ��0ϵͳ����Ӧ��1�϶��롢2���С�3�¶��룩
}BXpageHeader,EQpageHeader;

typedef struct
{
E_arrMode arrMode; //���з�ʽ--���ж���  E_arrMode::	eSINGLELINE,   //���� eMULTILINE,    //����
Ouint16  fontSize; //�����С
Ouint32 color;//������ɫ E_Color_G56 ��ͨ����ö��ֵ����ֱ�������߲�ɫ���������ö�ٷ�Χʹ��RGB888ģʽ
Obool    fontBold; //�Ƿ�Ϊ����
Obool    fontItalic;//�Ƿ�Ϊб��
E_txtDirection tdirection;//���ַ���
Ouint16   txtSpace;  //���ּ��   
Ouint8 Halign; //������뷽ʽ��0ϵͳ����Ӧ��1����롢2���С�3�Ҷ��룩
Ouint8 Valign; //������뷽ʽ��0ϵͳ����Ӧ��1�϶��롢2���С�3�¶��룩
}BXfontData,EQfontData;

typedef struct {
Ouint8 fileName[4]; //�ļ���
Ouint8 fileType; //�ļ�����
Ouint32 fileLen; //�ļ�����
Ouint8* fileAddre; // �ļ����ڵĻ����ַ
Ouint32 fileCRC32; //�ļ�CRC32У����
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
E_arrMode       linestyle;			//���з�ʽ�����л��Ƕ���
Ouint32         color;				//������ɫ E_Color_G56��ͨ����ö��ֵ����ֱ�������߲�ɫ���������ö�ٷ�Χʹ��RGB888ģʽ
Ouint8*         fontName;           //��������
Ouint16         fontSize;           //�����С
Ouint8			fontBold;           //����Ӵ�
Ouint8			fontItalic;         //б��
Ouint8			fontUnderline;      //������»���
Ouint8			fontAlign;          //���뷽ʽ--������Ч
Obool			date_enable;        //�Ƿ��������
E_DateStyle		datestyle;			//���ڸ�ʽ
Obool			time_enable;        //�Ƿ����ʱ��---Ĭ�����
E_TimeStyle		timestyle;			//ʱ���ʽ
Obool			week_enable;        //�Ƿ��������
E_WeekStyle		weekstyle;			//���ڸ�ʽ
}BXtimeAreaData_G56,EQtimeAreaData_G56;

typedef struct
{
Ouint16  OrignPointX;    //ԭ�������
Ouint16  OrignPointY;    //ԭ��������
Ouint8   UnitMode;       //����ģʽ
Ouint8   HourHandWidth;  //ʱ����
Ouint8   HourHandLen;    //ʱ�볤��
Ouint32   HourHandColor;  //ʱ����ɫ
Ouint8   MinHandWidth;   //������
Ouint8   MinHandLen;     //���볤��
Ouint32  MinHandColor;   //������ɫ
Ouint8   SecHandWidth;   //������
Ouint8   SecHandLen;     //���볤��
Ouint32   SecHandColor;   //������ɫ
}BXAnalogClockHeader_G56,EQAnalogClockHeader_G56;

typedef struct {
/*
Ĭ�ϣ�0x00
LOGO�ļ�:0x08
ɨ�������ļ�:0x02
��־�ļ�:0x06
�ֿ��ļ�:0x05
��ʾ��Ϣ���ļ�: 0x07
*/
Ouint8    FileType; //�ļ�����
Ouint32   ProgramID;//��ĿID

/*
Bit0 �Cȫ�ֽ�Ŀ��־λ
Bit1 �C��̬��Ŀ��־λ
Bit2 �C������Ŀ��־λ
*/
Ouint8    ProgramStyle;			//��Ŀ����
//ע:������ʱ�εĽ�Ŀ���ȼ�Ϊ 1����������ʱ�εĽ�Ŀ���ȼ�Ϊ 0
Ouint8    ProgramPriority;		//��Ŀ�ȼ�
Ouint8    ProgramPlayTimes;		//��Ŀ�ز��Ŵ���
Ouint16   ProgramTimeSpan;		//���ŵķ�ʽ
Ouint8    SpecialFlag;			//�����Ŀ��
Ouint8    CommExtendParaLen;	//��չ�������ȣ�Ĭ��Ϊ0x00
Ouint16   ScheduNum;			//��Ŀ����  
Ouint16   LoopValue;			//���ȹ���ѭ������
Ouint8    Intergrate;			//�������
Ouint8    TimeAttributeNum;		//ʱ����������
Ouint16   TimeAttribute0Offset; //��һ��ʱ������ƫ����--Ŀǰֻ֧��һ��
Ouint8    ProgramWeek;			//��Ŀ��������
Ouint16   ProgramLifeSpan_sy;	//��
Ouint8    ProgramLifeSpan_sm;	//��
Ouint8    ProgramLifeSpan_sd;	//��
Ouint16   ProgramLifeSpan_ey;	//������
Ouint8    ProgramLifeSpan_em;	//������
Ouint8    ProgramLifeSpan_ed;	//������
//Ouint8    PlayPeriodGrpNum;		//����ʱ�ε�����
}BXprogramHeader_G6,EQprogramHeader_G6;

typedef struct
{
Ouint8 FrameDispStype;    //�߿���ʾ��ʽ
Ouint8 FrameDispSpeed;    //�߿���ʾ�ٶ�
Ouint8 FrameMoveStep;     //�߿��ƶ�����
Ouint8 FrameUnitLength;   //�߿���Ԫ����
Ouint8 FrameUnitWidth;    //�߿���Ԫ���
Ouint8 FrameDirectDispBit;//�������ұ߿���ʾ��־λ��Ŀǰֻ֧��6QX-M��    
}BXscreenframeHeader_G6,EQscreenframeHeader_G6;

/*�������������ṹ��EQSound_6G���ڶ�̬��ʱʹ�ã�ͼ�ķ�������������ʹ�ã�EQPicAreaSoundHeader_G6;*/
typedef struct
{
Oint8 SoundFlag;		//1 0x00 �Ƿ�ʹ����������;0 ��ʾ��ʹ������; 1 ��ʾ���������� SoundData ��������;
//SoundData ��������---------------------------------------------------------------------------------------------------------------------------------------------------
Oint8 SoundPerson;		//1 0x00 ������ ��ֵ��Χ�� 0 - 5���� 6 ��ѡ��ֻ�� SoundFlag���Ƿ�ʹ���������ţ�Ϊ 1 ʱ�ŷ��͸��ֽڣ����򲻷��͸�ֵĬ��Ϊ 0
Oint8 SoundVolum;		//1 0x05 ������ֵ��Χ�� 0~10���� 11 �֣�0��ʾ����ֻ�� SoundFlag���Ƿ�ʹ���������ţ�Ϊ 1 ʱ�ŷ��͸��ֽڣ����򲻷��͸�ֵĬ��Ϊ 5
Oint8 SoundSpeed;		//1 0x05 ���ٸ�ֵ��Χ�� 0~10���� 11 ��ֻ�� SoundFlag���Ƿ�ʹ���������ţ�Ϊ 1 ʱ�ŷ��͸��ֽڣ����򲻷��͸�ֵĬ��Ϊ 5
Oint8 SoundDataMode;	//1 0x00 SoundData �ı����ʽ����ֵ�������£�0x00 GB2312; 0x01 GBK; 0x02 BIG5; 0x03 UNICODEֻ�� SoundFlag���Ƿ�ʹ���������ţ�Ϊ 1 ʱ�ŷ��͸��ֽڣ����򲻷���
Oint32 SoundReplayTimes;	// 4 0x00000000 �ز�������ֵΪ 0����ʾ���� 1 �θ�ֵΪ 1����ʾ���� 2 ��
//......
//��ֵΪ 0xffffffff����ʾ�������޴�ֻ�� SoundFlag���Ƿ�ʹ���ﲥ�ţ�Ϊ 1 ʱ�ŷ��͸��ֽڣ����򲻷��͸�ֵĬ��Ϊ 0
Oint32 SoundReplayDelay;// 4 0x00000000 �ز�ʱ������ֵ��ʾ���β���������ʱ��������λΪ 10msֻ�� SoundFlag���Ƿ�ʹ���������ţ�Ϊ 1 ʱ�ŷ��͸��ֽڣ����򲻷��͸�ֵĬ��Ϊ 0
Oint8 SoundReservedParaLen;// 1 0x03 ��������������������
Oint8 Soundnumdeal;		// 1 0 0���Զ��ж�1�����������봦�� 2����������ֵ����ֻ�е� SoundFlag Ϊ 1 ��SoundReservedParaLen��Ϊ 0�ŷ��ʹ˲���
Oint8 Soundlanguages;	// 1 0 0���Զ��ж�����1�����������֡�������λ��������ŵȺϳ�Ϊ����2�����������֡�������λ��������ŵȺϳ�ΪӢ��ֻ�е� SoundFlag Ϊ 1 �� SoundReservedParaLen��Ϊ 0�ŷ��ʹ˲�����Ŀǰֻ֧����Ӣ�ģ�
Oint8 Soundwordstyle;	// 1 0 0���Զ��жϷ�����ʽ1����ĸ������ʽ2�����ʷ�����ʽ��ֻ�е� SoundFlag Ϊ 1 ��SoundReservedParaLen��Ϊ 0�ŷ��ʹ˲���
Ouint32 SoundDataLen;	// 4 �������ݳ���; ֻ�� SoundFlag���Ƿ�ʹ���������ţ�Ϊ 1 ʱ�ŷ��͸��ֽڣ����򲻷���
Ouint8* SoundData;		// N ��������ֻ�� SoundFlag���Ƿ�ʹ���������ţ�Ϊ 1 ʱ�ŷ��͸��ֽڣ����򲻷���
}
EQSound_6G;/*��������ṹ��EQSound_6G���ڶ�̬��ʱʹ�ã�ͼ�ķ�������������ʹ�ã�EQPicAreaSoundHeader_G6;*/

//��̬�������������й���
//5.4.3 ����������������
typedef struct
{
Ouint8 VoiceID;	// 1 1 ����������ÿ�������� ID���� 0 ��ʼ
EQSound_6G stSound;
}BXSoundDepend_6G,EQSoundDepend_6G;

typedef struct
{
Ouint8	AreaType;		//�������ͣ���̬��ʱ���̶�Ϊ0x10;
Ouint16	AreaX;			//�������ϽǺ�����
Ouint16	AreaY;			//�������Ͻ�������
Ouint16	AreaWidth;		//������
Ouint16	AreaHeight;		//����߶�
Ouint8  BackGroundFlag; //�Ƿ��б���
Ouint8  Transparency;   //͸����
Ouint8  AreaEqual;      //ǰ�������������С�Ƿ���ͬ

/*�������������ṹ��EQSound_6G���ڶ�̬��ʱʹ�ã�ͼ�ķ�������������ʹ�õ����Ľṹ�壺EQPicAreaSoundHeader_G6;*/
//��������
//ʹ����������ʱ�����ֿ���Ҫ���ô���Ϊ����ģʽ������
EQSound_6G stSoundData;

}BXareaHeader_G6,EQareaHeader_G6;


typedef struct
{
Ouint8  SoundPerson;           //�����ˣ���Χ0��5����6��ѡ��
Ouint8  SoundVolum;            //��������Χ0��10
Ouint8  SoundSpeed;            //���٣���Χ0��10
Ouint8  SoundDataMode;         //�������ݵı����ʽ
Ouint32 SoundReplayTimes;      //�ز�����
Ouint32 SoundReplayDelay;      //�ز�ʱ����
Ouint8  SoundReservedParaLen;  //�������������������ȣ�Ĭ��0x03
Ouint8  Soundnumdeal;          //�����Э��
Ouint8  Soundlanguages;        //�����Э��
Ouint8  Soundwordstyle;        //�����Э��
}BXPicAreaSoundHeader_G6,EQPicAreaSoundHeader_G6;//ͼ�ķ�����������

typedef struct
{
Ouint16 BattleStartYear;     //��ʼ��ݣ�BCD��ʽ����ͬ��
Ouint8  BattleStartMonth;    //��ʼ�·�
Ouint8  BattleStartDate;     //��ʼ����
Ouint8  BattleStartHour;     //��ʼСʱ
Ouint8  BattleStartMinute;   //��ʼ����
Ouint8  BattleStartSecond;   //��ʼ����
Ouint8  BattleStartWeek;     //��ʼ����ֵ
Ouint8  StartUpMode;         //����ģʽ
}BXTimeAreaBattle_G6,EQTimeAreaBattle_G6; //ʱ�����ս��ʱ��

typedef struct
{
Ouint8   PageStyle;			//����ҳ����
Ouint8   DisplayMode;		//��ʾ��ʽ:0x00 �C�����ʾ; 0x01�C��ֹ��ʾ; 0x02�C���ٴ��; 0x03�C�����ƶ�; ...0x25 �C�����ƶ�  0x26 �C��������  0x27 �C�����ƶ�  0x28 �C��������
Ouint8   ClearMode;			//�˳���ʽ/������ʽ
Ouint8   Speed;				//�ٶȵȼ�
Ouint16  StayTime;			//ͣ��ʱ��
Ouint8   RepeatTime;		//�ظ�����
Ouint16  ValidLen;			//���ֶ�ֻ���������Ʒ�ʽ����Ч
Ouint8   CartoonFrameRate;  //�ؼ�Ϊ������ʽʱ����ֵ������֡��
Ouint8   BackNotValidFlag;  //������Ч��־
//������Ϣ-------------------------------------------------------------------------------------------------------
E_arrMode arrMode;			//���з�ʽ--���ж���
Ouint16  fontSize;			//�����С
Ouint32  color;				//������ɫ E_Color_G56��ͨ����ö��ֵ����ֱ�������߲�ɫ���������ö�ٷ�Χʹ��RGB888ģʽ
Obool    fontBold;			//�Ƿ�Ϊ����
Obool    fontItalic;		//�Ƿ�Ϊб��
E_txtDirection tdirection;	//���ַ���
Ouint16   txtSpace;			//���ּ��    
Ouint8 Halign; //������뷽ʽ��0ϵͳ����Ӧ��1����롢2���С�3�Ҷ��룩
Ouint8 Valign; //������뷽ʽ��0ϵͳ����Ӧ��1�϶��롢2���С�3�¶��룩
//������Ϣ ����
}BXpageHeader_G6,EQpageHeader_G6;


typedef struct
{
Ouint8 uAreaId;
EQareaHeader_G6 oAreaHeader_G6;
EQpageHeader_G6 stPageHeader;
Ouint8* fontName;
Ouint8* strAreaTxtContent;     //������ͼƬ�Ľӿں���ʱ������ֶ��е�ֵΪͼƬ��·���ļ�����
}DynamicAreaParams;


typedef struct {
Ouint8  fileName[4]; //��Ŀ�����ļ���
Ouint8  fileType;	 //�ļ�����
Ouint32 fileLen;	 //�����ļ�����
Ouint8* fileAddre;   //�ļ����ڵĻ����ַ
Ouint8  dfileName[4];//��Ŀ�����ļ���
Ouint8  dfileType;   //��Ŀ�����ļ�����
Ouint32 dfileLen;	 //�����ļ�����
Ouint8* dfileAddre;  //�����ļ������ַ
}EQprogram_G6;

typedef struct {
Ouint8   fileType;   //Ҫ��ȡ���ļ�����
Ouint16  fileNumber; //�����ж��ٸ��ļ�
Ouint8*  dataAddre;  //�����ļ��б��ַ
}GetDirBlock_G56;

typedef struct {
Ouint8  fileName[4];  //�ļ���
Ouint8  fileType;     //�ļ�����
Ouint32 fileLen;      //�ļ�����
Ouint32 fileCRC;      //�ļ�CRCУ��
}FileAttribute_G56;

typedef struct {
Ouint8*  fileAddre;     //�ļ���ַָ�
Ouint32 fileLen;        //�ļ�����
Ouint16 fileCRC16;      //�ļ�CRC16У��
}FileCRC16_G56;

typedef struct {
Ouint8*  fileAddre;     //�ļ���ַָ�
Ouint32 fileLen;        //�ļ�����
Ouint32 fileCRC32;      //�ļ�CRC32У��
}FileCRC32_G56;

typedef struct {
Ouint32 Color369; //369����ɫ
Ouint32 ColorDot; //����ɫ
Ouint32 ColorBG;  //������Ȧ��ɫ ģʽû��Ȧ�����ɫ��Ч
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
Ouint8 AreaId;		//������ţ��� 0 ��ʼ
Ouint8 RunMode;		//RunMode			1		0x00	��̬������ģʽ
//0�� ��̬������ѭ����ʾ��
//1�� ��̬��������ʾ��ɺ�ֹ��ʾ���һҳ���ݡ�
//2�� ��̬������ѭ����ʾ�������趨ʱ���������δ����ʱ������ʾ
//3�� ��̬������ѭ����ʾ�������趨

Ouint16 Timeout;	//��̬�����ݳ�ʱʱ�䣬��λΪ��
Ouint8 RelateAllPro;	//�����ֽ�Ϊ 1 ʱ�������첽��Ŀ����ʱ�������Ÿö�̬����
//Ϊ 0 ʱ���ɽ������� RelateProNum ֵ����								
Ouint16 RelateProNum;	//RelateProNum 0-N
//��̬��������˶��ٸ��첽��Ŀһ��������ĳ���첽��Ŀ���򵱸��첽��Ŀ����ʱ�����Ÿö�̬����
//���򣬲������Ÿö�	̬�������µĽ�Ŀ��Ÿ���RelateProNum��ֵ��ȷ��������	ֵΪ 0 ʱ������;

//vector<Ouint16> vctRelateProSerial;		

Ouint8 ImmePlay;	//ImmePlay		1			�Ƿ���������
//���ֽ�Ϊ 0 ʱ���ö�̬�������첽��Ŀһ�𲥷�
//���ֽ�Ϊ 1 ʱ���첽��Ŀֹͣ���ţ������Ÿö�̬����
//���ֽ�Ϊ 2 ʱ���ݴ�ö�̬���򣬵��������Ŀ�����ߵ��첽��Ŀ�󲥷Ÿö�̬����
//ע�⣺�����ֽ�Ϊ 0 ʱ��RelateAllPro ��	RelateProSerialN - 1 �Ĳ�������Ч��������Ч���ò���Ϊ 1 �� 2 ʱ�����ڲ����첽��Ŀͬʱ���ţ�
//Ϊ���Ƹö�̬�����ܼ�ʱ��������ѡ��RunMode ����Ϊ 2 �� 4����ȻҲ��ͨ��ɾ����������ʵ��

Ouint32 Reserved;// 4�ֽ� 0x00 �����ֽ�
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
Ouint8 nType; // nType=1:�ı��� nType=2:ͼƬ��

//PageStyle begin---------------
Ouint8 DisplayMode;
Ouint8 ClearMode;
Ouint8 Speed;
Ouint16 StayTime;
Ouint8 RepeatTime;
//PageStyle End.

//�ı���ʾ���ݺ������ʽ begin---------
EQfontData oFont;
Ouint8* fontName;
Ouint8* strAreaTxtContent;
//end.

//ͼƬ·�� begin---------
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


//�ı���ʾ���ݺ������ʽ begin---------
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

//ͼƬ·�� begin---------
Ouint8* filePath;
//end.

}DynamicAreaPicInfo_5G;
*/
#pragma endregion

//��ʼ����̬���ӿ�
typedef int(__stdcall *PbxDual_InitSdk)();
	PbxDual_InitSdk bxDual_InitSdk;

//�ͷŶ�̬���ӿ�
typedef void(__stdcall *PbxDual_ReleaseSdk)();
	PbxDual_ReleaseSdk bxDual_ReleaseSdk;

/*! ***************************************************************
* ��������       cmd_tcpPing����
* ��������ip��������IP�� port���������˿ڣ� retData����ο��ṹ��Ping_data
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ�ͨ��TCP��ʽ��ȡ��������������Ժ�IP��ַ
* ע��
* ��UDP PING�����ȡ���Ĳ�����ͬ
******************************************************************/
typedef int(__stdcall *PbxDual_cmd_tcpPing)(Ouint8* ip, Ouint16 port, Ping_data *retData);
	PbxDual_cmd_tcpPing bxDual_cmd_tcpPing;

/*! ***************************************************************
* ��������       bxDual_program_setScreenParams_G56����
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ��������������
* ע��
* ����������ο�����ö��ֵ
******************************************************************/
typedef int(__stdcall *PbxDual_program_setScreenParams_G56)(E_ScreenColor_G56 color, Ouint16 ControllerType, E_DoubleColorPixel_G56 doubleColor); //�������������
	PbxDual_program_setScreenParams_G56 bxDual_program_setScreenParams_G56;

/*! ***************************************************************
* ��������       bxDual_cmd_ofsStartFileTransf����
* ��������ip��������IP�� port���������˿�
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ���ʼ����д�ļ�
* ע��
* ���ͽ�Ŀǰ����
******************************************************************/
typedef int(__stdcall *PbxDual_cmd_ofsStartFileTransf)(Ouint8* ip, Ouint16 port);
	PbxDual_cmd_ofsStartFileTransf bxDual_cmd_ofsStartFileTransf;

/*! ***************************************************************
* ��������       bxDual_cmd_ofsWriteFile����
* ��������ip��������IP�� port���������˿�
*	fileName���ļ���
*	fileType���ļ�����
*	fileLen���ļ�����
*	fileAddre���ļ����ڵĻ����ַ
*	overwrite���Ƿ񸲸ǿ����ϵ��ļ� 1���� 0������ ���鷢1
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ�д�ļ�������
* ע�����ڶԴ洢�� OFS �е��ļ��Ĵ��� ���磺 ��Ŀ�ļ��� �ֿ��ļ��� �����б��ļ���
* �ڲ�������������ע�ⷵ��״̬�����������
******************************************************************/
typedef int(__stdcall *PbxDual_cmd_ofsWriteFile)(Ouint8* ip, Ouint16 port, Ouint8 *fileName, Ouint8 fileType, Ouint32 fileLen, Ouint8 overwrite, Ouint8 *fileAddre);
	PbxDual_cmd_ofsWriteFile bxDual_cmd_ofsWriteFile;

/*! ***************************************************************
* ��������       bxDual_cmd_ofsEndFileTransf����
* ��������ip��������IP�� port���������˿�
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ�д�ļ�����
* ע��
* ���ͽ�Ŀ�����
******************************************************************/
typedef int(__stdcall *PbxDual_cmd_ofsEndFileTransf)(Ouint8* ip, Ouint16 port);
	PbxDual_cmd_ofsEndFileTransf bxDual_cmd_ofsEndFileTransf;

/*! ***************************************************************
* ��������       bxDual_cmd_uart_ofsStartFileTransf����
* ��������uartPort�����ڶ˿ںţ� baudRate��������
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ���ʼ����д�ļ�
* ע��
* ���ͽ�Ŀǰ����
******************************************************************/
typedef int(__stdcall *PbxDual_cmd_uart_ofsStartFileTransf)(Oint8* uartPort, Ouint8 baudRate);
	PbxDual_cmd_uart_ofsStartFileTransf bxDual_cmd_uart_ofsStartFileTransf;

/*! ***************************************************************
* ��������       bxDual_cmd_uart_ofsEndFileTransf����
* ��������uartPort�����ڶ˿ںţ� baudRate��������
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ�д�ļ�����
* ע��
* ���ͽ�Ŀ�����
******************************************************************/
typedef int(__stdcall *PbxDual_cmd_uart_ofsEndFileTransf)(Oint8* uartPort, Ouint8 baudRate);
	PbxDual_cmd_uart_ofsEndFileTransf bxDual_cmd_uart_ofsEndFileTransf;

/**************************************************************BX-6***********************************************************************/

/*! ***************************************************************
* ��������       bxDual_program_addProgram_G6(��
* ��������
*	EQprogramHeader_G6���ο��ṹ��EQprogramHeader_G6
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ���ӽ�Ŀ
* ע��
*
******************************************************************/
typedef int(__stdcall *PbxDual_program_addProgram_G6)(EQprogramHeader_G6 *programH);
	PbxDual_program_addProgram_G6 bxDual_program_addProgram_G6;
	
/*! ***************************************************************
* ��������       bxDual_program_addArea_G6����
* ��������areaID�������ID��
*	aheader���ο��ṹ��EQareaHeader_G6
*
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ���Ŀ�������
* ע��
* һ��Ҫ�ο�Э���ÿһ��ֵ�����������������ȥ��������ʾ�϶������Լ���Ҫ��
******************************************************************/
typedef int(__stdcall *PbxDual_program_addArea_G6)(Ouint16 areaID, EQareaHeader_G6 *aheader);
	PbxDual_program_addArea_G6 bxDual_program_addArea_G6;

/*! ***************************************************************
* ��������       bxDual_program_pictureAreaAddPic_G6����
*	areaID�������ID��
*   picID��ͼƬ��ţ���0��ʼ����һ�����ͼƬΪ0���ڶ������ͼƬΪ1�������ۼӣ�ÿ��id��Ӧһ��ͼƬ
*	EQpageHeader_G6���ο��ṹ��EQpageHeader_G6
*	picPath��ͼƬ�ľ���·����ͼƬ����
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ����ͼƬ��ͼ������
* ע����λ������ͼƬ�Ĵ�����picIDһ�£������Ȳ���picIDΪ0��ͼƬ�����β���
*
******************************************************************/
typedef int(__stdcall *PbxDual_program_pictureAreaAddPic_G6)(Ouint16 areaID, Ouint16 picID, EQpageHeader_G6* pheader, Ouint8* picPath);
	PbxDual_program_pictureAreaAddPic_G6 bxDual_program_pictureAreaAddPic_G6;

/*! ***************************************************************
* ��������       bxDual_program_timeAreaAddContent_G6����
*	areaID�������ID��
*   timeData���ο��ṹ��EQtimeAreaData_G56
*
*
* ����ֵ��0 �ɹ��� ����ֵΪ����
* �� �ܣ�ʱ��������ʱ������ݣ�������ο��ṹ��EQtimeAreaData_G56
* ע��
*
******************************************************************/
typedef int(__stdcall *PbxDual_program_timeAreaAddContent_G6)(Ouint16 areaID, EQtimeAreaData_G56* timeData);
	PbxDual_program_timeAreaAddContent_G6 bxDual_program_timeAreaAddContent_G6;

/*! ***************************************************************
* ��������       bxDual_program_timeAreaAddAnalogClock_G6(��
* ��������
*	areaID������ID
*   header: �����EQAnalogClockHeader_G56�ṹ��
*   cStyle: ������ʽ�������E_ClockStyle
*   cColor: ������ɫ�������E_Color_G56ͨ����ö��ֵ����ֱ�������߲�ɫ���������ö�ٷ�Χʹ��RGB888ģʽ
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ�ʱ��������ģ��ʱ��
* ע��
*
******************************************************************/
typedef int(__stdcall *PbxDual_program_timeAreaAddAnalogClock_G6)(Ouint16 areaID, EQAnalogClockHeader_G56 *header, E_ClockStyle cStyle, ClockColor_G56* cColor);
	PbxDual_program_timeAreaAddAnalogClock_G6 bxDual_program_timeAreaAddAnalogClock_G6;

/*! ***************************************************************
* ��������       bxDual_program_picturesAreaAddTxt_G6����
*	areaID�������ID��
*	str����Ҫ��������
*	fontName����������
*	pheader���ο��ṹ��EQpageHeader_G6
*
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ������ֵ�ͼ������
* ע��
* һ��Ҫ�ο�Э���ÿһ��ֵ�����������������ȥ��������ʾ�϶������Լ���Ҫ��
******************************************************************/
typedef int(__stdcall *PbxDual_program_picturesAreaAddTxt_G6)(Ouint16 areaID, Ouint8* str, Ouint8* fontName, EQpageHeader_G6* pheader);
	PbxDual_program_picturesAreaAddTxt_G6 bxDual_program_picturesAreaAddTxt_G6;

/*! ***************************************************************
* ��������       bxDual_program_IntegrateProgramFile_G6����
* ��������
*	program���ο��ṹ��EQprogram_G6
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ��ϳɽ�Ŀ�ļ����ؽ�Ŀ�ļ����Լ���ַ
* ע��
* EQprogram �ṹ���������ص������ļ�����Ҫ����
******************************************************************/
typedef int(__stdcall *PbxDual_program_IntegrateProgramFile_G6)(EQprogram_G6* program);
	PbxDual_program_IntegrateProgramFile_G6 bxDual_program_IntegrateProgramFile_G6;

/*! ***************************************************************
* ��������       bxDual_program_deleteProgram_G6����
* ����ֵ��0 �ɹ��� ����ֵΪ����
* �� �ܣ�ɾ����Ŀ
* ע��
*
******************************************************************/
typedef int(__stdcall *PbxDual_program_deleteProgram_G6)();
	PbxDual_program_deleteProgram_G6 bxDual_program_deleteProgram_G6;

//ͬʱ���¶����̬��:����ʾ��̬��������ʾ��Ŀ
typedef int(__stdcall *PbxDual_dynamicAreaS_AddTxtDetails_6G)(Ouint8* pIP, Ouint32 nPort, E_ScreenColor_G56 color, Ouint8 uAreaCount, DynamicAreaParams* pParams);
	PbxDual_dynamicAreaS_AddTxtDetails_6G bxDual_dynamicAreaS_AddTxtDetails_6G;

//ͬʱ���¶����̬��:�����Ŀ�����������Ŀһ����ʾ
//RelateProNum = 0 ʱ���������н�Ŀ�������н�Ŀһ�𲥷ţ����û�н�Ŀ���򲻲��Ÿö�̬����
//			   > 0 ʱ, ָ��������Ŀ��Ҫ�����Ľ�ĿID�����RelateProSerial[]�У�
typedef int(__stdcall *PbxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G)(Ouint8* pIP, Ouint32 nPort, E_ScreenColor_G56 color, Ouint8 uAreaCount, DynamicAreaParams* pParams, Ouint16 RelateProNum, Ouint16* RelateProSerial);
	PbxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G bxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G;

//���¶�̬��ͼƬ������ʾ��̬��;
typedef int(__stdcall *PbxDual_dynamicAreaS_AddAreaPic_6G)(Ouint8* pIP, Ouint32 nPort, E_ScreenColor_G56 color, Ouint8 uAreaCount, DynamicAreaParams* pParams);
	PbxDual_dynamicAreaS_AddAreaPic_6G bxDual_dynamicAreaS_AddAreaPic_6G;

//��̬��ͼƬ������Ŀ: 
//RelateProNum = 0 ʱ���������н�Ŀ�������н�Ŀһ�𲥷ţ����û�н�Ŀ���򲻲��Ÿö�̬����
//			   > 0 ʱ, ָ��������Ŀ��Ҫ�����Ľ�ĿID�����RelateProSerial[]�У�
typedef int(__stdcall *PbxDual_dynamicAreaS_AddAreaPic_WithProgram_6G)(Ouint8* pIP, Ouint32 nPort, E_ScreenColor_G56 color, Ouint8 uAreaCount, DynamicAreaParams* pParams, Ouint16 RelateProNum, Ouint16* RelateProSerial);
	PbxDual_dynamicAreaS_AddAreaPic_WithProgram_6G bxDual_dynamicAreaS_AddAreaPic_WithProgram_6G;

/*
ɾ����̬����ɾ��������̬����
uAreaId = 0xff:ɾ����������
*/
typedef int(__stdcall *PbxDual_dynamicArea_DelArea_6G)(Ouint8* pIP, Ouint32 nPort, Oint8 uAreaId);
	PbxDual_dynamicArea_DelArea_6G bxDual_dynamicArea_DelArea_6G;
/*
���ܣ�ɾ�������̬����
������
pAreaID-���Ҫɾ���Ķ�̬��ID���飻
uAreaCount-��̬��ID�����еĸ�����
*/
typedef int(__stdcall *PbxDual_dynamicArea_DelAreas_6G)(Ouint8* pIP, Ouint32 nPort, Oint8 uAreaCount, Oint8* pAreaID);
	PbxDual_dynamicArea_DelAreas_6G bxDual_dynamicArea_DelAreas_6G;

	/***********************************************************BX-5**********************************************************/

/*! ***************************************************************
* ��������       bxDual_program_addProgram����
*	programH���ο��ṹ��EQprogramHeader
* ����ֵ��0 �ɹ��� ����ֵΪ����
* �� �ܣ���ӽ�Ŀ���
* ע��
* һ��Ҫ�ο�Э���ÿһ��ֵ�����������������ȥ��������ʾ�϶������Լ���Ҫ��
******************************************************************/
typedef int(__stdcall *PbxDual_program_addProgram)(EQprogramHeader *programH); //��ӽ�Ŀ���
	PbxDual_program_addProgram bxDual_program_addProgram;

/*! ***************************************************************
* ��������       bxDual_program_addArea_G6����
* ��������areaID�������ID��
*	aheader���ο��ṹ��EQareaHeader_G6
*
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ���Ŀ�������
* ע��
* һ��Ҫ�ο�Э���ÿһ��ֵ�����������������ȥ��������ʾ�϶������Լ���Ҫ��
******************************************************************/
typedef int(__stdcall *PbxDual_program_AddArea)(Ouint16 areaID, EQareaHeader *aheader);
	PbxDual_program_AddArea bxDual_program_AddArea;
	
/*! ***************************************************************
* ��������       bxDual_program_picturesAreaAddTxt����
*	areaID�������ID��
*	str����Ҫ�����ַ�
*	fontName����������
*	pheader���ο��ṹ��EQpageHeader
*
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ����ַ���ͼ����
* ע��
* һ��Ҫ�ο�Э���ÿһ��ֵ�����������������ȥ��������ʾ�϶������Լ���Ҫ��
******************************************************************/
typedef int(__stdcall *PbxDual_program_picturesAreaAddTxt)(Ouint16 areaID, Ouint8* str, Ouint8* fontName, EQpageHeader* pheader);//���ַ�������
	PbxDual_program_picturesAreaAddTxt bxDual_program_picturesAreaAddTxt;
	
/*! ***************************************************************
* ��������       bxDual_program_pictureAreaAddPic_G6����
*	areaID�������ID��
*   picID��ͼƬ��ţ���0��ʼ����һ�����ͼƬΪ0���ڶ������ͼƬΪ1�������ۼӣ�ÿ��id��Ӧһ��ͼƬ
*	EQpageHeader_G6���ο��ṹ��EQpageHeader_G6
*	picPath��ͼƬ�ľ���·����ͼƬ����
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ����ͼƬ��ͼ������
* ע����λ������ͼƬ�Ĵ�����picIDһ�£������Ȳ���picIDΪ0��ͼƬ�����β���
*
******************************************************************/
typedef int(__stdcall *PbxDual_program_pictureAreaAddPic)(Ouint16 areaID, Ouint16 picID, EQpageHeader* pheader, Ouint8* picPath);
	PbxDual_program_pictureAreaAddPic bxDual_program_pictureAreaAddPic;

/*! ***************************************************************
* ��������       bxDual_program_timeAreaAddContent()
*	areaID�������ID��
*   timeData:�������ʱ�������ݸ�ʽ�ṹ��EQtimeAreaData_G56
*
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ�ʱ������������
* ע��
*
******************************************************************/
typedef int(__stdcall *PbxDual_program_timeAreaAddContent)(Ouint16 areaID, EQtimeAreaData_G56* timeData);
	PbxDual_program_timeAreaAddContent bxDual_program_timeAreaAddContent;

/*! ***************************************************************
* ��������       bxDual_program_timeAreaAddAnalogClock_G6(��
* ��������
*	areaID������ID
*   header: �����EQAnalogClockHeader_G56�ṹ��
*   cStyle: ������ʽ�������E_ClockStyle
*   cColor: ������ɫ�������E_Color_G56ͨ����ö��ֵ����ֱ�������߲�ɫ���������ö�ٷ�Χʹ��RGB888ģʽ
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ�ʱ��������ģ��ʱ��
* ע��
*
******************************************************************/
typedef int(__stdcall *PbxDual_program_timeAreaAddAnalogClock)(Ouint16 areaID, EQAnalogClockHeader_G56 *header, E_ClockStyle cStyle, ClockColor_G56* cColor);
	PbxDual_program_timeAreaAddAnalogClock bxDual_program_timeAreaAddAnalogClock;

/*! ***************************************************************
* ��������       bxDual_program_IntegrateProgramFile_G6����
* ��������
*	program���ο��ṹ��EQprogram_G6
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ��ϳɽ�Ŀ�ļ����ؽ�Ŀ�ļ����Լ���ַ
* ע��
* EQprogram �ṹ���������ص������ļ�����Ҫ����
******************************************************************/
typedef int(__stdcall *PbxDual_program_IntegrateProgramFile)(EQprogram* program);
	PbxDual_program_IntegrateProgramFile bxDual_program_IntegrateProgramFile;

/*! ***************************************************************
* ��������       bxDual_program_deleteProgram����
* ����ֵ��0 �ɹ��� ����ֵΪ����
* �� �ܣ�ɾ����Ŀ
* ע��
*
******************************************************************/
typedef int(__stdcall *PbxDual_program_deleteProgram)();
	PbxDual_program_deleteProgram bxDual_program_deleteProgram;
/*
����˵��������һ���ļ���Ϣ��ָ���Ķ�̬���������Թ��������̬����ָ���Ľ�Ŀ�������ο���Ϣ�μ� ����� 6�����ƿ���̬������ ���� bxDual_dynamicArea_AddAreaTxt_6G �����˵����
����˵����
strAreaTxtContent - ��̬������Ҫ��ʾ���ı�����
*/
typedef int(__stdcall *PbxDual_dynamicArea_AddAreaWithTxt_5G)(Ouint8* pIP, Ouint32 nPort, E_ScreenColor_G56 color,Ouint8 uAreaId,Ouint8 RunMode,Ouint16 Timeout,Ouint8 RelateAllPro,Ouint16 RelateProNum,
	Ouint16* RelateProSerial,Ouint8 ImmePlay,Ouint16 uAreaX, Ouint16 uAreaY, Ouint16 uWidth, Ouint16 uHeight,EQareaframeHeader oFrame,Ouint8 DisplayMode,Ouint8 ClearMode,Ouint8 Speed,Ouint16 StayTime,
	Ouint8 RepeatTime,EQfontData oFont,Ouint8* fontName,Ouint8* strAreaTxtContent);
PbxDual_dynamicArea_AddAreaWithTxt_5G bxDual_dynamicArea_AddAreaWithTxt_5G;

/*
����˵��������һ��ͼƬ��ָ���Ķ�̬���������Թ��������̬����ָ���Ľ�Ŀ��
*/
typedef int(__stdcall *PbxDual_dynamicArea_AddAreaWithPic_5G)(Ouint8* pIP, Ouint32 nPort, E_ScreenColor_G56 color,Ouint8 uAreaId,Ouint8 RunMode,Ouint16 Timeout,Ouint8 RelateAllPro,Ouint16 RelateProNum,
	Ouint16* RelateProSerial,Ouint8 ImmePlay,Ouint16 uAreaX, Ouint16 uAreaY, Ouint16 uWidth, Ouint16 uHeight,EQareaframeHeader oFrame,Ouint8 DisplayMode,Ouint8 ClearMode,Ouint8 Speed,Ouint16 StayTime,
	Ouint8 RepeatTime,Ouint8* filePath);
	PbxDual_dynamicArea_AddAreaWithPic_5G bxDual_dynamicArea_AddAreaWithPic_5G;


	
/*! ***************************************************************
* ��������       cmd_coerceOnOff����
* ��������ip��������IP�� port���������˿ڣ�onOff��������״̬��0x01 �C���� 0x00 �C�ػ�
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ�ǿ�ƿ��һ�����
* ע��
*
******************************************************************/
typedef int(__stdcall *PbxDual_cmd_coerceOnOff)(Ouint8* ip, Ouint16 port, Ouint8 onOff);
	PbxDual_cmd_coerceOnOff bxDual_cmd_coerceOnOff;

/*! ***************************************************************
* ��������       cmd_timingOnOff����
* ��������ip��������IP�� port���������˿ڣ�groupNum���м��鶨ʱ���ػ� data��TimingOnOff�ṹ��ĵ�ַ
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ���ʱ���ػ�����
* ע��
* groupNumֵ��n�����,data��С = n * TimingOnOff
******************************************************************/
typedef int(__stdcall *PbxDual_cmd_timingOnOff)(Ouint8* ip, Ouint16 port, Ouint8 groupNum, Ouint8 *data);
	PbxDual_cmd_timingOnOff bxDual_cmd_timingOnOff;

/*! ***************************************************************
* ��������       cmd_cancelTimingOnOff����
* ��������ip��������IP�� port���������˿�
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ�ȡ����ʱ���ػ�
* ע��
*
******************************************************************/
typedef int(__stdcall *PbxDual_cmd_cancelTimingOnOff)(Ouint8* ip, Ouint16 port);
	PbxDual_cmd_cancelTimingOnOff bxDual_cmd_cancelTimingOnOff;

/*! ***************************************************************
* ��������       cmd_setBrightness����
* ��������ip��������IP�� port���������˿ڣ� brightness�����ȶȱ�
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ��������Ⱥ����ģʽ
* ע��
* �ο�Э���Ӧÿһ�����ע���һ���ֽ�ģʽ������
******************************************************************/
typedef int(__stdcall *PbxDual_cmd_setBrightness)(Ouint8* ip, Ouint16 port, Brightness *brightness);
	PbxDual_cmd_setBrightness bxDual_cmd_setBrightness;

/*! ***************************************************************
* ��������       cmd_readControllerID����
* ��������ip��������IP�� port���������˿ڣ� ControllerID�����ؿ�����ID
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ���������ID
* ע��
* ControllerID��8���ֽ� �붨��char data[8];
******************************************************************/
typedef int(__stdcall *PbxDual_cmd_readControllerID)(Ouint8* ip, Ouint16 port, Ouint8 *ControllerID);
	PbxDual_cmd_readControllerID bxDual_cmd_readControllerID;

/*! ***************************************************************
* ��������       cmd_screenLock����
* ��������ip��������IP�� port���������˿�
*         nonvolatile��״̬�Ƿ���籣�� 0x00 �C���粻���� 0x01 �C���籣��
*         lock�� 0x00 �C����  0x01 �C����
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ���Ļ����
* ע��
*
******************************************************************/
typedef int(__stdcall *PbxDual_cmd_screenLock)(Ouint8* ip, Ouint16 port, Ouint8 nonvolatile, Ouint8 lock);
	PbxDual_cmd_screenLock bxDual_cmd_screenLock;

/*! ***************************************************************
* ��������       cmd_programLock����
* ��������ip��������IP�� port���������˿�
*         nonvolatile�� ״̬�Ƿ���籣�� 0x00 �C���粻����  0x01 �C���籣��
*         lock��0x00 �C����  0x01 �C����
*         name�� ��Ŀ����4��byte�����ֽ�
*         lockDuration: ��Ŀ����ʱ�䳤�ȣ� ��λΪ 10 ���룬 ��
*         �統��ֵΪ 100 ʱ��ʾ������Ŀ 1 ��.ע�⣺ ����ֵΪ 0xffffffff ʱ��ʾ��Ŀ������ʱ�䳤������
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ���Ŀ����
* ע��
* ����ʹ�÷����ο�Э��
******************************************************************/
typedef int(__stdcall *PbxDual_cmd_programLock)(Ouint8* ip, Ouint16 port, Ouint8 nonvolatile, Ouint8 lock, Ouint8 *name, Ouint32 lockDuration);
	PbxDual_cmd_programLock bxDual_cmd_programLock;

/*! ***************************************************************
* ��������       cmd_check_controllerStatus����
* ��������ip��������IP�� port���������˿ڣ� controllerStatus����ο��ṹ��ControllerStatus_G56
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ���������״̬
* ע��
* ControllerStatus_G56��Э��ʱ��Ӧ�Ŀ��Բο�Э��ľ����÷�
******************************************************************/
typedef int(__stdcall *PbxDual_cmd_check_controllerStatus)(Ouint8* ip, Ouint16 port, ControllerStatus_G56 *controllerStatus);
	PbxDual_cmd_check_controllerStatus bxDual_cmd_check_controllerStatus;

/*! ***************************************************************
* ��������       cmd_setPassword����
* ��������ip��������IP�� port���������˿ڣ� oldPassword�������룬 newPassword������
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ����ÿ���������
* ע��
* ���ú�һ��Ҫ��ס�����ú�Ͳ���������ͨѶ
******************************************************************/
typedef int(__stdcall *PbxDual_cmd_setPassword)(Ouint8* ip, Ouint16 port, Ouint8 *oldPassword, Ouint8 *newPassword);
	PbxDual_cmd_setPassword bxDual_cmd_setPassword;

/*! ***************************************************************
* ��������       cmd_deletePassword����
* ��������ip��������IP�� port���������˿ڣ� password�������ǰ��������
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ�ɾ����ǰ����������
* ע��
*
******************************************************************/
typedef int(__stdcall *PbxDual_cmd_deletePassword)(Ouint8* ip, Ouint16 port, Ouint8 *password);
	PbxDual_cmd_deletePassword bxDual_cmd_deletePassword;

/*! ***************************************************************
* ��������       cmd_setDelayTime����
* ��������ip��������IP�� port���������˿ڣ� delayTime��������ʱ��λ��
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ����ÿ��ƿ�����ʱʱ��
* ע��
*
******************************************************************/
typedef int(__stdcall *PbxDual_cmd_setDelayTime)(Ouint8* ip, Ouint16 port, short delayTime);
	PbxDual_cmd_setDelayTime bxDual_cmd_setDelayTime;

/*! ***************************************************************
* ��������       cmd_setBtnFunc����
* ��������ip��������IP�� port���������˿ڣ� btnMode����ťģʽ 0x00�C���԰�ť 0x01 �C�ش����л���Ŀ 0x02 �C��ƽ�����л���Ŀ
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ����ÿ��Ʋ��԰�ť����
* ע��
* ����ϸ�ڲο�Э��
******************************************************************/
typedef int(__stdcall *PbxDual_cmd_setBtnFunc)(Ouint8* ip, Ouint16 port, Ouint8 btnMode);
	PbxDual_cmd_setBtnFunc bxDual_cmd_setBtnFunc;

/*! ***************************************************************
* ��������       cmd_setTimingReset����
* ��������ip��������IP�� port���������˿ڣ� cmdData���ο��ṹ��TimingReset
* ����ֵ��0 �ɹ��� ����ֵΪ�����
* �� �ܣ����ÿ�����������ʱ��
* ע��
* ����ϸ�ڲο�Э��
******************************************************************/
typedef int(__stdcall *PbxDual_cmd_setTimingReset)(Ouint8* ip, Ouint16 port, TimingReset *cmdData);
	PbxDual_cmd_setTimingReset bxDual_cmd_setTimingReset;


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
void Net_Bright(Ouint8* ipAdder,byte num);
void Creat_sound_6(Ouint16 areaID);
void Reset(Ouint8* ipAdder);
void coerceOnOff(Ouint8* ipAdder);
void timingOnOff(Ouint8* ipAdder);
void screenLock(Ouint8* ipAdder);
void programLock(Ouint8* ipAdder);

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
	
	bxDual_cmd_coerceOnOff = (PbxDual_cmd_coerceOnOff)GetProcAddress(hdll,"bxDual_cmd_coerceOnOff");
	bxDual_cmd_timingOnOff = (PbxDual_cmd_timingOnOff)GetProcAddress(hdll,"bxDual_cmd_timingOnOff");
	bxDual_cmd_coerceOnOff = (PbxDual_cmd_coerceOnOff)GetProcAddress(hdll,"bxDual_cmd_coerceOnOff");
	bxDual_cmd_cancelTimingOnOff = (PbxDual_cmd_cancelTimingOnOff)GetProcAddress(hdll,"bxDual_cmd_cancelTimingOnOff");
	bxDual_cmd_setBrightness = (PbxDual_cmd_setBrightness)GetProcAddress(hdll,"bxDual_cmd_setBrightness");
	bxDual_cmd_readControllerID = (PbxDual_cmd_readControllerID)GetProcAddress(hdll,"bxDual_cmd_readControllerID");
	bxDual_cmd_screenLock = (PbxDual_cmd_screenLock)GetProcAddress(hdll,"bxDual_cmd_screenLock");
	bxDual_cmd_programLock = (PbxDual_cmd_programLock)GetProcAddress(hdll,"bxDual_cmd_programLock");
	bxDual_cmd_check_controllerStatus = (PbxDual_cmd_check_controllerStatus)GetProcAddress(hdll,"bxDual_cmd_check_controllerStatus");
	bxDual_cmd_setPassword = (PbxDual_cmd_setPassword)GetProcAddress(hdll,"bxDual_cmd_setPassword");
	bxDual_cmd_deletePassword = (PbxDual_cmd_deletePassword)GetProcAddress(hdll,"bxDual_cmd_deletePassword");
	bxDual_cmd_setBtnFunc = (PbxDual_cmd_setBtnFunc)GetProcAddress(hdll,"bxDual_cmd_setBtnFunc");
	bxDual_cmd_setDelayTime = (PbxDual_cmd_setDelayTime)GetProcAddress(hdll,"bxDual_cmd_setDelayTime");
	bxDual_cmd_setTimingReset = (PbxDual_cmd_setTimingReset)GetProcAddress(hdll,"bxDual_cmd_setTimingReset");



	
	unsigned char ip[] = "192.168.89.182";
	unsigned short port = 5005;
	int ret = 0;
	ret = bxDual_InitSdk();//��ʼ����̬��
	addAreaPicturePic_G5(1);
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


//��ӽ�Ŀ
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
//�������
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
//���ʱ������
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
	timeData2.fontAlign = 1;  //0--����룬1-���У�2-�Ҷ���
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
	strcpy((Oint8*)timeData.fontName,"����");
	timeData.fontSize = 12;
	timeData.fontBold = 0;
	timeData.fontItalic = 0;
	timeData.fontUnderline = 0;
	timeData.fontAlign = 1;  //0--����룬1-���У�2-�Ҷ���
	timeData.date_enable = true;
	timeData.datestyle = (E_DateStyle)eYYYY_MM_DD_CHS;//eMM_DD_CHS;// //eYYYY_MM_DD_VIRGURE;// 
	timeData.week_enable = false;
	timeData.weekstyle = (E_WeekStyle)eMonday_CHS;
	timeData.time_enable = true;
	timeData.timestyle = (E_TimeStyle)eHH_MM_SS_COLON;
	bxDual_program_timeAreaAddContent_G6(AreaID,&timeData);
}
//����ı�
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
	bxDual_program_picturesAreaAddTxt(0, str,(Ouint8*)"����",&pheader);
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
	
	bxDual_program_picturesAreaAddTxt_G6(AreaID,str1,(Ouint8*)"����",&pheader1);
	//program_fontPath_picturesAreaAddTxt_G6(0,str,(Ouint8*)"C:/Windows/Fonts/simsun.ttc",&pheader1);
}
//���ͼƬ
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
	unsigned char str[] = "32.png";
    int err = bxDual_program_pictureAreaAddPic(areaID, 0, &pheader, str);
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
    Ouint8* img = (Ouint8*)"K:/onbon/ͼƬ�����ļ�/3232c.png";
    int err = bxDual_program_pictureAreaAddPic_G6(areaID, 0, &pheader, img);
}
//���ͽ�Ŀ
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

	//ɾ�������ڴ��еĽ�Ŀ
	bxDual_program_deleteProgram_G6();

}
//void tcp_com_program_G5(Ouint8* com)
//{
//	Oint8 ret;
//	ret = bxDual_cmd_uart_ofsStartFileTransf(com, 2);
//	printf("tcp_send_program_G5L:cmd_ofsStartFileTransf===== %d \n", ret);
//	if(ret != 0){
//		printf("cmd_ofsStartFileTransf run error...");
//	}else{
//		printf("cmd_ofsStartFileTransf run succeed...");
//	}
//
//	EQprogram program;
//	memset((void*)&program, 0, sizeof(program));
//	bxDual_program_IntegrateProgramFile(&program);
//
//	ret = bxDual_cmd_uart_ofsWriteFile(com, 2, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
//	if(ret != 0){
//		printf("cmd_ofsWriteFile run error...");
//	}else{
//		printf("cmd_ofsWriteFile run succeed...");
//	}
//	printf("tcp_send_program_G5:cmd_ofsWriteFile===== %d \n", ret);
//	printf("fileName_G5 == %s \n", program.fileName);
//	printf("fileType_G5 == %d \n", program.fileType);
//	printf("fileLen_G5 == %d \n", program.fileLen);
//	printf("fileCRC32_G5 == %d \n",program.fileCRC32);
//	ret = bxDual_cmd_uart_ofsEndFileTransf(com, 2);
//	if(ret != 0){
//		printf("cmd_ofsEndFileTransf run error...");
//	}else{
//		printf("cmd_ofsEndFileTransf run succeed...");
//	}
//	printf("tcp_send_program_G5:md_ofsWriteFile===== %d \n", ret);
//	
//}
//void tcp_com_program_G6(Ouint8* com)
//{
//	Oint8 ret;
//	EQprogram_G6 program;
//	memset((void*)&program, 0, sizeof(program));
//	bxDual_program_IntegrateProgramFile_G6(&program);
//	
//	ret = bxDual_cmd_uart_ofsStartFileTransf(com, 2);
//	printf("ret =====cmd_ofsStartFileTransf===== %d \n", ret);
//	if(ret != 0){
//		printf("cmd_ofsStartFileTransf run error...");
//	}else{
//		printf("cmd_ofsStartFileTransf run succeed...");
//	}
//
//	ret = bxDual_cmd_uart_ofsWriteFile(com, 2, program.dfileName, program.dfileType, program.dfileLen, 1, program.dfileAddre);
//	if(ret != 0){
//		printf("cmd_ofsWriteFile run error...");
//	}else{
//		printf("cmd_ofsWriteFile run succeed...");
//	}
//	printf("ret =====cmd_ofsWriteFile===== %d \n", ret);
//
//	ret = bxDual_cmd_uart_ofsWriteFile(com, 2, program.fileName, program.fileType, program.fileLen, 1, program.fileAddre);
//	if(ret != 0){
//		printf("cmd_ofsWriteFile run error...");
//	}else{
//		printf("cmd_ofsWriteFile run succeed...");
//	}
//	printf("ret =====cmd_ofsWriteFile===== %d \n", ret);
//
//	ret = bxDual_cmd_uart_ofsEndFileTransf(com, 2);
//	if(ret != 0){
//		printf("cmd_ofsEndFileTransf run error...");
//	}else{
//		printf("cmd_ofsEndFileTransf run succeed...");
//	}
//	printf("ret =====cmd_ofsEndFileTransf===== %d \n", ret);
//
//	//ɾ�������ڴ��еĽ�Ŀ
//	bxDual_program_deleteProgram_G6();
//
//}
//BX-5��̬���ı�
//void dynamicArea_test_5(Ouint8* ip)
//{
//	EQareaframeHeader Frame;
//                    Frame.AreaFFlag = 0;
//                    Frame.AreaFDispStyle = 0;
//                    Frame.AreaFDispSpeed = 0;
//                    Frame.AreaFMoveStep = 0;
//                    Frame.AreaFWidth = 0;
//                    Frame.AreaFBackup = 0;
//	EQfontData oFont;
//            oFont.arrMode = eSINGLELINE;
//            oFont.fontSize = 10;
//            oFont.color = eRED;
//            oFont.fontBold = false;
//            oFont.fontItalic = false;
//            oFont.tdirection = pNORMAL;
//            oFont.txtSpace = 0;
//            oFont.Valign = 0;
//            oFont.Halign = 0;
//	Ouint16 uRelateProgID[1];  uRelateProgID[0] = 0;
//	bxDual_dynamicArea_AddAreaWithTxt_5G(ip, 5005, eSCREEN_COLOR_FULLCOLOR, 1, 0, 0, 1, 0, uRelateProgID,
//                            1, 0, 0, 64, 32, Frame, 4, 0, 10, 100, 0, oFont, (Ouint8*)"����", (Ouint8*)"һ��");
//	printf("err =====bxDual_dynamicArea_AddAreaWithTxt_5G===== %d \n", err);
//}
//BX-6��̬���ı�
void dynamicArea_test_6(Ouint8* ip)
{
	EQareaHeader_G6 oAreaHeader_G6;
	oAreaHeader_G6.AreaType = 0x10; //0x10 ��̬����

	oAreaHeader_G6.AreaX = 0;
	oAreaHeader_G6.AreaY = 0;
	oAreaHeader_G6.AreaWidth = 32;	
	oAreaHeader_G6.AreaHeight = 32;	
	//AreaFrame N ����߿����ԣ���ϸ�ο�
	oAreaHeader_G6.BackGroundFlag = 0x00;
	oAreaHeader_G6.Transparency = 101;
	oAreaHeader_G6.AreaEqual = 0x00;

	Ouint8* strSoundTxt = (Ouint8*)"���";
	Ouint8 nSize = sizeof(strSoundTxt);
	Ouint8 nStrLen = strlen((const char*)strSoundTxt);
	oAreaHeader_G6.stSoundData.SoundDataLen = nStrLen;		// 4 �������ݳ���; ֻ�� SoundFlag���Ƿ�ʹ���������ţ�Ϊ 1 ʱ�ŷ��͸��ֽڣ����򲻷���
	oAreaHeader_G6.stSoundData.SoundData = strSoundTxt;			// N ��������ֻ�� SoundFlag���Ƿ�ʹ���������ţ�Ϊ 1 ʱ�ŷ��͸��ֽڣ����򲻷���

	{
		oAreaHeader_G6.stSoundData.SoundFlag = 0x00;	//1 0x00 �Ƿ�ʹ����������;0 ��ʾ��ʹ������; 1 ��ʾ����������;
		oAreaHeader_G6.stSoundData.SoundPerson = 0x01;	//1 0x00 ������ ��ֵ��Χ�� 0 - 5���� 6 ��ѡ��ֻ�� SoundFlag���Ƿ�ʹ���������ţ�Ϊ 1 ʱ�ŷ��͸��ֽڣ����򲻷��͸�ֵĬ��Ϊ 0
		oAreaHeader_G6.stSoundData.SoundVolum = 1;		//1 0x05 ������ֵ��Χ�� 0~10���� 11 �֣�0��ʾ����ֻ�� SoundFlag���Ƿ�ʹ���������ţ�Ϊ 1 ʱ�ŷ��͸��ֽڣ����򲻷��͸�ֵĬ��Ϊ 5
		oAreaHeader_G6.stSoundData.SoundSpeed = 0x2;	//1 0x05 ���ٸ�ֵ��Χ�� 0~10���� 11 ��ֻ�� SoundFlag���Ƿ�ʹ���������ţ�Ϊ 1 ʱ�ŷ��͸��ֽڣ����򲻷��͸�ֵĬ��Ϊ 5
		oAreaHeader_G6.stSoundData.SoundDataMode = 0x00;//1 0x00 SoundData �ı����ʽ����ֵ�������£�0x00 GB2312; 0x01 GBK; 0x02 BIG5; 0x03 UNICODEֻ�� SoundFlag���Ƿ�ʹ���������ţ�Ϊ 1 ʱ�ŷ��͸��ֽڣ����򲻷���
		oAreaHeader_G6.stSoundData.SoundReplayTimes = 0x01;// 0xffffffff;	//4 0x00000000 �ز�������ֵΪ 0����ʾ���� 1 �θ�ֵΪ 1����ʾ���� 2 ��
		//......
		//��ֵΪ 0xffffffff����ʾ�������޴�ֻ�� SoundFlag���Ƿ�ʹ���ﲥ�ţ�Ϊ 1 ʱ�ŷ��͸��ֽڣ����򲻷��͸�ֵĬ��Ϊ 0
		oAreaHeader_G6.stSoundData.SoundReplayDelay = 200;	//4 0x00000000 �ز�ʱ������ֵ��ʾ���β���������ʱ��������λΪ 10msֻ�� SoundFlag���Ƿ�ʹ���������ţ�Ϊ 1 ʱ�ŷ��͸��ֽڣ����򲻷��͸�ֵĬ��Ϊ 0
		oAreaHeader_G6.stSoundData.SoundReservedParaLen = 0x03;//1 0x03 ��������������������
		oAreaHeader_G6.stSoundData.Soundnumdeal = 0x00;		//1 0 0���Զ��ж�1�����������봦�� 2����������ֵ����ֻ�е� SoundFlag Ϊ 1 ��SoundReservedParaLen��Ϊ 0�ŷ��ʹ˲���
		oAreaHeader_G6.stSoundData.Soundlanguages = 0x00;		// 1 0 0���Զ��ж�����1�����������֡�������λ��������ŵȺϳ�Ϊ����2�����������֡�������λ��������ŵȺϳ�ΪӢ��ֻ�е� SoundFlag Ϊ 1 �� SoundReservedParaLen��Ϊ 0�ŷ��ʹ˲�����Ŀǰֻ֧����Ӣ�ģ�
		oAreaHeader_G6.stSoundData.Soundwordstyle = 0x00;		// 1 0 0���Զ��жϷ�����ʽ1����ĸ������ʽ2�����ʷ�����ʽֻ�е� SoundFlag Ϊ 1 ��SoundReservedParaLen��Ϊ 0�ŷ��ʹ˲���
		oAreaHeader_G6.stSoundData.SoundDataLen = nStrLen;		// 4 �������ݳ���; ֻ�� SoundFlag���Ƿ�ʹ���������ţ�Ϊ 1 ʱ�ŷ��͸��ֽڣ����򲻷���
		oAreaHeader_G6.stSoundData.SoundData = strSoundTxt;			// N ��������ֻ�� SoundFlag���Ƿ�ʹ���������ţ�Ϊ 1 ʱ�ŷ��͸��ֽڣ����򲻷���

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
		oAreaParams_1.strAreaTxtContent = (Ouint8*)"һ��������3����̬��������abcdefghijklmnopqrst......"; //(Ouint8*)"1�л����񹲺͹���ӭ����";
		oAreaParams_1.fontName = (Ouint8*)"����";
		DynamicAreaParams arrParams[1];
		arrParams[0] = oAreaParams_1;
	err = bxDual_dynamicAreaS_AddTxtDetails_6G(ip, 5005, eSCREEN_COLOR_FULLCOLOR, 1, arrParams);
	printf("err =====dynamicArea_AddAreaTxtDetails_WithProgram_6G===== %d \n", err);
}
        //��������
//void Net_Bright(Ouint8* ipAdder,byte num)
//{
//    Brightness brightnes;
//    brightnes.BrightnessMode=0;
//    brightnes.HalfHourValue0 = num;
//    brightnes.HalfHourValue1 = num;
//    brightnes.HalfHourValue2 = num;
//    brightnes.HalfHourValue3 = num;
//    brightnes.HalfHourValue4 = num;
//    brightnes.HalfHourValue5 = num;
//    brightnes.HalfHourValue6 = num;
//    brightnes.HalfHourValue7 = num;
//    brightnes.HalfHourValue8 = num;
//    brightnes.HalfHourValue9 = num;
//    brightnes.HalfHourValue10 = num;
//    brightnes.HalfHourValue11 = num;
//    brightnes.HalfHourValue12 = num;
//    brightnes.HalfHourValue13 = num;
//    brightnes.HalfHourValue14 = num;
//    brightnes.HalfHourValue15 = num;
//    brightnes.HalfHourValue16 = num;
//    brightnes.HalfHourValue17 = num;
//    brightnes.HalfHourValue18 = num;
//    brightnes.HalfHourValue19 = num;
//    brightnes.HalfHourValue20 = num;
//    brightnes.HalfHourValue21 = num;
//    brightnes.HalfHourValue22 = num;
//    brightnes.HalfHourValue23 = num;
//    brightnes.HalfHourValue24 = num;
//    brightnes.HalfHourValue25 = num;
//    brightnes.HalfHourValue26 = num;
//    brightnes.HalfHourValue27 = num;
//    brightnes.HalfHourValue28 = num;
//    brightnes.HalfHourValue29 = num;
//    brightnes.HalfHourValue30 = num;
//    brightnes.HalfHourValue31 = num;
//    brightnes.HalfHourValue32 = num;
//    brightnes.HalfHourValue33 = num;
//    brightnes.HalfHourValue34 = num;
//    brightnes.HalfHourValue35 = num;
//    brightnes.HalfHourValue36 = num;
//    brightnes.HalfHourValue37 = num;
//    brightnes.HalfHourValue38 = num;
//    brightnes.HalfHourValue39 = num;
//    brightnes.HalfHourValue40 = num;
//    brightnes.HalfHourValue41 = num;
//    brightnes.HalfHourValue42 = num;
//    brightnes.HalfHourValue43 = num;
//    brightnes.HalfHourValue44 = num;
//    brightnes.HalfHourValue45 = num;
//    brightnes.HalfHourValue46 = num;
//    brightnes.HalfHourValue47 = num;
//
//    int err = bxDual_cmd_setBrightness(ipAdder, 5005, brightnes);
//}
        //�������
//void Creat_sound_6(Ouint16 areaID)
//{
//	EQPicAreaSoundHeader_G6 pheader;
//	pheader.SoundPerson=3;
//	pheader.SoundVolum=5;
//	pheader.SoundSpeed=5;
//	pheader.SoundDataMode=0;
//	pheader.SoundReplayTimes=0;
//	pheader.SoundReplayDelay=1000;
//	pheader.SoundReservedParaLen=3;
//	pheader.Soundnumdeal = 1;
//	pheader.Soundlanguages = 1;
//	pheader.Soundwordstyle = 1;
//	int err = bxDual_program_pictureAreaEnableSound_G6(areaID, pheader, (Ouint8*)"��������1�Ŵ���ȡҩ");
//}
////ϵͳ��λ
//void Reset(Ouint8* ipAdder)
//{
//int err = bxDual_cmd_sysReset(ipAdder, 5005);
//}
////ǿ�ƿ��ػ�
//void coerceOnOff(Ouint8* ipAdder)
//{
//	int err = bxDual_cmd_coerceOnOff(ipAdder, 5005, 0);//�ػ�
//	//int err = bxDual_cmd_coerceOnOff(ipAdder, 5005, 1);//����
//}
////��ʱ���ػ�
//void timingOnOff(Ouint8* ipAdder) 
//{
//	TimingOnOff[] time;
//	time[0].onHour=0x06;   // ����Сʱ
//	time[0].onMinute = 0x10; // ��������
//	time[0].offHour = 0x10;  // �ػ�Сʱ
//	time[0].offMinute = 0x10; // �ػ�����
//	int err = bxDual_cmd_timingOnOff(ipAdder, 5005, 1,time);
//	//ȡ����ʱ���ػ�
//	err = bx_sdk_dual.bxDual_cmd_cancelTimingOnOff(ipAdder, 5005);
//}
////��Ļ����
//void screenLock(Ouint8* ipAdder)
//{
//	int err = bx_sdk_dual.bxDual_cmd_screenLock(ipAdder, 5005, 1, 1);//��Ļ����
//	//int err = bx_sdk_dual.bxDual_cmd_screenLock(ipAdder, 5005, 1,0);//��Ļ����
//}
////��Ŀ����
//void programLock(Ouint8* ipAdder)
//{
//	int err = bx_sdk_dual.bxDual_cmd_programLock(ipAdder, 5005, 1, 1, (Ouint8*)"P000", 0xffffffff);//����
//	//int err = bx_sdk_dual.bxDual_cmd_programLock(ipAdder, 5005, 1,0, (Ouint8*)"P000", 0xffffffff);//��
//}
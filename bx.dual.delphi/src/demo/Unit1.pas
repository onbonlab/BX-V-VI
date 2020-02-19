unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type

  //�� ����ɫ  ˫��ɫ  �߲�ɫ  ȫ��ɫ
  TE_ScreenColor_G56 = (eSCREEN_COLOR_NONE, eSCREEN_COLOR_SINGLE,
    eSCREEN_COLOR_DOUBLE, eSCREEN_COLOR_THREE, eSCREEN_COLOR_FULLCOLOR);

  //�� ˫��ɫ1��G+R  ˫��ɫ2��R+G
  TE_DoubleColorPixel = (eDOUBLE_COLOR_PIXTYPE_0, eDOUBLE_COLOR_PIXTYPE_1,
    eDOUBLE_COLOR_PIXTYPE_2);
      
  //����  ����
  TE_arrMode = (eSINGLELINE, eMULTILINE);

  //��ɫ  ��ɫ  ��ɫ ��ɫ
  TE_Color = (eBLACK, eRED, eGREEN, eYELLOW);

  //����  ������ת  ����  ������ת
  TE_txtDirection = (pNORMAL, pROTATERIGHT, pMIRROR, pROTATELEFT);

  //YYYY-MM-DD  YYYY/MM/DD  DD-MM-YYYY  DD/MM/YYYY  MM-DD  MM/DD
  //MM��DD�� YYYY��MM��DD��
  TE_DateStyle = (eYYYY_MM_DD_MINUS, eYYYY_MM_DD_VIRGURE, eDD_MM_YYYY_MINUS,
    eDD_MM_YYYY_VIRGURE, eMM_DD_MINUS, eMM_DD_VIRGURE, eMM_DD_CHS,
    eYYYY_MM_DD_CHS);

  //HH:MM:SS HHʱMM��SS�� HH:MM  HHʱMM��  AM HH:MM  HH:MM AM
  TE_TimeStyle = (eHH_MM_SS_COLON, eHH_MM_SS_CHS, eHH_MM_COLON, eHH_MM_CHS,
    eAM_HH_MM, eHH_MM_AM);

  //Monday  Mon. ����һ
  TE_WeekStyle = (eMonday_NONE, eMonday, eMon, eMonday_CHS);

  //��ɫ ��ɫ ��ɫ ��ɫ ��ɫ  Ʒ��/���  ��ɫ  ��ɫ(5��ʱ����ֻ֧��������ɫ)
  TE_Color_G56 = (ecBLACK, ecRED, ecGREEN, ecYELLOW, ecBLUE, ecMAGENTA, ecCYAN,
    ecWHITE);

  //������ʽ  ���� ���� Բ��
  TE_ClockStyle = (eLINE, eSQUARE, eCIRCLE);

  Tbx_Ping_data = packed record
    ControllerType:Word;
    FirmwareVersion:array[0..7] of Byte;
    ScreenParaStatus:Byte;
    uAddress:Word;
    Baudrate:Byte;
    ScreenWidth:Word;
    ScreenHeight:Word;
    Color:Byte;
    CurrentBrigtness:Byte;
    CurrentOnOffStatus:Byte;
    ScanConfNumber:Word;
    reversed:array[0..8] of Byte;
    ipAdder:array[0..19] of Byte;
  end;
  Pbx_Ping_data=^Tbx_Ping_data;  

  //ͼ�ķ�����������
  TEQPicAreaSoundHeader_G6 = packed record
		SoundPerson: Byte;           //�����ˣ���Χ0��5����6��ѡ��
		SoundVolum: Byte;            //��������Χ0��10
		SoundSpeed: Byte;            //���٣���Χ0��10
		SoundDataMode: Byte;         //�������ݵı����ʽ
		SoundReplayTimes: Integer;      //�ز�����
		SoundReplayDelay: Integer;      //�ز�ʱ����
		SoundReservedParaLen: Byte;  //�������������������ȣ�Ĭ��0x03
		Soundnumdeal: Byte;          //�����Э��  ͬ TEQSound_6G
		Soundlanguages: Byte;        //�����Э��
		Soundwordstyle: Byte;        //�����Э��
	end; 
  PEQPicAreaSoundHeader_G6 = ^TEQPicAreaSoundHeader_G6;

  TEQtimeAreaData_G56 = packed record
    linestyle: Integer{TE_arrMode};   //'���з�ʽ�����л��Ƕ���
    color: LongWord;          //'������ɫ
    fontName: PAnsiChar;         //'��������
    fontSize: Word;           //'�����С
    fontBold: Byte;           //'����Ӵ�
    fontItalic: Byte;         //'б��
    fontUnderline: Byte;      //'������»���
    fontAlign: Byte;          //'���뷽ʽ--������Ч
    date_enable: Byte;        //'�Ƿ��������
    datestyle: integer{TE_DateStyle};  //'���ڸ�ʽ
    time_enable: Byte;        //'�Ƿ����ʱ��---Ĭ�����
    timestyle: integer{TE_TimeStyle};  //'ʱ���ʽ
    week_enable: Byte;       //'�Ƿ��������
    weekstyle: integer{TE_WeekStyle};  //'���ڸ�ʽ
  end;
  PEQtimeAreaData_G56 = ^TEQtimeAreaData_G56;

  TEQAnalogClockHeader_G56 = packed record
    OrignPointX: Word; //'ԭ�������
    OrignPointY: Word; //'ԭ��������
    UnitMode: Byte;      //'����ģʽ
    HourHandWidth: Byte;  //'ʱ����
    HourHandLen: Byte;   //'ʱ�볤��
    HourHandColor: LongWord;  //'ʱ����ɫ
    MinHandWidth: Byte;      //'������
    MinHandLen: Byte;    //'���볤��
    MinHandColor: LongWord;  //'������ɫ
    SecHandWidth: Byte;   //'������
    SecHandLen: Byte;    //'���볤��
    SecHandColor: LongWord; //'������ɫ
  end;
  PEQAnalogClockHeader_G56 = ^TEQAnalogClockHeader_G56;

  TClockColor_G56 = packed record
    Color369: LongWord;  //'369����ɫ
    ColorDot: LongWord;  //'����ɫ
    ColorBG: LongWord;  //'������Ȧ��ɫ ģʽû��Ȧ�����ɫ��Ч
  end;  
  PClockColor_G56 = ^TClockColor_G56;

  TEQprogramHeader = packed record
    FileType: Byte; //'�ļ�����  'Ĭ�ϣ�0x00 'LOGO�ļ�:0x08 'ɨ�������ļ�:0x02
                      // '��־�ļ�:0x06 '�ֿ��ļ�:0x05  '��ʾ��Ϣ���ļ�: 0x07
    ProgramID: LongWord; //'��ĿID   Bit0 �Cȫ�ֽ�Ŀ��־λ Bit1 �C��̬��Ŀ��־λ Bit2 �C������Ŀ��־λ
    ProgramStyle: Byte; //'��Ŀ����
    ProgramPriority: Byte; //'��Ŀ�ȼ� ע:������ʱ�εĽ�Ŀ���ȼ�Ϊ 1����������ʱ�εĽ�Ŀ���ȼ�Ϊ 0
    ProgramPlayTimes: Byte; //'��Ŀ�ز��Ŵ���
    ProgramTimeSpan: Word; //'���ŵķ�ʽ
    ProgramWeek: Byte; //'��Ŀ��������
    ProgramLifeSpan_sy: Word; //'��
    ProgramLifeSpan_sm: Byte; //'��
    ProgramLifeSpan_sd: Byte; //'��
    ProgramLifeSpan_ey: Word; //'������
    ProgramLifeSpan_em: Byte; //'������
    ProgramLifeSpan_ed: Byte; //'������
  end;
  PEQprogramHeader=^TEQprogramHeader;

  TEQareaHeader = packed record
    AreaType: Byte;   //'��������
    AreaX: Word;      //'�������ϽǺ�����
    AreaY: Word;      //'�������Ͻ�������
    AreaWidth: Word;  //'������
    AreaHeight: Word; //'����߶�
  end;
  PEQareaHeader=^TEQareaHeader;

  TEQpageHeader = packed record
      PageStyle: Byte; //'����ҳ����
      DisplayMode: Byte; //'��ʾ��ʽ
      ClearMode: Byte; //'�˳���ʽ/������ʽ
      Speed: Byte; //'�ٶȵȼ�
      StayTime: Word; //'ͣ��ʱ��  ��λΪ10ms
      RepeatTime: Byte; //'�ظ�����
      ValidLen: Word; //'���ֶ�ֻ���������Ʒ�ʽ����Ч
      arrMode: integer;{TE_arrMode} //'���з�ʽ--���ж���
      fontSize: Word; //'�����С
      color: integer;{TE_Color;} //'������ɫ
      fontBold: byte; //Boolean; //'�Ƿ�Ϊ����
      fontItalic: byte; //Boolean; //'�Ƿ�Ϊб��
      tdirection: integer;{TE_txtDirection;} //'���ַ���
      txtSpace: Word; //'���ּ��
      Valign: Byte;
      Halign: Byte;
  end;
  PEQpageHeader=^TEQpageHeader;

  TEQprogram = packed record
      fileName: array[0..3] of char; //'��Ŀ�����ļ���
      fileType: Byte; //'�ļ�����
      fileLen: Integer; //'�����ļ�����
      fileAddre: pointer; //'�ļ����ڵĻ����ַ
      fileCRC32: Integer; //'�ļ�CRC32У����
  end;
  PEQprogram = ^TEQprogram;

  TEQprogramHeader_G6 = packed record
    FileType: Byte;         //�ļ�����  Ĭ�ϣ�0x00  LOGO�ļ�:0x08 ɨ�������ļ�:0x02
                           //��־�ļ�:0x06  �ֿ��ļ�:0x05  ��ʾ��Ϣ���ļ�: 0x07
    ProgramID: LongWord;    //��ĿID   Bit0 �Cȫ�ֽ�Ŀ��־λ Bit1 �C��̬��Ŀ��־λ Bit2 �C������Ŀ��־λ
    ProgramStyle: Byte;     //��Ŀ����
    ProgramPriority: Byte;  //��Ŀ�ȼ� ע:������ʱ�εĽ�Ŀ���ȼ�Ϊ 1����������ʱ�εĽ�Ŀ���ȼ�Ϊ 0
    ProgramPlayTimes: Byte; //��Ŀ�ز��Ŵ���
    ProgramTimeSpan: Word;  //���ŵķ�ʽ
    SpecialFlag: Byte;      //�����Ŀ��
    CommExtendParaLen: Byte;  //��չ�������ȣ�Ĭ��Ϊ0x00
    ScheduNum: Word;  //��Ŀ����
    LoopValue: Word;  //���ȹ���ѭ������
    Intergrate: Byte;  //�������
    TimeAttributeNum: Byte;  //ʱ����������
    TimeAttribute0Offset: Word;  //��һ��ʱ������ƫ����--Ŀǰֻ֧��һ��
    ProgramWeek: Byte;  //��Ŀ��������
    ProgramLifeSpan_sy: Word;  //��
    ProgramLifeSpan_sm: Byte;  //��
    ProgramLifeSpan_sd: Byte;  //��
    ProgramLifeSpan_ey: Word;  //������
    ProgramLifeSpan_em: Byte;  //������
    ProgramLifeSpan_ed: Byte;  //������
  end;
  PEQprogramHeader_G6 = ^TEQprogramHeader_G6;

  TEQSound_6G = packed Record
    SoundFlag: Byte;               //'1 0x00 �Ƿ�ʹ����������;0 ��ʾ��ʹ������; 1 ��ʾ���������� SoundData ��������;
    SoundPerson: Byte;             //'SoundData ��������
                                   //'1 0x00 ������ ��ֵ��Χ�� 0 - 5��
                                   //�� 6 ��ѡ��ֻ�� SoundFlag���Ƿ�ʹ���������ţ�Ϊ 1 ʱ�ŷ��͸��ֽڣ�
                                   //���򲻷��͸�ֵĬ��Ϊ 0
    SoundVolum: Byte;              //'1 0x05 ������ֵ��Χ�� 0~10���� 11 �֣�0��ʾ����ֻ�� SoundFlag���Ƿ�ʹ���������ţ�Ϊ 1 ʱ�ŷ��͸��ֽڣ����򲻷��͸�ֵĬ��Ϊ 5
    SoundSpeed: Byte;              //'1 0x05 ���ٸ�ֵ��Χ�� 0~10���� 11 ��ֻ�� SoundFlag���Ƿ�ʹ���������ţ�Ϊ 1 ʱ�ŷ��͸��ֽڣ����򲻷��͸�ֵĬ��Ϊ 5
    SoundDataMode: Byte;           //'1 0x00 SoundData �ı����ʽ����ֵ�������£�0x00 GB2312; 0x01 GBK; 0x02 BIG5; 0x03 UNICODEֻ�� SoundFlag���Ƿ�ʹ���������ţ�Ϊ 1 ʱ�ŷ��͸��ֽڣ����򲻷���
    SoundReplayTimes: Integer;     //' 4 0x00000000 �ز�������ֵΪ 0����ʾ���� 1 �θ�ֵΪ 1����ʾ���� 2 ��
    SoundReplayDelay: Integer;     //'......
                                   //'��ֵΪ 0xffffffff����ʾ�������޴�ֻ�� SoundFlag���Ƿ�ʹ���ﲥ�ţ�Ϊ 1 ʱ�ŷ��͸��ֽڣ����򲻷��͸�ֵĬ��Ϊ 0
                                   //' 4 0x00000000 �ز�ʱ������ֵ��ʾ���β���������ʱ��������λΪ 10msֻ�� SoundFlag���Ƿ�ʹ���������ţ�Ϊ 1 ʱ�ŷ��͸��ֽڣ����򲻷��͸�ֵĬ��Ϊ 0
    SoundReservedParaLen: Byte ;   //' 1 0x03 ��������������������
    Soundnumdeal: Byte;            //' 1 0 0���Զ��ж�1�����������봦�� 2����������ֵ����ֻ�е� SoundFlag Ϊ 1 ��SoundReservedParaLen��Ϊ 0�ŷ��ʹ˲���

    Soundlanguages: Byte;          //' 1 0 0���Զ��ж�����1�����������֡�������λ��������ŵȺϳ�Ϊ����2�����������֡�������λ��������ŵȺϳ�ΪӢ��ֻ�е� SoundFlag Ϊ 1 �� SoundReservedParaLen��Ϊ 0�ŷ��ʹ˲�����Ŀǰֻ֧����Ӣ�ģ�
    Soundwordstyle: Byte;          //' 1 0 0���Զ��жϷ�����ʽ1����ĸ������ʽ2�����ʷ�����ʽ��ֻ�е� SoundFlag Ϊ 1 ��SoundReservedParaLen��Ϊ 0�ŷ��ʹ˲���
    SoundDataLen: Integer;         //' 4 �������ݳ���; ֻ�� SoundFlag���Ƿ�ʹ���������ţ�Ϊ 1 ʱ�ŷ��͸��ֽڣ����򲻷���
    SoundData: string;{Pointer;}{PByteArray;}         //' N ��������ֻ�� SoundFlag���Ƿ�ʹ���������ţ�Ϊ 1 ʱ�ŷ��͸��ֽڣ����򲻷���
  end;
  PEQSound_6G = ^TEQSound_6G;

  TEQAreaHeader_G6 = packed record
    AreaType: Byte;  //��������
    AreaX: Word;  //�������ϽǺ�����
    AreaY: Word;  //�������Ͻ�������
    AreaWidth: Word;  //������
    AreaHeight: Word;  //����߶�
    BackGroundFlag: Byte;  //�Ƿ��б���
    Transparency: Byte;  //͸����
    AreaEqual: Byte;  //ǰ�������������С�Ƿ���ͬ
    stSoundData: TEQSound_6G;  //�������� ʹ����������ʱ�����ֿ���Ҫ���ô���Ϊ����ģʽ������
  end;
  PEQAreaHeader_G6 = ^TEQAreaHeader_G6;

  TEQPageHeader_G6  = packed record
    PageStyle: Byte;  //����ҳ����
    DisplayMode: Byte;  //��ʾ��ʽ
    ClearMode: Byte;  //�˳���ʽ/������ʽ
    Speed: Byte;  //�ٶȵȼ�
    StayTime: Word;  //ͣ��ʱ��
    RepeatTime: Byte;  //�ظ�����
    ValidLen: Word;  //���ֶ�ֻ���������Ʒ�ʽ����Ч
    CartoonFrameRate: Byte;  //�ؼ�Ϊ������ʽʱ����ֵ������֡��
    BackNotValidFlag: Byte;  //������Ч��־
    arrMode: integer{TE_arrMode};  //���з�ʽ--���ж���
    fontSize: Word;  //�����С
    color: integer; {TE_Color;}  //������ɫ
    fontBold: byte; {Boolean;}  //�Ƿ�Ϊ����
    fontItalic: byte; {Boolean;}  //�Ƿ�Ϊб��
    tdirection: integer{TE_txtDirection};  //���ַ���
    txtSpace: Word;  //���ּ��
    Valign: Byte;
    Halign: Byte;
  end;
  PEQPageHeader_G6 = ^TEQPageHeader_G6;

  TEQprogram_G6 = packed record
    fileName: Array[0..3] of char;  //��Ŀ�����ļ��� <MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> _
    fileType: Byte;  //�ļ�����
    fileLen: Integer;  //�����ļ�����
    fileAddre: Pointer;  //�ļ����ڵĻ����ַ
    dfileName: Array[0..3] of char;  //��Ŀ�����ļ��� <MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)>
    dfileType: Byte;  //��Ŀ�����ļ�����
    dfileLen: Integer;  //�����ļ�����
    dfileAddre: Pointer;  //�����ļ������ַ
  end;   
  PEQprogram_G6 = ^TEQprogram_G6;



type
  TForm1 = class(TForm)
    Button1: TButton;
    Label1: TLabel;
    Button2: TButton;
    Label2: TLabel;
    Label3: TLabel;
    Button3: TButton;
    Button4: TButton;
    Label4: TLabel;
    Button5: TButton;
    Label5: TLabel;
    Button6: TButton;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;   
  err:integer;
  cmb_ping_Color:TE_ScreenColor_G56;
  ControllerType:Word;
  function bxDual_InitSdk():integer; stdcall external 'bx_sdk_dual.dll';
  procedure bxDual_ReleaseSdk(); stdcall external 'bx_sdk_dual.dll';
  //function bxDual_InitSdk():integer; stdcall external 'bx_sdk_dual.dll';
  function  bxDual_cmd_udpPing(retData:Pointer):integer; stdcall external 'bx_sdk_dual.dll';
  function  bxDual_cmd_tcpPing(ip: pchar; port: longword;retData:Pointer):integer; stdcall external 'bx_sdk_dual.dll';
  Function bxDual_program_setScreenParams_G56(color:integer{TE_ScreenColor_G56;}; ControllerType: Word;doubleColor:integer{TE_DoubleColorPixel}):integer; stdcall external 'bx_sdk_dual.dll';

  //'д�ļ�
  function bxDual_cmd_ofsWriteFile(ip: PAnsiChar; port: LongWord; fileName:PChar;fileType: Byte; fileLen: Integer; overwrite: Byte; fileAddre: Pointer): Integer;
     stdcall; external 'bx_sdk_dual.dll';
  //'��ʼд�ļ�
  function bxDual_cmd_ofsStartFileTransf(ip: PAnsiChar; port: LongWord): Integer;
     stdcall; external 'bx_sdk_dual.dll';
  //'����д�ļ�
  function bxDual_cmd_ofsEndFileTransf(ip: PAnsiChar; port: LongWord): Integer;
     stdcall; external 'bx_sdk_dual.dll';  
  
//****************************5�����ƿ��ӿ�*************************************
  //'������Ŀ
  function bxDual_program_addProgram(programH: Pointer{TEQprogramHeader}): Integer;
     stdcall; external 'bx_sdk_dual.dll';
  //�������
  function bxDual_program_AddArea(areaID: Word; programH: Pointer{TEQareaHeader}): Integer;
     stdcall; external 'bx_sdk_dual.dll';
  //'����ı�
  function bxDual_program_picturesAreaAddTxt(areaID: Word; str,fontName: PChar; programH: Pointer{TEQpageHeader}): Integer;
     stdcall; external 'bx_sdk_dual.dll';
  //'���ͼƬ
  function bxDual_program_pictureAreaAddPic(areaID:Word; picID:Word;
    pheader: Pointer{TEQpageHeader}; picPath: PAnsiChar): Integer;
     stdcall; external 'bx_sdk_dual.dll';
  //'���ʱ��
  function bxDual_program_fontPath_timeAreaAddContent(areaID: Word; pheader: Pointer{TEQtimeAreaData_G56}): Integer;
     stdcall; external 'bx_sdk_dual.dll';
  //'��ӱ���
  function bxDual_program_timeAreaAddAnalogClock(areaID: Word; pheader: Pointer{TEQAnalogClockHeader_G56};
    cStyle: TE_ClockStyle; cColor: Pointer{TClockColor_G56}): Integer;
     stdcall; external 'bx_sdk_dual.dll';
 
  //'��ȡ��Ŀ����
  function bxDual_program_IntegrateProgramFile(AProgram:Pointer{TEQprogram}): Integer;
     stdcall; external 'bx_sdk_dual.dll';
  //'ɾ����Ŀ����
  function bxDual_program_deleteProgram: Integer;
     stdcall; external 'bx_sdk_dual.dll';


//****************************6�����ƿ��ӿ�**********************************

  //'��ӽ�Ŀ
  function bxDual_program_addProgram_G6(programH: Pointer{TEQprogramHeader_G6}): Integer;
     stdcall; external 'bx_sdk_dual.dll';
  //'�������
  function bxDual_program_addArea_G6(areaID: Word; programH: Pointer{TEQareaHeader_G6}): Integer;
     stdcall; external 'bx_sdk_dual.dll';
  //'����ı�
  function bxDual_program_picturesAreaAddTxt_G6(areaID: Word; str: PAnsiChar;
    fontName: PAnsiChar; programH: Pointer{TEQpageHeader_G6}):
    Integer;  stdcall; external 'bx_sdk_dual.dll';
  //'���ͼƬ
  function bxDual_program_pictureAreaAddPic_G6(areaID: Word; picID: Word;
    pheader: Pointer{TEQpageHeader_G6}; picPath: PAnsiChar): Integer;
     stdcall; external 'bx_sdk_dual.dll';
  //'���ʱ��
  function bxDual_program_timeAreaAddContent_G6(areaID: Word;pheader: Pointer{TEQtimeAreaData_G56}): Integer;
    stdcall; external 'bx_sdk_dual.dll';

  //'��ӱ���
  function bxDual_program_timeAreaAddAnalogClock_G6(areaID: Word;
    pheader: Pointer{TEQAnalogClockHeader_G56}; cStyle: TE_ClockStyle;
    cColor: Pointer{PClockColor_G56}): Integer;
    stdcall; external 'bx_sdk_dual.dll';

  //'��ȡ��Ŀ����
  function bxDual_program_IntegrateProgramFile_G6(AProgram: PEQprogram_G6): Integer;
     stdcall; external 'bx_sdk_dual.dll';
  //'ɾ����Ŀ����
  function bxDual_program_deleteProgram_G6: Integer;
    stdcall; external 'bx_sdk_dual.dll';


  //ͼ�ķ���ʹ����������
  function bxDual_program_pictureAreaEnableSound_G6(areaID: Word;sheader: TEQPicAreaSoundHeader_G6; soundData: PChar): Integer;
    stdcall; external 'bx_sdk_dual.dll';



implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
begin
  err:=bxDual_InitSdk();
  Label1.Caption:=IntTostr(err);
end;

procedure TForm1.Button2Click(Sender: TObject);
var
  retData:Pbx_Ping_data;
  Data:Pointer;
begin
  new(retData);
        //retData.ControllerType := 0;
        //fillchar(retData.FirmwareVersion,sizeof(retData.FirmwareVersion),#0);
        //retData.ScreenParaStatus := 0   ;
        //retData.uAddress := 0 ;
        //retData.Baudrate := 0 ;
        //retData.ScreenWidth := 0  ;
        //retData.ScreenHeight := 0 ;
        //retData.Color := 0 ;
        //retData.CurrentBrigtness := 0  ;
        //retData.CurrentOnOffStatus := 0 ;
        //retData.ScanConfNumber := 0;
        //fillchar(retData.reversed,sizeof(retData.reversed),#0);
        //fillchar(retData.ipAdder,sizeof(retData.ipAdder),#0);
  err:=bxDual_cmd_udpPing(retData);
  //retData:=Data^;
  Label2.Caption:=IntTostr(err+retData.ControllerType);
  ControllerType:=retData.ControllerType;
  if (retData.Color = 1)then begin cmb_ping_Color := eSCREEN_COLOR_SINGLE; end
  else if (retData.Color = 3)then begin cmb_ping_Color := eSCREEN_COLOR_DOUBLE; end
  else if (retData.Color = 7)then begin cmb_ping_Color := eSCREEN_COLOR_THREE; end
  else begin cmb_ping_Color := eSCREEN_COLOR_FULLCOLOR; end
end;

procedure TForm1.Button3Click(Sender: TObject);
var
  Header: PEQprogramHeader;
  aHeader:PEQareaHeader;
  AreaText,font,ipAdder,fileName: string;
  pHeader: PEQpageHeader;
  eqProgram:PEQprogram;
  timeData:PEQtimeAreaData_G56;
begin
  new(Header);
  new(aHeader);
  new(pHeader);
  new(timeData);
  new(eqProgram);
  err:=bxDual_program_setScreenParams_G56(Integer(cmb_ping_Color),ControllerType, Integer(eDOUBLE_COLOR_PIXTYPE_2));

  Header.FileType := $0;
  Header.ProgramID := 0;
  Header.ProgramStyle := $0;
  Header.ProgramPriority := $0;
  Header.ProgramPlayTimes := 1;
  Header.ProgramTimeSpan := 0;
  Header.ProgramWeek := $FF;
  Header.ProgramLifeSpan_sy := $FFFF;
  Header.ProgramLifeSpan_sm := $3;
  Header.ProgramLifeSpan_sd := $14;
  Header.ProgramLifeSpan_ey := $FFFF;
  Header.ProgramLifeSpan_em := $3;
  Header.ProgramLifeSpan_ed := $14;
  err := bxDual_program_addProgram(Header);
  {
  aHeader.AreaType := 0;
  aHeader.AreaX := 32;
  aHeader.AreaY := 0;
  aHeader.AreaWidth := 16;
  aHeader.AreaHeight := 16;
  err := bxDual_program_AddArea(0,aHeader);

  AreaText := '1';
  font := '����';
  pHeader.PageStyle := 0;
  pHeader.DisplayMode := 1;
  pHeader.ClearMode := 1;
  pHeader.Speed := 15;
  pHeader.StayTime := 500;
  pHeader.RepeatTime := 1;
  pHeader.ValidLen := 32;
  pHeader.arrMode := Integer(eSINGLELINE);
  pHeader.fontSize := 12;
  pHeader.color := Integer(eRED);
  pHeader.fontBold := 0;
  pHeader.fontItalic := 0;
  pHeader.tdirection := Integer(pNORMAL);
  pHeader.txtSpace := 0;
  pHeader.Valign := 0;
  pHeader.Halign := 0;
  err := bxDual_program_picturesAreaAddTxt(0, PChar(AreaText), PChar(font), pHeader);
      }
  aHeader.AreaType := 2;
  aHeader.AreaX := 0;
  aHeader.AreaY := 0;
  aHeader.AreaWidth := 64;
  aHeader.AreaHeight := 32;
  err := bxDual_program_AddArea(0,aHeader);

  timeData.linestyle := Integer(eMULTILINE);
  timeData.color := LongWord(ecRED);
  timeData.fontName := pansichar(ansistring(font));
  timeData.fontSize := 10;
  timeData.fontBold := 0;
  timeData.fontItalic := 0;
  timeData.fontUnderline := 0;
  timeData.fontAlign := 1;
  timeData.date_enable := 1;
  timeData.datestyle := Integer(eYYYY_MM_DD_MINUS);
  timeData.time_enable := 1;
  timeData.timestyle := Integer(eHH_MM_SS_COLON);
  timeData.week_enable := 1;
  timeData.weekstyle := Integer(eMonday_CHS);
  err := bxDual_program_fontPath_timeAreaAddContent(0, timeData);

  err := bxDual_Program_IntegrateProgramFile(eqProgram);
  ipAdder:= '192.168.89.111';
  err := bxDual_cmd_ofsStartFileTransf(pansichar(ansistring(ipAdder)), 5005);
  //fileName:= string(eqProgram.fileName);
  err := bxDual_cmd_ofsWriteFile(pansichar(ansistring(ipAdder)), 5005, eqProgram.fileName, eqProgram.fileType, eqProgram.fileLen, 1, eqProgram.fileAddre);
  err := bxDual_cmd_ofsEndFileTransf(pansichar(ansistring(ipAdder)), 5005);
  err := bxDual_Program_deleteProgram();
  Label3.Caption:=IntTostr(err);
end;

procedure TForm1.Button6Click(Sender: TObject);
var
  str: WideString;
  retData:Pbx_Ping_data;
begin
  new(retData);
  str:= '192.168.89.111';
  err:=bxDual_cmd_tcpPing(pansichar(ansistring(str)), 5005,retData);
  Label2.Caption:=IntTostr(err+retData.ControllerType);
  ControllerType:=retData.ControllerType;
  if (retData.Color = 1)then begin cmb_ping_Color := eSCREEN_COLOR_SINGLE; end
  else if (retData.Color = 3)then begin cmb_ping_Color := eSCREEN_COLOR_DOUBLE; end
  else if (retData.Color = 7)then begin cmb_ping_Color := eSCREEN_COLOR_THREE; end
  else begin cmb_ping_Color := eSCREEN_COLOR_FULLCOLOR; end
end;

procedure TForm1.Button4Click(Sender: TObject);
var
  Header: pEQprogramHeader_G6;
  aHeader:PEQareaHeader_G6;
  stSoundData: TEQSound_6G;
  str,AreaText,font,ipAdder: string;
  pHeader: PEQpageHeader_G6;
  eqProgram:PEQprogram_G6;
  timeData:PEQtimeAreaData_G56;
  Soundheader:TEQPicAreaSoundHeader_G6;
begin  
  new(Header);
  new(aHeader);
  new(pHeader);
  new(timeData);
  new(eqProgram);
  err:=bxDual_program_setScreenParams_G56(Integer(cmb_ping_Color),ControllerType, Integer(eDOUBLE_COLOR_PIXTYPE_2));

  Header.FileType := $0;
  Header.ProgramID := 0;
  Header.ProgramStyle := $0;
  Header.ProgramPriority := $0;
  Header.ProgramPlayTimes := 1;
  Header.ProgramTimeSpan := 0;
  Header.SpecialFlag := 0;
  Header.CommExtendParaLen := $0;
  Header.ScheduNum := 0;
  Header.LoopValue := 0;
  Header.Intergrate := $0;
  Header.TimeAttributeNum := $0;
  Header.TimeAttribute0Offset := $0;
  Header.ProgramWeek := $FF;
  Header.ProgramLifeSpan_sy := $FFFF;
  Header.ProgramLifeSpan_sm := $3;
  Header.ProgramLifeSpan_sd := $14;
  Header.ProgramLifeSpan_ey := $FFFF;
  Header.ProgramLifeSpan_em := $3;
  Header.ProgramLifeSpan_ed := $14;
  err := bxDual_program_addProgram_G6(Header);
  
  stSoundData.SoundFlag := 0;
  stSoundData.SoundVolum := 0;
  stSoundData.SoundSpeed := 0;
  stSoundData.SoundDataMode := 0;
  stSoundData.SoundReplayTimes := 0;
  stSoundData.SoundReplayDelay := 0;
  stSoundData.SoundReservedParaLen := 0;
  stSoundData.Soundnumdeal := 0;
  stSoundData.Soundlanguages := 0;
  stSoundData.Soundwordstyle := 0;
  stSoundData.SoundDataLen := 0;
  str:='1';
  stSoundData.SoundData :='1';// pansichar(ansistring(str);
  aHeader.AreaType := 0;
  aHeader.AreaX := 0;
  aHeader.AreaY := 0;
  aHeader.AreaWidth := 64;
  aHeader.AreaHeight := 32;
  aheader.BackGroundFlag := $0;
  aheader.Transparency := 101;
  aheader.AreaEqual := $0;
  aheader.stSoundData := stSoundData;
  err := bxDual_program_addArea_G6(0,aHeader);

  AreaText := 'Hello,123';
  font := '����';
  pheader.PageStyle := $0;
  pheader.DisplayMode := $5;
  pheader.ClearMode := $1;
  pheader.Speed := 15;
  pheader.StayTime := 500;
  pheader.RepeatTime := 1;
  pheader.ValidLen := 0;
  pheader.CartoonFrameRate := $0;
  pheader.BackNotValidFlag := $0;
  pheader.arrMode := Integer(eMULTILINE);
  pheader.fontSize := 18;
  pheader.color := Integer(eRED);
  pheader.fontBold := 0; //False;
  pheader.fontItalic :=0; // False;
  pheader.tdirection := Integer(pNORMAL);
  pheader.txtSpace := 0;
  pheader.Valign := 2;
  pheader.Halign := 2;
  err := bxDual_program_picturesAreaAddTxt_G6(0, pansichar(ansistring(AreaText)), pansichar(ansistring(font)), pHeader);

  Soundheader.SoundPerson:=3;
  Soundheader.SoundVolum:=5;
  Soundheader.SoundSpeed:=5;
  Soundheader.SoundDataMode:=0;
  Soundheader.SoundReplayTimes:=0;
  Soundheader.SoundReplayDelay:=1000;
  Soundheader.SoundReservedParaLen:=3;
  Soundheader.Soundnumdeal := 1;
  Soundheader.Soundlanguages := 1;
  Soundheader.Soundwordstyle := 1;
  AreaText := '123';
  err := bxDual_program_pictureAreaEnableSound_G6(0, Soundheader, PChar(AreaText));
  {aHeader.AreaType := 2;
  aHeader.AreaX := 64;
  aHeader.AreaY := 0;
  aHeader.AreaWidth := 64;
  aHeader.AreaHeight := 32;
  err := bxDual_program_addArea_G6(1,aHeader);

  timeData.linestyle := Integer(eMULTILINE);
  timeData.color := LongWord(ecRED);
  timeData.fontName := pansichar(ansistring(font));
  timeData.fontSize := 18;
  timeData.fontBold := 0;
  timeData.fontItalic := 0;
  timeData.fontUnderline := 0;
  timeData.fontAlign := 1;
  timeData.date_enable := 1;
  timeData.datestyle := Integer(eYYYY_MM_DD_MINUS);
  timeData.time_enable := 1;
  timeData.timestyle := Integer(eHH_MM_SS_COLON);
  timeData.week_enable := 1;
  timeData.weekstyle := Integer(eMonday_CHS);
  err := bxDual_program_timeAreaAddContent_G6(1, timeData);
   }
  err := bxDual_program_IntegrateProgramFile_G6(eqProgram);
  ipAdder:= '192.168.89.111';
  err := bxDual_cmd_ofsStartFileTransf(pansichar(ansistring(ipAdder)), 5005);
  err := bxDual_cmd_ofsWriteFile(pansichar(ansistring(ipAdder)), 5005, eqProgram.dfileName, eqProgram.dfileType, eqProgram.dfileLen, 1, eqProgram.dfileAddre);
  err := bxDual_cmd_ofsWriteFile(pansichar(ansistring(ipAdder)), 5005, eqProgram.fileName, eqProgram.fileType, eqProgram.fileLen, 1, eqProgram.fileAddre);
  err := bxDual_cmd_ofsEndFileTransf(pansichar(ansistring(ipAdder)), 5005);
  err := bxDual_program_deleteProgram_G6();
end;

procedure TForm1.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  bxDual_ReleaseSdk();
end;

end.

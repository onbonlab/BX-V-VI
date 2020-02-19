unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type

  //无 单基色  双基色  七彩色  全彩色
  TE_ScreenColor_G56 = (eSCREEN_COLOR_NONE, eSCREEN_COLOR_SINGLE,
    eSCREEN_COLOR_DOUBLE, eSCREEN_COLOR_THREE, eSCREEN_COLOR_FULLCOLOR);

  //无 双基色1：G+R  双基色2：R+G
  TE_DoubleColorPixel = (eDOUBLE_COLOR_PIXTYPE_0, eDOUBLE_COLOR_PIXTYPE_1,
    eDOUBLE_COLOR_PIXTYPE_2);
      
  //单行  多行
  TE_arrMode = (eSINGLELINE, eMULTILINE);

  //黑色  红色  绿色 黄色
  TE_Color = (eBLACK, eRED, eGREEN, eYELLOW);

  //正常  向右旋转  镜像  向左旋转
  TE_txtDirection = (pNORMAL, pROTATERIGHT, pMIRROR, pROTATELEFT);

  //YYYY-MM-DD  YYYY/MM/DD  DD-MM-YYYY  DD/MM/YYYY  MM-DD  MM/DD
  //MM月DD日 YYYY年MM月DD日
  TE_DateStyle = (eYYYY_MM_DD_MINUS, eYYYY_MM_DD_VIRGURE, eDD_MM_YYYY_MINUS,
    eDD_MM_YYYY_VIRGURE, eMM_DD_MINUS, eMM_DD_VIRGURE, eMM_DD_CHS,
    eYYYY_MM_DD_CHS);

  //HH:MM:SS HH时MM分SS秒 HH:MM  HH时MM分  AM HH:MM  HH:MM AM
  TE_TimeStyle = (eHH_MM_SS_COLON, eHH_MM_SS_CHS, eHH_MM_COLON, eHH_MM_CHS,
    eAM_HH_MM, eHH_MM_AM);

  //Monday  Mon. 星期一
  TE_WeekStyle = (eMonday_NONE, eMonday, eMon, eMonday_CHS);

  //黑色 红色 绿色 黄色 蓝色  品红/洋红  青色  白色(5代时间区只支持四种颜色)
  TE_Color_G56 = (ecBLACK, ecRED, ecGREEN, ecYELLOW, ecBLUE, ecMAGENTA, ecCYAN,
    ecWHITE);

  //表盘样式  线形 方形 圆形
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

  //图文分区播放语音
  TEQPicAreaSoundHeader_G6 = packed record
		SoundPerson: Byte;           //发音人，范围0～5，共6种选择
		SoundVolum: Byte;            //音量，范围0～10
		SoundSpeed: Byte;            //语速，范围0～10
		SoundDataMode: Byte;         //语音数据的编码格式
		SoundReplayTimes: Integer;      //重播次数
		SoundReplayDelay: Integer;      //重播时间间隔
		SoundReservedParaLen: Byte;  //语音参数保留参数长度，默认0x03
		Soundnumdeal: Byte;          //详情见协议  同 TEQSound_6G
		Soundlanguages: Byte;        //详情见协议
		Soundwordstyle: Byte;        //详情见协议
	end; 
  PEQPicAreaSoundHeader_G6 = ^TEQPicAreaSoundHeader_G6;

  TEQtimeAreaData_G56 = packed record
    linestyle: Integer{TE_arrMode};   //'排列方式，单行还是多行
    color: LongWord;          //'字体颜色
    fontName: PAnsiChar;         //'字体名字
    fontSize: Word;           //'字体大小
    fontBold: Byte;           //'字体加粗
    fontItalic: Byte;         //'斜体
    fontUnderline: Byte;      //'字体加下划线
    fontAlign: Byte;          //'对齐方式--多行有效
    date_enable: Byte;        //'是否添加日期
    datestyle: integer{TE_DateStyle};  //'日期格式
    time_enable: Byte;        //'是否添加时间---默认添加
    timestyle: integer{TE_TimeStyle};  //'时间格式
    week_enable: Byte;       //'是否添加星期
    weekstyle: integer{TE_WeekStyle};  //'星期格式
  end;
  PEQtimeAreaData_G56 = ^TEQtimeAreaData_G56;

  TEQAnalogClockHeader_G56 = packed record
    OrignPointX: Word; //'原点横坐标
    OrignPointY: Word; //'原点纵坐标
    UnitMode: Byte;      //'表针模式
    HourHandWidth: Byte;  //'时针宽度
    HourHandLen: Byte;   //'时针长度
    HourHandColor: LongWord;  //'时针颜色
    MinHandWidth: Byte;      //'分针宽度
    MinHandLen: Byte;    //'分针长度
    MinHandColor: LongWord;  //'分针颜色
    SecHandWidth: Byte;   //'秒针宽度
    SecHandLen: Byte;    //'秒针长度
    SecHandColor: LongWord; //'秒针颜色
  end;
  PEQAnalogClockHeader_G56 = ^TEQAnalogClockHeader_G56;

  TClockColor_G56 = packed record
    Color369: LongWord;  //'369点颜色
    ColorDot: LongWord;  //'点颜色
    ColorBG: LongWord;  //'表盘外圈颜色 模式没有圈泽此颜色无效
  end;  
  PClockColor_G56 = ^TClockColor_G56;

  TEQprogramHeader = packed record
    FileType: Byte; //'文件类型  '默认：0x00 'LOGO文件:0x08 '扫描配置文件:0x02
                      // '日志文件:0x06 '字库文件:0x05  '提示信息库文件: 0x07
    ProgramID: LongWord; //'节目ID   Bit0 –全局节目标志位 Bit1 –动态节目标志位 Bit2 –屏保节目标志位
    ProgramStyle: Byte; //'节目类型
    ProgramPriority: Byte; //'节目等级 注:带播放时段的节目优先级为 1，不带播放时段的节目优先级为 0
    ProgramPlayTimes: Byte; //'节目重播放次数
    ProgramTimeSpan: Word; //'播放的方式
    ProgramWeek: Byte; //'节目星期属性
    ProgramLifeSpan_sy: Word; //'年
    ProgramLifeSpan_sm: Byte; //'月
    ProgramLifeSpan_sd: Byte; //'日
    ProgramLifeSpan_ey: Word; //'结束年
    ProgramLifeSpan_em: Byte; //'结束日
    ProgramLifeSpan_ed: Byte; //'结束天
  end;
  PEQprogramHeader=^TEQprogramHeader;

  TEQareaHeader = packed record
    AreaType: Byte;   //'区域类型
    AreaX: Word;      //'区域左上角横坐标
    AreaY: Word;      //'区域左上角纵坐标
    AreaWidth: Word;  //'区域宽度
    AreaHeight: Word; //'区域高度
  end;
  PEQareaHeader=^TEQareaHeader;

  TEQpageHeader = packed record
      PageStyle: Byte; //'数据页类型
      DisplayMode: Byte; //'显示方式
      ClearMode: Byte; //'退出方式/清屏方式
      Speed: Byte; //'速度等级
      StayTime: Word; //'停留时间  单位为10ms
      RepeatTime: Byte; //'重复次数
      ValidLen: Word; //'此字段只在左移右移方式下有效
      arrMode: integer;{TE_arrMode} //'排列方式--单行多行
      fontSize: Word; //'字体大小
      color: integer;{TE_Color;} //'字体颜色
      fontBold: byte; //Boolean; //'是否为粗体
      fontItalic: byte; //Boolean; //'是否为斜体
      tdirection: integer;{TE_txtDirection;} //'文字方向
      txtSpace: Word; //'文字间隔
      Valign: Byte;
      Halign: Byte;
  end;
  PEQpageHeader=^TEQpageHeader;

  TEQprogram = packed record
      fileName: array[0..3] of char; //'节目参数文件名
      fileType: Byte; //'文件类型
      fileLen: Integer; //'参数文件长度
      fileAddre: pointer; //'文件所在的缓存地址
      fileCRC32: Integer; //'文件CRC32校验码
  end;
  PEQprogram = ^TEQprogram;

  TEQprogramHeader_G6 = packed record
    FileType: Byte;         //文件类型  默认：0x00  LOGO文件:0x08 扫描配置文件:0x02
                           //日志文件:0x06  字库文件:0x05  提示信息库文件: 0x07
    ProgramID: LongWord;    //节目ID   Bit0 –全局节目标志位 Bit1 –动态节目标志位 Bit2 –屏保节目标志位
    ProgramStyle: Byte;     //节目类型
    ProgramPriority: Byte;  //节目等级 注:带播放时段的节目优先级为 1，不带播放时段的节目优先级为 0
    ProgramPlayTimes: Byte; //节目重播放次数
    ProgramTimeSpan: Word;  //播放的方式
    SpecialFlag: Byte;      //特殊节目标
    CommExtendParaLen: Byte;  //扩展参数长度，默认为0x00
    ScheduNum: Word;  //节目调度
    LoopValue: Word;  //调度规则循环次数
    Intergrate: Byte;  //调度相关
    TimeAttributeNum: Byte;  //时间属性组数
    TimeAttribute0Offset: Word;  //第一组时间属性偏移量--目前只支持一组
    ProgramWeek: Byte;  //节目星期属性
    ProgramLifeSpan_sy: Word;  //年
    ProgramLifeSpan_sm: Byte;  //月
    ProgramLifeSpan_sd: Byte;  //日
    ProgramLifeSpan_ey: Word;  //结束年
    ProgramLifeSpan_em: Byte;  //结束日
    ProgramLifeSpan_ed: Byte;  //结束天
  end;
  PEQprogramHeader_G6 = ^TEQprogramHeader_G6;

  TEQSound_6G = packed Record
    SoundFlag: Byte;               //'1 0x00 是否使能语音播放;0 表示不使能语音; 1 表示播放下文中 SoundData 部分内容;
    SoundPerson: Byte;             //'SoundData 部分内容
                                   //'1 0x00 发音人 该值范围是 0 - 5，
                                   //共 6 种选择只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，
                                   //否则不发送该值默认为 0
    SoundVolum: Byte;              //'1 0x05 音量该值范围是 0~10，共 11 种，0表示静音只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 5
    SoundSpeed: Byte;              //'1 0x05 语速该值范围是 0~10，共 11 种只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 5
    SoundDataMode: Byte;           //'1 0x00 SoundData 的编码格式：该值意义如下：0x00 GB2312; 0x01 GBK; 0x02 BIG5; 0x03 UNICODE只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送
    SoundReplayTimes: Integer;     //' 4 0x00000000 重播次数该值为 0，表示播放 1 次该值为 1，表示播放 2 次
    SoundReplayDelay: Integer;     //'......
                                   //'该值为 0xffffffff，表示播放无限次只有 SoundFlag（是否使能语播放）为 1 时才发送该字节，否则不发送该值默认为 0
                                   //' 4 0x00000000 重播时间间隔该值表示两次播放语音的时间间隔，单位为 10ms只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 0
    SoundReservedParaLen: Byte ;   //' 1 0x03 语音参数保留参数长度
    Soundnumdeal: Byte;            //' 1 0 0：自动判断1：数字作号码处理 2：数字作数值处理只有当 SoundFlag 为 1 且SoundReservedParaLen不为 0才发送此参数

    Soundlanguages: Byte;          //' 1 0 0：自动判断语种1：阿拉伯数字、度量单位、特殊符号等合成为中文2：阿拉伯数字、度量单位、特殊符号等合成为英文只有当 SoundFlag 为 1 且 SoundReservedParaLen不为 0才发送此参数（目前只支持中英文）
    Soundwordstyle: Byte;          //' 1 0 0：自动判断发音方式1：字母发音方式2：单词发音方式；只有当 SoundFlag 为 1 且SoundReservedParaLen不为 0才发送此参数
    SoundDataLen: Integer;         //' 4 语音数据长度; 只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送
    SoundData: string;{Pointer;}{PByteArray;}         //' N 语音数据只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送
  end;
  PEQSound_6G = ^TEQSound_6G;

  TEQAreaHeader_G6 = packed record
    AreaType: Byte;  //区域类型
    AreaX: Word;  //区域左上角横坐标
    AreaY: Word;  //区域左上角纵坐标
    AreaWidth: Word;  //区域宽度
    AreaHeight: Word;  //区域高度
    BackGroundFlag: Byte;  //是否有背景
    Transparency: Byte;  //透明度
    AreaEqual: Byte;  //前景、背景区域大小是否相同
    stSoundData: TEQSound_6G;  //语音内容 使用语音功能时：部分卡需要配置串口为语音模式！！！
  end;
  PEQAreaHeader_G6 = ^TEQAreaHeader_G6;

  TEQPageHeader_G6  = packed record
    PageStyle: Byte;  //数据页类型
    DisplayMode: Byte;  //显示方式
    ClearMode: Byte;  //退出方式/清屏方式
    Speed: Byte;  //速度等级
    StayTime: Word;  //停留时间
    RepeatTime: Byte;  //重复次数
    ValidLen: Word;  //此字段只在左移右移方式下有效
    CartoonFrameRate: Byte;  //特技为动画方式时，该值代表其帧率
    BackNotValidFlag: Byte;  //背景无效标志
    arrMode: integer{TE_arrMode};  //排列方式--单行多行
    fontSize: Word;  //字体大小
    color: integer; {TE_Color;}  //字体颜色
    fontBold: byte; {Boolean;}  //是否为粗体
    fontItalic: byte; {Boolean;}  //是否为斜体
    tdirection: integer{TE_txtDirection};  //文字方向
    txtSpace: Word;  //文字间隔
    Valign: Byte;
    Halign: Byte;
  end;
  PEQPageHeader_G6 = ^TEQPageHeader_G6;

  TEQprogram_G6 = packed record
    fileName: Array[0..3] of char;  //节目参数文件名 <MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)> _
    fileType: Byte;  //文件类型
    fileLen: Integer;  //参数文件长度
    fileAddre: Pointer;  //文件所在的缓存地址
    dfileName: Array[0..3] of char;  //节目数据文件名 <MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)>
    dfileType: Byte;  //节目数据文件类型
    dfileLen: Integer;  //数据文件长度
    dfileAddre: Pointer;  //数据文件缓存地址
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

  //'写文件
  function bxDual_cmd_ofsWriteFile(ip: PAnsiChar; port: LongWord; fileName:PChar;fileType: Byte; fileLen: Integer; overwrite: Byte; fileAddre: Pointer): Integer;
     stdcall; external 'bx_sdk_dual.dll';
  //'开始写文件
  function bxDual_cmd_ofsStartFileTransf(ip: PAnsiChar; port: LongWord): Integer;
     stdcall; external 'bx_sdk_dual.dll';
  //'结束写文件
  function bxDual_cmd_ofsEndFileTransf(ip: PAnsiChar; port: LongWord): Integer;
     stdcall; external 'bx_sdk_dual.dll';  
  
//****************************5代控制卡接口*************************************
  //'创建节目
  function bxDual_program_addProgram(programH: Pointer{TEQprogramHeader}): Integer;
     stdcall; external 'bx_sdk_dual.dll';
  //添加区域
  function bxDual_program_AddArea(areaID: Word; programH: Pointer{TEQareaHeader}): Integer;
     stdcall; external 'bx_sdk_dual.dll';
  //'添加文本
  function bxDual_program_picturesAreaAddTxt(areaID: Word; str,fontName: PChar; programH: Pointer{TEQpageHeader}): Integer;
     stdcall; external 'bx_sdk_dual.dll';
  //'添加图片
  function bxDual_program_pictureAreaAddPic(areaID:Word; picID:Word;
    pheader: Pointer{TEQpageHeader}; picPath: PAnsiChar): Integer;
     stdcall; external 'bx_sdk_dual.dll';
  //'添加时间
  function bxDual_program_fontPath_timeAreaAddContent(areaID: Word; pheader: Pointer{TEQtimeAreaData_G56}): Integer;
     stdcall; external 'bx_sdk_dual.dll';
  //'添加表盘
  function bxDual_program_timeAreaAddAnalogClock(areaID: Word; pheader: Pointer{TEQAnalogClockHeader_G56};
    cStyle: TE_ClockStyle; cColor: Pointer{TClockColor_G56}): Integer;
     stdcall; external 'bx_sdk_dual.dll';
 
  //'获取节目缓存
  function bxDual_program_IntegrateProgramFile(AProgram:Pointer{TEQprogram}): Integer;
     stdcall; external 'bx_sdk_dual.dll';
  //'删除节目缓存
  function bxDual_program_deleteProgram: Integer;
     stdcall; external 'bx_sdk_dual.dll';


//****************************6代控制卡接口**********************************

  //'添加节目
  function bxDual_program_addProgram_G6(programH: Pointer{TEQprogramHeader_G6}): Integer;
     stdcall; external 'bx_sdk_dual.dll';
  //'添加区域
  function bxDual_program_addArea_G6(areaID: Word; programH: Pointer{TEQareaHeader_G6}): Integer;
     stdcall; external 'bx_sdk_dual.dll';
  //'添加文本
  function bxDual_program_picturesAreaAddTxt_G6(areaID: Word; str: PAnsiChar;
    fontName: PAnsiChar; programH: Pointer{TEQpageHeader_G6}):
    Integer;  stdcall; external 'bx_sdk_dual.dll';
  //'添加图片
  function bxDual_program_pictureAreaAddPic_G6(areaID: Word; picID: Word;
    pheader: Pointer{TEQpageHeader_G6}; picPath: PAnsiChar): Integer;
     stdcall; external 'bx_sdk_dual.dll';
  //'添加时间
  function bxDual_program_timeAreaAddContent_G6(areaID: Word;pheader: Pointer{TEQtimeAreaData_G56}): Integer;
    stdcall; external 'bx_sdk_dual.dll';

  //'添加表盘
  function bxDual_program_timeAreaAddAnalogClock_G6(areaID: Word;
    pheader: Pointer{TEQAnalogClockHeader_G56}; cStyle: TE_ClockStyle;
    cColor: Pointer{PClockColor_G56}): Integer;
    stdcall; external 'bx_sdk_dual.dll';

  //'获取节目缓存
  function bxDual_program_IntegrateProgramFile_G6(AProgram: PEQprogram_G6): Integer;
     stdcall; external 'bx_sdk_dual.dll';
  //'删除节目缓存
  function bxDual_program_deleteProgram_G6: Integer;
    stdcall; external 'bx_sdk_dual.dll';


  //图文分区使能语音播放
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
  font := '宋体';
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
  font := '宋体';
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

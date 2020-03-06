# Dual vb.net SDK
本项目为仰邦科技 单双色 系列的 vb.net实现，调用仰邦封装的动态库文件，任何人都可直接在此代码上进行添加与修改。

本项目由Visual Stuio 2010编写， 本 demo 中提供了 TCP 模式和RS485/232的简单使用方式。

* CSharp 代码

  

* 可执行程序

  



## 支持功能

* 更新动态区（单个）
* 删除动态区
* 更新节目（单个节目，节目可有多个普通区域）
* 删除节目
* 其他

## 调用方法

此API接口的调用方式如下：

**步骤1：**

初始化动态库

```
bxDual_InitSdk();
```

**步骤2：**

编辑节目：

* 创建节目
* 添加区域
* 添加显示内容
* 获取编辑的节目缓存

**步骤3：**

发送节目

**步骤4：**

释放动态库

```
bxDual_ReleaseSdk();
```

## 使用例程

```vb
//初始化
int err = bx_sdk_dual.bxDual_InitSdk();
//控制卡IP
byte[] ip = Encoding.GetEncoding("GBK").GetBytes("192.168.89.182");
//获取控制卡信息
bx_sdk_dual.Ping_data data = new bx_sdk_dual.Ping_data();
err = bx_sdk_dual.bxDual_cmd_tcpPing(ip, 5005, ref data);
           
Console.WriteLine("ControllerType:0x" + data.ControllerType.ToString("X2"));
           
Console.WriteLine("FirmwareVersion:V" + System.Text.Encoding.Default.GetString(data.FirmwareVersion));
            
Console.WriteLine("ipAdder:" + System.Text.Encoding.Default.GetString(data.ipAdder));
byte cmb_ping_Color = 1;
if (data.Color == 1) { cmb_ping_Color = 1; }
else if (data.Color == 3) { cmb_ping_Color = 2; }
 else if (data.Color == 7) { cmb_ping_Color = 3; }
else { cmb_ping_Color = 4; }
Console.WriteLine("\r\n");
err = bx_sdk_dual.bxDual_program_setScreenParams_G56((bx_sdk_dual.E_ScreenColor_G56)cmb_ping_Color, data.ControllerType, bx_sdk_dual.E_DoubleColorPixel_G56.eDOUBLE_COLOR_PIXTYPE_1);
           Console.WriteLine("program_setScreenParams_G56:" + err);
            
            
byte[] ip = Encoding.Default.GetBytes("192.168.89.182");
byte[] img = Encoding.Default.GetBytes("32.png");
byte[] img1 = Encoding.Default.GetBytes("0.png");
byte[] font = Encoding.Default.GetBytes("宋体");
bx_sdk_dual.EQareaHeader_G6 aheader;
aheader.AreaType = 0x10;
aheader.AreaX = 0;
aheader.AreaY = 0;
aheader.AreaWidth = 40;
aheader.AreaHeight = 32;
aheader.BackGroundFlag = 0x00;
aheader.Transparency = 101;
aheader.AreaEqual = 0x00;
bx_sdk_dual.EQSound_6G stSoundData = new bx_sdk_dual.EQSound_6G();
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
Random ran = new Random();
bx_sdk_dual.EQpageHeader_G6 pheader;
pheader.PageStyle = 0x00;
pheader.DisplayMode = 4;
pheader.ClearMode = 0x00;
pheader.Speed = 15;
pheader.StayTime = 0;
pheader.RepeatTime = 1;
pheader.ValidLen = 0;
pheader.CartoonFrameRate = 0x00;
pheader.BackNotValidFlag = 0x00;
pheader.arrMode = bx_sdk_dual.E_arrMode.eSINGLELINE;
pheader.fontSize = 12;
pheader.color = (uint)0x01;
pheader.fontBold = 0;
pheader.fontItalic = 0;
pheader.tdirection = bx_sdk_dual.E_txtDirection.pNORMAL;
pheader.txtSpace = 0;
pheader.Valign = 1;
pheader.Halign = 1;


bx_sdk_dual.DynamicAreaParams[] Params = new bx_sdk_dual.DynamicAreaParams[1];
Params[0].uAreaId = 0;
Params[0].oAreaHeader_G6 = aheader;
Params[0].stPageHeader = pheader;
Params[0].fontName = BytesToIntptr(font);
Params[0].strAreaTxtContent = BytesToIntptr(img);

err = bx_sdk_dual.bxDual_dynamicAreaS_AddAreaPic_6G(ip, 5005, bx_sdk_dual.E_ScreenColor_G56.eSCREEN_COLOR_DOUBLE, 1, Params);
            
bxDual_ReleaseSdk();
```


# Dual C++SDK
本项目为仰邦科技 单双色 系列的 C++实现，调用仰邦封装的动态库文件，任何人都可直接在此代码上进行添加与修改。

本项目由Visual Stuio 2010编写， 本 demo 中提供了 TCP 模式和RS485/232的简单使用方式。

* 代码

  

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

```C++
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
		//memcpy((void*)ip,(void*)retdata.ipAdder, strlen((char*)retdata.ipAdder));
		printf("retdata.ipAdder =====%s \n", ip);
		printf("retdata.ControllerType == 0x%x \n", re
	}
	printf("ret =====cmd_tcpPing===== %d \n", ret);
    BYTE cmb_ping_Color = 1;
    if (retdata.Color == 1) { cmb_ping_Color = 1; }
    else if (retdata.Color == 3) { cmb_ping_Color = 2; }
    else if (retdata.Color == 7) { cmb_ping_Color = 3; }
    else { cmb_ping_Color = 4; }
	
    ret = bxDual_program_setScreenParams_G56((E_ScreenColor_G56)cmb_ping_Color, retdata.ControllerType, eDOUBLE_COLOR_PIXTYPE_1);tdata.ControllerType);
    
    
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
```


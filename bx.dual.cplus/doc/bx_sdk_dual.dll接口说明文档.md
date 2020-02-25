# bx_sdk_dual.dll接口说明文档

##  发送流程

### BX-5系列控制卡发送节目

<img src=".\img\BX-5program.png" alt="image" style="zoom:150%;" />

### BX-5系列控制卡发送动态区(BX-5E)

<img src=".\img\BX-5dynamicarea.png" alt="image" style="zoom:150%;" />

### BX-6系列控制卡发送节目

<img src=".\img\BX-6program.png" alt="image" style="zoom:150%;" />

### BX-6系列控制卡发送动态区(6E 6EX)

<img src=".\img\BX-6dynamicarea.png" alt="image" style="zoom:150%;" />

## 接⼝说明

### 1.通用API

#### 1.1非节目相关

##### 1.1.1 bxDual_InitSdk

**返回值：**成功返回0；失败返回错误号 

**参数：**⽆ 

**说明：** 初始化动态库 

**函数：**LEDEQSDK_API int _CALL_STD bxDual_InitSdk(void);

##### 1.1.2 bxDual_ReleaseSdk

**返回值：**成功返回0；失败返回错误号 

**参数：**⽆ 

**说明：** 释放动态库 

**函数：**LEDEQSDK_API void _CALL_STD bxDual_ReleaseSdk(void);

##### 1.1.3 bxDual_cmd_searchController

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数    | 说明                                                         |
| ------- | ------------------------------------------------------------ |
| retData | 请参考结构体[Ping_data](#Ping_data)所有回读参数都会通过结构体回调，附录 |

**说明：** 通过各种通讯方式（AT、UDP、TCP）搜索控制器【单张控制卡】

**函数：** LEDEQSDK_API int _CALL_STD bxDual_cmd_searchController(Ping_data *retData);

##### 1.1.4 bxDual_cmd_udpPing

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数    | 说明                                                         |
| ------- | ------------------------------------------------------------ |
| retData | 请参考结构体[Ping_data](#Ping_data)所有回读参数都会通过结构体回调，附录 |

**说明：** UDP ping命令并返回IP地址

**函数：** LEDEQSDK_API int _CALL_STD bxDual_cmd_udpPing(Ping_data *retData);

##### 1.1.5 bxDual_cmd_uart_searchController

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数     | 说明                                                         |
| -------- | ------------------------------------------------------------ |
| retData  | 请参考结构体[Ping_data](#Ping_data)所有回读参数都会通过结构体回调，附录 |
| uartPort | 波特率:9600、57600                                           |

**说明：** 通过串口通讯方式（9600、57600）搜索控制器

**函数：** LEDEQSDK_API int _CALL_STD bxDual_cmd_uart_searchController(Ping_data *retData, Oint8* uartPort);

##### 1.1.6 bxDual_cmd_tcpPing

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数    | 说明                                                         |
| ------- | ------------------------------------------------------------ |
| ip      | 控制器IP                                                     |
| port    | 控制器端口                                                   |
| retData | 请参考结构体[Ping_data](#Ping_data)所有回读参数都会通过结构体回调，附录 |

**说明：** 通过TCP方式获取到控制器相关属性和IP地址

**函数：** LEDEQSDK_API int _CALL_STD bxDual_cmd_tcpPing(Ouint8* ip, Ouint16 port, Ping_data *retData);

##### 1.1.7 bxDual_cmd_setBrightness

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数       | 说明                                      |
| ---------- | ----------------------------------------- |
| ip         | 控制器IP                                  |
| port       | 控制器端口                                |
| brightness | 参考结构体[Brightness](#Brightness)，附录 |

**说明：** 设置亮度和相关模式

**函数：** LEDEQSDK_API int _CALL_STD bxDual_cmd_setBrightness(Ouint8* ip, Ouint16 port, Brightness *brightness);

##### 1.1.8 bxDual_cmd_sysReset

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数 | 说明       |
| ---- | ---------- |
| ip   | 控制器IP   |
| port | 控制器端口 |

**说明：** 让系统复位

**函数：** BXDUAL_API int _CALL_STD bxDual_cmd_sysReset(Ouint8* ip, Ouint16 port);

##### 1.1.9 bxDual_cmd_coerceOnOff

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数  | 说明                              |
| ----- | --------------------------------- |
| ip    | 控制器IP                          |
| port  | 控制器端口                        |
| onOff | 控制器状态：0x01 –开机 0x00 –关机 |

**说明：** 强制开关机

**函数：** BXDUAL_API int _CALL_STD bxDual_cmd_coerceOnOff(Ouint8* ip, Ouint16 port, Ouint8 onOff);

##### 1.1.10 bxDual_cmd_timingOnOff

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数     | 说明                                    |
| -------- | --------------------------------------- |
| ip       | 控制器IP                                |
| port     | 控制器端口                              |
| groupNum | 有几组定时开关机                        |
| data     | [TimingOnOff](#TimingOnOff)结构体的地址 |

**说明：** 定时开关机命令

**函数：** BXDUAL_API int _CALL_STD bxDual_cmd_timingOnOff(Ouint8* ip, Ouint16 port, Ouint8 groupNum, Ouint8 *data);

##### 1.1.11 bxDual_cmd_cancelTimingOnOff

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数 | 说明       |
| ---- | ---------- |
| ip   | 控制器IP   |
| port | 控制器端口 |

**说明：**取消定时开关机

**函数：** BXDUAL_API int _CALL_STD bxDual_cmd_cancelTimingOnOff(Ouint8* ip, Ouint16 port);

##### 1.1.12 bxDual_cmd_screenLock

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数        | 说明                                             |
| ----------- | ------------------------------------------------ |
| ip          | 控制器IP                                         |
| port        | 控制器端口                                       |
| nonvolatile | 状态是否掉电保存 0x00 –掉电不保存 0x01 –掉电保存 |
| locked      | 0x00 –解锁  0x01 –锁定                           |

**说明：** 屏幕锁定

**函数：** BXDUAL_API int _CALL_STD bxDual_cmd_screenLock(Ouint8* ip, Ouint16 port, Ouint8 nonvolatile, Ouint8 lock);

##### 1.1.13 bxDual_cmd_programLock

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数         | 说明                                                         |
| ------------ | ------------------------------------------------------------ |
| ip           | 控制器IP                                                     |
| port         | 控制器端口                                                   |
| nonvolatile  | 状态是否掉电保存 0x00 –掉电不保存 0x01 –掉电保存             |
| locked       | 0x00 –解锁  0x01 –锁定                                       |
| name         | 节目名称4（byte）个字节                                      |
| lockDuration | 节目锁定时间长度， 单位为 10 毫秒， 例 如当该值为 100 时表示锁定节目 1 秒.注意： 当该值为 0xffffffff 时表示节目锁定无时间长度限制 |

**说明：** 节目锁定

**函数：**BXDUAL_API int _CALL_STD bxDual_cmd_programLock(Ouint8* ip, Ouint16 port, Ouint8 nonvolatile, Ouint8 lock, Ouint8 *name, Ouint32 lockDuration);

#### 1.2节目相关

##### 1.2.1 bxDual_program_setScreenParams_G56

**返回值：**成功返回0；失败返回错误号 

**参数：**⽆

| 参数           | 说明                                                         |
| -------------- | ------------------------------------------------------------ |
| color          | 屏基色，<br/>typedef enum 
{
	eSCREEN_COLOR_SINGLE=1,    //单基色
	eSCREEN_COLOR_DOUBLE,      //双基色
	eSCREEN_COLOR_THREE,       //七彩色
	eSCREEN_COLOR_FULLCOLOR,   //全彩色
}E_ScreenColor_G56; |
| ControllerType | 控制卡型号                                                   |
| doubleColor    | 点阵类型，<br/>typedef enum 
{
	eDOUBLE_COLOR_PIXTYPE_1=1, //双基色1：R+G
	eDOUBLE_COLOR_PIXTYPE_2,   //双基色2：G+R
}E_DoubleColorPixel_G56; |

**说明：** 设置屏相关属性 

**函数：** LEDEQSDK_API int _CALL_STD bxDual_program_setScreenParams_G56(E_ScreenColor_G56 color, Ouint16 ControllerType, E_DoubleColorPixel_G56 doubleColor);

##### 1.2.2 bxDual_cmd_ofsStartFileTransf

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数 | 说明       |
| ---- | ---------- |
| ip   | 控制器IP   |
| port | 控制器端口 |

**说明：** 开始批量写文件 

**函数：** LEDEQSDK_API int _CALL_STD bxDual_cmd_ofsStartFileTransf(Ouint8* ip, Ouint16 port);

##### 1.2.3  bxDual_cmd_ofsWriteFile

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数      | 说明                                                         |
| --------- | ------------------------------------------------------------ |
| ip        | 控制器IP                                                     |
| port      | 控制器端口                                                   |
| fileName  | 文件名[文件数据:[EQprogram_G6](#EQprogram_G6),[EQprogram](#EQprogram)] |
| fileType  | 文件类型                                                     |
| fileLen   | 文件长度                                                     |
| overwrite | 是否覆盖控制上的文件 1覆盖 0不覆盖 建议发1                   |
| fileAddre | 文件所在的缓存地址                                           |

**说明：** 写文件到控制

**函数：**LEDEQSDK_API int _CALL_STD bxDual_cmd_ofsWriteFile(Ouint8* ip, Ouint16 port, Ouint8 *fileName, Ouint8 fileType, Ouint32 fileLen, Ouint8 overwrite, Ouint8 *fileAddre);

##### 1.2.4 bxDual_cmd_ofsEndFileTransf

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数 | 说明       |
| ---- | ---------- |
| ip   | 控制器IP   |
| port | 控制器端口 |

**说明：** 写文件结束

**函数：** LEDEQSDK_API int _CALL_STD bxDual_cmd_ofsEndFileTransf(Ouint8* ip, Ouint16 port);

### 2.BX-5(5代)控制卡API

#### 2.1 节目API

##### 2.1.1 bxDual_program_addProgram

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数     | 说明                                                |
| -------- | --------------------------------------------------- |
| programH | 参考结构体[EQprogramHeader](#EQprogramHeader)，附录 |

**说明：** 添加节目句柄

**函数：** LEDEQSDK_API int _CALL_STD bxDual_program_addProgram(EQprogramHeader *programH);

##### 2.1.2 bxDual_program_AddArea

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数    | 说明                                          |
| ------- | --------------------------------------------- |
| areaID  | 区域的ID号                                    |
| aheader | 参考结构体[EQareaHeader](#EQareaHeader)，附录 |

**说明：** 添加区域句柄 

**函数：** LEDEQSDK_API int _CALL_STD bxDual_program_AddArea(Ouint16 areaID, EQareaHeader *aheader);

##### 2.1.3 bxDual_program_picturesAreaAddTxt

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数     | 说明                                          |
| -------- | --------------------------------------------- |
| areaID   | 区域的ID号                                    |
| str      | 需要画的字符                                  |
| fontName | 字体名称                                      |
| pheader  | 参考结构体[EQpageHeader](#EQpageHeader)，附录 |

**说明：** 画字符到图文区

**函数：**LEDEQSDK_API int _CALL_STD bxDual_program_picturesAreaAddTxt(Ouint16 areaID, Ouint8* str, Ouint8* fontName, EQpageHeader* pheader);

##### 2.1.4 bxDual_program_pictureAreaAddPic

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数    | 说明                                          |
| ------- | --------------------------------------------- |
| areaID  | 区域的ID号                                    |
| picID   | 图片的ID号                                    |
| pheader | 参考结构体[EQpageHeader](#EQpageHeader)，附录 |
| picPath | 添加的图片路径,PNG                            |

**说明：** 添加图片到区域

**函数：**LEDEQSDK_API int _CALL_STD bxDual_program_pictureAreaAddPic(Ouint16 areaID,Ouint16 picID,EQpageHeader* pheader,Ouint8* picPath);

##### 2.1.5 bxDual_program_timeAreaAddContent

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数     | 说明                                                         |
| -------- | ------------------------------------------------------------ |
| areaID   | 区域的ID号                                                   |
| timeData | 详情请见时间区数据格式结构体[EQtimeAreaData_G56](#EQtimeAreaData_G56)，附录 |

**说明：** 时间分区添加内容

**函数：** LEDEQSDK_API int _CALL_STD bxDual_program_timeAreaAddContent(Ouint16 areaID,EQtimeAreaData_G56* timeData); 

##### 2.1.6 bxDual_program_timeAreaAddAnalogClock

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数   | 说明                                                         |
| ------ | ------------------------------------------------------------ |
| areaID | 区域ID                                                       |
| header | 详情见[EQAnalogClockHeader_G56](#EQAnalogClockHeader_G56)结构体，附录 |
| cStyle | 表盘样式，详情见[E_ClockStyle](#E_ClockStyle)，附录          |
| cColor | 表盘颜色，详情见[ClockColor_G56](#ClockColor_G56)，附录      |

**说明：** 时间分区添加模拟时钟

**函数：**LEDEQSDK_API int _CALL_STD bxDual_program_timeAreaAddAnalogClock(Ouint16 areaID,EQAnalogClockHeader_G56 *header,E_ClockStyle cStyle, ClockColor_G56 *cColor);

##### 2.1.7 bxDual_program_IntegrateProgramFile

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数    | 说明                              |
| ------- | --------------------------------- |
| program | 参考结构体[EQprogram](#EQprogram) |

**说明：** 合成节目文件返回节目文件属性及地址

**函数：** LEDEQSDK_API int _CALL_STD bxDual_program_IntegrateProgramFile(EQprogram* program);

##### 2.1.8 bxDual_program_deleteProgram

**返回值：**成功返回0；失败返回错误号 

**参数：**⽆ 

**说明：** 删除节目缓存

**函数：**LEDEQSDK_API int _CALL_STD bxDual_program_deleteProgram();

##### 2.1.9 bxDual_program_addFrame

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数                | 说明                                                  |
| ------------------- | ----------------------------------------------------- |
| EQscreenframeHeader | 边框属性[EQscreenframeHeader](#EQscreenframeHeader)   |
| picPath             | 添加的边框图片路径【图片像素 高等于边框宽，宽等于32】 |

**说明：**节目添加边框

**函数：**LEDEQSDK_API int _CALL_STD bxDual_program_addFrame(EQscreenframeHeader* sfHeader,Ouint8* picPath);

##### 2.1.10 bxDual_program_picturesAreaAddFrame

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数                | 说明                                                  |
| ------------------- | ----------------------------------------------------- |
| areaID              | 区域ID                                                |
| EQscreenframeHeader | 边框属性[EQareaframeHeader](#EQareaframeHeader)       |
| picPath             | 添加的边框图片路径【图片像素 高等于边框宽，宽等于32】 |

**说明：**区域添加边框

**函数：**LEDEQSDK_API int _CALL_STD bxDual_program_picturesAreaAddFrame(Ouint16 areaID,EQareaframeHeader* afHeader, Ouint8* picPath);

#### 2.2 动态区API

##### 2.2.1 bxDual_dynamicArea_AddAreaWithTxt_5G

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数              | 说明                                                         |
| ----------------- | ------------------------------------------------------------ |
| pIP               | 控制卡IP                                                     |
| nPort             | 控制卡端口                                                   |
| color             | 屏型                                                         |
| uAreaId           | 区域编号                                                     |
| RunMode           | 动态区运行模式 0— 动态区数据循环显示。 1— 动态区数据显示完成后静止显 示最后一页数据。 2— 动态区数据循环显示，超过设 定时间后数据仍未更新时不再 显示 3— 动态区数据循环显示，超过设 定时间后数据仍未更新时显示 Logo 信息,Logo 信息即为动 态区域的最后一页信息 4— 动态区数据顺序显示，显示完 最后一页后就不再显示 |
| Timeout           | 动态区数据超时时间，单位为秒                                 |
| RelateAllPro      | 当该字节为 1 时，所有异步节目 播放时都允许播放该动态区域； 为 0 时，绑定节目 |
| RelateProNum      | 动态区域关联了多少个异步节目                                 |
| RelateProSerial   | 动态区域关联的异步节 目的编号                                |
| ImmePlay          | 是否立即播放 该字节为 0 时，该动态区域与异 步节目一起播放， 该字节为 1 时，异步节目停止播 放，仅播放该动态区域 |
| uAreaX            | 区域左上角横坐标                                             |
| uAreaY            | 区域左上角纵坐标                                             |
| uWidth            | 区域宽度                                                     |
| uHeight           | 区域高度                                                     |
| oFrame            | 区域边框属性[EQareaframeHeader](#EQareaframeHeader)          |
| DisplayMode       | 显示方式                                                     |
| ClearMode         | 退出方式/清屏方式，固定 0                                    |
| Speed             | 速度等级 1-65                                                |
| StayTime          | 停留时间，单位为 10ms                                        |
| RepeatTime        | 重复次数                                                     |
| oFont             | 字体格式[EQfontData](#EQfontData)                            |
| fontName          | 字体名称                                                     |
| strAreaTxtContent | 显示文本                                                     |

**说明：** 更新动态区文本

**函数：** LEDEQSDK_API int _CALL_STD bxDual_dynamicArea_AddAreaWithTxt_5G(Ouint8* pIP, Ouint32 nPort, E_ScreenColor_G56 color,Ouint8 uAreaId,Ouint8 RunMode,Ouint16 Timeout,Ouint8 RelateAllPro,Ouint16 RelateProNum,Ouint16* RelateProSerial,Ouint8 ImmePlay,Ouint16 uAreaX, Ouint16 uAreaY, Ouint16 uWidth, Ouint16 uHeight, EQareaframeHeader oFrame,Ouint8 DisplayMode,Ouint8 ClearMode,Ouint8 Speed,Ouint16 StayTime,Ouint8 RepeatTime,EQfontData oFont,Ouint8* fontName,Ouint8* strAreaTxtContent);

##### 2.2.2 bxDual_dynamicArea_AddAreaWithPic_5G

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数              | 说明                                                         |
| ----------------- | ------------------------------------------------------------ |
| pIP               | 控制卡IP                                                     |
| nPort             | 控制卡端口                                                   |
| color             | 屏型                                                         |
| uAreaId           | 区域编号                                                     |
| RunMode           | 动态区运行模式 0— 动态区数据循环显示。 1— 动态区数据显示完成后静止显 示最后一页数据。 2— 动态区数据循环显示，超过设 定时间后数据仍未更新时不再 显示 3— 动态区数据循环显示，超过设 定时间后数据仍未更新时显示 Logo 信息,Logo 信息即为动 态区域的最后一页信息 4— 动态区数据顺序显示，显示完 最后一页后就不再显示 |
| Timeout           | 动态区数据超时时间，单位为秒                                 |
| RelateAllPro      | 当该字节为 1 时，所有异步节目 播放时都允许播放该动态区域； 为 0 时，绑定节目 |
| RelateProNum      | 动态区域关联了多少个异步节目                                 |
| RelateProSerial   | 动态区域关联的异步节 目的编号                                |
| ImmePlay          | 是否立即播放 该字节为 0 时，该动态区域与异 步节目一起播放， 该字节为 1 时，异步节目停止播 放，仅播放该动态区域 |
| uAreaX            | 区域左上角横坐标                                             |
| uAreaY            | 区域左上角纵坐标                                             |
| uWidth            | 区域宽度                                                     |
| uHeight           | 区域高度                                                     |
| oFrame            | 区域边框属性[EQareaframeHeader](#EQareaframeHeader)          |
| DisplayMode       | 显示方式                                                     |
| ClearMode         | 退出方式/清屏方式，固定 0                                    |
| Speed             | 速度等级 1-65                                                |
| StayTime          | 停留时间，单位为 10ms                                        |
| RepeatTime        | 重复次数                                                     |
| strAreaTxtContent | 图片路径png                                                  |

**说明：** 更新动态区图片

**函数：** LEDEQSDK_API int _CALL_STD bxDual_dynamicArea_AddAreaWithPic_5G(Ouint8* pIP, Ouint32 nPort, E_ScreenColor_G56 color,Ouint8 uAreaId,Ouint8 RunMode,Ouint16 Timeout,Ouint8 RelateAllPro,Ouint16 RelateProNum,Ouint16* RelateProSerial,Ouint8 ImmePlay,Ouint16 uAreaX, Ouint16 uAreaY, Ouint16 uWidth, Ouint16 uHeight, EQareaframeHeader oFrame,Ouint8 DisplayMode,Ouint8 ClearMode,Ouint8 Speed,Ouint16 StayTime,Ouint8 RepeatTime,Ouint8* filePath);

##### 2.2.3 bxDual_dynamicArea_AddAreaInfos_5G

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数            | 说明                                                         |
| --------------- | ------------------------------------------------------------ |
| pIP             | 控制卡IP                                                     |
| nPort           | 控制卡端口                                                   |
| color           | 屏型                                                         |
| uAreaId         | 区域编号                                                     |
| RunMode         | 动态区运行模式 0— 动态区数据循环显示。 1— 动态区数据显示完成后静止显 示最后一页数据。 2— 动态区数据循环显示，超过设 定时间后数据仍未更新时不再 显示 3— 动态区数据循环显示，超过设 定时间后数据仍未更新时显示 Logo 信息,Logo 信息即为动 态区域的最后一页信息 4— 动态区数据顺序显示，显示完 最后一页后就不再显示 |
| Timeout         | 动态区数据超时时间，单位为秒                                 |
| RelateAllPro    | 当该字节为 1 时，所有异步节目 播放时都允许播放该动态区域； 为 0 时，绑定节目 |
| RelateProNum    | 动态区域关联了多少个异步节目                                 |
| RelateProSerial | 动态区域关联的异步节 目的编号                                |
| ImmePlay        | 是否立即播放 该字节为 0 时，该动态区域与异 步节目一起播放， 该字节为 1 时，异步节目停止播 放，仅播放该动态区域 |
| uAreaX          | 区域左上角横坐标                                             |
| uAreaY          | 区域左上角纵坐标                                             |
| uWidth          | 区域宽度                                                     |
| uHeight         | 区域高度                                                     |
| oFrame          | 区域边框属性[EQareaframeHeader](#EQareaframeHeader)          |
| nInfoCount      | 数据页数                                                     |
| pInfo           | 数据页数据[DynamicAreaBaseInfo_5G](#DynamicAreaBaseInfo_5G)  |

**说明：** 增加多条信息（文本/图片）到指定的动态区，并可以关联这个动态区到指定的节目

**函数：** LEDEQSDK_API int _CALL_STD bxDual_dynamicArea_AddAreaInfos_5G(Ouint8* pIP, Ouint32 nPort，E_ScreenColor_G56 color,Ouint8 uAreaId,Ouint8 RunMode,Ouint16 Timeout,Ouint8 RelateAllPro,Ouint16 RelateProNum,Ouint16* RelateProSerial,Ouint8 ImmePlay,Ouint16 uAreaX, Ouint16 uAreaY, Ouint16 uWidth, Ouint16 uHeight,EQareaframeHeader oFrame,Ouint8 nInfoCount,DynamicAreaBaseInfo_5G** pInfo);

##### 2.2.4 bxDual_dynamicArea_DelArea_5G

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数    | 说明                               |
| ------- | ---------------------------------- |
| pIP     | IP                                 |
| nPort   | 端口                               |
| uAreaId | 删除的区域编号，0xFF删除所有动态区 |

**说明：** 删除动态区：

**函数：**LEDEQSDK_API int _CALL_STD bxDual_dynamicArea_DelArea_5G( Ouint8* pIP, Ouint32 nPort, Oint8 uAreaId);

##### 2.2.5 bxDual_dynamicArea_DelAreas_5G

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数       | 说明             |
| ---------- | ---------------- |
| pIP        | IP               |
| nPort      | 端口             |
| uAreaCount | 要删除的区域个数 |
| pAreaID    | 区域编号列表     |

**说明：** 删除动态区

**函数：**LEDEQSDK_API int _CALL_STD bxDual_dynamicArea_DelAreas_5G( Ouint8* pIP, Ouint32 nPort, Oint8 uAreaCount, Oint8* pAreaID);

#### 2.3 其它API

### 3.BX-6(6代)控制卡API

#### 3.1 节目API

##### 3.1.1 bxDual_program_addArea_G6

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数    | 说明                                                |
| ------- | --------------------------------------------------- |
| areaID  | 区域的ID号                                          |
| aheader | 参考结构体[EQareaHeader_G6](#EQareaHeader_G6)，附录 |

**说明：** 添加区域句柄 

**函数：** LEDEQSDK_API int _CALL_STD bxDual_program_addArea_G6(Ouint16 areaID, EQareaHeader_G6*aheader);

##### 3.1.2 bxDual_program_picturesAreaAddTxt_G6

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数     | 说明                                                |
| -------- | --------------------------------------------------- |
| areaID   | 区域的ID号                                          |
| str      | 需要画的字符                                        |
| fontName | 字体名称                                            |
| pheader  | 参考结构体[EQpageHeader_G6](#EQpageHeader_G6)，附录 |

**说明：** 画字符到图文区

**函数：**LEDEQSDK_API int _CALL_STD bxDual_program_picturesAreaAddTxt_G6(Ouint16 areaID, Ouint8* str, Ouint8* fontName, EQpageHeader_G6* pheader);

##### 3.1.3 bxDual_program_pictureAreaAddPic_G6

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数    | 说明                                                |
| ------- | --------------------------------------------------- |
| areaID  | 区域的ID号                                          |
| picID   | 图片的ID号                                          |
| pheader | 参考结构体[EQpageHeader_G6](#EQpageHeader_G6)，附录 |
| picPath | 添加的图片路径,PNG                                  |

**说明：** 添加图片到区域

**函数：**LEDEQSDK_API int _CALL_STD bxDual_program_pictureAreaAddPic_G6(Ouint16 areaID,Ouint16 picID,EQpageHeader_G6* pheader,Ouint8* picPath);

##### 3.1.4 bxDual_program_timeAreaAddContent_G6

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数     | 说明                                                         |
| -------- | ------------------------------------------------------------ |
| areaID   | 区域的ID号                                                   |
| timeData | 详情请见时间区数据格式结构体[EQtimeAreaData_G56](#EQtimeAreaData_G56)，附录 |

**说明：** 时间分区添加内容

**函数：** LEDEQSDK_API int _CALL_STD bxDual_program_timeAreaAddContent_G6(Ouint16 areaID,EQtimeAreaData_G56* timeData); 

##### 3.1.5 bxDual_program_timeAreaAddAnalogClock_G6

**返回值：**成功返回0；失败返回错误号 

**参数**：

| 参数   | 说明                                                         |
| ------ | ------------------------------------------------------------ |
| areaID | 区域ID                                                       |
| header | 详情见[EQAnalogClockHeader_G56](#EQAnalogClockHeader_G56)结构体，附录 |
| cStyle | 表盘样式，详情见[E_ClockStyle](#E_ClockStyle)，附录          |
| cColor | 表盘颜色，详情见[ClockColor_G56](#ClockColor_G56)，附录      |

**说明：** 时间分区添加模拟时钟

**函数：** LEDEQSDK_API int _CALL_STD bxDual_program_timeAreaAddAnalogClock_G6(Ouint16 areaID,EQAnalogClockHeader_G56 *header,E_ClockStyle cStyle, ClockColor_G56 *cColor);

##### 3.1.6 program_IntegrateProgramFile_G6

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数    | 说明                                    |
| ------- | --------------------------------------- |
| program | 参考结构体[EQprogram_G6](#EQprogram_G6) |

**说明：** 合成节目文件返回节目文件属性及地址

**函数：** LEDEQSDK_API int _CALL_STD bxDual_program_IntegrateProgramFile_G6(EQprogram_G6* program);

##### 3.1.7 program_deleteProgram_G6

**返回值：**成功返回0；失败返回错误号 

**参数：**⽆ 

**说明：** 删除节目缓存

**函数：**LEDEQSDK_API int _CALL_STD bxDual_program_deleteProgram_G6();

##### 3.1.8 bxDual_program_addFrame_G6

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数                | 说明                                                      |
| ------------------- | --------------------------------------------------------- |
| EQscreenframeHeader | 边框属性[EQscreenframeHeader_G6](#EQscreenframeHeader_G6) |
| picPath             | 添加的边框图片路径【图片像素 高等于边框宽，宽等于32】     |

**说明：**节目添加边框

**函数：**LEDEQSDK_API int _CALL_STD bxDual_program_addFrame_G6(EQscreenframeHeader_G6* sfHeader,Ouint8* picPath);

##### 3.1.9 bxDual_program_addProgram_G6

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数     | 说明                                                      |
| -------- | --------------------------------------------------------- |
| programH | 参考结构体[EQprogramHeader_G6](#EQprogramHeader_G6)，附录 |

**说明：** 添加节目句柄

**函数：** LEDEQSDK_API int _CALL_STD bxDual_program_addProgram_G6(EQprogramHeader_G6 *programH);

#### 3.2 动态区API

##### 3.2.1 bxDual_dynamicArea_AddAreaTxt_6G

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数              | 说明     |
| ----------------- | -------- |
| pIP               | IP       |
| nPort             | 端口     |
| color             | 屏型     |
| uAreaId           | 区域编号 |
| uAreaX            | X坐标    |
| uAreaY            | Y坐标    |
| uWidth            | 宽度     |
| uHeight           | 高度     |
| fontName          | 字体     |
| nFontSize         | 字体大小 |
| strAreaTxtContent | 显示文本 |

**说明：**6代更新动态区最基本功能：仅显示动态区：即不与节目一起显示，如果当前有节目显示，调用此函数后，LED屏幕上会清空原来的内容

**函数：**LEDEQSDK_API int _CALL_STD bxDual_dynamicArea_AddAreaTxt_6G(Ouint8* pIP, Ouint32 nPort,  E_ScreenColor_G56 color, Ouint8 uAreaId, Ouint16 uAreaX, Ouint16 uAreaY, Ouint16 uWidth, Ouint16 uHeight, Ouint8* fontName, Ouint8 nFontSize, Ouint8* strAreaTxtContent);

##### 3.2.2 bxDual_dynamicArea_AddAreaTxtDetails_6G

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数              | 说明                                                         |
| ----------------- | ------------------------------------------------------------ |
| pIP               | IP                                                           |
| nPort             | 端口                                                         |
| color             | 屏基色 typedef enum 
{
	eSCREEN_COLOR_SINGLE=1,    //单基色
	eSCREEN_COLOR_DOUBLE,      //双基色
	eSCREEN_COLOR_THREE,       //七彩色
	eSCREEN_COLOR_FULLCOLOR,   //全彩色
}E_ScreenColor_G56; |
| uAreaId           | 区域编号                                                     |
| oAreaHeader_G6    | 区域参数，结构体[EQareaHeader_G6](#EQareaHeader_G6)附录      |
| stPageHeader      | 数据页，附录[EQpageHeader_G6](#EQpageHeader_G6)              |
| fontName          | 字体                                                         |
| strAreaTxtContent | 显示内容                                                     |

**说明：** 6代更新动态区详细功能：仅显示动态区; 将要显示的一些特性/属性，封装在 EQareaHeader_G6 和 EQpageHeader_G6 结构体中

**函数：**LEDEQSDK_API int _CALL_STD bxDual_dynamicArea_AddAreaTxtDetails_6G(Ouint8* pIP, Ouint32 nPort, E_ScreenColor_G56 color, Ouint8 uAreaId, EQareaHeader_G6* oAreaHeader_G6,EQpageHeader_G6* stPageHeader,Ouint8* fontName, Ouint8* strAreaTxtContent);

##### 3.2.3 bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数              | 说明                                                    |
| ----------------- | ------------------------------------------------------- |
| pIP               | IP                                                      |
| nPort             | 端口                                                    |
| color             | 屏型                                                    |
| uAreaId           | 区域编号                                                |
| oAreaHeader_G6    | 区域参数，结构体[EQareaHeader_G6](#EQareaHeader_G6)附录 |
| stPageHeader      | 数据页，附录[EQpageHeader_G6                            |
| fontName          | 字体                                                    |
| strAreaTxtContent | 显示内容                                                |
| RelateProNum      | 0：和节目一起播放    1：绑定节目                        |
| RelateProSerial   | 绑定节目编号                                            |

**说明：** 动态区文本关联节目

**函数：**LEDEQSDK_API int _CALL_STD bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G(Ouint8* pIP, Ouint32 nPort, E_ScreenColor_G56 color, Ouint8 uAreaId, EQareaHeader_G6* oAreaHeader_G6,EQpageHeader_G6* stPageHeader, Ouint8* fontName, Ouint8* strAreaTxtContent, Ouint16 RelateProNum, Ouint16* RelateProSerial );

##### 3.2.4 bxDual_dynamicArea_AddAreaPic_6G

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数    | 说明            |
| ------- | --------------- |
| pIP     | IP              |
| nPort   | 端口            |
| color   | 屏型            |
| uAreaId | 区域编号        |
| uAreaX  | X坐标           |
| uAreaY  | Y坐标           |
| uWidth  | 宽度            |
| uHeight | 高度            |
| pheader | 区域参数        |
| picPath | 图片绝对路径png |

**说明：** 更新动态区图片：仅显示动态区;

**函数：**LEDEQSDK_API int _CALL_STD bxDual_dynamicArea_AddAreaPic_6G(Ouint8* pIP, Ouint32 nPort, E_ScreenColor_G56 color, Ouint8 uAreaId, Ouint16	AreaX, Ouint16 AreaY, Ouint16 AreaWidth, Ouint16 AreaHeight, EQpageHeader_G6* pheader, Ouint8* picPath);

##### 3.2.5 bxDual_dynamicArea_AddAreaPic_WithProgram_6G

**返回值：**成功返回0；失败返回错误号 

**参数：****

| 参数            | 说明                             |
| --------------- | -------------------------------- |
| pIP             | IP                               |
| nPort           | 端口                             |
| color           | 屏型                             |
| uAreaId         | 区域编号                         |
| uAreaX          | X坐标                            |
| uAreaY          | Y坐标                            |
| uWidth          | 宽度                             |
| uHeight         | 高度                             |
| pheader         | 区域参数                         |
| picPath         | 图片绝对路径png                  |
| RelateProNum    | 0：和节目一起播放    1：绑定节目 |
| RelateProSerial | 绑定节目编号                     |

**说明：**动态区图片关联节目

**函数：**LEDEQSDK_API int _CALL_STD bxDual_dynamicArea_AddAreaPic_WithProgram_6G(Ouint8* pIP, Ouint32 nPort, E_ScreenColor_G56 color, Ouint8 uAreaId, Ouint16 AreaX, Ouint16 AreaY,  Ouint16 AreaWidth, Ouint16 AreaHeight, EQpageHeader_G6* pheader, Ouint8* picPath, Ouint16 RelateProNum, Ouint16* RelateProSerial );

##### 3.2.6 bxDual_dynamicArea_DelArea_6G

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数    | 说明                               |
| ------- | ---------------------------------- |
| pIP     | IP                                 |
| nPort   | 端口                               |
| uAreaId | 删除的区域编号，0xFF删除所有动态区 |

**说明：** 删除动态区：

**函数：**LEDEQSDK_API int _CALL_STD bxDual_dynamicArea_DelArea_6G( Ouint8* pIP, Ouint32 nPort, Oint8 uAreaId);

##### 3.2.7 bxDual_dynamicArea_DelAreas_6G

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数       | 说明             |
| ---------- | ---------------- |
| pIP        | IP               |
| nPort      | 端口             |
| uAreaCount | 要删除的区域个数 |
| pAreaID    | 区域编号列表     |

**说明：** 删除动态区

**函数：**LEDEQSDK_API int _CALL_STD bxDual_dynamicArea_DelAreas_6G( Ouint8* pIP, Ouint32 nPort, Oint8 uAreaCount, Oint8* pAreaID);

##### 3.2.8 bxDual_dynamicAreaS_AddTxtDetails_6G

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数       | 说明                                            |
| ---------- | ----------------------------------------------- |
| pIP        | IP                                              |
| nPort      | 端口                                            |
| color      | 屏型                                            |
| uAreaCount | 区域个数                                        |
| pParams    | 区域列表[DynamicAreaParams](#DynamicAreaParams) |

**说明：**同时更新多个动态区:仅显示动态区，不显示节目

**函数：**LEDEQSDK_API int _CALL_STD bxDual_dynamicAreaS_AddTxtDetails_6G(Ouint8* pIP, Ouint32 nPort, E_ScreenColor_G56 color, Ouint8 uAreaCount, DynamicAreaParams* pParams);

##### 3.2.9 bxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数            | 说明                                            |
| --------------- | ----------------------------------------------- |
| ip              | 控制卡IP                                        |
| nPort           | 端口                                            |
| color           | 屏型                                            |
| uAreaCount      | 区域个数                                        |
| pParams         | 区域列表[DynamicAreaParams](#DynamicAreaParams) |
| RelateProNum    | 0：和节目一起播放    1：绑定节目                |
| RelateProSerial | 节目编号                                        |

**说明：** 同时更新多个动态区:并与节目关联，即与节目一起显示

**函数：**LEDEQSDK_API int _CALL_STD bxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G(Ouint8* pIP, Ouint32 nPort, E_ScreenColor_G56 color, Ouint8 uAreaCount, DynamicAreaParams* pParams, Ouint16 RelateProNum, Ouint16* RelateProSerial );

#### 3.3 其它API

## 附录

### 接口函数的参数类型定义

typedef unsigned char			Ouint8;		//!< unsigned 8-bit
typedef char			       		 Oint8;		//!< signed 8-bit 
typedef unsigned short			Ouint16;	//!< unsigned 16-bit 
typedef short			        	Oint16;		//!< signed 16-bit 
typedef unsigned int				Ouint32;	//!< unsigned 32-bit
typedef int			           	 	Oint32;		//!< signed 32-bit
typedef unsigned long long      	Ouint64;        //!< unsigned 64-bit
typedef long long               		Oint64;         //!< singed 64-bit
typedef float		            		Ofloat32;	//!< 32-bit floating point
typedef double                  			Ofloat64;	//!< 64-bit double precision FP
typedef bool                    			Obool;

###  <span id="Ping_data">Ping_data</span>

```
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
}Ping_data；
```
### <span id="EQprogram">EQprogram</span>

```
typedef struct{
    Ouint8 fileName[4]; //文件名
    Ouint8 fileType; //文件类型
    Ouint32 fileLen; //文件长度
    Ouint8* fileAddre; // 文件所在的缓存地址
	Ouint32 fileCRC32; //文件CRC32校验码
}EQprogram;
```

### <span id="EQprogram_G6">EQprogram_G6</span>

```
typedef struct{
 		Ouint8  fileName[4]; //节目参数文件名
 		Ouint8  fileType;	 //文件类型
 		Ouint32 fileLen;	 //参数文件长度
 		Ouint8* fileAddre;   //文件所在的缓存地址
		Ouint8  dfileName[4];//节目数据文件名
		Ouint8  dfileType;   //节目数据文件类型
		Ouint32 dfileLen;	 //数据文件长度
		Ouint8* dfileAddre;  //数据文件缓存地址
 	}EQprogram_G6;
```

### <span id="EQprogramHeader">EQprogramHeader</span>

    typedef struct{
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
    }EQprogramHeader;
### <span id="EQprogramHeader_G6">EQprogramHeader_G6</span>

```
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
```



### <span id="EQareaHeader">EQareaHeader</span>

    typedef struct{
        /*
         图文字幕:0x00
         字库区域:0x01
         时间区:0x02
         温度区：0x03
         湿度区：0x04
         噪声区：0x05
         透明文本：0x06
         霓虹区：0x08
         战斗时间：0x09
         */
        Ouint8    AreaType; //区域类型
        Ouint16    AreaX; //区域X坐标
        Ouint16    AreaY; //区域Y坐标
        Ouint16    AreaWidth; //区域宽
        Ouint16    AreaHeight;//区域高
    }EQareaHeader;
### <span id="EQpageHeader">EQpageHeader</span>

    typedef struct{ //请参考协议 图文字幕区数据格式
        Ouint8   PageStyle; //数据页类型
        Ouint8   DisplayMode; //显示方式 （特效）
        Ouint8   ClearMode; // 退出方式/清屏方式
        Ouint8   Speed; // 速度等级/背景速度等级
        Ouint16  StayTime; // 停留时间， 单位为 10ms
        Ouint8   RepeatTime;//重复次数/背景拼接步长(左右拼接下为宽度， 上下拼接为高度)
        Ouint16  ValidLen;  //用法比较复杂请参考协议
    	E_arrMode arrMode; //排列方式--单行多行
    	Ouint16  fontSize; //字体大小
    	Ouint32  color; //字体颜色 E_Color_G56此通过此枚举值可以直接配置七彩色，如果大于枚举范围使用RGB888模式
    	Obool    fontBold; //是否为粗体 false:0  true:1
    	Obool    fontItalic;//是否为斜体 false:0  true:1
    	E_txtDirection tdirection;//文字方向
    	Ouint16   txtSpace; //文字间隔   
    	Ouint8 Halign; //横向对齐方式（0系统自适应、1左对齐、2居中、3右对齐）
    	Ouint8 Valign; //纵向对齐方式（0系统自适应、1上对齐、2居中、3下对齐）
    }EQpageHeader;
### <span id="EQtimeAreaData_G56">EQtimeAreaData_G56</span>

	typedef struct{
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
	}EQtimeAreaData_G56;
### <span id="EQAnalogClockHeader_G56">EQAnalogClockHeader_G56</span>

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
	}EQAnalogClockHeader_G56;
### <span id="ClockColor_G56">ClockColor_G56</span>

	typedef struct{
			Ouint32 Color369; //369点颜色
			Ouint32 ColorDot; //点颜色
			Ouint32 ColorBG;  //表盘外圈颜色 模式没有圈泽此颜色无效
	}ClockColor_G56;
### <span id="EQprogram">EQprogram</span>

    typedef struct{
        Ouint8 fileName[4]; //文件名
        Ouint8 fileType; //文件类型
        Ouint32 fileLen; //文件长度
        Ouint8* fileAddre; // 文件所在的缓存地址
    	Ouint32 fileCRC32; //文件CRC32校验码
    }EQprogram;
### <span id="EQareaHeader_G6">EQareaHeader_G6</span>

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
	
		//语音内容
		//使用语音功能时：部分卡需要配置串口为语音模式！！！
		EQSound_6G stSoundData;
	
	}EQareaHeader_G6;
### <span id="EQSound_6G">EQSound_6G</span>

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
	EQSound_6G;
### <span id="EQpageHeader_G6">EQpageHeader_G6</span>

	typedef struct
	{
		Ouint8   PageStyle;			//数据页类型
		Ouint8   DisplayMode;		//显示方式:0x00 –随机显示; 0x01–静止显示; 0x02–快速打出; 0x03–向左移动; ...0x25 –向右移动  0x26 –向右连移  0x27 –向下移动  0x28 –向下连移
		Ouint8   ClearMode;			//退出方式/清屏方式
		Ouint8   Speed;				//速度等级
		Ouint16  StayTime;			//停留时间，单位为 10ms 
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
	}EQpageHeader_G6;
### <span id="EQprogram_G6">EQprogram_G6</span>

```
typedef struct{
 		Ouint8  fileName[4]; //节目参数文件名
 		Ouint8  fileType;	 //文件类型
 		Ouint32 fileLen;	 //参数文件长度
 		Ouint8* fileAddre;   //文件所在的缓存地址
		Ouint8  dfileName[4];//节目数据文件名
		Ouint8  dfileType;   //节目数据文件类型
		Ouint32 dfileLen;	 //数据文件长度
		Ouint8* dfileAddre;  //数据文件缓存地址
 	}EQprogram_G6;
```

### <span id="Brightness">Brightness </span>


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
### <span id="EQscreenframeHeader">EQscreenframeHeader</span>

    typedef struct{
        Ouint8   FrameDispFlag; //标志位 0x01
        Ouint8   FrameDispStyle;//边框显示方式： 0x00 –闪烁 0x01 –顺时针转动 0x02 –逆时针转动 0x03 –闪烁加顺时针转动 0x04 –闪烁加逆时针转动 0x05 –红绿交替闪烁 0x06 –红绿交替转动 0x07 –静止打出 
        Ouint8   FrameDispSpeed; //边框显示速度
        Ouint8   FrameMoveStep; //边框移动步长，单位为点，此参 数范围为 1~16 
        Ouint8   FrameWidth; //边框组元宽度，此参数范围为 1~8 
        Ouint16  FrameBackup; //备用字 0
    }EQscreenframeHeader;
### <span id="EQareaframeHeader">EQareaframeHeader</span>

	typedef struct{
		Ouint8   AreaFFlag; //标志位 0x01
		Ouint8   AreaFDispStyle;//边框显示方式： 0x00 –闪烁 0x01 –顺时针转动 0x02 –逆时针转动 0x03 –闪烁加顺时针转动 0x04 –闪烁加逆时针转动 0x05 –红绿交替闪烁 0x06 –红绿交替转动 0x07 –静止打出 
		Ouint8   AreaFDispSpeed; //边框显示速度
		Ouint8   AreaFMoveStep; //边框移动步长，单位为点，此参 数范围为 1~16 
		Ouint8   AreaFWidth; //边框组元宽度，此参数范围为 1~8 
		Ouint16  AreaFBackup;  //备用字 0
	}EQareaframeHeader;
### <span id="EQscreenframeHeader_G6">EQscreenframeHeader_G6</span>

	typedef struct 
	{
		Ouint8 FrameDispStype;    //边框显示方式
		Ouint8 FrameDispSpeed;    //边框显示速度
		Ouint8 FrameMoveStep;     //边框移动步长
		Ouint8 FrameUnitLength;   //边框组元长度
		Ouint8 FrameUnitWidth;    //边框组元宽度
		Ouint8 FrameDirectDispBit;//上下左右边框显示标志位，目前只支持6QX-M卡    
	}EQscreenframeHeader_G6;
### <span id="DynamicAreaParams">DynamicAreaParams</span>

	typedef struct
	{
		Ouint8 uAreaId;
		EQareaHeader_G6 oAreaHeader_G6;
		EQpageHeader_G6 stPageHeader;
		Ouint8* fontName;
		Ouint8* strAreaTxtContent;     //当调用图片的接口函数时，这个字段中的值为图片的路径文件名；
	}DynamicAreaParams;

### <span id="EQareaframeHeader">EQareaframeHeader</span>

	typedef struct{
		Ouint8   AreaFFlag;如果此字段为 0x00，则以下 区域边框属性不发送 
		Ouint8   AreaFDispStyle;边框显示方式： 0x00 –闪烁 0x01 –顺时针转动 0x02 –逆时针转动 0x03 –闪烁加顺时针转动 0x04 –闪烁加逆时针转动 0x05 –红绿交替闪烁 0x06 –红绿交替转动 0x07 –静止打出 
		Ouint8   AreaFDispSpeed;边框显示速度 1-7
		Ouint8   AreaFMoveStep;边框移动步长，单位为点，此参 数范围为 1~16 
		Ouint8   AreaFWidth;边框组元宽度，此参数范围为 1~8 
		Ouint16  AreaFBackup;备用字 0
	}EQareaframeHeader;
### <span id="EQfontData">EQfontData</span>

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
	}EQfontData;
### <span id="DynamicAreaBaseInfo_5G">DynamicAreaBaseInfo_5G</span>

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
### <span id="TimingOnOff">TimingOnOff</span>

```
typedef struct {
Ouint8 onHour;   // 开机小时
Ouint8 onMinute; // 开机分钟
Ouint8 offHour;  // 关机小时
Ouint8 offMinute; // 关机分钟
}TimingOnOff;
```





### 枚举类型

#### 日期格式

```
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
```



#### 时间格式

```
typedef enum
{
	eHH_MM_SS_COLON,  //HH:MM:SS
	eHH_MM_SS_CHS,    //HH时MM分SS秒
	eHH_MM_COLON,     //HH:MM
	eHH_MM_CHS,       //HH时MM分
	eAM_HH_MM,        //AM HH:MM
	eHH_MM_AM,        //HH:MM AM
}E_TimeStyle;
```



#### 星期格式

```
typedef enum
{
	eMonday=1,    //Monday
	eMon,         //Mon.
	eMonday_CHS,  //星期一
}E_WeekStyle;
```



#### <span id="E_ClockStyle">表盘格式</span>

```
typedef enum
{
	eLINE,     //线形
	eSQUARE,   //方形
	eCIRCLE,   //圆形
}E_ClockStyle;//表盘样式
```



#### <span id="E_ClockStyle">文字方向</span>

```
typedef enum
{
	pNORMAL,       //正常
	pROTATERIGHT,  //向右旋转
	pMIRROR,       //镜像
	pROTATELEFT,   //向左旋转
}E_txtDirection;//图文区文字方向---暂不支持
```



### 显示方式

```
0x00 –随机显示 
0x01 –静止显示 
0x02 –快速打出 
0x03 –向左移动 
0x04 –向左连移 
0x05 –向上移动 
0x06 –向上连移 
0x07 –闪烁 
0x08 –飘雪 
0x09 –冒泡 
0x0a –中间移出 
0x0b –左右移入 
0x0c –左右交叉移入 
0x0d –上下交叉移入 
0x0e –画卷闭合 
0x0f –画卷打开 
0x10 –向左拉伸 
0x11 –向右拉伸 
0x12 –向上拉伸 
0x13 –向下拉伸 
0x14 –向左镭射 
0x15 –向右镭射 
0x16 –向上镭射 
0x17 –向下镭射 
0x18 –左右交叉拉幕 
0x19 –上下交叉拉幕 
0x1a –分散左拉 
0x1b –水平百页 
0x1c –垂直百页 
0x1d –向左拉幕 
0x1e –向右拉幕 
0x1f –向上拉幕 
0x20 –向下拉幕 
0x21 –左右闭合 
0x22 –左右对开 
0x23 –上下闭合 
0x24 –上下对开 
0x25 –向右移动 
0x26 –向右连移 
0x27 –向下移动 
0x28 –向下连移 
```


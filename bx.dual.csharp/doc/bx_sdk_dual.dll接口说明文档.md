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

### １.通用API

#### １.1非节目相关

##### １.1.1 bxDual_InitSdk

**返回值：**成功返回0；失败返回错误号 

**参数：**⽆ 

**说明：** 初始化动态库 

**函数：**public static extern int bxDual_InitSdk();

##### １.1.2 bxDual_ReleaseSdk

**返回值：**成功返回0；失败返回错误号 

**参数：**⽆ 

**说明：** 释放动态库 

**函数：**public static extern void bxDual_ReleaseSdk();

##### １.1.3 bxDual_cmd_searchController

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数    | 说明                                                         |
| ------- | ------------------------------------------------------------ |
| retData | 请参考结构体[Ping_data](#Ping_data)所有回读参数都会通过结构体回调，附录 |

**说明：** 通过各种通讯方式（AT、UDP、TCP）搜索控制器【单张控制卡】

**函数：** LEDEQSDK_API int _CALL_STD bxDual_cmd_searchController(Ping_data *retData);

##### １.1.4 bxDual_cmd_udpPing

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数    | 说明                                                         |
| ------- | ------------------------------------------------------------ |
| retData | 请参考结构体[Ping_data](#Ping_data)所有回读参数都会通过结构体回调，附录 |

**说明：** UDP ping命令并返回IP地址

**函数：** public static extern int bxDual_cmd_udpPing(ref Ping_data retData);

##### １.1.5 bxDual_cmd_uart_searchController

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数     | 说明                                                         |
| -------- | ------------------------------------------------------------ |
| retData  | 请参考结构体[Ping_data](#Ping_data)所有回读参数都会通过结构体回调，附录 |
| uartPort | 波特率:9600、57600                                           |

**说明：** 通过串口通讯方式（9600、57600）搜索控制器

**函数：** public static extern int bxDual_cmd_uart_searchController(byte[] retData, byte[] uartPort);

##### １.1.6 bxDual_cmd_tcpPing

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数    | 说明                                                         |
| ------- | ------------------------------------------------------------ |
| ip      | 控制器IP                                                     |
| port    | 控制器端口                                                   |
| retData | 请参考结构体[Ping_data](#Ping_data)所有回读参数都会通过结构体回调，附录 |

**说明：** 通过TCP方式获取到控制器相关属性和IP地址

**函数：** public static extern int bxDual_cmd_tcpPing(byte[] ip, ushort port, ref Ping_data retData);

##### 1.1.7 bxDual_cmd_setBrightness

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数       | 说明                                      |
| ---------- | ----------------------------------------- |
| ip         | 控制器IP                                  |
| port       | 控制器端口                                |
| brightness | 参考结构体[Brightness](#Brightness)，附录 |

**说明：** 设置亮度和相关模式

**函数：** public static extern int bxDual_cmd_setBrightness(byte[] ip, ushort port, ref Brightness brightness);

#### 1.2节目相关

##### 1.2.1 bxDual_program_setScreenParams_G56

**返回值：**成功返回0；失败返回错误号 

**参数：**⽆

| 参数           | 说明                                                         |
| -------------- | ------------------------------------------------------------ |
| color          | 屏基色 |
| ControllerType | 控制卡型号                                                   |
| doubleColor    | 点阵类型 |

**说明：** 设置屏相关属性 

**函数：** public static extern int bxDual_program_setScreenParams_G56(E_ScreenColor_G56 color, ushort ControllerType, E_DoubleColorPixel_G56 doubleColor);

##### 1.2.2 bxDual_cmd_ofsStartFileTransf

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数 | 说明       |
| ---- | ---------- |
| ip   | 控制器IP   |
| port | 控制器端口 |

**说明：** 开始批量写文件 

**函数：** public static extern int bxDual_cmd_ofsStartFileTransf(byte[] ip, ushort port);

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

**函数：**public static extern int bxDual_cmd_ofsWriteFile(byte[] ip, ushort port, byte[] fileName, byte fileType, uint fileLen, byte overwrite, IntPtr fileAddre);

##### 1.2.4 bxDual_cmd_ofsEndFileTransf

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数 | 说明       |
| ---- | ---------- |
| ip   | 控制器IP   |
| port | 控制器端口 |

**说明：** 写文件结束

**函数：** public static extern int bxDual_cmd_ofsEndFileTransf(byte[] ip, ushort port);

### 2.BX-5(5代)控制卡API

#### 2.1 节目API

##### 2.1.1 bxDual_program_addProgram

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数     | 说明                                                |
| -------- | --------------------------------------------------- |
| programH | 参考结构体[EQprogramHeader](#EQprogramHeader)，附录 |

**说明：** 添加节目句柄

**函数：** public static extern int bxDual_program_addProgram(ref EQprogramHeader programH);

##### 2.1.2 bxDual_program_AddArea

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数    | 说明                                          |
| ------- | --------------------------------------------- |
| areaID  | 区域的ID号                                    |
| aheader | 参考结构体[EQareaHeader](#EQareaHeader)，附录 |

**说明：** 添加区域句柄 

**函数：**public static extern int bxDual_program_AddArea(ushort areaID, ref EQareaHeader aheader);

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

**函数：**public static extern int bxDual_program_picturesAreaAddTxt(ushort areaID, byte[] str, byte[] fontName,ref EQpageHeader pheader);

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

**函数：**public static extern int bxDual_program_pictureAreaAddPic(ushort areaID, ushort picID,ref EQpageHeader pheader, byte[] picPath);

##### 2.1.5 bxDual_program_timeAreaAddContent

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数     | 说明                                                         |
| -------- | ------------------------------------------------------------ |
| areaID   | 区域的ID号                                                   |
| timeData | 详情请见时间区数据格式结构体[EQtimeAreaData_G56](#EQtimeAreaData_G56)，附录 |

**说明：** 时间分区添加内容

**函数：** public static extern int bxDual_program_timeAreaAddContent(ushort areaID, ref EQtimeAreaData_G56 timeData); 

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

**函数：**public static extern int bxDual_program_timeAreaAddAnalogClock(ushort areaID,ref EQAnalogClockHeader_G56 header, E_ClockStyle cStyle, ref  ClockColor_G56 cColor);

##### 2.1.7 bxDual_program_IntegrateProgramFile

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数    | 说明                              |
| ------- | --------------------------------- |
| program | 参考结构体[EQprogram](#EQprogram) |

**说明：** 合成节目文件返回节目文件属性及地址

**函数：** public static extern int bxDual_program_IntegrateProgramFile(ref EQprogram program);

##### 2.1.8 bxDual_program_deleteProgram

**返回值：**成功返回0；失败返回错误号 

**参数：**⽆ 

**说明：** 删除节目缓存

**函数：**public static extern int  bxDual_program_deleteProgram();

##### 2.1.9 bxDual_program_addFrame

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数                | 说明                                                  |
| ------------------- | ----------------------------------------------------- |
| EQscreenframeHeader | 边框属性[EQscreenframeHeader](#EQscreenframeHeader)   |
| picPath             | 添加的边框图片路径【图片像素 高等于边框宽，宽等于32】 |

**说明：**节目添加边框

**函数：**public static extern int bxDual_program_addFrame(ref EQscreenframeHeader sfHeader, byte[] picPath);

##### 2.1.10 bxDual_program_picturesAreaAddFrame

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数                | 说明                                                  |
| ------------------- | ----------------------------------------------------- |
| areaID              | 区域ID                                                |
| EQscreenframeHeader | 边框属性[EQareaframeHeader](#EQareaframeHeader)       |
| picPath             | 添加的边框图片路径【图片像素 高等于边框宽，宽等于32】 |

**说明：**区域添加边框

**函数：** public static extern int bxDual_program_picturesAreaAddFrame(ushort areaID,ref  EQareaframeHeader afHeader, byte[] picPath);

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

**函数：** public static extern int bxDual_dynamicArea_AddAreaWithTxt_5G(byte[] ip, int nPort, E_ScreenColor_G56 color,byte uAreaId,byte RunMode,ushort Timeout,byte RelateAllPro,ushort RelateProNum,ushort[] RelateProSerial,byte ImmePlay,ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight, EQareaframeHeader oFrame,	byte DisplayMode,byte ClearMode,byte Speed,ushort StayTime,byte RepeatTime,EQfontData oFont，byte[] fontName,byte[] strAreaTxtContent);

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

**函数：** public static extern int bxDual_dynamicArea_AddAreaWithPic_5G(byte[] ip, int nPort, E_ScreenColor_G56 color,byte uAreaId,byte RunMode,ushort Timeout,byte RelateAllPro, ushort RelateProNum,ushort[] RelateProSerial,byte ImmePlay,ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight,EQareaframeHeader oFrame,byte DisplayMode,byte ClearMode,byte Speed, ushort StayTime,byte RepeatTime,byte[] filePath);

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

**函数：** public static extern int bxDual_dynamicArea_AddAreaInfos_5G(byte[] ip, int nPort, E_ScreenColor_G56 color,byte uAreaId,byte RunMode, ushort Timeout,byte RelateAllPro,ushort RelateProNum,ushort[] RelateProSerial, byte ImmePlay,ushort uAreaX, ushort uAreaY, ushort uWidth, ushort uHeight,EQareaframeHeader oFrame,byte nInfoCount,[In] DynamicAreaBaseInfo_5G[] pInfo);

##### 2.2.4 bxDual_dynamicArea_DelArea_5G

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数    | 说明                               |
| ------- | ---------------------------------- |
| pIP     | IP                                 |
| nPort   | 端口                               |
| uAreaId | 删除的区域编号，0xFF删除所有动态区 |

**说明：** 删除动态区：

**函数：**public static extern int bxDual_dynamicArea_DelArea_5G(byte[] ip, int nPort, byte uAreaId);

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

**函数：**public static extern int bxDual_dynamicArea_DelAreaS_5G(byte[] ip, int nPort, byte uAreaCount, byte[] pAreaID);

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

**函数：** public static extern int bxDual_program_addArea_G6(ushort areaID,ref EQareaHeader_G6 aheader);

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

**函数：**public static extern int bxDual_program_picturesAreaAddTxt_G6(ushort areaID, byte[] str, byte[] fontName,ref EQpageHeader_G6 pheader);

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

**函数：**public static extern int bxDual_program_pictureAreaAddPic_G6(ushort areaID, ushort picID,ref EQpageHeader_G6 pheader, byte[] picPath);

##### 3.1.4 bxDual_program_timeAreaAddContent_G6

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数     | 说明                                                         |
| -------- | ------------------------------------------------------------ |
| areaID   | 区域的ID号                                                   |
| timeData | 详情请见时间区数据格式结构体[EQtimeAreaData_G56](#EQtimeAreaData_G56)，附录 |

**说明：** 时间分区添加内容

**函数：** public static extern int bxDual_program_timeAreaAddContent_G6(ushort areaID,ref EQtimeAreaData_G56 timeData);

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

**函数：**public static extern int bxDual_program_timeAreaAddAnalogClock_G6(ushort areaID, ref EQAnalogClockHeader_G56 header, E_ClockStyle cStyle,ref ClockColor_G56 cColor);

##### 3.1.6 program_IntegrateProgramFile_G6

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数    | 说明                                    |
| ------- | --------------------------------------- |
| program | 参考结构体[EQprogram_G6](#EQprogram_G6) |

**说明：** 合成节目文件返回节目文件属性及地址

**函数：** public static extern int bxDual_program_IntegrateProgramFile_G6(ref EQprogram_G6 program);

##### 3.1.7 program_deleteProgram_G6

**返回值：**成功返回0；失败返回错误号 

**参数：**⽆ 

**说明：** 删除节目缓存

**函数：**public static extern int bxDual_program_deleteProgram_G6();

##### 3.1.8 bxDual_program_addFrame_G6

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数                | 说明                                                      |
| ------------------- | --------------------------------------------------------- |
| EQscreenframeHeader | 边框属性[EQscreenframeHeader_G6](#EQscreenframeHeader_G6) |
| picPath             | 添加的边框图片路径【图片像素 高等于边框宽，宽等于32】     |

**说明：**节目添加边框

**函数：**public static extern int bxDual_program_addFrame_G6(ref EQscreenframeHeader_G6 sfHeader, byte[] picPath);

##### 3.1.9 bxDual_program_addProgram_G6

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数     | 说明                                                      |
| -------- | --------------------------------------------------------- |
| programH | 参考结构体[EQprogramHeader_G6](#EQprogramHeader_G6)，附录 |

**说明：** 添加节目句柄

**函数：** public static extern int bxDual_program_addProgram_G6(ref EQprogramHeader_G6 programH);

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

**函数：**public static extern int bxDual_dynamicArea_AddAreaTxt_6G(byte[] ip, int port, E_ScreenColor_G56 color, byte uAreaId, ushort uAreaX, ushort uAreaY,ushort uWidth, ushort uHeight, byte[] fontName, byte nFontSize, byte[] strAreaTxtContent);

##### 3.2.2 bxDual_dynamicArea_AddAreaTxtDetails_6G

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数              | 说明                                                    |
| ----------------- | ------------------------------------------------------- |
| pIP               | IP                                                      |
| nPort             | 端口                                                    |
| color             | 屏基色                                                  |
| uAreaId           | 区域编号                                                |
| oAreaHeader_G6    | 区域参数，结构体[EQareaHeader_G6](#EQareaHeader_G6)附录 |
| stPageHeader      | 数据页，附录[EQpageHeader_G                             |
| fontName          | 字体                                                    |
| strAreaTxtContent | 显示内容                                                |
**说明：** 6代更新动态区详细功能：仅显示动态区; 将要显示的一些特性/属性，封装在 EQareaHeader_G6 和 EQpageHeader_G6 结构体中

**函数：**public static extern int bxDual_dynamicArea_AddAreaTxtDetails_6G(byte[] ip, int nPort, E_ScreenColor_G56 color, byte uAreaId,IntPtr oAreaHeader_G6, IntPtr stPageHeader, byte[] fontName, byte[] strAreaTxtContent);

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

**函数：**public static extern int bxDual_dynamicArea_AddAreaTxtDetails_WithProgram_6G(byte[] ip, int nPort, E_ScreenColor_G56 color, byte uAreaId, IntPtr oAreaHeader_G6, IntPtr stPageHeader, byte[] fontName, byte[] strAreaTxtContent, ushort RelateProNum, ushort[] RelateProSerial);

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

**函数：**public static extern int bxDual_dynamicArea_AddAreaPic_6G(byte[] ip, int nPort, E_ScreenColor_G56 color, byte uAreaId, ushort AreaX, ushort AreaY,ushort AreaWidth, ushort AreaHeight, IntPtr pheader, byte[] picPath);

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

**函数：**public static extern int bxDual_dynamicArea_AddAreaPic_WithProgram_6G(byte[] ip, int nPort, E_ScreenColor_G56 color, byte uAreaId, ushort[] AreaX, ushort[] AreaY, ushort[] AreaWidth, ushort[] AreaHeight, IntPtr pheader, byte[] picPath, ushort RelateProNum, ushort[] RelateProSerial);

##### 3.2.6 bxDual_dynamicArea_DelArea_6G

**返回值：**成功返回0；失败返回错误号 

**参数：**

| 参数    | 说明                               |
| ------- | ---------------------------------- |
| pIP     | IP                                 |
| nPort   | 端口                               |
| uAreaId | 删除的区域编号，0xFF删除所有动态区 |

**说明：** 删除动态区：

**函数：**public static extern int bxDual_dynamicArea_DelArea_6G(byte[] ip, int nPort, byte uAreaId);

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

**函数：**public static extern int bxDual_dynamicArea_DelAreas_6G(byte[] ip, int nPort, byte uAreaCount, byte[] pAreaID);

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

**函数：**public static extern int bxDual_dynamicAreaS_AddTxtDetails_6G(byte[] ip, int nPort, E_ScreenColor_G56 color, byte uAreaCount, [In] DynamicAreaParams[] pParams);

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

**函数：**public static extern int bxDual_dynamicAreaS_AddTxtDetails_WithProgram_6G(byte[] ip, int nPort, E_ScreenColor_G56 color, byte uAreaCount, [In] DynamicAreaParams[] pParams, ushort RelateProNum, ushort[] RelateProSerial);

#### 3.3 其它API

## 附录

###  <span id="Ping_data">Ping_data</span>

```
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
            public ushort Address;
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
```
### <span id="EQprogram">EQprogram</span>

```
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
```

### <span id="EQprogram_G6">EQprogram_G6</span>

```
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
```

### <span id="EQprogramHeader">EQprogramHeader</span>

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
### <span id="EQprogramHeader_G6">EQprogramHeader_G6</span>

```
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
            //public byte PlayPeriodGrpNum;		//播放时段的组数
        }
```



### <span id="EQareaHeader">EQareaHeader</span>

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
                 动态区：0x10
                 */
                public byte AreaType; //区域类型
    
                public ushort AreaX; //区域X坐标
                public ushort AreaY; //区域Y坐标
                public ushort AreaWidth; //区域宽
                public ushort AreaHeight;//区域高
            }
### <span id="EQpageHeader">EQpageHeader</span>

           [StructLayoutAttribute(LayoutKin)]
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
### <span id="EQtimeAreaData_G56">EQtimeAreaData_G56</span>

	        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
	        public struct EQtimeAreaData_G56
	        {
	            public E_arrMode linestyle;			//排列方式，单行还是多行
	            public uint color;				//字体颜色
	            public IntPtr fontName;           //字体名字
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
### <span id="EQAnalogClockHeader_G56">EQAnalogClockHeader_G56</span>

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
### <span id="ClockColor_G56">ClockColor_G56</span>

	       [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
	        public struct ClockColor_G56
	        {
	            public uint Color369; //369点颜色
	            public uint ColorDot; //点颜色
	            public uint ColorBG;  //表盘外圈颜色 模式没有圈泽此颜色无效
	        }
### <span id="EQprogram">EQprogram</span>

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
### <span id="EQareaHeader_G6">EQareaHeader_G6</span>

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
### <span id="EQSound_6G">EQSound_6G</span>

	      [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
	        public struct EQSound_6G
	        {
	            public byte SoundFlag;		//1 0x00 是否使能语音播放;0 表示不使能语音; 1 表示播放下文中 SoundData 部分内容;
	            //SoundData 部分内容---------------------------------------------------------------------------------------------------------------------------------------------------
	            public byte SoundPerson;		//1 0x00 发音人 该值范围是 0 - 5，共 6 种选择只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 0
	            public byte SoundVolum;		//1 0x05 音量该值范围是 0~10，共 11 种，0表示静音只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 5
	            public byte SoundSpeed;		//1 0x05 语速该值范围是 0~10，共 11 种只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 5
	            public byte SoundDataMode;	//1 0x00 SoundData 的编码格式：该值意义如下：0x00 GB2312; 0x01 GBK; 0x02 BIG5; 0x03 UNICODE只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送
	            public uint SoundReplayTimes;	// 4 0x00000000 重播次数该值为 0，表示播放 1 次该值为 1，表示播放 2 次
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
### <span id="EQpageHeader_G6">EQpageHeader_G6</span>

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
### <span id="EQprogram_G6">EQprogram_G6</span>

```
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
```

### <span id="Brightness">Brightness </span>


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
### <span id="EQscreenframeHeader">EQscreenframeHeader</span>

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
### <span id="EQareaframeHeader">EQareaframeHeader</span>

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
### <span id="EQscreenframeHeader_G6">EQscreenframeHeader_G6</span>

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
### <span id="DynamicAreaParams">DynamicAreaParams</span>

	        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
	        public struct DynamicAreaParams
	        {
	            public byte uAreaId;
	            public EQareaHeader_G6 oAreaHeader_G6;
	            public EQpageHeader_G6 stPageHeader;
	            public IntPtr fontName;
	            public IntPtr strAreaTxtContent;
	        }

### <span id="EQareaframeHeader">EQareaframeHeader</span>

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
### <span id="EQfontData">EQfontData</span>

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
### <span id="DynamicAreaBaseInfo_5G">DynamicAreaBaseInfo_5G</span>

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


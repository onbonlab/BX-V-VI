# Dual Delphi SDK
本项目为仰邦科技 单双色 系列的 delphi实现，调用仰邦封装的动态库文件，任何人都可直接在此代码上进行添加与修改。

本项目由Delphi7编写， 本 demo 中提供了 TCP 模式和RS485/232的简单使用方式。

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

```Delphi
err:=bxDual_InitSdk();
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
```


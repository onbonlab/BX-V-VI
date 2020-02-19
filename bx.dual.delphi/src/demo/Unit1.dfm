object Form1: TForm1
  Left = 1316
  Top = 302
  Width = 324
  Height = 306
  Caption = 'Form1'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnClose = FormClose
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 136
    Top = 32
    Width = 32
    Height = 13
    Caption = 'Label1'
  end
  object Label2: TLabel
    Left = 136
    Top = 64
    Width = 32
    Height = 13
    Caption = 'Label2'
  end
  object Label3: TLabel
    Left = 136
    Top = 104
    Width = 32
    Height = 13
    Caption = 'Label3'
  end
  object Label4: TLabel
    Left = 136
    Top = 144
    Width = 32
    Height = 13
    Caption = 'Label4'
  end
  object Label5: TLabel
    Left = 136
    Top = 184
    Width = 32
    Height = 13
    Caption = 'Label5'
  end
  object Button1: TButton
    Left = 16
    Top = 22
    Width = 97
    Height = 25
    Caption = 'InitSdk'
    TabOrder = 0
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 16
    Top = 56
    Width = 97
    Height = 25
    Caption = 'udpPing'
    TabOrder = 1
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 16
    Top = 96
    Width = 97
    Height = 25
    Caption = 'SendProgram_5'
    TabOrder = 2
    OnClick = Button3Click
  end
  object Button4: TButton
    Left = 16
    Top = 136
    Width = 97
    Height = 25
    Caption = 'SendProgram_6'
    TabOrder = 3
    OnClick = Button4Click
  end
  object Button5: TButton
    Left = 16
    Top = 176
    Width = 97
    Height = 25
    Caption = 'Dynamic_6'
    TabOrder = 4
  end
  object Button6: TButton
    Left = 184
    Top = 56
    Width = 75
    Height = 25
    Caption = 'tcpPing'
    TabOrder = 5
    OnClick = Button6Click
  end
end

# HmAppBitChecker

![HmAppBitChecker v1.0.0](https://img.shields.io/badge/HmAppBitChecker-v1.0.0-6479ff.svg)
[![CC0](https://img.shields.io/badge/license-CC0-blue.svg?style=flat)](LICENSE.txt)
![.NET Framework 4.5](https://img.shields.io/badge/.NET_Framework-4.5-6479ff.svg?logo=windows&logoColor=white)

## 概要

`HmAppBitChecker`は、Windowsのネイティブな実行ファイル（`.exe`）やダイナミックリンクライブラリ（`.dll`）が、32bitアプリケーションか64bitアプリケーションかを判定するためのコマンドラインツールです。

## 主な機能

- 指定されたファイルが32bitか64bitかを判定します。
- 結果をコンソール出力と終了コードの両方で返します。
- バッチファイルなどのスクリプトから簡単に利用できます。

## 動作環境

- .NET Framework 4.5 以上

## ビルド方法

1.  Visual Studioで`HmAppBitChecker.sln`ファイルを開きます。
2.  「ビルド」メニューから「ソリューションのビルド」を選択します。
3.  `HmAppBitChecker/HmAppBitChecker/bin/Release/`（または`Debug`）ディレクトリに実行ファイル`HmAppBitChecker.exe`が生成されます。

## 使い方

### コマンドライン

```sh
HmAppBitChecker.exe <ファイルパス>
```

- **`<ファイルパス>`**: 判定したい`.exe`または`.dll`ファイルのパスを指定します。

### 出力

プログラムは判定結果に応じて、以下のいずれかを**コンソールに出力**します。

| 出力    | 意味                                     |
| :------ | :--------------------------------------- |
| `x86`   | 32bit アプリケーションです。             |
| `x64`   | 64bit アプリケーションです。             |
| `0`     | 判定不能、またはエラーです。下記参照。   |

### 終了コード

プログラムは判定結果に応じて、以下のいずれかの**終了コード (`%ERRORLEVEL%`)** を返します。

| 終了コード | 意味                                     |
| :--------- | :--------------------------------------- |
| `32`       | 32bit アプリケーションです。             |
| `64`       | 64bit アプリケーションです。             |
| `0`        | 判定不能、またはエラーです。下記参照。   |


#### `0`が返されるケース

出力および終了コードで`0`が返されるのは、主に以下の場合です。
- コマンドライン引数にファイルパスが指定されなかった。
- 指定されたファイルが存在しない。
- ファイルが32bitまたは64bitのWindowsアプリケーションではない（例: MS-DOS形式、16bit形式など）。
- ファイルが壊れている、または実行ファイル形式ではない。

### 使用例 (バッチファイル)

```cmd
@echo off
HmAppBitChecker.exe "C:\path\to\your\application.exe"

if %ERRORLEVEL%==64 (
    echo "これは64bit版のアプリケーションです。"
) else if %ERRORLEVEL%==32 (
    echo "これは32bit版のアプリケーションです。"
) else if %ERRORLEVEL%==0 (
    echo "判定できませんでした。ファイルを確認してください。"
)
```

## ライセンス

このソフトウェアは **CC0 1.0 Universal** の条件の下で提供されます。
詳細は`LICENSE.txt`ファイルをご覧ください。

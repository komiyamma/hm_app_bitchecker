# HmAppBitChecker

![HmAppBitChecker v1.0.0](https://img.shields.io/badge/HmAppBitChecker-v1.0.0-6479ff.svg)
[![CC0](https://img.shields.io/badge/license-CC0-blue.svg?style=flat)](LICENSE)
![.NET Framework 4.5](https://img.shields.io/badge/.NET_Framework-4.5-6479ff.svg?logo=windows&logoColor=white)

このプログラムは、ネイティブのexeやdllに対して、対象が32bitなのか64bitなのか判定します。
コンソール上に「x86」もしくは「x64」もしくは「0」が出力されます。
プログラム結果のシェルへの返り値は「32」もしくは「64」もしくは「0」が返ります。

- 使用例:

```cmd
HmAppBitChecker aaa.exe

if %ERRORLEVEL%==32 (
	echo "32bit版";
)

if %ERRORLEVEL%==64 (
	echo "64bit版";
)

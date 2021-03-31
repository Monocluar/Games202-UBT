@echo off

rem ## PPEngine Visual Studio project setup script
rem ## Copyright Epic Games, Inc. All Rights Reserved.
rem ##
rem ## This script is expecting to exist in the PPE root directory.  It will not work correctly
rem ## if you copy it to a different location and run it.

setlocal
echo Setting up PPEngine project files...


rem ## First, make sure the batch file exists in the folder we expect it to.  This is necessary in order to
rem ## verify that our relative path to the /Engine/Source directory is correct
if not exist "%~dp0..\..\Source" goto Error_BatchFileInWrongLocation


rem ## Change the CWD to /Engine/Source.  We always need to run UnrealBuildTool from /Engine/Source!
pushd "%~dp0..\..\Source"
if not exist ..\Build\BatchFiles\GenerateProjectFiles.bat goto Error_BatchFileInWrongLocation


rem ## Check to make sure that we have a Binaries directory with at least one dependency that we know that UnrealBuildTool will need
rem ## in order to run.  It's possible the user acquired source but did not download and unpack the other prerequiste binaries.
if not exist ..\Build\PPEngineMarker.dat goto Error_MissingBinaryPrerequisites

rem ## Get the path to MSBuild
call "%~dp0GetMSBuildPath.bat"
if errorlevel 1 goto Error_NoVisualStudioEnvironment

rem ## 修复依赖关系的东西，暂不使用
rem ## call "%~dp0FixDependencyFiles.bat"

rem ## If we're using VS2017, check that NuGet package manager is installed. MSBuild fails to compile C# projects from the command line with a cryptic error if it's not: 
rem ## https://developercommunity.visualstudio.com/content/problem/137779/the-getreferencenearesttargetframeworktask-task-wa.html
if not exist "%ProgramFiles(x86)%\Microsoft Visual Studio\Installer\vswhere.exe" goto NoVsWhere

set MSBUILD_15_EXE=
for /f "delims=" %%i in ('"%ProgramFiles(x86)%\Microsoft Visual Studio\Installer\vswhere" -latest -products * -requires Microsoft.Component.MSBuild -property installationPath') do (
	if exist "%%i\MSBuild\15.0\Bin\MSBuild.exe" (
		set MSBUILD_15_EXE="%%i\MSBuild\15.0\Bin\MSBuild.exe"
		goto FoundMsBuild15
	)
)
:FoundMsBuild15

set MSBUILD_15_EXE_WITH_NUGET=
for /f "delims=" %%i in ('"%ProgramFiles(x86)%\Microsoft Visual Studio\Installer\vswhere" -latest -products * -requires Microsoft.Component.MSBuild -requires Microsoft.VisualStudio.Component.NuGet -property installationPath') do (
	if exist "%%i\MSBuild\15.0\Bin\MSBuild.exe" (
		set MSBUILD_15_EXE_WITH_NUGET="%%i\MSBuild\15.0\Bin\MSBuild.exe"
		goto FoundMsBuild15WithNuget
	)
)
:FoundMsBuild15WithNuget

if not [%MSBUILD_EXE%] == [%MSBUILD_15_EXE%] goto NoVsWhere
if not [%MSBUILD_EXE%] == [%MSBUILD_15_EXE_WITH_NUGET%] goto Error_RequireNugetPackageManager

:NoVsWhere

rem Check to see if the files in the UBT directory have changed. We conditionally include platform files from the .csproj file, but MSBuild doesn't recognize the dependency when new files are added. 
md ..\Intermediate\Build >nul 2>nul
dir /s /b Programs\UnrealBuildTool\*.cs >..\Intermediate\Build\UnrealBuildToolFiles.txt
if exist ..\..\Platforms dir /s /b ..\..\Platforms\*.cs >> ..\Intermediate\Build\UnrealBuildToolFiles.txt
fc /b ..\Intermediate\Build\UnrealBuildToolFiles.txt ..\Intermediate\Build\UnrealBuildToolPrevFiles.txt >nul 2>nul
if not errorlevel 1 goto SkipClean
copy /y ..\Intermediate\Build\UnrealBuildToolFiles.txt ..\Intermediate\Build\UnrealBuildToolPrevFiles.txt >nul
%MSBUILD_EXE% /nologo /verbosity:quiet Programs\UnrealBuildTool\UnrealBuildTool.csproj /property:Configuration=Development /property:Platform=AnyCPU /target:Clean
:SkipClean
%MSBUILD_EXE% /nologo /verbosity:quiet Programs\UnrealBuildTool\UnrealBuildTool.csproj /property:Configuration=Development /property:Platform=AnyCPU /target:Build
if errorlevel 1 goto Error_UBTCompileFailed

rem ## Run UnrealBuildTool to generate Visual Studio solution and project files
rem ## NOTE: We also pass along any arguments to the GenerateProjectFiles.bat here
..\Binaries\DotNET\UnrealBuildTool.exe -ProjectFiles %*
if errorlevel 1 goto Error_ProjectGenerationFailed

rem ## Success!
popd
exit /B 0

:Error_BatchFileInWrongLocation
echo.
echo GenerateProjectFiles ERROR: 批处理文件似乎不在/Engine/Build/BatchFiles目录中。此脚本必须从该目录中运行。
echo.
pause
goto Exit


:Error_MissingBinaryPrerequisites
echo.
echo GenerateProjectFiles ERROR: 缺少生成文件，查看一下自身项目..\Build\PPEngineMarker.dat 是否含有该文件
echo.
pause
goto Exit


:Error_NoVisualStudioEnvironment
echo.
echo GenerateProjectFiles ERROR: 找不到Visual Studio的有效安装。请检查是否已安装Visual Studio 2017或Visual Studio 2019，并且已选择MSBuild组件作为安装的一部分。
echo.
pause
goto Exit

:Error_RequireNugetPackageManager
echo.
echo PPEngine要求安装NuGet包管理器以使用 %MSBUILD_EXE%. 请运行VisualStudio安装程序并从单个组件列表（在“代码工具”类别中）添加它。
echo.
pause
goto Exit

:Error_UBTCompileFailed
echo.
echo GenerateProjectFiles ERROR: UnreadBuildTool未能编译。
echo.
pause
goto Exit


:Error_ProjectGenerationFailed
echo.
echo GenerateProjectFiles ERROR: UnrealBuildTool was unable to generate project files.
echo.
pause
goto Exit


:Exit
rem ## Restore original CWD in case we change it
popd
exit /B 1
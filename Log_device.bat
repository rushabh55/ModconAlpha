@echo off
setlocal
pushd %~dp0
echo RUN THIS TOOL AND WHEN YOU'RE DONE, JUST CLOSE THE WINDOW. LOG WOULD BE GENERATED AND SAVED IN LOG.TXT
PAUSE
adb logcat | tee log.txt
popd
endlocal & exit /b %MYERRORLEVEL% 

setlocal
pushd %~dp0
pushd trunk
pushd Engineering
pushd bin
pushd Android
:: ----------------------------------------------------------------------------
:: You have the apk
:APKFOUND
echo Installing the application on your device.
adb install -r main.apk
IF %ERRORLEVEL% NEQ 0 GOTO error

echo INSTALLED SUCCESSFULLY
echo RUNNNING THE APP

REM TODO::CHANGE THE NAME OF THE APPLICATION IF YOU ARE NOT ON ZEN. 
adb shell am start -a android.intent.action.MAIN -n com.Company.Modcon/.Session
IF %ERRORLEVEL% NEQ 0 GOTO error

:success
echo APP IS RUNNING.
popd
popd
popd
popd
popd

endlocal & exit /b 0

:: ----------------------------------------------------------------------------
:error
set MYERRORLEVEL=%ERRORLEVEL%
echo ABORTING. ERRORS FOUND
popd
popd
popd
popd
popd
endlocal & PAUSE & exit /b %MYERRORLEVEL% 

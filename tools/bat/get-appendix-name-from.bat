@echo off
rem input args (submit options) like : --master yarn-cluster --num-executors 100 --executor-cores 28 --executor-memory 30G --conf xxx=xxxx
rem this script try to get brief sumbit options, set them to AppNameBySparkOptions (-ec-28_-em-30G)
call %~dp0..\set-common-dir-and-tools.bat || exit /b 1
echo ## %* | findstr /I /R "[0-9a-z]" >nul || (echo No input args of submit options, exit %0  && exit /b 1)
rem append AppNameBySparkOptions to application name to be obvious in cluster page. curent AppNameBySparkOptions=%AppNameBySparkOptions%
:: set AppNameBySparkOptions=
for /F "tokens=*" %%a in ('echo %* ^|lzmw -it "(?:^|\s+)--([a-z])\w*-(\w)\S*\s+(\d+\w?)\w*" -o "\n-$1$2-$3\n" -PAC ^| lzmw -it "(^|\s+)-\w{1,3}-\d+\w*" -PAC ^| lzmw -S -t "\s+" -o "_" -PAC ^| lzmw -t "^_|_\s*$" -o "" -PAC ') do ( set "AppNameBySparkOptions=%%a" && exit /b 0)
exit /b 1

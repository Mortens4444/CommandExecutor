taskkill /f /im CommandExecutor.exe /t

SET sourceFolder=\\SERVER\Folder
SET destinationFolder=C:\Folder

copy %sourceFolder%\* %destinationFolder%\* 

%destinationFolder%\CommandExecutor.exe
C:\Factory\Tools\RDMD.exe /RC out

COPY Prime54\Prime54.exe out

FOR %%E IN (out\*.exe) DO (
	C:\Factory\SubTools\EmbedConfig.exe --factory-dir-disabled "%%E"
)

COPY Prime4096\Prime4096\bin\Release\Prime4096.exe out
COPY WPrime4096\WPrime4096\bin\Release\WPrime4096.exe out
COPY WPrime4096\WPrime4096\bin\Release\Chocolate.dll out
COPY WPrime4096\WPrime4096\bin\Release\Chocomint.dll out
C:\Factory\Tools\xcp.exe doc out
C:\Factory\Tools\DirFltr.exe /EF out

C:\Factory\SubTools\zip.exe /O out Prime4096

PAUSE

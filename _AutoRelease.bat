IF NOT EXIST Prime4096\. GOTO END
rem �����[�X���� qrum ���܂��B
PAUSE

CALL newcsrr

CALL ff
cx ***

IF ERRORLEVEL 1 START ?_Factory_Build_Error

CD %~dp0.

IF NOT EXIST Prime4096\. GOTO END

CALL qq
cx **

CALL _Release.bat /-P

MOVE out\Prime4096.zip S:\�����[�X��\.

START "" /B /WAIT /DC:\home\bat syncRev

CALL qrumauto rel

rem **** AUTO RELEASE COMPLETED ****

:END

#include "libs\all.h"

static void Main2(void)
{
	Consts_INIT();
	Stop_INIT();
	LoadConfig();

	if(argIs("/S"))
	{
		Stop();
		return;
	}
	if(argIs("/D")) // �����[�X���p Prime.dat �폜
	{
		LOGPOS();
		mutex();
		LOGPOS();
		coExecute_x(xcout("DEL \"%s\"", combine(getSelfDir(), "Prime.dat")));
		LOGPOS();
		unmutex();
		LOGPOS();
		return;
	}
	if(argIs("/P"))
	{
		uint64 value;
		char *outFile;

		value = toValue64(nextArg());
		outFile = nextArg();

		writeOneLineNoRet_b(outFile, A_IsPrime(value) ? "P" : "N");
		return;
	}
	if(argIs("/F"))
	{
		error(); // TODO -- �f��������
		return;
	}
	if(argIs("/L"))
	{
		error(); // TODO -- �T�� - ����������
		return;
	}
	if(argIs("/H"))
	{
		error(); // TODO -- �T�� - �傫������
		return;
	}
	if(argIs("/R"))
	{
		error(); // TODO -- �͈� - �o��
		return;
	}
	if(argIs("/C"))
	{
		error(); // TODO -- �͈� - �����o��
		return;
	}
	error(); // �s���ȃR�}���h����
}
int main(int argc, char **argv)
{
	Main2();
	termination(0);
}

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
	if(argIs("/P"))
	{
		error(); // TODO -- ����
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

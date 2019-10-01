#include "libs\all.h"

static int OutputDivFlag;

int main(int argc, char **argv)
{
	mutex();
	{
		IsPrime(2);
	}
	unmutex();

	OutputDivFlag = argIs("/D");

	if(argIs("/P"))
	{
		char *sn;
		char *outFile;

		sn      = nextArg();
		outFile = nextArg();

		writeOneLineNoRet_b(outFile, A_IsPrime(AToUI4096(sn), 0) ? "P" : "N");

		return;
	}
	if(argIs("/F"))
	{
		error(); // TODO
	}
	if(argIs("/L"))
	{
		error(); // TODO
	}
	if(argIs("/H"))
	{
		error(); // TODO
	}
	if(argIs("/R"))
	{
		error(); // TODO
	}
	if(argIs("/C"))
	{
		error(); // TODO
	}
	error_m("Unknown Arg");
}

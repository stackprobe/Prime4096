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

		writeOneLineNoRet_b(outFile, A_IsPrime(sn) ? "P" : "N");

		return;
	}
	if(argIs("/F"))
	{
		char *sn;
		char *outFile;

		sn      = nextArg();
		outFile = nextArg();

		writeOneLineNoRet_b(outFile, A_IsPrime(sn) ? "P" : "N");

		return;
	}
	error_m("Unknown Arg");
}

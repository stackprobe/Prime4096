#include "libs\all.h"

static int OutputDivFlag;

static UI4096_t GetLowerPrime(UI4096_t value)
{
	while(!UI4096_IsZero(value))
	{
		value = UI4096_Sub(value, UI4096_N1);

		if(A_IsPrime(value, 0))
			return value;

		if(IsStopped())
			break;
	}
	return UI4096_N0;
}
static UI4096_t GetHigherPrime(UI4096_t value)
{
	while(!UI4096_IsFill(value))
	{
		value = UI4096_Add(value, UI4096_N1, NULL);

		if(A_IsPrime(value, 0))
			return value;

		if(IsStopped())
			break;
	}
	return UI4096_N0;
}
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
		char *sn;
		char *outFile;

		sn      = nextArg();
		outFile = nextArg();

		writeOneLineNoRet_b_cx(outFile, UI4096ToA(GetLowerPrime(AToUI4096(sn))));

		return;
	}
	if(argIs("/H"))
	{
		char *sn;
		char *outFile;

		sn      = nextArg();
		outFile = nextArg();

		writeOneLineNoRet_b_cx(outFile, UI4096ToA(GetHigherPrime(AToUI4096(sn))));

		return;
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
int main(int argc, char **argv)
{
	Main2();
	termination(0);
}

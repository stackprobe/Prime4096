#include "libs\all.h"

static void S_Factorization(uint64 value, char *outFile)
{
	FILE *fp = fileOpen(outFile, "wt");
	uint64 dest[64];
	uint index;

	Factorization(value, dest);

	for(index = 0; dest[index] != 0ui64; index++)
		writeLine_x(fp, xcout("%I64u", dest[index]));

	fileClose(fp);
}
static uint64 GetLowerPrime(uint64 value)
{
	while(value != 0ui64)
		if(A_IsPrime(--value))
			return value;

	return 0ui64;
}
static uint64 GetHigherPrime(uint64 value)
{
	while(value != UINT64MAX)
		if(A_IsPrime(++value))
			return value;

	return 0ui64;
}
static void Main2(void)
{
	Report_INIT();
	Stop_INIT();
	LoadConfig();

	if(argIs("/2"))
	{
		IsPrime(2);
		return;
	}
	if(argIs("/D")) // リリース環境用 Prime.dat 削除
	{
		LOGPOS();
		mutex();
		LOGPOS();
		coExecute_x(xcout("DEL \"%s\"", c_combine(getSelfDir(), "Prime.dat")));
		LOGPOS();
		unmutex();
		LOGPOS();
		return;
	}
	if(argIs("/S"))
	{
		Stop();
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
		uint64 value;
		char *outFile;

		value = toValue64(nextArg());
		outFile = nextArg();

		S_Factorization(value, outFile);
		return;
	}
	if(argIs("/L"))
	{
		uint64 value;
		char *outFile;

		value = toValue64(nextArg());
		outFile = nextArg();

		writeOneLineNoRet_b_cx(outFile, xcout("%I64u", GetLowerPrime(value)));
		return;
	}
	if(argIs("/H"))
	{
		uint64 value;
		char *outFile;

		value = toValue64(nextArg());
		outFile = nextArg();

		writeOneLineNoRet_b_cx(outFile, xcout("%I64u", GetHigherPrime(value)));
		return;
	}
	if(argIs("/R"))
	{
		uint64 minval;
		uint64 maxval;
		char *outFile;

		minval = toValue64(nextArg());
		maxval = toValue64(nextArg());
		outFile = nextArg();

		FindPrimes(minval, maxval, outFile);
		return;
	}
	if(argIs("/C"))
	{
		uint64 minval;
		uint64 maxval;
		char *outFile;

		minval = toValue64(nextArg());
		maxval = toValue64(nextArg());
		outFile = nextArg();

		WritePrimeCount(minval, maxval, outFile);
		return;
	}
	error(); // 不明なコマンド引数
}
int main(int argc, char **argv)
{
	Main2();
	termination(0);
}

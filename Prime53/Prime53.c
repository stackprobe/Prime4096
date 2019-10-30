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

	cout("Prime53_MillerRabin_Lmt: %I64u\n", MillerRabin_Lmt); // test

	if(argIs("/2")) // リリース環境用 Prime.dat 作成
	{
		LOGPOS();
		IsPrime(2);
		LOGPOS();
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
		LOGPOS();
		Stop();
		LOGPOS();
		return;
	}
	if(argIs("/P"))
	{
		uint64 value;
		char *outFile;

		value = toValue64(nextArg());
		outFile = nextArg();

		LOGPOS();
		writeOneLineNoRet_b(outFile, A_IsPrime(value) ? "P" : "N");
		LOGPOS();
		return;
	}
	if(argIs("/F"))
	{
		uint64 value;
		char *outFile;

		value = toValue64(nextArg());
		outFile = nextArg();

		LOGPOS();
		S_Factorization(value, outFile);
		LOGPOS();
		return;
	}
	if(argIs("/L"))
	{
		uint64 value;
		char *outFile;

		value = toValue64(nextArg());
		outFile = nextArg();

		LOGPOS();
		writeOneLineNoRet_b_cx(outFile, xcout("%I64u", GetLowerPrime(value)));
		LOGPOS();
		return;
	}
	if(argIs("/H"))
	{
		uint64 value;
		char *outFile;

		value = toValue64(nextArg());
		outFile = nextArg();

		LOGPOS();
		writeOneLineNoRet_b_cx(outFile, xcout("%I64u", GetHigherPrime(value)));
		LOGPOS();
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

		LOGPOS();
		FindPrimes(minval, maxval, outFile);
		LOGPOS();
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

		LOGPOS();
		WritePrimeCount(minval, maxval, outFile);
		LOGPOS();
		return;
	}
	error(); // 不明なコマンド引数
}
int main(int argc, char **argv)
{
	Main2();
	termination(0);
}

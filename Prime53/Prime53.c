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
		error(); // TODO -- 判定
		return;
	}
	if(argIs("/F"))
	{
		error(); // TODO -- 素因数分解
		return;
	}
	if(argIs("/L"))
	{
		error(); // TODO -- 探索 - 小さい方へ
		return;
	}
	if(argIs("/H"))
	{
		error(); // TODO -- 探索 - 大きい方へ
		return;
	}
	if(argIs("/R"))
	{
		error(); // TODO -- 範囲 - 出力
		return;
	}
	if(argIs("/C"))
	{
		error(); // TODO -- 範囲 - 個数を出力
		return;
	}
	error(); // 不明なコマンド引数
}
int main(int argc, char **argv)
{
	Main2();
	termination(0);
}

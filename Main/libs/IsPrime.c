#include "all.h"

static int S_IsPrime(UI4096_t prm)
{
error();
	return 0; // TODO
}

#define MILLER_RABIN_LMT 10000000000000000ui64 // 10^16

int A_IsPrime(UI4096_t prm, int r_flg)
{
	uint *arr = UI4096ToUIArr(prm);

	if(GetUIArrSize(arr) <= 2)
	{
		uint64 value = (uint64)arr[1] << 32 | arr[0];

		if(r_flg)
		{
			return IsPrime_R(value);
		}
		else if(value < MILLER_RABIN_LMT)
		{
			return IsPrime(value);
		}
	}
	return S_IsPrime(prm);
}

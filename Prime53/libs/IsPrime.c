#include "all.h"

int A_IsPrime(uint64 value)
{
	if(value < MillerRabin_Lmt)
	{
		return IsPrime(value);
	}
	else
	{
		return IsPrime_M_K(value, MillerRabin_K);
	}
}

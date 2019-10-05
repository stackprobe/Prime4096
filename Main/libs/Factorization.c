#include "all.h"

static UI4096_t Sqrt(UI4096_t val)
{
	UI4096_t bVal = UI4096_N2P2048;
	UI4096_t rVal = UI4096_N0;
	UI4096_t tVal;
	UI4096_t uVal;

	while(!UI4096_IsZero(bVal = UI4096_DivTwo(bVal)))
	{
		tVal = UI4096_Add(rVal, bVal, NULL);
		uVal = UI4096_Mul(tVal, tVal, NULL);

		if(UI4096_Comp(uVal, val) <= 0)
		{
			rVal = tVal;
		}
	}
	return rVal;
}
void A_Factorization(UI4096_t val, char *outFile)
{
	FILE *fp = fileOpen(outFile, "wt");
	UI4096_t dVal = UI4096_N3;
	UI4096_t eVal = Sqrt(val);
	UI4096_t tmp[2];

	while(!UI4096_IsZero(val) && !(UI4096_y(val) & 1))
	{
		writeLine(fp, "2");
		val = UI4096_DivTwo(val);
	}
	if(!A_IsPrime(val, 0))
	{
		while(UI4096_Comp(dVal, eVal) <= 0)
		{
			if(IsStopped())
				break;

			if(A_IsPrimeOrLargeValue(dVal) && UI4096_IsZero(UI4096_Mod(val, dVal, tmp)))
			{
				writeLine(fp, c_UI4096ToA(dVal));
				val = tmp[0];

				if(A_IsPrime(val, 0))
					break;

				eVal = Sqrt(val);
			}
			else
				dVal = UI4096_Add(dVal, UI4096_N2, NULL);
		}
	}
	writeLine(fp, c_UI4096ToA(val));
	fileClose(fp);
}

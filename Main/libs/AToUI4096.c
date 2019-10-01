#include "all.h"

UI4096_t AToUI4096(char *str)
{
	uint arr[138];
	uint i;
	UI4096_t m   = UI4096_x(1000000000); // 10^9
	UI4096_t ret = UI4096_0();
	UI4096_t tmp[2];

	errorCase(!lineExp("<1,1234,09>", str));

	str = xcout("%01242s", str); // 1242 == 138 * 9

	for(i = 0; i < 138; i++)
	{
		str[1242 - 9 * i] = '\0';
		arr[i] = toValue(str + (1242 - 9) - 9 * i);
	}
	while(--i)
	{
		UI4096_t a = UI4096_x(arr[i]);

		ret = UI4096_Mul(ret, m, NULL);
		ret = UI4096_Add(ret, a, NULL);
	}

	{
		UI4096_t a = UI4096_x(arr[0]);

		ret = UI4096_Mul(ret, m, tmp);
		errorCase(!UI4096_IsZero(tmp[1]));
		ret = UI4096_Add(ret, a, tmp);
		errorCase(!UI4096_IsZero(tmp[1]));
	}

	memFree(str);

	return ret;
}
char *UI4096ToA(UI4096_t prm)
{
	char *ret = (char *)memAlloc(1242 + 1);
	uint i;
	UI4096_t m = UI4096_x(1000000000); // 10^9
	UI4096_t tmp[2];

	for(i = 0; i < 138; i++)
	{
		prm = UI4096_Div(prm, m, tmp);
		sprintf(ret + (1242 - 9) - 9 * i, "%09u", UI4096_y(tmp[1]));
	}
	return ret;
}

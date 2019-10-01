#include "all.h"

static char *NextNotZero(char *p)
{
	while(*p == '0')
		p++;

	return p;
}
UI4096_t AToUI4096(char *str)
{
	UI4096_t m   = UI4096_x(1000000000); // 10^9
	UI4096_t ret = UI4096_0();
	UI4096_t tmp[2];
	uint i;

	errorCase(!lineExp("<00><1,1234,09>", str)); // Keisan 2 P 4096 - 1 L 10 == 1233.* ==> 1234 Œ…

	str = xcout("%01242s", NextNotZero(str)); // 1242 == 138 * 9

	for(i = 0; i < 138; i++)
	{
		UI4096_t a = UI4096_x(toValue_x(strxl(str + 9 * i, 9)));

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
		errorCase(sprintf(ret + (1242 - 9) - 9 * i, "%09u", UI4096_y(tmp[1])) != 9);
	}
	trimLead(ret, '0');

	if(!*ret)
		strcpy(ret, "0");

	return ret;
}

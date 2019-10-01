#include "all.h"

static uint UIArr[512];

uint *UI4096ToUIArr(UI4096_t prm)
{
	FromUI4096(prm, UIArr);
	return UIArr;
}
uint GetUIArrSize(uint *arr)
{
	uint i;

	for(i = 512; i; i--)
		if(arr[i - 1])
			break;

	return i;
}

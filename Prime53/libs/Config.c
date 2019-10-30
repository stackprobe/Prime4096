#include "all.h"

// ---- Items ----

uint64 MillerRabin_Lmt;

// ----

void LoadConfig(void)
{
	autoList_t *lines = readResourceLines_x(changeExt(getSelfFile(), "conf"));
	uint c = 0;

	// ---- Items ----

	MillerRabin_Lmt = toValue64(getLine(lines, c++));

	// ----

	errorCase(strcmp("\\e", getLine(lines, c++)));

	releaseDim(lines, 1);
}

#include "all.h"

static uint EvStop;

static void FNLZ(void)
{
	handleClose(EvStop);
	EvStop = 0;
}
void Stop_INIT(void)
{
	EvStop = eventOpen("{8b4187e0-4234-4f24-86df-d893b40777dd}");
	addFinalizer(FNLZ);
}
void Stop(void)
{
	eventSet(EvStop);
}
int IsStopped(void)
{
	static int stopped;

	if(stopped)
	{
		LOGPOS();
		return 1;
	}
	if(pulseSec(2, NULL) && handleWaitForMillis(EvStop, 0))
	{
		LOGPOS();
		stopped = 1;
		return 1;
	}
	return 0;
}

#include "all.h"

static uint EvStop;

static void FNLZ(void)
{
	handleClose(EvStop);
}
void Stop_INIT(void)
{
	EvStop = eventOpen("{b14487c3-8699-4fab-a093-43c31182f4ba}");
	addFinalizer(FNLZ);
}
void Stop(void)
{
	eventSet(EvStop);
}
int IsStopped(void)
{
	if(pulseSec(2, NULL) && handleWaitForMillis(EvStop, 0))
	{
		LOGPOS();
		return 1;
	}
	return 0;
}

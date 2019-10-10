#include "all.h"

#define REPORT_IDENT "{0a06a4fe-041b-4d3f-9894-c6e478d75f58}" // shared_uuid
#define REPORT_MTX_NAME  REPORT_IDENT "_L"
#define REPORTED_EV_NAME REPORT_IDENT "_R"

static char *ReportFile;

static uint MtxReport;
static uint EvReported;

static void FNLZ(void)
{
	handleWaitForever(MtxReport);
	{
		removeFileIfExist(ReportFile);
	}
	mutexRelease(MtxReport);

	memFree(ReportFile);

	handleClose(MtxReport);
	handleClose(EvReported);

	ReportFile = NULL;

	MtxReport = 0;
	EvReported = 0;
}
void Report_INIT(void)
{
	ReportFile = combine(getEnvLine("TMP"), REPORT_IDENT ".tmp");

	MtxReport = mutexOpen(REPORT_MTX_NAME);
	EvReported = eventOpen(REPORTED_EV_NAME);

	addFinalizer(FNLZ);
}
void Report(double value)
{
	handleWaitForever(MtxReport);
	{
		writeOneLineNoRet_b_cx(ReportFile, xcout("%.9f", value));
	}
	mutexRelease(MtxReport);

	eventSet(EvReported);
}

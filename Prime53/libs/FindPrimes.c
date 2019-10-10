#include "all.h"

static FILE *Writer;

// ---- WrUI64 ----

#define WR_BUFF_SIZE 67000000

static uchar WrBuff[WR_BUFF_SIZE];
static uchar *WrPos = WrBuff;

static void WrUI64Flush(void)
{
	uint size = (uint)WrPos - (uint)WrBuff;

	if(fwrite(WrBuff, 1, size, Writer) != size) // ? Ž¸”s
	{
		if(GetLastError() == 0x299)
		{
			error_m("ERROR_FILE_SYSTEM_LIMITATION");
		}
		else
		{
			error();
		}
	}
	WrPos = WrBuff;
}
static void WrUI64(uint64 value)
{
	static char buff[] = "01234567890123456789\n";
	char *p = buff + 20;
	uint s;

	if(WrBuff + WR_BUFF_SIZE < WrPos + 21)
		WrUI64Flush();

	do
	{
		p--;
		*p = '0' + (value % 10);
		value /= 10;
	}
	while(value != 0);

	s = ((uint)buff + 21) - (uint)p;
	memcpy(WrPos, p, s);
	WrPos += s;
}

// ----

void FindPrimes(uint64 minval, uint64 maxval, char *outFile)
{
	uint64 value;

	Writer = fileOpen(outFile, "wb");

	if(minval <= 2)
	{
		if(2 <= maxval)
			errorCase(fprintf(Writer, "2\n") < 0);

		minval = 3;
	}
	else
		minval |= 1;

	if(maxval < minval)
		goto endSearch;

	maxval--;
	maxval |= 1;

	for(value = minval; ; value += 2)
	{
		if(value % 0x08000000 == 1)
		{
			if(IsStopped())
				break;

			{
				double rate = (value - minval) * 1.0 / (maxval - minval);

				Report(rate * 0.5);
			}
		}
		if(IsPrime_R(value))
			WrUI64(value);

		if(value == maxval)
			break;
	}
	WrUI64Flush();

endSearch:
	fileClose(Writer);
	Writer = NULL;
}
void WritePrimeCount(uint64 minval, uint64 maxval, char *outFile)
{
	uint64 count = 0;
	uint64 value;

	if(minval <= 2)
	{
		if(2 <= maxval)
			count++;

		minval = 3;
	}
	else
		minval |= 1;

	if(maxval < minval)
		goto endSearch;

	maxval--;
	maxval |= 1;

	for(value = minval; ; value += 2)
	{
		if(value % 0x10000000 == 1)
		{
			if(IsStopped())
				break;

			{
				double rate = (value - minval) * 1.0 / (maxval - minval);

				Report(rate * 0.5);
			}
		}
		if(IsPrime_R(value))
			count++;

		if(value == maxval)
			break;
	}

endSearch:
	Writer = fileOpen(outFile, "wb");

	WrUI64(count);
	WrUI64Flush();

	fileClose(Writer);
	Writer = NULL;
}

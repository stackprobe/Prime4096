using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.TCalcs;
using Charlotte.Tools;
using System.Threading;

namespace Charlotte
{
	public static class Ground
	{
		public static TCalc TCalc_Int = new TCalc(10, 0);
		public static ReportMgr ReportMgr = new ReportMgr();

		public static void Destroy()
		{
			ReportMgr.Dispose();
			ReportMgr = null;
		}
	}
}

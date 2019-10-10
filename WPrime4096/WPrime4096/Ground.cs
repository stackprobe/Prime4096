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
		public static readonly TCalc TCalc_Int = new TCalc(10, 0);

		public static Mutex MtxReport = MutexTools.Create(Consts.REPORT_MTX_NAME);
		public static NamedEventUnit EvReported = new NamedEventUnit(Consts.REPORTED_EV_NAME);

		public static void Destroy()
		{
			Ground.MtxReport.Dispose();
			Ground.MtxReport = null;

			Ground.EvReported.Dispose();
			Ground.EvReported = null;
		}
	}
}

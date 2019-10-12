using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using Charlotte.Tools;

namespace Charlotte
{
	public class ReportMgr : IDisposable
	{
		private Mutex MtxReport = MutexTools.Create(Consts.REPORT_MTX_NAME);
		private NamedEventUnit EvReported = new NamedEventUnit(Consts.REPORTED_EV_NAME);

		public Report GetReport() // ret: null == レポート無し
		{
			if (this.EvReported.WaitForMillis(0))
			{
				using (new MSection(this.MtxReport))
				{
					if (File.Exists(Consts.ReportFile))
					{
						string[] lines = File.ReadAllLines(Consts.ReportFile, Encoding.ASCII);

						return new Report()
						{
							ProgressRate = double.Parse(lines[0]),
							CurrentValue = lines[1],
						};
					}
				}
			}
			return null;
		}

		public void Dispose()
		{
			if (this.MtxReport != null)
			{
				this.MtxReport.Dispose();
				this.MtxReport = null;

				this.EvReported.Dispose();
				this.EvReported = null;
			}
		}
	}
}

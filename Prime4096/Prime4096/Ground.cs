using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Charlotte.Tools;
using Charlotte.TCalcs;
using System.Threading;

namespace Charlotte
{
	public static class Ground
	{
		public static readonly TCalc TCalc_Int = new TCalc(10, 0);

		// ---- Conf 項目 ----

		public static int MillerRabin_K = 50;

		// ----

		public static void LoadConf()
		{
			string confFile = Path.Combine(ProcMain.SelfDir, Path.GetFileNameWithoutExtension(ProcMain.SelfFile) + ".conf");

			if (File.Exists(confFile) == false)
				return;

			string[] lines = File.ReadAllLines(confFile, StringTools.ENCODING_SJIS).Where(line => line != "" && line.StartsWith(";") == false).ToArray();
			int c = 0;

			if (lines.Length != int.Parse(lines[c++])) // 有効項目数
				throw new Exception();

			// ---- Conf 項目 ----

			MillerRabin_K = IntTools.ToInt(lines[c++], 1, IntTools.IMAX, 30);

			// ----
		}

		public static Mutex MtxProcStartEnd = MutexTools.Create("{0a47d7c9-b6f1-499d-8a02-be94669f9fcf}");

		public static NamedEventUnit EvStop = new NamedEventUnit("{c4ef09ea-5598-4ddf-98f0-9c06b17d9b6c}");

		public static Mutex MtxReport = MutexTools.Create(Consts.REPORT_MTX_NAME);
		public static NamedEventUnit EvReported = new NamedEventUnit(Consts.REPORTED_EV_NAME);

		public static void Destroy()
		{
			MtxProcStartEnd.Dispose();
			MtxProcStartEnd = null;

			EvStop.Dispose();
			EvStop = null;

			MtxReport.Dispose();
			MtxReport = null;

			EvReported.Dispose();
			EvReported = null;
		}
	}
}

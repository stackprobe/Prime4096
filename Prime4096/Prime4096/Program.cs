using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Charlotte.Tools;
using System.Numerics;
using Charlotte.Chocomint.Dialogs;

namespace Charlotte
{
	class Program
	{
		public const string APP_IDENT = "{6b52bb57-5925-4355-9394-db6fda18be73}";
		public const string APP_TITLE = "Prime4096";

		static void Main(string[] args)
		{
			ProcMain.CUIMain(new Program().Main2, APP_IDENT, APP_TITLE);

#if DEBUG
			//if (ProcMain.CUIError)
			{
				Console.WriteLine("Press ENTER.");
				Console.ReadLine();
			}
#endif
		}

		private void Main2(ArgsReader ar)
		{
			using (new MSection(Ground.MtxProcStartEnd))
			{
				this.Main2B(ar);
			}
			Ground.Destroy();
		}

		private void Main2B(ArgsReader ar)
		{
			string errorReportFile = Path.Combine(ProcMain.SelfDir, Consts.ERROR_REPORT_LOCAL_FILE);

			FileTools.Delete(errorReportFile);

			try
			{
				this.Main3(ar);
			}
			catch (Exception e)
			{
				File.WriteAllText(errorReportFile, GetLiteMessage(e), Encoding.UTF8);
				throw;
			}
		}

		private static string GetLiteMessage(Exception e)
		{
			return FileTools.TextToLines("" + e)[0];
		}

		private void Main3(ArgsReader ar)
		{
			Prime53.INIT();
			Ground.LoadConf();

			this.Main4(ar);

			Common.RemoveReportFile();
			//Ground.Destroy(); // moved
		}

		private void Main4(ArgsReader ar)
		{
			using (MSection.Unsection(Ground.MtxProcStartEnd))
			{
				this.Main4B(ar);
			}
		}

		private void Main4B(ArgsReader ar)
		{
			if (ar.ArgIs("/S"))
			{
				Ground.EvStop.Set();
				return;
			}
			if (ar.ArgIs("/P"))
			{
				string sn = ar.NextArg();
				string outFile = ar.NextArg();

				File.WriteAllText(outFile, PrimeUtils.IsPrime(Common.ToBigInteger(sn)) ? "P" : "N", Encoding.ASCII);
				return;
			}
			if (ar.ArgIs("/F"))
			{
				string sn = ar.NextArg();
				string outFile = ar.NextArg();

				FactorizationUtils.Factorization(Common.ToBigInteger(sn), outFile);
				return;
			}
			if (ar.ArgIs("/L"))
			{
				string sn = ar.NextArg();
				string outFile = ar.NextArg();

				File.WriteAllText(outFile, Common.ToString(
					GetLowerPrime(
						Common.ToBigInteger(sn)
						)
					),
					Encoding.ASCII
					);
				return;
			}
			if (ar.ArgIs("/H"))
			{
				string sn = ar.NextArg();
				string outFile = ar.NextArg();

				File.WriteAllText(outFile, Common.ToString(
					GetHigherPrime(
						Common.ToBigInteger(sn)
						)
					),
					Encoding.ASCII
					);
				return;
			}
			if (ar.ArgIs("/R"))
			{
				string sn1 = ar.NextArg();
				string sn2 = ar.NextArg();
				string outFile = ar.NextArg();

				FindPrimesUtils.FindPrimes(
					Common.ToBigInteger(sn1),
					Common.ToBigInteger(sn2),
					outFile
					);
				return;
			}
			if (ar.ArgIs("/C"))
			{
				string sn1 = ar.NextArg();
				string sn2 = ar.NextArg();
				string outFile = ar.NextArg();

				File.WriteAllText(outFile, Common.ToString(
					FindPrimesUtils.GetPrimeCount(
						Common.ToBigInteger(sn1),
						Common.ToBigInteger(sn2)
						)
					),
					Encoding.ASCII
					);
				return;
			}
			throw new ArgumentException("不明なコマンド引数");
		}

		private BigInteger GetLowerPrime(BigInteger value)
		{
			while (Consts.BI2P64 < value)
			{
				value--;

				if (PrimeUtils.IsPrime(value))
					return value;

				if (Ground.EvStop.WaitForMillis(0))
					return 0;
			}
			return Prime53.GetLowerPrime(Common.ToULong(value - 1));
		}

		private BigInteger GetHigherPrime(BigInteger value)
		{
			if (value < Consts.BI2P64)
			{
				ulong ret = Prime53.GetHigherPrime(Common.ToULong(value));

				if (ret != 0)
					return ret;

				//value = Consts.BI2P64 - 1;
				value = Consts.BI2P64; // 2^64 is not prime
			}
			while (value < Consts.BI2P4096_1) // 2^4096-1 is not prime
			{
				value++;

				if (PrimeUtils.IsPrime(value))
					return value;

				if (Ground.EvStop.WaitForMillis(0))
					break;
			}
			return 0;
		}
	}
}

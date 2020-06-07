using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Charlotte.Tools;
using System.Numerics;
using Charlotte.Chocomint.Dialogs;
using Charlotte.Tests;

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
				Prime53.INIT();
				Ground.LoadConf();

				{
					string errorReportFile = Path.Combine(ProcMain.SelfDir, Consts.ERROR_REPORT_LOCAL_FILE);

					FileTools.Delete(errorReportFile);

					try
					{
						using (MSection.Unsection(Ground.MtxProcStartEnd))
						{
#if DEBUG // test code
							//new Test0001().Test01();
							//new Test0001().Test02();
							//new Test0001().Test03();
							//new Test0001().Test04();
							//new Test0001().Test05();
							new Test0001().Test06();
#else
							this.Main3(ar);
#endif
						}
					}
					catch (Exception e)
					{
						File.WriteAllText(errorReportFile, GetLiteMessage(e), Encoding.UTF8);
						throw;
					}
				}

				Common.RemoveReportFile();
			}
			Ground.Destroy();
		}

		private static string GetLiteMessage(Exception e)
		{
			return FileTools.TextToLines("" + e)[0];
		}

		private void Main3(ArgsReader ar)
		{
			Console.WriteLine("Prime4096_MillerRabin_K: " + Ground.MillerRabin_K); // test

			if (ar.ArgIs("/S"))
			{
				Ground.Stop();
				return;
			}
			if (ar.ArgIs("/P"))
			{
				string sn = ar.NextArg();
				string outFile = ar.NextArg();

				Console.WriteLine("IsPrime_sn: " + sn);

				File.WriteAllText(outFile, PrimeUtils.IsPrime(Common.ToBigInteger(sn)) ? "P" : "N", Encoding.ASCII);
				return;
			}
			if (ar.ArgIs("/F"))
			{
				string sn = ar.NextArg();
				string outFile = ar.NextArg();

				Console.WriteLine("Factorization_sn: " + sn);

				FactorizationUtils.Factorization(Common.ToBigInteger(sn), outFile);
				return;
			}
			if (ar.ArgIs("/L"))
			{
				string sn = ar.NextArg();
				string outFile = ar.NextArg();

				Console.WriteLine("GetLowerPrime_sn: " + sn);

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

				Console.WriteLine("GetHigherPrime_sn: " + sn);

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

				Console.WriteLine("FindPrimes_sn1: " + sn1);
				Console.WriteLine("FindPrimes_sn2: " + sn2);

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

				Console.WriteLine("GetPrimeCount_sn1: " + sn1);
				Console.WriteLine("GetPrimeCount_sn2: " + sn2);

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
			while (Consts.BI2P64 <= value)
			{
				value--;

				if (PrimeUtils.IsPrime(value))
					return value;

				if (Ground.IsStopped())
					return 0;
			}
			return Prime53.GetLowerPrime(Common.ToULong(value));
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
			for (; ; )
			//while (value < Consts.BI2P4096_1) // 2^4096-1 is not prime
			{
				value++;

				if (PrimeUtils.IsPrime(value))
					return value;

				if (Ground.IsStopped())
					break;
			}
			return 0;
		}
	}
}

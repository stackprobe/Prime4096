using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Charlotte.Tools;
using System.Diagnostics;

namespace Charlotte
{
	public static class Prime4096
	{
		private static string Prime4096File;

		public static void INIT()
		{
			string file = Path.Combine(ProcMain.SelfDir, "Prime4096.exe");

			if (File.Exists(file) == false)
				file = FileTools.MakeFullPath(@"..\..\..\..\Prime4096\Prime4096\bin\Release\Prime4096.exe");

			Prime4096File = file;
		}

		public static bool IsPrime(string value)
		{
			return Perform("/P " + value)[0] == "P";
		}

		public static string[] Factorization(string value)
		{
			return Perform("/F " + value);
		}

		public static string GetLowerPrime(string value)
		{
			return Perform("/L " + value)[0];
		}

		public static string GetHigherPrime(ulong value)
		{
			return Perform("/H " + value)[0];
		}

		public static void FindPrimes(string minval, string maxval, string outFile, Func<bool> interlude)
		{
			Perform_OutFile_Interlude("/R " + minval + " " + maxval, outFile, interlude);
		}

		public static void WritePrimeCount(string minval, string maxval, string outFile, Func<bool> interlude)
		{
			Perform_OutFile_Interlude("/C " + minval + " " + maxval, outFile, interlude);
		}

		private static string[] Perform(string arguments)
		{
			using (WorkingDir wd = new WorkingDir())
			{
				string outFile = wd.MakePath();

				Perform_OutFile_Interlude(arguments, outFile, () => true);

				return File.ReadAllLines(outFile, Encoding.ASCII);
			}
		}

		private static void Perform_OutFile_Interlude(string arguments, string outFile, Func<bool> interlude)
		{
			using (Process p = ProcessTools.Start(Prime4096File, arguments + " \"" + outFile + "\""))
			{
				bool cancelled = false;

				while (p.WaitForExit(2000) == false)
				{
					if (cancelled || interlude() == false)
					{
						ProcessTools.Start(Prime4096File, "/S").WaitForExit();
						cancelled = true;
					}
				}
			}
		}
	}
}

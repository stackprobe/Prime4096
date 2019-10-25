using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using Charlotte.Tools;
using System.IO;
using System.Diagnostics;

namespace Charlotte
{
	public class Prime53
	{
		private static string Prime53File;

		public static void INIT()
		{
			string file = Path.Combine(ProcMain.SelfDir, "Prime53.exe");

			if (File.Exists(file) == false)
				file = FileTools.MakeFullPath(@"..\..\..\..\Prime53\Prime53.exe"); // devenv

			Prime53File = file;
		}

		public static bool IsPrime(ulong value)
		{
			return Perform("/P " + value)[0] == "P";
		}

		public static ulong[] Factorization(ulong value)
		{
			return Perform("/F " + value).Select(v => ulong.Parse(v)).ToArray();
		}

		public static ulong GetLowerPrime(ulong value)
		{
			return ulong.Parse(Perform("/L " + value)[0]);
		}

		public static ulong GetHigherPrime(ulong value)
		{
			return ulong.Parse(Perform("/H " + value)[0]);
		}

		public static void FindPrimes(ulong minval, ulong maxval, string outFile, Func<bool> interlude)
		{
			Perform_OutFile_Interlude("/R " + minval + " " + maxval, outFile, interlude);
		}

		/*
		public static void WritePrimeCount(ulong minval, ulong maxval, string outFile, Func<bool> interlude)
		{
			Perform_OutFile_Interlude("/C " + minval + " " + maxval, outFile, interlude);
		}
		*/

		public static ulong GetPrimeCount(ulong minval, ulong maxval, Func<bool> interlude)
		{
			return ulong.Parse(Perform_Interlude("/C " + minval + " " + maxval, interlude)[0]);
		}

		private static string[] Perform(string arguments)
		{
			return Perform_Interlude(arguments, () => true);
		}

		private static string[] Perform_Interlude(string arguments, Func<bool> interlude)
		{
			using (WorkingDir wd = new WorkingDir())
			{
				string outFile = wd.MakePath();

				Perform_OutFile_Interlude(arguments, outFile, interlude);

				return File.ReadAllLines(outFile, Encoding.ASCII);
			}
		}

		private static void Perform_OutFile_Interlude(string arguments, string outFile, Func<bool> interlude)
		{
			using (Process p = ProcessTools.Start(
				Prime53File,
				arguments + " \"" + outFile + "\"",
				"",
				ProcessTools.WindowStyle_e.INVISIBLE,
				psi => psi.RedirectStandardOutput = true
				))
			using (new ThreadEx(() =>
			{
				StreamReader reader = p.StandardOutput;

				for (; ; )
				{
					string line = reader.ReadLine();

					if (line == null)
						break;

					Console.WriteLine(line);
				}
			}
			))
			{
				bool cancelled = false;

				while (p.WaitForExit(2000) == false)
				{
					if (cancelled || interlude() == false)
					{
						ProcessTools.Start(Prime53File, "/S").WaitForExit();
						cancelled = true;
					}
				}
			}
		}
	}
}

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
		private static string LogFile;
		private static string LogFile0;

		public static void INIT()
		{
			string file = Path.Combine(ProcMain.SelfDir, "Prime4096.exe");

			if (File.Exists(file) == false)
				file = FileTools.MakeFullPath(@"..\..\..\..\Prime4096\Prime4096\bin\Release\Prime4096.exe"); // devenv

			Prime4096File = file;
			LogFile = Path.Combine(Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file) + ".log");
			LogFile0 = LogFile + "0";
		}

		public static bool IsPrime(string value)
		{
			return Perform("/P " + value)[0] == "P";
		}

		public static string[] Factorization(string value, Func<bool> interlude)
		{
			return Perform_Interlude("/F " + value, interlude);
		}

		public static string GetLowerPrime(string value, Func<bool> interlude)
		{
			return Perform_Interlude("/L " + value, interlude)[0];
		}

		public static string GetHigherPrime(string value, Func<bool> interlude)
		{
			return Perform_Interlude("/H " + value, interlude)[0];
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
				Prime4096File,
				arguments + " \"" + outFile + "\"",
				"",
				ProcessTools.WindowStyle_e.INVISIBLE,
				psi => psi.RedirectStandardOutput = true
				))
			using (new ThreadEx(() =>
			{
				StreamReader reader = p.StandardOutput;

				for (int c = 0; c < 100; c++)
				{
					string line = reader.ReadLine();

					if (line == null)
						break;

					using (StreamWriter writer = new StreamWriter(LogFile, c != 0, Encoding.UTF8))
					{
						writer.WriteLine("[" + DateTime.Now + "." + (c + 1).ToString("D3") + "] " + line);
					}
				}
			}
			))
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

			{
				string errorReportFile = Path.Combine(Path.GetDirectoryName(Prime4096File), Consts.ERROR_REPORT_LOCAL_FILE);

				if (File.Exists(errorReportFile))
				{
					string message = File.ReadAllText(errorReportFile, Encoding.UTF8);
					FileTools.Delete(errorReportFile);
					throw new CUIError(message);
				}
			}
		}
	}
}

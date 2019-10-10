using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Charlotte.Tools;
using System.Diagnostics;

namespace Charlotte
{
	public static class Prime53Lite
	{
		private static string Prime53File;

		public static void INIT()
		{
			string file = Path.Combine(ProcMain.SelfDir, "Prime53.exe");

			if (File.Exists(file) == false)
				file = FileTools.MakeFullPath(@"..\..\..\..\Prime53\Prime53.exe"); // devenv

			Prime53File = file;
		}

		private static Process GeneratePrimeDat_Proc = null;

		public static void GeneratePrimeDat()
		{
			GeneratePrimeDat_Proc = ProcessTools.Start(Prime53File, "/2");
		}

		public static void RemovePrimeDat()
		{
			GeneratePrimeDat_Proc.WaitForExit();
			GeneratePrimeDat_Proc = null;

			ProcessTools.Start(Prime53File, "/D").WaitForExit();
		}
	}
}

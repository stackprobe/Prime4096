using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Charlotte.Tools;

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
			Prime53.INIT();
			Ground.LoadConf();

			Ground.EvStop = new NamedEventUnit("{c4ef09ea-5598-4ddf-98f0-9c06b17d9b6c}");
			try
			{
				this.Main3(ar);
			}
			finally
			{
				Ground.EvStop.Dispose();
				Ground.EvStop = null;
			}
		}

		private void Main3(ArgsReader ar)
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
				throw null; // TODO
			}
			if (ar.ArgIs("/L"))
			{
				throw null; // TODO
			}
			if (ar.ArgIs("/H"))
			{
				throw null; // TODO
			}
			if (ar.ArgIs("/R"))
			{
				throw null; // TODO
			}
			if (ar.ArgIs("/C"))
			{
				throw null; // TODO
			}
			throw new ArgumentException("不明なコマンド引数");
		}
	}
}

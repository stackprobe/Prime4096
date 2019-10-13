using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.IO;

namespace Charlotte
{
	public static class FactorizationUtils
	{
		public static void Factorization(BigInteger value, string outFile)
		{
			// TODO GNFS ???

			List<string> lines = new List<string>();

			if (value <= 3)
				goto gotPrime;

			while (4 <= value && value.IsEven)
			{
				value >>= 1;
				lines.Add("2");
			}
			if (PrimeUtils.IsPrime_M(value))
				goto gotPrime;

			BigInteger denom = 3;
			int valueFirstScale = value.ToByteArray().Length; // レポート用

			while (Consts.BI2P64 <= value)
			{
				while (value % denom == 0)
				{
					value /= denom;
					lines.Add(Common.ToString(denom));

					if (PrimeUtils.IsPrime_M(value))
						goto gotPrime;

					if (Ground.IsStopped())
						goto gotPrime; // 中止

					Common.Report(1.0 - value.ToByteArray().Length * 1.0 / valueFirstScale, value);
				}
				denom += 2;

				if (Pulser() && Ground.IsStopped())
					goto gotPrime; // 中止
			}
			lines.AddRange(Prime53.Factorization(Common.ToULong(value)).Select(v => "" + v));
			goto wrLines;

		gotPrime:
			lines.Add(Common.ToString(value));

		wrLines:
			File.WriteAllLines(outFile, lines, Encoding.ASCII);
		}

		private static int P_Count = 0;

		private static bool Pulser()
		{
			if (++P_Count < 1000)
				return false;

			P_Count = 0;
			return true;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using Charlotte.Tools;
using System.IO;

namespace Charlotte
{
	public class FindPrimesUtils
	{
		private static void S_FindPrimes(BigInteger minval, BigInteger maxval, string outFile)
		{
			using (FileStream writer = new FileStream(outFile, FileMode.Append, FileAccess.Write))
			{
				for (BigInteger value = minval; ; value++)
				{
					if (PrimeUtils.IsPrime(value))
					{
						FileTools.Write(writer, Encoding.ASCII.GetBytes(Common.ToString(value)));
						writer.WriteByte(0x0a); // '\n'
					}
					if (value == maxval)
						break;

					if (Ground.EvStop.WaitForMillis(0))
						break; // 中止

					{
						int permil = (int)(((value - minval) * 1000) / (maxval - minval));
						double rate = permil / 1000.0;

						Common.Report(0.5 + rate * 0.5);
					}
				}
			}
		}

		public static void FindPrimes(BigInteger minval, BigInteger maxval, string outFile)
		{
			FileTools.Delete(outFile);

			if (maxval < minval)
				throw new Exception("maxval < minval");

			if (minval < Consts.BI2P64)
			{
				if (maxval < Consts.BI2P64)
				{
					Prime53.FindPrimes(Common.ToULong(minval), Common.ToULong(maxval), outFile, () => Ground.EvStop.WaitForMillis(0) == false);
				}
				else
				{
					Prime53.FindPrimes(Common.ToULong(minval), ulong.MaxValue, outFile, () => Ground.EvStop.WaitForMillis(0) == false);
					S_FindPrimes(Consts.BI2P64, maxval, outFile);
				}
			}
			else
			{
				S_FindPrimes(minval, maxval, outFile);
			}
		}

		private static BigInteger S_GetPrimeCount(BigInteger minval, BigInteger maxval)
		{
			BigInteger count = 0;

			for (BigInteger value = minval; ; value++)
			{
				if (PrimeUtils.IsPrime(value))
					count++;

				if (value == maxval)
					break;

				if (Ground.EvStop.WaitForMillis(0))
					break; // 中止

				{
					int permil = (int)(((value - minval) * 1000) / (maxval - minval));
					double rate = permil / 1000.0;

					Common.Report(0.5 + rate * 0.5);
				}
			}
			return count;
		}

		public static BigInteger GetPrimeCount(BigInteger minval, BigInteger maxval)
		{
			BigInteger count;

			if (maxval < minval)
				throw new Exception("maxval < minval");

			if (minval < Consts.BI2P64)
			{
				if (maxval < Consts.BI2P64)
				{
					count = Prime53.GetPrimeCount(Common.ToULong(minval), Common.ToULong(maxval), () => Ground.EvStop.WaitForMillis(0) == false);
				}
				else
				{
					count = Prime53.GetPrimeCount(Common.ToULong(minval), ulong.MaxValue, () => Ground.EvStop.WaitForMillis(0) == false);
					count += S_GetPrimeCount(Consts.BI2P64, maxval);
				}
			}
			else
			{
				count = S_GetPrimeCount(minval, maxval);
			}
			return count;
		}
	}
}

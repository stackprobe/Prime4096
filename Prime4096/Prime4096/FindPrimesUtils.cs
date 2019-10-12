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
		private static void FindPrimes_BIBI(BigInteger minval, BigInteger maxval, string outFile)
		{
			using (FileStream writer = new FileStream(outFile, FileMode.Append, FileAccess.Write))
			{
				for (BigInteger value = minval; ; value++)
				{
					if (PrimeUtils.IsPrime(value))
					{
						FileTools.Write(writer, Encoding.ASCII.GetBytes(Common.ToString(value)));
						writer.WriteByte(0x0a); // '\n'

						{
							int permil = (int)(((value - minval) * 1000) / (maxval - minval));
							double rate = permil / 1000.0;

							Common.Report(0.5 + rate * 0.5, value);
						}

						GC.Collect();
					}
					if (value == maxval)
						break;

					if (Ground.EvStop.WaitForMillis(0))
					{
						FileTools.Write(writer, Encoding.ASCII.GetBytes("ABORTED\n"));
						break; // 中止
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
					FindPrimes_BIBI(Consts.BI2P64, maxval, outFile);
				}
			}
			else
			{
				FindPrimes_BIBI(minval, maxval, outFile);
			}
		}

		private static BigInteger GetPrimeCount_BIBI(BigInteger minval, BigInteger maxval)
		{
			BigInteger count = 0;

			for (BigInteger value = minval; ; value++)
			{
				if (PrimeUtils.IsPrime(value))
				{
					count++;

					{
						int permil = (int)(((value - minval) * 1000) / (maxval - minval));
						double rate = permil / 1000.0;

						Common.Report(0.5 + rate * 0.5, value);
					}

					GC.Collect();
				}
				if (value == maxval)
					break;

				if (Ground.EvStop.WaitForMillis(0))
					break; // 中止
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
					count += GetPrimeCount_BIBI(Consts.BI2P64, maxval);
				}
			}
			else
			{
				count = GetPrimeCount_BIBI(minval, maxval);
			}
			return count;
		}
	}
}

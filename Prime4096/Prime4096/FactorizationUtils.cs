using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.IO;
using Charlotte.Tools;

namespace Charlotte
{
	public static class FactorizationUtils
	{
		public static void Factorization(BigInteger value, string outFile)
		{
			List<BigInteger> dest = new List<BigInteger>();

			if (value < 2)
			{
				dest.Add(value);
				goto endFunc;
			}

			Queue<BigInteger> q = new Queue<BigInteger>();

			q.Enqueue(value);

			int valueFirstScale = value.ToByteArray().Length; // レポート用

			while (1 <= q.Count)
			{
				BigInteger v = q.Dequeue();

				if (PrimeUtils.IsPrime_M(v))
				{
					dest.Add(v);

					// レポート
					{
						BigInteger tv = value;

						foreach (BigInteger td in dest)
							tv /= td;

						Common.Report(1.0 - tv.ToByteArray().Length * 1.0 / valueFirstScale, tv);
					}
				}
				else
				{
					try
					{
						BigInteger f;

						try
						{
							f = FindFactor(v);
						}
						catch (Cancelled)
						{
							dest.Add(v);
							dest.AddRange(q.ToArray());

							break;
						}

						if (f <= 1)
							throw null; // bugged !!!

						if (v <= f)
							throw null; // bugged !!!

						if (v % f != 0)
							throw null; // bugged !!!

						q.Enqueue(f);
						q.Enqueue(v / f);
					}
					catch (FF_Retired)
					{
						q.Enqueue(v);
					}
				}
			}

			dest.Sort((a, b) =>
			{
				if (a < b)
					return -1;

				if (b < a)
					return 1;

				return 0;
			});

		endFunc:
			File.WriteAllLines(outFile, dest.Select(v => Common.ToString(v)), Encoding.ASCII);
		}

		private static BigInteger FindFactor(BigInteger value)
		{
			if (Ground.IsStopped())
				throw new Cancelled();

			if (value < 2)
				throw null; // bugged !!!

			if (value <= 3) // 2, 3 are prime
				goto retired;

			int valueScale = value.ToByteArray().Length;

			for (int c = 0; c < 1000; c++)
			{
				BigInteger r = new BigInteger(BinTools.Join(new byte[][] { SecurityTools.CRandom.GetBytes(valueScale + 10), new byte[] { 0x00 } })) % (value - 2) + 2; // 2 ～ (value - 1)
				BigInteger f = FF_GCD(value, r);

				if (f != 1)
					return f;
			}

		retired:
			throw new FF_Retired();
		}

		private static BigInteger FF_GCD(BigInteger m, BigInteger n)
		{
			//if (m < n) throw null;

			while (n != 0)
			{
				BigInteger r = m % n;

				m = n;
				n = r;
			}
			return m;
		}

		private class FF_Retired : Exception
		{ }
	}
}

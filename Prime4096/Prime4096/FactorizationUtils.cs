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
							throw new FindFactorError_Restore();

						if (v <= f)
							throw new FindFactorError_Restore();

						if (v % f != 0)
							throw new FindFactorError_Restore();

						q.Enqueue(f);
						q.Enqueue(v / f);
					}
					catch (FindFactorError_Restore)
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
				throw new ArgumentException();

			foreach (int denom in Consts.PRIMES_NN)
				while (value % denom == 0)
					return denom;

#if false // zantei ???
			//for (BigInteger c = 1; ; c += 2) // zantei
			//for (int c = 1; c < 10000; c += 2) // zantei
			for (int c = 1; c < 10000; c++) // zantei
			{
				//int a = Consts.PRIMES_NN[(int)(c % Consts.PRIMES_NN.Length)]; // zantei
				foreach (int a in Consts.PRIMES_NN) // zantei
				{
					BigInteger ret;

					if (FindFactor(value, a, c, out ret))
						return ret;
				}
			}
#endif

			BigInteger acPrm = value;

			if (acPrm > Consts.BI2P256)
				acPrm = Consts.BI2P256;

			int acPrmScale = acPrm.ToByteArray().Length;

			for (; ; )
			{
				BigInteger a = new BigInteger(BinTools.Join(new byte[][] { SecurityTools.CRandom.GetBytes(acPrmScale + 10), new byte[] { 0x00 } })) % (acPrm - 1) + 1;
				BigInteger c = new BigInteger(BinTools.Join(new byte[][] { SecurityTools.CRandom.GetBytes(acPrmScale + 10), new byte[] { 0x00 } })) % (acPrm - 1) + 1;
				BigInteger ret;

				if (FindFactor(value, a, c, out ret))
					return ret;
			}
		}

		private static bool FindFactor(BigInteger value, BigInteger a, BigInteger c, out BigInteger ret)
		{
			BigInteger x = 2;
			BigInteger y = 2;

			for (; ; )
			{
				if (Pulser() && Ground.IsStopped())
					throw new Cancelled();

				x = FF_Rand(x, a, c, value);
				y = FF_Rand(y, a, c, value); // y 1回目
				y = FF_Rand(y, a, c, value); // y 2回目

				BigInteger d = x - y;

				if (d < 0)
					d = -d;

				ret = FF_GCD(value, d);

				if (ret == value)
					return false;

				if (ret != 1)
					return true;
			}
		}

		private static BigInteger FF_GCD(BigInteger m, BigInteger n)
		{
			while (n != 0)
			{
				BigInteger r = m % n;

				m = n;
				n = r;
			}
			return m;
		}

		private static BigInteger FF_Rand(BigInteger x, BigInteger a, BigInteger c, BigInteger m)
		{
			return (a * x + c) % m;
		}

		private static int P_Count = 0;

		private static bool Pulser()
		{
			if (++P_Count < 1000)
				return false;

			P_Count = 0;
			return true;
		}

		private class FindFactorError_Restore : Exception
		{ }
	}
}

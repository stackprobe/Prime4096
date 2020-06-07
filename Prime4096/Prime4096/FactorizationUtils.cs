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
			List<BigInteger> dest = new List<BigInteger>();

			if (value < 2)
			{
				dest.Add(value);
				goto endFunc;
			}
			foreach (int denom in Consts.PRIMES_NN)
			{
				while (value % denom == 0)
				{
					value /= denom;
					dest.Add(denom);
				}
			}
			if (value == 1)
				goto endFunc;

			Queue<BigInteger> q = new Queue<BigInteger>();

			q.Enqueue(value);

			while (1 <= q.Count)
			{
				BigInteger v = q.Dequeue();

				if (PrimeUtils.IsPrime_M(v))
				{
					dest.Add(v);
				}
				else
				{
					BigInteger f = FindFactor(v);

					q.Enqueue(f);
					q.Enqueue(v / f);
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
			for (BigInteger c = 1; ; c += 2) // zantei
			{
				foreach (int a in Consts.PRIMES_NN) // zantei
				{
					if(Pulser() && Ground.IsStopped())


					BigInteger ret;

					if (FindFactor(value, a, c, out ret))
						return ret;
				}
			}
		}

		private static bool FindFactor(BigInteger value, BigInteger a, BigInteger c, out BigInteger ret)
		{
			BigInteger x = 2;
			BigInteger y = 2;

			for (; ; )
			{
				x = FF_Rand(x, a, c, value);
				y = FF_Rand(y, a, c, value); // 1
				y = FF_Rand(y, a, c, value); // 2

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
			if (m < n) throw null; // souteigai !!!

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
	}
}

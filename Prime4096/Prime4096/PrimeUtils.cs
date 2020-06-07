using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using Charlotte.Tools;

namespace Charlotte
{
	public static class PrimeUtils
	{
		public static bool IsPrime_M(BigInteger value)
		{
			if (value <= 1)
				return false;

			if (value <= 3)
				return true;

			if (value.IsEven)
				return false;

			if (value < 100)
				return Consts.PRIMES_NN.Any(v => v == value);

			int valueScale = value.ToByteArray().Length;
			BigInteger d = value >> 1;
			int r = 0;

			while (d.IsEven)
			{
				d >>= 1;
				r++;
			}

			// if n < 3,317,044,064,679,887,385,961,981, it is enough to test a = 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, and 41. @ wiki

			if (value < Consts.BIPXX)
			{
				foreach (int ix in new int[] { /* 2, */ 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41 })
				{
					BigInteger x = new BigInteger(new byte[] { (byte)ix, 0x00 });

					if (IsPrime_X(x, d, r, value) == false)
						return false;
				}
			}
			else
			{
				for (int k = 0; k < Ground.MillerRabin_K; k++)
				{
					BigInteger x = new BigInteger(BinTools.Join(new byte[][] { SecurityTools.CRandom.GetBytes(valueScale + 10), new byte[] { 0x00 } })) % (value - 3) + 2;

					if (IsPrime_X(x, d, r, value) == false)
						return false;
				}
			}
			return true;
		}

		private static bool IsPrime_X(BigInteger x, BigInteger d, int r, BigInteger value)
		{
			x = BigInteger.ModPow(x, d, value);

			if (x != 1 && x != value - 1)
			{
				for (int c = r; ; c--)
				{
					if (c <= 0)
						return false;

					x = (x * x) % value;
					//x = BigInteger.ModPow(x, 2, value);

					if (x == value - 1)
						break;
				}
			}
			return true;
		}

		public static bool IsPrime(BigInteger value)
		{
			if (value < Consts.BI2P64)
				return Prime53.IsPrime(Common.ToULong(value));

			return IsPrime_M(value);
		}
	}
}

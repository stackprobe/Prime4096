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

			int valueScale = BigIntegerUtils.GetByteArrayLength(value);
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
				foreach (int ix in new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41 })
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
					BigInteger x = new BigInteger(BinTools.Join(new byte[][] { SecurityTools.CRandom.GetBytes(valueScale + 10), new byte[] { 0x00 } })) % (value - 3) + 2; // 2 ～ (value - 2)

					if (IsPrime_X(x, d, r, value) == false)
						return false;
				}
			}
			return true;
		}

#if false // memo:

https://zh.wikipedia.org/wiki/%E7%B1%B3%E5%8B%92-%E6%8B%89%E5%AE%BE%E6%A3%80%E9%AA%8C#%E7%AE%97%E6%B3%95%E5%A4%8D%E6%9D%82%E5%BA%A6

Input #1: n > 3, an odd integer to be tested for primality;
Input #2: k, a parameter that determines the accuracy of the test
Output: composite if n is composite, otherwise probably prime

write n - 1 as (2^r)*d with d odd by factoring powers of 2 from n - 1
WitnessLoop: repeat k times:
	pick a random integer a in the range [2, n - 2]
	x <- a^d mod n
	if x = 1 or x = n - 1 then
		continue WitnessLoop
	repeat r - 1 times:
		x <- x^2 mod n
		if x = n - 1 then
			continue WitnessLoop
	return composite
return probably prime

#endif

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

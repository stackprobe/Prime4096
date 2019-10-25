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

			int valueScale = value.ToByteArray().Length;
			BigInteger d = value >> 1;
			int r = 0;

			while (d.IsEven)
			{
				d >>= 1;
				r++;
			}
			for (int k = 0; k < Ground.MillerRabin_K; k++)
			{
				BigInteger x = new BigInteger(BinTools.Join(new byte[][] { SecurityTools.CRandom.GetBytes(valueScale + 10), new byte[] { 0x00 } })) % (value - 3) + 2;

				x = BigInteger.ModPow(x, d, value);

				if (x != 1 && x != value - 1)
				{
					for (int c = r; ; c--)
					{
						if (c <= 0)
							return false;

						x = (x * x) % value;
						//BigInteger.ModPow(x, 2, value);

						if (x == value - 1)
							break;
					}
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

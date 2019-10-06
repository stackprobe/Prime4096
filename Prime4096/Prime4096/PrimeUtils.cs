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

			if (value <= 2)
				return true;

			if (value.IsEven)
				return false;

			BigInteger d = value >> 1;
			int r = 0;

			while (d.IsEven)
			{
				d >>= 1;
				r++;
			}
			for (int k = 0; k < Ground.MillerRabin_K; k++)
			{
				BigInteger x = new BigInteger(BinTools.Join(new byte[][] { SecurityTools.CRandom.GetBytes(4096 + 8), new byte[] { 0x00 } })) % (value - 3) + 2;

				x = BigInteger.ModPow(x, d, value);

				if (x != 1 && x != value - 1)
				{
					for (int c = r; ; c--)
					{
						if (c <= 0)
							return false;

						BigInteger.ModPow(x, 2, value);

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
			{
				byte[] bUnit = value.ToByteArray();

				// unit ???
				ulong unit =
					((ulong)bUnit[0] << 0) |
					((ulong)bUnit[1] << 8) |
					((ulong)bUnit[2] << 16) |
					((ulong)bUnit[3] << 24) |
					((ulong)bUnit[4] << 32) |
					((ulong)bUnit[5] << 40) |
					((ulong)bUnit[6] << 48) |
					((ulong)bUnit[7] << 56);

				return Prime53.IsPrime(unit);
			}
			else
			{
				return IsPrime_M(value);
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Charlotte
{
	public static class Consts
	{
		public static readonly BigInteger BI2P64 = new BigInteger(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01 });
		public const string S2P64 = "18446744073709551616";
		public const ulong UL10P19 = 10000000000000000000;
		public static readonly BigInteger BI10P19 = new BigInteger(UL10P19);
	}
}

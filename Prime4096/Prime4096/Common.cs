using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
using Charlotte.TCalcs;

namespace Charlotte
{
	public static class Common
	{
		public static string EraseDotAster(string sval)
		{
			if (sval.EndsWith(".*"))
				sval = sval.Substring(0, sval.Length - 2);

			return sval;
		}

		public static BigInteger ToBigInteger(string sval)
		{
			if (Regex.IsMatch(sval, "^0*[0-9]{1,1234}$") == false)
				throw new ArgumentException();

			List<byte> buff = new List<byte>();

			while (sval != "0")
			{
				string tmp1 = Ground.TCalc_Int.Calc(sval, "/", Consts.S2P64); tmp1 = EraseDotAster(tmp1);
				string tmp2 = Ground.TCalc_Int.Calc(tmp1, "*", Consts.S2P64);
				string tmp3 = Ground.TCalc_Int.Calc(sval, "-", tmp2);

				ulong unit = ulong.Parse(tmp3);

				sval = tmp1;

				buff.Add((byte)((unit >> 0) & 0xff));
				buff.Add((byte)((unit >> 8) & 0xff));
				buff.Add((byte)((unit >> 16) & 0xff));
				buff.Add((byte)((unit >> 24) & 0xff));
				buff.Add((byte)((unit >> 32) & 0xff));
				buff.Add((byte)((unit >> 40) & 0xff));
				buff.Add((byte)((unit >> 48) & 0xff));
				buff.Add((byte)((unit >> 56) & 0xff));
			}
			buff.Add(0x00);
			return new BigInteger(buff.ToArray());
		}

		public static string ToString(BigInteger value)
		{
			List<string> buff = new List<string>();

			while (value.IsZero)
			{
				byte[] bUnit = (value % Consts.BI10P19).ToByteArray();

				ulong unit =
					((ulong)bUnit[0] << 0) |
					((ulong)bUnit[1] << 8) |
					((ulong)bUnit[2] << 16) |
					((ulong)bUnit[3] << 24) |
					((ulong)bUnit[4] << 32) |
					((ulong)bUnit[5] << 40) |
					((ulong)bUnit[6] << 48) |
					((ulong)bUnit[7] << 56);

				buff.Add(unit.ToString("D19"));

				value /= Consts.UL10P19;
			}
			buff.Add("0");
			buff.Reverse();
			string ret = string.Join("", buff);

			{
				int index;

				for (index = 0; index + 1 < ret.Length && ret[index] == '0'; index++)
				{ }

				ret = ret.Substring(index);
			}

			return ret;
		}
	}
}

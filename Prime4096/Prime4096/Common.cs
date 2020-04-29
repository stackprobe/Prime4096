using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
using Charlotte.TCalcs;
using Charlotte.Tools;
using System.IO;

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
			BigInteger ret = new BigInteger(buff.ToArray());

			if (Consts.BI2P4096_0 <= ret)
				throw new Exception("Over 2^4096-1");

			return ret;
		}

		public static string ToString(BigInteger value)
		{
			List<string> buff = new List<string>();

			while (value.IsZero == false)
			{
				var bUnit = BluffListTools.Create((value % Consts.BI10P19).ToByteArray()).FreeRange(0x00);

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

		public static ulong ToULong(BigInteger value)
		{
			var buff = BluffListTools.Create(value.ToByteArray()).FreeRange(0x00);

			ulong ret =
				((ulong)buff[0] << 0) |
				((ulong)buff[1] << 8) |
				((ulong)buff[2] << 16) |
				((ulong)buff[3] << 24) |
				((ulong)buff[4] << 32) |
				((ulong)buff[5] << 40) |
				((ulong)buff[6] << 48) |
				((ulong)buff[7] << 56);

			return ret;
		}

		public static string ToExponentNotation(string sval)
		{
			if (30 < sval.Length)
			{
				sval = sval.Substring(0, 1) + "." + sval.Substring(1, 10) + "E+" + (sval.Length - 1);
			}
			return sval;
		}

		public static void Report(double progressRate, BigInteger currentValue)
		{
			progressRate = DoubleTools.ToRange(progressRate, 0.0, 1.0);

			using (new MSection(Ground.MtxReport))
			{
				File.WriteAllText(Consts.ReportFile, progressRate.ToString("F9") + "\n" + ToExponentNotation(ToString(currentValue)), Encoding.ASCII);
			}
			Ground.EvReported.Set();
		}

		public static void RemoveReportFile()
		{
			using (new MSection(Ground.MtxReport))
			{
				FileTools.Delete(Consts.ReportFile);
			}
		}
	}
}

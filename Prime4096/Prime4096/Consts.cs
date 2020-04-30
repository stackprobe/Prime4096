using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.IO;
using Charlotte.Tools;

namespace Charlotte
{
	public static class Consts
	{
		/// <summary>
		/// 2 ^ 64
		/// </summary>
		public static readonly BigInteger BI2P64 = new BigInteger(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01 });

		/// <summary>
		/// 2 ^ 64
		/// </summary>
		public const string S2P64 = "18446744073709551616";

		/// <summary>
		/// 10 ^ 19
		/// </summary>
		public const ulong UL10P19 = 10000000000000000000;

		/// <summary>
		/// 10 ^ 19
		/// </summary>
		public static readonly BigInteger BI10P19 = new BigInteger(UL10P19);

		/// <summary>
		/// 2 ^ 4096 - 0
		/// </summary>
		public static readonly BigInteger BI2P4096_0 = new BigInteger(BinTools.Join(new byte[][] { ArrayTools.Repeat((byte)0x00, 512), new byte[] { 0x01 } }));

		/// <summary>
		/// 2 ^ 4096 - 1
		/// </summary>
		public static readonly BigInteger BI2P4096_1 = new BigInteger(BinTools.Join(new byte[][] { ArrayTools.Repeat((byte)0xff, 512), new byte[] { 0x00 } }));

		public const string REPORT_IDENT = "{0a06a4fe-041b-4d3f-9894-c6e478d75f58}"; // shared_uuid
		public const string REPORT_MTX_NAME = REPORT_IDENT + "_L";
		public const string REPORTED_EV_NAME = REPORT_IDENT + "_R";
		public static readonly string ReportFile = Path.Combine(Environment.GetEnvironmentVariable("TMP"), REPORT_IDENT + ".tmp");

		public const string ERROR_REPORT_LOCAL_FILE = "Prime4096.error.tmp";

		// if n < 3,317,044,064,679,887,385,961,981, it is enough to test a = 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, and 41. -- wiki

		public const string SXMR = "3317044064679887385961981";
		public static readonly BigInteger BIXMR = Common.ToBigInteger(SXMR);
	}
}

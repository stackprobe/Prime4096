using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using Charlotte.Tools;

namespace Charlotte.Tests
{
	public static class BigIntegerUtilsTest
	{
		public static void Test01()
		{
			for (int c = 0; c < 10000; c++) Test01_a(3);
			for (int c = 0; c < 10000; c++) Test01_a(10);
			for (int c = 0; c < 10000; c++) Test01_a(100);
			for (int c = 0; c < 1000; c++) Test01_a(1000);
			for (int c = 0; c < 100; c++) Test01_a(10000);
			for (int c = 0; c < 30; c++) Test01_a(100000);
		}

		public static void Test01_a(int scale)
		{
			Console.WriteLine("scale: " + scale); // test

			BigInteger v = new BigInteger(BinTools.Join(SecurityTools.CRandom.GetBytes(SecurityTools.CRandom.GetRange(1, scale)), new byte[] { 0x00 }));
			BigInteger x = new BigInteger(BinTools.Join(SecurityTools.CRandom.GetBytes(SecurityTools.CRandom.GetRange(1, scale)), new byte[] { 0x00 }));

			if (v < 1)
				v = 1;

			if (x < 2)
				x = 2;

			int xe = BigIntegerUtils.GetLogarithm(v, x);

			Console.WriteLine("xe: " + xe); // test

			BigInteger t1 = T01_PowerOf(x, xe);
			BigInteger t2 = t1 * x;

			if (t1 <= v && v < t2)
			{
				// noop
			}
			else
			{
				throw null; // bugged !!!
			}

			Console.WriteLine("ok"); // test
		}

		private static BigInteger T01_PowerOf(BigInteger v, int x)
		{
			if (x < 0)
				throw null;

			if (x == 0)
				return 1;

			if (x == 1)
				return v;

			return T01_PowerOf(v * v, x / 2) * (x % 2 == 1 ? v : 1);
		}
	}
}

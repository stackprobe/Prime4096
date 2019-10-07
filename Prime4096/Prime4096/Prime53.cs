using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using Charlotte.Tools;
using System.IO;
using System.Diagnostics;

namespace Charlotte
{
	public class Prime53
	{
		public static bool IsPrime(ulong value)
		{
			return Perform("/P " + value)[0] == "P";
		}

		public static ulong[] Factorization(ulong value)
		{
			return Perform("/P " + value).Select(v => ulong.Parse(v)).ToArray();
		}

		public static ulong GetLowerPrime(ulong value)
		{
			return ulong.Parse(Perform("/L " + value)[0]);
		}

		public static ulong GetHigherPrime(ulong value)
		{
			return ulong.Parse(Perform("/H " + value)[0]);
		}

		public static void FindPrimes(ulong minval, ulong maxval, string outFile, Func<bool> interlude)
		{
			throw null; // TODO
		}

		public static void WritePrimeCount(ulong minval, ulong maxval, string outFile, Func<bool> interlude)
		{
			throw null; // TODO
		}

		private static string[] Perform(string arguments)
		{
			throw null; // TODO
		}
	}
}

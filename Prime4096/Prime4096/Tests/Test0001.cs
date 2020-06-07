using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using System.Numerics;

namespace Charlotte.Tests
{
	public class Test0001
	{
		public void Test01()
		{
			// if n < 3,317,044,064,679,887,385,961,981, it is enough to test a = 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, and 41. @ wiki

			for (int c = 0; c < 10000; c++)
			{
				string s = string.Format("331704406467988738596{0:D4}", c);

				Console.WriteLine(s + " ==> " + PrimeUtils.IsPrime_M(Common.ToBigInteger(s)));
			}
		}

		public void Test02()
		{
			// 3桁以下の素数の積

			BigInteger value = Common.ToBigInteger(
				"19590340644999083431262508198206381046123972390589368223882605328968666316379870661851951648789482321596" +
				"22955911543601914918952972521526672829228299085264902336273139240401793914201095826139363495947148375719" +
				"67216722434100671185162276611331351924888489899148921571883086798968751374395193389039680949055497503864" +
				"07106033836586660683539201011635917900039904495065203299749542985993134669814805318474080581207891125910"
				);

			FactorizationUtils.Factorization(value, @"C:\temp\1.txt");
		}

		public void Test03()
		{
			BigInteger value = Common.ToBigInteger(
				"106700590455862347842907841856033238416352421" // 10007 * 10009 * 10037 * 10039 * 10061 * 10067 * 10069 * 10079 * 10091 * 10093 * 10099
				);

			FactorizationUtils.Factorization(value, @"C:\temp\1.txt");
		}
	}
}

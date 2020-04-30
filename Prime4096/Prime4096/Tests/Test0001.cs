using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;

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
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte.CalcUtilsD
{
	//
	//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
	//
	public class FatUFloatCalc
	{
		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public int Radix;

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public FatUFloatCalc(int radix)
		{
			this.Radix = radix;
		}

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public void Add(FatUFloat a, FatUFloat b)
		{
			a.normalize();
			b.normalize();

			a.sync(b);
			b.sync(a);

			new FatUIntCalc(Radix).Add(a.Inner, b.Inner);

			a.normalize();
		}

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public int Sub(FatUFloat a, FatUFloat b)
		{
			a.normalize();
			b.normalize();

			a.sync(b);
			b.sync(a);

			int sign = new FatUIntCalc(Radix).Sub(a.Inner, b.Inner);

			a.normalize();

			return sign;
		}

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public FatUFloat Mul(FatUFloat a, FatUFloat b)
		{
			a.normalize();
			b.normalize();

			FatUFloat answer = new FatUFloat(new FatUIntCalc(Radix).Mul(a.Inner, b.Inner), a.Exponent + b.Exponent);

			answer.normalize();

			return answer;
		}

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public FatUFloat Div(FatUFloat a, FatUFloat b)
		{
			a.normalize();
			b.normalize();

			a.sync(b);
			b.sync(a);

			FatUFloat answer = new FatUFloat(new FatUIntCalc(Radix).Div(a.Inner, b.Inner), 0);

			answer.normalize();

			return answer;
		}
	}
}

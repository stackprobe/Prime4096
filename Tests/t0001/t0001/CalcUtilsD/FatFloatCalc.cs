using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte.CalcUtilsD
{
	//
	//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
	//
	public class FatFloatCalc
	{
		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public int Radix;

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public FatFloatCalc(int radix)
		{
			this.Radix = radix;
		}

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public void Add(FatFloat a, FatFloat b)
		{
			a.Normalize();
			b.Normalize();

			if (a.Sign == b.Sign)
			{
				new FatUFloatCalc(this.Radix).Add(a.Inner, b.Inner);
			}
			else
			{
				a.Sign *= new FatUFloatCalc(this.Radix).Sub(a.Inner, b.Inner);
			}
		}

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public void Sub(FatFloat a, FatFloat b)
		{
			a.Normalize();
			b.Normalize();

			b.Sign *= -1;

			Add(a, b);
		}

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public FatFloat Mul(FatFloat a, FatFloat b)
		{
			a.Normalize();
			b.Normalize();

			return new FatFloat(new FatUFloatCalc(this.Radix).Mul(a.Inner, b.Inner), a.Sign * b.Sign);
		}

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public FatFloat Div(FatFloat a, FatFloat b)
		{
			a.Normalize();
			b.Normalize();

			return new FatFloat(new FatUFloatCalc(this.Radix).Div(a.Inner, b.Inner), a.Sign * b.Sign);
		}
	}
}

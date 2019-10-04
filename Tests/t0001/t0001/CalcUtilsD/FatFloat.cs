using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte.CalcUtilsD
{
	//
	//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
	//
	public class FatFloat
	{
		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public FatUFloat Inner;
		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public int Sign;

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public FatFloat(FatUFloat inner, int sign)
		{
			this.Inner = inner;
			this.Sign = sign;
		}

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public void Normalize()
		{
			this.Inner.normalize();

			if (this.Inner.Inner.Figures.Length == 0)
			{
				this.Sign = 1;
			}
		}
	}
}

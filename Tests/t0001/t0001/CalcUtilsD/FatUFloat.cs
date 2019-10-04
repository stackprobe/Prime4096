using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte.CalcUtilsD
{
	//
	//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
	//
	public class FatUFloat
	{
		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public FatUInt Inner;
		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public int Exponent;

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public FatUFloat(FatUInt inner, int exponent)
		{
			this.Inner = inner;
			this.Exponent = exponent;
		}

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public void normalize()
		{
			int start;

			for (start = 0; start < this.Inner.Figures.Length && this.Inner.Figures[start] == 0; start++)
			{ }

			if (start < this.Inner.Figures.Length)
			{
				int end;

				for (end = this.Inner.Figures.Length; this.Inner.Figures[end - 1] == 0; end--)
				{ }

				if (0 < start || end < this.Inner.Figures.Length)
				{
					this.Inner.Figures = CalcDSysUtils.CopyOfRange(this.Inner.Figures, start, end);
					this.Exponent += start;
				}
			}
			else
			{
				if (this.Inner.Figures.Length != 0)
					this.Inner.Figures = new int[0];

				this.Exponent = 0;
			}
		}

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public void sync(FatUFloat another)
		{
			int count = this.Exponent - another.Exponent;

			if (0 < count)
			{
				this.Inner.Figures = CalcDSysUtils.Shift(this.Inner.Figures, count);
				this.Exponent -= count;
			}
		}
	}
}

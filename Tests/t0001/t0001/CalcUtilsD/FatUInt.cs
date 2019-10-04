using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte.CalcUtilsD
{
	//
	//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
	//
	public class FatUInt
	{
		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public int[] Figures;
		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public bool Remained = false;

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public FatUInt()
			: this(new int[0])
		{ }

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public FatUInt(int[] figures)
		{
			this.Figures = figures;
		}

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public int Get(int index)
		{
			return index < this.Figures.Length ? this.Figures[index] : 0;
		}

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public void Resize(int size)
		{
			this.Figures = CalcDSysUtils.CopyOf(this.Figures, size);
		}

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public void Inverse(int fill)
		{
			for (int index = 0; index < this.Figures.Length; index++)
			{
				this.Figures[index] = fill - this.Figures[index];
			}
		}

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public void Add(int index, long value, int radix)
		{
			while (0 < value)
			{
				value += this.Figures[index];
				this.Figures[index] = (int)(value % radix);
				value /= radix;
				index++;
			}
		}
	}
}

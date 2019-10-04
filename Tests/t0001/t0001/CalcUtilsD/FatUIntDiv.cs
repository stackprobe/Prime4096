using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte.CalcUtilsD
{
	//
	//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
	//
	public class FatUIntDiv
	{
		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public int[] Figures;
		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public int Start;
		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public int End;

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public FatUIntDiv(FatUInt a)
			: this(a.Figures)
		{ }

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public FatUIntDiv(int[] figures)
		{
			this.Figures = figures;
			this.Start = 0;
			this.End = figures.Length;

			this.Trim();
		}

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public void Trim()
		{
			while (0 < this.End && this.Figures[this.End - 1] == 0)
			{
				this.End--;
			}
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
		public FatUInt GetUInt()
		{
			return new FatUInt(this.Figures.Length == this.End ? this.Figures : CalcDSysUtils.CopyOf(this.Figures, this.End));
		}
	}
}

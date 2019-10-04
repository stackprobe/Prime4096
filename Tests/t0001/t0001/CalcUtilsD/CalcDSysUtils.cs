using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte.CalcUtilsD
{
	//
	//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
	//
	public static class CalcDSysUtils
	{
		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public static int[] CopyOf(int[] arr, int size)
		{
			int[] dest = new int[size];

			Array.Copy(arr, 0, dest, 0, Math.Min(arr.Length, size));

			return dest;
		}

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public static int[] CopyOfRange(int[] arr, int start, int end)
		{
			int[] dest = new int[end - start];

			Array.Copy(arr, start, dest, 0, end - start);

			return dest;
		}

		//
		//	copied the source file by https://github.com/stackprobe/Factory/blob/master/SubTools/CopyLib.c
		//
		public static int[] Shift(int[] arr, int count)
		{
			int[] dest = new int[arr.Length + count];

			Array.Copy(arr, 0, dest, count, arr.Length);

			return dest;
		}
	}
}

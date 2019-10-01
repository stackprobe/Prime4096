using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte
{
	public static class Utils
	{
		public static string AutoInsertNewLine(string text, int maxLineLength, int margin = 10)
		{
			List<string> lines = new List<string>();

			while (maxLineLength + margin < text.Length)
			{
				lines.Add(text.Substring(0, maxLineLength));
				text = text.Substring(maxLineLength);
			}
			lines.Add(text);
			return string.Join("\r\n", lines);
		}
	}
}

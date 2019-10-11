using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte
{
	public class CUIError : Exception
	{
		public CUIError(string message)
			: base(message)
		{ }
	}
}

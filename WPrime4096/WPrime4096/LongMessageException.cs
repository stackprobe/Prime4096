using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte
{
	public class LongMessageException : Exception
	{
		public LongMessageException(string message)
			: base(message)
		{ }
	}
}

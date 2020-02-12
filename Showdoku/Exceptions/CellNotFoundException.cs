using System;
using System.Runtime.Serialization;

namespace Showdoku.Exceptions
{
	public class CellNotFoundException : Exception
	{
		public CellNotFoundException(string message) : base(message)
		{
		}

		public CellNotFoundException(SerializationInfo info, StreamingContext context) : base()
		{
		}
	}
}

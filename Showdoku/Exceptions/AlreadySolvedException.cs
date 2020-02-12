using System;
using System.Runtime.Serialization;

namespace Showdoku
{
	public class AlreadySolvedException : Exception
	{
		public AlreadySolvedException(string message) : base(message)
		{
		}

		public AlreadySolvedException(SerializationInfo info, StreamingContext context) : base()
		{
		}
	}
}

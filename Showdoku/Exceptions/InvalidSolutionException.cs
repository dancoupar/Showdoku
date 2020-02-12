using System;
using System.Runtime.Serialization;

namespace Showdoku.Exceptions
{
	public class InvalidSolutionException : Exception
	{		
		public InvalidSolutionException(string message, int attemptedSolution) : base(message)
		{
			this.AttemptedSolution = attemptedSolution;
		}

		public InvalidSolutionException(SerializationInfo info, StreamingContext context) : base()
		{
			this.AttemptedSolution = (int)info.GetValue("AttemptedSolution", typeof(int));
		}

		public int AttemptedSolution
		{
			get;
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("AttemptedSolution", this.AttemptedSolution);
		}
	}
}

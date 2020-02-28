using System;
using System.Runtime.Serialization;

namespace Showdoku.Exceptions
{
	/// <summary>
	/// The exception thrown if an attempted solution is not valid.
	/// </summary>
	public class InvalidSolutionException : Exception
	{
		/// <summary>
		/// Initialises a new instance of the <see cref="InvalidSolutionException"/> class with the
		/// specified error message.
		/// </summary>
		/// <param name="message">
		/// The message associated with the exception.
		/// </param>
		/// <param name="attemptedSolution">
		/// The attempted solution.
		/// </param>
		public InvalidSolutionException(string message, int attemptedSolution) : base(message)
		{
			this.AttemptedSolution = attemptedSolution;
		}

		/// <summary>
		/// Initialises a new instance of the <see cref="InvalidSolutionException"/> class with
		/// serialised data.
		/// </summary>
		/// <param name="info">
		/// The <see cref="SerializationInfo"/> that holds the serialised object data about the
		/// exception being thrown.
		/// </param>
		/// <param name="context">
		/// The <see cref="StreamingContext"/> that contains contextual information about the
		/// source or destination.
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// Thrown if info is null.
		/// </exception>
		/// <exception cref="SerializationException">
		/// Thrown if the class name is null or System.Exception.HResult is zero (0).
		/// </exception>
		public InvalidSolutionException(SerializationInfo info, StreamingContext context) : base()
		{
			this.AttemptedSolution = (int)info.GetValue("AttemptedSolution", typeof(int));
		}

		/// <summary>
		/// Gets the attempted solution.
		/// </summary>
		public int AttemptedSolution
		{
			get;
		}

		/// <summary>
		/// Sets the specified <see cref="SerializationInfo"/> with information about the
		/// exception.
		/// </summary>
		/// <param name="info">
		/// The <see cref="SerializationInfo"/> that holds the serialised object data about the
		/// exception being thrown.
		/// </param>
		/// <param name="context">
		/// The <see cref="StreamingContext"/> that contains contextual information about the
		/// source or destination.
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// Thrown if the info parameter is null.
		/// </exception>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("AttemptedSolution", this.AttemptedSolution);
		}
	}
}

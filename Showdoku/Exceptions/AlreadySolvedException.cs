using System;
using System.Runtime.Serialization;

namespace Showdoku
{
	/// <summary>
	/// The exception thrown if a cell has already been solved.
	/// </summary>
	public class AlreadySolvedException : Exception
	{
		/// <summary>
		/// Initialises a new instance of the <see cref="AlreadySolvedException"/> class with the
		/// specified error message.
		/// </summary>
		/// <param name="message">
		/// The message associated with the exception.
		/// </param>
		public AlreadySolvedException(string message) : base(message)
		{
		}

		/// <summary>
		/// Initialises a new instance of the <see cref="AlreadySolvedException"/> class with
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
		public AlreadySolvedException(SerializationInfo info, StreamingContext context) : base(info, context)
		{			
		}
	}
}

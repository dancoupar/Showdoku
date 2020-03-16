using System;
using System.Runtime.Serialization;

namespace Showdoku.Exceptions
{
	/// <summary>
	/// The exception thrown if a cell cannot be found.
	/// </summary>
	public class CellNotFoundException : Exception
	{
		/// <summary>
		/// Initialises a new instance of the <see cref="CellNotFoundException"/> class with the
		/// specified error message.
		/// </summary>
		/// <param name="message">
		/// The message associated with the exception.
		/// </param>
		public CellNotFoundException(string message) : base(message)
		{
		}

		/// <summary>
		/// Initialises a new instance of the <see cref="CellNotFoundException"/> class with
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
		public CellNotFoundException(SerializationInfo info, StreamingContext context) : base()
		{
		}
	}
}

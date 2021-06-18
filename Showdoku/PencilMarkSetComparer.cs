using System;
using System.Collections.Generic;
using System.Linq;

namespace Showdoku
{
	/// <summary>
	/// A comparer for comparing two sets of pencil marks to determine whether they're the same.
	/// </summary>
	public class PencilMarkSetComparer : IEqualityComparer<PencilMarkSet>
	{
		/// <summary>
		/// Returns a value indicating whether the two specified sets of pencil marks are the same.
		/// </summary>
		/// <param name="first">
		/// The first set.
		/// </param>
		/// <param name="second">
		/// The second set.
		/// </param>
		/// <returns>
		/// True if the two sets of pencil marks are the same, otherwise false.
		/// </returns>
		public bool Equals(PencilMarkSet first, PencilMarkSet second)
		{
			if (Object.ReferenceEquals(first, second))
			{
				return true;
			}

			if (first == null || second == null)
			{
				return false;
			}

			if (first.Count() != second.Count())
			{
				return false;
			}

			// Assumes pencil marks are in ascending order
			for (int i = 0; i < first.Count(); i++)
			{
				if (first.ElementAt(i) != second.ElementAt(i))
				{
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Returns a hash code for the specified set of pencil marks.
		/// </summary>
		/// <param name="pencilMarks">
		/// The set of pencil marks whose hash code is to be returned.
		/// </param>
		/// <returns>
		/// A hash code for the set of pencil marks.
		/// </returns>
		/// <remarks>
		/// Powers of 2 are used to ensure no other combination of pencil marks can result in the
		/// same hashcode. Technically, this on its own is enough for comparison, but the Equals
		/// method is also implemented for completeness and readability.
		/// </remarks>
		public int GetHashCode(PencilMarkSet pencilMarks)
		{
			if (pencilMarks == null)
			{
				throw new ArgumentNullException(nameof(pencilMarks), "Argument cannot be null.");
			}

			int hashCode = 0;

			foreach (int pencilMark in pencilMarks)
			{
				hashCode += (int)Math.Pow(2, pencilMark - 1);
			}

			return hashCode;
		}
	}
}

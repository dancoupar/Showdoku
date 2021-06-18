using System;
using System.Collections;
using System.Collections.Generic;

namespace Showdoku
{
	/// <summary>
	/// A set of up to nine pencil marks relating to a particular cell. Each pencil mark within the
	/// set represents a possible solution to the cell.
	/// </summary>
	public class PencilMarkSet : IEnumerable<int>
	{
		private readonly List<int> pencilMarks;

		/// <summary>
		/// Creates a new set of nine pencil marks for an unsolved cell.
		/// </summary>
		public PencilMarkSet()
		{
			this.pencilMarks = new List<int>(9);
			this.Init();
		}

		private void Init()
		{
			for (int i = 1; i < 10; i++)
			{
				this.pencilMarks.Add(i);
			}
		}

		/// <summary>
		/// Removes the specified value from the set.
		/// </summary>
		/// <param name="pencilMark">
		/// The value to remove from the set.
		/// </param>
		/// <exception cref="ArgumentOutOfRangeException">
		/// Thrown if the specified pencil mark is not a number between 1 and 9 (inclusive).
		/// </exception>
		public void Erase(int pencilMark)
		{
			if (pencilMark < 1 || pencilMark > 9)
			{
				throw new ArgumentOutOfRangeException(nameof(pencilMark), pencilMark, "Argument must not be less than 1 or greater than 9.");
			}

			this.pencilMarks.Remove(pencilMark);
		}

		/// <summary>
		/// Removes all values from the set.
		/// </summary>
		public void EraseAll()
		{
			this.pencilMarks.Clear();
		}

		/// <summary>
		/// Re-initialises the set with nine pencil marks.
		/// </summary>
		public void Reset()
		{
			this.pencilMarks.Clear();
			this.Init();
		}

		/// <summary>
		/// Returns an enumerator that iterates through the set.
		/// </summary>
		/// <returns>
		/// An enumerator for the set.
		/// </returns>
		public IEnumerator<int> GetEnumerator()
		{
			return this.pencilMarks.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Showdoku
{
	/// <summary>
	/// A collection of cells.
	/// </summary>
	public abstract class CellCollection : IEnumerable<Cell>
	{
		/// <summary>
		/// Gets a value indicating whether all the cells within this collection have been
		/// successfully solved.
		/// </summary>
		/// <returns>
		/// True if this collection contains only solved cells, otherwise false.
		/// </returns>
		public bool IsSolved()
		{
			return this.All((c) => c.IsSolved());
		}

		/// <summary>
		/// Gets the total number of cells within this collection that have been successfully solved.
		/// </summary>
		/// <returns>
		/// The total number of solved cells.
		/// </returns>
		public int CountSolvedCells()
		{
			return this.Count((c) => c.IsSolved());
		}

		/// <summary>
		/// Gets the total number of pencil marks for all cells within this collection. The lower the
		/// number, the closer the collection is to being solved.
		/// </summary>
		/// <returns>
		/// The total number of pencil marks.
		/// </returns>
		public int CountPencilMarks()
		{
			return this.Sum((c) => c.PencilMarks.Count);
		}

		/// <summary>
		/// Gets a value indicating whether this collection includes the specified cell.
		/// </summary>
		/// <param name="cell">
		/// The cell that may be contained within this collection.
		/// </param>
		/// <returns>
		/// True if this collection contains the specified cell, otherwise false.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// Thrown if the specified cell is null.
		/// </exception>
		public bool Contains(Cell cell)
		{
			if (cell == null)
			{
				throw new ArgumentNullException(nameof(cell), "Argument cannot be null.");
			}

			return this.Any((c) => c == cell);
		}

		/// <summary>
		/// Returns an enumerator that iterates through each of the cells within this collection.
		/// </summary>
		/// <returns>
		/// An enumerator that can be used to iterate through the cells within this collection.
		/// </returns>
		public abstract IEnumerator<Cell> GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}

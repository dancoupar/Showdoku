using System;
using System.Collections.Generic;
using System.Linq;

namespace Showdoku
{
	/// <summary>
	/// A vertical column containing 9 cells.
	/// </summary>
	public class Column : CellCollection
	{
		/// <summary>
		/// Creates a new column of 9 cells.
		/// </summary>
		/// <param name="cells">
		/// An array of 9 cells that the column is to contain.
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// Thrown if the specified array is null.
		/// </exception>
		/// <exception cref="ArgumentException">
		/// Thrown if the specified array does not contain 9 elements, or if any elements are null.
		/// </exception>
		public Column(Cell[] cells)
		{
			this.Cells = cells ?? throw new ArgumentNullException(nameof(cells), "Argument cannot be null.");

			if (cells.Length != 9)
			{
				throw new ArgumentException("Array must contain 9 elements.", nameof(cells));
			}

			if (cells.Any((c) => c == null))
			{
				throw new ArgumentException("Array cannot contain null elements.");
			}
		}

		/// <summary>
		/// Gets an array of all 9 cells in this column.
		/// </summary>
		public Cell[] Cells
		{
			get;
		}

		/// <summary>
		/// Returns an enumerator that iterates through each of the cells within this column.
		/// </summary>
		/// <returns>
		/// An enumerator that can be used to iterate through the cells within this column.
		/// </returns>
		public override IEnumerator<Cell> GetEnumerator()
		{
			foreach (Cell cell in this.Cells)
			{
				yield return cell;
			}
		}
	}
}

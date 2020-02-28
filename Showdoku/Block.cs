using System;
using System.Collections.Generic;

namespace Showdoku
{
	/// <summary>
	/// A block of 3 by 3 cells.
	/// </summary>
	public class Block : CellCollection
	{
		/// <summary>
		/// Creates a new block of 3 by 3 cells.
		/// </summary>
		/// <param name="cells">
		/// A 3 by 3 array of cells that the block is to contain.
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// Thrown if the specified array is null.
		/// </exception>
		/// <exception cref="ArgumentException">
		/// Thrown if the specified array has invalid dimensions.
		/// </exception>
		public Block(Cell[,] cells)
		{			
			this.Cells = cells ?? throw new ArgumentNullException(nameof(cells), "Argument cannot be null.");

			if (cells.GetLength(0) != 3 || cells.GetLength(1) != 3)
			{
				throw new ArgumentException("Array must contain 3 by 3 elements.", nameof(cells));
			}
		}

		/// <summary>
		/// Gets a 3 by 3 array of all the cells in this block.
		/// </summary>
		public Cell[,] Cells
		{
			get;
		}

		/// <summary>
		/// Returns an enumerator that iterates through each of the cells within this block.
		/// </summary>
		/// <returns>
		/// An enumerator that can be used to iterate through the cells within this block.
		/// </returns>
		public override IEnumerator<Cell> GetEnumerator()
		{
			for (int x = 0; x < 3; x++)
			{
				for (int y = 0; y < 3; y++)
				{
					yield return this.Cells[x, y];
				}
			}
		}
	}
}

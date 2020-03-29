using Showdoku.Exceptions;
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
		/// Thrown if the specified array has invalid dimensions, or if any of the elements are null.
		/// </exception>
		public Block(Cell[,] cells)
		{
			this.Cells = cells ?? throw new ArgumentNullException(nameof(cells), "Argument cannot be null.");

			if (cells.GetLength(0) != 3 || cells.GetLength(1) != 3)
			{
				throw new ArgumentException("Array must contain 3 by 3 elements.", nameof(cells));
			}

			foreach (Cell cell in cells)
			{
				if (cell == null)
				{
					throw new ArgumentException("Array cannot contain null elements.");
				}
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
		/// Gets the x-index of the specified cell within this block.
		/// </summary>
		/// <param name="cell">
		/// A cell within this block.
		/// </param>
		/// <returns>
		/// The zero-based x-index of the cell within this block.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// Thrown if the specified cell is null.
		/// </exception>
		/// <exception cref="CellNotFoundException">
		/// Thrown if the specified cell does not appear within this block.
		/// </exception>
		public int XIndexOf(Cell cell)
		{
			if (cell == null)
			{
				throw new ArgumentNullException(nameof(cell), "Argument cannot be null.");
			}

			for (int y = 0; y < 3; y++)
			{
				for (int x = 0; x < 3; x++)
				{
					if (this.Cells[x, y] == cell)
					{
						return x;
					}
				}
			}

			throw new CellNotFoundException($"The specified cell does not appear within this block.");
		}

		/// <summary>
		/// Gets the y-index of the specified cell within this block.
		/// </summary>
		/// <param name="cell">
		/// A cell within this block.
		/// </param>
		/// <returns>
		/// The zero-based y-index of the cell within this block.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// Thrown if the specified cell is null.
		/// </exception>
		/// <exception cref="CellNotFoundException">
		/// Thrown if the specified cell does not appear within this block.
		/// </exception>
		public int YIndexOf(Cell cell)
		{
			if (cell == null)
			{
				throw new ArgumentNullException(nameof(cell), "Argument cannot be null.");
			}

			for (int y = 0; y < 3; y++)
			{
				for (int x = 0; x < 3; x++)
				{
					if (this.Cells[x, y] == cell)
					{
						return y;
					}
				}
			}

			throw new CellNotFoundException($"The specified cell does not appear within this block.");
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

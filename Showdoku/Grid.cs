using Showdoku.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Showdoku
{
	/// <summary>
	/// A soduko grid containing 9 blocks, 9 rows and 9 columns of 9 cells.
	/// </summary>
	public class Grid : CellCollection
	{
		/// <summary>
		/// Creates a new, empty sudoku grid.
		/// </summary>
		public Grid()
		{
			this.Cells = new Cell[9, 9];
			this.Rows = new Row[9];
			this.Columns = new Column[9];
			this.Blocks = new Block[3, 3];

			for (int y = 0; y < 9; y++)
			{
				for (int x = 0; x < 9; x++)
				{
					this.Cells[x, y] = new Cell(this);
				}
			}

			for (int y1 = 0; y1 < 3; y1++)
			{
				for (int x1 = 0; x1 < 3; x1++)
				{
					var blockCells = new Cell[3, 3];

					for (int y2 = 0; y2 < 3; y2++)
					{
						for (int x2 = 0; x2 < 3; x2++)
						{
							blockCells[x2, y2] = this.Cells[x2 + 3 * x1, y2 + 3 * y1];
						}
					}

					this.Blocks[x1, y1] = new Block(blockCells);
				}
			}

			for (int y = 0; y < 9; y++)
			{
				var rowCells = new Cell[9];

				for (int x = 0; x < 9; x++)
				{
					rowCells[x] = this.Cells[x, y];
				}

				this.Rows[y] = new Row(rowCells);
			}

			for (int x = 0; x < 9; x++)
			{
				var columnCells = new Cell[9];

				for (int y = 0; y < 9; y++)
				{
					columnCells[y] = this.Cells[x, y];
				}

				this.Columns[x] = new Column(columnCells);
			}
		}

		/// <summary>
		/// Gets a 9 by 9 array of all the cells in this grid.
		/// </summary>
		public Cell[,] Cells
		{
			get;
		}

		/// <summary>
		/// Gets a 3 by 3 array of all the blocks in this grid.
		/// </summary>
		public Block[,] Blocks
		{
			get;
		}

		/// <summary>
		/// Gets an array of all 9 rows in this grid. Rows run from left to right.
		/// </summary>
		public Row[] Rows
		{
			get;
		}

		/// <summary>
		/// Gets an array of all 9 columns in this grid. Columns run from top to bottom.
		/// </summary>
		public Column[] Columns
		{
			get;
		}

		/// <summary>
		/// Gets the x-index of the specified cell within this grid.
		/// </summary>
		/// <param name="cell">
		/// A cell within this grid.
		/// </param>
		/// <returns>
		/// The zero-based x-index of the cell within this grid, or -1 if the specified cell does not
		/// appear within this grid.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// Thrown if the specified cell is null.
		/// </exception>
		public int XIndexOf(Cell cell)
		{
			if (cell == null)
			{
				throw new ArgumentNullException(nameof(cell), "Argument cannot be null.");
			}

			for (int y = 0; y < this.Cells.GetLength(1); y++)
			{
				for (int x = 0; x < this.Cells.GetLength(0); x++)
				{
					if (this.Cells[x, y] == cell)
					{
						return x;
					}
				}
			}

			return -1;
		}

		/// <summary>
		/// Gets the y-index of the specified cell within this grid.
		/// </summary>
		/// <param name="cell">
		/// A cell within this grid.
		/// </param>
		/// <returns>
		/// The zero-based y-index of the cell within this grid, or -1 if the specified cell does not
		/// appear within this grid.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// Thrown if the specified cell is null.
		/// </exception>
		public int YIndexOf(Cell cell)
		{
			if (cell == null)
			{
				throw new ArgumentNullException(nameof(cell), "Argument cannot be null.");
			}

			for (int y = 0; y < this.Cells.GetLength(1); y++)
			{
				for (int x = 0; x < this.Cells.GetLength(0); x++)
				{
					if (this.Cells[x, y] == cell)
					{
						return y;
					}
				}
			}

			return -1;
		}

		/// <summary>
		/// Gets the x-index of the specified block within this grid.
		/// </summary>
		/// <param name="block">
		/// A block within this grid.
		/// </param>
		/// <returns>
		/// The zero-based x-index of the block within this grid, or -1 if the specified block does not
		/// appear within this grid.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// Thrown if the specified block is null.
		/// </exception>
		public int XIndexOf(Block block)
		{
			if (block == null)
			{
				throw new ArgumentNullException(nameof(block), "Argument cannot be null.");
			}

			for (int y = 0; y < this.Blocks.GetLength(1); y++)
			{
				for (int x = 0; x < this.Blocks.GetLength(0); x++)
				{
					if (this.Blocks[x, y] == block)
					{
						return x;
					}
				}
			}

			return -1;
		}

		/// <summary>
		/// Gets the y-index of the specified block within this grid.
		/// </summary>
		/// <param name="block">
		/// A block within this grid.
		/// </param>
		/// <returns>
		/// The zero-based y-index of the block within this grid, or -1 if the specified block does not
		/// appear within this grid.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// Thrown if the specified block is null.
		/// </exception>
		public int YIndexOf(Block block)
		{
			if (block == null)
			{
				throw new ArgumentNullException(nameof(block), "Argument cannot be null.");
			}

			for (int y = 0; y < this.Blocks.GetLength(1); y++)
			{
				for (int x = 0; x < this.Blocks.GetLength(0); x++)
				{
					if (this.Blocks[x, y] == block)
					{
						return y;
					}
				}
			}

			return -1;
		}

		/// <summary>
		/// Gets the index of the specified row within this grid.
		/// </summary>
		/// <param name="row">
		/// A row within this grid.
		/// </param>
		/// <returns>
		/// The zero-based index of the row within this grid, or -1 if the specified row does not appear
		/// within this grid.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// Thrown if the specified row is null.
		/// </exception>
		public int IndexOf(Row row)
		{
			if (row == null)
			{
				throw new ArgumentNullException(nameof(row), "Argument cannot be null.");
			}

			for (int y = 0; y < this.Rows.Length; y++)
			{
				if (this.Rows[y] == row)
				{
					return y;
				}
			}

			return -1;
		}

		/// <summary>
		/// Gets the index of the specified column within this grid.
		/// </summary>
		/// <param name="column">
		/// A column within this grid.
		/// </param>
		/// <returns>
		/// The zero-based index of the column within this grid, or -1 if the specified column does not
		/// appear within this grid.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// Thrown if the specified column is null.
		/// </exception>
		public int IndexOf(Column column)
		{
			if (column == null)
			{
				throw new ArgumentNullException(nameof(column), "Argument cannot be null.");
			}

			for (int x = 0; x < this.Columns.Length; x++)
			{
				if (this.Columns[x] == column)
				{
					return x;
				}
			}

			return -1;
		}

		/// <summary>
		/// Gets the block which contains the specified cell.
		/// </summary>
		/// <param name="cell">
		/// The cell whose encompassing block is to be retrieved.
		/// </param>
		/// <returns>
		/// The block which contains the cell.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// Thrown if the specified cell is null.
		/// </exception>
		/// <exception cref="CellNotFoundException">
		/// Thrown if the specified cell is not contained within any block.
		/// </exception>
		public Block GetBlockContainingCell(Cell cell)
		{
			if (cell == null)
			{
				throw new ArgumentNullException(nameof(cell), "Argument cannot be null.");
			}

			foreach (Block block in this.Blocks)
			{
				if (block.Contains(cell))
				{
					return block;
				}
			}

			throw new CellNotFoundException("The specified cell is not contained in any block.");
		}

		/// <summary>
		/// Gets the row which contains the specified cell.
		/// </summary>
		/// <param name="cell">
		/// The cell whose encompassing row is to be retrieved.
		/// </param>
		/// <returns>
		/// The row which contains the cell.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// Thrown if the specified cell is null.
		/// </exception>
		/// <exception cref="CellNotFoundException">
		/// Thrown if the specified cell is not contained within any row.
		/// </exception>
		public Row GetRowContainingCell(Cell cell)
		{
			if (cell == null)
			{
				throw new ArgumentNullException(nameof(cell), "Argument cannot be null.");
			}

			Row row = this.Rows.SingleOrDefault((r) => r.Contains(cell));

			if (row == null)
			{
				throw new CellNotFoundException("The specified cell is not contained in any row.");
			}

			return row;
		}

		/// <summary>
		/// Gets the column which contains the specified cell.
		/// </summary>
		/// <param name="cell">
		/// The cell whose encompassing column is to be retrieved.
		/// </param>
		/// <returns>
		/// The column which contains the cell.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// Thrown if the specified cell is null.
		/// </exception>
		/// <exception cref="CellNotFoundException">
		/// Thrown if the specified cell is not contained within any column.
		/// </exception>
		public Column GetColumnContainingCell(Cell cell)
		{
			if (cell == null)
			{
				throw new ArgumentNullException(nameof(cell), "Argument cannot be null.");
			}

			Column column = this.Columns.SingleOrDefault((r) => r.Contains(cell));

			if (column == null)
			{
				throw new CellNotFoundException("The specified cell is not contained in any column.");
			}

			return column;
		}

		/// <summary>
		/// Returns an enumerator that iterates through each of the cells within this grid.
		/// </summary>
		/// <returns>
		/// An enumerator that can be used to iterate through the cells within this grid.
		/// </returns>
		public override IEnumerator<Cell> GetEnumerator()
		{
			for (int x = 0; x < 9; x++)
			{
				for (int y = 0; y < 9; y++)
				{
					yield return this.Cells[x, y];
				}
			}
		}

		/// <summary>
		/// Returns a string representation of the grid.
		/// </summary>
		public override string ToString()
		{
			var builder = new StringBuilder();

			void addLineBreak()
			{
				for (int i = 0; i < 31; i++)
				{
					builder.Append('—');
				}

				builder.AppendLine();
			};

			for (int y1 = 0; y1 < 3; y1++)
			{
				addLineBreak();

				for (int y2 = 0; y2 < 3; y2++)
				{
					for (int x1 = 0; x1 < 3; x1++)
					{
						builder.Append('|');

						for (int x2 = 0; x2 < 3; x2++)
						{
							Cell cell = this.Cells[x2 + 3 * x1, y2 + 3 * y1];

							if (cell.IsSolved())
							{
								builder.Append($" {cell.Solution.Value} ");
							}
							else
							{
								builder.Append("   ");
							}
						}
					}

					builder.AppendLine("|");
				}
			}

			addLineBreak();

			return builder.ToString();
		}
	}
}

using Showdoku.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Showdoku
{
	public class Grid : ICellContainer
	{
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
					Cell[,] blockCells = new Cell[3, 3];

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
				Cell[] rowCells = new Cell[9];

				for (int x = 0; x < 9; x++)
				{
					rowCells[x] = this.Cells[x, y];
				}

				this.Rows[y] = new Row(rowCells);
			}

			for (int x = 0; x < 9; x++)
			{
				Cell[] columnCells = new Cell[9];

				for (int y = 0; y < 9; y++)
				{
					columnCells[y] = this.Cells[x, y];
				}

				this.Columns[x] = new Column(columnCells);
			}
		}

		public Cell[,] Cells
		{
			get;
		}

		public Block[,] Blocks
		{
			get;
		}

		public Row[] Rows
		{
			get;
		}

		public Column[] Columns
		{
			get;
		}

		/// <summary>
		/// Gets a value indicating whether the grid has been successfully solved.
		/// </summary>
		/// <returns>
		/// True if the grid is solved, otherwise false.
		/// </returns>
		public bool IsSolved()
		{
			return this.All((c) => c.IsSolved());
		}

		/// <summary>
		/// Gets the total number of cells within the grid that have been solved.
		/// </summary>
		/// <returns>
		/// The total number of solved cells.
		/// </returns>
		public int GetSolvedCellCount()
		{
			return this.Count((c) => c.IsSolved());
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
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="CellNotFoundException"></exception>
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
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="CellNotFoundException"></exception>
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
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="CellNotFoundException"></exception>
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
		/// Returns a string representation of the grid in its current state.
		/// </summary>
		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();

			for (int y1 = 0; y1 < 3; y1++)
			{
				builder.AppendLine("———————————————————————————————");

				for (int y2 = 0; y2 < 3; y2++)
				{
					for (int x1 = 0; x1 < 3; x1++)
					{
						builder.Append("|");

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

			builder.AppendLine("———————————————————————————————");

			return builder.ToString();
		}

		public IEnumerator<Cell> GetEnumerator()
		{
			for (int x = 0; x < 9; x++)
			{
				for (int y = 0; y < 9; y++)
				{
					yield return this.Cells[x, y];
				}
			}
		}

		IEnumerable<Cell> ICellContainer.Cells
		{
			get
			{
				foreach (Cell cell in this)
				{
					yield return cell;
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}

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
					this.Cells[x, y] = new Cell();
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

		public void SolveCell(int x, int y, int solution)
		{
			Cell toSolve = this.Cells[x, y];
			this.SolveCell(toSolve, solution);
		}

		public void SolveCell(Cell toSolve, int solution)
		{
			if (toSolve == null)
			{
				throw new ArgumentNullException(nameof(toSolve), "Argument cannot be null.");
			}

			// TODO: Implement IEnumerable and validate cell exists in grid

			if (toSolve.IsSolved())
			{
				throw new AlreadySolvedException("This cell has already been solved.");
			}

			if (this.IsNumberAlreadyInBlock(toSolve, solution))
			{
				throw new InvalidSolutionException($"The block containing this cell already contains a cell with a solution of {solution}.", solution);
			}

			if (this.IsNumberAlreadyInRow(toSolve, solution))
			{
				throw new InvalidSolutionException($"The row containing this cell already contains a cell with a solution of {solution}.", solution);
			}

			if (this.IsNumberAlreadyInColumn(toSolve, solution))
			{
				throw new InvalidSolutionException($"The column containing this cell already contains a cell with a solution of {solution}.", solution);
			}

			toSolve.Solve(solution);
		}

		public bool IsSolved()
		{
			return this.All((c) => c.IsSolved());
		}

		public int GetSolvedCellCount()
		{
			return this.Count((c) => c.IsSolved());
		}

		public bool IsCellSolutionValid(int x, int y, int solution)
		{
			Cell toSolve = this.Cells[x, y];

			if (solution < 1 || solution > 9)
			{
				return false;
			}

			if (this.IsNumberAlreadyInBlock(toSolve, solution))
			{
				return false;
			}
			
			if (this.IsNumberAlreadyInRow(toSolve, solution))
			{
				return false;
			}			

			if (this.IsNumberAlreadyInColumn(toSolve, solution))
			{
				return false;
			}

			return true;
		}

		private bool IsNumberAlreadyInBlock(Cell toSolve, int number)
		{
			foreach (Cell blockCell in this.GetBlockContainingCell(toSolve).Cells)
			{
				if (blockCell != toSolve && blockCell.IsSolved() && blockCell.Solution.Value == number)
				{
					return true;
				}
			}

			return false;
		}

		private bool IsNumberAlreadyInRow(Cell toSolve, int number)
		{
			foreach (Cell rowCell in this.GetRowContainingCell(toSolve).Cells)
			{
				if (rowCell != toSolve && rowCell.IsSolved() && rowCell.Solution.Value == number)
				{
					return true;
				}
			}

			return false;
		}

		private bool IsNumberAlreadyInColumn(Cell toSolve, int number)
		{
			foreach (Cell columnCell in this.GetColumnContainingCell(toSolve).Cells)
			{
				if (columnCell != toSolve && columnCell.IsSolved() && columnCell.Solution.Value == number)
				{
					return true;
				}
			}

			return false;
		}

		public Block GetBlockContainingCell(Cell cell)
		{
			foreach (Block block in this.Blocks)
			{
				if (block.Contains(cell))
				{
					return block;
				}
			}

			throw new CellNotFoundException("The specified cell is not contained in any block.");
		}

		public Row GetRowContainingCell(Cell cell)
		{
			Row row = this.Rows.SingleOrDefault((r) => r.Contains(cell));

			if (row == null)
			{
				throw new CellNotFoundException("The specified cell is not contained in any row.");
			}

			return row;
		}

		public Column GetColumnContainingCell(Cell cell)
		{
			Column column = this.Columns.SingleOrDefault((r) => r.Contains(cell));

			if (column == null)
			{
				throw new CellNotFoundException("The specified cell is not contained in any column.");
			}

			return column;
		}

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

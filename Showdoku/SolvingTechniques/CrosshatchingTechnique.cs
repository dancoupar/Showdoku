using System;

namespace Showdoku.SolvingTechniques
{
	/// <summary>
	/// A technique for solving cells within a sudoku grid by eliminating pencil marks for each
	/// cell based on whether any other cell within the same block, row or column has the penil
	/// mark as its solution.
	/// </summary>
	public class CrosshatchingTechnique : ISolvingTechnique
	{
		/// <summary>
		/// Gets a value indicating whether the solving process should be restarted if this
		/// technique proves successful.
		/// </summary>
		public bool RestartSolvingProcessOnSuccess
		{
			get
			{
				return false;
			}
		}

		/// <summary>
		/// Applies the technique to the specified grid.
		/// </summary>
		/// <param name="grid">
		/// The grid to which the technique should be applied.
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// Thrown if the specified grid is null.
		/// </exception>
		public void Apply(Grid grid)
		{
			if (grid == null)
			{
				throw new ArgumentNullException(nameof(grid), "Argument cannot be null.");
			}

			foreach (Cell cell in grid.Cells)
			{
				if (!cell.IsSolved())
				{
					Apply(grid, cell);
				}
			}
		}

		private static void Apply(Grid grid, Cell cell)
		{
			Block containingBlock = grid.GetBlockContainingCell(cell);
			Row containingRow = grid.GetRowContainingCell(cell);
			Column containingColumn = grid.GetColumnContainingCell(cell);

			foreach (Cell blockCell in containingBlock.Cells)
			{
				if (blockCell.IsSolved())
				{
					// Number appears elsewhere in same block
					cell.RemovePencilMark(blockCell.Solution.Value);

					if (cell.IsSolved())
					{
						return;
					}
				}
			}

			foreach (Cell rowCell in containingRow.Cells)
			{
				if (rowCell.IsSolved())
				{
					// Number appears elsewhere in same row
					cell.RemovePencilMark(rowCell.Solution.Value);

					if (cell.IsSolved())
					{
						return;
					}
				}
			}

			foreach (Cell columnCell in containingColumn.Cells)
			{
				if (columnCell.IsSolved())
				{
					// Number appears elsewhere in same column
					cell.RemovePencilMark(columnCell.Solution.Value);

					if (cell.IsSolved())
					{
						return;
					}
				}
			}
		}
	}
}

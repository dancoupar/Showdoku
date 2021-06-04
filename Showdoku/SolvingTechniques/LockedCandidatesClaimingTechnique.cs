using System;
using System.Collections.Generic;
using System.Linq;

namespace Showdoku.SolvingTechniques
{
	/// <summary>
	/// A technique for eliminating pencil marks within a soduko grid by identifying solutions that
	/// are restricted to a single row or column.
	/// </summary>
	public class LockedCandidatesClaimingTechnique : ISolvingTechnique
	{
		/// <summary>
		/// Gets a value indicating whether the solving process should be restarted if this
		/// technique proves successful.
		/// </summary>
		public bool RestartSolvingProcessOnSuccess
		{
			get
			{
				return true;
			}
		}

		public void Apply(Grid grid)
		{
			if (grid == null)
			{
				throw new ArgumentNullException(nameof(grid), "Argument cannot be null.");
			}

			foreach (Row row in grid.Rows)
			{
				Apply(grid, row);
			}

			foreach (Column column in grid.Columns)
			{
				Apply(grid, column);
			}
		}

		private static void Apply(Grid grid, CellCollection rowOrColumn)
		{
			for (int solution = 1; solution < 10; solution++)
			{
				if (!rowOrColumn.Any(c => c.Solution == solution))
				{
					// Find all cells in the row or column that have the solution as a pencil mark.
					// The solution must belong to one of those cells. Therefore, if they're all
					// within the same block, we can remove that penil mark from all other cells in
					// that block.

					IEnumerable<Cell> cellsWithPencilMark = rowOrColumn.Where((c) => c.PencilMarks.Contains(solution));

					if (AllCellsBelongToSameBlock(grid, cellsWithPencilMark, out Block block))
					{
						foreach (Cell cell in block.Except(cellsWithPencilMark))
						{
							if (!cell.IsSolved())
							{
								cell.ErasePencilMark(solution);
							}
						}
					}
				}
			}
		}

		private static bool AllCellsBelongToSameBlock(Grid grid, IEnumerable<Cell> cells, out Block block)
		{
			block = null;

			if (!cells.Any())
			{
				return false;
			}

			Block firstBlock = grid.GetBlockContainingCell(cells.First());

			foreach (Cell cell in cells.Skip(1))
			{
				if (grid.GetBlockContainingCell(cell) != firstBlock)
				{					
					return false;
				}
			}

			block = firstBlock;
			return true;
		}
	}
}

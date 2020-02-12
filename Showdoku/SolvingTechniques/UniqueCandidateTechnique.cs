using System;
using System.Linq;

namespace Showdoku.SolvingTechniques
{
	public class UniqueCandidateTechnique : ISolvingTechnique
	{
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

			foreach (Cell cell in grid.Cells)
			{
				if (!cell.IsSolved())
				{
					if (this.ApplyToCell(grid, cell))
					{
						// This technique stops once it makes progress,
						// in order for the more basic techniques to be
						// reapplied.

						return;
					}
				}
			}
		}

		private bool ApplyToCell(Grid grid, Cell cell)
		{
			Block containingBlock = grid.GetBlockContainingCell(cell);
			Row containingRow = grid.GetRowContainingCell(cell);
			Column containingColumn = grid.GetColumnContainingCell(cell);

			foreach (int pencilMark in cell.PencilMarks)
			{
				// Is this the only cell in its block with this pencil mark?
				if (this.IsOnlyCellWithPencilMark(cell, containingBlock, pencilMark))
				{
					// If so, we can solve it
					grid.SolveCell(cell, pencilMark);
					return true;
				}

				// Is this the only cell in its row with this pencil mark?
				if (this.IsOnlyCellWithPencilMark(cell, containingRow, pencilMark))
				{
					// If so, we can solve it
					grid.SolveCell(cell, pencilMark);
					return true;
				}

				// Is this the only cell in its column with this pencil mark?
				if (this.IsOnlyCellWithPencilMark(cell, containingColumn, pencilMark))
				{
					// If so, we can solve it
					grid.SolveCell(cell, pencilMark);
					return true;
				}
			}

			return false;
		}

		private bool IsOnlyCellWithPencilMark(Cell cell, ICellContainer container, int pencilMark)
		{
			foreach (Cell otherCell in container.Where((c) => c != cell))
			{
				if (otherCell.PencilMarks.Contains(pencilMark))
				{
					return false;
				}
			}

			return true;
		}
	}
}

using System;

namespace Showdoku.SolvingTechniques
{
	public class SoleCandidateTechnique : ISolvingTechnique
	{
		public bool RestartSolvingProcessOnSuccess
		{
			get
			{
				return false;
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
					this.ApplyToCell(grid, cell);
				}
			}
		}

		private void ApplyToCell(Grid grid, Cell cell)
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

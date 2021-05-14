using System;
using System.Collections.Generic;
using System.Linq;

namespace Showdoku.SolvingTechniques
{
	/// <summary>
	/// A technique for eliminating pencil marks within a soduko grid by identifying pencil marks that
	/// are restricted to a single row or column.
	/// </summary>
	public class LockedCandidatesTechnique : ISolvingTechnique
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

			foreach (Block block in grid.Blocks)
			{
				for (int pencilMark = 1; pencilMark < 10; pencilMark++)
				{
					IEnumerable<Cell> cellsWithPencilMark = block.Where((c) => c.PencilMarks.Contains(pencilMark));

					if (cellsWithPencilMark.Count() == 2 || cellsWithPencilMark.Count() == 3)
					{
						// We have 2 or 3 or cells within the block that share an exclusive pencil mark.
						// Now need to work out if all the cells share the same row or column.

						if (cellsWithPencilMark.All((c) => block.YIndexOf(c) == block.YIndexOf(cellsWithPencilMark.First())))
						{
							// All cells are in the same row
							RemovePencilMarkFromAllCellsNotInBlock(grid.GetRowContainingCell(cellsWithPencilMark.First()), pencilMark, block);
						}
						else if (cellsWithPencilMark.All((c) => block.XIndexOf(c) == block.XIndexOf(cellsWithPencilMark.First())))
						{
							// All cells are in the same column
							RemovePencilMarkFromAllCellsNotInBlock(grid.GetColumnContainingCell(cellsWithPencilMark.First()), pencilMark, block);
						}
					}
				}
			}
		}

		private static void RemovePencilMarkFromAllCellsNotInBlock(CellCollection cells, int pencilMark, Block block)
		{
			foreach (Cell cell in cells.Where((c) => !c.IsSolved()))
			{
				if (!block.Contains(cell))
				{
					cell.RemovePencilMark(pencilMark);
				}
			}
		}
	}
}

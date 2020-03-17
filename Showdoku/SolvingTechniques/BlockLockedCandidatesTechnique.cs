using System;

namespace Showdoku.SolvingTechniques
{
	/// <summary>
	/// A technique for eliminating pencil marks within a sudoku grid by identifying pairs of cells
	/// within individual blocks that share an exclusive pencil mark and that appear in the same row
	/// or column.
	/// </summary>
	public class BlockLockedCandidatesTechnique : ISolvingTechnique
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
		}
	}
}

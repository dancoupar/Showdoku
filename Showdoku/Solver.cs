using Showdoku.SolvingTechniques;
using System;
using System.Collections.Generic;

namespace Showdoku
{
	public class Solver
	{
		private readonly ICollection<ISolvingTechnique> techniques;

		public Solver(ICollection<ISolvingTechnique> techniques)
		{
			if (techniques == null)
			{
				throw new ArgumentNullException(nameof(techniques), "Argument cannot be null.");
			}

			this.techniques = techniques;
		}

		public bool TrySolve(Grid grid, out string report)
		{
			if (grid == null)
			{
				throw new ArgumentNullException(nameof(grid), "Argument cannot be null.");
			}

			long startTicks = DateTime.UtcNow.Ticks;

			bool progressMade;
			do
			{
				int startingSolvedCellCount = grid.GetSolvedCellCount();
				this.ApplyTechniques(grid);
				progressMade = this.ProgressMade(grid, startingSolvedCellCount);
			}
			while (progressMade);

			long endTicks = DateTime.UtcNow.Ticks;

			if (grid.IsSolved())
			{
				report = $"Grid solved in {new TimeSpan(endTicks - startTicks).TotalSeconds} seconds.";
				return true;
			}
			else
			{
				report = "Could not solve grid.";
				return false;
			}
		}

		private void ApplyTechniques(Grid grid)
		{
			foreach (ISolvingTechnique technique in this.techniques)
			{
				bool progressMade;
				do
				{
					int startingSolvedCellCount = grid.GetSolvedCellCount();
					technique.Apply(grid);
					progressMade = this.ProgressMade(grid, startingSolvedCellCount);

					if (progressMade && technique.RestartSolvingProcessOnSuccess)
					{
						return;
					}

				} while (progressMade);
			}			
		}

		private bool ProgressMade(Grid grid, int startingSolvedCellCount)
		{
			return grid.GetSolvedCellCount() > startingSolvedCellCount;
		}
	}
}

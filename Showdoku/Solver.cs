using Showdoku.SolvingTechniques;
using System;
using System.Collections.Generic;

namespace Showdoku
{
	/// <summary>
	/// Provides a framework for applying techniques for solving a sudoku grid.
	/// </summary>
	public class Solver
	{
		private readonly ICollection<ISolvingTechnique> techniques;

		/// <summary>
		/// Creates a new solver for solving sudoku grids using the specified techniques.
		/// </summary>
		/// <param name="techniques">
		/// A collection of techniques for solving a sudoku grid.
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// Thrown if the specified collection of techniques is null.
		/// </exception>
		public Solver(params ISolvingTechnique[] techniques)
		{
			this.techniques = techniques ?? throw new ArgumentNullException(nameof(techniques), "Argument cannot be null.");
		}

		/// <summary>
		/// Attempts to solve the specified sudoku grid.
		/// </summary>
		/// <param name="grid">
		/// The sudoku grid to try and solve.
		/// </param>
		/// <param name="report">
		/// An output parameter describing the outcome.
		/// </param>
		/// <returns>
		/// True if the grid was successfully solved, otherwise false.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// Thrown if the specified grid is null.
		/// </exception>
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

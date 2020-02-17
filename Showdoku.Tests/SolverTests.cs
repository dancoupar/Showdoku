using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Showdoku.Setup;
using Showdoku.SolvingTechniques;
using System.Collections.Generic;

namespace Showdoku
{
	[TestClass]
	public class SolverTests
	{
		[TestMethod]
		public void Should_be_able_to_solve_medium_grid_b()
		{
			// Arrange			
			Solver solver = new Solver(
				new List<ISolvingTechnique>()
				{
					new SoleCandidateTechnique(),
					new UniqueCandidateTechnique()
				}
			);

			Grid grid = new GridBuilder().WithMediumGrid_B();

			// Act
			bool result = solver.TrySolve(grid, out string report);

			// Assert
			result.Should().BeTrue();
			this.AssertSolutionIsValid(grid);
		}

		private void AssertSolutionIsValid(Grid grid)
		{
			for (int x = 0; x < 9; x++)
			{
				for (int y = 0; y < 9; y++)
				{
					grid.Cells[x, y].IsSolutionValid(grid.Cells[x, y].Solution.Value).Should().BeTrue();
				}
			}
		}
	}
}

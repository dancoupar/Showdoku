using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Showdoku.Setup;
using System;

namespace Showdoku.SolvingTechniques
{
	[TestClass]
	public class UniqueCandidateTechniqueTests
	{
		[TestMethod]
		public void Technique_should_throw_if_passed_null_grid()
		{
			// Arrange
			UniqueCandidateTechnique cut = new UniqueCandidateTechnique();

			// Act
			Action act = () =>
			{
				cut.Apply(null);
			};

			// Assert
			act.Should().Throw<ArgumentNullException>();
		}

		[TestMethod]
		public void Cells_within_a_block_that_have_a_unique_pencil_mark_should_be_solved()
		{
			// Arrange
			
			// Arrange a grid containing a block where the number 4 can appear in only one cell
			// owing to all other cells not having the number 4 as a pencil mark (i.e. for all
			// other cells, the number 4 appears elsewhere in the same row or column, or the cell
			// has already been solved).
			
			Grid grid = new GridBuilder().WithEmptyGrid();

			grid.Cells[2, 0].Solve(4);
			grid.Cells[1, 4].Solve(4);
			grid.Cells[0, 6].Solve(5);
			grid.Cells[5, 8].Solve(4);

			// The unique candidate technique relies on the sole candidate technique eliminating
			// pencil marks.

			SoleCandidateTechnique soleCandidate = new SoleCandidateTechnique();
			soleCandidate.Apply(grid);

			UniqueCandidateTechnique cut = new UniqueCandidateTechnique();

			// Act
			cut.Apply(grid);

			// Assert
			grid.Cells[0, 7].IsSolved().Should().BeTrue();
			grid.Cells[0, 7].Solution.Value.Should().Be(4);
		}
	}
}

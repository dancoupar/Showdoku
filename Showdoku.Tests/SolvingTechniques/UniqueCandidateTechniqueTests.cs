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
			// owing to all other cells in that block not having the number 4 as a pencil mark
			// (i.e. for all other cells, the number 4 appears elsewhere in the same row or
			// column, or the cell has already been solved).

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

		[TestMethod]
		public void Cells_within_a_row_that_have_a_unique_pencil_mark_should_be_solved()
		{
			// Arrange

			// Arrange a grid containing a row where the number 6 can appear in only one cell owing
			// to all other cells in that row not having the number 6 as a pencil mark (i.e. for
			// all other cells, the number 6 appears elsewhere in the same column, or the cell has
			// already been solved).

			Grid grid = new GridBuilder().WithEmptyGrid();

			grid.Cells[0, 0].Solve(1);
			grid.Cells[1, 0].Solve(2);
			grid.Cells[2, 0].Solve(3);
			grid.Cells[6, 0].Solve(7);
			grid.Cells[7, 0].Solve(8);
			grid.Cells[8, 0].Solve(9);
			grid.Cells[3, 3].Solve(6);
			grid.Cells[5, 6].Solve(6);

			// The unique candidate technique relies on the sole candidate technique eliminating
			// pencil marks.

			SoleCandidateTechnique soleCandidate = new SoleCandidateTechnique();
			soleCandidate.Apply(grid);

			UniqueCandidateTechnique cut = new UniqueCandidateTechnique();

			// Act
			cut.Apply(grid);

			// Assert
			grid.Cells[4, 0].IsSolved().Should().BeTrue();
			grid.Cells[4, 0].Solution.Value.Should().Be(6);
		}

		[TestMethod]
		public void Cells_within_a_column_that_have_a_unique_pencil_mark_should_be_solved()
		{
			// Arrange

			// Arrange a grid containing a column where the number 5 can appear in only one cell
			// owing to all other cells in that column not having the number 5 as a pencil mark
			// (i.e. for all other cells, the number 5 appears elsewhere in the same row, or the
			// cell has already been solved).

			Grid grid = new GridBuilder().WithEmptyGrid();

			grid.Cells[4, 0].Solve(1);
			grid.Cells[7, 1].Solve(5);
			grid.Cells[4, 2].Solve(3);
			grid.Cells[2, 3].Solve(5);
			grid.Cells[6, 5].Solve(5);
			grid.Cells[4, 6].Solve(7);
			grid.Cells[1, 7].Solve(5);
			grid.Cells[4, 8].Solve(9);

			// The unique candidate technique relies on the sole candidate technique eliminating
			// pencil marks.

			SoleCandidateTechnique soleCandidate = new SoleCandidateTechnique();
			soleCandidate.Apply(grid);

			UniqueCandidateTechnique cut = new UniqueCandidateTechnique();

			// Act
			cut.Apply(grid);

			// Assert
			grid.Cells[4, 4].IsSolved().Should().BeTrue();
			grid.Cells[4, 4].Solution.Value.Should().Be(5);
		}
	}
}

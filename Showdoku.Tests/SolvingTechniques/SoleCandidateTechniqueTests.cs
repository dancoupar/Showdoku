using FluentAssertions;
using Showdoku.Setup;
using System;
using Xunit;

namespace Showdoku.SolvingTechniques
{
	public class SoleCandidateTechniqueTests
	{
		[Fact]
		public void Technique_throws_if_no_grid_is_provided()
		{
			// Arrange
			var cut = new SoleCandidateTechnique();

			// Act
			Action act = () =>
			{
				cut.Apply(null);
			};

			// Assert
			act.Should().Throw<ArgumentNullException>();
		}

		[Fact]
		public void Cells_within_a_block_that_have_a_unique_pencil_mark_can_be_solved()
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

			// Eliminate some pencil marks from block 0,2 using basic scanning; a 4 appears
			// elsewhere outside the block in columns 1 and 2 and in row 8.

			grid.Cells[1, 6].ErasePencilMark(4);
			grid.Cells[2, 6].ErasePencilMark(4);
			grid.Cells[1, 7].ErasePencilMark(4);
			grid.Cells[2, 7].ErasePencilMark(4);
			grid.Cells[0, 8].ErasePencilMark(4);
			grid.Cells[1, 8].ErasePencilMark(4);
			grid.Cells[2, 8].ErasePencilMark(4);

			var cut = new SoleCandidateTechnique();

			// Act
			cut.Apply(grid);

			// Assert
			grid.Cells[0, 7].IsSolved().Should().BeTrue();
			grid.Cells[0, 7].Solution.Value.Should().Be(4);
		}

		[Fact]
		public void Cells_within_a_row_that_have_a_unique_pencil_mark_can_be_solved()
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

			// Eliminate some pencil marks from block 1,0 using basic scanning; a 6 appears
			// elsewhere outside the block in columns 3 and 5.

			grid.Cells[3, 0].ErasePencilMark(6);
			grid.Cells[5, 0].ErasePencilMark(6);

			var cut = new SoleCandidateTechnique();

			// Act
			cut.Apply(grid);

			// Assert
			grid.Cells[4, 0].IsSolved().Should().BeTrue();
			grid.Cells[4, 0].Solution.Value.Should().Be(6);
		}

		[Fact]
		public void Cells_within_a_column_that_have_a_unique_pencil_mark_can_be_solved()
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

			// Eliminate some pencil marks using basic scanning. In block 1,0, a 5 appears
			// elsewhere outside the block in row 1. In block 1,1, a 5 appears elsewhere outside
			// outside the block in rows 3 and 5. In block 1,2, a 5 appears elsewhere outside the
			// block in row 7.

			grid.Cells[4, 1].ErasePencilMark(5);
			grid.Cells[4, 3].ErasePencilMark(5);
			grid.Cells[4, 5].ErasePencilMark(5);
			grid.Cells[4, 7].ErasePencilMark(5);

			var cut = new SoleCandidateTechnique();

			// Act
			cut.Apply(grid);

			// Assert
			grid.Cells[4, 4].IsSolved().Should().BeTrue();
			grid.Cells[4, 4].Solution.Value.Should().Be(5);
		}
	}
}

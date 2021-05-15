using FluentAssertions;
using Showdoku.Setup;
using System;
using Xunit;

namespace Showdoku.SolvingTechniques
{
	public class CrosshatchingTechniqueTests
	{
		[Fact]
		public void Technique_throws_if_no_grid_is_provided()
		{
			// Arrange
			var cut = new CrosshatchingTechnique();

			// Act
			Action act = () =>
			{
				cut.Apply(null);
			};

			// Assert
			act.Should().Throw<ArgumentNullException>();
		}

		[Fact]
		public void The_solution_of_a_cell_does_not_appear_anywhere_within_the_encompassing_block_as_a_pencil_mark()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();
			Cell solvedCell = grid.Cells[0, 0];
			solvedCell.Solve(8);

			var cut = new CrosshatchingTechnique();

			// Act
			cut.Apply(grid);

			// Assert			
			foreach (var cell in grid.GetBlockContainingCell(solvedCell))
			{
				cell.PencilMarks.Should().NotContain(8);
			}
		}

		[Fact]
		public void The_solution_of_a_cell_does_not_appear_anywhere_within_the_encompassing_row_as_a_pencil_mark()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();
			Cell solvedCell = grid.Cells[0, 0];
			solvedCell.Solve(8);

			var cut = new CrosshatchingTechnique();

			// Act
			cut.Apply(grid);

			// Assert			
			foreach (var cell in grid.GetRowContainingCell(solvedCell))
			{
				cell.PencilMarks.Should().NotContain(8);
			}
		}

		[Fact]
		public void The_solution_of_a_cell_does_not_appear_anywhere_within_the_encompassing_column_as_a_pencil_mark()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();
			Cell solvedCell = grid.Cells[0, 0];
			solvedCell.Solve(8);

			var cut = new CrosshatchingTechnique();

			// Act
			cut.Apply(grid);

			// Assert			
			foreach (var cell in grid.GetColumnContainingCell(solvedCell))
			{
				cell.PencilMarks.Should().NotContain(8);
			}
		}

		[Fact]
		public void A_cell_where_all_but_one_number_appears_elsewhere_in_the_same_block_row_or_column_can_be_solved()
		{
			// Arrange

			// Arrange a grid that contains a cell where all but one number appears in the cell's
			// own block, row or column, leaving that number the only possible solution.

			Grid grid = new GridBuilder().WithEmptyGrid();
			grid.Cells[5, 0].Solve(1);
			grid.Cells[5, 2].Solve(6);
			grid.Cells[3, 3].Solve(4);
			grid.Cells[4, 4].Solve(8);
			grid.Cells[0, 5].Solve(2);
			grid.Cells[2, 5].Solve(9);
			grid.Cells[8, 5].Solve(7);
			grid.Cells[5, 7].Solve(3);

			var cut = new CrosshatchingTechnique();

			// Act
			cut.Apply(grid);

			// Assert
			grid.Cells[5, 5].IsSolved().Should().BeTrue();
			grid.Cells[5, 5].Solution.Value.Should().Be(5);
		}
	}
}

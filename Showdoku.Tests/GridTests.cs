using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Showdoku.Exceptions;
using Showdoku.Setup;
using System;

namespace Showdoku
{
	[TestClass]
	public class GridTests
	{
		[TestMethod]
		public void A_grid_should_have_2_dimensions()
		{
			// Arrange
			// Act
			Grid grid = new Grid();

			// Assert
			grid.Cells.Rank.Should().Be(2);
		}

		[TestMethod]
		public void A_grid_should_contain_9_by_9_cells()
		{
			// Arrange			
			// Act
			Grid grid = new Grid();

			// Assert
			grid.Cells.GetLength(0).Should().Be(9);
			grid.Cells.GetLength(1).Should().Be(9);
		}

		[TestMethod]
		public void A_grid_should_contain_3_by_3_blocks()
		{
			// Arrange
			// Act
			Grid grid = new Grid();

			// Assert
			grid.Blocks.GetLength(0).Should().Be(3);
			grid.Blocks.GetLength(1).Should().Be(3);
		}

		[TestMethod]
		public void A_grid_should_contain_9_rows()
		{
			// Arrange
			// Act
			Grid grid = new Grid();

			// Assert
			grid.Rows.Length.Should().Be(9);
		}

		[TestMethod]
		public void A_grid_should_contain_9_columns()
		{
			// Arrange			
			// Act
			Grid grid = new Grid();

			// Assert
			grid.Columns.Length.Should().Be(9);
		}

		[TestMethod]
		public void A_grid_containing_only_solved_cells_should_be_classed_as_solved()
		{
			// Arrange
			// Act
			Grid grid = new GridBuilder().WithSolvedGrid();

			// Assert
			foreach (Cell cell in grid.Cells)
			{
				cell.IsSolved().Should().BeTrue();
			}

			grid.IsSolved().Should().BeTrue();
		}

		[TestMethod]
		public void A_grid_containing_any_unsolved_cells_should_be_classed_as_unsolved()
		{
			// Arrange
			Grid grid = new GridBuilder().WithSolvedGrid();

			// Act
			grid.Cells[0, 0].Empty();

			// Assert
			grid.IsSolved().Should().BeFalse();
		}

		[TestMethod]
		public void A_cell_solution_should_not_be_deemed_valid_if_the_same_number_appears_elsewhere_in_the_same_block()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();
			grid.SolveCell(0, 0, 1);

			// Act
			bool result = grid.IsCellSolutionValid(1, 1, 1);

			// Assert
			result.Should().BeFalse();
		}

		[TestMethod]
		public void A_cell_solution_should_not_be_deemed_valid_if_the_same_number_appears_elsewhere_in_the_same_row()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();
			grid.SolveCell(0, 0, 1);

			// Act
			bool result = grid.IsCellSolutionValid(0, 8, 1);

			// Assert
			result.Should().BeFalse();
		}

		[TestMethod]
		public void A_cell_solution_should_not_be_deemed_valid_if_the_same_number_appears_elsewhere_in_the_same_column()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();
			grid.SolveCell(0, 0, 1);

			// Act
			bool result = grid.IsCellSolutionValid(8, 0, 1);

			// Assert
			result.Should().BeFalse();
		}

		[TestMethod]
		public void A_cell_solution_should_not_be_deemed_valid_if_its_less_than_1()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();

			// Act
			bool result = grid.IsCellSolutionValid(0, 0, 0);

			// Assert
			result.Should().BeFalse();
		}

		[TestMethod]
		public void A_cell_solution_should_not_be_deemed_valid_if_its_more_than_9()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();

			// Act
			bool result = grid.IsCellSolutionValid(0, 0, 10);

			// Assert
			result.Should().BeFalse();
		}

		[TestMethod]
		public void Checking_whether_a_cell_solution_is_valid_should_throw_if_the_x_index_is_less_than_0()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();

			// Act
			Action act = () =>
			{
				grid.IsCellSolutionValid(-1, 0, 0);
			};

			// Assert
			act.Should().Throw<IndexOutOfRangeException>();
		}

		[TestMethod]
		public void Checking_whether_a_cell_solution_is_valid_should_throw_if_the_x_index_is_more_than_8()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();

			// Act
			Action act = () =>
			{
				grid.IsCellSolutionValid(9, 0, 0);
			};

			// Assert
			act.Should().Throw<IndexOutOfRangeException>();
		}

		[TestMethod]
		public void Checking_whether_a_cell_solution_is_valid_should_throw_if_the_y_index_is_less_than_0()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();

			// Act
			Action act = () =>
			{
				grid.IsCellSolutionValid(0, -1, 0);
			};

			// Assert
			act.Should().Throw<IndexOutOfRangeException>();
		}

		[TestMethod]
		public void Checking_whether_a_cell_solution_is_valid_should_throw_if_the_y_index_is_more_than_8()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();

			// Act
			Action act = () =>
			{
				grid.IsCellSolutionValid(0, 9, 0);
			};

			// Assert
			act.Should().Throw<IndexOutOfRangeException>();
		}

		[TestMethod]
		public void A_cell_solution_should_be_deemed_valid_if_the_same_number_does_not_appear_anywhere_else_in_the_same_block_or_row_or_column()
		{
			// For this test, start with a solved grid, then empty a cell, remembering its value.
			// That value should necessarily be a valid solution for the cell that's been emptied.

			// Arrange
			Grid grid = new GridBuilder().WithSolvedGrid();
			int cellValue = grid.Cells[0, 0].Solution.Value;
			grid.Cells[0, 0].Empty();

			// Act
			bool result = grid.IsCellSolutionValid(0, 0, cellValue);

			// Assert
			result.Should().BeTrue();
		}

		[TestMethod]
		public void Solving_a_cell_with_a_value_that_appears_in_the_same_block_should_throw()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();

			// Act
			grid.SolveCell(0, 0, 4);

			Action act = () =>
			{
				grid.SolveCell(1, 1, 4);
			};

			// Assert
			act.Should().Throw<InvalidSolutionException>();
		}

		[TestMethod]
		public void Solving_a_cell_with_a_value_that_appears_in_the_same_column_should_throw()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();

			// Act
			grid.SolveCell(0, 0, 5);

			Action act = () =>
			{
				grid.SolveCell(1, 0, 5);
			};

			// Assert
			act.Should().Throw<InvalidSolutionException>();
		}

		[TestMethod]
		public void Solving_a_cell_with_a_value_that_appears_in_the_same_row_should_throw()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();

			// Act
			grid.SolveCell(0, 0, 6);

			Action act = () =>
			{
				grid.SolveCell(0, 1, 6);
			};

			// Assert
			act.Should().Throw<InvalidSolutionException>();
		}
	}
}

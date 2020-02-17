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
			grid.Cells[0, 0].Solve(1);

			// Act
			bool result = grid.Cells[1, 1].IsSolutionValid(1);

			// Assert
			result.Should().BeFalse();
		}

		[TestMethod]
		public void A_cell_solution_should_not_be_deemed_valid_if_the_same_number_appears_elsewhere_in_the_same_row()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();
			grid.Cells[0, 0].Solve(1);

			// Act
			bool result = grid.Cells[0, 8].IsSolutionValid(1);

			// Assert
			result.Should().BeFalse();
		}

		[TestMethod]
		public void A_cell_solution_should_not_be_deemed_valid_if_the_same_number_appears_elsewhere_in_the_same_column()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();
			grid.Cells[0, 0].Solve(1);

			// Act
			bool result = grid.Cells[8, 0].IsSolutionValid(1);

			// Assert
			result.Should().BeFalse();
		}

		[TestMethod]
		public void A_cell_solution_should_not_be_deemed_valid_if_its_less_than_1()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();

			// Act
			bool result = grid.Cells[0, 0].IsSolutionValid(0);

			// Assert
			result.Should().BeFalse();
		}

		[TestMethod]
		public void A_cell_solution_should_not_be_deemed_valid_if_its_more_than_9()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();

			// Act
			bool result = grid.Cells[0, 0].IsSolutionValid(10);

			// Assert
			result.Should().BeFalse();
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
			bool result = grid.Cells[0, 0].IsSolutionValid(cellValue);

			// Assert
			result.Should().BeTrue();
		}

		[TestMethod]
		public void Solving_a_cell_with_a_value_that_appears_in_the_same_block_should_throw()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();

			// Act
			grid.Cells[0, 0].Solve(4);

			Action act = () =>
			{
				grid.Cells[1, 1].Solve(4);
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
			grid.Cells[0, 0].Solve(5);

			Action act = () =>
			{
				grid.Cells[1, 0].Solve(5);
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
			grid.Cells[0, 0].Solve(6);

			Action act = () =>
			{
				grid.Cells[0, 1].Solve(6);
			};

			// Assert
			act.Should().Throw<InvalidSolutionException>();
		}
	}
}

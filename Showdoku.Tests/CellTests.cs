using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Showdoku.Exceptions;
using Showdoku.Setup;
using System;

namespace Showdoku
{
	[TestClass]
	public class CellTests
	{
		[TestMethod]
		public void A_new_cell_should_have_nine_pencil_marks()
		{
			// Arrange
			// Act
			Cell cell = new Cell(new Grid());

			// Assert
			cell.PencilMarks.Count.Should().Be(9);

			cell.PencilMarks.Should().Contain(1);
			cell.PencilMarks.Should().Contain(2);
			cell.PencilMarks.Should().Contain(3);
			cell.PencilMarks.Should().Contain(4);
			cell.PencilMarks.Should().Contain(5);
			cell.PencilMarks.Should().Contain(6);
			cell.PencilMarks.Should().Contain(7);
			cell.PencilMarks.Should().Contain(8);
			cell.PencilMarks.Should().Contain(9);
		}

		[TestMethod]
		public void A_solved_cell_should_have_no_pencil_marks()
		{
			// Arrange
			Grid grid = new Grid();
			Cell cell = grid.Cells[0, 0];

			// Act
			cell.Solve(1);

			// Assert
			cell.PencilMarks.Count.Should().Be(0);
		}

		[TestMethod]
		public void A_cell_with_a_solution_should_be_classed_as_solved()
		{
			// Arrange
			Grid grid = new Grid();
			Cell cell = grid.Cells[0, 0];

			// Act
			cell.Solve(1);

			// Assert
			cell.Solution.HasValue.Should().BeTrue();
			cell.IsSolved().Should().BeTrue();
		}

		[TestMethod]
		public void A_cell_without_a_solution_should_be_classed_as_unsolved()
		{
			// Arrange
			// Act
			Grid grid = new Grid();
			Cell cell = grid.Cells[0, 0];

			// Assert
			cell.Solution.HasValue.Should().BeFalse();
			cell.IsSolved().Should().BeFalse();
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
		public void Solving_should_throw_if_the_cell_is_already_solved()
		{
			// Arrange
			Grid grid = new Grid();
			Cell cell = grid.Cells[0, 0];

			// Act			
			Action act = () =>
			{
				cell.Solve(1);
				cell.Solve(2);
			};

			// Assert
			act.Should().Throw<AlreadySolvedException>();
		}

		[TestMethod]
		public void Solving_should_throw_if_the_solution_is_less_than_one()
		{
			// Arrange
			Grid grid = new Grid();
			Cell cell = grid.Cells[0, 0];

			// Act
			Action act = () =>
			{
				cell.Solve(0);
			};

			// Assert
			act.Should().Throw<ArgumentOutOfRangeException>();
		}

		[TestMethod]
		public void Solving_should_throw_if_the_solution_is_more_than_nine()
		{
			// Arrange
			Grid grid = new Grid();
			Cell cell = grid.Cells[0, 0];

			// Act
			Action act = () =>
			{
				cell.Solve(10);
			};

			// Assert
			act.Should().Throw<ArgumentOutOfRangeException>();
		}

		[DataTestMethod]
		[DataRow(1)]
		[DataRow(2)]
		[DataRow(3)]
		[DataRow(4)]
		[DataRow(5)]
		[DataRow(6)]
		[DataRow(7)]
		[DataRow(8)]
		[DataRow(9)]
		public void Solving_should_allow_all_values_between_one_and_nine(int solution)
		{
			// Arrange
			Grid grid = new Grid();
			Cell cell = grid.Cells[0, 0];

			// Act
			Action act = () =>
			{
				cell.Solve(solution);
			};

			// Assert
			act.Should().NotThrow();
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

		[TestMethod]
		public void Solving_should_throw_if_the_solution_is_not_a_pencil_mark()
		{
			// Arrange
			Grid grid = new Grid();
			Cell cell = grid.Cells[0, 0];

			// Act
			cell.RemovePencilMark(1);

			Action act = () =>
			{
				cell.Solve(1);
			};

			// Assert
			act.Should().Throw<InvalidSolutionException>();
		}

		[TestMethod]
		public void Solving_should_not_throw_if_the_solution_is_a_pencil_mark()
		{
			// Arrange
			Grid grid = new Grid();
			Cell cell = grid.Cells[0, 0];

			// Act
			Action act = () =>
			{
				cell.Solve(5);
			};

			// Assert
			cell.PencilMarks.Should().Contain(5);
			act.Should().NotThrow();
		}		

		[TestMethod]
		public void Removing_a_pencil_mark_should_remove_it_from_the_list_of_pencil_marks()
		{
			// Arrange
			Grid grid = new Grid();
			Cell cell = grid.Cells[0, 0];

			// Act
			cell.RemovePencilMark(5);

			// Assert
			cell.PencilMarks.Should().NotContain(5);
		}

		[TestMethod]
		public void Removing_an_already_removed_pencil_mark_should_have_no_effect_on_the_list_of_pencil_marks()
		{
			// Arrange
			Grid grid = new Grid();
			Cell cell = grid.Cells[0, 0];

			// Act
			cell.RemovePencilMark(5);
			cell.RemovePencilMark(5);

			// Assert
			cell.PencilMarks.Count.Should().Be(8);
		}

		[TestMethod]
		public void Removing_a_pencil_mark_should_throw_if_the_specified_value_is_less_than_one()
		{
			// Arrange
			Grid grid = new Grid();
			Cell cell = grid.Cells[0, 0];

			// Act
			Action act = () =>
			{
				cell.RemovePencilMark(0);
			};

			// Assert
			act.Should().Throw<ArgumentOutOfRangeException>();
		}

		[TestMethod]
		public void Removing_a_pencil_mark_should_throw_if_the_specified_value_is_more_than_nine()
		{
			// Arrange
			Grid grid = new Grid();
			Cell cell = grid.Cells[0, 0];

			// Act
			Action act = () =>
			{
				cell.RemovePencilMark(10);
			};

			// Assert
			act.Should().Throw<ArgumentOutOfRangeException>();
		}

		[DataTestMethod]
		[DataRow(1)]
		[DataRow(2)]
		[DataRow(3)]
		[DataRow(4)]
		[DataRow(5)]
		[DataRow(6)]
		[DataRow(7)]
		[DataRow(8)]
		[DataRow(9)]
		public void Removing_a_pencil_mark_between_one_and_nine_should_not_throw(int pencilMark)
		{
			// Arrange
			Grid grid = new Grid();
			Cell cell = grid.Cells[0, 0];

			// Act
			Action act = () =>
			{
				cell.RemovePencilMark(pencilMark);
			};

			// Assert
			act.Should().NotThrow();
		}		

		[TestMethod]
		public void Removing_all_but_one_pencil_mark_should_solve_the_cell()
		{
			// Arrange
			Grid grid = new Grid();
			Cell cell = grid.Cells[0, 0];

			// Act
			cell.RemovePencilMark(1);
			cell.RemovePencilMark(2);
			cell.RemovePencilMark(3);
			cell.RemovePencilMark(4);
			cell.RemovePencilMark(5);
			cell.RemovePencilMark(6);
			cell.RemovePencilMark(7);
			cell.RemovePencilMark(8);

			// Assert
			cell.IsSolved().Should().BeTrue();
			cell.Solution.Should().Be(9);
		}

		[TestMethod]
		public void Removing_a_pencil_mark_on_an_already_solved_cell_should_throw()
		{
			// Arrange
			Grid grid = new Grid();
			Cell cell = grid.Cells[0, 0];

			// Act
			cell.Solve(7);

			Action act = () =>
			{
				cell.RemovePencilMark(7);
			};

			// Assert
			act.Should().Throw<AlreadySolvedException>();
		}

		[TestMethod]
		public void A_solved_cell_that_has_been_emptied_should_no_longer_be_classed_as_solved()
		{
			// Arrange
			Grid grid = new Grid();
			Cell cell = grid.Cells[0, 0];
			cell.Solve(1);

			// Act			
			cell.Empty();

			// Assert
			cell.IsSolved().Should().BeFalse();
		}

		[TestMethod]
		public void A_solved_cell_that_has_been_emptied_should_have_nine_pencil_marks()
		{
			// Arrange
			Grid grid = new Grid();
			Cell cell = grid.Cells[0, 0];
			cell.Solve(1);

			// Act			
			cell.Empty();

			// Assert
			cell.PencilMarks.Count.Should().Be(9);
		}
	}
}

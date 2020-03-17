using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Showdoku.Setup;
using System;

namespace Showdoku.SolvingTechniques
{
	[TestClass]
	public class CrosshatchingTechniqueTests
	{
		[TestMethod]
		public void Technique_should_throw_if_passed_null_grid()
		{
			// Arrange
			CrosshatchingTechnique cut = new CrosshatchingTechnique();

			// Act
			Action act = () =>
			{
				cut.Apply(null);
			};

			// Assert
			act.Should().Throw<ArgumentNullException>();
		}

		[TestMethod]
		public void The_solution_of_a_cell_should_not_be_a_pencil_mark_elsewhere_in_the_same_block()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();
			grid.Cells[0, 0].Solve(8);
			
			CrosshatchingTechnique cut = new CrosshatchingTechnique();

			// Act
			cut.Apply(grid);

			// Assert
			grid.Cells[1, 0].PencilMarks.Should().NotContain(8);
			grid.Cells[2, 0].PencilMarks.Should().NotContain(8);
			grid.Cells[0, 1].PencilMarks.Should().NotContain(8);
			grid.Cells[1, 1].PencilMarks.Should().NotContain(8);
			grid.Cells[2, 1].PencilMarks.Should().NotContain(8);
			grid.Cells[0, 2].PencilMarks.Should().NotContain(8);
			grid.Cells[1, 2].PencilMarks.Should().NotContain(8);
			grid.Cells[2, 2].PencilMarks.Should().NotContain(8);
		}

		[TestMethod]
		public void The_solution_of_a_cell_should_not_be_a_pencil_mark_elsewhere_in_the_same_row()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();
			grid.Cells[0, 0].Solve(8);

			CrosshatchingTechnique cut = new CrosshatchingTechnique();

			// Act
			cut.Apply(grid);

			// Assert
			grid.Cells[1, 0].PencilMarks.Should().NotContain(8);
			grid.Cells[2, 0].PencilMarks.Should().NotContain(8);
			grid.Cells[3, 0].PencilMarks.Should().NotContain(8);
			grid.Cells[4, 0].PencilMarks.Should().NotContain(8);
			grid.Cells[5, 0].PencilMarks.Should().NotContain(8);
			grid.Cells[6, 0].PencilMarks.Should().NotContain(8);
			grid.Cells[7, 0].PencilMarks.Should().NotContain(8);
			grid.Cells[8, 0].PencilMarks.Should().NotContain(8);
		}

		[TestMethod]
		public void The_solution_of_a_cell_should_not_be_a_pencil_mark_elsewhere_in_the_same_column()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();
			grid.Cells[0, 0].Solve(8);

			CrosshatchingTechnique cut = new CrosshatchingTechnique();

			// Act
			cut.Apply(grid);

			// Assert
			grid.Cells[0, 1].PencilMarks.Should().NotContain(8);
			grid.Cells[0, 2].PencilMarks.Should().NotContain(8);
			grid.Cells[0, 3].PencilMarks.Should().NotContain(8);
			grid.Cells[0, 4].PencilMarks.Should().NotContain(8);
			grid.Cells[0, 5].PencilMarks.Should().NotContain(8);
			grid.Cells[0, 6].PencilMarks.Should().NotContain(8);
			grid.Cells[0, 7].PencilMarks.Should().NotContain(8);
			grid.Cells[0, 8].PencilMarks.Should().NotContain(8);
		}

		[TestMethod]
		public void A_cell_where_all_but_one_number_appears_elsewhere_in_the_same_block_row_or_column_should_be_solved()
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
						
			CrosshatchingTechnique cut = new CrosshatchingTechnique();

			// Act
			cut.Apply(grid);

			// Assert
			grid.Cells[5, 5].IsSolved().Should().BeTrue();
			grid.Cells[5, 5].Solution.Value.Should().Be(5);
		}
	}
}

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
		public void If_a_cell_has_only_one_pencil_mark_it_should_be_solved()
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

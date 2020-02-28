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
	}
}

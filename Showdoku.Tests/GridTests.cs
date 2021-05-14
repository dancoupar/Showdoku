using FluentAssertions;
using Showdoku.Setup;
using Xunit;

namespace Showdoku
{
	public class GridTests
	{
		[Fact]
		public void A_grid_should_have_two_dimensions()
		{
			// Arrange
			// Act
			Grid grid = new Grid();

			// Assert
			grid.Cells.Rank.Should().Be(2);
		}

		[Fact]
		public void A_grid_should_contain_nine_by_nine_cells()
		{
			// Arrange			
			// Act
			Grid grid = new Grid();

			// Assert
			grid.Cells.GetLength(0).Should().Be(9);
			grid.Cells.GetLength(1).Should().Be(9);
		}

		[Fact]
		public void A_grid_should_contain_three_by_three_blocks()
		{
			// Arrange
			// Act
			Grid grid = new Grid();

			// Assert
			grid.Blocks.GetLength(0).Should().Be(3);
			grid.Blocks.GetLength(1).Should().Be(3);
		}

		[Fact]
		public void A_grid_should_contain_nine_rows()
		{
			// Arrange
			// Act
			Grid grid = new Grid();

			// Assert
			grid.Rows.Length.Should().Be(9);
		}

		[Fact]
		public void A_grid_should_contain_nine_columns()
		{
			// Arrange			
			// Act
			Grid grid = new Grid();

			// Assert
			grid.Columns.Length.Should().Be(9);
		}

		[Fact]
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

		[Fact]
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

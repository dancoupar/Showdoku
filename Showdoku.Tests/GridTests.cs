using FluentAssertions;
using Showdoku.Setup;
using Xunit;

namespace Showdoku
{
	public class GridTests
	{
		[Fact]
		public void A_grid_has_two_dimensions()
		{
			// Arrange
			// Act
			var grid = new Grid();

			// Assert
			grid.Cells.Rank.Should().Be(2);
		}

		[Fact]
		public void A_grid_contains_nine_by_nine_cells()
		{
			// Arrange
			// Act
			var grid = new Grid();

			// Assert
			grid.Cells.GetLength(0).Should().Be(9);
			grid.Cells.GetLength(1).Should().Be(9);
		}

		[Fact]
		public void A_grid_contains_three_by_three_blocks()
		{
			// Arrange
			// Act
			var grid = new Grid();

			// Assert
			grid.Blocks.GetLength(0).Should().Be(3);
			grid.Blocks.GetLength(1).Should().Be(3);
		}

		[Fact]
		public void A_grid_contains_nine_rows()
		{
			// Arrange
			// Act
			var grid = new Grid();

			// Assert
			grid.Rows.Length.Should().Be(9);
		}

		[Fact]
		public void A_grid_contains_nine_columns()
		{
			// Arrange			
			// Act
			var grid = new Grid();

			// Assert
			grid.Columns.Length.Should().Be(9);
		}

		[Fact]
		public void A_grid_containing_only_solved_cells_is_solved()
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
		public void A_grid_containing_any_unsolved_cells_is_unsolved()
		{
			// Arrange
			Grid grid = new GridBuilder().WithSolvedGrid();

			// Act
			grid.Cells[0, 0].Empty();

			// Assert
			grid.IsSolved().Should().BeFalse();
		}

		[Theory]
		[InlineData(0)]
		[InlineData(1)]
		[InlineData(2)]
		[InlineData(3)]
		[InlineData(4)]
		[InlineData(5)]
		[InlineData(6)]
		[InlineData(7)]
		[InlineData(8)]
		public void A_cells_encompassing_block_can_be_correctly_determined(int index)
		{
			// Arrange
			var grid = new Grid();
			Cell cell = grid.Cells[index, index];

			// Act
			Block block = grid.GetBlockContainingCell(cell);

			// Assert
			block.Should().Equal(grid.Blocks[index / 3, index / 3]);
		}

		[Theory]
		[InlineData(0)]
		[InlineData(1)]
		[InlineData(2)]
		[InlineData(3)]
		[InlineData(4)]
		[InlineData(5)]
		[InlineData(6)]
		[InlineData(7)]
		[InlineData(8)]
		public void A_cells_encompassing_row_can_be_correctly_determined(int index)
		{
			// Arrange
			var grid = new Grid();
			Cell cell = grid.Cells[index, index];

			// Act
			Row row = grid.GetRowContainingCell(cell);

			// Assert
			row.Should().Equal(grid.Rows[index]);
		}

		[Theory]
		[InlineData(0)]
		[InlineData(1)]
		[InlineData(2)]
		[InlineData(3)]
		[InlineData(4)]
		[InlineData(5)]
		[InlineData(6)]
		[InlineData(7)]
		[InlineData(8)]
		public void A_cells_encompassing_column_can_be_correctly_determined(int index)
		{
			// Arrange
			var grid = new Grid();
			Cell cell = grid.Cells[index, index];

			// Act
			Column column = grid.GetColumnContainingCell(cell);

			// Assert
			column.Should().Equal(grid.Columns[index]);
		}
	}
}

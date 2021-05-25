using FluentAssertions;
using Showdoku.Exceptions;
using Showdoku.Setup;
using System;
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

		[Fact]
		public void Retrieving_x_index_of_contained_cell_throws_if_no_cell_is_provided()
		{
			// Arrange
			var grid = new Grid();

			// Act
			Action act = () =>
			{
				grid.XIndexOf((Cell)null);
			};

			// Assert
			act.Should().Throw<ArgumentNullException>();
		}

		[Fact]
		public void Retrieving_y_index_of_contained_cell_throws_if_no_cell_is_provided()
		{
			// Arrange
			var grid = new Grid();

			// Act
			Action act = () =>
			{
				grid.YIndexOf((Cell)null);
			};

			// Assert
			act.Should().Throw<ArgumentNullException>();
		}

		[Fact]
		public void Retrieving_x_index_of_contained_cell_returns_negative_one_if_cell_is_not_contained_in_grid()
		{
			// Arrange
			var grid = new Grid();

			// Act
			int result = grid.XIndexOf(new Cell(grid));

			// Assert
			result.Should().Be(-1);
		}

		[Fact]
		public void Retrieving_y_index_of_contained_cell_returns_negative_one_if_cell_is_not_contained_in_grid()
		{
			// Arrange
			var grid = new Grid();

			// Act
			int result = grid.YIndexOf(new Cell(grid));

			// Assert
			result.Should().Be(-1);
		}

		[Fact]
		public void Correct_x_index_of_contained_cell_is_returned()
		{
			// Arrange
			var grid = new Grid();

			// Act
			int result = grid.XIndexOf(grid.Cells[3, 4]);

			// Assert
			result.Should().Be(3);
		}

		[Fact]
		public void Correct_y_index_of_contained_cell_is_returned()
		{
			// Arrange
			var grid = new Grid();

			// Act
			int result = grid.YIndexOf(grid.Cells[7, 8]);

			// Assert
			result.Should().Be(8);
		}

		[Fact]
		public void Retrieving_x_index_of_contained_block_throws_if_no_block_is_provided()
		{
			// Arrange
			var grid = new Grid();

			// Act
			Action act = () =>
			{
				grid.XIndexOf((Block)null);
			};

			// Assert
			act.Should().Throw<ArgumentNullException>();
		}

		[Fact]
		public void Retrieving_y_index_of_contained_block_throws_if_no_block_is_provided()
		{
			// Arrange
			var grid = new Grid();

			// Act
			Action act = () =>
			{
				grid.YIndexOf((Block)null);
			};

			// Assert
			act.Should().Throw<ArgumentNullException>();
		}

		[Fact]
		public void Retrieving_x_index_of_contained_block_returns_negative_one_if_block_is_not_contained_in_grid()
		{
			// Arrange
			var grid = new Grid();
			var blockCells = new Cell[3, 3];

			for (int y = 0; y < 3; y++)
			{
				for (int x = 0; x < 3; x++)
				{
					blockCells[x, y] = new Cell(grid);
				}
			}

			// Act
			int result = grid.XIndexOf(new Block(blockCells));

			// Assert
			result.Should().Be(-1);
		}

		[Fact]
		public void Retrieving_y_index_of_contained_block_returns_negative_one_if_block_is_not_contained_in_grid()
		{
			// Arrange
			var grid = new Grid();
			var blockCells = new Cell[3, 3];

			for (int y = 0; y < 3; y++)
			{
				for (int x = 0; x < 3; x++)
				{
					blockCells[x, y] = new Cell(grid);
				}
			}

			// Act
			int result = grid.YIndexOf(new Block(blockCells));

			// Assert
			result.Should().Be(-1);
		}

		[Fact]
		public void Correct_x_index_of_contained_block_is_returned()
		{
			// Arrange
			var grid = new Grid();

			// Act
			int result = grid.XIndexOf(grid.Blocks[1, 2]);

			// Assert
			result.Should().Be(1);
		}

		[Fact]
		public void Correct_y_index_of_contained_block_is_returned()
		{
			// Arrange
			var grid = new Grid();

			// Act
			int result = grid.YIndexOf(grid.Blocks[1, 2]);

			// Assert
			result.Should().Be(2);
		}		

		[Fact]
		public void Retrieving_index_of_contained_row_throws_if_no_row_is_provided()
		{
			// Arrange
			var grid = new Grid();

			// Act
			Action act = () =>
			{
				grid.IndexOf((Row)null);
			};

			// Assert
			act.Should().Throw<ArgumentNullException>();
		}

		[Fact]
		public void Retrieving_index_of_contained_row_returns_negative_one_if_row_is_not_contained_in_grid()
		{
			// Arrange
			var grid = new Grid();
			var rowCells = new Cell[9];

			for (int x = 0; x < 9; x++)
			{				
				rowCells[x] = new Cell(grid);
			}

			// Act
			int result = grid.IndexOf(new Row(rowCells));

			// Assert
			result.Should().Be(-1);
		}
		
		[Fact]
		public void Correct_index_of_contained_row_is_returned()
		{
			// Arrange
			var grid = new Grid();

			// Act
			int result = grid.IndexOf(grid.Rows[3]);

			// Assert
			result.Should().Be(3);
		}

		[Fact]
		public void Retrieving_index_of_contained_column_throws_if_no_row_is_provided()
		{
			// Arrange
			var grid = new Grid();

			// Act
			Action act = () =>
			{
				grid.IndexOf((Column)null);
			};

			// Assert
			act.Should().Throw<ArgumentNullException>();
		}

		[Fact]
		public void Retrieving_index_of_contained_column_returns_negative_one_if_column_is_not_contained_in_grid()
		{
			// Arrange
			var grid = new Grid();
			var columnCells = new Cell[9];

			for (int x = 0; x < 9; x++)
			{
				columnCells[x] = new Cell(grid);
			}

			// Act
			int result = grid.IndexOf(new Column(columnCells));

			// Assert
			result.Should().Be(-1);
		}

		[Fact]
		public void Correct_index_of_contained_column_is_returned()
		{
			// Arrange
			var grid = new Grid();

			// Act
			int result = grid.IndexOf(grid.Columns[3]);

			// Assert
			result.Should().Be(3);
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

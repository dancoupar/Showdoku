using FluentAssertions;
using Showdoku.Exceptions;
using System;
using Xunit;

namespace Showdoku
{
	public class BlockTests
	{
		[Fact]
		public void Creating_a_block_throws_if_no_cells_are_provided()
		{
			// Arrange
			Block block;

			// Act
			Action act = () =>
			{
				block = new Block(null);
			};

			// Assert
			act.Should().Throw<ArgumentNullException>();
		}

		[Fact]
		public void Creating_a_block_throws_if_fewer_than_three_rows_of_cells_are_provided()
		{
			// Arrange
			Block block;
			Grid grid = new Grid();
			Cell[,] cells = new Cell[3, 2];

			// Act
			Action act = () =>
			{
				block = new Block(cells);
			};

			// Assert
			act.Should().Throw<ArgumentException>();
		}

		[Fact]
		public void Creating_a_block_throws_if_more_than_three_rows_of_cells_are_provided()
		{
			// Arrange
			Block block;
			Grid grid = new Grid();
			Cell[,] cells = new Cell[3, 4];

			// Act
			Action act = () =>
			{
				block = new Block(cells);
			};

			// Assert
			act.Should().Throw<ArgumentException>();
		}

		[Fact]
		public void Creating_a_row_throws_if_fewer_than_three_columns_of_cells_are_provided()
		{
			// Arrange
			Block block;
			Grid grid = new Grid();
			Cell[,] cells = new Cell[2, 3];

			// Act
			Action act = () =>
			{
				block = new Block(cells);
			};

			// Assert
			act.Should().Throw<ArgumentException>();
		}

		[Fact]
		public void Creating_a_row_throws_if_more_than_three_columns_of_cells_are_provided()
		{
			// Arrange
			Block block;
			Grid grid = new Grid();
			Cell[,] cells = new Cell[4, 3];

			// Act
			Action act = () =>
			{
				block = new Block(cells);
			};

			// Assert
			act.Should().Throw<ArgumentException>();
		}

		[Fact]
		public void Creating_a_block_throws_if_any_provided_cells_are_missing()
		{
			// Arrange
			Block block;
			Grid grid = new Grid();
			Cell[,] cells = new Cell[3, 3];
			cells[0, 0] = new Cell(grid);
			cells[1, 0] = new Cell(grid);
			cells[2, 0] = new Cell(grid);
			cells[0, 1] = new Cell(grid);
			cells[1, 1] = new Cell(grid);
			cells[2, 1] = new Cell(grid);
			cells[0, 2] = new Cell(grid);
			cells[1, 2] = new Cell(grid);
			cells[2, 2] = null;

			// Act
			Action act = () =>
			{
				block = new Block(cells);
			};

			// Assert
			act.Should().Throw<ArgumentException>();
		}

		[Fact]
		public void All_blocks_have_two_dimensions()
		{
			// Arrange
			// Act
			Grid grid = new Grid();

			// Assert
			foreach (Block block in grid.Blocks)
			{
				block.Cells.Rank.Should().Be(2);
			}
		}

		[Fact]
		public void All_blocks_contain_three_by_three_cells()
		{
			// Arrange
			// Act
			Grid grid = new Grid();

			// Assert
			foreach (Block block in grid.Blocks)
			{
				block.Cells.GetLength(0).Should().Be(3);
				block.Cells.GetLength(1).Should().Be(3);
			}
		}

		[Fact]
		public void All_blocks_contain_expected_cells()
		{
			// Arrange
			// Act
			Grid grid = new Grid();

			// Assert
			grid.Blocks[0, 0].Cells[0, 0].Should().Be(grid.Cells[0, 0]);
			grid.Blocks[0, 0].Cells[1, 0].Should().Be(grid.Cells[1, 0]);
			grid.Blocks[0, 0].Cells[2, 0].Should().Be(grid.Cells[2, 0]);
			grid.Blocks[0, 0].Cells[0, 1].Should().Be(grid.Cells[0, 1]);
			grid.Blocks[0, 0].Cells[1, 1].Should().Be(grid.Cells[1, 1]);
			grid.Blocks[0, 0].Cells[2, 1].Should().Be(grid.Cells[2, 1]);
			grid.Blocks[0, 0].Cells[0, 2].Should().Be(grid.Cells[0, 2]);
			grid.Blocks[0, 0].Cells[1, 2].Should().Be(grid.Cells[1, 2]);
			grid.Blocks[0, 0].Cells[2, 2].Should().Be(grid.Cells[2, 2]);

			grid.Blocks[1, 0].Cells[0, 0].Should().Be(grid.Cells[3, 0]);
			grid.Blocks[1, 0].Cells[1, 0].Should().Be(grid.Cells[4, 0]);
			grid.Blocks[1, 0].Cells[2, 0].Should().Be(grid.Cells[5, 0]);
			grid.Blocks[1, 0].Cells[0, 1].Should().Be(grid.Cells[3, 1]);
			grid.Blocks[1, 0].Cells[1, 1].Should().Be(grid.Cells[4, 1]);
			grid.Blocks[1, 0].Cells[2, 1].Should().Be(grid.Cells[5, 1]);
			grid.Blocks[1, 0].Cells[0, 2].Should().Be(grid.Cells[3, 2]);
			grid.Blocks[1, 0].Cells[1, 2].Should().Be(grid.Cells[4, 2]);
			grid.Blocks[1, 0].Cells[2, 2].Should().Be(grid.Cells[5, 2]);

			grid.Blocks[2, 0].Cells[0, 0].Should().Be(grid.Cells[6, 0]);
			grid.Blocks[2, 0].Cells[1, 0].Should().Be(grid.Cells[7, 0]);
			grid.Blocks[2, 0].Cells[2, 0].Should().Be(grid.Cells[8, 0]);
			grid.Blocks[2, 0].Cells[0, 1].Should().Be(grid.Cells[6, 1]);
			grid.Blocks[2, 0].Cells[1, 1].Should().Be(grid.Cells[7, 1]);
			grid.Blocks[2, 0].Cells[2, 1].Should().Be(grid.Cells[8, 1]);
			grid.Blocks[2, 0].Cells[0, 2].Should().Be(grid.Cells[6, 2]);
			grid.Blocks[2, 0].Cells[1, 2].Should().Be(grid.Cells[7, 2]);
			grid.Blocks[2, 0].Cells[2, 2].Should().Be(grid.Cells[8, 2]);

			grid.Blocks[0, 1].Cells[0, 0].Should().Be(grid.Cells[0, 3]);
			grid.Blocks[0, 1].Cells[1, 0].Should().Be(grid.Cells[1, 3]);
			grid.Blocks[0, 1].Cells[2, 0].Should().Be(grid.Cells[2, 3]);
			grid.Blocks[0, 1].Cells[0, 1].Should().Be(grid.Cells[0, 4]);
			grid.Blocks[0, 1].Cells[1, 1].Should().Be(grid.Cells[1, 4]);
			grid.Blocks[0, 1].Cells[2, 1].Should().Be(grid.Cells[2, 4]);
			grid.Blocks[0, 1].Cells[0, 2].Should().Be(grid.Cells[0, 5]);
			grid.Blocks[0, 1].Cells[1, 2].Should().Be(grid.Cells[1, 5]);
			grid.Blocks[0, 1].Cells[2, 2].Should().Be(grid.Cells[2, 5]);

			grid.Blocks[1, 1].Cells[0, 0].Should().Be(grid.Cells[3, 3]);
			grid.Blocks[1, 1].Cells[1, 0].Should().Be(grid.Cells[4, 3]);
			grid.Blocks[1, 1].Cells[2, 0].Should().Be(grid.Cells[5, 3]);
			grid.Blocks[1, 1].Cells[0, 1].Should().Be(grid.Cells[3, 4]);
			grid.Blocks[1, 1].Cells[1, 1].Should().Be(grid.Cells[4, 4]);
			grid.Blocks[1, 1].Cells[2, 1].Should().Be(grid.Cells[5, 4]);
			grid.Blocks[1, 1].Cells[0, 2].Should().Be(grid.Cells[3, 5]);
			grid.Blocks[1, 1].Cells[1, 2].Should().Be(grid.Cells[4, 5]);
			grid.Blocks[1, 1].Cells[2, 2].Should().Be(grid.Cells[5, 5]);

			grid.Blocks[2, 1].Cells[0, 0].Should().Be(grid.Cells[6, 3]);
			grid.Blocks[2, 1].Cells[1, 0].Should().Be(grid.Cells[7, 3]);
			grid.Blocks[2, 1].Cells[2, 0].Should().Be(grid.Cells[8, 3]);
			grid.Blocks[2, 1].Cells[0, 1].Should().Be(grid.Cells[6, 4]);
			grid.Blocks[2, 1].Cells[1, 1].Should().Be(grid.Cells[7, 4]);
			grid.Blocks[2, 1].Cells[2, 1].Should().Be(grid.Cells[8, 4]);
			grid.Blocks[2, 1].Cells[0, 2].Should().Be(grid.Cells[6, 5]);
			grid.Blocks[2, 1].Cells[1, 2].Should().Be(grid.Cells[7, 5]);
			grid.Blocks[2, 1].Cells[2, 2].Should().Be(grid.Cells[8, 5]);

			grid.Blocks[0, 2].Cells[0, 0].Should().Be(grid.Cells[0, 6]);
			grid.Blocks[0, 2].Cells[1, 0].Should().Be(grid.Cells[1, 6]);
			grid.Blocks[0, 2].Cells[2, 0].Should().Be(grid.Cells[2, 6]);
			grid.Blocks[0, 2].Cells[0, 1].Should().Be(grid.Cells[0, 7]);
			grid.Blocks[0, 2].Cells[1, 1].Should().Be(grid.Cells[1, 7]);
			grid.Blocks[0, 2].Cells[2, 1].Should().Be(grid.Cells[2, 7]);
			grid.Blocks[0, 2].Cells[0, 2].Should().Be(grid.Cells[0, 8]);
			grid.Blocks[0, 2].Cells[1, 2].Should().Be(grid.Cells[1, 8]);
			grid.Blocks[0, 2].Cells[2, 2].Should().Be(grid.Cells[2, 8]);

			grid.Blocks[1, 2].Cells[0, 0].Should().Be(grid.Cells[3, 6]);
			grid.Blocks[1, 2].Cells[1, 0].Should().Be(grid.Cells[4, 6]);
			grid.Blocks[1, 2].Cells[2, 0].Should().Be(grid.Cells[5, 6]);
			grid.Blocks[1, 2].Cells[0, 1].Should().Be(grid.Cells[3, 7]);
			grid.Blocks[1, 2].Cells[1, 1].Should().Be(grid.Cells[4, 7]);
			grid.Blocks[1, 2].Cells[2, 1].Should().Be(grid.Cells[5, 7]);
			grid.Blocks[1, 2].Cells[0, 2].Should().Be(grid.Cells[3, 8]);
			grid.Blocks[1, 2].Cells[1, 2].Should().Be(grid.Cells[4, 8]);
			grid.Blocks[1, 2].Cells[2, 2].Should().Be(grid.Cells[5, 8]);

			grid.Blocks[2, 2].Cells[0, 0].Should().Be(grid.Cells[6, 6]);
			grid.Blocks[2, 2].Cells[1, 0].Should().Be(grid.Cells[7, 6]);
			grid.Blocks[2, 2].Cells[2, 0].Should().Be(grid.Cells[8, 6]);
			grid.Blocks[2, 2].Cells[0, 1].Should().Be(grid.Cells[6, 7]);
			grid.Blocks[2, 2].Cells[1, 1].Should().Be(grid.Cells[7, 7]);
			grid.Blocks[2, 2].Cells[2, 1].Should().Be(grid.Cells[8, 7]);
			grid.Blocks[2, 2].Cells[0, 2].Should().Be(grid.Cells[6, 8]);
			grid.Blocks[2, 2].Cells[1, 2].Should().Be(grid.Cells[7, 8]);
			grid.Blocks[2, 2].Cells[2, 2].Should().Be(grid.Cells[8, 8]);
		}

		[Fact]
		public void A_block_containing_only_solved_cells_is_solved()
		{
			// Arrange
			Grid grid = new Grid();

			// Act
			grid.Cells[0, 0].Solve(1);
			grid.Cells[1, 0].Solve(2);
			grid.Cells[2, 0].Solve(3);
			grid.Cells[0, 1].Solve(4);
			grid.Cells[1, 1].Solve(5);
			grid.Cells[2, 1].Solve(6);
			grid.Cells[0, 2].Solve(7);
			grid.Cells[1, 2].Solve(8);
			grid.Cells[2, 2].Solve(9);

			// Assert
			grid.Blocks[0, 0].IsSolved().Should().BeTrue();
		}

		[Fact]
		public void A_block_containing_any_unsolved_cells_is_unsolved()
		{
			// Arrange
			Grid grid = new Grid();

			// Act
			grid.Cells[0, 0].Solve(1);
			grid.Cells[1, 0].Solve(2);
			grid.Cells[2, 0].Solve(3);
			grid.Cells[0, 1].Solve(4);
			grid.Cells[1, 1].Solve(5);
			grid.Cells[2, 1].Solve(6);
			grid.Cells[0, 2].Solve(7);
			grid.Cells[1, 2].Solve(8);

			// Assert
			grid.Blocks[0, 0].IsSolved().Should().BeFalse();
		}

		[Fact]
		public void Retrieving_x_index_of_contained_cell_throws_if_no_cell_is_provided()
		{
			// Arrange
			Grid grid = new Grid();

			// Act
			Action act = () =>
			{
				grid.Blocks[0, 0].XIndexOf(null);
			};

			// Assert
			act.Should().Throw<ArgumentNullException>();
		}

		[Fact]
		public void Retrieving_y_index_of_contained_cell_throws_if_no_cell_is_provided()
		{
			// Arrange
			Grid grid = new Grid();

			// Act
			Action act = () =>
			{
				grid.Blocks[0, 0].YIndexOf(null);
			};

			// Assert
			act.Should().Throw<ArgumentNullException>();
		}

		[Fact]
		public void Retrieving_x_index_of_contained_cell_throws_if_cell_is_not_contained_in_block()
		{
			// Arrange
			Grid grid = new Grid();

			// Act
			Action act = () =>
			{
				grid.Blocks[0, 0].XIndexOf(grid.Cells[4, 4]);
			};

			// Assert
			act.Should().Throw<CellNotFoundException>();
		}

		[Fact]
		public void Retrieving_y_index_of_contained_cell_throws_if_cell_is_not_contained_in_block()
		{
			// Arrange
			Grid grid = new Grid();

			// Act
			Action act = () =>
			{
				grid.Blocks[0, 0].YIndexOf(grid.Cells[4, 4]);
			};

			// Assert
			act.Should().Throw<CellNotFoundException>();
		}

		[Fact]
		public void Correct_x_index_of_contained_cell_is_returned()
		{
			// Arrange
			Grid grid = new Grid();

			// Act
			int result = grid.Blocks[1, 1].XIndexOf(grid.Cells[3, 4]);

			// Assert
			result.Should().Be(0);
		}

		[Fact]
		public void Correct_y_index_of_contained_cell_is_returned()
		{
			// Arrange
			Grid grid = new Grid();

			// Act
			int result = grid.Blocks[2, 2].YIndexOf(grid.Cells[7, 8]);

			// Assert
			result.Should().Be(2);
		}
	}
}

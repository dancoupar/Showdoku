using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Showdoku
{
	[TestClass]
	public class RowTests
	{
		[TestMethod]
		public void All_rows_should_contain_9_cells()
		{
			// Arrange
			// Act
			Grid grid = new Grid();

			// Assert
			foreach (Row row in grid.Rows)
			{
				row.Cells.Length.Should().Be(9);
			}
		}

		[TestMethod]
		public void All_rows_should_contain_expected_cells()
		{
			// Arrange
			// Act
			Grid grid = new Grid();

			// Assert
			grid.Rows[0].Cells[0].Should().Be(grid.Cells[0, 0]);
			grid.Rows[0].Cells[1].Should().Be(grid.Cells[1, 0]);
			grid.Rows[0].Cells[2].Should().Be(grid.Cells[2, 0]);
			grid.Rows[0].Cells[3].Should().Be(grid.Cells[3, 0]);
			grid.Rows[0].Cells[4].Should().Be(grid.Cells[4, 0]);
			grid.Rows[0].Cells[5].Should().Be(grid.Cells[5, 0]);
			grid.Rows[0].Cells[6].Should().Be(grid.Cells[6, 0]);
			grid.Rows[0].Cells[7].Should().Be(grid.Cells[7, 0]);
			grid.Rows[0].Cells[8].Should().Be(grid.Cells[8, 0]);

			grid.Rows[1].Cells[0].Should().Be(grid.Cells[0, 1]);
			grid.Rows[1].Cells[1].Should().Be(grid.Cells[1, 1]);
			grid.Rows[1].Cells[2].Should().Be(grid.Cells[2, 1]);
			grid.Rows[1].Cells[3].Should().Be(grid.Cells[3, 1]);
			grid.Rows[1].Cells[4].Should().Be(grid.Cells[4, 1]);
			grid.Rows[1].Cells[5].Should().Be(grid.Cells[5, 1]);
			grid.Rows[1].Cells[6].Should().Be(grid.Cells[6, 1]);
			grid.Rows[1].Cells[7].Should().Be(grid.Cells[7, 1]);
			grid.Rows[1].Cells[8].Should().Be(grid.Cells[8, 1]);

			grid.Rows[2].Cells[0].Should().Be(grid.Cells[0, 2]);
			grid.Rows[2].Cells[1].Should().Be(grid.Cells[1, 2]);
			grid.Rows[2].Cells[2].Should().Be(grid.Cells[2, 2]);
			grid.Rows[2].Cells[3].Should().Be(grid.Cells[3, 2]);
			grid.Rows[2].Cells[4].Should().Be(grid.Cells[4, 2]);
			grid.Rows[2].Cells[5].Should().Be(grid.Cells[5, 2]);
			grid.Rows[2].Cells[6].Should().Be(grid.Cells[6, 2]);
			grid.Rows[2].Cells[7].Should().Be(grid.Cells[7, 2]);
			grid.Rows[2].Cells[8].Should().Be(grid.Cells[8, 2]);

			grid.Rows[3].Cells[0].Should().Be(grid.Cells[0, 3]);
			grid.Rows[3].Cells[1].Should().Be(grid.Cells[1, 3]);
			grid.Rows[3].Cells[2].Should().Be(grid.Cells[2, 3]);
			grid.Rows[3].Cells[3].Should().Be(grid.Cells[3, 3]);
			grid.Rows[3].Cells[4].Should().Be(grid.Cells[4, 3]);
			grid.Rows[3].Cells[5].Should().Be(grid.Cells[5, 3]);
			grid.Rows[3].Cells[6].Should().Be(grid.Cells[6, 3]);
			grid.Rows[3].Cells[7].Should().Be(grid.Cells[7, 3]);
			grid.Rows[3].Cells[8].Should().Be(grid.Cells[8, 3]);

			grid.Rows[4].Cells[0].Should().Be(grid.Cells[0, 4]);
			grid.Rows[4].Cells[1].Should().Be(grid.Cells[1, 4]);
			grid.Rows[4].Cells[2].Should().Be(grid.Cells[2, 4]);
			grid.Rows[4].Cells[3].Should().Be(grid.Cells[3, 4]);
			grid.Rows[4].Cells[4].Should().Be(grid.Cells[4, 4]);
			grid.Rows[4].Cells[5].Should().Be(grid.Cells[5, 4]);
			grid.Rows[4].Cells[6].Should().Be(grid.Cells[6, 4]);
			grid.Rows[4].Cells[7].Should().Be(grid.Cells[7, 4]);
			grid.Rows[4].Cells[8].Should().Be(grid.Cells[8, 4]);

			grid.Rows[5].Cells[0].Should().Be(grid.Cells[0, 5]);
			grid.Rows[5].Cells[1].Should().Be(grid.Cells[1, 5]);
			grid.Rows[5].Cells[2].Should().Be(grid.Cells[2, 5]);
			grid.Rows[5].Cells[3].Should().Be(grid.Cells[3, 5]);
			grid.Rows[5].Cells[4].Should().Be(grid.Cells[4, 5]);
			grid.Rows[5].Cells[5].Should().Be(grid.Cells[5, 5]);
			grid.Rows[5].Cells[6].Should().Be(grid.Cells[6, 5]);
			grid.Rows[5].Cells[7].Should().Be(grid.Cells[7, 5]);
			grid.Rows[5].Cells[8].Should().Be(grid.Cells[8, 5]);

			grid.Rows[6].Cells[0].Should().Be(grid.Cells[0, 6]);
			grid.Rows[6].Cells[1].Should().Be(grid.Cells[1, 6]);
			grid.Rows[6].Cells[2].Should().Be(grid.Cells[2, 6]);
			grid.Rows[6].Cells[3].Should().Be(grid.Cells[3, 6]);
			grid.Rows[6].Cells[4].Should().Be(grid.Cells[4, 6]);
			grid.Rows[6].Cells[5].Should().Be(grid.Cells[5, 6]);
			grid.Rows[6].Cells[6].Should().Be(grid.Cells[6, 6]);
			grid.Rows[6].Cells[7].Should().Be(grid.Cells[7, 6]);
			grid.Rows[6].Cells[8].Should().Be(grid.Cells[8, 6]);

			grid.Rows[7].Cells[0].Should().Be(grid.Cells[0, 7]);
			grid.Rows[7].Cells[1].Should().Be(grid.Cells[1, 7]);
			grid.Rows[7].Cells[2].Should().Be(grid.Cells[2, 7]);
			grid.Rows[7].Cells[3].Should().Be(grid.Cells[3, 7]);
			grid.Rows[7].Cells[4].Should().Be(grid.Cells[4, 7]);
			grid.Rows[7].Cells[5].Should().Be(grid.Cells[5, 7]);
			grid.Rows[7].Cells[6].Should().Be(grid.Cells[6, 7]);
			grid.Rows[7].Cells[7].Should().Be(grid.Cells[7, 7]);
			grid.Rows[7].Cells[8].Should().Be(grid.Cells[8, 7]);

			grid.Rows[8].Cells[0].Should().Be(grid.Cells[0, 8]);
			grid.Rows[8].Cells[1].Should().Be(grid.Cells[1, 8]);
			grid.Rows[8].Cells[2].Should().Be(grid.Cells[2, 8]);
			grid.Rows[8].Cells[3].Should().Be(grid.Cells[3, 8]);
			grid.Rows[8].Cells[4].Should().Be(grid.Cells[4, 8]);
			grid.Rows[8].Cells[5].Should().Be(grid.Cells[5, 8]);
			grid.Rows[8].Cells[6].Should().Be(grid.Cells[6, 8]);
			grid.Rows[8].Cells[7].Should().Be(grid.Cells[7, 8]);
			grid.Rows[8].Cells[8].Should().Be(grid.Cells[8, 8]);
		}

		[TestMethod]
		public void A_row_containing_only_solved_cells_should_be_classed_as_solved()
		{
			// Arrange
			Grid grid = new Grid();

			// Act
			grid.Cells[0, 0].Solve(1);
			grid.Cells[1, 0].Solve(2);
			grid.Cells[2, 0].Solve(3);
			grid.Cells[3, 0].Solve(4);
			grid.Cells[4, 0].Solve(5);
			grid.Cells[5, 0].Solve(6);
			grid.Cells[6, 0].Solve(7);
			grid.Cells[7, 0].Solve(8);
			grid.Cells[8, 0].Solve(9);

			// Assert
			grid.Rows[0].IsSolved().Should().BeTrue();
		}

		[TestMethod]
		public void A_row_containing_any_unsolved_cells_should_not_be_classed_as_solved()
		{
			// Arrange
			Grid grid = new Grid();

			// Act
			grid.Cells[0, 0].Solve(1);
			grid.Cells[1, 0].Solve(2);
			grid.Cells[2, 0].Solve(3);
			grid.Cells[3, 0].Solve(4);
			grid.Cells[4, 0].Solve(5);
			grid.Cells[5, 0].Solve(6);
			grid.Cells[6, 0].Solve(7);
			grid.Cells[7, 0].Solve(8);
			
			// Assert
			grid.Rows[0].IsSolved().Should().BeFalse();
		}
	}
}

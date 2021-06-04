using FluentAssertions;
using Xunit;

namespace Showdoku
{
	public class CellCollectionTests
	{
		[Fact]
		public void Solved_cells_are_counted_correctly()
		{
			// Arrange
			var grid = new Grid();

			// Act
			grid.Cells[0, 0].Solve(1);
			grid.Cells[1, 1].Solve(2);
			grid.Cells[2, 2].Solve(3);

			// Assert
			grid.Rows[0].CountSolvedCells().Should().Be(1);
			grid.Columns[0].CountSolvedCells().Should().Be(1);
			grid.Blocks[0, 0].CountSolvedCells().Should().Be(3);
		}

		[Fact]
		public void Pencil_marks_are_counted_correctly()
		{
			// Arrange
			var grid = new Grid();

			// Act
			grid.Cells[0, 0].ErasePencilMark(1);
			grid.Cells[0, 0].ErasePencilMark(2);
			grid.Cells[0, 0].ErasePencilMark(3);

			// Assert
			grid.Rows[0].CountPencilMarks().Should().Be(9 * 9 - 3);
			grid.Columns[0].CountPencilMarks().Should().Be(9 * 9 - 3);
			grid.Blocks[0, 0].CountPencilMarks().Should().Be(9 * 9 - 3);
		}
	}
}

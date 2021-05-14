using FluentAssertions;
using Xunit;

namespace Showdoku
{
	public class CellCollectionTests
	{
		[Fact]
		public void Solved_cells_should_be_counted_correctly()
		{
			// Arrange
			Grid grid = new Grid();

			// Act
			grid.Cells[0, 0].Solve(1);
			grid.Cells[1, 1].Solve(2);
			grid.Cells[2, 2].Solve(3);

			// Assert
			grid.Rows[0].GetSolvedCellCount().Should().Be(1);
			grid.Columns[0].GetSolvedCellCount().Should().Be(1);
			grid.Blocks[0, 0].GetSolvedCellCount().Should().Be(3);
		}

		[Fact]
		public void Pencil_marks_should_be_counted_correctly()
		{
			// Arrange
			Grid grid = new Grid();

			// Act
			grid.Cells[0, 0].RemovePencilMark(1);
			grid.Cells[0, 0].RemovePencilMark(2);
			grid.Cells[0, 0].RemovePencilMark(3);

			// Assert
			grid.Rows[0].GetPencilMarkCount().Should().Be(9 * 9 - 3);
			grid.Columns[0].GetPencilMarkCount().Should().Be(9 * 9 - 3);
			grid.Blocks[0, 0].GetPencilMarkCount().Should().Be(9 * 9 - 3);
		}
	}
}

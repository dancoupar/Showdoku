using FluentAssertions;
using Showdoku.Setup;
using System;
using Xunit;

namespace Showdoku.SolvingTechniques
{
	public class LockedCandidatesPointingTechniqueTests
	{
		[Fact]
		public void Technique_throws_if_no_grid_is_provided()
		{
			// Arrange
			var cut = new LockedCandidatesPointingTechnique();

			// Act
			Action act = () =>
			{
				cut.Apply(null);
			};

			// Assert
			act.Should().Throw<ArgumentNullException>();
		}

		[Fact]
		public void Pencil_marks_for_two_cells_within_a_block_restricted_to_one_row_eliminates_pencil_marks_from_other_cells_outside_the_block_in_the_same_row()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();

			grid.Cells[4, 0].Solve(6);
			grid.Cells[3, 3].Solve(1);
			grid.Cells[5, 3].Solve(2);
			grid.Cells[3, 5].Solve(3);
			grid.Cells[5, 5].Solve(4);

			grid.Cells[4, 3].ErasePencilMark(6);
			grid.Cells[4, 4].ErasePencilMark(6);
			grid.Cells[4, 5].ErasePencilMark(6);

			var cut = new LockedCandidatesPointingTechnique();

			// Act
			cut.Apply(grid);

			// Assert
			grid.Cells[0, 4].PencilMarks.Should().NotContain(6);
			grid.Cells[1, 4].PencilMarks.Should().NotContain(6);
			grid.Cells[2, 4].PencilMarks.Should().NotContain(6);
			grid.Cells[6, 4].PencilMarks.Should().NotContain(6);
			grid.Cells[7, 4].PencilMarks.Should().NotContain(6);
			grid.Cells[8, 4].PencilMarks.Should().NotContain(6);
		}

		[Fact]
		public void Pencil_marks_for_three_cells_within_a_block_restricted_to_one_row_eliminates_pencil_marks_from_other_cells_outside_the_block_in_the_same_row()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();

			grid.Cells[3, 3].Solve(1);
			grid.Cells[4, 3].Solve(2);
			grid.Cells[5, 3].Solve(3);
			grid.Cells[3, 5].Solve(4);
			grid.Cells[4, 5].Solve(5);
			grid.Cells[5, 5].Solve(6);

			grid.Cells[3, 4].ErasePencilMark(1);
			grid.Cells[4, 4].ErasePencilMark(1);
			grid.Cells[5, 4].ErasePencilMark(1);
			grid.Cells[3, 4].ErasePencilMark(2);
			grid.Cells[4, 4].ErasePencilMark(2);
			grid.Cells[5, 4].ErasePencilMark(2);
			grid.Cells[3, 4].ErasePencilMark(3);
			grid.Cells[4, 4].ErasePencilMark(3);
			grid.Cells[5, 4].ErasePencilMark(3);
			grid.Cells[3, 4].ErasePencilMark(4);
			grid.Cells[4, 4].ErasePencilMark(4);
			grid.Cells[5, 4].ErasePencilMark(4);
			grid.Cells[3, 4].ErasePencilMark(5);
			grid.Cells[4, 4].ErasePencilMark(5);
			grid.Cells[5, 4].ErasePencilMark(5);
			grid.Cells[3, 4].ErasePencilMark(6);
			grid.Cells[4, 4].ErasePencilMark(6);
			grid.Cells[5, 4].ErasePencilMark(6);

			LockedCandidatesPointingTechnique cut = new LockedCandidatesPointingTechnique();

			// Act
			cut.Apply(grid);

			// Assert
			grid.Cells[0, 4].PencilMarks.Should().NotContain(7);
			grid.Cells[1, 4].PencilMarks.Should().NotContain(7);
			grid.Cells[2, 4].PencilMarks.Should().NotContain(7);
			grid.Cells[6, 4].PencilMarks.Should().NotContain(7);
			grid.Cells[7, 4].PencilMarks.Should().NotContain(7);
			grid.Cells[8, 4].PencilMarks.Should().NotContain(7);
			grid.Cells[0, 4].PencilMarks.Should().NotContain(8);
			grid.Cells[1, 4].PencilMarks.Should().NotContain(8);
			grid.Cells[2, 4].PencilMarks.Should().NotContain(8);
			grid.Cells[6, 4].PencilMarks.Should().NotContain(8);
			grid.Cells[7, 4].PencilMarks.Should().NotContain(8);
			grid.Cells[8, 4].PencilMarks.Should().NotContain(8);
			grid.Cells[0, 4].PencilMarks.Should().NotContain(9);
			grid.Cells[1, 4].PencilMarks.Should().NotContain(9);
			grid.Cells[2, 4].PencilMarks.Should().NotContain(9);
			grid.Cells[6, 4].PencilMarks.Should().NotContain(9);
			grid.Cells[7, 4].PencilMarks.Should().NotContain(9);
			grid.Cells[8, 4].PencilMarks.Should().NotContain(9);
		}

		[Fact]
		public void Pencil_marks_for_two_cells_within_a_block_restricted_to_one_column_eliminates_pencil_marks_from_other_cells_outside_the_block_in_the_same_column()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();

			grid.Cells[0, 4].Solve(6);
			grid.Cells[3, 3].Solve(1);
			grid.Cells[5, 3].Solve(2);
			grid.Cells[3, 5].Solve(3);
			grid.Cells[5, 5].Solve(4);

			grid.Cells[3, 4].ErasePencilMark(6);
			grid.Cells[4, 4].ErasePencilMark(6);
			grid.Cells[5, 4].ErasePencilMark(6);

			var cut = new LockedCandidatesPointingTechnique();

			// Act
			cut.Apply(grid);

			// Assert
			grid.Cells[4, 0].PencilMarks.Should().NotContain(6);
			grid.Cells[4, 1].PencilMarks.Should().NotContain(6);
			grid.Cells[4, 2].PencilMarks.Should().NotContain(6);
			grid.Cells[4, 6].PencilMarks.Should().NotContain(6);
			grid.Cells[4, 7].PencilMarks.Should().NotContain(6);
			grid.Cells[4, 8].PencilMarks.Should().NotContain(6);
		}
	}
}

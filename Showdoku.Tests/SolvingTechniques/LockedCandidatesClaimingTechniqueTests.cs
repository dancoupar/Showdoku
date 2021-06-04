using FluentAssertions;
using Showdoku.Setup;
using System;
using Xunit;

namespace Showdoku.SolvingTechniques
{
	public class LockedCandidatesClaimingTechniqueTests
	{
		[Fact]
		public void Technique_throws_if_no_grid_is_provided()
		{
			// Arrange
			var cut = new LockedCandidatesClaimingTechnique();

			// Act
			Action act = () =>
			{
				cut.Apply(null);
			};

			// Assert
			act.Should().Throw<ArgumentNullException>();
		}

		[Fact]
		public void Pencil_marks_for_three_cells_within_a_row_restricted_to_one_block_eliminates_pencil_marks_from_other_cells_within_the_same_block()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();

			grid.Cells[0, 4].ErasePencilMark(1);
			grid.Cells[1, 4].ErasePencilMark(1);
			grid.Cells[2, 4].ErasePencilMark(1);

			grid.Cells[6, 4].ErasePencilMark(1);
			grid.Cells[7, 4].ErasePencilMark(1);
			grid.Cells[8, 4].ErasePencilMark(1);

			var cut = new LockedCandidatesClaimingTechnique();

			// Act
			cut.Apply(grid);

			// Assert
			grid.Cells[3, 3].PencilMarks.Should().NotContain(1);
			grid.Cells[4, 3].PencilMarks.Should().NotContain(1);
			grid.Cells[5, 3].PencilMarks.Should().NotContain(1);

			grid.Cells[3, 5].PencilMarks.Should().NotContain(1);
			grid.Cells[4, 5].PencilMarks.Should().NotContain(1);
			grid.Cells[5, 5].PencilMarks.Should().NotContain(1);
		}

		[Fact]
		public void Pencil_marks_for_two_cells_within_a_row_restricted_to_one_block_eliminates_pencil_marks_from_other_cells_within_the_same_block()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();

			grid.Cells[0, 4].ErasePencilMark(1);
			grid.Cells[1, 4].ErasePencilMark(1);
			grid.Cells[2, 4].ErasePencilMark(1);

			grid.Cells[4, 4].ErasePencilMark(1);

			grid.Cells[6, 4].ErasePencilMark(1);
			grid.Cells[7, 4].ErasePencilMark(1);
			grid.Cells[8, 4].ErasePencilMark(1);

			var cut = new LockedCandidatesClaimingTechnique();

			// Act
			cut.Apply(grid);

			// Assert
			grid.Cells[3, 3].PencilMarks.Should().NotContain(1);
			grid.Cells[4, 3].PencilMarks.Should().NotContain(1);
			grid.Cells[5, 3].PencilMarks.Should().NotContain(1);

			grid.Cells[4, 4].PencilMarks.Should().NotContain(1);

			grid.Cells[3, 5].PencilMarks.Should().NotContain(1);
			grid.Cells[4, 5].PencilMarks.Should().NotContain(1);
			grid.Cells[5, 5].PencilMarks.Should().NotContain(1);
		}

		[Fact]
		public void Pencil_marks_for_three_cells_within_a_column_restricted_to_one_block_eliminates_pencil_marks_from_other_cells_within_the_same_block()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();

			grid.Cells[4, 0].ErasePencilMark(2);
			grid.Cells[4, 1].ErasePencilMark(2);
			grid.Cells[4, 2].ErasePencilMark(2);

			grid.Cells[4, 6].ErasePencilMark(2);
			grid.Cells[4, 7].ErasePencilMark(2);
			grid.Cells[4, 8].ErasePencilMark(2);

			var cut = new LockedCandidatesClaimingTechnique();

			// Act
			cut.Apply(grid);

			// Assert
			grid.Cells[3, 3].PencilMarks.Should().NotContain(2);
			grid.Cells[3, 4].PencilMarks.Should().NotContain(2);
			grid.Cells[3, 5].PencilMarks.Should().NotContain(2);

			grid.Cells[5, 3].PencilMarks.Should().NotContain(2);
			grid.Cells[5, 4].PencilMarks.Should().NotContain(2);
			grid.Cells[5, 5].PencilMarks.Should().NotContain(2);
		}

		[Fact]
		public void Pencil_marks_for_two_cells_within_a_column_restricted_to_one_block_eliminates_pencil_marks_from_other_cells_within_the_same_block()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();

			grid.Cells[4, 0].ErasePencilMark(2);
			grid.Cells[4, 1].ErasePencilMark(2);
			grid.Cells[4, 2].ErasePencilMark(2);

			grid.Cells[4, 4].ErasePencilMark(2);

			grid.Cells[4, 6].ErasePencilMark(2);
			grid.Cells[4, 7].ErasePencilMark(2);
			grid.Cells[4, 8].ErasePencilMark(2);

			var cut = new LockedCandidatesClaimingTechnique();

			// Act
			cut.Apply(grid);

			// Assert
			grid.Cells[3, 3].PencilMarks.Should().NotContain(2);
			grid.Cells[3, 4].PencilMarks.Should().NotContain(2);
			grid.Cells[3, 5].PencilMarks.Should().NotContain(2);

			grid.Cells[4, 4].PencilMarks.Should().NotContain(2);

			grid.Cells[5, 3].PencilMarks.Should().NotContain(2);
			grid.Cells[5, 4].PencilMarks.Should().NotContain(2);
			grid.Cells[5, 5].PencilMarks.Should().NotContain(2);
		}

		[Fact]
		public void Pencil_marks_for_two_cells_within_a_row_not_restricted_to_one_block_eliminates_no_pencil_marks()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();

			grid.Cells[0, 4].ErasePencilMark(1);
			grid.Cells[1, 4].ErasePencilMark(1);
			
			grid.Cells[3, 4].ErasePencilMark(1);
			grid.Cells[4, 4].ErasePencilMark(1);
			grid.Cells[5, 4].ErasePencilMark(1);
			
			grid.Cells[7, 4].ErasePencilMark(1);
			grid.Cells[8, 4].ErasePencilMark(1);

			int pencilMarkCountBefore = grid.CountPencilMarks();

			var cut = new LockedCandidatesClaimingTechnique();

			// Act
			cut.Apply(grid);

			// Assert
			int pencilMarkCountAfter = grid.CountPencilMarks();
			pencilMarkCountBefore.Should().Be(pencilMarkCountAfter);
		}

		[Fact]
		public void Pencil_marks_for_two_cells_within_a_column_not_restricted_to_one_block_eliminates_no_pencil_marks()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();

			grid.Cells[4, 0].ErasePencilMark(1);
			grid.Cells[4, 1].ErasePencilMark(1);

			grid.Cells[4, 3].ErasePencilMark(1);
			grid.Cells[4, 4].ErasePencilMark(1);
			grid.Cells[4, 5].ErasePencilMark(1);

			grid.Cells[4, 7].ErasePencilMark(1);
			grid.Cells[4, 8].ErasePencilMark(1);

			int pencilMarkCountBefore = grid.CountPencilMarks();

			var cut = new LockedCandidatesClaimingTechnique();

			// Act
			cut.Apply(grid);

			// Assert
			int pencilMarkCountAfter = grid.CountPencilMarks();
			pencilMarkCountBefore.Should().Be(pencilMarkCountAfter);
		}
	}
}

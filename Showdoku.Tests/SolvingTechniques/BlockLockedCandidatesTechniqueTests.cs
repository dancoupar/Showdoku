using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Showdoku.Setup;
using System;

namespace Showdoku.SolvingTechniques
{
	[TestClass]
	public class BlockLockedCandidatesTechniqueTests
	{
		[TestMethod]
		public void Technique_should_throw_if_no_grid_is_provided()
		{
			// Arrange
			BlockLockedCandidatesTechnique cut = new BlockLockedCandidatesTechnique();

			// Act
			Action act = () =>
			{
				cut.Apply(null);
			};

			// Assert
			act.Should().Throw<ArgumentNullException>();
		}

		[TestMethod]
		public void Identified_pairs_in_same_row_should_eliminate_pencil_marks_from_other_cells_outside_the_block_in_the_same_row()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();

			grid.Cells[4, 0].Solve(6);
			grid.Cells[3, 3].Solve(1);
			grid.Cells[5, 3].Solve(2);
			grid.Cells[3, 5].Solve(3);
			grid.Cells[5, 5].Solve(4);

			grid.Cells[4, 3].RemovePencilMark(6);
			grid.Cells[4, 4].RemovePencilMark(6);
			grid.Cells[4, 5].RemovePencilMark(6);

			BlockLockedCandidatesTechnique cut = new BlockLockedCandidatesTechnique();

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

		[TestMethod]
		public void Identified_pairs_in_same_column_should_eliminate_pencil_marks_from_other_cells_outside_the_block_in_the_same_column()
		{
			// Arrange
			Grid grid = new GridBuilder().WithEmptyGrid();

			grid.Cells[0, 4].Solve(6);
			grid.Cells[3, 3].Solve(1);
			grid.Cells[5, 3].Solve(2);
			grid.Cells[3, 5].Solve(3);
			grid.Cells[5, 5].Solve(4);

			grid.Cells[3, 4].RemovePencilMark(6);
			grid.Cells[4, 4].RemovePencilMark(6);
			grid.Cells[5, 4].RemovePencilMark(6);

			BlockLockedCandidatesTechnique cut = new BlockLockedCandidatesTechnique();

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

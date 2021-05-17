using FluentAssertions;
using Showdoku.Setup;
using Showdoku.SolvingTechniques;
using Xunit;

namespace Showdoku
{
	public class SolverTests
	{
		[Fact]
		public void Easy_grid_1_can_be_solved()
		{
			// Arrange
			var solver = new Solver(
				new CrosshatchingTechnique()
			);

			Grid grid = new GridBuilder().WithEasyGrid_A();

			// Act
			bool result = solver.TrySolve(grid, out _);

			// Assert
			result.Should().BeTrue();
			AssertSolutionIsValid(grid);
		}

		[Fact]
		public void Easy_grid_2_can_be_solved()
		{
			// Arrange			
			var solver = new Solver(
				new CrosshatchingTechnique()
			);

			Grid grid = new GridBuilder().WithEasyGrid_B();

			// Act
			bool result = solver.TrySolve(grid, out _);

			// Assert
			result.Should().BeTrue();
			AssertSolutionIsValid(grid);
		}

		[Fact]
		public void Medium_grid_1_can_be_solved()
		{
			// Arrange			
			var solver = new Solver(
				new CrosshatchingTechnique(),
				new SoleCandidateTechnique()
			);

			Grid grid = new GridBuilder().WithMediumGrid_A();

			// Act
			bool result = solver.TrySolve(grid, out _);

			// Assert
			result.Should().BeTrue();
			AssertSolutionIsValid(grid);
		}

		[Fact]
		public void Medium_grid_2_can_be_solved()
		{
			// Arrange			
			var solver = new Solver(
				new CrosshatchingTechnique(),
				new SoleCandidateTechnique()
			);

			Grid grid = new GridBuilder().WithMediumGrid_B();

			// Act
			bool result = solver.TrySolve(grid, out _);

			// Assert
			result.Should().BeTrue();
			AssertSolutionIsValid(grid);
		}

		[Fact]
		public void Medium_grid_3_can_be_solved()
		{
			// Arrange			
			var solver = new Solver(
				new CrosshatchingTechnique(),
				new SoleCandidateTechnique()
			);

			Grid grid = new GridBuilder().WithMediumGrid_C();

			// Act
			bool result = solver.TrySolve(grid, out _);

			// Assert
			result.Should().BeTrue();
			AssertSolutionIsValid(grid);
		}

		[Fact]
		public void Medium_grid_4_can_be_solved()
		{
			// Arrange			
			var solver = new Solver(
				new CrosshatchingTechnique(),
				new SoleCandidateTechnique()
			);

			Grid grid = new GridBuilder().WithMediumGrid_D();

			// Act
			bool result = solver.TrySolve(grid, out _);

			// Assert
			result.Should().BeTrue();
			AssertSolutionIsValid(grid);
		}

		[Fact]
		public void Hard_grid_1_can_be_solved()
		{
			// Arrange
			var solver = new Solver(
				new CrosshatchingTechnique(),
				new SoleCandidateTechnique(),
				new LockedCandidatesPointingTechnique(),
				new LockedCandidatesClaimingTechnique()
			);

			Grid grid = new GridBuilder().WithHardGrid_A();

			// Act
			bool result = solver.TrySolve(grid, out _);

			// Assert
			result.Should().BeTrue();
			AssertSolutionIsValid(grid);
		}

		[Fact]
		public void Hard_grid_2_can_be_solved()
		{
			// Arrange			
			var solver = new Solver(
				new CrosshatchingTechnique(),
				new SoleCandidateTechnique(),
				new LockedCandidatesPointingTechnique()
			);

			Grid grid = new GridBuilder().WithHardGrid_B();

			// Act
			bool result = solver.TrySolve(grid, out _);

			// Assert
			result.Should().BeTrue();
			AssertSolutionIsValid(grid);
		}

		[Fact]
		public void Worlds_hardest_grid_can_be_solved()
		{
			// Arrange			
			var solver = new Solver(
				new CrosshatchingTechnique(),
				new SoleCandidateTechnique(),
				new LockedCandidatesPointingTechnique()
			);

			Grid grid = new GridBuilder().WithWorldsHardestGrid();

			// Act
			bool result = solver.TrySolve(grid, out _);

			// Assert
			result.Should().BeTrue();
			AssertSolutionIsValid(grid);
		}

		private static void AssertSolutionIsValid(Grid grid)
		{
			for (int x = 0; x < 9; x++)
			{
				for (int y = 0; y < 9; y++)
				{
					grid.Cells[x, y].IsSolutionValid(grid.Cells[x, y].Solution.Value).Should().BeTrue();
				}
			}
		}
	}
}

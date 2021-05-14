using FluentAssertions;
using Showdoku.Setup;
using Showdoku.SolvingTechniques;
using Xunit;

namespace Showdoku
{
	public class SolverTests
	{
		[Fact]
		public void Should_be_able_to_solve_easy_grid_a()
		{
			// Arrange
			Solver solver = new Solver(
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
		public void Should_be_able_to_solve_easy_grid_b()
		{
			// Arrange			
			Solver solver = new Solver(
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
		public void Should_be_able_to_solve_medium_grid_a()
		{
			// Arrange			
			Solver solver = new Solver(
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
		public void Should_be_able_to_solve_medium_grid_b()
		{
			// Arrange			
			Solver solver = new Solver(
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
		public void Should_be_able_to_solve_medium_grid_c()
		{
			// Arrange			
			Solver solver = new Solver(
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
		public void Should_be_able_to_solve_medium_grid_d()
		{
			// Arrange			
			Solver solver = new Solver(
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
		public void Should_be_able_to_solve_hard_grid_a()
		{
			// Arrange			
			Solver solver = new Solver(
				new CrosshatchingTechnique(),
				new SoleCandidateTechnique(),
				new LockedCandidatesTechnique()
			);

			Grid grid = new GridBuilder().WithHardGrid_A();

			// Act
			bool result = solver.TrySolve(grid, out _);

			// Assert
			result.Should().BeTrue();
			AssertSolutionIsValid(grid);
		}

		[Fact]
		public void Should_be_able_to_solve_hard_grid_b()
		{
			// Arrange			
			Solver solver = new Solver(
				new CrosshatchingTechnique(),
				new SoleCandidateTechnique(),
				new LockedCandidatesTechnique()
			);

			Grid grid = new GridBuilder().WithHardGrid_B();

			// Act
			bool result = solver.TrySolve(grid, out _);

			// Assert
			result.Should().BeTrue();
			AssertSolutionIsValid(grid);
		}

		[Fact]
		public void Should_be_able_to_solve_worlds_hardest_grid()
		{
			// Arrange			
			Solver solver = new Solver(
				new CrosshatchingTechnique(),
				new SoleCandidateTechnique(),
				new LockedCandidatesTechnique()
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

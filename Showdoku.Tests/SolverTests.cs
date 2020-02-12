using Microsoft.VisualStudio.TestTools.UnitTesting;
using Showdoku.Setup;
using Showdoku.SolvingTechniques;
using System.Collections.Generic;

namespace Showdoku
{
	[TestClass]
	public class SolverTests
	{
		[TestMethod]
		public void Test()
		{
			// Arrange			
			Solver solver = new Solver(
				new List<ISolvingTechnique>()
				{
					new SoleCandidateTechnique(),
					new UniqueCandidateTechnique()
				}
			);

			Grid grid = new GridBuilder().WithHardGrid_A();

			// Act
			solver.TrySolve(grid, out string report);
		}
	}
}

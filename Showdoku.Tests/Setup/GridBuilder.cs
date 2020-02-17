namespace Showdoku.Setup
{
	public class GridBuilder
	{
		private readonly Grid grid;

		public GridBuilder()
		{
			this.grid = new Grid();
		}

		public GridBuilder WithEmptyGrid()
		{
			foreach (Cell cell in grid.Cells)
			{
				cell.Empty();
			}

			return this;
		}

		public GridBuilder WithSolvedGrid()
		{
			foreach (Cell cell in grid.Cells)
			{
				cell.Empty();
			}

			// Row 1: 1,2,3,4,5,6,7,8,9
			for (int x = 0; x < 9; x++)
			{				
				int solution = x + 1;
				this.grid.Cells[x, 0].Solve(solution);
			}

			// Row 2: 4,5,6,7,8,9,1,2,3
			for (int x = 0; x < 9; x++)
			{				
				int solution = x < 6 ? x + 4 : x - 5;
				this.grid.Cells[x, 1].Solve(solution);
			}

			// Row 3: 7,8,9,1,2,3,4,5,6
			for (int x = 0; x < 9; x++)
			{
				int solution = x < 3 ? x + 7 : x - 2;
				this.grid.Cells[x, 2].Solve(solution);
			}

			// Row 4: 2,3,4,5,6,7,8,9,1
			for (int x = 0; x < 9; x++)
			{
				int solution = x < 8 ? x + 2 : x - 7;
				this.grid.Cells[x, 3].Solve(solution);
			}

			// Row 5: 5,6,7,8,9,1,2,3,4
			for (int x = 0; x < 9; x++)
			{
				int solution = x < 5 ? x + 5 : x - 4;
				this.grid.Cells[x, 4].Solve(solution);
			}

			// Row 6: 8,9,1,2,3,4,5,6,7
			for (int x = 0; x < 9; x++)
			{
				int solution = x < 2 ? x + 8 : x - 1;
				this.grid.Cells[x, 5].Solve(solution);
			}

			// Row 7: 3,4,5,6,7,8,9,1,2
			for (int x = 0; x < 9; x++)
			{
				int solution = x < 7 ? x + 3 : x - 6;
				this.grid.Cells[x, 6].Solve(solution);
			}

			// Row 8: 6,7,8,9,1,2,3,4,5
			for (int x = 0; x < 9; x++)
			{
				int solution = x < 4 ? x + 6 : x - 3;
				this.grid.Cells[x, 7].Solve(solution);
			}

			// Row 9: 9,1,2,3,4,5,6,7,8
			for (int x = 0; x < 9; x++)
			{
				int solution = x < 1 ? x + 9 : x;
				this.grid.Cells[x, 8].Solve(solution);
			}			

			return this;
		}

		public GridBuilder WithEasyGrid_A()
		{
			foreach (Cell cell in grid.Cells)
			{
				cell.Empty();
			}

			grid.Cells[0, 0].Solve(5);
			grid.Cells[4, 0].Solve(1);
			grid.Cells[8, 0].Solve(4);
			grid.Cells[0, 1].Solve(2);
			grid.Cells[1, 1].Solve(7);
			grid.Cells[2, 1].Solve(4);
			grid.Cells[6, 1].Solve(6);
			grid.Cells[1, 2].Solve(8);
			grid.Cells[3, 2].Solve(9);
			grid.Cells[5, 2].Solve(4);
			grid.Cells[0, 3].Solve(8);
			grid.Cells[1, 3].Solve(1);
			grid.Cells[3, 3].Solve(4);
			grid.Cells[4, 3].Solve(6);
			grid.Cells[6, 3].Solve(3);
			grid.Cells[8, 3].Solve(2);
			grid.Cells[2, 4].Solve(2);
			grid.Cells[4, 4].Solve(3);
			grid.Cells[6, 4].Solve(1);
			grid.Cells[0, 5].Solve(7);
			grid.Cells[2, 5].Solve(6);
			grid.Cells[4, 5].Solve(9);
			grid.Cells[5, 5].Solve(1);
			grid.Cells[7, 5].Solve(5);
			grid.Cells[8, 5].Solve(8);
			grid.Cells[3, 6].Solve(5);
			grid.Cells[5, 6].Solve(3);
			grid.Cells[7, 6].Solve(1);
			grid.Cells[2, 7].Solve(5);
			grid.Cells[6, 7].Solve(9);
			grid.Cells[7, 7].Solve(2);
			grid.Cells[8, 7].Solve(7);
			grid.Cells[0, 8].Solve(1);
			grid.Cells[4, 8].Solve(2);
			grid.Cells[8, 8].Solve(3);
			
			return this;
		}

		public GridBuilder WithEasyGrid_B()
		{
			foreach (Cell cell in grid.Cells)
			{
				cell.Empty();
			}

			grid.Cells[1, 0].Solve(3);
			grid.Cells[4, 0].Solve(2);
			grid.Cells[5, 0].Solve(9);
			grid.Cells[8, 0].Solve(4);
			grid.Cells[1, 1].Solve(7);
			grid.Cells[2, 1].Solve(2);
			grid.Cells[3, 1].Solve(6);
			grid.Cells[6, 1].Solve(9);
			grid.Cells[7, 1].Solve(8);
			grid.Cells[8, 1].Solve(5);
			grid.Cells[2, 2].Solve(1);
			grid.Cells[5, 2].Solve(4);
			grid.Cells[2, 3].Solve(9);
			grid.Cells[6, 3].Solve(5);
			grid.Cells[7, 3].Solve(4);
			grid.Cells[0, 4].Solve(2);
			grid.Cells[8, 4].Solve(9);
			grid.Cells[1, 5].Solve(6);
			grid.Cells[2, 5].Solve(5);
			grid.Cells[6, 5].Solve(1);
			grid.Cells[3, 6].Solve(8);
			grid.Cells[6, 6].Solve(6);
			grid.Cells[0, 7].Solve(8);
			grid.Cells[1, 7].Solve(1);
			grid.Cells[2, 7].Solve(6);
			grid.Cells[5, 7].Solve(7);
			grid.Cells[6, 7].Solve(2);
			grid.Cells[7, 7].Solve(9);
			grid.Cells[0, 8].Solve(5);
			grid.Cells[3, 8].Solve(2);
			grid.Cells[4, 8].Solve(1);
			grid.Cells[7, 8].Solve(7);

			return this;
		}

		public GridBuilder WithMediumGrid_A()
		{
			foreach (Cell cell in grid.Cells)
			{
				cell.Empty();
			}

			grid.Cells[0, 0].Solve(5);
			grid.Cells[4, 0].Solve(2);
			grid.Cells[6, 0].Solve(9);
			grid.Cells[4, 1].Solve(1);
			grid.Cells[6, 1].Solve(6);
			grid.Cells[7, 1].Solve(8);
			grid.Cells[0, 2].Solve(1);
			grid.Cells[1, 2].Solve(9);
			grid.Cells[4, 2].Solve(8);
			grid.Cells[5, 2].Solve(3);
			grid.Cells[2, 3].Solve(1);
			grid.Cells[4, 3].Solve(4);
			grid.Cells[8, 3].Solve(6);
			grid.Cells[2, 4].Solve(6);
			grid.Cells[4, 4].Solve(7);
			grid.Cells[7, 4].Solve(4);
			grid.Cells[8, 4].Solve(5);
			grid.Cells[1, 5].Solve(7);
			grid.Cells[4, 5].Solve(5);
			grid.Cells[6, 5].Solve(8);
			grid.Cells[8, 5].Solve(1);
			grid.Cells[1, 6].Solve(8);
			grid.Cells[4, 6].Solve(3);
			grid.Cells[5, 6].Solve(2);
			grid.Cells[8, 6].Solve(9);
			grid.Cells[0, 7].Solve(7);
			grid.Cells[2, 7].Solve(4);
			grid.Cells[3, 7].Solve(5);			
			grid.Cells[0, 8].Solve(2);
			grid.Cells[5, 8].Solve(4);

			return this;
		}

		public GridBuilder WithMediumGrid_B()
		{
			foreach (Cell cell in grid.Cells)
			{
				cell.Empty();
			}

			grid.Cells[1, 0].Solve(8);
			grid.Cells[7, 0].Solve(7);
			grid.Cells[8, 0].Solve(2);
			grid.Cells[0, 1].Solve(2);
			grid.Cells[1, 1].Solve(5);
			grid.Cells[5, 1].Solve(4);
			grid.Cells[8, 1].Solve(1);
			grid.Cells[1, 2].Solve(1);
			grid.Cells[6, 2].Solve(5);
			grid.Cells[7, 2].Solve(4);
			grid.Cells[8, 2].Solve(9);
			grid.Cells[0, 3].Solve(5);
			grid.Cells[2, 3].Solve(1);
			grid.Cells[3, 3].Solve(3);
			grid.Cells[5, 3].Solve(7);
			grid.Cells[1, 4].Solve(7);
			grid.Cells[7, 4].Solve(1);
			grid.Cells[8, 4].Solve(5);
			grid.Cells[0, 5].Solve(4);
			grid.Cells[1, 5].Solve(2);
			grid.Cells[3, 5].Solve(1);
			grid.Cells[5, 5].Solve(8);
			grid.Cells[7, 6].Solve(9);
			grid.Cells[8, 6].Solve(6);
			grid.Cells[4, 7].Solve(6);
			grid.Cells[5, 7].Solve(9);
			grid.Cells[8, 7].Solve(7);
			grid.Cells[0, 8].Solve(1);
			grid.Cells[6, 8].Solve(2);
			grid.Cells[7, 8].Solve(8);

			return this;
		}

		public GridBuilder WithHardGrid_A()
		{
			foreach (Cell cell in grid.Cells)
			{
				cell.Empty();
			}

			grid.Cells[3, 0].Solve(7);
			grid.Cells[5, 0].Solve(9);
			grid.Cells[6, 0].Solve(6);
			grid.Cells[1, 1].Solve(4);
			grid.Cells[6, 1].Solve(1);
			grid.Cells[8, 1].Solve(8);
			grid.Cells[0, 2].Solve(8);
			grid.Cells[4, 2].Solve(6);
			grid.Cells[6, 2].Solve(2);
			grid.Cells[2, 3].Solve(3);
			grid.Cells[5, 3].Solve(8);
			grid.Cells[8, 3].Solve(1);
			grid.Cells[1, 4].Solve(8);
			grid.Cells[7, 4].Solve(6);
			grid.Cells[0, 5].Solve(5);
			grid.Cells[3, 5].Solve(6);
			grid.Cells[6, 5].Solve(7);
			grid.Cells[2, 6].Solve(6);
			grid.Cells[4, 6].Solve(3);
			grid.Cells[8, 6].Solve(4);
			grid.Cells[0, 7].Solve(4);
			grid.Cells[2, 7].Solve(8);
			grid.Cells[7, 7].Solve(7);
			grid.Cells[2, 8].Solve(1);
			grid.Cells[3, 8].Solve(2);
			grid.Cells[5, 8].Solve(7);

			return this;
		}

		public GridBuilder WithHardGrid_B()
		{
			foreach (Cell cell in grid.Cells)
			{
				cell.Empty();
			}

			

			return this;
		}

		public GridBuilder WithWorldsHardestGrid()
		{
			foreach (Cell cell in grid.Cells)
			{
				cell.Empty();
			}

			grid.Cells[0, 0].Solve(8);
			grid.Cells[2, 1].Solve(3);
			grid.Cells[3, 1].Solve(6);
			grid.Cells[1, 2].Solve(7);
			grid.Cells[4, 2].Solve(9);
			grid.Cells[6, 2].Solve(2);
			grid.Cells[1, 3].Solve(5);
			grid.Cells[5, 3].Solve(7);
			grid.Cells[4, 4].Solve(4);
			grid.Cells[5, 4].Solve(5);
			grid.Cells[6, 4].Solve(7);
			grid.Cells[3, 5].Solve(1);
			grid.Cells[7, 5].Solve(3);
			grid.Cells[2, 6].Solve(1);
			grid.Cells[7, 6].Solve(6);
			grid.Cells[8, 6].Solve(8);
			grid.Cells[2, 7].Solve(8);
			grid.Cells[3, 7].Solve(5);
			grid.Cells[7, 7].Solve(1);
			grid.Cells[1, 8].Solve(9);
			grid.Cells[6, 8].Solve(4);
			
			return this;
		}

		public static implicit operator Grid(GridBuilder builder)
		{
			return builder.grid;
		}
	}
}

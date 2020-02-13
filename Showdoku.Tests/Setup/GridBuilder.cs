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
				this.grid.SolveCell(x, 0, solution);
			}

			// Row 2: 4,5,6,7,8,9,1,2,3
			for (int x = 0; x < 9; x++)
			{				
				int solution = x < 6 ? x + 4 : x - 5;
				this.grid.SolveCell(x, 1, solution);
			}

			// Row 3: 7,8,9,1,2,3,4,5,6
			for (int x = 0; x < 9; x++)
			{
				int solution = x < 3 ? x + 7 : x - 2;
				this.grid.SolveCell(x, 2, solution);
			}

			// Row 4: 2,3,4,5,6,7,8,9,1
			for (int x = 0; x < 9; x++)
			{
				int solution = x < 8 ? x + 2 : x - 7;
				this.grid.SolveCell(x, 3, solution);
			}

			// Row 5: 5,6,7,8,9,1,2,3,4
			for (int x = 0; x < 9; x++)
			{
				int solution = x < 5 ? x + 5 : x - 4;
				this.grid.SolveCell(x, 4, solution);
			}

			// Row 6: 8,9,1,2,3,4,5,6,7
			for (int x = 0; x < 9; x++)
			{
				int solution = x < 2 ? x + 8 : x - 1;
				this.grid.SolveCell(x, 5, solution);
			}

			// Row 7: 3,4,5,6,7,8,9,1,2
			for (int x = 0; x < 9; x++)
			{
				int solution = x < 7 ? x + 3 : x - 6;
				this.grid.SolveCell(x, 6, solution);
			}

			// Row 8: 6,7,8,9,1,2,3,4,5
			for (int x = 0; x < 9; x++)
			{
				int solution = x < 4 ? x + 6 : x - 3;
				this.grid.SolveCell(x, 7, solution);
			}

			// Row 9: 9,1,2,3,4,5,6,7,8
			for (int x = 0; x < 9; x++)
			{
				int solution = x < 1 ? x + 9 : x;
				this.grid.SolveCell(x, 8, solution);
			}			

			return this;
		}

		public GridBuilder WithEasyGrid_A()
		{
			foreach (Cell cell in grid.Cells)
			{
				cell.Empty();
			}

			grid.SolveCell(0, 0, 5);
			grid.SolveCell(4, 0, 1);
			grid.SolveCell(8, 0, 4);
			grid.SolveCell(0, 1, 2);
			grid.SolveCell(1, 1, 7);
			grid.SolveCell(2, 1, 4);
			grid.SolveCell(6, 1, 6);
			grid.SolveCell(1, 2, 8);
			grid.SolveCell(3, 2, 9);
			grid.SolveCell(5, 2, 4);
			grid.SolveCell(0, 3, 8);
			grid.SolveCell(1, 3, 1);
			grid.SolveCell(3, 3, 4);
			grid.SolveCell(4, 3, 6);
			grid.SolveCell(6, 3, 3);
			grid.SolveCell(8, 3, 2);
			grid.SolveCell(2, 4, 2);
			grid.SolveCell(4, 4, 3);
			grid.SolveCell(6, 4, 1);
			grid.SolveCell(0, 5, 7);
			grid.SolveCell(2, 5, 6);
			grid.SolveCell(4, 5, 9);
			grid.SolveCell(5, 5, 1);
			grid.SolveCell(7, 5, 5);
			grid.SolveCell(8, 5, 8);
			grid.SolveCell(3, 6, 5);
			grid.SolveCell(5, 6, 3);
			grid.SolveCell(7, 6, 1);
			grid.SolveCell(2, 7, 5);
			grid.SolveCell(6, 7, 9);
			grid.SolveCell(7, 7, 2);
			grid.SolveCell(8, 7, 7);
			grid.SolveCell(0, 8, 1);
			grid.SolveCell(4, 8, 2);
			grid.SolveCell(8, 8, 3);
			
			return this;
		}

		public GridBuilder WithEasyGrid_B()
		{
			foreach (Cell cell in grid.Cells)
			{
				cell.Empty();
			}

			grid.SolveCell(1, 0, 3);
			grid.SolveCell(4, 0, 2);
			grid.SolveCell(5, 0, 9);
			grid.SolveCell(8, 0, 4);
			grid.SolveCell(1, 1, 7);
			grid.SolveCell(2, 1, 2);
			grid.SolveCell(3, 1, 6);
			grid.SolveCell(6, 1, 9);
			grid.SolveCell(7, 1, 8);
			grid.SolveCell(8, 1, 5);
			grid.SolveCell(2, 2, 1);
			grid.SolveCell(5, 2, 4);
			grid.SolveCell(2, 3, 9);
			grid.SolveCell(6, 3, 5);
			grid.SolveCell(7, 3, 4);
			grid.SolveCell(0, 4, 2);
			grid.SolveCell(8, 4, 9);
			grid.SolveCell(1, 5, 6);
			grid.SolveCell(2, 5, 5);
			grid.SolveCell(6, 5, 1);
			grid.SolveCell(3, 6, 8);
			grid.SolveCell(6, 6, 6);
			grid.SolveCell(0, 7, 8);
			grid.SolveCell(1, 7, 1);
			grid.SolveCell(2, 7, 6);
			grid.SolveCell(5, 7, 7);
			grid.SolveCell(6, 7, 2);
			grid.SolveCell(7, 7, 9);
			grid.SolveCell(0, 8, 5);
			grid.SolveCell(3, 8, 2);
			grid.SolveCell(4, 8, 1);
			grid.SolveCell(7, 8, 7);

			return this;
		}

		public GridBuilder WithMediumGrid_A()
		{
			foreach (Cell cell in grid.Cells)
			{
				cell.Empty();
			}

			grid.SolveCell(0, 0, 5);
			grid.SolveCell(4, 0, 2);
			grid.SolveCell(6, 0, 9);
			grid.SolveCell(4, 1, 1);
			grid.SolveCell(6, 1, 6);
			grid.SolveCell(7, 1, 8);
			grid.SolveCell(0, 2, 1);
			grid.SolveCell(1, 2, 9);
			grid.SolveCell(4, 2, 8);
			grid.SolveCell(5, 2, 3);
			grid.SolveCell(2, 3, 1);
			grid.SolveCell(4, 3, 4);
			grid.SolveCell(8, 3, 6);
			grid.SolveCell(2, 4, 6);
			grid.SolveCell(4, 4, 7);
			grid.SolveCell(7, 4, 4);
			grid.SolveCell(8, 4, 5);
			grid.SolveCell(1, 5, 7);
			grid.SolveCell(4, 5, 5);
			grid.SolveCell(6, 5, 8);
			grid.SolveCell(8, 5, 1);
			grid.SolveCell(1, 6, 8);
			grid.SolveCell(4, 6, 3);
			grid.SolveCell(5, 6, 2);
			grid.SolveCell(8, 6, 9);
			grid.SolveCell(0, 7, 7);
			grid.SolveCell(2, 7, 4);
			grid.SolveCell(3, 7, 5);			
			grid.SolveCell(0, 8, 2);
			grid.SolveCell(5, 8, 4);

			return this;
		}

		public GridBuilder WithMediumGrid_B()
		{
			foreach (Cell cell in grid.Cells)
			{
				cell.Empty();
			}

			grid.SolveCell(1, 0, 8);
			grid.SolveCell(7, 0, 7);
			grid.SolveCell(8, 0, 2);
			grid.SolveCell(0, 1, 2);
			grid.SolveCell(1, 1, 5);
			grid.SolveCell(5, 1, 4);
			grid.SolveCell(8, 1, 1);
			grid.SolveCell(1, 2, 1);
			grid.SolveCell(6, 2, 5);
			grid.SolveCell(7, 2, 4);
			grid.SolveCell(8, 2, 9);
			grid.SolveCell(0, 3, 5);
			grid.SolveCell(2, 3, 1);
			grid.SolveCell(3, 3, 3);
			grid.SolveCell(5, 3, 7);
			grid.SolveCell(1, 4, 7);
			grid.SolveCell(7, 4, 1);
			grid.SolveCell(8, 4, 5);
			grid.SolveCell(0, 5, 4);
			grid.SolveCell(1, 5, 2);
			grid.SolveCell(3, 5, 1);
			grid.SolveCell(5, 5, 8);
			grid.SolveCell(7, 6, 9);
			grid.SolveCell(8, 6, 6);
			grid.SolveCell(4, 7, 6);
			grid.SolveCell(5, 7, 9);
			grid.SolveCell(8, 7, 7);
			grid.SolveCell(0, 8, 1);
			grid.SolveCell(6, 8, 2);
			grid.SolveCell(7, 8, 8);

			return this;
		}

		public GridBuilder WithHardGrid_A()
		{
			foreach (Cell cell in grid.Cells)
			{
				cell.Empty();
			}

			grid.SolveCell(3, 0, 7);
			grid.SolveCell(5, 0, 9);
			grid.SolveCell(6, 0, 6);
			grid.SolveCell(1, 1, 4);
			grid.SolveCell(6, 1, 1);
			grid.SolveCell(8, 1, 8);
			grid.SolveCell(0, 2, 8);
			grid.SolveCell(4, 2, 6);
			grid.SolveCell(6, 2, 2);
			grid.SolveCell(2, 3, 3);
			grid.SolveCell(5, 3, 8);
			grid.SolveCell(8, 3, 1);
			grid.SolveCell(1, 4, 8);
			grid.SolveCell(7, 4, 6);
			grid.SolveCell(0, 5, 5);
			grid.SolveCell(3, 5, 6);
			grid.SolveCell(6, 5, 7);
			grid.SolveCell(2, 6, 6);
			grid.SolveCell(4, 6, 3);
			grid.SolveCell(8, 6, 4);
			grid.SolveCell(0, 7, 4);
			grid.SolveCell(2, 7, 8);
			grid.SolveCell(7, 7, 7);
			grid.SolveCell(2, 8, 1);
			grid.SolveCell(3, 8, 2);
			grid.SolveCell(5, 8, 7);

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

			grid.SolveCell(0, 0, 8);
			grid.SolveCell(2, 1, 3);
			grid.SolveCell(3, 1, 6);
			grid.SolveCell(1, 2, 7);
			grid.SolveCell(4, 2, 9);
			grid.SolveCell(6, 2, 2);
			grid.SolveCell(1, 3, 5);
			grid.SolveCell(5, 3, 7);
			grid.SolveCell(4, 4, 4);
			grid.SolveCell(5, 4, 5);
			grid.SolveCell(6, 4, 7);
			grid.SolveCell(3, 5, 1);
			grid.SolveCell(7, 5, 3);
			grid.SolveCell(2, 6, 1);
			grid.SolveCell(7, 6, 6);
			grid.SolveCell(8, 6, 8);
			grid.SolveCell(2, 7, 8);
			grid.SolveCell(3, 7, 5);
			grid.SolveCell(7, 7, 1);
			grid.SolveCell(1, 8, 9);
			grid.SolveCell(6, 8, 4);
			
			return this;
		}

		public static implicit operator Grid(GridBuilder builder)
		{
			return builder.grid;
		}
	}
}

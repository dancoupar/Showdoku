using System;
using System.Collections;
using System.Collections.Generic;

namespace Showdoku
{
	public class Block : ICellContainer
	{
		public Block(Cell[,] cells)
		{
			if (cells == null)
			{
				throw new ArgumentNullException(nameof(cells), "Argument cannot be null.");
			}

			if (cells.GetLength(0) != 3 || cells.GetLength(1) != 3)
			{
				throw new ArgumentException("Array must contain 3 by 3 elements.", nameof(cells));
			}

			this.Cells = cells;
		}

		public Cell[,] Cells
		{
			get;
		}
		
		public bool IsSolved()
		{
			for (int y = 0; y < 3; y++)
			{
				for (int x = 0; x < 3; x++)
				{
					if (!this.Cells[x,y].IsSolved())
					{
						return false;
					}
				}
			}

			return true;
		}

		public bool Contains(Cell cell)
		{
			foreach (Cell c in this.Cells)
			{
				if (c == cell)
				{
					return true;
				}
			}

			return false;
		}

		public IEnumerator<Cell> GetEnumerator()
		{
			for (int x = 0; x < 3; x++)
			{
				for (int y = 0; y < 3; y++)
				{
					yield return this.Cells[x, y];
				}
			}
		}

		IEnumerable<Cell> ICellContainer.Cells
		{
			get
			{
				foreach (Cell cell in this)
				{
					yield return cell;
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}

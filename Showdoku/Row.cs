using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Showdoku
{
	public class Row : ICellContainer
	{
		public Row(Cell[] cells)
		{
			if (cells == null)
			{
				throw new ArgumentNullException(nameof(cells), "Argument cannot be null.");
			}

			if (cells.Length != 9)
			{				
				throw new ArgumentException("Array must contain 9 elements.", nameof(cells));
			}

			this.Cells = cells;
		}

		public Cell[] Cells
		{
			get;
		}

		public IEnumerator<Cell> GetEnumerator()
		{
			foreach (Cell cell in this.Cells)
			{
				yield return cell;
			}
		}

		public bool IsSolved()
		{
			return this.Cells.All((c) => c.IsSolved());
		}

		IEnumerable<Cell> ICellContainer.Cells
		{
			get
			{
				return this.Cells;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}

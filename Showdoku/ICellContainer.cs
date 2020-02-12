using System;
using System.Collections.Generic;
using System.Text;

namespace Showdoku
{
	public interface ICellContainer : IEnumerable<Cell>
	{
		public IEnumerable<Cell> Cells { get; }
	}
}

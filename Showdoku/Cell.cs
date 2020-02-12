using Showdoku.Exceptions;
using System;
using System.Collections.Generic;

namespace Showdoku
{
	public class Cell
	{
		private readonly List<int> pencilMarks;

		public Cell()
		{
			this.pencilMarks = new List<int>();
			this.ResetPencilMarks();
		}

		/// <summary>
		/// Gets the solution to this cell, if solved.
		/// </summary>
		public int? Solution
		{
			get;
			private set;
		}

		public IReadOnlyCollection<int> PencilMarks
		{
			get
			{
				return this.pencilMarks.AsReadOnly();
			}
		}

		public void RemovePencilMark(int pencilMark)
		{
			if (this.IsSolved())
			{
				throw new AlreadySolvedException("This cell has already been solved.");
			}

			if (pencilMark < 1 || pencilMark > 9)
			{
				throw new ArgumentOutOfRangeException(nameof(pencilMark), pencilMark, "Argument must not be less than 1 or greater than 9.");
			}

			this.pencilMarks.Remove(pencilMark);

			if (this.pencilMarks.Count == 1)
			{
				this.Solve(this.pencilMarks[0]);
			}
		}

		public void Solve(int solution)
		{
			if (this.IsSolved())
			{
				throw new AlreadySolvedException("This cell has already been solved.");
			}

			if (solution < 1 || solution > 9)
			{
				throw new ArgumentOutOfRangeException(nameof(solution), solution, "Argument must not be less than 1 or greater than 9.");
			}

			if (!this.pencilMarks.Contains(solution))
			{
				throw new InvalidSolutionException($"{solution} is not a possible solution for this cell.", solution);
			}

			this.Solution = solution;
			this.pencilMarks.Clear();
		}

		public void Empty()
		{
			this.Solution = null;
			this.ResetPencilMarks();
		}

		public bool IsSolved()
		{
			return this.Solution.HasValue;
		}

		private void ResetPencilMarks()
		{
			this.pencilMarks.Clear();

			for (int i = 1; i < 10; i++)
			{
				this.pencilMarks.Add(i);
			}
		}
	}
}

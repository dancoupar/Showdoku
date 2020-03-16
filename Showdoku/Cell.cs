using Showdoku.Exceptions;
using System;
using System.Collections.Generic;

namespace Showdoku
{
	/// <summary>
	/// Represents a single cell within a sudoku grid.
	/// </summary>
	public class Cell
	{
		private readonly Grid grid;
		private readonly List<int> pencilMarks;

		/// <summary>
		/// Creates a new cell to be contained in the specified sudoku grid.
		/// </summary>
		/// <param name="grid">
		/// The grid to which the cell will belong.
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// Thrown if the specified grid is null.
		/// </exception>
		public Cell(Grid grid)
		{
			this.grid = grid ?? throw new ArgumentNullException(nameof(grid), "Argument cannot be null.");
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

		/// <summary>
		/// Gets a collection of possible solutions for this cell.
		/// </summary>
		public IReadOnlyCollection<int> PencilMarks
		{
			get
			{
				return this.pencilMarks.AsReadOnly();
			}
		}

		/// <summary>
		/// Eliminates the specified value as a possible solution to this cell.
		/// </summary>
		/// <param name="pencilMark">
		/// The number to remove from the list of possible solutions for this cell.
		/// </param>
		/// <exception cref="AlreadySolvedException">
		/// Thrown if this cell has already been solved.
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		/// Thrown if the specified solution is not a number between 1 and 9 (inclusive).
		/// </exception>
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

		/// <summary>
		/// Gets a value indicating whether the specified solution is valid for this cell. A
		/// solution is valid only if it does not appear elsewhere within the same block, row or
		/// column that this cell occupies.
		/// </summary>	
		/// <param name="solution">
		/// The proposed solution for the cell.
		/// </param>
		/// <returns>
		/// True if the proposed solution is valid, otherwise false.
		/// </returns>
		public bool IsSolutionValid(int solution)
		{			
			if (solution < 1 || solution > 9)
			{
				return false;
			}

			if (this.IsNumberAlreadyInBlock(solution))
			{
				return false;
			}

			if (this.IsNumberAlreadyInRow(solution))
			{
				return false;
			}

			if (this.IsNumberAlreadyInColumn(solution))
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// Solves this cell with the specified solution.
		/// </summary>
		/// <param name="solution">
		/// The solution to this cell; a number between 1 and 9.
		/// </param>
		/// <exception cref="AlreadySolvedException">
		/// Thrown if this cell has already been solved.
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		/// Thrown if the specified solution is not a number between 1 and 9 (inclusive).
		/// </exception>
		/// <exception cref="InvalidSolutionException">
		/// Thrown if the specified solution already appears within the same block, row or column
		/// that this cell occupies.
		/// </exception>
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

			if (this.IsNumberAlreadyInBlock(solution))
			{
				throw new InvalidSolutionException($"The block containing this cell already contains a cell with a solution of {solution}.", solution);
			}

			if (this.IsNumberAlreadyInRow(solution))
			{
				throw new InvalidSolutionException($"The row containing this cell already contains a cell with a solution of {solution}.", solution);
			}

			if (this.IsNumberAlreadyInColumn(solution))
			{
				throw new InvalidSolutionException($"The column containing this cell already contains a cell with a solution of {solution}.", solution);
			}

			if (!this.pencilMarks.Contains(solution))
			{
				throw new InvalidSolutionException($"{solution} is not a possible solution for this cell.", solution);
			}

			this.Solution = solution;
			this.pencilMarks.Clear();
		}

		/// <summary>
		/// Empties this cell, removing any existing solution.
		/// </summary>
		public void Empty()
		{
			this.Solution = null;
			this.ResetPencilMarks();
		}

		/// <summary>
		/// Gets a value indicating whether this cell has been solved.
		/// </summary>
		/// <returns>
		/// True if this cell is solved, otherwise false.
		/// </returns>
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

		private bool IsNumberAlreadyInBlock(int number)
		{
			foreach (Cell blockCell in this.grid.GetBlockContainingCell(this).Cells)
			{
				if (blockCell != this && blockCell.IsSolved() && blockCell.Solution.Value == number)
				{
					return true;
				}
			}

			return false;
		}

		private bool IsNumberAlreadyInRow(int number)
		{
			foreach (Cell rowCell in this.grid.GetRowContainingCell(this).Cells)
			{
				if (rowCell != this && rowCell.IsSolved() && rowCell.Solution.Value == number)
				{
					return true;
				}
			}

			return false;
		}

		private bool IsNumberAlreadyInColumn(int number)
		{
			foreach (Cell columnCell in this.grid.GetColumnContainingCell(this).Cells)
			{
				if (columnCell != this && columnCell.IsSolved() && columnCell.Solution.Value == number)
				{
					return true;
				}
			}

			return false;
		}
	}
}

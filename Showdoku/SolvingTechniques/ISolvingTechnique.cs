namespace Showdoku.SolvingTechniques
{
	/// <summary>
	/// A technique for solving cells within a sudoku grid.
	/// </summary>
	public interface ISolvingTechnique
	{
		/// <summary>
		/// Gets a value indicating whether the solving process should be restarted if this
		/// technique proves successful.
		/// </summary>
		public bool RestartSolvingProcessOnSuccess { get; }

		/// <summary>
		/// Applies the technique to the specified grid.
		/// </summary>
		/// <param name="grid">
		/// The grid to which the technique should be applied.
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// Thrown if the specified grid is null.
		/// </exception>
		public void Apply(Grid grid);
	}
}

using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Showdoku
{
	public class PencilMarksComparerTests
	{
		[Fact]
		public void Two_sets_of_pencil_marks_are_deemed_equal_if_they_are_the_same_and_not_equal_otherwise()
		{
			// Arrange
			var grid = new Grid();

			// Test every possible combination of pencil marks with every
			// other possible combination of pencil marks. There are 512
			// possible combinations (2^9) for a single set of pencil marks.

			var firstSetCombos = new List<List<int>>();
			var secondSetCombos = new List<List<int>>();

			void populateSetCombos(List<List<int>> setCombos)
			{
				// Cycle through each combination using a simple integer as the
				// key, treated as a binary number. For example, for the 100th
				// iteration, 100 is 001100100. If we want to know whether we
				// should include 3 in the set of pencil marks we need to know
				// whether the third digit from the right is a 0 or a 1. To do
				// that a bitwise AND is performed on 001100100 and 000000100.
				// If the result is 000000100 then the third digit from the
				// right is a 1 and we so include 3. The second operand in the
				// bitwise AND is always a power of 2.

				for (int n = 0; n < 512; n++)
				{
					var nthCombo = new List<int>(9);

					for (int i = 0; i < 9; i++)
					{
						// 1, 2, 4, 8, 16, 32 etc
						var pow = (int)Math.Pow(2, i);

						// Bitwise AND
						if ((n & pow) == pow)
						{
							nthCombo.Add(i + 1);
						}
					}

					setCombos.Add(nthCombo);
				}
			};

			populateSetCombos(firstSetCombos);
			populateSetCombos(secondSetCombos);

			void assertEqual(List<int> firstSet, List<int> secondSet)
			{
				firstSet.Count.Should().Be(secondSet.Count);

				for (int i = 0; i < firstSet.Count; i++)
				{
					firstSet[i].Should().Be(secondSet.ElementAt(i));
				}
			};

			void assertNotEqual(List<int> firstSet, List<int> secondSet)
			{
				bool proven = firstSet.Count != secondSet.Count;

				for (int i = 0; i < firstSet.Count && !proven; i++)
				{
					if (firstSet.ElementAt(i) != secondSet.ElementAt(i))
					{
						proven = true;
					}
				}

				proven.Should().BeTrue();
			};

			var cut = new PencilMarksComparer();

			foreach (List<int> firstSet in firstSetCombos)
			{
				foreach (List<int> secondSet in secondSetCombos)
				{
					// Act
					if (cut.Equals(firstSet, secondSet))
					{
						// Assert
						assertEqual(firstSet, secondSet);
					}
					else
					{
						// Assert
						assertNotEqual(firstSet, secondSet);
					}
				}
			}
		}

		public void Two_sets_of_pencil_marks_have_the_same_hashcode_if_they_are_the_same_and_different_hashcodes_otherwise()
		{

		}
	}
}

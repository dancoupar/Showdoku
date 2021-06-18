using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Showdoku
{
	public class PencilMarkSetComparerTests
	{
		[Fact]
		public void Two_sets_of_pencil_marks_are_deemed_equal_if_they_contain_the_same_pencil_marks_and_not_equal_otherwise()
		{
			// Arrange

			// Test every possible combination of pencil marks with every
			// other possible combination of pencil marks. There are 512
			// possible combinations (2^9) for a single set of pencil marks.

			List<PencilMarkSet> firstSetCombos = GetAllPencilMarkSetCominations();
			List<PencilMarkSet> secondSetCombos = GetAllPencilMarkSetCominations();
			
			var cut = new PencilMarkSetComparer();

			foreach (PencilMarkSet firstSet in firstSetCombos)
			{
				foreach (PencilMarkSet secondSet in secondSetCombos)
				{
					// Act
					if (cut.Equals(firstSet, secondSet))
					{
						// Assert
						AssertEqual(firstSet, secondSet);
					}
					else
					{
						// Assert
						AssertNotEqual(firstSet, secondSet);
					}
				}
			}
		}

		[Fact]
		public void Two_sets_of_pencil_marks_have_the_same_hashcode_if_they_contain_the_same_pencil_marks_and_different_hashcodes_otherwise()
		{
			// Arrange

			// Test every possible combination of pencil marks with every
			// other possible combination of pencil marks. There are 512
			// possible combinations (2^9) for a single set of pencil marks.

			List<PencilMarkSet> firstSetCombos = GetAllPencilMarkSetCominations();
			List<PencilMarkSet> secondSetCombos = GetAllPencilMarkSetCominations();

			var cut = new PencilMarkSetComparer();

			foreach (PencilMarkSet firstSet in firstSetCombos)
			{
				foreach (PencilMarkSet secondSet in secondSetCombos)
				{
					// Act
					if (cut.GetHashCode(firstSet) == cut.GetHashCode(secondSet))
					{
						// Assert
						AssertEqual(firstSet, secondSet);
					}
					else
					{
						// Assert
						AssertNotEqual(firstSet, secondSet);
					}
				}
			}
		}

		private static List<PencilMarkSet> GetAllPencilMarkSetCominations()
		{
			// Cycle through each combination using a simple integer as the
			// key, treated as a binary number. For example, for the 100th
			// iteration, 100 is 001100100. If we want to know whether we
			// should erase 3 from the set of pencil marks we need to know
			// whether the third digit from the right is a 0 or a 1. To do
			// that a bitwise AND is performed on 001100100 and 000000100.
			// If the result is 000000100 then the third digit from the
			// right is a 1 and we so erase 3. The second operand in the
			// bitwise AND is always a power of 2.

			var setCombos = new List<PencilMarkSet>();

			for (int n = 0; n < 512; n++)
			{
				var nthCombo = new PencilMarkSet();

				for (int i = 0; i < 9; i++)
				{
					// 1, 2, 4, 8, 16, 32 etc
					var pow = (int)Math.Pow(2, i);

					// Bitwise AND
					if ((n & pow) == pow)
					{
						nthCombo.Erase(i + 1);
					}
				}

				setCombos.Add(nthCombo);
			}

			return setCombos;
		}

		private static void AssertEqual(PencilMarkSet firstSet, PencilMarkSet secondSet)
		{
			firstSet.Count().Should().Be(secondSet.Count());

			for (int i = 0; i < firstSet.Count(); i++)
			{
				firstSet.ElementAt(i).Should().Be(secondSet.ElementAt(i));
			}
		}

		private static void AssertNotEqual(PencilMarkSet firstSet, PencilMarkSet secondSet)
		{
			bool proven = firstSet.Count() != secondSet.Count();

			for (int i = 0; i < firstSet.Count() && !proven; i++)
			{
				if (firstSet.ElementAt(i) != secondSet.ElementAt(i))
				{
					proven = true;
				}
			}

			proven.Should().BeTrue();
		}
	}
}

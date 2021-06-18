using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace Showdoku
{
	public class PencilMarkSetTests
	{
		[Fact]
		public void A_new_pencil_mark_set_contains_nine_pencil_marks()
		{
			// Arrange
			// Act
			var cut = new PencilMarkSet();

			// Assert
			cut.Count().Should().Be(9);

			cut.Should().Contain(1);
			cut.Should().Contain(2);
			cut.Should().Contain(3);
			cut.Should().Contain(4);
			cut.Should().Contain(5);
			cut.Should().Contain(6);
			cut.Should().Contain(7);
			cut.Should().Contain(8);
			cut.Should().Contain(9);
		}

		[Fact]
		public void Erasing_a_pencil_mark_removes_it_from_the_set()
		{
			// Arrange
			var cut = new PencilMarkSet();

			// Act
			cut.Erase(5);

			// Assert
			cut.Should().NotContain(5);
		}

		[Fact]
		public void Erasing_an_already_erased_pencil_mark_has_no_effect_on_the_set()
		{
			// Arrange
			var cut = new PencilMarkSet();

			// Act
			cut.Erase(5);
			cut.Erase(5);

			// Assert
			cut.Count().Should().Be(8);
		}

		[Fact]
		public void Erasing_a_pencil_mark_throws_if_the_specified_value_is_less_than_one()
		{
			// Arrange
			var cut = new PencilMarkSet();

			// Act
			Action act = () =>
			{
				cut.Erase(0);
			};

			// Assert
			act.Should().Throw<ArgumentOutOfRangeException>();
		}

		[Fact]
		public void Erasing_a_pencil_mark_throws_if_the_specified_value_is_more_than_nine()
		{
			// Arrange
			var cut = new PencilMarkSet();

			// Act
			Action act = () =>
			{
				cut.Erase(10);
			};

			// Assert
			act.Should().Throw<ArgumentOutOfRangeException>();
		}

		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		[InlineData(3)]
		[InlineData(4)]
		[InlineData(5)]
		[InlineData(6)]
		[InlineData(8)]
		[InlineData(9)]
		public void Erasing_a_pencil_mark_between_one_and_nine_throws(int pencilMark)
		{
			// Arrange
			var cut = new PencilMarkSet();

			// Act
			Action act = () =>
			{
				cut.Erase(pencilMark);
			};

			// Assert
			act.Should().NotThrow();
		}

		[Fact]
		public void Erasing_all_pencil_marks_clears_the_set()
		{
			// Arrange
			var cut = new PencilMarkSet();

			// Act
			cut.EraseAll();

			// Assert
			cut.Count().Should().Be(0);
		}

		[Fact]
		public void Resetting_a_set_reinitialises_it_with_nine_pencil_marks()
		{
			// Arrange
			var cut = new PencilMarkSet();
			cut.Erase(1);
			cut.Erase(2);
			cut.Erase(3);

			// Act
			cut.Reset();

			// Assert
			cut.Count().Should().Be(9);
		}
	}
}

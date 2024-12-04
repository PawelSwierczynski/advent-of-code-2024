using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Tasks.Tests
{
	public class MullItOverTaskTest
	{
		[Test]
		public void ExecuteInitialTask_ExampleIsProvided_ReturnsCorrectValue()
		{
			var input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
			var expected = "161";
			var mullItOverTask = new MullItOverTask();

			var actual = mullItOverTask.ExecuteInitialTask(input);

			actual.Should().Be(expected);
		}

		[Test]
		public void ExecuteAdvancedTask_ExampleIsProvided_RetursCorrectValue()
		{
			var input = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
			var expected = "48";
			var mullItOverTask = new MullItOverTask();

			var actual = mullItOverTask.ExecuteAdvancedTask(input);

			actual.Should().Be(expected);
		}
	}
}

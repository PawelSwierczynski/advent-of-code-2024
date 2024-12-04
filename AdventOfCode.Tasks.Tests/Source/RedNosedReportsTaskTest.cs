using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Tasks.Tests
{
	public class RedNosedReportsTaskTest
	{
		[Test]
		public void ExecuteInitialTask_ExampleIsProvided_ReturnsCorrectValue()
		{
			var input = "7 6 4 2 1\r\n1 2 7 8 9\r\n9 7 6 2 1\r\n1 3 2 4 5\r\n8 6 4 4 1\r\n1 3 6 7 9";
			var expected = "2";
			var redNosedReportsTask = new RedNosedReportsTask();

			var actual = redNosedReportsTask.ExecuteInitialTask(input);

			actual.Should().Be(expected);
		}

		[Test]
		public void ExecuteAdvancedTask_ExampleIsProvided_ReturnsCorrectValue()
		{
			var input = "7 6 4 2 1\r\n1 2 7 8 9\r\n9 7 6 2 1\r\n1 3 2 4 5\r\n8 6 4 4 1\r\n1 3 6 7 9";
			var expected = "4";
			var redNosedReportsTask = new RedNosedReportsTask();

			var actual = redNosedReportsTask.ExecuteAdvancedTask(input);

			actual.Should().Be(expected);
		}
	}
}

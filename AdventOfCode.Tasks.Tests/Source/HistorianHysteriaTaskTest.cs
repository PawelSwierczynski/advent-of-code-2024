using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Tasks.Tests
{
	public class HistorianHysteriaTaskTest
	{
		[Test]
		public void ExecuteInitialTask_ExampleIsProvided_ReturnsCorrectValue()
		{
			var input = "3   4\r\n4   3\r\n2   5\r\n1   3\r\n3   9\r\n3   3";
			var expected = "11";
			var historianHysteriaTask = new HistorianHysteriaTask();

			var actual = historianHysteriaTask.ExecuteInitialTask(input);

			actual.Should().Be(expected);
		}

		[Test]
		public void ExecuteAdvancedTask_ExampleIsProvided_ReturnsCorrectValue()
		{
			var input = "3   4\r\n4   3\r\n2   5\r\n1   3\r\n3   9\r\n3   3";
			var expected = "31";
			var historianHysteriaTask = new HistorianHysteriaTask();

			var actual = historianHysteriaTask.ExecuteAdvancedTask(input);

			actual.Should().Be(expected);
		}
	}
}

using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Tasks.Tests
{
	public class HystorianHysteriaTaskTest
	{
		[Test]
		public void ExecuteFirstTask_ExampleIsProvided_ReturnsCorrectValue()
		{
			var input = "3   4\r\n4   3\r\n2   5\r\n1   3\r\n3   9\r\n3   3";
			var expected = "11";
			var hystorianHysteriaTask = new HystorianHysteriaTask();

			var actual = hystorianHysteriaTask.ExecuteFirstTask(input);

			actual.Should().Be(expected);
		}
	}
}

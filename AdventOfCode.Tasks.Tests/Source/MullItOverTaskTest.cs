using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Tasks.Tests.Source
{
	public class MullItOverTaskTest
	{
		[Test]
		public void ExevuteFirstTask_ExampleIsProvided_ReturnsCorrectValue()
		{
			var input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
			var expected = "161";
			var mullItOverTask = new MullItOverTask();

			var actual = mullItOverTask.ExecuteFirstTask(input);

			actual.Should().Be(expected);
		}
	}
}

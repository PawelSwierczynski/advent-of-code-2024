using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Tasks.Tests
{
	public class CeresSearchTaskTest
	{
		[Test]
		public void ExecuteInitialTask_ExampleIsProvided_ReturnsCorrectValue()
		{
			var input = "MMMSXXMASM\r\nMSAMXMSMSA\r\nAMXSXMAAMM\r\nMSAMASMSMX\r\nXMASAMXAMM\r\nXXAMMXXAMA\r\nSMSMSASXSS\r\nSAXAMASAAA\r\nMAMMMXMMMM\r\nMXMXAXMASX";
			var expected = "18";
			var ceresSearchTask = new CeresSearchTask();

			var actual = ceresSearchTask.ExecuteInitialTask(input);

			actual.Should().Be(expected);
		}
	}
}

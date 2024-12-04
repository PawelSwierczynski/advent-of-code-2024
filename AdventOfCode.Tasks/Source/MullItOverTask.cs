using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Tasks
{
	public class MullItOverTask : AdventTask
	{
		private const string MultiplierGroupName = "Multiplier";
		private const string MultiplicandGroupName = "Multiplicand";
		private static readonly Regex multiplySyntax =
			new Regex($@"mul\((?<{MultiplierGroupName}>[0-9]{{1,3}}),(?<{MultiplicandGroupName}>[0-9]{{1,3}})\)", RegexOptions.Singleline);
		private static readonly Regex disableSyntax = new Regex(@"don\'t\(\).*?((do\(\))|$)", RegexOptions.Singleline);

		public override string Name => "Day 3: Mull It Over";

		public override string ExecuteInitialTask(string input)
		{
			var matchedMultiplications = multiplySyntax.Matches(input);

			return matchedMultiplications
				.Select(m => int.Parse(m.Groups[MultiplierGroupName].Value) * int.Parse(m.Groups[MultiplicandGroupName].Value))
				.Sum()
				.ToString();
		}

		public override string ExecuteAdvancedTask(string input)
		{
			input = disableSyntax.Replace(input, string.Empty);

			return ExecuteInitialTask(input);
		}
	}
}

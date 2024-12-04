using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Tasks
{
	public class RedNosedReportsTask : AdventTask
	{
		private const int MinimumDifference = 1;
		private const int MaximumDifference = 3;
		private const char Separator = ' ';

		public override string Name => "Day 2: Red-Nosed Reports";

		public override string ExecuteInitialTask(string input)
		{
			var reports = ParseInput(input);

			return reports
				.Where(IsReportSafe)
				.Count()
				.ToString();
		}

		public override string ExecuteAdvancedTask(string input)
		{
			var reports = ParseInput(input);

			return reports
				.Where(IsReportConditionallySafe)
				.Count()
				.ToString();
		}

		private IEnumerable<IEnumerable<int>> ParseInput(string input)
		{
			return input
				.Trim()
				.Split(Environment.NewLine)
				.Select(r => r
					.Split(Separator)
					.Select(n => int.Parse(n)));
		}

		private bool IsReportSafe(IEnumerable<int> report)
		{
			var reportDifferences = report
				.Zip(report.Skip(1))
				.Select(d => d.First - d.Second);

			return reportDifferences.All(d => Math.Abs(d) >= MinimumDifference && Math.Abs(d) <= MaximumDifference) &&
				(reportDifferences.All(d => d < 0) || reportDifferences.All(d => d > 0));
		}

		private bool IsReportConditionallySafe(IEnumerable<int> report)
		{
			for (int i = 0; i < report.Count(); i++)
			{
				var subreport = report.ToList();
				subreport.RemoveAt(i);

				if (IsReportSafe(subreport))
				{
					return true;
				}
			}

			return false;
		}
	}
}

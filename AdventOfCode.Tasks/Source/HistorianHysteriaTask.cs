using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace AdventOfCode.Tasks;

public class HistorianHysteriaTask : AdventTask
{
	public override string Name => "Day 1: Historian Hysteria";

	public override string ExecuteInitialTask(string input)
	{
		var (firstLocationIds, secondLocationIds) = ParseLocationIds(input);

		firstLocationIds = firstLocationIds.OrderBy(l => l);
		secondLocationIds = secondLocationIds.OrderBy(l => l);

		var result = firstLocationIds
			.Zip(secondLocationIds, (f, s) => Math.Abs(f - s))
			.Sum(e => e);

		return result.ToString();
	}

	public override string ExecuteAdvancedTask(string input)
	{
		var (firstLocationIds, secondLocationIds) = ParseLocationIds(input);

		var groupedFirstLocationIds = GroupLocationIds(firstLocationIds);
		var groupedSecondLocationIds = GroupLocationIds(secondLocationIds);

		var result = 0;

		foreach (var groupedLocationId in groupedFirstLocationIds)
		{
			if (groupedSecondLocationIds.TryGetValue(groupedLocationId.Key, out int groupedSecondLocationCount))
			{
				result += groupedLocationId.Key * groupedLocationId.Value * groupedSecondLocationCount;
			}
		}

		return result.ToString();
	}

	private (IEnumerable<int>, IEnumerable<int>) ParseLocationIds(string input)
	{
		IEnumerable<LocationIds> parsedInput;

		var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = "   ", HasHeaderRecord = false };

		using (var stringReader = new StringReader(input))
		{
			using var csvReader = new CsvReader(stringReader, csvConfiguration);
			{
				parsedInput = csvReader.GetRecords<LocationIds>().ToList();
			}
		}

		return (parsedInput.Select(p => p.First), parsedInput.Select(p => p.Second));
	}

	private IDictionary<int, int> GroupLocationIds(IEnumerable<int> locationIds)
	{
		return locationIds.GroupBy(l => l).ToDictionary(g => g.Key, g => g.Count());
	}

	private struct LocationIds
	{
		[Index(0)]
		public int First { get; set; }
		[Index(1)]
		public int Second { get; set; }
	}
}

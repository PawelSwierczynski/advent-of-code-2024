using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace AdventOfCode.Tasks;

public class HystorianHysteriaTask : AdventTask
{
	public override string Name => "Day 1: Historian Hysteria";

	public override string ExecuteFirstTask(string input)
	{
		IEnumerable<Locations> parsedInput;

		var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = "   ", HasHeaderRecord = false };

		using (var stringReader = new StringReader(input))
		{
			using var csvReader = new CsvReader(stringReader, csvConfiguration);
			{
				parsedInput = csvReader.GetRecords<Locations>().ToList();
			}
		}

		var firstLocationIds = parsedInput.Select(p => p.First)
			.OrderBy(l => l)
			.ToList();

		var secondLocationIds = parsedInput.Select(p => p.Second)
			.OrderBy(l => l)
			.ToList();

		var result = 0;

		for (int i = 0; i < firstLocationIds.Count; i++)
		{
			result += Math.Abs(firstLocationIds[i] - secondLocationIds[i]);
		}

		return $"{result}";
	}

	private struct Locations
	{
		[Index(0)]
		public int First { get; set; }
		[Index(1)]
		public int Second { get; set; }
	}
}

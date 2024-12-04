using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace AdventOfCode.Tasks
{
	public class CeresSearchTask : AdventTask
	{
		private const char XLetter = 'X';
		private const string WordToMatch = "XMAS";
		private static readonly IEnumerable<Size> Directions = new List<Size>
		{
			new Size(-1, -1),
			new Size(-1, 0),
			new Size(-1, 1),
			new Size(0, -1),
			new Size(0, 1),
			new Size(1, -1),
			new Size(1, 0),
			new Size(1, 1)
		};

		public override string Name => "Day 4: Ceres Search";

		public override string ExecuteInitialTask(string input)
		{
			var lettersMatrix = new Dictionary<Point, char>();
			var xLetterCoordinates = new List<Point>();

			foreach (var (line, y) in input.Split(Environment.NewLine).Select((line, y) => (line, y)))
			{
				foreach (var (letter, x) in line.Select((letter, x) => (letter, x)))
				{
					lettersMatrix.Add(new Point(x, y), letter);

					if (letter == XLetter)
					{
						xLetterCoordinates.Add(new Point(x, y));
					}
				}
			}

			return xLetterCoordinates
				.Sum(x => XmasWordLocatedCount(lettersMatrix, x))
				.ToString();
		}

		public override string ExecuteAdvancedTask(string input)
		{
			return "";
		}

		private int XmasWordLocatedCount(IDictionary<Point, char> lettersMatrix, Point xLetterCoordinates)
		{
			var result = 0;

			foreach (var direction in Directions)
			{
				if (lettersMatrix.TryGetValue(xLetterCoordinates + direction, out char secondLetter) &&
					secondLetter == WordToMatch[1] &&
					lettersMatrix.TryGetValue(xLetterCoordinates + direction * 2, out char thirdLetter) &&
					thirdLetter == WordToMatch[2] &&
					lettersMatrix.TryGetValue(xLetterCoordinates + direction * 3, out char fourthLetter) &&
					fourthLetter == WordToMatch[3])
				{
					result++;
				}
			}

			return result;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode.Tasks
{
	public class CeresSearchTask : AdventTask
	{
		private const char XLetter = 'X';
		private const char ALetter = 'A';
		private const string WordToMatch = "XMAS";
		private static readonly Size SouthwesternDirection = new Size(-1, -1);
		private static readonly Size NorthwesternDirection = new Size(-1, 1);
		private static readonly Size NortheasternDirection = new Size(1, 1);
		private static readonly Size SoutheasternDirection = new Size(1, -1);
		private static readonly IEnumerable<Size> AllDirections = new List<Size>
		{
			SouthwesternDirection,
			NorthwesternDirection,
			NortheasternDirection,
			SoutheasternDirection,
			new Size(-1, 0),
			new Size(0, -1),
			new Size(0, 1),
			new Size(1, 0),
		};
		private static readonly IEnumerable<Size> OrthogonalDirections = new List<Size>
		{
			SouthwesternDirection,
			NorthwesternDirection,
			NortheasternDirection,
			SoutheasternDirection
		};
		private static readonly HashSet<char> LettersToMatchInCross = new HashSet<char> { 'M', 'S' };
		private static readonly HashSet<string> CrossSequencesToMatch = new HashSet<string> //TODO: Make an extension to "shift" strings
		{
			"MMSS",
			"SMMS",
			"SSMM",
			"MSSM"
		};

		public override string Name => "Day 4: Ceres Search";

		public override string ExecuteInitialTask(string input)
		{
			var (lettersMatrix, xLetterCoordinates) = ParseInput(input, XLetter);

			return xLetterCoordinates
				.Sum(x => XmasWordFoundCount(lettersMatrix, x))
				.ToString();
		}

		public override string ExecuteAdvancedTask(string input)
		{
			var (lettersMatrix, aLetterCoordinates) = ParseInput(input, ALetter);

			return aLetterCoordinates
				.Where(a => IsXmasCrossFound(lettersMatrix, a))
				.Count()
				.ToString();
		}

		private (IDictionary<Point, char> LettersMatrix, IEnumerable<Point> LetterToMatchCoordinates) ParseInput(string input, char letterToMatch)
		{
			var lettersMatrix = new Dictionary<Point, char>();
			var letterToMatchCoordinates = new List<Point>();

			foreach (var (line, y) in input.Split(Environment.NewLine).Select((line, y) => (line, y)))
			{
				foreach (var (letter, x) in line.Select((letter, x) => (letter, x)))
				{
					lettersMatrix.Add(new Point(x, y), letter);

					if (letter == letterToMatch)
					{
						letterToMatchCoordinates.Add(new Point(x, y));
					}
				}
			}

			return (lettersMatrix, letterToMatchCoordinates);
		}

		private int XmasWordFoundCount(IDictionary<Point, char> lettersMatrix, Point xLetterCoordinates)
		{
			var result = 0;

			foreach (var direction in AllDirections)
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

		private bool IsXmasCrossFound(IDictionary<Point, char> lettersMatrix, Point aLetterCoordinates)
		{
			var orthogonalLetters = string.Empty;

			foreach (var orthogonalDirection in OrthogonalDirections)
			{
				if (lettersMatrix.TryGetValue(aLetterCoordinates + orthogonalDirection, out char letter)
					&& LettersToMatchInCross.Contains(letter))
				{
					orthogonalLetters += letter;
				}
				else
				{
					return false;
				}
			}

			return CrossSequencesToMatch.Contains(orthogonalLetters);
		}
	}
}

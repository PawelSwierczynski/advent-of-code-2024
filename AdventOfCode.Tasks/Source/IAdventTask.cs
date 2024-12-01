namespace AdventOfCode.Tasks.Source
{
	public interface IAdventTask
	{
		public string Name { get; }

		public string Execute(string input);
	}
}

namespace AdventOfCode.Tasks.Source
{
	public interface IAdventTask
	{
		public string Name { get; set; }

		public string Execute(string input);
	}
}

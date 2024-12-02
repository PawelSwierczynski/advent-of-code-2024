namespace AdventOfCode.Tasks
{
	public abstract class AdventTask
	{
		public abstract string Name { get; }

		public abstract string ProcessInput(string input);
	}
}

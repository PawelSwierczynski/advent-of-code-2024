namespace AdventOfCode.Tasks
{
	public abstract class AdventTask
	{
		public abstract string Name { get; }

		public abstract string ExecuteInitialTask(string input);
		public abstract string ExecuteAdvancedTask(string input);
	}
}

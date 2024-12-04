namespace AdventOfCode.Tasks
{
	public abstract class AdventTask
	{
		public abstract string Name { get; }

		public abstract string ExecuteFirstTask(string input);
		public abstract string ExecuteSecondTask(string input);
	}
}

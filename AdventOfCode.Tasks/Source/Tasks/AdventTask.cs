namespace AdventOfCode.Tasks
{
	public abstract class AdventTask
	{
		protected static readonly IInputParseable inputParser;

		public abstract string Name { get; }

		public abstract string ProcessInput(string input);
	}
}

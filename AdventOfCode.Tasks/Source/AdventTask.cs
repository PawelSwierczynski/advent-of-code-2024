namespace AdventOfCode.Tasks
{
	public abstract class AdventTask<T>
	{
		public abstract string Name { get; }

		protected abstract IInputParseable<T> InputParser { get; }

		public string Execute(string input)
		{
			var parsedInput = InputParser.Parse(input);

			return ProcessInput(parsedInput);
		}

		protected abstract string ProcessInput(T parsedInput);
	}
}

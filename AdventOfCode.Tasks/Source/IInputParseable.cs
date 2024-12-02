namespace AdventOfCode.Tasks
{
	public interface IInputParseable<T>
	{
		public T Parse(string input);
	}
}

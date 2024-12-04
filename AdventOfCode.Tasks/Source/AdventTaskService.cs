using System.Collections.Generic;

namespace AdventOfCode.Tasks
{
	public class AdventTaskService
	{
		public IEnumerable<AdventTask> AdventTasks { get; }

		public AdventTaskService()
		{
			AdventTasks = new List<AdventTask>
			{
				new HystorianHysteriaTask(),
				new MullItOverTask(),
			};
		}
	}
}

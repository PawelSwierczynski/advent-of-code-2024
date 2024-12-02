using System.Collections;
using System.Collections.Generic;

namespace AdventOfCode.Tasks
{
	public class AdventTaskService
	{
		public IEnumerable<string> AdventTasks { get; }

		public AdventTaskService()
		{
			AdventTasks = new List<AdventTask>
			{
				new HystorianHysteriaTask()
			};
		}
	}
}

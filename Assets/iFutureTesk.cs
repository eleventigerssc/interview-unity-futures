using UnityEngine;
using System.Collections;

namespace Futures
{
	public interface IFutureTask<T> where T : struct
	{
		YieldInstruction Run();

		T? Get();

		bool IsDone();
	}
}

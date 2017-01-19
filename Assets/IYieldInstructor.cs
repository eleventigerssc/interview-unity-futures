using UnityEngine;
using System.Collections;

namespace Futures 
{
	public interface IYieldInstructor 
	{
		YieldInstruction Call(IEnumerator ienumerator);
	}
}

using System;
using UnityEngine;
using System.Collections;

namespace Futures 
{
	public sealed class FutureTask<T> : IFutureTask<T> where T : struct
	{	
		public static IFutureTask<R> From<R>(IEnumerator task, IYieldInstructor yieldInstructor) where R : struct
		{
			return null;
		}
	}
}

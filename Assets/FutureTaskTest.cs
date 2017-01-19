using UnityEngine;
using System;
using System.Collections;

namespace Futures
{
	public class FutureTaskTest : MonoBehaviour, IYieldInstructor {

		struct Response 
		{
			public string Message;

			public override string ToString() 
			{
				return "Response: " + Message;
			}
		}

		private IFutureTask<Response> task;

		void Update()
		{
			if (task != null && task.IsDone ()) {
				try 
				{
					var taskResult = task.Get();
					Debug.Log ("Task has completed with the result: " + taskResult);
				} 
				catch (Exception e) 
				{
					Debug.LogError ("Task has completed with the exception: " + e);
				}	
				task = null;
			}
		}

		void OnGUI() 
		{
			if (task == null && GUILayout.Button ("Run")) 
			{
				task = FutureTask<Response>.From<Response> (CreateTestTask (), this);
				Debug.Log ("Running task: " + task);
				task.Run ();
			}
		}
		
		private IEnumerator CreateTestTask()
		{
			yield return new WaitForSeconds (UnityEngine.Random.value * 5);
			if (UnityEngine.Random.value > 0.5) 
			{
				yield return new Response{ Message = "Current time is: " + System.DateTime.Now };
			} 
			else 
			{
				throw new Exception ("Failed to get response");
			}

		}

		public YieldInstruction Call(IEnumerator ienumerator) 
		{
			return StartCoroutine (ienumerator);
		}
	}
}
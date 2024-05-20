#if UNITY_5_3 || UNITY_5_3_OR_NEWER

using UnityEngine.SceneManagement;
#endif

using UnityEngine;

namespace MvR
{
	public class LoadLevel : MonoBehaviour
	{
		public string levelName = "CSStressTest"; // Level name to load.

		/// <summary>
		/// Activate this instance.
		/// </summary>
		public void Activate()
		{
			#if UNITY_5_3 || UNITY_5_3_OR_NEWER

			SceneManager.LoadScene(levelName);
			#else
			Application.LoadLevel(levelName);
			#endif
		}
	}
}

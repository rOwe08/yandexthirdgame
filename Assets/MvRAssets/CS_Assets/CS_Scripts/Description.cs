#if UNITY_5_3 || UNITY_5_3_OR_NEWER

using UnityEngine.SceneManagement;
#endif

using UnityEngine;
using YG;

namespace MvR
{
	/// <summary>
	/// This script displays a simple description within a defined size and position.
	/// This GUI element is very primitive  and is not recommended for your full project.
	/// Instead you should consider using a more robust and advanced GUI system than what is
	/// available natively in Unity (21/8/2013) such as EZGUI or NGUI.
	/// </summary>
	public class Description : MonoBehaviour
	{
		public Rect positionAndSize = new Rect(100, 100, 600, 400); // Location and size of the description box.

		private string description;
		public string[] desc;
		public GUISkin guiSkin;

		/// <summary>
		/// OnGUI is called for rendering and handling GUI events.
		/// This means that your OnGUI implementation might be called several times per frame (one call per event).
		/// For more information on GUI events see the Event reference. If the MonoBehaviour's enabled property is
		/// set to false, OnGUI() will not be called.
		/// </summary>
		public void OnGUI()
		{
			GUI.skin = guiSkin;

			if(YandexGame.EnvironmentData.language == "ru")
			{
				description = desc[0];
			}
			else
			{
                description = desc[1];
            }

			GUI.Label(positionAndSize, description);

			// A button which goes back to the start menu

			string ruText = "В меню";
			string enText = "Back To Menu";
			string textToShow;

			if(YandexGame.EnvironmentData.language == "ru") 
			{
				textToShow = ruText;
			}
            else
			{ 
				textToShow = enText;
            }
            if ( GUI.Button(new Rect((Screen.width - 300) * 0.5f, Screen.height - 60, 300, 50), textToShow) )
			{
				if( GetComponent<AudioSource>() )
					GetComponent<AudioSource>().Play();
		
				#if UNITY_5_3 || UNITY_5_3_OR_NEWER

				SceneManager.LoadScene("CSStartMenu");
				#else
				Application.LoadLevel("CSStartMenu");
				#endif
			}
	
			GUI.Label(positionAndSize, string.Empty);
		}
	}
}

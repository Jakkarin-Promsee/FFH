using UnityEngine;
using System.Collections;

namespace SlimUI.ModernMenu
{
	public class CheckMusicVolume : MonoBehaviour
	{
		public void Start()
		{
			if (!PlayerPrefs.HasKey("MusicVolume"))
			{
				PlayerPrefs.SetFloat("MusicVolume", 0.5f); // Default volume
				PlayerPrefs.Save();
			}

			// remember volume level from last time
			GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
		}

		public void UpdateVolume()
		{
			GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
		}
	}
}
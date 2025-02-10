using UnityEngine;
using System.Collections;

namespace SlimUI.ModernMenu
{
	public class CheckMusicVolume : MonoBehaviour
	{
		public Db db;
		public void Start()
		{
			// remember volume level from last time
			GetComponent<AudioSource>().volume = db.MusicVolume;
			GetComponent<AudioSource>().volume = db.MusicVolume;
		}

		public void UpdateVolume()
		{
			// GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
			GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
			db.MusicVolume = PlayerPrefs.GetFloat("MusicVolume");
		}
	}
}
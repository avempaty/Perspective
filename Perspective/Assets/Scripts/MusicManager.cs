using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip mainTheme;
	public AudioClip menuTheme;

	void Start() {
		/*bool startTrack = true;
		AudioSource[] allAudioSources = FindObjectsOfType (AudioSource);
		for (int i = 0; i < allAudioSources.Length; i++) {
			if (allAudioSources [i].isPlaying == true) {
				startTrack = false;
			}
		}*/
		//if (startTrack) {
		AudioManager.instance.PlayMusic (menuTheme, 2);
		//}
	}

	void Update () {
		/*if (Input.GetKeyDown (KeyCode.Space)) {
			AudioManager.instance.PlayMusic (mainTheme, 3);
		}
		*/
	}
}
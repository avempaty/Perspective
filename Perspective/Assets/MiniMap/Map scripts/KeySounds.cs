using UnityEngine;
using System.Collections;

public class KeySounds : MonoBehaviour {

	// Use this for initialization
	public AudioSource[] audio;
	public AudioSource audio1;
	public KeyInteractions keyPickUp;
	void Start () {
		keyPickUp = GameObject.Find ("PlayerRobot").GetComponent<KeyInteractions> ();
		audio = GetComponents<AudioSource> ();
		print (audio[0]);
		//print (audio [1]);
		audio1 = audio [1];

	}
	
	// Update is called once per frame
	void Update () {
		//print ("Key is Found: " + keyPickUp.keyIsFound);
		if (keyPickUp.keyClip == true) {
			print ("Hello I am here");
			if (audio1.isPlaying) {
				
			} else {
				
				audio1.Play();
			}
			keyPickUp.keyClip = false;
		}
	}
}

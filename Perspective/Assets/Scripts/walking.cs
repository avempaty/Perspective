using UnityEngine;
using System.Collections;

public class walking : MonoBehaviour {

	public AudioSource[] audio;
	public bool running = false;
	public Orientation orient;
	public KeyInteractions key;
	public AudioClip audioClip;
	public AudioSource audio1;
	public AudioSource audio2;
	public AudioSource audio3;
	public AudioSource audio4;
	public AudioSource audio5;

	// Use this for initialization
	void Start () {
		orient = GameObject.Find("PlayerRobot").GetComponent<Orientation> ();
		key = GameObject.Find ("PlayerRobot").GetComponent<KeyInteractions> ();
		audio = GetComponents<AudioSource> ();
		audio1 = audio [0];
		audio2 = audio [1];
		audio3 = audio [2];
		audio4 = audio [3];
	}
	
	// Update is called once per frame
	void Update () {
		//print (orient.wallswitch);
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D)) {
			//audio.clip = AudioFile;
			running = true;
			//audio.Play();
		} else {
			running = false;
		}
		if (orient.wallswitch == true) {
			if (audio2.isPlaying) {
			} else {
				audio2.Play ();
			}
			orient.wallswitch = false;
		}
		if (orient.failwallswitch == true) {
			if (audio3.isPlaying) {
			} else {
				audio3.Play ();
			}
			orient.failwallswitch = false;
		}
		if (key.keyClip == true) {
			if (audio4.isPlaying) {
			} else {
				audio4.Play ();
			}
			key.keyClip = false;
		}
		PlayFootsteps ();
	}

	void PlayFootsteps() {
		if (orient.paused == true) {
			if (running) {
				if (audio1.isPlaying) {

				} else {
					audio1.Play ();
				}
			} else {
				audio1.Stop ();
			}
		} else {
			audio1.Stop ();
		}
	}
}

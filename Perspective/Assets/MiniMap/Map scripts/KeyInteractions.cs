using UnityEngine;
using System.Collections;

public class KeyInteractions : MonoBehaviour {

	bool showSubs;
	string sub;
	float timeLeft = 3.0f;
	private GUIStyle g = new GUIStyle();
	bool keyIsFound = false;
	public bool keyClip = false;
	//AudioClip collectSound;

	public void OnTriggerEnter(Collider other ) {
		print ("hello");
		if (other.gameObject.CompareTag ("key")) {
			timeLeft = 3.0f;
			//AudioSource.PlayClipAtPoint(collectSound, transform.position);
			print ("I picked up the key!");
			keyClip = true;

			other.gameObject.SetActive (false);
			keyIsFound = true;
			//GameObject.Find ("Door").SetActive (false);
			sub = "Picked up key";
			showSubs = true;
			print (showSubs);

		}
		if (other.gameObject.CompareTag ("door")) {
			if (keyIsFound == true) {
				//other.gameObject.SetActive (false);
				print("hi");
				Vector3 coor = new Vector3 (0, -1, 0);
				Physics.gravity = coor * 10;
				//Application.LoadLevel ("Map 2 (button)");
			}
		}
		//if (keyClip == true) {
		//	keyClip = false;
		//}
	}
	void Update()
	{
	
	}
	void OnGUI() {
		if (showSubs) {
			g.fontSize = 30;
			g.normal.textColor = Color.white;
			GUI.Label (new Rect (0, Screen.height - 100, 100, 100), sub, g);
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0) {
				showSubs = false;
			}
		}
	}
}


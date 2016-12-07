using UnityEngine;
using System.Collections;

public class MapInteractions : MonoBehaviour {

	bool showSubs = false;
	string sub;
	float timeLeft = 5.0f;
	private GUIStyle g = new GUIStyle();
	bool button1 = false;
	bool button2 = false;
	bool button3 = false;
	public GameObject buttonPressed;
	public GameObject buttonClick;
	public GameObject buttonCylinder;
	public GameObject buttonPlane;
	bool keyIsFound = false;
	public bool keyClip = false;
	void Update () {
		RaycastHit hit = new RaycastHit ();
		Vector3 fwd = transform.TransformDirection (Vector3.forward);

		if (Input.GetKeyDown (KeyCode.E)) { //if E is pressed do...
			print("hi");
			if (Physics.Raycast (transform.position, fwd, out hit, 3)) { //is there an object in front
				print(hit.collider.gameObject.tag);
				print(hit.collider.gameObject.name);
				if (hit.collider.gameObject.tag == "test") {
					timeLeft = 5.0f;
					sub = "Hit button";
					//button1 = hit.collider.gameObject;
					buttonPressed = hit.collider.gameObject;
					if (buttonPressed.GetComponent<ButtonPress>().pressed == false) {
						buttonPressed.GetComponent<ButtonPress> ().pressed = true;
						string buttonName = buttonPressed.gameObject.name + " click";
						buttonClick = buttonPressed.transform.Find (buttonName).gameObject;
						print (buttonClick.name);
						buttonClick.transform.Find ("Button Cylinder").gameObject.GetComponent<Renderer> ().material.color = new Color (0, 255, 0);
						buttonClick.transform.Find ("Button Plane").gameObject.GetComponent<Renderer> ().material.color = new Color (0, 255, 0);

						//buttonPressed.transform.FindChild ("Button Cylinder").gameObject.GetComponent<Renderer> ().material.color = new Color (0, 255, 0);
						//buttonPressed.transform.FindChild ("Button Plane").gameObject.GetComponent<Renderer> ().material.color = new Color (0, 255, 0);
						string wallName = "switch " + buttonPressed.name;
						if (buttonPressed.GetComponent<ButtonPress> ().effect == 1) {
							//GameObject.Find (wallName).gameObject.GetComponent<Renderer> ().enabled = false;
							//GameObject.Find(wallName).gameObject.SetActive(false);
							GameObject.Find(wallName).gameObject.transform.Translate(new Vector3(0, 1000, 0));
							//Resources.FindObjectsOfTypeAll<GameObject>
						} else if (buttonPressed.GetComponent<ButtonPress> ().effect == 2) {
							GameObject.Find (wallName).gameObject.GetComponent<Renderer> ().material.color = new Color (255, 255, 255);
							GameObject.Find (wallName).gameObject.tag = "wall";
						}
					} else {
						buttonPressed.GetComponent<ButtonPress> ().pressed = false;
						string buttonName = buttonPressed.gameObject.name + " click";
						buttonClick = buttonPressed.transform.Find (buttonName).gameObject;
						print (buttonClick.name);
						buttonClick.transform.Find ("Button Cylinder").gameObject.GetComponent<Renderer> ().material.color = new Color (255, 0, 0);
						buttonClick.transform.Find ("Button Plane").gameObject.GetComponent<Renderer> ().material.color = new Color (255, 0, 0);

						string wallName = "switch " + buttonPressed.name;
						if (buttonPressed.GetComponent<ButtonPress> ().effect == 1) {
							//GameObject.Find (wallName).gameObject.GetComponent<Renderer> ().enabled = true;
							//GameObject.Find(wallName).gameObject.SetActive(true);
							GameObject.Find(wallName).gameObject.transform.Translate(new Vector3(0, -1000, 0));
						} else if (buttonPressed.GetComponent<ButtonPress> ().effect == 2) {
							GameObject.Find (wallName).gameObject.GetComponent<Renderer> ().material.color = new Color (0, 0, 0);
							GameObject.Find (wallName).gameObject.tag = "Untagged";
						}
					}
					showSubs = true;
					print("button1 " + button1);
				}
			}
		}
	}

	public void OnTriggerEnter(Collider other ) {
		print ("hello");
		if (other.gameObject.CompareTag ("key")) {
			timeLeft = 5.0f;
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
				Application.LoadLevel ("EndGame");
			}
		}
		//if (keyClip == true) {
		//	keyClip = false;
		//}
	}

	void OnGUI() {
		if (showSubs) {
			g.fontSize = 30;
			g.normal.textColor = Color.white;
			GUI.Label (new Rect (0, Screen.height - 100, Screen.width - 60, 40), sub, g);
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0) {
				showSubs = false;
			}
		}
	}

}

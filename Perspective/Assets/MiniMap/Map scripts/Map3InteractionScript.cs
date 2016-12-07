using UnityEngine;
using System.Collections;

public class Map3InteractionScript : MonoBehaviour {

	// Update is called once per frame
	bool showSubs = false;
	string sub;
	float timeLeft = 3.0f;
	private GUIStyle g = new GUIStyle();
	bool button1 = false;
	bool button2 = false;
	bool button3 = false;
	void Update () {
		RaycastHit hit = new RaycastHit ();
		Vector3 fwd = transform.TransformDirection (Vector3.forward);

		if (Input.GetKeyDown (KeyCode.E)) { //if E is pressed do...
			print("hi");
			if (Physics.Raycast (transform.position, fwd, out hit, 3)) { //is there an object in front
				print(hit.collider.gameObject.tag);
				if (hit.collider.gameObject.tag == "test") {
					timeLeft = 3.0f;
					sub = "Hit button";
					if (button1 == false) {
						button1 = true;
						GameObject.Find ("Button 1 Cylinder").gameObject.GetComponent<Renderer> ().material.color = new Color (0, 255, 0);
						GameObject.Find ("Button 1 Plane").gameObject.GetComponent<Renderer> ().material.color = new Color (0, 255, 0);
						GameObject.Find ("Switch Wall").gameObject.GetComponent<Renderer> ().material.color = new Color (255, 255, 255);
						GameObject.Find ("Switch Wall").gameObject.tag = "wall";
					} else {
						button1 = false;
						GameObject.Find ("Button 1 Cylinder").gameObject.GetComponent<Renderer> ().material.color = new Color (255, 0, 0);
						GameObject.Find ("Button 1 Plane").gameObject.GetComponent<Renderer> ().material.color = new Color (255, 0, 0);
						GameObject.Find ("Switch Wall").gameObject.GetComponent<Renderer> ().material.color = new Color (0, 0, 0);
						GameObject.Find ("Switch Wall").gameObject.tag = "Untagged";
					}
					showSubs = true;
					print("button1 " + button1);
				}
				/*if (hit.collider.gameObject.tag == "test 2") {
					timeLeft = 3.0f;
					sub = "Hit button 2";
					if (button2 == false) {
						button2 = true;
						GameObject.Find ("Button 2 Cylinder").gameObject.GetComponent<Renderer> ().material.color = new Color (0, 255, 0);
						GameObject.Find ("Button 2 Plane").gameObject.GetComponent<Renderer> ().material.color = new Color (0, 255, 0);

					} else {
						button2 = false;
						GameObject.Find ("Button 2 Cylinder").gameObject.GetComponent<Renderer> ().material.color = new Color (255, 0, 0);
						GameObject.Find ("Button 2 Plane").gameObject.GetComponent<Renderer> ().material.color = new Color (255, 0, 0);

					}
					showSubs = true;
					print("button2 " + button2);
				}
				if (hit.collider.gameObject.tag == "test 3") {
					timeLeft = 3.0f;
					sub = "Hit button 3";
					if (button3 == false) {
						button3 = true;
						GameObject.Find ("Button 3 Cylinder").gameObject.GetComponent<Renderer> ().material.color = new Color (0, 255, 0);
						GameObject.Find ("Button 3 Plane").gameObject.GetComponent<Renderer> ().material.color = new Color (0, 255, 0);

					} else {
						button3 = false;
						GameObject.Find ("Button 3 Cylinder").gameObject.GetComponent<Renderer> ().material.color = new Color (255, 0, 0);
						GameObject.Find ("Button 3 Plane").gameObject.GetComponent<Renderer> ().material.color = new Color (255, 0, 0);

					}
					showSubs = true;
					print("button3 " + button3);
				}*/
			}
		}

	}
	public void OnTriggerEnter(Collider other ) {
		print ("hi");
		if (other.gameObject.CompareTag ("door")) {
			
				//other.gameObject.SetActive (false);

				Vector3 coor = new Vector3 (0, -1, 0);
				Physics.gravity = coor * 10;
				Application.LoadLevel ("TestNewGame");
		}
		if (other.gameObject.CompareTag ("death")) {
			Vector3 coor = new Vector3 (0, -1, 0);
			Physics.gravity = coor * 10;
			Application.LoadLevel ("Death Scene");
		}
	}
	void OnGUI() 
	{
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

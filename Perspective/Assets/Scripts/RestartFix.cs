using UnityEngine;
using System.Collections;

public class RestartFix : MonoBehaviour {

	// Use this for initialization
	public bool paused = true;
	public GameObject pausePanel;
	// Update is called once per frame
	void Update () {
		if (paused) {
				Time.timeScale = 0;
				Cursor.visible = true;
				pausePanel.SetActive(true);
				//camera.enabled = false;
				paused = false;
				print ("Hello this is active");
			} else {
				Time.timeScale = 1;
				pausePanel.SetActive(false);
				//camera.enabled = true;
				Cursor.visible = false;
				paused = true;
				print ("noooooe");
			}
		}

}

using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {
	public GameObject pausePanel;
	public bool isPaused;
	public Camera camera;

	// Use this for initialization
	void Start () {
		//camera = GetComponent<Camera> ();
		isPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isPaused) {
			PauseGame (true);
		} else {
			PauseGame (false);
		}

		if (Input.GetButtonDown ("Cancel")) {
			switchPause ();
		}
	}

	void PauseGame(bool state) {
		if (state) {
			pausePanel.SetActive(true);
			camera.enabled = false;
			Time.timeScale = 0.0f;
		} else {
			Time.timeScale = 1.0f;
			camera.enabled = true;
			pausePanel.SetActive(false);
		}
	}
	public void switchPause() {
		if (isPaused) {
			isPaused = false;
		} else {
			isPaused = true;
		}
	}			
}
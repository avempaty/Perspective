using UnityEngine;
using System.Collections;

public class TimeTrialController : MonoBehaviour {

	public float timer = 0.0F;
	public bool show = true;
	public GUIStyle style = new GUIStyle();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (show == true) {
			timer += Time.deltaTime;
		} else {
		
		}
	}
	void OnGUI() {
		GUI.skin.box.fontSize = Screen.width / 50;
		GUI.Box (new Rect ((Screen.width / 40) - 10 , Screen.height / 40, (Screen.width / 20) + 20, (Screen.height / 20) + 10)	, "" + timer.ToString ("0.00"));
	}

}

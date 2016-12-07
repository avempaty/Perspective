using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetScore : MonoBehaviour {
	public Text txt;
	public float r;
	// Use this for initialization
	void Start () {
		txt = GameObject.Find ("Highscores").GetComponent<Text> ();
		r = PlayerPrefs.GetFloat ("highscore");
		txt.text = "Best Score\n" + r.ToString ("0.00") + " s";
		PlayerPrefs.DeleteAll ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

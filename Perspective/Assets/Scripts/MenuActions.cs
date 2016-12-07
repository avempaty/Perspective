using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour 
{
	//public string scenename;
	//public Orientation orient;
	private string level;
	//orient = GameObject.Find("PlayerRobot").GetComponent<Orientation> ();
	void Start() {
		//orient = GameObject.Find("PlayerRobot").GetComponent<Orientation> ();
		level = PlayerPrefs.GetString("loadlevel");
		Cursor.visible = true;
	}
	public void MENU_ACTION_GotoPage(string sceneName)
	{
		//scenename = SceneManager.GetActiveScene().name;
		//print(scenename);
		Application.LoadLevel (sceneName);
	}
	public void LoadLevel() {
		if (level != null) {
			Application.LoadLevel (level);
		} else {
			print ("no level to be loaded");
		}
	}
}

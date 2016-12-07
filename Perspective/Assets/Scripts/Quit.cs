using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour {
	public void ChangeToScene (int sceneToChangeTo)
	{
		if (sceneToChangeTo == 0) 
		{
			Application.Quit ();
		}
		else
		{ 
			Application.LoadLevel (sceneToChangeTo);
		}
	}
}
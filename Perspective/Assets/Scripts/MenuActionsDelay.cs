using UnityEngine;
using System.Collections;
using System.Threading;

public class MenuActionsDelay : MonoBehaviour 
{
	void Start()
	{
		Application.LoadLevel ("MainMenu");
		Thread.Sleep(5000);
	}
}

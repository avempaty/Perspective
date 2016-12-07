using UnityEngine;
using System.Collections;

public class PlayerMC : MonoBehaviour {

	private float speed = 6f;

	private bool paused = true;
	private Animator anim;
	private Vector3 movement;
	private CamMouseLook camera;
	private Rigidbody playerRigidBody;

	//private int floorMask;
	//private Rigidbody playerRigidBody;
	//private float camRayLength = 100f;

	void Awake () {

		/*anim = this.gameObject.GetComponent<Animator> ();
		//floorMask = LayerMask.GetMask ("Floor");
		playerRigidBody = GetComponent<Rigidbody> ();
		camera = Camera.main.GetComponent<CamMouseLook> ();*/

	}

	void Start () {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		//Cursor.lockState = CursorLockMode.Confined;
		Cursor.lockState = CursorLockMode.None;
	}
	/*void Animating (float h, float v) {
		bool walking = h != 0f || v != 0f;
		if (walking) {
			anim.SetInteger ("Speed", 2);
		} else {
			anim.SetInteger ("Speed", 0);
		}
	}*/

	void Update () {
		/*float translation = Input.GetAxis ("Vertical") * speed;
		float straffle = Input.GetAxis ("Horizontal") * speed;
		translation *= Time.deltaTime;
		straffle *= Time.deltaTime;

		transform.Translate (0, 0, translation);
		//playerRigidBody.MovePosition(new Vector3(straffle, 0, translation));
		if (Input.GetKeyDown ("escape")) {
			if (paused) {
				Time.timeScale = 0;
				Cursor.visible = true;
				camera.enabled = false;
				paused = false;
			} else {
				Time.timeScale = 1;
				//camera.enabled = true;
				Cursor.visible = false;
				paused = true;
			}

		}

		Animating (translation, straffle);*/
	}
}

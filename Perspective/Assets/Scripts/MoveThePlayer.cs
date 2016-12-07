using UnityEngine;
using System.Collections;

public class MoveThePlayer : MonoBehaviour {

	public float speed;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVeritical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVeritical);

		rb.AddForce (movement * speed);
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("endGame")) {
			other.gameObject.SetActive (false);
			Application.LoadLevel ("EndGame");
		}
	}
}

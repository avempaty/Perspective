using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;

public class Orientation : MonoBehaviour {

	public string scenename;
	public float speed = 6f;
	public GameObject wallClimb; // wall object
	public Vector3 myNormal;
	public Vector3 myPrevNormal;
	public Rigidbody playerRigidbody;
	public int canMove = 1;
	public GameObject pausePanel;
	public float totalRotation = 0;
	public float rotationAmount = 90f;
	public bool wallswitch = false;
	public bool failwallswitch = false;

	public Camera bloomcam;
	public BloomOptimized bloom;
	public bool paused = true;
	private CamMouseLook camera;
	private Animator anim;
	private bool jumping = false;

	void Awake () {
		paused = true;
	}

	// Use this for initialization
	void Start () {
		bloom = bloomcam.GetComponent<BloomOptimized> ();
		scenename = SceneManager.GetActiveScene ().name;
		print (scenename);
		PlayerPrefs.SetString ("loadlevel", scenename);
		Time.timeScale = 1;
		canMove = 1;
		paused = true;
		pausePanel.SetActive(false);
		playerRigidbody = GetComponent<Rigidbody> ();
		myNormal = Vector3.down;
		myPrevNormal = Vector3.down;
		//camera = Camera.GetComponent<CamMouseLook> ();
		//anim = this.gameObject.GetComponent<Animator>();
		anim = this.gameObject.GetComponent<Animator>();

	}

	void FixedUpdate() {
		if (canMove == 1) {
			float translation = Input.GetAxis ("Vertical") * speed;
			float straffle = Input.GetAxis ("Horizontal") * speed;
			//playerRigidbody.AddRelativeForce(new Vector3 (0, 0, translation));
			playerRigidbody.velocity = transform.forward * translation;
			playerRigidbody.velocity += transform.up * -10;
		}
	}

	IEnumerator BloomAnimation() {
		bloom.threshold = 0.2f;
		while (bloom.threshold < 1) {
			float increment = Time.deltaTime / 5f;
			bloom.threshold += increment;
			yield return null;
		}
		yield return null;
	}

	// Update is called once per frame
	void Update () {
		
		
		if (paused == true) {
			RaycastHit hit = new RaycastHit ();
			Vector3 fwd = transform.TransformDirection (Vector3.forward);

			if (Input.GetKeyDown (KeyCode.Space)) { //if Space is pressed do...
				canMove = 0;
				//playerRigidbody.velocity = Vector3.zero;
				if (Physics.Raycast (transform.position, fwd, out hit, 3)) { //is there an object in front
					print ("There is something in front of the object!");
					print (hit.collider.gameObject.tag);
					if (hit.collider.gameObject.tag == "wall") { // if object you hit was a wall
						print ("hit a wall");
						wallswitch = true; //meaning it will switch wall
						playerRigidbody.velocity = Vector3.zero;
						Vector3 coor = new Vector3 (hit.point.x, hit.point.y, hit.point.z); // raycast coordinates
						transform.position = coor; // to teleport

						myPrevNormal = myNormal;
						WallNormal wallNormal = hit.collider.gameObject.GetComponent<WallNormal> ();

						myNormal = wallNormal.normal;

						//transform.Rotate (Vector3.left * 90, Space.World); //rotate 90 degrees
						Physics.gravity = myNormal * 10; // change gravity

						// change rotation

						if (myPrevNormal == Vector3.down) { // PLANE 1
							//transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
							if (myNormal == Vector3.forward) {
								
								//transform.Rotate (Vector3.left * 90, Space.World);
								//Vector3 myForward = Vector3.Cross(transform.up, myNormal);
								//Quaternion targetRotation = Quaternion.LookRotation (Vector3.down, myNormal);
								//transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, 0.05f);
								//transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.up, transform.forward*-1), 0.05f);

								transform.Rotate (Vector3.left * 90, Space.World);

							} else if (myNormal == Vector3.back) {
								transform.Rotate (Vector3.right * 90, Space.World);
							} else if (myNormal == Vector3.left) {
								transform.Rotate (Vector3.back * 90, Space.World);
							} else if (myNormal == Vector3.right) {
								transform.Rotate (Vector3.forward * 90, Space.World);
							}
							StartCoroutine (BloomAnimation ());
						} else if (myPrevNormal == Vector3.forward) { // PLANE 2
							if (myNormal == Vector3.down) {
								transform.Rotate (Vector3.right * 90, Space.World);
							} else if (myNormal == Vector3.left) {
								transform.Rotate (Vector3.down * 90, Space.World);
							} else if (myNormal == Vector3.right) {
								transform.Rotate (Vector3.up * 90, Space.World);
							} else if (myNormal == Vector3.up) {
								transform.Rotate (Vector3.left * 90, Space.World);
							}
						} else if (myPrevNormal == Vector3.left) { // PLANE 3
							if (myNormal == Vector3.down) {
								transform.Rotate (Vector3.forward * 90, Space.World);
							} else if (myNormal == Vector3.forward) {
								transform.Rotate (Vector3.up * 90, Space.World);
							} else if (myNormal == Vector3.back) {
								transform.Rotate (Vector3.down * 90, Space.World);
							} else if (myNormal == Vector3.up) {
								transform.Rotate (Vector3.back * 90, Space.World);
							}
						} else if (myPrevNormal == Vector3.back) { // PLANE 4
							if (myNormal == Vector3.down) {
								transform.Rotate (Vector3.left * 90, Space.World);
							} else if (myNormal == Vector3.left) {
								transform.Rotate (Vector3.up * 90, Space.World);
							} else if (myNormal == Vector3.up) {
								transform.Rotate (Vector3.right * 90, Space.World);
							} else if (myNormal == Vector3.right) {
								transform.Rotate (Vector3.down * 90, Space.World);
							}
						} else if (myPrevNormal == Vector3.right) { // PLANE 5
							if (myNormal == Vector3.down) {
								transform.Rotate (Vector3.back * 90, Space.World);
							} else if (myNormal == Vector3.forward) {
								transform.Rotate (Vector3.down * 90, Space.World);
							} else if (myNormal == Vector3.back) {
								transform.Rotate (Vector3.up * 90, Space.World);
							} else if (myNormal == Vector3.up) {
								transform.Rotate (Vector3.forward * 90, Space.World);
							} 
						} else if (myPrevNormal == Vector3.up) { // Plane 6
							if (myNormal == Vector3.forward) {
								transform.Rotate (Vector3.right * 90, Space.World);
							} else if (myNormal == Vector3.left) {
								transform.Rotate (Vector3.forward * 90, Space.World);
							} else if (myNormal == Vector3.back) {
								transform.Rotate (Vector3.left * 90, Space.World);
							} else if (myNormal == Vector3.right) {
								transform.Rotate (Vector3.back * 90, Space.World);
							} 
						}
						StartCoroutine (BloomAnimation ());
						//wallswitch = false;
					} else {
						failwallswitch = true;
					}
				}
				

				//change gravity
				canMove = 1;
			}

			if (canMove == 1) {
				if (Input.GetKey (KeyCode.D)) {
					if (myNormal == Vector3.right) {
						transform.Rotate (Vector3.left * 3f, Space.World);
					}
					if (myNormal == Vector3.left) {
						transform.Rotate (Vector3.right * 3f, Space.World);
					}
					if (myNormal == Vector3.up) {
						transform.Rotate (Vector3.down * 3f, Space.World);
					}
					if (myNormal == Vector3.down) {
						transform.Rotate (Vector3.up * 3f, Space.World);
					}
					if (myNormal == Vector3.forward) {
						transform.Rotate (Vector3.back * 3f, Space.World);
					}
					if (myNormal == Vector3.back) {
						transform.Rotate (Vector3.forward * 3f, Space.World);
					}
				} 
				if (Input.GetKey (KeyCode.A)) {
					if (myNormal == Vector3.right) {
						transform.Rotate (Vector3.right * 3f, Space.World);
					}
					if (myNormal == Vector3.left) {
						transform.Rotate (Vector3.left * 3f, Space.World);
					}
					if (myNormal == Vector3.up) {
						transform.Rotate (Vector3.up * 3f, Space.World);
					}
					if (myNormal == Vector3.down) {
						transform.Rotate (Vector3.down * 3f, Space.World);
					}
					if (myNormal == Vector3.forward) {
						transform.Rotate (Vector3.forward * 3f, Space.World);
					}
					if (myNormal == Vector3.back) {
						transform.Rotate (Vector3.back * 3f, Space.World);
					}
				}

				float translation = Input.GetAxis ("Vertical") * speed;
				float straffle = Input.GetAxis ("Horizontal") * speed;
				translation *= Time.deltaTime;
				straffle *= Time.deltaTime;
				//playerRigidbody.AddForce(new Vector3(1000, 0, 1000));
				//transform.Translate (0, 0, translation);


				Animating (translation, straffle); 
			}
		}
			//playerRigidBody.MovePosition(new Vector3(straffle, 0, translation));
		if (Input.GetKeyDown ("escape")) {
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

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("endGame")) {
			print ("Hello");
			Cursor.visible = true;
			Vector3 coor = new Vector3 (0, -1, 0);
			Physics.gravity = coor * 10;
			Application.LoadLevel ("EndGame");
		}
	}

	void Animating (float h, float v) {
		bool walking = h != 0f || v != 0f;
		if (walking) {
			if (anim.GetInteger ("Speed") == 2) {
			} else {
				anim.SetInteger ("Speed", 2);
			}
		} else {
			anim.SetInteger ("Speed", 0);
		}
	}
}

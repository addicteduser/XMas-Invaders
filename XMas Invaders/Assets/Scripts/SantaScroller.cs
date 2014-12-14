using UnityEngine;
using System.Collections;

/// <summary>
/// Handler for Santa's movements
/// </summary>
public class SantaScroller : MonoBehaviour {
	/// <summary>
	/// For wipeout scrolling
	/// </summary>
	public Transform wipeout;
	/// <summary>
	/// For bounds scrolling
	/// </summary>
	public Transform bounds;
	
	/// <summary>
	/// How fast can Santa move?
	/// </summary>
	private float speed = 0.2f;
	private float distanceFromCamera;
	private float distanceFromWipeOut;
	
	private float x, y, z;
	private float lockY = 0, lockZ = 0;
	
	/// <summary>
	/// Flag for when the up button is being pressed
	/// </summary>
	public bool isUpPressed = false;
	/// <summary>
	/// Flag for when the down button is being pressed
	/// </summary>
	public bool isDownPressed = false;
	
	// Use this for initialization
	void Start () {
		// get the distance from the camera
		distanceFromCamera = Mathf.Abs(transform.position.x - Camera.main.transform.position.x);
		// get the distance from the wipeout
		distanceFromWipeOut = Mathf.Abs(transform.position.x - wipeout.transform.position.x);
		
		GetCurrentPosition();
	}
	
	/// <summary>
	/// For verical movement
	/// </summary>
	void FixedUpdate() {
		GetCurrentPosition();
		
		// Move UP
		if(Input.GetAxisRaw("Vertical") > 0 || isUpPressed) {
			MoveUp();
		}
		
		// Move DOWN
		if(Input.GetAxisRaw("Vertical") < 0 || isDownPressed) {
			MoveDown();
		}
	}
	
	/// <summary>
	/// For horizontal movement
	/// </summary>
	void Update () {
		float newX;
		
		GetCurrentPosition();
		
		// Santa
		newX = Camera.main.transform.position.x - distanceFromCamera;
		transform.position = new Vector3(newX, y, z);
		
		// Wipeout
		newX = x - distanceFromWipeOut;
		wipeout.transform.position = new Vector3(newX, lockY, lockZ);
		
		// Bounds
		bounds.transform.position = new Vector3(x, lockY, lockZ);
	}
	
	/// <summary>
	/// Gets Santa's the current position.
	/// </summary>
	private void GetCurrentPosition() {
		x = transform.position.x;
		y = transform.position.y;
		z = transform.position.z;
	}
	
	/// <summary>
	/// Moves up.
	/// </summary>
	public void MoveUp() {
		transform.position = new Vector3(x, y+speed, z);
	}
	
	/// <summary>
	/// Moves down.
	/// </summary>
	public void MoveDown() {
		transform.position = new Vector3(x, y-speed, z);
	}
	
	public void pressDown() {
		isDownPressed = true;
	}
	
	public void pressDownRelease() {
		isDownPressed = true;
	}
	
	public void pressUp() {
		isUpPressed = true;
	}
	
	public void pressUpRelease() {
		isUpPressed = false;
	}
	
	/// <summary>
	/// When colliding with an enemy
	/// </summary>
	/// <param name="collision">Collision.</param>
	void OnCollisionEnter2D(Collision2D collision) {
		// Flag to indicate that player sustained damage
		bool damagePlayer = false;
		// Who did Santa collide with?
		GameObject enemy = collision.gameObject;
		
		if (enemy.tag == "Enemy") {
			// Kill Enemy
			Health enemyHealth = enemy.GetComponent<Health>();
			if (enemyHealth != null) {
				enemyHealth.Damage(enemyHealth.hp);
			}
			
			damagePlayer = true;
		}
		
		// Santa also sustains damage
		if (damagePlayer) {
			Health playerHealth = GetComponent<Health>();
			if (playerHealth != null) {
				playerHealth.Damage(playerHealth.hp);
			}
		}
	}
}

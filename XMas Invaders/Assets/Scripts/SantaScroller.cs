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
	
	// Use this for initialization
	void Start () {
		// get the distance from the camera
		distanceFromCamera = Mathf.Abs(transform.position.x - Camera.main.transform.position.x);
		// get the distance from the wipeout
		distanceFromWipeOut = Mathf.Abs(transform.position.x - wipeout.transform.position.x);
		
		GetCurrentPosition();
	}
	
	/// <summary>
	/// For vertical movement
	/// </summary>
	void FixedUpdate() {
		GetCurrentPosition();
			
		// Move UP
		if(Input.GetAxisRaw("Vertical") > 0) {
			MoveUp();
		}
		
		// Move DOWN
		if(Input.GetAxisRaw("Vertical") < 0) {
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
}

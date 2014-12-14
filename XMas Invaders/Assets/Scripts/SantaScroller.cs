using UnityEngine;
using System.Collections;

public class SantaScroller : MonoBehaviour {

	// This is responsible for Santa's movements

	public static Vector3 currentPos;

	private float speed;
	private float distanceFromCamera;
	private float distanceFromWipeOut;
	public Transform wipeout;
	private float x, y, z;
	private float lockY, lockZ;
	
	// Use this for initialization
	void Start () {
		speed = 0.2f;		
		distanceFromCamera = Mathf.Abs(transform.position.x - Camera.main.transform.position.x);
		lockY = wipeout.transform.position.y;
		lockZ = wipeout.transform.position.z;
		distanceFromWipeOut = Mathf.Abs(transform.position.x - wipeout.transform.position.x);
		GetCurrentPosition();
	}
	
	void FixedUpdate() {
		GetCurrentPosition();
				
		// Move UP
		if(Input.GetAxisRaw("Vertical") > 0) {
			transform.position = new Vector3(x, y+speed, z);			
			//transform.Translate(new Vector2(0f, speed));
		}
		
		// Move DOWN
		if(Input.GetAxisRaw("Vertical") < 0) {
			transform.position = new Vector3(x, y-speed, z);
			//transform.Translate(new Vector2(0f, -speed));
		}
		
		wipeout.transform.position = new Vector3(x - distanceFromWipeOut, lockY, lockZ);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			// Get movement of the finger since last frame
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			
			Vector3 touchPosition = new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, touchDeltaPosition.y);
				
			// Move object across XY plane
			transform.position = Camera.main.ScreenToWorldPoint(touchPosition);
		}
	
	
		// move horizontal
		GetCurrentPosition();
		float newX = Camera.main.transform.position.x - distanceFromCamera;
		transform.position = new Vector3(newX, y, z);
		currentPos = transform.position;
	}
	
	private void GetCurrentPosition() {
		x = transform.position.x;
		y = transform.position.y;
		z = transform.position.z;
	}
}

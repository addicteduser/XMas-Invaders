using UnityEngine;
using System.Collections;

public class Santa : MonoBehaviour {

	public static Vector3 currentPos;

	private float speed;
	private float distanceFromCamera;
	private float x, y, z;
	
	// Use this for initialization
	void Start () {
		speed = 0.2f;		
		distanceFromCamera = Mathf.Abs(transform.position.x - Camera.main.transform.position.x);
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
	}
	
	// Update is called once per frame
	void Update () {
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

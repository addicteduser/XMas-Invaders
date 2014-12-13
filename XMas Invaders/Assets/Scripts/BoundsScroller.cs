using UnityEngine;
using System.Collections;

public class BoundsScroller : MonoBehaviour {

	// This is so that the bounds follow Santa
	// The bounds are for limiting Santa to not leave the screen
	
	void Update () {
		float y = transform.position.y;
		float z = transform.position.z;
		transform.position = new Vector3(SantaScroller.currentPos.x, y, z);
	}
	
}

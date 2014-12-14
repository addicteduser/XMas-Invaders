using UnityEngine;
using System.Collections;

/// <summary>
/// Handler for the movement of the bounds
/// </summary>
public class BoundsScroller : MonoBehaviour {
	
	/// <summary>
	/// Used for following Santa
	/// </summary>
	public Transform santa;
	
	void Update () {
		float y = transform.position.y;
		float z = transform.position.z;
		transform.position = new Vector3(santa.position.x, y, z);
	}
	
}
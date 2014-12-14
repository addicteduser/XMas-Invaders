using UnityEngine;
using System.Collections;

/// <summary>
/// Handler for camera movement -> scrolling
/// </summary>
public class CameraScroller : MonoBehaviour {

	/// <summary>
	/// How fast is the side-scrolling?
	/// </summary>
	public float speed = 2f;
	
	void Update () {
		transform.Translate(speed * Time.deltaTime, 0f, 0f);
	}
}

using UnityEngine;
using System.Collections;

public class CameraScroller : MonoBehaviour {

	// This is responsible for the scrolling of the camera

	public float speed;
	
	void Update () {
		transform.Translate(speed * Time.deltaTime, 0f, 0f);
	}
}

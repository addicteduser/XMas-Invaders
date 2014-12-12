using UnityEngine;
using System.Collections;

public class CameraScroller : MonoBehaviour {

	public float speed;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(speed * Time.deltaTime, 0f, 0f);
	}
}

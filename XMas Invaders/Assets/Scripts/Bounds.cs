using UnityEngine;
using System.Collections;

public class Bounds : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float y = transform.position.y;
		float z = transform.position.z;
		transform.position = new Vector3(Santa.currentPos.x, y, z);
	}
	
}

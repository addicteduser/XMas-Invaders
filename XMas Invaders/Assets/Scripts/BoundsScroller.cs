using UnityEngine;
using System.Collections;

public class BoundsScroller : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float y = transform.position.y;
		float z = transform.position.z;
		transform.position = new Vector3(SantaScroller.currentPos.x, y, z);
	}
	
}

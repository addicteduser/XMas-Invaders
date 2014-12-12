using UnityEngine;
using System.Collections;

public class UtilityBarScroller : MonoBehaviour {

	private float distanceFromSanta;
	
	// Use this for initialization
	void Start () {
		distanceFromSanta = transform.position.x - Santa.currentPos.x;
	}
	
	// Update is called once per frame
	void Update () {
		float newX = transform.position.x + distanceFromSanta;
		float y = transform.position.y;
		float z = transform.position.z;
		transform.position = new Vector3(newX, y, z);		
	}
}

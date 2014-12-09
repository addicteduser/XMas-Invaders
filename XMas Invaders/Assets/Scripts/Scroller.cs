using UnityEngine;
using System.Collections;

public class Scroller : MonoBehaviour {

	private float speed;
	
	// Use this for initialization
	void Start () {
		speed = 20f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(speed * Time.deltaTime, 0f, 0f);
	}
}

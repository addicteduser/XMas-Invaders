using UnityEngine;
using System.Collections;

public class MoveTrail : MonoBehaviour {

	// This is responsible for the movement of the bullets

	public int moveSpeed = 20;

	void Update () {
		transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
		Destroy(gameObject, 5);
	}
}

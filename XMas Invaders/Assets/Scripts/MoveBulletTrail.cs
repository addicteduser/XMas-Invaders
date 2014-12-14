using UnityEngine;
using System.Collections;

/// <summary>
/// Handler for the movement of the bullet on the screen
/// </summary>
public class MoveBulletTrail : MonoBehaviour {

	/// <summary>
	/// How fast the bullet moves
	/// </summary>
	public int moveSpeed = 20;
	/// <summary>
	/// How much damage the bullet can render
	/// </summary>
	public int damage = 1;
	/// <summary>
	/// Flag to see if an enemy is shot
	/// </summary>
	public bool isEnemyShot = false;

	void Update () {
		// Move the bullet
		transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
		
		// Remove it from the scene
		Destroy(gameObject, 3);
	}
}

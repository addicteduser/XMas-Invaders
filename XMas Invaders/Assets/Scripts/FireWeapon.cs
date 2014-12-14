using UnityEngine;
using System.Collections;

/// <summary>
/// Handler for the firing of the weapons
/// </summary>
public class FireWeapon : MonoBehaviour {

	/// <summary>
	/// This holds the different bullets
	/// </summary>
	public Transform[] BulletTrailPrefab;

	/// <summary>
	/// The index of the bullet trail prefab.
	/// </summary>
	private int BulletTrailPrefabIndex = 0;
	/// <summary>
	/// This is where the bullets for the Snow Blaster, Candy Cane Shotgun, Gum Ball Bazooka, and Licorice Laser will respawn
	/// </summary>
	private Transform firePoint;
	/// <summary>
	/// This is where the Garland Wipeout will respawn
	/// </summary>
	private Transform wipeOutPoint;

	// Use this for initialization
	void Awake () {
		// starting point of the bullets
		firePoint = transform.FindChild("FirePoint");
		// starting point of the WIPE OUT bullet
		wipeOutPoint = transform.FindChild("WipeOut");
		
		// checkers
		if (firePoint == null) {
			Debug.LogError("No FirePoint Child");
		}
		if (wipeOutPoint == null) {
			Debug.LogError("No WipeOut Child");
		}
	}
	
	void Update() {
		if (Input.GetButtonDown("Jump")) {
			Shoot();
		}
	}
	
	/// <summary>
	/// Fire the bullet
	/// </summary>
	public void Shoot() {
		if (BulletTrailPrefabIndex == 4) {
			Effect(wipeOutPoint);
		} else {
			Effect(firePoint);
		}
	}

	/// <summary>
	/// Sets the index of the bullet trail.
	/// </summary>
	/// <param name="index">Index.</param>
	public void SetBulletTrailIndex(int index) {
		BulletTrailPrefabIndex = index;
	}
	
	/// <summary>
	/// Renders the bullet on the scene
	/// </summary>
	/// <param name="point">Point.</param>
	private void Effect(Transform point) {
		Instantiate(BulletTrailPrefab[BulletTrailPrefabIndex], point.position, point.rotation);
	}
}

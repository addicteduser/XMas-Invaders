using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float damage = 10;
	public LayerMask whatToHit;
	
	public Transform BulletTrailPrefab;
	
	private float timeToFire = 0;
	private Transform firePoint;

	// Use this for initialization
	void Awake () {
		firePoint = transform.FindChild("FirePoint");
		if (firePoint == null) {
			Debug.LogError("No FirePoint Child");
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public void Shoot() { 
		Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
		Vector2 target = new Vector2 (firePoint.position.x+100, firePoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast(firePointPosition, target, 100, whatToHit);
		Effect();
		Debug.DrawLine (firePointPosition, target, Color.cyan);
		if (hit.collider != null) {
			Debug.DrawLine (firePointPosition, hit.point, Color.red);
			Debug.Log("We hit " + hit.collider.name + " and did " + damage + "damage.");
		}
	}
	
	private void Effect() {
		Instantiate(BulletTrailPrefab, firePoint.position, firePoint.rotation);
	}
}

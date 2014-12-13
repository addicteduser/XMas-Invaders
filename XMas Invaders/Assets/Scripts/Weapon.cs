using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public int[] damage;
	public LayerMask whatToHit;
	public Transform[] BulletTrailPrefab;

	private int BulletTrailPrefabIndex = 0;
	private int DamageIndex = 0;
	private Transform firePoint;
	private Transform wipeOutPoint;

	// Use this for initialization
	void Awake () {
		firePoint = transform.FindChild("FirePoint");
		wipeOutPoint = transform.FindChild("WipeOut");
		if (firePoint == null) {
			Debug.LogError("No FirePoint Child");
		}
		if (wipeOutPoint == null) {
			Debug.LogError("No WipeOut Child");
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public void Shoot() {
		
	
	
		if (BulletTrailPrefabIndex == 4) {
			ReadyShoot(wipeOutPoint);
		} else {
			ReadyShoot(firePoint);
		}
		
		//Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
		//Vector2 target = new Vector2 (firePoint.position.x+100, firePoint.position.y);
		//RaycastHit2D hit = Physics2D.Raycast(firePointPosition, target, 100, whatToHit);
		//Effect();
		//Debug.DrawLine (firePointPosition, target, Color.cyan);
		//if (hit.collider != null) {
		//	Debug.DrawLine (firePointPosition, hit.point, Color.red);
		//	Debug.Log("We hit " + hit.collider.name + " and did " + damage[DamageIndex] + "damage.");
		//}
	}
	
	public void ReadyShoot(Transform point) {
		Vector2 pointPosition = new Vector2 (point.position.x, point.position.y);
		Vector2 target = new Vector2 (point.position.x+100, point.position.y);
		RaycastHit2D hit = Physics2D.Raycast(pointPosition, target, 100, whatToHit);
		Effect(point);
	}
	
	public void SetBulletTrailIndex(int index) {
		BulletTrailPrefabIndex = index;
	}
	
	public void SetDamageIndex(int index) {
		DamageIndex = index;
	}
	
	private void Effect(Transform point) {
		Instantiate(BulletTrailPrefab[BulletTrailPrefabIndex], point.position, point.rotation);
	}
}

﻿using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	/// <summary>
	/// Total hitpoints
	/// </summary>
	public int hp = 1;
	
	/// <summary>
	/// Enemy or player?
	/// </summary>
	public bool isEnemy = true;
	
	/// <summary>
	/// Inflicts damage and check if the object should be destroyed
	/// </summary>
	/// <param name="damageCount"></param>
	public void Damage(int damageCount) {
		hp -= damageCount;
		
		if (hp <= 0) {
			// Dead!
			Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D otherCollider)	{
		// Is this a shot?
		MoveBulletTrail shot = otherCollider.gameObject.GetComponent<MoveBulletTrail>();
		if (shot != null) {
			// Avoid friendly fire
			if (shot.isEnemyShot != isEnemy) {
				Damage(shot.damage);
								
				if (!shot.gameObject.name.Contains("GarlandWipeoutBulletTrail")) {
					// Destroy the shot
					Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
				}
			}
		}
	}
}

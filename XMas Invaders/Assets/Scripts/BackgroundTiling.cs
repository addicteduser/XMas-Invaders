using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Handler for the repetition of the background
/// </summary>
public class BackgroundTiling : MonoBehaviour {
	/// <summary>
	/// Position of the main camera
	/// </summary>
	private Transform cameraPos;
	/// <summary>
	/// Width of the background image
	/// </summary>
	private float spriteWidth;
	
	void Start() {
		cameraPos = Camera.main.transform;
		SpriteRenderer spriteRenderer = renderer as SpriteRenderer;
		spriteWidth = spriteRenderer.sprite.bounds.size.x;
	}
	
	void Update() {
		if( (transform.position.x + spriteWidth) < cameraPos.position.x) {
			Vector3 newPos = transform.position;
			newPos.x += 2.0f * spriteWidth; 
			transform.position = newPos;
		}
	}
}

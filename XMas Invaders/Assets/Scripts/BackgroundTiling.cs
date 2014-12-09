using UnityEngine;
using System.Collections.Generic;

public class BackgroundTiling : MonoBehaviour {
	
	private Transform cameraPos;
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

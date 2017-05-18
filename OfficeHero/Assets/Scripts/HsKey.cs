using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsKey : MonoBehaviour {

	private void Start () {
	}

	private void Update () {
		foreach (Touch t in Input.touches) {
			if (t.phase == TouchPhase.Began) {
				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (t.position), -Vector2.up);
				if (hit.collider != null) {
					if (hit.collider.gameObject == this.gameObject) {
						Destroy (this.gameObject);
					}
				}
			}	
		}
	}
}
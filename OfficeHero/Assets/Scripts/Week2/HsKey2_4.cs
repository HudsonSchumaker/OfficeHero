﻿using UnityEngine;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsKey2_4 : MonoBehaviour {

	private float speed;
	private GameObject gameEngine;
	private HsWeek2_4 hsEngine;

	private void Start () {
		this.speed = 3.4f;
		this.gameEngine = GameObject.FindGameObjectWithTag ("MainCamera");
		this.hsEngine = (HsWeek2_4) gameEngine.GetComponent (typeof(HsWeek2_4));
		Behaviour h = (Behaviour)GetComponent("Halo");
		h.enabled = false;
	}

	private void Update () {
		foreach (Touch t in Input.touches) {
			if (t.phase == TouchPhase.Began) {
				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (t.position), -Vector2.up);
				if (hit.collider != null) {
					if (hit.collider.gameObject == this.gameObject) {
						if(transform.position.y < -2.0f){
							hsEngine.AddScore (transform.position.x);
							hsEngine.RemoveOneKey ();
							hsEngine.Strike ();
							Destroy (this.gameObject);
						}
					}
				}
			}	
		}
		if (transform.position.y < -1.8f) {
			Behaviour h = (Behaviour)GetComponent("Halo");
			h.enabled = true;
		}
		this.transform.Translate (new Vector3 (0.0f,-speed * Time.deltaTime,0.0f));// Make fall
		this.isOutOfScreen ();
	}

	private void isOutOfScreen(){
		if(this.transform.position.y < -6.20f) {
			Destroy (this.gameObject);
			Handheld.Vibrate();
			hsEngine.RemoveOneKey ();
			hsEngine.Error ();
			hsEngine.EndStrike ();
		}
	}
}
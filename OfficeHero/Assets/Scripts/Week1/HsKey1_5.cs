﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HsKey1_5 : MonoBehaviour {

	private float speed;
	private GameObject gameEngine;
	private HsWeek1_5 hsEngine;

	private void Start () {
		this.speed = 1.5f;
		this.gameEngine = GameObject.FindGameObjectWithTag ("MainCamera");
		this.hsEngine = (HsWeek1_5) gameEngine.GetComponent (typeof(HsWeek1_5));
	}

	private void Update () {
		foreach (Touch t in Input.touches) {
			if (t.phase == TouchPhase.Began) {
				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (t.position), -Vector2.up);
				if (hit.collider != null) {
					if (hit.collider.gameObject == this.gameObject) {
						if(transform.position.y < -2.0f){
							Destroy (this.gameObject);
							hsEngine.AddScore ();
							hsEngine.RemoveOneKey ();
							hsEngine.Strike ();
						}
					}
				}
			}	
		}
		this.transform.Translate (new Vector3 (0.0f,-speed * Time.deltaTime,0.0f));// Make fall
		this.isOutOfScreen ();
	}

	private void isOutOfScreen(){
		if(this.transform.position.y < -6.10f) {
			Destroy (this.gameObject);
			Handheld.Vibrate();
			hsEngine.RemoveOneKey ();
			hsEngine.Error ();
			hsEngine.EndStrike ();
		}
	}
}
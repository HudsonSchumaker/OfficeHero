﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HsMouseRight4_4 : MonoBehaviour {

	private float speed;
	private GameObject gameEngine;
	private HsWeek4_4 hsEngine;

	private void Start () {
		this.speed = 4.0f;
		this.gameEngine = GameObject.FindGameObjectWithTag ("MainCamera");
		this.hsEngine = (HsWeek4_4) gameEngine.GetComponent (typeof(HsWeek4_4));
		Behaviour h = (Behaviour)GetComponent("Halo");
		h.enabled = false;
	}

	void Update () {
		if (transform.position.y < -2.0f) {
			if (Input.acceleration.x > 0) {
				transform.Translate (Input.acceleration.x * Time.deltaTime*14, 0.0f, 0.0f);
				hsEngine.AddScore (transform.position.x);
				Destroy (this.gameObject);
				hsEngine.RemoveOneKey ();
				hsEngine.Strike ();
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

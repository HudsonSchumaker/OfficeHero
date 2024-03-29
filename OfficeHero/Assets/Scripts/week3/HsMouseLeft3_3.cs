﻿using UnityEngine;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsMouseLeft3_3 : MonoBehaviour {

	private float speed;
	private GameObject gameEngine;
	private HsWeek3_3 hsEngine;

	private void Start () {
		this.speed = 3.7f;
		this.gameEngine = GameObject.FindGameObjectWithTag ("MainCamera");
		this.hsEngine = (HsWeek3_3) gameEngine.GetComponent (typeof(HsWeek3_3));
		Behaviour h = (Behaviour)GetComponent("Halo");
		h.enabled = false;
	}
		
	void Update () {
		if (transform.position.y < -2.0f) {
			if (Input.acceleration.x < 0) {
				transform.Translate (Input.acceleration.x * Time.deltaTime*14, 0.0f, 0.0f);
				Destroy (this.gameObject);
				hsEngine.AddScore (transform.position.x);
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
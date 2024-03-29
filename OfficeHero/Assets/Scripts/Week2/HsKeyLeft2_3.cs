﻿using UnityEngine;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsKeyLeft2_3 : MonoBehaviour {

	private GameObject keyExclamation;
	private float speed;
	private GameObject gameEngine;
	private HsWeek2_3 hsEngine;

	private void Start () {
		this.speed = 3.2f;
		this.gameEngine = GameObject.FindGameObjectWithTag ("MainCamera");
		this.hsEngine = (HsWeek2_3)gameEngine.GetComponent (typeof(HsWeek2_3));
		Behaviour h = (Behaviour)GetComponent ("Halo");
		h.enabled = false;
		this.keyExclamation = (GameObject) Instantiate(Resources.Load("keyExclamation"));//ExclamationKey
		this.keyExclamation.transform.Translate (new Vector3(-2.0f,0.0f,0.0f));
	}

	private void Update () {
		if (transform.position.y < -2.0f) {
			if (Input.touchCount >= 1) {
				Touch touch = Input.GetTouch (0);
				float x = -7.5f + 15.0f * touch.position.x / Screen.width;
				float y = -4.5f + 9 * touch.position.y / Screen.height;
				transform.position = new Vector3 (x, y, 0.0f);
			}

			if (transform.position.x < -2.0f) {
				//transform.Translate (Input.acceleration.x * Time.deltaTime, 0.0f, 0.0f);
				hsEngine.AddScore (10.0f);//Pre set for play audio
				hsEngine.RemoveOneKey ();
				hsEngine.Strike ();
				Destroy (this.gameObject);
				Destroy (this.keyExclamation.gameObject);
			}
		}

		if (transform.position.y < -1.8f) {
			Behaviour h = (Behaviour)GetComponent ("Halo");
			h.enabled = true;
		}

		this.transform.Translate (new Vector3 (0.0f, -speed * Time.deltaTime, 0.0f));// Make fall
		this.keyExclamation.transform.Translate(new Vector3 (0.0f, -speed * Time.deltaTime, 0.0f));// Make fall
		this.isOutOfScreen ();
	}

	private void isOutOfScreen () {
		if (this.transform.position.y < -6.20f) {
			Destroy (this.keyExclamation.gameObject);
			Destroy (this.gameObject);
			Handheld.Vibrate ();
			hsEngine.RemoveOneKey ();
			hsEngine.Error ();
			hsEngine.EndStrike ();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HsKey1_5 : MonoBehaviour {

	private float speed;
	private GameObject gameEngine;
	private HsWeek1_5 hsEngine;

	private void Start () {
		this.speed = 2.9f;
		this.gameEngine = GameObject.FindGameObjectWithTag ("MainCamera");
		this.hsEngine = (HsWeek1_5) gameEngine.GetComponent (typeof(HsWeek1_5));
		Behaviour h = (Behaviour)GetComponent("Halo");
		h.enabled = false;
	}

	private void Update () {
		foreach (Touch t in Input.touches) {
			if (t.phase == TouchPhase.Began) {
				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (t.position), -Vector2.up);
				if (hit.collider != null) {
					if (hit.collider.gameObject == this.gameObject) {
						if(transform.position.y < -1.20f){
							hsEngine.AddScore (transform.position.x);
							hsEngine.RemoveOneKey ();
							hsEngine.Strike ();
							Destroy (this.gameObject);
						}
					}
				}
			}	
		}
		if (transform.position.y < -1.5f) {
			Behaviour h = (Behaviour)GetComponent("Halo");
			h.enabled = true;
		}
		this.transform.Translate (new Vector3 (0.0f,-speed * Time.deltaTime,0.0f));// Make fall
		this.isOutOfScreen ();
	}

	private void isOutOfScreen(){
		if(this.transform.position.y < -6.0f) {
			Destroy (this.gameObject);
			Handheld.Vibrate();
			hsEngine.RemoveOneKey ();
			hsEngine.Error ();
			hsEngine.EndStrike ();
		}
	}
}
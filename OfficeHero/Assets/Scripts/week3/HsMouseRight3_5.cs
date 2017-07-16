using UnityEngine;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsMouseRight3_5 : MonoBehaviour {

	private float speed;
	private GameObject gameEngine;
	private HsWeek3_5 hsEngine;

	private void Start () {
		this.speed = 3.8f;
		this.gameEngine = GameObject.FindGameObjectWithTag ("MainCamera");
		this.hsEngine = (HsWeek3_5) gameEngine.GetComponent (typeof(HsWeek3_5));
		Behaviour h = (Behaviour)GetComponent("Halo");
		h.enabled = false;
	}

	void Update () {
		if (transform.position.y < -2.0f) {
			if (Input.acceleration.x > 0) {
				transform.Translate (Input.acceleration.x * Time.deltaTime*14, 0.0f, 0.0f);
				hsEngine.AddScore (transform.position.x);
				Invoke ("ManageMouse", 0.1f);
			}
		}

		if (transform.position.y < -1.8f) {
			Behaviour h = (Behaviour)GetComponent("Halo");
			h.enabled = true;
		}
		this.transform.Translate (new Vector3 (0.0f,-speed * Time.deltaTime,0.0f));// Make fall
		this.isOutOfScreen ();
	}

	private void ManageMouse(){
		Destroy (this.gameObject);
		hsEngine.AddScore (transform.position.x);
		hsEngine.RemoveOneKey ();
		hsEngine.Strike ();
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
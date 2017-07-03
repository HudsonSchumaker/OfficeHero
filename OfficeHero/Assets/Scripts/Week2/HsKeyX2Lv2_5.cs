using UnityEngine;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsKeyX2Lv2_5 : MonoBehaviour {

	private float speed;
	private GameObject gameEngine;
	private HsWeek2_5 hsEngine;

	private void Start () {
		this.speed = 2.5f;
		this.gameEngine = GameObject.FindGameObjectWithTag ("MainCamera");
		this.hsEngine = (HsWeek2_5) gameEngine.GetComponent (typeof(HsWeek2_5));
	}

	private void Update () {
		foreach (Touch t in Input.touches) {
			if (t.phase == TouchPhase.Began) {
				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (t.position), -Vector2.up);
				if (hit.collider != null) {
					if (hit.collider.gameObject == this.gameObject) {
						hsEngine.SetComboKeyX2 ();
						Destroy (this.gameObject);
					}
				}
			}	
		}
		this.transform.Translate (new Vector3 (0.0f,-speed * Time.deltaTime,0.0f));// Make fall
		this.isOutOfScreen ();
	}

	private void isOutOfScreen(){
		if(this.transform.position.y < -6.20f) {
			Destroy (this.gameObject);
			Handheld.Vibrate();
			hsEngine.RemoveOneKey ();
		}
	}
}

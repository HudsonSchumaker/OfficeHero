using UnityEngine;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsKey : MonoBehaviour {


	private float speed;
	private GameObject gameEngine;

	private HsEngine hsengine;


	private void Start () {
		this.gameEngine = GameObject.FindGameObjectWithTag ("MainCamera");
		this.hsengine = (HsEngine) gameEngine.GetComponent (typeof(HsEngine));
		this.speed = hsengine.GetLevelSpeed ();

	}

	private void Update () {
		foreach (Touch t in Input.touches) {
			if (t.phase == TouchPhase.Began) {
				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (t.position), -Vector2.up);
				if (hit.collider != null) {
					if (hit.collider.gameObject == this.gameObject) {
						if(transform.position.y < -2.0f){
							Destroy (this.gameObject);
							Invoke ("backFrame", 0.5f);
							hsengine.AddScore ();
						}
					}
				}
			}	
		}
		this.transform.Translate (new Vector3 (0.0f,-speed * Time.deltaTime,0.0f));// Make fall
		this.isOutOfScreen ();
	}

	private void isOutOfScreen(){
		if(this.transform.position.y < -6.10) {
			Destroy (this.gameObject);
			Handheld.Vibrate();
		}
	}
}
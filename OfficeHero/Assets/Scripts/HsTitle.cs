using UnityEngine;
using UnityEngine.SceneManagement;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsTitle : MonoBehaviour {

	private float delay;
	void Start () {
		delay = 1.5f;
	}

	void Update () {
		delay -= Time.deltaTime;
		if(delay <= 0.0f){
			SceneManager.LoadScene("_Splash");
		}
	}
}

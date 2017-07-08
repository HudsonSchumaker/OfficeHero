using UnityEngine;
using UnityEngine.SceneManagement;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsGameOver : MonoBehaviour {

	public GameObject stage1;
	public GameObject stage2;
	public GameObject stage3;
	public GameObject stage4;

	private float delay;

	private void Start () {
		AdManager.instance.ShowBanner ();
		AdManager.instance.LoadBigBanner ();
	
		this.delay = 4.0f;
		this.SetGameOverTheme ();
	}

	private void Update () {
		delay -= Time.deltaTime;
		if(delay <= 0.0f){
			SceneManager.LoadScene("_MainScreen");
		}
	}

	private void SetGameOverTheme(){
		int gameOver = PlayerPrefs.GetInt("gameOverStage");

		if (gameOver == 1){
			stage1.SetActive (true);
			return;
		}
		if (gameOver == 2){
			stage2.SetActive (true);
			return;
		}
		if (gameOver == 3){
			stage3.SetActive (true);
			return;
		}
		if (gameOver == 4){
			stage4.SetActive (true);
		}
	}
}
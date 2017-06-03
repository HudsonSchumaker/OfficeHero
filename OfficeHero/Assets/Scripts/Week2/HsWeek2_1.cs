using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsWeek2_1 : MonoBehaviour {

	public GameObject key;
	public GameObject keyPurple;
	public GameObject keyX2;
	public GameObject keyLeft;
	public GameObject keyRight;
	public Text scoreStr;
	public Text comboStr;
	public GameObject hero1;
	public GameObject hero2;
	public AudioClip key1;
	public AudioClip key2;
	public AudioClip key3;
	public AudioClip key4;
	public AudioClip lostKey;

	private int numberOfKeys;
	private int score;
	private int hitPoint;
	private int longStrike;
	private int error;
	private int strike;
	private int combo;
	private int comboKeyX2;
	private int normalKey;
	private float x1, x2, x3, x4;
	private float y;
	private float z;
	private float interval;

	private void Start () {
		this.numberOfKeys = 150;
		this.scoreStr.text = "SCORE: " + score;
		this.error = 0;
		this.score = 0;
		this.strike = 0;
		this.longStrike = 0;
		this.normalKey = 0;
		this.hitPoint = 50;
		this.combo = 1;
		this.comboKeyX2 = 1;
		this.x1 = -2.0f;
		this.x2 = -0.7f;
		this.x3 = 0.7f;
		this.x4 = 2.0f;
		this.y = 5.5f;
		this.z = 0.0f;
		this.interval = 1.1f;
		this.TheLevel ();
	}

	private void Update () {
		scoreStr.text = "SCORE : " + score;
		if(numberOfKeys <= 0){
			EndStrike ();//Se nao errar nao entra
			PlayerPrefs.SetInt ("StrikeLv2-1", longStrike);
			PlayerPrefs.SetInt ("ScoreLv2-1", score);
			SceneManager.LoadScene("_EndWeek2-1s");
		}
		if(error >= 8){
			SceneManager.LoadScene("_GameOver");
		}
	}
		
	private void CreateKey1 () {
		Instantiate (key, new Vector3 (x1, y, z), Quaternion.identity);
	}

	private void CreateKey2 () {
		Instantiate (key, new Vector3 (x2, y, z), Quaternion.identity);	
	}

	private void CreateKey3 () {
		Instantiate (key, new Vector3 (x3, y, z), Quaternion.identity);	
	}

	private void CreateKey4 () {
		Instantiate (key, new Vector3 (x4, y, z), Quaternion.identity);	
	}

	private void CreateKeyLeft () {
		Instantiate (keyLeft, new Vector3 (x3, y, z), Quaternion.identity);	
	}

	private void CreateKeyRight () {
		Instantiate (keyRight, new Vector3 (x3, y, z), Quaternion.identity);	
	}
		
	private void playAudio(float posX){
		if(posX == x1){
			HsAudioManager.instance.PlayAudioClip (key1);
			return;
		}
		if(posX == x2){
			HsAudioManager.instance.PlayAudioClip (key2);
			return;
		}
		if(posX == x3){
			HsAudioManager.instance.PlayAudioClip (key3);
			return;
		}
		if(posX == x4){
			HsAudioManager.instance.PlayAudioClip (key4);
		}
	}

	private void SetFrame1(){
		hero1.SetActive(false);
		hero2.SetActive(true);
	}

	private void SetFrame2(){
		hero2.SetActive(false);
	}

	public void AddScore (float posX) {
		playAudio (posX);
		hero1.SetActive(true);
		Invoke ("SetFrame1", 0.20f);
		Invoke ("SetFrame2", 0.40f);
		score++;
	}

	public void AddScore (int value) {
		score += value;
	}

	public void RemoveOneKey(){
		numberOfKeys--;
	}

	public void Error(){
		HsAudioManager.instance.PlayAudioClip (lostKey);
		error++;
	}

	public void Strike(){
		strike++;
	}

	public void EndStrike(){
		if(strike > longStrike){
			longStrike = strike;
		}
		strike = 0;
	}

	private void TheLevel(){		
		Invoke ("CreateKeyLeft", 0.1f);
		Invoke ("CreateKeyLeft", 1.1f);
		Invoke ("CreateKeyLeft", 2.1f);
		Invoke ("CreateKeyRight", 3.1f);
		Invoke ("CreateKeyLeft", 4.1f);
		Invoke ("CreateKeyRight", 5.1f);
		Invoke ("CreateKeyLeft", 6.1f);
		Invoke ("CreateKeyRight", 7.1f);
		Invoke ("CreateKeyLeft", 8.1f);
		Invoke ("CreateKeyRight", 9.1f);
		Invoke ("CreateKeyLeft", 10.1f);
	}
}
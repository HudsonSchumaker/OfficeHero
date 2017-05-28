using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsWeek1_5 : MonoBehaviour {

	public GameObject key;
	public Text scoreStr;
	public GameObject hero1;
	public GameObject hero2;
	public AudioClip key1;
	public AudioClip key2;
	public AudioClip key3;
	public AudioClip key4;
	public AudioClip lostKey;

	private int numberOfKeys;
	private int score;
	private int longStrike;
	private int error;
	private int strike;
	private float x1, x2, x3, x4;
	private float y;
	private float z;
	private float interval;

	private void Start () {
		this.error = 0;
		this.score = 0;
		scoreStr.text = "Score: " + score;
		this.x1 = -2.0f;
		this.x2 = -0.7f;
		this.x3 = 0.7f;
		this.x4 = 2.0f;
		this.y = 5.5f;
		this.z = 0.0f;
		this.interval = 1.1f;
		this.numberOfKeys = 150;
		this.TheLevel();
		this.longStrike = strike = 0;
	}

	private void Update () {
		scoreStr.text = "SCORE : " + score;
		if(numberOfKeys <= 0){
			EndStrike ();//Se nao errar nao entra
			PlayerPrefs.SetInt ("StrikeLv1-5", longStrike);
			PlayerPrefs.SetInt ("ScoreLv1-5", score);
			SceneManager.LoadScene("_EndWeek1-5");
		}
		if(error >= 8){
			SceneManager.LoadScene("_GameOver");
		}
	}
	private void TheLevel(){		
		Invoke ("CreateKey1", 0.1f);
		Invoke ("CreateKey2", 0.1f);
		Invoke ("CreateKey3", 0.1f);
		Invoke ("CreateKey4", 0.1f);
		Invoke ("CreateKey1", 1.0f);
		Invoke ("CreateKey2", 1.0f);
		Invoke ("CreateKey3", 1.0f);
		Invoke ("CreateKey4", 1.0f);
		Invoke ("CreateKey1", interval *2);
		Invoke ("CreateKey2", interval *3);
		Invoke ("CreateKey3", interval *4);
		Invoke ("CreateKey4", interval *5);
		Invoke ("CreateKey1", interval *6);
		Invoke ("CreateKey2", interval *7);
		Invoke ("CreateKey3", interval *8);
		Invoke ("CreateKey4", interval *9);
		Invoke ("CreateKey1", interval *10);
		Invoke ("CreateKey2", interval *10);
		Invoke ("CreateKey3", interval *10);
		Invoke ("CreateKey4", interval *10);
		Invoke ("CreateKey1", interval *11);
		Invoke ("CreateKey2", interval *11);
		Invoke ("CreateKey3", interval *11);
		Invoke ("CreateKey4", interval *11);
		Invoke ("CreateKey1", interval *12);
		Invoke ("CreateKey4", interval *12);
		Invoke ("CreateKey2", interval *13);
		Invoke ("CreateKey3", interval *13);
		Invoke ("CreateKey1", interval *14);
		Invoke ("CreateKey4", interval *14);
		Invoke ("CreateKey2", interval *15);
		Invoke ("CreateKey3", interval *15);
		Invoke ("CreateKey1", interval *16);
		Invoke ("CreateKey3", interval *16);
		Invoke ("CreateKey2", interval *17);
		Invoke ("CreateKey4", interval *17);
		Invoke ("CreateKey1", interval *18);
		Invoke ("CreateKey4", interval *18);
		Invoke ("CreateKey1", interval *19);
		Invoke ("CreateKey3", interval *19);
		Invoke ("CreateKey1", interval *20);
		Invoke ("CreateKey2", interval *20);
		Invoke ("CreateKey1", interval *21);
		Invoke ("CreateKey2", interval *21);
		Invoke ("CreateKey3", interval *21);
		Invoke ("CreateKey4", interval *21);
		Invoke ("CreateKey1", interval *22);
		Invoke ("CreateKey2", interval *22);
		Invoke ("CreateKey3", interval *22);
		Invoke ("CreateKey4", interval *22);
		Invoke ("CreateKey1", interval *22.5f);
		Invoke ("CreateKey2", interval *22.5f);
		Invoke ("CreateKey3", interval *22.5f);
		Invoke ("CreateKey4", interval *22.5f);
		Invoke ("CreateKey1", interval *23);
		Invoke ("CreateKey2", interval *23.5f);
		Invoke ("CreateKey3", interval *24);
		Invoke ("CreateKey4", interval *24.5f);
		Invoke ("CreateKey4", interval *25);
		Invoke ("CreateKey1", interval *26);
		Invoke ("CreateKey2", interval *26);
		Invoke ("CreateKey3", interval *26);
		Invoke ("CreateKey4", interval *26);
		Invoke ("CreateKey1", interval *27);
		Invoke ("CreateKey4", interval *27);
		Invoke ("CreateKey2", interval *27.5f);
		Invoke ("CreateKey3", interval *27.5f);
		Invoke ("CreateKey1", interval *28);
		Invoke ("CreateKey4", interval *28);
		Invoke ("CreateKey1", interval *29);
		Invoke ("CreateKey2", interval *29);
		Invoke ("CreateKey3", interval *29);
		Invoke ("CreateKey4", interval *29);
		Invoke ("CreateKey1", interval *29.5f);
		Invoke ("CreateKey2", interval *29.5f);
		Invoke ("CreateKey3", interval *29.5f);
		Invoke ("CreateKey4", interval *29.5f);
		Invoke ("CreateKey2", interval *30);
		Invoke ("CreateKey3", interval *30);
		Invoke ("CreateKey1", interval *31);
		Invoke ("CreateKey4", interval *31);
		Invoke ("CreateKey1", interval *32);
		Invoke ("CreateKey1", interval *32.5f);
		Invoke ("CreateKey1", interval *33);
		Invoke ("CreateKey1", interval *33.5f);
		Invoke ("CreateKey1", interval *34);
		Invoke ("CreateKey1", interval *34.5f);
		Invoke ("CreateKey1", interval *35);
		Invoke ("CreateKey1", interval *35.5f);
		Invoke ("CreateKey1", interval *36);
		Invoke ("CreateKey1", interval *36.5f);
		Invoke ("CreateKey4", interval *32);
		Invoke ("CreateKey4", interval *33);
		Invoke ("CreateKey4", interval *34);
		Invoke ("CreateKey4", interval *35);
		Invoke ("CreateKey4", interval *36);
		Invoke ("CreateKey2", interval *33);
		Invoke ("CreateKey2", interval *36);
		Invoke ("CreateKey1", interval *37);
		Invoke ("CreateKey2", interval *37);
		Invoke ("CreateKey3", interval *37);
		Invoke ("CreateKey4", interval *37);
		Invoke ("CreateKey1", interval *38);
		Invoke ("CreateKey2", interval *39);
		Invoke ("CreateKey3", interval *40);
		Invoke ("CreateKey4", interval *40);
		Invoke ("CreateKey1", interval *41);
		Invoke ("CreateKey2", interval *41);
		Invoke ("CreateKey3", interval *41);
		Invoke ("CreateKey4", interval *41);
		Invoke ("CreateKey1", interval *41.5f);
		Invoke ("CreateKey2", interval *41.5f);
		Invoke ("CreateKey3", interval *41.5f);
		Invoke ("CreateKey4", interval *41.5f);
		Invoke ("CreateKey1", interval *42);
		Invoke ("CreateKey2", interval *42);
		Invoke ("CreateKey3", interval *42);
		Invoke ("CreateKey4", interval *42);
		Invoke ("CreateKey1", interval *42.5f);
		Invoke ("CreateKey2", interval *42.5f);
		Invoke ("CreateKey3", interval *42.5f);
		Invoke ("CreateKey4", interval *42.5f);
		Invoke ("CreateKey4", interval *43);
		Invoke ("CreateKey1", interval *44);
		Invoke ("CreateKey2", interval *44);
		Invoke ("CreateKey2", interval *44.5f);
		Invoke ("CreateKey3", interval *44);
		Invoke ("CreateKey4", interval *44);
		Invoke ("CreateKey1", interval *45);
		Invoke ("CreateKey4", interval *45);
		Invoke ("CreateKey2", interval *46);
		Invoke ("CreateKey4", interval *46);
		Invoke ("CreateKey1", interval *47);
		Invoke ("CreateKey3", interval *47);
		Invoke ("CreateKey4", interval *48);
		Invoke ("CreateKey1", interval *48);
		Invoke ("CreateKey4", interval *49);
		Invoke ("CreateKey3", interval *49);
		Invoke ("CreateKey1", interval *50);
		Invoke ("CreateKey2", interval *50);
		Invoke ("CreateKey3", interval *50);
		Invoke ("CreateKey4", interval *50);
		Invoke ("CreateKey1", interval *50.5f);
		Invoke ("CreateKey2", interval *50.5f);
		Invoke ("CreateKey3", interval *50.5f);
		Invoke ("CreateKey4", interval *50.5f);
		Invoke ("CreateKey1", interval *51.5f);
		Invoke ("CreateKey2", interval *51.8f);
		Invoke ("CreateKey3", interval *52);
		Invoke ("CreateKey4", interval *52);
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
}
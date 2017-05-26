using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsWeek1_4 : MonoBehaviour {

	public GameObject key;
	public Text scoreStr;
	public GameObject hero;

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
		this.numberOfKeys = 140;
		this.TheLevel();
		this.longStrike = strike = 0;
	}

	private void Update () {
		scoreStr.text = "SCORE: " + score;
		if(numberOfKeys <= 0){
			EndStrike ();//Se nao errar nao entra
			PlayerPrefs.SetInt ("StrikeLv1-4", longStrike);
			PlayerPrefs.SetInt ("ScoreLv1-4", score);
			SceneManager.LoadScene("_EndWeek1-4");
		}
		if(error >= 8){
			SceneManager.LoadScene("_GameOver");
		}
	}

	private void TheLevel(){		
		Invoke ("CreateKey1", 0.01f);
		Invoke ("CreateKey2", 0.5f);
		Invoke ("CreateKey3", 1.0f);
		Invoke ("CreateKey1", 1.0f);
		Invoke ("CreateKey3", 1.699f);
		Invoke ("CreateKey1", interval *2);
		Invoke ("CreateKey2", interval *3);
		Invoke ("CreateKey3", interval *4);
		Invoke ("CreateKey1", interval *5);
		Invoke ("CreateKey2", interval *6);
		Invoke ("CreateKey3", interval *7);
		Invoke ("CreateKey3", interval *8);
		Invoke ("CreateKey2", interval *9);
		Invoke ("CreateKey1", interval *10);
		Invoke ("CreateKey1", interval *11);
		Invoke ("CreateKey2", interval *12);
		Invoke ("CreateKey3", interval *13);
		Invoke ("CreateKey2", interval *14);
		Invoke ("CreateKey2", interval *15);
		Invoke ("CreateKey2", interval *16);
		Invoke ("CreateKey1", interval *17);
		Invoke ("CreateKey3", interval *17);
		Invoke ("CreateKey2", interval *18);
		Invoke ("CreateKey1", interval *19);
		Invoke ("CreateKey2", interval *19);
		Invoke ("CreateKey3", interval *20);
		Invoke ("CreateKey1", interval *21);
		Invoke ("CreateKey2", interval *22);
		Invoke ("CreateKey3", interval *23);
		Invoke ("CreateKey2", interval *23.5f);
		Invoke ("CreateKey1", interval *24);
		Invoke ("CreateKey1", interval *25);
		Invoke ("CreateKey1", interval *26);
		Invoke ("CreateKey1", interval *27);
		Invoke ("CreateKey1", interval *28);
		Invoke ("CreateKey2", interval *26);
		Invoke ("CreateKey3", interval *28);
		Invoke ("CreateKey3", interval *29);
		Invoke ("CreateKey3", interval *30);
		Invoke ("CreateKey3", interval *31);
		Invoke ("CreateKey3", interval *32);
		Invoke ("CreateKey3", interval *33);
		Invoke ("CreateKey3", interval *34);
		Invoke ("CreateKey3", interval *35);
		Invoke ("CreateKey1", interval *30);
		Invoke ("CreateKey2", interval *31);
		Invoke ("CreateKey1", interval *32);
		Invoke ("CreateKey2", interval *32);
		Invoke ("CreateKey2", interval *33);
		Invoke ("CreateKey1", interval *34);
		Invoke ("CreateKey3", interval *35);
		Invoke ("CreateKey1", interval *36);
		Invoke ("CreateKey3", interval *37);
		Invoke ("CreateKey1", interval *38);
		Invoke ("CreateKey2", interval *39);
		Invoke ("CreateKey1", interval *40);
		Invoke ("CreateKey1", interval *42);
		Invoke ("CreateKey1", interval *44);
		Invoke ("CreateKey2", interval *41);
		Invoke ("CreateKey2", interval *43);
		Invoke ("CreateKey2", interval *45);
		Invoke ("CreateKey2", interval *47);
		Invoke ("CreateKey2", interval *49);
		Invoke ("CreateKey1", interval *50);
		Invoke ("CreateKey2", interval *50);
		Invoke ("CreateKey3", interval *50);
		Invoke ("CreateKey1", interval *51);
		Invoke ("CreateKey2", interval *51);
		Invoke ("CreateKey3", interval *51);
		Invoke ("CreateKey1", interval *52);
		Invoke ("CreateKey2", interval *52);
		Invoke ("CreateKey3", interval *52);
		Invoke ("CreateKey1", interval *53);
		Invoke ("CreateKey2", interval *53);
		Invoke ("CreateKey3", interval *53);
		Invoke ("CreateKey1", interval *54);
		Invoke ("CreateKey2", interval *54);
		Invoke ("CreateKey3", interval *54);
		Invoke ("CreateKey1", interval *55);
		Invoke ("CreateKey2", interval *56);
		Invoke ("CreateKey3", interval *57);
		Invoke ("CreateKey1", interval *58);
		Invoke ("CreateKey2", interval *58);
		Invoke ("CreateKey3", interval *58);
		Invoke ("CreateKey1", interval *58.5f);
		Invoke ("CreateKey2", interval *59);
		Invoke ("CreateKey1", interval *60);
		Invoke ("CreateKey1", interval *61);
		Invoke ("CreateKey2", interval *62);
		Invoke ("CreateKey3", interval *62);
		Invoke ("CreateKey1", interval *63);
		Invoke ("CreateKey2", interval *64);
		Invoke ("CreateKey3", interval *64);
		Invoke ("CreateKey2", interval *65);
		Invoke ("CreateKey3", interval *65);
		Invoke ("CreateKey1", interval *66);
		Invoke ("CreateKey3", interval *67);
		Invoke ("CreateKey2", interval *67.5f);
		Invoke ("CreateKey1", interval *67);
		Invoke ("CreateKey1", interval *68);
		Invoke ("CreateKey2", interval *68);
		Invoke ("CreateKey3", interval *68);
		Invoke ("CreateKey1", interval *69);
		Invoke ("CreateKey2", interval *69);
		Invoke ("CreateKey3", interval *69);
		Invoke ("CreateKey1", interval *70);
		Invoke ("CreateKey2", interval *71);
		Invoke ("CreateKey3", interval *70);
		Invoke ("CreateKey1", interval *72);
		Invoke ("CreateKey3", interval *72);
		Invoke ("CreateKey2", interval *73);
		Invoke ("CreateKey1", interval *74);
		Invoke ("CreateKey3", interval *74);
		Invoke ("CreateKey2", interval *75);
		Invoke ("CreateKey1", interval *76);
		Invoke ("CreateKey3", interval *76);
		Invoke ("CreateKey2", interval *77);
		Invoke ("CreateKey1", interval *78);
		Invoke ("CreateKey3", interval *78);
		Invoke ("CreateKey2", interval *78);
		Invoke ("CreateKey1", interval *79);
		Invoke ("CreateKey3", interval *79);
		Invoke ("CreateKey2", interval *79);
		Invoke ("CreateKey3", interval *80);
		Invoke ("CreateKey2", interval *80);
		Invoke ("CreateKey1", interval *81);
		Invoke ("CreateKey3", interval *81);
		Invoke ("CreateKey2", interval *82);
		Invoke ("CreateKey3", interval *83);
		Invoke ("CreateKey1", interval *83);
		Invoke ("CreateKey3", interval *84);
		Invoke ("CreateKey1", interval *85);
		Invoke ("CreateKey2", interval *86);
		Invoke ("CreateKey3", interval *87);
		Invoke ("CreateKey1", interval *87);
		Invoke ("CreateKey2", interval *88);
		Invoke ("CreateKey1", interval *89);
		Invoke ("CreateKey3", interval *89);
		Invoke ("CreateKey2", interval *90);
		Invoke ("CreateKey2", interval * 90.5f);
	}


	private void BackFrame(){
		hero.SetActive(false);
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

	public void AddScore () {
		hero.SetActive(true);
		Invoke ("BackFrame", 0.25f);
		score++;
	}

	public void AddScore (int value) {
		score += value;
	}

	public void RemoveOneKey(){
		numberOfKeys--;
	}

	public void Error(){
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


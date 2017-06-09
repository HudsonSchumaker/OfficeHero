using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;
using System.Collections.Generic;
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
	public GameObject keyLeftPurple;
	public GameObject keyRightPurple;
	public Text scoreStr;
	public Text comboStr;
	public GameObject hero1;
	public GameObject hero2;
	public AudioClip key1;
	public AudioClip key2;
	public AudioClip key3;
	public AudioClip key4;
	public AudioClip slideKey;
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
	private float ks;//slide keys codes for audio 
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
		this.ks = 10.0f;
	}

	private void Update () {
		this.scoreStr.text = "SCORE : " + score;
		this.CheckBonus ();
		if(numberOfKeys <= 0){
			EndStrike ();//Se nao errar nao entra
			PlayerPrefs.SetInt ("StrikeLv2-1", longStrike);
			PlayerPrefs.SetInt ("ScoreLv2-1", score);
			SceneManager.LoadScene("_EndWeek2-1");
			Invoke ("NextScreen", 3.0f);
			Analytics.CustomEvent("WinLv2-1", new Dictionary<string, object>{
				{ "score", score },
				{ "strike", longStrike }
			});
		}
		if(error >= 8){
			Analytics.CustomEvent("gameOverLv2-1", new Dictionary<string, object>{
				{ "score", score },
				{ "strike", longStrike }
			});
			SceneManager.LoadScene("_GameOver");
		}
	}

	private void NextScreen(){
		SceneManager.LoadScene("_EndWeek2-1");
	}
		
	private void CreateKey1 () {
		if(normalKey == 0){
			Instantiate (key, new Vector3 (x1, y, z), Quaternion.identity);
		}
		else{
			Instantiate (keyPurple, new Vector3 (x1, y, z), Quaternion.identity);
		}
	}

	private void CreateKey2 () {
		if (normalKey == 0) {
			Instantiate (key, new Vector3 (x2, y, z), Quaternion.identity);	
		}
		else{
			Instantiate (keyPurple, new Vector3 (x2, y, z), Quaternion.identity);	
		}
	}

	private void CreateKey3 () {
		if (normalKey == 0) {
			Instantiate (key, new Vector3 (x3, y, z), Quaternion.identity);	
		}
		else{
			Instantiate (keyPurple, new Vector3 (x3, y, z), Quaternion.identity);	
		}
	}

	private void CreateKey4 () {
		if (normalKey == 0) {
			Instantiate (key, new Vector3 (x4, y, z), Quaternion.identity);	
		}
		else{
			Instantiate (keyPurple, new Vector3 (x4, y, z), Quaternion.identity);
		}
	}

	private void CreateKeyX2 () {
		Instantiate (keyX2, new Vector3 (x4, y, z), Quaternion.identity);//Atenção aqui
	}

	private void CreateKeyLeft () {
		if (normalKey == 0) {
			Instantiate (keyLeft, new Vector3 (x4, y, z), Quaternion.identity);	
		}else{
			Instantiate (keyLeftPurple, new Vector3 (x4, y, z), Quaternion.identity);	
		}
	}

	private void CreateKeyRight () {
		if (normalKey == 0) {
			Instantiate (keyRight, new Vector3 (x1, y, z), Quaternion.identity);	
		}else{
			Instantiate (keyRightPurple, new Vector3 (x1, y, z), Quaternion.identity);
		}
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
			return;
		}
		if (posX == ks) {
			HsAudioManager.instance.PlayAudioClip (slideKey);
		}
	}

	private void SetFrame1(){
		hero1.SetActive(false);
		hero2.SetActive(true);
	}

	private void SetFrame2(){
		hero2.SetActive(false);
	}

	private void CheckBonus(){
		if(strike < 20){
			combo = 1;
			comboStr.text = "COMBO : X1";
			return;
		}
		if(strike >19 && strike <40){
			combo = 2;
			comboStr.text = "COMBO : X2";
			return;
		}
		if(strike >39 && strike <60){
			combo = 3;
			comboStr.text = "COMBO : X3";
			return;
		}
		if(strike >59 && strike <80){
			combo = 4;
			comboStr.text = "COMBO : X4";
			return;
		}
		if(strike >79 && strike <100){
			combo = 5;
			comboStr.text = "COMBO : X5";
		}
	}

	public void AddScore (float posX) {
		playAudio (posX);
		hero1.SetActive(true);
		Invoke ("SetFrame1", 0.20f);
		Invoke ("SetFrame2", 0.40f);
		score += (hitPoint*combo*comboKeyX2);//Combos Aqui
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

	public void SetComboKeyX2(){
		normalKey = 1;// ativa key roxa
		comboKeyX2 = 2;
		Invoke ("RemoveComboKeyX2", 14.99f);
	}

	private void RemoveComboKeyX2(){
		normalKey = 0;// desativa key rox
		comboKeyX2 = 1;
	}

	private void TheLevel(){		
		Invoke ("CreateKeyLeft", 0.1f);
		Invoke ("CreateKeyLeft", 1.1f);
		Invoke ("CreateKeyLeft", 2.1f);
		//Invoke ("CreateKeyRight", 3.1f);
		Invoke ("CreateKeyLeft", 4.1f);
	//	Invoke ("CreateKeyRight", 5.1f);
		Invoke ("CreateKeyLeft", 6.1f);
	//	Invoke ("CreateKeyRight", 7.1f);
		Invoke ("CreateKeyLeft", 8.1f);
	//	Invoke ("CreateKeyRight", 9.1f);
		Invoke ("CreateKeyLeft", 10.1f);

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
	}
}
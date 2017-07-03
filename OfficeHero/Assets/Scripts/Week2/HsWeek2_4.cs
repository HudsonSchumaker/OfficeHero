using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsWeek2_4 : MonoBehaviour {

	public GameObject key;
	public GameObject keyPurple;
	public GameObject spaceBar;
	public GameObject spaceBarPurple;
	public GameObject keyEnter;
	public GameObject keyEnterPurple;
	public GameObject keyX2;
	public GameObject keyLeft;
	public GameObject keyRight;
	public GameObject keyLeftPurple;
	public GameObject keyRightPurple;
	public Text scoreStr;
	public Text comboStr;
	public Text errorsStr;
	public GameObject hero1;
	public GameObject hero2;
	public GameObject finished;
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
	private int maxErrors;
	private int combo;
	private int comboKeyX2;
	private int normalKey;
	private float x1, x2, x3, x4;
	private float spb;
	private float ks;
	private float y;
	private float z;
	private float interval;

	private void Start () {
		AdManager.instance.RemoveBanners ();
		this.numberOfKeys = 91;
		this.scoreStr.text = "SCORE: " + score;
		this.error = 0;
		this.maxErrors = 8;
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
		this.spb = 0.0f;
		this.ks = 10.0f;
		this.y = 5.5f;
		this.z = 0.0f;
		this.interval = 1.1f;
		this.TheLevel ();
	}

	private void Update () {
		this.scoreStr.text = "SCORE : " + score;
		this.errorsStr.text = "ERRORS : " + error + " / " + maxErrors;
		this.CheckBonus ();
		if(numberOfKeys <= 0){
			EndStrike ();//Se nao errar nao entra
			finished.SetActive (true);
			PlayerPrefs.SetInt ("StrikeLv2-4", longStrike);
			PlayerPrefs.SetInt ("ScoreLv2-4", score);
			Invoke ("NextScreen", 3.0f);
			Analytics.CustomEvent("WinLv2-4", new Dictionary<string, object>{
				{ "score", score },
				{ "strike", longStrike }
			});
		}
		if(error >= maxErrors){
			Analytics.CustomEvent("gameOverLv2-4", new Dictionary<string, object>{
				{ "score", score },
				{ "strike", longStrike }
			});
			SceneManager.LoadScene("_GameOver");
		}
	}

	private void NextScreen(){
		SceneManager.LoadScene("_EndWeek2-4");
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

	private void CreateSpacebar(){
		if (normalKey == 0) {
			Instantiate (spaceBar, new Vector3 (spb, y, z), Quaternion.identity);	
		}
		else{
			Instantiate (spaceBarPurple, new Vector3 (spb, y, z), Quaternion.identity);
		}
	}

	private void CreateEnter1 () {
		if(normalKey == 0){
			Instantiate (keyEnter, new Vector3 (x1, y, z), Quaternion.identity);
		}
		else{
			Instantiate (keyEnterPurple, new Vector3 (x1, y, z), Quaternion.identity);
		}
	}

	private void CreateEnter2 () {
		if (normalKey == 0) {
			Instantiate (keyEnter, new Vector3 (x2, y, z), Quaternion.identity);	
		}
		else{
			Instantiate (keyEnterPurple, new Vector3 (x2, y, z), Quaternion.identity);	
		}
	}

	private void CreateEnter3 () {
		if (normalKey == 0) {
			Instantiate (keyEnter, new Vector3 (x3, y, z), Quaternion.identity);	
		}
		else{
			Instantiate (keyEnterPurple, new Vector3 (x3, y, z), Quaternion.identity);	
		}
	}

	private void CreateEnter4 () {
		if (normalKey == 0) {
			Instantiate (keyEnter, new Vector3 (x4, y, z), Quaternion.identity);	
		}
		else{
			Instantiate (keyEnterPurple, new Vector3 (x4, y, z), Quaternion.identity);
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
			PlayKeySound (key1);
			return;
		}
		if(posX == x2){
			PlayKeySound (key2);
			return;
		}
		if(posX == x3){
			PlayKeySound (key3);
			return;
		}
		if(posX == x4){
			PlayKeySound (key4);
			return;
		}
		if(posX == spb){
			PlayKeySound (key4);
			return;
		}
		if (posX == ks) {
			PlayKeySound (slideKey);
		}
	}

	private void PlayKeySound(AudioClip clip){
		HsAudioManager.instance.PlayAudioClip (clip);
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
		PlayKeySound (lostKey);
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
		Invoke ("CreateKeyX2", interval*18);//Aqui keyComboX2	
		Invoke ("CreateKeyX2", interval*28);//Aqui keyComboX2	

		Invoke ("CreateEnter2", interval *2);
		Invoke ("CreateKeyLeft", interval*3);
		Invoke ("CreateKeyLeft", interval*4);
		Invoke ("CreateKey2", interval *5);
		Invoke ("CreateKey3", interval *5);
		Invoke ("CreateKey2", interval *6);
		Invoke ("CreateKey3", interval *6);
		Invoke ("CreateKey2", interval *7);
		Invoke ("CreateKey3", interval *7);
		Invoke ("CreateKey4", interval *7);
		Invoke ("CreateKey1", interval *8);
		Invoke ("CreateKey2", interval *8);
		Invoke ("CreateKey3", interval *8);
		Invoke ("CreateSpacebar", interval*9);
		Invoke ("CreateSpacebar", interval*10);
		Invoke ("CreateKey2", interval *11);
		Invoke ("CreateKey2", interval *11);
		Invoke ("CreateKey1", interval *12);
		Invoke ("CreateKey2", interval *12);
		Invoke ("CreateKey3", interval *13);
		Invoke ("CreateKey4", interval *14);
		Invoke ("CreateKey3", interval *15);
		Invoke ("CreateKey4", interval *16);
		Invoke ("CreateKey1", interval *17);
		Invoke ("CreateKey2", interval *17);
		Invoke ("CreateKey3", interval *17);
		Invoke ("CreateKeyRight", interval*18);
		Invoke ("CreateKeyRight", interval*19);
		Invoke ("CreateKeyRight", interval*20);
		Invoke ("CreateSpacebar", interval*21);
		Invoke ("CreateKey2", interval *22);
		Invoke ("CreateKey3", interval *22);
		Invoke ("CreateKey1", interval *23);
		Invoke ("CreateKey2", interval *23);
		Invoke ("CreateKey2", interval *24);
		Invoke ("CreateKey3", interval *24);
		Invoke ("CreateKey3", interval *25);
		Invoke ("CreateKey4", interval *25);
		Invoke ("CreateKey2", interval *26);
		Invoke ("CreateKey3", interval *26);
		Invoke ("CreateKey1", interval *27);
		Invoke ("CreateKey2", interval *27);
		Invoke ("CreateKey1", interval *28);
		Invoke ("CreateKey2", interval *28);
		Invoke ("CreateKey2", interval *29);
		Invoke ("CreateKey3", interval *29);
		Invoke ("CreateKey1", interval *30);
		Invoke ("CreateKey2", interval *30);
		Invoke ("CreateKey1", interval *31);
		Invoke ("CreateKey2", interval *31);
		Invoke ("CreateKey4", interval *32);
		Invoke ("CreateKey2", interval *33);
		Invoke ("CreateKey3", interval *33);
		Invoke ("CreateKey4", interval *33);
		Invoke ("CreateKey2", interval *34);
		Invoke ("CreateKey1", interval *35);
		Invoke ("CreateKey2", interval *35);
		Invoke ("CreateKey3", interval *35);
		Invoke ("CreateSpacebar", interval*36);
		Invoke ("CreateKeyLeft" , interval*37);
		Invoke ("CreateKeyRight", interval*38);
		Invoke ("CreateKeyLeft" , interval*39);
		Invoke ("CreateKeyRight", interval*40);
		Invoke ("CreateKeyLeft" , interval*41);
		Invoke ("CreateKeyRight", interval*42);
		Invoke ("CreateSpacebar", interval*43);
		Invoke ("CreateKey3", interval *44);
		Invoke ("CreateKey3", interval *45);
		Invoke ("CreateKey3", interval *46);
		Invoke ("CreateKey2", interval *47);
		Invoke ("CreateKey3", interval *47);
		Invoke ("CreateKey1", interval *48);
		Invoke ("CreateKey2", interval *48);
		Invoke ("CreateKey3", interval *48);
		Invoke ("CreateSpacebar", interval*49);
		Invoke ("CreateKey3", interval *50);
		Invoke ("CreateKey2", interval *51);
		Invoke ("CreateKey3", interval *51);
		Invoke ("CreateKey2", interval *52);
		Invoke ("CreateKey1", interval *53);
		Invoke ("CreateKey2", interval *53);
		Invoke ("CreateKey1", interval *54);
		Invoke ("CreateKey2", interval *54);
		Invoke ("CreateKey3", interval *55);
		Invoke ("CreateKey2", interval *56);
		Invoke ("CreateKey3", interval *57);
		Invoke ("CreateKey4", interval *58);
		Invoke ("CreateKey1", interval *59);
		Invoke ("CreateKey1", interval *60);
		Invoke ("CreateKey2", interval *60);
		Invoke ("CreateKey3", interval *60);
	}
}
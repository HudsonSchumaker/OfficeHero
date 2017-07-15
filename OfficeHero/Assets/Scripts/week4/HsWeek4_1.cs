using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsWeek4_1 : MonoBehaviour {

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
	public GameObject mouseRight;
	//public GameObject mouseRightPurple;
	public GameObject mouseLeft;
	//public GameObject mouseLeftPurple;
	public Text scoreStr;
	public Text comboStr;
	public Text errorsStr;
	public GameObject hero1;
	public GameObject hero2;
	public GameObject finished;
	public GameObject paused;
	public AudioClip key1;
	public AudioClip key2;
	public AudioClip key3;
	public AudioClip key4;
	public AudioClip lostKey;
	public AudioSource music;

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
	private float mouse;
	private float y;
	private float z;
	private float interval;
	private bool isGameShown;

	private void Start () {
		AdManager.instance.RemoveBanners ();
		this.numberOfKeys = 124;
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
		this.mouse = 0.0f;
		this.y = 5.5f;
		this.z = 0.0f;
		this.interval = 0.6f;
		this.isGameShown = true;
		this.TheLevel ();
	}

	private void Update () {
		this.scoreStr.text = "SCORE : " + score;
		this.errorsStr.text = "ERRORS : " + error + " / " + maxErrors;
		this.CheckBonus ();
		if(numberOfKeys <= 0){
			EndStrike ();//Se nao errar nao entra
			finished.SetActive (true);
			PlayerPrefs.SetInt ("StrikeLv4-1", longStrike);
			PlayerPrefs.SetInt ("ScoreLv4-1", score);
			Invoke ("NextScreen", 3.0f);
			Analytics.CustomEvent("WinLv4-1", new Dictionary<string, object>{
				{ "score", score },
				{ "strike", longStrike }
			});
		}
		if(error >= maxErrors){
			Analytics.CustomEvent("gameOverLv4-1", new Dictionary<string, object>{
				{ "score", score },
				{ "strike", longStrike }
			});
			PlayerPrefs.SetInt ("gameOverStage", 4);
			SceneManager.LoadScene("_GameOver");
		}
	}

	private void NextScreen(){
		SceneManager.LoadScene("_EndWeek4_1");
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

	private void CreateMouseLeft(){
		if (normalKey == 0) {
			Instantiate (mouseLeft, new Vector3 (mouse, y, z), Quaternion.identity);	
		}
		else{
			Instantiate (mouseLeft, new Vector3 (mouse, y, z), Quaternion.identity);
		}
	}

	private void CreateMouseRight(){
		if (normalKey == 0) {
			Instantiate (mouseRight, new Vector3 (mouse, y, z), Quaternion.identity);	
		}
		else{
			Instantiate (mouseRight, new Vector3 (mouse, y, z), Quaternion.identity);
		}
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

	private void CreateKeyX2 () {
		Instantiate (keyX2, new Vector3 (x4, y, z), Quaternion.identity);//Atenção aqui
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
		score += (hitPoint*combo*comboKeyX2);//Aqui Combos
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

	public void HsPauseGame (){
		if(isGameShown){
			this.isGameShown = false;
		}else{
			this.isGameShown = true;
		}
		if (!isGameShown) {
			AdManager.instance.ShowBannerDown ();
			Time.timeScale = 0;
			paused.SetActive (true);
			music.Pause ();
		} else {
			AdManager.instance.RemoveBanners ();
			Time.timeScale = 1;
			paused.SetActive (false);
			music.Play ();
		}
	}

	public void HsBack(){
		AdManager.instance.LoadBigBanner ();
		SceneManager.LoadScene("_MainScreen");
	}

	private void TheLevel(){	
		Invoke ("CreateKeyX2", interval*18);//Aqui keyComboX2	
		Invoke ("CreateKeyX2", interval*48);//Aqui keyComboX2
		Invoke ("CreateKeyX2", interval*78);//Aqui keyComboX2	
		Invoke ("CreateKeyX2", interval*99);//Aqui keyComboX2		

		Invoke ("CreateSpacebar", 0.1f);
		Invoke ("CreateEnter2", interval *2);
		Invoke ("CreateKeyLeft", interval*3);
		Invoke ("CreateEnter2", interval *4);
		Invoke ("CreateEnter2", interval *4);
		Invoke ("CreateSpacebar", interval *5);
		Invoke ("CreateKeyLeft", interval*6);
		Invoke ("CreateSpacebar", interval *7);
		Invoke ("CreateKeyRight", interval*8);
		Invoke ("CreateSpacebar", interval *9);
		Invoke ("CreateKeyRight", interval*10);
		Invoke ("CreateSpacebar", interval *11);
		Invoke ("CreateKey1", interval *12);
		Invoke ("CreateKey2", interval *12);
		Invoke ("CreateKey3", interval *12);
		Invoke ("CreateKey4", interval *12);
		Invoke ("CreateKey2", interval *13);
		Invoke ("CreateKey3", interval *13);
		Invoke ("CreateKey4", interval *13);
		Invoke ("CreateKey3", interval *14);
		Invoke ("CreateKey4", interval *14);
		Invoke ("CreateKey4", interval *15);
		Invoke ("CreateKey1", interval *16);
		Invoke ("CreateKey2", interval *16);
		Invoke ("CreateKey3", interval *16);
		Invoke ("CreateKey4", interval *16);
		Invoke ("CreateKey1", interval *17);
		Invoke ("CreateKey2", interval *17);
		Invoke ("CreateKey3", interval *17);
		Invoke ("CreateKey1", interval *18);
		Invoke ("CreateKey2", interval *18);
		Invoke ("CreateKey1", interval *19);
		Invoke ("CreateKey1", interval *20);
		Invoke ("CreateKey2", interval *21);
		Invoke ("CreateKey3", interval *22);
		Invoke ("CreateKey4", interval *23);
		Invoke ("CreateKey3", interval *24);
		Invoke ("CreateKey2", interval *25);
		Invoke ("CreateKey1", interval *26);
		Invoke ("CreateMouseRight",interval *27);
		Invoke ("CreateMouseRight",interval *28);
		Invoke ("CreateMouseRight",interval *29);
		Invoke ("CreateSpacebar", interval *30);
		Invoke ("CreateMouseLeft",interval *31);
		Invoke ("CreateMouseLeft",interval *32);
		Invoke ("CreateMouseLeft",interval *33);
		Invoke ("CreateSpacebar", interval *34);
		Invoke ("CreateEnter2", interval *35);
		Invoke ("CreateEnter4", interval *35);
		Invoke ("CreateEnter2", interval *36);
		Invoke ("CreateSpacebar", interval *37);
		Invoke ("CreateSpacebar", interval *38);
		Invoke ("CreateKey4", interval *39);
		Invoke ("CreateKey3", interval *40);
		Invoke ("CreateKey2", interval *41);
		Invoke ("CreateKey1", interval *42);
		Invoke ("CreateKey4", interval *43);
		Invoke ("CreateKey3", interval *44);
		Invoke ("CreateKey2", interval *45);
		Invoke ("CreateKey1", interval *46);
		Invoke ("CreateKey4", interval *47);
		Invoke ("CreateKey3", interval *48);
		Invoke ("CreateKey2", interval *49);
		Invoke ("CreateKey1", interval *50);
		Invoke ("CreateKey4", interval *51);
		Invoke ("CreateKey3", interval *52);
		Invoke ("CreateKey2", interval *53);
		Invoke ("CreateKey4", interval *54);
		Invoke ("CreateKey3", interval *55);
		Invoke ("CreateKey2", interval *56);
		Invoke ("CreateKey4", interval *57);
		Invoke ("CreateKey3", interval *58);
		Invoke ("CreateKey2", interval *59);
		Invoke ("CreateSpacebar", interval *60);
		Invoke ("CreateKeyLeft", interval*61);
		Invoke ("CreateKey2", interval *62);
		Invoke ("CreateKey3", interval *63);
		Invoke ("CreateKey2", interval *64);
		Invoke ("CreateKey4", interval *64);
		Invoke ("CreateKey1", interval *65);
		Invoke ("CreateKey2", interval *65);
		Invoke ("CreateKey4", interval *66);
		Invoke ("CreateKey3", interval *67);
		Invoke ("CreateKey2", interval *68);
		Invoke ("CreateKey3", interval *69);
		Invoke ("CreateKey2", interval *70);
		Invoke ("CreateKey2", interval *71);
		Invoke ("CreateKey3", interval *72);
		Invoke ("CreateEnter1", interval *73);
		Invoke ("CreateEnter2", interval *73);
		Invoke ("CreateEnter3", interval *74);
		Invoke ("CreateEnter4", interval *75);
		Invoke ("CreateEnter3", interval *76);
		Invoke ("CreateEnter2", interval *77);
		Invoke ("CreateEnter1", interval *78);
		Invoke ("CreateSpacebar", interval *79);
		Invoke ("CreateKeyLeft", interval*80);
		Invoke ("CreateSpacebar", interval *81);
		Invoke ("CreateKeyLeft", interval*82);
		Invoke ("CreateSpacebar", interval *83);
		Invoke ("CreateKeyRight", interval*84);
		Invoke ("CreateSpacebar", interval *85);
		Invoke ("CreateSpacebar", interval *86);
		Invoke ("CreateSpacebar", interval *87);
		Invoke ("CreateMouseLeft",interval *88);
		Invoke ("CreateKey1", interval *89);
		Invoke ("CreateKey2", interval *89);
		Invoke ("CreateKey3", interval *89);
		Invoke ("CreateKey4", interval *89);
		Invoke ("CreateKey3", interval *90);
		Invoke ("CreateKey4", interval *90);
		Invoke ("CreateKey2", interval *91);
		Invoke ("CreateKey3", interval *91);
		Invoke ("CreateKey1", interval *92);
		Invoke ("CreateKey2", interval *92);
		Invoke ("CreateKey2", interval *93);
		Invoke ("CreateKey3", interval *93);
		Invoke ("CreateKey4", interval *94);
		Invoke ("CreateMouseRight",interval *95);
		Invoke ("CreateEnter4", interval *96);
		Invoke ("CreateEnter1", interval *97);
		Invoke ("CreateKey4", interval *98);
		Invoke ("CreateSpacebar", interval *99);
		Invoke ("CreateMouseLeft",interval *100);
	}
}

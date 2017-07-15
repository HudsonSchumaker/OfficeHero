using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsWeek3_5 : MonoBehaviour {

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
		this.numberOfKeys = 115;
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
			PlayerPrefs.SetInt ("StrikeLv3-5", longStrike);
			PlayerPrefs.SetInt ("ScoreLv3-5", score);
			Invoke ("NextScreen", 3.0f);
			Analytics.CustomEvent("WinLv3-5", new Dictionary<string, object>{
				{ "score", score },
				{ "strike", longStrike }
			});
		}
		if(error >= maxErrors){
			Analytics.CustomEvent("gameOverLv3-5", new Dictionary<string, object>{
				{ "score", score },
				{ "strike", longStrike }
			});
			PlayerPrefs.SetInt ("gameOverStage", 3);
			SceneManager.LoadScene("_GameOver");
		}
	}

	private void NextScreen(){
		PlayerPrefs.SetInt ("okLv3-5", 1);
		SceneManager.LoadScene("_EndWeek3_5");
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

		Invoke ("CreateEnter2", 0.1f);
		Invoke ("CreateMouseLeft",interval *2);
		Invoke ("CreateSpacebar", interval *3);
		Invoke ("CreateMouseRight",interval *4);
		Invoke ("CreateMouseLeft",interval *5);
		Invoke ("CreateSpacebar", interval *6);
		Invoke ("CreateKey2", interval *7);
		Invoke ("CreateKey4", interval *7);
		Invoke ("CreateSpacebar", interval *8);
		Invoke ("CreateEnter2",  interval *9);
		Invoke ("CreateEnter4",  interval *10);
		Invoke ("CreateEnter1",  interval *11);
		Invoke ("CreateKey2", interval *12);
		Invoke ("CreateKey2", interval *13);
		Invoke ("CreateEnter2",  interval *14);
		Invoke ("CreateSpacebar", interval *15);
		Invoke ("CreateKey2", interval *16);
		Invoke ("CreateKey4", interval *16);
		Invoke ("CreateKey1", interval *17);
		Invoke ("CreateKey3", interval *18);
		Invoke ("CreateKey4", interval *18);
		Invoke ("CreateKey3", interval *19);
		Invoke ("CreateKey2", interval *20);
		Invoke ("CreateKey3", interval *20);
		Invoke ("CreateKey1", interval *21);
		Invoke ("CreateKey1", interval *22);
		Invoke ("CreateKey2", interval *22);
		Invoke ("CreateKey2", interval *23);
		Invoke ("CreateKey3", interval *23);
		Invoke ("CreateKey3", interval *24);
		Invoke ("CreateKey4", interval *25);
		Invoke ("CreateKey4", interval *26);
		Invoke ("CreateSpacebar", interval *27);
		Invoke ("CreateMouseLeft",interval *28);
		Invoke ("CreateMouseLeft",interval *29);
		Invoke ("CreateSpacebar", interval *30);
		Invoke ("CreateKey1", interval *31);
		Invoke ("CreateEnter4",  interval *31);
		Invoke ("CreateKey1", interval *32);
		Invoke ("CreateKey2", interval *32);
		Invoke ("CreateKey4", interval *32);
		Invoke ("CreateKey1", interval *33);
		Invoke ("CreateKey3", interval *33);
		Invoke ("CreateKey4", interval *33);
		Invoke ("CreateKey3", interval *34);
		Invoke ("CreateKey4", interval *34);
		Invoke ("CreateKey1", interval *35);
		Invoke ("CreateKey2", interval *35);
		Invoke ("CreateKey2", interval *36);
		Invoke ("CreateKey4", interval *36);
		Invoke ("CreateKey1", interval *37);
		Invoke ("CreateKey2", interval *37);
		Invoke ("CreateKey3", interval *38);
		Invoke ("CreateKey4", interval *38);
		Invoke ("CreateKey4", interval *39);
		Invoke ("CreateKey3", interval *40);
		Invoke ("CreateKey3", interval *41);
		Invoke ("CreateKey2", interval *42);
		Invoke ("CreateKey1", interval *43);
		Invoke ("CreateSpacebar", interval *44);
		Invoke ("CreateMouseRight",interval *45);
		Invoke ("CreateMouseLeft",interval *46);
		Invoke ("CreateSpacebar", interval *47);
		Invoke ("CreateMouseRight",interval *48);
		Invoke ("CreateMouseRight",interval *49);
		Invoke ("CreateMouseLeft",interval *50);
		Invoke ("CreateKey2", interval *51);
		Invoke ("CreateKey2", interval *52);
		Invoke ("CreateSpacebar", interval *53);
		Invoke ("CreateKey1", interval *54);
		Invoke ("CreateKey2", interval *54);
		Invoke ("CreateKey3", interval *54);
		Invoke ("CreateKey4", interval *54);
		Invoke ("CreateSpacebar", interval *55);
		Invoke ("CreateMouseRight",interval *56);
		Invoke ("CreateEnter4",  interval *57);
		Invoke ("CreateMouseLeft",interval *58);
		Invoke ("CreateSpacebar", interval *59);
		Invoke ("CreateKey2", interval *60);
		Invoke ("CreateKey3", interval *61);
		Invoke ("CreateKey4", interval *62);
		Invoke ("CreateKey1", interval *63);
		Invoke ("CreateKey2", interval *64);
		Invoke ("CreateKey3", interval *65);
		Invoke ("CreateKey1", interval *66);
		Invoke ("CreateKey4", interval *67);
		Invoke ("CreateKey4", interval *68);
		Invoke ("CreateKey3", interval *69);
		Invoke ("CreateKey2", interval *70);
		Invoke ("CreateKey1", interval *71);
		Invoke ("CreateKey2", interval *72);
		Invoke ("CreateKey3", interval *73);
		Invoke ("CreateEnter4",  interval *74);
		Invoke ("CreateSpacebar", interval *75);
		Invoke ("CreateEnter1",  interval *76);
		Invoke ("CreateSpacebar", interval *77);
		Invoke ("CreateKey4", interval *78);
		Invoke ("CreateKey4", interval *79);
		Invoke ("CreateKey3", interval *80);
		Invoke ("CreateKey2", interval *81);
		Invoke ("CreateKey1", interval *82);
		Invoke ("CreateKey3", interval *83);
		Invoke ("CreateKey2", interval *84);
		Invoke ("CreateKey3", interval *85);
		Invoke ("CreateKey4", interval *86);
		Invoke ("CreateKey1", interval *87);
		Invoke ("CreateKey2", interval *87);
		Invoke ("CreateKey3", interval *87);
		Invoke ("CreateKey4", interval *87);
		Invoke ("CreateKey2", interval *88);
		Invoke ("CreateKey3", interval *88);
		Invoke ("CreateKey4", interval *89);
		Invoke ("CreateKey3", interval *90);
		Invoke ("CreateKey2", interval *91);
		Invoke ("CreateSpacebar", interval *92);
	}
}
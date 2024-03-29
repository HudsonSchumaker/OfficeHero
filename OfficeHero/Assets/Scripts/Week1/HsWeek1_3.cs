﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsWeek1_3 : MonoBehaviour {

	public GameObject key;
	public GameObject keyPurple;
	public GameObject spaceBar;
	public GameObject spaceBarPurple;
	public GameObject keyEnter;
	public GameObject keyEnterPurple;
	public GameObject keyX2;
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
	private float y;
	private float z;
	private float interval;
	private bool isGameShown;

	private void Start () {
		AdManager.instance.RemoveBanners ();
		this.numberOfKeys = 56;
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
		this.y = 5.5f;
		this.z = 0.0f;
		this.interval = 0.8f;
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
			PlayerPrefs.SetInt ("StrikeLv1-3", longStrike);
			PlayerPrefs.SetInt ("ScoreLv1-3", score);
			Invoke ("NextScreen", 3.0f);
			Analytics.CustomEvent("winLv1-3", new Dictionary<string, object>{
				{ "score", score },
				{ "strike", longStrike }
			});
		}
		if(error >= maxErrors){
			Analytics.CustomEvent("gameOverLv1-3", new Dictionary<string, object>{
				{ "score", score },
				{ "strike", longStrike }
			});
			PlayerPrefs.SetInt ("gameOverStage", 1);
			SceneManager.LoadScene("_GameOver");
		}
	}

	private void NextScreen(){
		PlayerPrefs.SetInt ("okLv1-3", 1);
		SceneManager.LoadScene("_EndWeek1-3");
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
		Instantiate (keyX2, new Vector3 (x2, y, z), Quaternion.identity);//Atenção aqui
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
			comboStr.text = "COMBO : X 1";
			return;
		}
		if(strike >19 && strike <40){
			combo = 2;
			comboStr.text = "COMBO : X 2";
			return;
		}
		if(strike >39 && strike <60){
			combo = 3;
			comboStr.text = "COMBO : X 3";
			return;
		}
		if(strike >59 && strike <80){
			combo = 4;
			comboStr.text = "COMBO : X 4";
			return;
		}
		if(strike >79 && strike <100){
			combo = 5;
			comboStr.text = "COMBO : X 5";
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
		Invoke ("RemoveComboKeyX2", 19.99f);
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
		Invoke ("CreateKeyX2", interval*10);//Aqui keyComboX2	
		Invoke ("CreateKeyX2", interval*38);//Aqui keyComboX2	

		Invoke ("CreateEnter3", 0.1f);
		Invoke ("CreateKey2", interval);
		Invoke ("CreateKey1", interval*2);
		Invoke ("CreateEnter2", interval*3);
		Invoke ("CreateKey2", interval*4);
		Invoke ("CreateKey4", interval*5);
		Invoke ("CreateKey4", interval*6);
		Invoke ("CreateEnter3", interval*7);
		Invoke ("CreateKey1", interval*8);
		Invoke ("CreateKey1", interval*9);
		Invoke ("CreateKey2", interval*10);
		Invoke ("CreateKey2", interval*11);
		Invoke ("CreateKey4", interval*12);
		Invoke ("CreateKey4", interval*13);
		Invoke ("CreateKey3", interval*14);
		Invoke ("CreateKey1", interval*15);
		Invoke ("CreateKey3", interval*16);
		Invoke ("CreateEnter3", interval*17);
		Invoke ("CreateKey3", interval*18);
		Invoke ("CreateKey3", interval*19);
		Invoke ("CreateEnter2", interval*20);
		Invoke ("CreateEnter3", interval*21);
		Invoke ("CreateKey2", interval*22);
		Invoke ("CreateKey4", interval*22);
		Invoke ("CreateKey2", interval*23);
		Invoke ("CreateKey3", interval*23);
		Invoke ("CreateKey2", interval*24);
		Invoke ("CreateKey3", interval*24);
		Invoke ("CreateKey1", interval*25);
		Invoke ("CreateKey4", interval*25);
		Invoke ("CreateKey1", interval*26);
		Invoke ("CreateKey2", interval*26);
		Invoke ("CreateKey3", interval*27);
		Invoke ("CreateKey4", interval*28);
		Invoke ("CreateEnter4", interval*29);
		Invoke ("CreateKey3", interval*30);
		Invoke ("CreateKey1", interval*31);
		Invoke ("CreateKey1", interval*32);
		Invoke ("CreateKey2", interval*32);
		Invoke ("CreateKey2", interval*33);
		Invoke ("CreateKey4", interval*33);
		Invoke ("CreateKey2", interval*34);
		Invoke ("CreateKey3", interval*34);
		Invoke ("CreateEnter1", interval*35);
		Invoke ("CreateEnter2", interval*36);
		Invoke ("CreateEnter3", interval*37);
		Invoke ("CreateEnter4", interval*38);
		Invoke ("CreateKey2", interval*39);
		Invoke ("CreateEnter2", interval*40);
		Invoke ("CreateKey2", interval*41);
		Invoke ("CreateKey3", interval*42);
		Invoke ("CreateKey2", interval*43);
		Invoke ("CreateKey3", interval*44);
		Invoke ("CreateKey2", interval*45);
		Invoke ("CreateKey2", interval*46);
		Invoke ("CreateKey3", interval*46);
   }
}
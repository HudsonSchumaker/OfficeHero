using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsWeek1_3 : MonoBehaviour {

	public GameObject key;
	public GameObject keyPurple;
	public GameObject keyX2;
	public Text scoreStr;
	public Text comboStr;
	public GameObject hero1;
	public GameObject hero2;
	public GameObject finished;
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
		this.numberOfKeys = 135;
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
		this.CheckBonus ();
		if(numberOfKeys <= 0){
			EndStrike ();//Se nao errar nao entra
			finished.SetActive (true);
			PlayerPrefs.SetInt ("StrikeLv1-3", longStrike);
			PlayerPrefs.SetInt ("ScoreLv1-3", score);
			Invoke ("NextScreen", 3.0f);
		}
		if(error >= 8){
			SceneManager.LoadScene("_GameOver");
		}
	}

	private void NextScreen(){
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

	private void CreateKeyX2 () {
		Instantiate (keyX2, new Vector3 (x2, y, z), Quaternion.identity);//Atenção aqui
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
		Invoke ("CreateKeyX2", interval*20);//Aqui keyComboX2	
		Invoke ("CreateKeyX2", interval*65);//Aqui keyComboX2	
		Invoke ("CreateKeyX2", interval*82);//Aqui keyComboX2	
		Invoke ("CreateKey4", 0.1f);
		Invoke ("CreateKey1", 0.5f);
		Invoke ("CreateKey4", interval);
		Invoke ("CreateKey1", interval);
		Invoke ("CreateKey4", interval*2);
		Invoke ("CreateKey1", interval*2);
		Invoke ("CreateKey4", interval*3);
		Invoke ("CreateKey4", interval*4);
		Invoke ("CreateKey4", interval*5);
		Invoke ("CreateKey1", interval*3);
		Invoke ("CreateKey4", interval*6);
		Invoke ("CreateKey4", interval*7);
		Invoke ("CreateKey4", interval*8);
		Invoke ("CreateKey1", interval*6);
		Invoke ("CreateKey4", interval*9);
		Invoke ("CreateKey4", interval*10);
		Invoke ("CreateKey4", interval*11);
		Invoke ("CreateKey1", interval*10);
		Invoke ("CreateKey4", interval*12);
		Invoke ("CreateKey4", interval*13);
		Invoke ("CreateKey4", interval*14);
		Invoke ("CreateKey1", interval*13);
		Invoke ("CreateKey1", interval*14);
		Invoke ("CreateKey1", interval*15);
		Invoke ("CreateKey1", interval*16);
		Invoke ("CreateKey1", interval*17);
		Invoke ("CreateKey1", interval*18);
		Invoke ("CreateKey1", interval*19);
		Invoke ("CreateKey4", interval*15);
		Invoke ("CreateKey4", interval*16);
		Invoke ("CreateKey4", interval*20);
		Invoke ("CreateKey1", interval*20);
		Invoke ("CreateKey4", interval*21);
		Invoke ("CreateKey1", interval*21);
		Invoke ("CreateKey4", interval*22);
		Invoke ("CreateKey1", interval*23);
		Invoke ("CreateKey4", interval*24);
		Invoke ("CreateKey1", interval*25);
		Invoke ("CreateKey4", interval*26);
		Invoke ("CreateKey1", interval*27);
		Invoke ("CreateKey4", interval*28);
		Invoke ("CreateKey1", interval*28);
		Invoke ("CreateKey4", interval*29);
		Invoke ("CreateKey4", interval*30);
		Invoke ("CreateKey4", interval*31);
		Invoke ("CreateKey1", interval*32);
		Invoke ("CreateKey1", interval*33);
		Invoke ("CreateKey4", interval*34);
		Invoke ("CreateKey4", interval*35);
		Invoke ("CreateKey4", interval*36);
		Invoke ("CreateKey1", interval*35);
		Invoke ("CreateKey1", interval*37);
		Invoke ("CreateKey1", interval*38);
		Invoke ("CreateKey4", interval*40);
		Invoke ("CreateKey1", interval*40);
		Invoke ("CreateKey4", interval*41);
		Invoke ("CreateKey1", interval*41);
		Invoke ("CreateKey4", interval*42);
		Invoke ("CreateKey1", interval*42);
		Invoke ("CreateKey4", interval*43);
		Invoke ("CreateKey4", interval*44);
		Invoke ("CreateKey4", interval*45);
		Invoke ("CreateKey1", interval*45);
		Invoke ("CreateKey4", interval*46);
		Invoke ("CreateKey1", interval*46);
		Invoke ("CreateKey4", interval*47);
		Invoke ("CreateKey4", interval*48);
		Invoke ("CreateKey4", interval*49);
		Invoke ("CreateKey1", interval*47);
		Invoke ("CreateKey4", interval*50);
		Invoke ("CreateKey4", interval*51);
		Invoke ("CreateKey1", interval*48);
		Invoke ("CreateKey4", interval*52);
		Invoke ("CreateKey4", interval*53);
		Invoke ("CreateKey4", interval*54);
		Invoke ("CreateKey1", interval*53);
		Invoke ("CreateKey4", interval*55);
		Invoke ("CreateKey4", interval*56);
		Invoke ("CreateKey4", interval*57);
		Invoke ("CreateKey1", interval*56);
		Invoke ("CreateKey1", interval*57);
		Invoke ("CreateKey1", interval*58);
		Invoke ("CreateKey1", interval*59);
		Invoke ("CreateKey1", interval*60);
		Invoke ("CreateKey1", interval*61);
		Invoke ("CreateKey1", interval*62);
		Invoke ("CreateKey4", interval*59);
		Invoke ("CreateKey4", interval*61);
		Invoke ("CreateKey4", interval*62);
		Invoke ("CreateKey1", interval*63);
		Invoke ("CreateKey4", interval*64);
		Invoke ("CreateKey1", interval*65);
		Invoke ("CreateKey4", interval*66);
		Invoke ("CreateKey1", interval*67);
		Invoke ("CreateKey4", interval*68);
		Invoke ("CreateKey1", interval*69);
		Invoke ("CreateKey4", interval*70);
		Invoke ("CreateKey1", interval*71);
		Invoke ("CreateKey4", interval*72);
		Invoke ("CreateKey1", interval*73);
		Invoke ("CreateKey4", interval*74);
		Invoke ("CreateKey4", interval*75);
		Invoke ("CreateKey4", interval*76);
		Invoke ("CreateKey1", interval*75);
		Invoke ("CreateKey1", interval*78);
		Invoke ("CreateKey4", interval*79);
		Invoke ("CreateKey4", interval*80);
		Invoke ("CreateKey4", interval*81);
		Invoke ("CreateKey1", interval*81);
		Invoke ("CreateKey1", interval*82);
		Invoke ("CreateKey1", interval*83);
		Invoke ("CreateKey4", interval*82);
		Invoke ("CreateKey1", interval*84);
		Invoke ("CreateKey4", interval*85);
		Invoke ("CreateKey1", interval*86);
		Invoke ("CreateKey4", interval*87);
		Invoke ("CreateKey1", interval*87);
		Invoke ("CreateKey4", interval*88);
		Invoke ("CreateKey4", interval*89);
		Invoke ("CreateKey4", interval*90);
		Invoke ("CreateKey4", interval*91);
		Invoke ("CreateKey1", interval*91);
		Invoke ("CreateKey4", interval*92);
		Invoke ("CreateKey4", interval*93);
		Invoke ("CreateKey1", interval*92);	
		Invoke ("CreateKey1", interval*94);	
		Invoke ("CreateKey4", interval*94);	
		Invoke ("CreateKey1", interval*95);	
		Invoke ("CreateKey1", interval*96);	
		Invoke ("CreateKey1", interval*97);
		Invoke ("CreateKey4", interval*98);	
		Invoke ("CreateKey4", interval*99);
		Invoke ("CreateKey4", interval*100);
		Invoke ("CreateKey1", interval*100);	
		Invoke ("CreateKey1", interval*101);
   }
}
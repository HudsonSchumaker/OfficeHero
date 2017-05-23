using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsWeek1_2 : MonoBehaviour {

	public GameObject key;
	public Text scoreStr;
	public GameObject hero;

	private int numberOfKeys;
	private int score;
	private float x1, x2, x3, x4;
	private float y;
	private float z;
	private float interval;

	private void Start () {
		this.score = 0;
		scoreStr.text = "Score: " + score;
		this.x1 = -2.0f;
		this.x2 = -0.7f;
		this.x3 = 0.7f;
		this.x4 = 2.0f;
		this.y = 5.5f;
		this.z = 0.0f;
		this.interval = 1.1f;
		this.numberOfKeys = 1000;
		this.TheLevel();

	}

	private void Update () {
		if(Input.touchCount > 0){
			hero.SetActive(false);
			Invoke ("BackFrame", 0.4f);
		}
	}

	private void TheLevel(){		



		Invoke ("CreateKey4", 0.1f);
		Invoke ("CreateKey2", 0.5f);
		Invoke ("CreateKey4", interval);
		Invoke ("CreateKey2", interval);
		Invoke ("CreateKey4", interval*2);
		Invoke ("CreateKey2", interval*2);
		Invoke ("CreateKey4", interval*3);
		Invoke ("CreateKey4", interval*4);
		Invoke ("CreateKey4", interval*5);
		Invoke ("CreateKey2", interval*3);
		Invoke ("CreateKey4", interval*6);
		Invoke ("CreateKey4", interval*7);
		Invoke ("CreateKey4", interval*8);
		Invoke ("CreateKey2", interval*6);
		Invoke ("CreateKey4", interval*9);
		Invoke ("CreateKey4", interval*10);
		Invoke ("CreateKey4", interval*11);
		Invoke ("CreateKey2", interval*10);
		Invoke ("CreateKey4", interval*12);
		Invoke ("CreateKey4", interval*13);
		Invoke ("CreateKey4", interval*14);
		Invoke ("CreateKey2", interval*13);
		Invoke ("CreateKey2", interval*14);
		Invoke ("CreateKey2", interval*15);
		Invoke ("CreateKey2", interval*16);
		Invoke ("CreateKey2", interval*17);
		Invoke ("CreateKey2", interval*18);
		Invoke ("CreateKey2", interval*19);
		Invoke ("CreateKey4", interval*15);
		Invoke ("CreateKey4", interval*16);
		Invoke ("CreateKey4", interval*20);
		Invoke ("CreateKey2", interval*20);
		Invoke ("CreateKey4", interval*21);
		Invoke ("CreateKey2", interval*21);
		Invoke ("CreateKey4", interval*22);
		Invoke ("CreateKey2", interval*23);
		Invoke ("CreateKey4", interval*24);
		Invoke ("CreateKey2", interval*25);
		Invoke ("CreateKey4", interval*26);
		Invoke ("CreateKey2", interval*27);
		Invoke ("CreateKey4", interval*28);
		Invoke ("CreateKey2", interval*28);
		Invoke ("CreateKey4", interval*29);
		Invoke ("CreateKey4", interval*30);
		Invoke ("CreateKey4", interval*31);
		Invoke ("CreateKey2", interval*32);
		Invoke ("CreateKey2", interval*33);
		Invoke ("CreateKey4", interval*34);
		Invoke ("CreateKey4", interval*35);
		Invoke ("CreateKey4", interval*36);
		Invoke ("CreateKey2", interval*35);
		Invoke ("CreateKey2", interval*37);
		Invoke ("CreateKey2", interval*38);
		Invoke ("CreateKey4", interval*40);
		Invoke ("CreateKey2", interval*40);
		Invoke ("CreateKey4", interval*41);
		Invoke ("CreateKey2", interval*41);
		Invoke ("CreateKey4", interval*42);
		Invoke ("CreateKey2", interval*42);
		Invoke ("CreateKey4", interval*43);
		Invoke ("CreateKey4", interval*44);

		Invoke ("CreateKey4", interval*45);
		Invoke ("CreateKey2", interval*45);
		Invoke ("CreateKey4", interval*46);
		Invoke ("CreateKey2", interval*46);
		Invoke ("CreateKey4", interval*47);
		Invoke ("CreateKey4", interval*48);
		Invoke ("CreateKey4", interval*49);
		Invoke ("CreateKey2", interval*47);
		Invoke ("CreateKey4", interval*50);
		Invoke ("CreateKey4", interval*51);
		Invoke ("CreateKey2", interval*48);
		Invoke ("CreateKey4", interval*52);
		Invoke ("CreateKey4", interval*53);
		Invoke ("CreateKey4", interval*54);
		Invoke ("CreateKey2", interval*53);
		Invoke ("CreateKey4", interval*55);
		Invoke ("CreateKey4", interval*56);
		Invoke ("CreateKey4", interval*57);
		Invoke ("CreateKey2", interval*56);
		Invoke ("CreateKey2", interval*57);
		Invoke ("CreateKey2", interval*58);
		Invoke ("CreateKey2", interval*59);
		Invoke ("CreateKey2", interval*60);
		Invoke ("CreateKey2", interval*61);
		Invoke ("CreateKey2", interval*62);
		Invoke ("CreateKey4", interval*59);
		Invoke ("CreateKey4", interval*61);
		Invoke ("CreateKey4", interval*62);
		Invoke ("CreateKey2", interval*63);
		Invoke ("CreateKey4", interval*64);
		Invoke ("CreateKey2", interval*65);
		Invoke ("CreateKey4", interval*66);
		Invoke ("CreateKey2", interval*67);
		Invoke ("CreateKey4", interval*68);
		Invoke ("CreateKey2", interval*69);
		Invoke ("CreateKey4", interval*70);
		Invoke ("CreateKey2", interval*71);
		Invoke ("CreateKey4", interval*72);
		Invoke ("CreateKey2", interval*73);
		Invoke ("CreateKey4", interval*74);
		Invoke ("CreateKey4", interval*75);
		Invoke ("CreateKey4", interval*76);
		Invoke ("CreateKey2", interval*75);
		Invoke ("CreateKey2", interval*78);
		Invoke ("CreateKey4", interval*79);
		Invoke ("CreateKey4", interval*80);
		Invoke ("CreateKey4", interval*81);
		Invoke ("CreateKey2", interval*81);
		Invoke ("CreateKey2", interval*82);
		Invoke ("CreateKey2", interval*83);
		Invoke ("CreateKey4", interval*82);
		Invoke ("CreateKey2", interval*84);
		Invoke ("CreateKey4", interval*85);
		Invoke ("CreateKey2", interval*86);
		Invoke ("CreateKey4", interval*87);
		Invoke ("CreateKey2", interval*87);
		Invoke ("CreateKey4", interval*88);
		Invoke ("CreateKey4", interval*89);
		Invoke ("CreateKey4", interval*90);
	}

	private void BackFrame(){
		hero.SetActive(true);
	}

	private void CreateKey1 () {
		Instantiate (key, new Vector3 (x1, y, z), Quaternion.identity);
		numberOfKeys--;
	}

	private void CreateKey2 () {
		Instantiate (key, new Vector3 (x2, y, z), Quaternion.identity);	
		numberOfKeys--;
	}

	private void CreateKey3 () {
		Instantiate (key, new Vector3 (x3, y, z), Quaternion.identity);	
		numberOfKeys--;
	}

	private void CreateKey4 () {
		Instantiate (key, new Vector3 (x4, y, z), Quaternion.identity);	
		numberOfKeys--;
	}

	public void AddScore () {
		score++;
	}

	public void AddScore (int value) {
		score += value;
	}
}

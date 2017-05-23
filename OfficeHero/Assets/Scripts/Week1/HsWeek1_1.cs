﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsWeek1_1 : MonoBehaviour {

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
			hero.SetActive(true);
			Invoke ("BackFrame", 0.4f);
		}
		scoreStr.text = "Score: " + score;
	}

	private void TheLevel(){		



		Invoke ("CreateKey1", 0.1f);
		Invoke ("CreateKey3", 0.5f);
		Invoke ("CreateKey1", interval);
		Invoke ("CreateKey3", interval);
		Invoke ("CreateKey1", interval*2);
		Invoke ("CreateKey3", interval*2);
		Invoke ("CreateKey1", interval*3);
		Invoke ("CreateKey1", interval*4);
		Invoke ("CreateKey1", interval*5);
		Invoke ("CreateKey3", interval*3);
		Invoke ("CreateKey1", interval*6);
		Invoke ("CreateKey1", interval*7);
		Invoke ("CreateKey1", interval*8);
		Invoke ("CreateKey3", interval*6);
		Invoke ("CreateKey1", interval*9);
		Invoke ("CreateKey1", interval*10);
		Invoke ("CreateKey1", interval*11);
		Invoke ("CreateKey3", interval*10);
		Invoke ("CreateKey1", interval*12);
		Invoke ("CreateKey1", interval*13);
		Invoke ("CreateKey1", interval*14);
		Invoke ("CreateKey3", interval*13);
		Invoke ("CreateKey3", interval*14);
		Invoke ("CreateKey3", interval*15);
		Invoke ("CreateKey3", interval*16);
		Invoke ("CreateKey3", interval*17);
		Invoke ("CreateKey3", interval*18);
		Invoke ("CreateKey3", interval*19);
		Invoke ("CreateKey1", interval*15);
		Invoke ("CreateKey1", interval*16);
		Invoke ("CreateKey1", interval*20);
		Invoke ("CreateKey3", interval*20);
		Invoke ("CreateKey1", interval*21);
		Invoke ("CreateKey3", interval*21);
		Invoke ("CreateKey1", interval*22);
		Invoke ("CreateKey3", interval*23);
		Invoke ("CreateKey1", interval*24);
		Invoke ("CreateKey3", interval*25);
		Invoke ("CreateKey1", interval*26);
		Invoke ("CreateKey3", interval*27);
		Invoke ("CreateKey1", interval*28);
		Invoke ("CreateKey3", interval*28);
		Invoke ("CreateKey1", interval*29);
		Invoke ("CreateKey1", interval*30);
		Invoke ("CreateKey1", interval*31);
		Invoke ("CreateKey3", interval*32);
		Invoke ("CreateKey3", interval*33);
		Invoke ("CreateKey1", interval*34);
		Invoke ("CreateKey1", interval*35);
		Invoke ("CreateKey1", interval*36);
		Invoke ("CreateKey3", interval*35);
		Invoke ("CreateKey3", interval*37);
		Invoke ("CreateKey3", interval*38);
		Invoke ("CreateKey1", interval*40);
		Invoke ("CreateKey3", interval*40);
		Invoke ("CreateKey1", interval*41);
		Invoke ("CreateKey3", interval*41);
		Invoke ("CreateKey1", interval*42);
		Invoke ("CreateKey3", interval*42);
		Invoke ("CreateKey1", interval*43);
		Invoke ("CreateKey1", interval*44);

		Invoke ("CreateKey1", interval*45);
		Invoke ("CreateKey3", interval*45);
		Invoke ("CreateKey1", interval*46);
		Invoke ("CreateKey3", interval*46);
		Invoke ("CreateKey1", interval*47);
		Invoke ("CreateKey1", interval*48);
		Invoke ("CreateKey1", interval*49);
		Invoke ("CreateKey3", interval*47);
		Invoke ("CreateKey1", interval*50);
		Invoke ("CreateKey1", interval*51);
		Invoke ("CreateKey3", interval*48);
		Invoke ("CreateKey1", interval*52);
		Invoke ("CreateKey1", interval*53);
		Invoke ("CreateKey1", interval*54);
		Invoke ("CreateKey3", interval*53);
		Invoke ("CreateKey1", interval*55);
		Invoke ("CreateKey1", interval*56);
		Invoke ("CreateKey1", interval*57);
		Invoke ("CreateKey3", interval*56);
		Invoke ("CreateKey3", interval*57);
		Invoke ("CreateKey3", interval*58);
		Invoke ("CreateKey3", interval*59);
		Invoke ("CreateKey3", interval*60);
		Invoke ("CreateKey3", interval*61);
		Invoke ("CreateKey3", interval*62);
		Invoke ("CreateKey1", interval*59);
		Invoke ("CreateKey1", interval*61);
		Invoke ("CreateKey1", interval*62);
		Invoke ("CreateKey3", interval*63);
		Invoke ("CreateKey1", interval*64);
		Invoke ("CreateKey3", interval*65);
		Invoke ("CreateKey1", interval*66);
		Invoke ("CreateKey3", interval*67);
		Invoke ("CreateKey1", interval*68);
		Invoke ("CreateKey3", interval*69);
		Invoke ("CreateKey1", interval*70);
		Invoke ("CreateKey3", interval*71);
		Invoke ("CreateKey1", interval*72);
		Invoke ("CreateKey3", interval*73);
		Invoke ("CreateKey1", interval*74);
		Invoke ("CreateKey1", interval*75);
		Invoke ("CreateKey1", interval*76);
		Invoke ("CreateKey3", interval*75);
		Invoke ("CreateKey3", interval*78);
		Invoke ("CreateKey1", interval*79);
		Invoke ("CreateKey1", interval*80);
		Invoke ("CreateKey1", interval*81);
		Invoke ("CreateKey3", interval*81);
		Invoke ("CreateKey3", interval*82);
		Invoke ("CreateKey3", interval*83);
		Invoke ("CreateKey1", interval*82);
		Invoke ("CreateKey3", interval*84);
		Invoke ("CreateKey1", interval*85);
		Invoke ("CreateKey3", interval*86);
		Invoke ("CreateKey1", interval*87);
		Invoke ("CreateKey3", interval*87);
		Invoke ("CreateKey1", interval*88);
		Invoke ("CreateKey1", interval*89);
		Invoke ("CreateKey1", interval*90);
	}
		
	private void BackFrame(){
		hero.SetActive(false);
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

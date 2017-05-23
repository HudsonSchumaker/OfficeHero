using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsWeek1_3 : MonoBehaviour {

	public GameObject key;
	public Text scoreStr;
	public GameObject hero;

	private int score;
	private float x1, x2, x3, x4;
	private float y;
	private float z;
	private float levelSpeed;

	private void Start () {
		this.score = 0;
		scoreStr.text = "Score: " + score;
		this.x1 = -2.0f;
		this.x2 = -0.7f;
		this.x3 = 0.7f;
		this.x4 = 2.0f;
		this.y = 5.5f;
		this.z = 0.0f;
		this.levelSpeed = 1.5f;
		this.TheLevel();
	}

	private void Update () {
		if(Input.touchCount > 0){
			hero.SetActive(false);
			Invoke ("BackFrame", 0.4f);
		}
	}

	private void TheLevel(){		
		Invoke ("CreateKey1", 0.1f);
		Invoke ("CreateKey2", 0.5f);
		Invoke ("CreateKey3", 0.9f);
		Invoke ("CreateKey4", 1.4f);
	}


	private void BackFrame(){
		hero.SetActive(true);
	}

	public void AddScore () {
		score++;
	}

	public void AddScore (int value) {
		score += value;
	}

	public float GetLevelSpeed () {
		return this.levelSpeed;
	}
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HsArrow : MonoBehaviour {


	public GameObject arrow;
	public AudioClip key1;
	private float delay;
	private bool act;

	void Start(){
		this.delay = 0.9f;
		this.act = true;
	}

	void Update () {
		if(PlayerPrefs.HasKey("tutorial")){
		
			if(PlayerPrefs.GetInt("tutorial")==0){
				Blink ();
			}
			else{
				//
			}
		}
		else{
			Blink ();
		}
	}

	private void Blink(){
		delay -= Time.deltaTime;
		if (delay <= 0.0f) {
			HsAudioManager.instance.PlayAudioClip (key1);
			if(act){
				act = false;
				arrow.SetActive (false);
			}else{
				act = true;
				arrow.SetActive (true);
			}
			this.delay = 0.9f;		
		}
	}
}

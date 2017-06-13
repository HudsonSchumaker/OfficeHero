using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsAudioManager : MonoBehaviour {

	public AudioSource source;
	public static HsAudioManager instance = null;

	private void Awake() {
		if (instance == null){
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}

	public void PlayAudioClip(AudioClip clip){
		this.source.clip = clip;
		this.source.Play ();
	}

	public void StopAudioClip(){
		this.source.Stop ();
	}
}

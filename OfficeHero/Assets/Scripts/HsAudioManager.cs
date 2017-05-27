using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HsAudioManager : MonoBehaviour {

	public AudioSource source;
	public static HsAudioManager instance = null;

	private void Awake() {
		if (instance == null){
			instance = this;
		}
	}

	public void PlayAudioClip(AudioClip clip){
		this.source.clip = clip;
		this.source.Play ();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsInternet : MonoBehaviour {

	void Start () {

		string url = "http://schumaker.com.br/officehero/ohlogin.html";
		WWW www = new WWW(url);
		StartCoroutine(WaitForRequest(www));
	}

	IEnumerator WaitForRequest(WWW www){
		yield return www;
		if (www.error == null){
			Debug.Log("WWW Ok!: " + www.text);
		} else {
			SceneManager.LoadScene("_NoConnection");
		}    
	}
}

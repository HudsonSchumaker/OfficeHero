using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsLeaderBoards : MonoBehaviour {


	void Start () {

		string id = PlayerPrefs.GetString ("id");
		string pname = PlayerPrefs.GetString ("playerName");
		pname = pname.Replace (" ", "%20");
		string email = PlayerPrefs.GetString ("playerEmail");

		int score = PlayerPrefs.GetInt("ScoreLv1-1") + PlayerPrefs.GetInt("ScoreLv1-2")+PlayerPrefs.GetInt("ScoreLv1-3")
			+PlayerPrefs.GetInt("ScoreLv1-4")+PlayerPrefs.GetInt("ScoreLv1-5");

		string url = "http://schumaker.com.br/officehero/setleaderboard.jsp?idfb="+id+"&name="+pname+"&email="+email+"&score="+score+"";
		Debug.Log(url);

		WWW www = new WWW(url);
		StartCoroutine(WaitForRequest(www));
	}
	
	IEnumerator WaitForRequest(WWW www){
		yield return www;

		if (www.error == null){
			Debug.Log("WWW Ok!: " + www.text);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}
}

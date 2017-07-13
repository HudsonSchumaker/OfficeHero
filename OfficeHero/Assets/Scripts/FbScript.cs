using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.SceneManagement;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class FbScript : MonoBehaviour {

	private void Awake (){
		if (!FB.IsInitialized) {
			FB.Init(InitCallback, OnHideUnity);
		} else {
			FB.ActivateApp();
		}
	}

	public void FBLogin(){
		var perms = new List<string>(){"public_profile"};
		FB.LogInWithReadPermissions(perms, AuthCallback);
	}

	private void AuthCallback (ILoginResult result) {
		if (FB.IsLoggedIn) {
			var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
			Debug.Log(aToken.UserId);
			FB.API ("/me?fields=id,name,email", HttpMethod.GET, DisplayUserName);

		} else {
			//Debug.Log("User cancelled login");
		}
	}

	public void DisplayUserName(IResult result){
		PlayerPrefs.SetString ("id", (string)result.ResultDictionary["id"]);
		PlayerPrefs.SetString ("playerName",(string) result.ResultDictionary["name"]);
		PlayerPrefs.SetString ("playerEmail",(string) result.ResultDictionary["email"]);

		SceneManager.LoadScene("_Endless");
	}

	private void InitCallback (){
		if (FB.IsInitialized) {
			FB.ActivateApp();
		} else {
			//Debug.Log("Failed to Initialize the Facebook SDK");
		}
	}

	private void OnHideUnity (bool isGameShown){
		if (!isGameShown) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}
}

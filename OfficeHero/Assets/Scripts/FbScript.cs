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
		var perms = new List<string>(){"public_profile", "email", "user_friends"};
		FB.LogInWithReadPermissions(perms, AuthCallback);
		
	}

	private void AuthCallback (ILoginResult result) {
		if (FB.IsLoggedIn) {
			var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
			Debug.Log(aToken.UserId);
			foreach (string perm in aToken.Permissions) {
				Debug.Log(perm);
			}
			FB.API ("/me?fields=id,name", HttpMethod.GET, DisplayUserName);

		} else {
			Debug.Log("User cancelled login");
		}
	}

	public void DisplayUserName(IResult result){
		Debug.Log("Hi there, "+result.ResultDictionary["id"]);
		Debug.Log("Hi there, "+result.ResultDictionary["name"]);

		PlayerPrefs.SetString ("id", (string)result.ResultDictionary["id"]);
		PlayerPrefs.SetString ("playerName",(string) result.ResultDictionary["name"]);

		SceneManager.LoadScene("_MainScreen");
	}

	private void InitCallback (){
		if (FB.IsInitialized) {
			FB.ActivateApp();
		} else {
			Debug.Log("Failed to Initialize the Facebook SDK");
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

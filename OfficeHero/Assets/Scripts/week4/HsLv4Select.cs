using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsLv4Select : MonoBehaviour {

	public Button lv4_1;
	public Button lv4_2;
	public Button lv4_3;
	public Button lv4_4;
	public Button lv4_5;

	private void Start () {
		AdManager.instance.ShowBannerDown();
		int lv35 = PlayerPrefs.GetInt ("okLv3-5");
		int lv41 = PlayerPrefs.GetInt ("okLv4-1");
		int lv42 = PlayerPrefs.GetInt ("okLv4-2");
		int lv43 = PlayerPrefs.GetInt ("okLv4-3");
		int lv44 = PlayerPrefs.GetInt ("okLv4-4");

		if(lv35 == 1){
			lv4_1.interactable = true;
		}
		if(lv41 == 1){
			lv4_2.interactable = true;
		}
		if(lv42 == 1){
			lv4_3.interactable = true;
		}
		if(lv43 == 1){
			lv4_4.interactable = true;
		}
		if(lv44 == 1){
			lv4_5.interactable = true;
		}
	}

	public void LoadLv4_1(){
		SceneManager.LoadScene("_PreWeek4-1");
	}

	public void LoadLv4_2(){
		SceneManager.LoadScene("_PreWeek4-2");
	}

	public void LoadLv4_3(){
		SceneManager.LoadScene("_PreWeek4-3");
	}

	public void LoadLv4_4(){
		SceneManager.LoadScene("_PreWeek4-4");
	}

	public void LoadLv4_5(){
		SceneManager.LoadScene("_PreWeek4-5");
	}

	public void HsBack(){
		SceneManager.LoadScene("_MainScreen");
	}
}

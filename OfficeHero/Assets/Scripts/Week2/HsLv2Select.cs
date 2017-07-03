using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsLv2Select : MonoBehaviour {

	public Button lv2_1;
	public Button lv2_2;
	public Button lv2_3;
	public Button lv2_4;
	public Button lv2_5;

	private void Start () {
		AdManager.instance.ShowBannerDown();
		int lv15 = PlayerPrefs.GetInt ("okLv1-5");
		int lv21 = PlayerPrefs.GetInt ("okLv2-1");
		int lv22 = PlayerPrefs.GetInt ("okLv2-2");
		int lv23 = PlayerPrefs.GetInt ("okLv2-3");
		int lv24 = PlayerPrefs.GetInt ("okLv2-4");

		if(lv15 == 1){
			lv2_1.interactable = true;
		}
		if(lv21 == 1){
			lv2_2.interactable = true;
		}
		if(lv22 == 1){
			lv2_3.interactable = true;
		}
		if(lv23 == 1){
			lv2_4.interactable = true;
		}
		if(lv24 == 1){
			lv2_5.interactable = true;
		}
	}

	public void LoadLv1_1(){
		SceneManager.LoadScene("_PreWeek2-1");
	}

	public void LoadLv1_2(){
		SceneManager.LoadScene("_PreWeek2-2");
	}

	public void LoadLv1_3(){
		SceneManager.LoadScene("_PreWeek2-3");
	}

	public void LoadLv1_4(){
		SceneManager.LoadScene("_PreWeek2-4");
	}

	public void LoadLv1_5(){
		SceneManager.LoadScene("_PreWeek2-5");
	}

	public void HsBack(){
		SceneManager.LoadScene("_MainScreen");
	}
}


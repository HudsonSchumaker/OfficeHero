using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsLv1Select : MonoBehaviour {

	public Button lv1_1;
	public Button lv1_2;
	public Button lv1_3;
	public Button lv1_4;
	public Button lv1_5;

	private void Start () {
		AdManager.instance.ShowBannerDown();
		int lv11 = PlayerPrefs.GetInt ("okLv1-1");
		int lv12 = PlayerPrefs.GetInt ("okLv1-2");
		int lv13 = PlayerPrefs.GetInt ("okLv1-3");
		int lv14 = PlayerPrefs.GetInt ("okLv1-4");
		//int lv15 = PlayerPrefs.GetInt ("okLv1-5");

		if(lv11 == 1){
			lv1_2.interactable = true;
		}
		if(lv12 == 1){
			lv1_3.interactable = true;
		}
		if(lv13 == 1){
			lv1_4.interactable = true;
		}
		if(lv14 == 1){
			lv1_5.interactable = true;
		}
	}

	public void LoadLv1_1(){
		SceneManager.LoadScene("_PreWeek1-1");
	}

	public void LoadLv1_2(){
		SceneManager.LoadScene("_PreWeek1-2");
	}

	public void LoadLv1_3(){
		SceneManager.LoadScene("_PreWeek1-3");
	}

	public void LoadLv1_4(){
		SceneManager.LoadScene("_PreWeek1-4");
	}

	public void LoadLv1_5(){
		SceneManager.LoadScene("_PreWeek1-5");
	}

	public void HsBack(){
		SceneManager.LoadScene("_MainScreen");
	}
}

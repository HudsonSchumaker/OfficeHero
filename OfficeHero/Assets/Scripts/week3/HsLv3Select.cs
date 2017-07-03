using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsLv3Select : MonoBehaviour {

	public Button lv3_1;
	public Button lv3_2;
	public Button lv3_3;
	public Button lv3_4;
	public Button lv3_5;

	private void Start () {
		AdManager.instance.ShowBannerDown();
		int lv25 = PlayerPrefs.GetInt ("okLv2-5");
		int lv31 = PlayerPrefs.GetInt ("okLv3-1");
		int lv32 = PlayerPrefs.GetInt ("okLv3-2");
		int lv33 = PlayerPrefs.GetInt ("okLv3-3");
		int lv34 = PlayerPrefs.GetInt ("okLv3-4");

		if(lv25 == 1){
			lv3_1.interactable = true;
		}
		if(lv31 == 1){
			lv3_2.interactable = true;
		}
		if(lv32 == 1){
			lv3_3.interactable = true;
		}
		if(lv33 == 1){
			lv3_4.interactable = true;
		}
		if(lv34 == 1){
			lv3_5.interactable = true;
		}
	}

	public void LoadLv3_1(){
		SceneManager.LoadScene("_PreWeek3-1");
	}

	public void LoadLv3_2(){
		SceneManager.LoadScene("_PreWeek3-2");
	}

	public void LoadLv3_3(){
		SceneManager.LoadScene("_PreWeek3-3");
	}

	public void LoadLv3_4(){
		SceneManager.LoadScene("_PreWeek3-4");
	}

	public void LoadLv3_5(){
		SceneManager.LoadScene("_PreWeek3-5");
	}

	public void HsBack(){
		SceneManager.LoadScene("_MainScreen");
	}
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/


public class HsLevelMenu : MonoBehaviour {

	public AudioClip key1;
	public Text userName;

	public Button lvl1;
	public Button lvl2;
	public Button lvl3;
	public Button lvl4;

	private void Start () {
		AdManager.instance.ShowBannerDown ();
		int lv15 = PlayerPrefs.GetInt ("okLv1-5");
		int lv25 = PlayerPrefs.GetInt ("okLv2-5");
		int lv35 = PlayerPrefs.GetInt ("okLv3-5");
		if(lv15 == 1){
			lvl2.interactable = true;
		}
		if(lv25 == 1){
			lvl3.interactable = true;
		}
		if(lv35 == 1){
			lvl4.interactable = true;
		}
		userName.text = PlayerPrefs.GetString ("playerName");
	}

	public void LoadEmails(){
		HsAudioManager.instance.PlayAudioClip (key1);
		SceneManager.LoadScene("_WeekCalendar1");
	}

	public void LoadReports(){
		HsAudioManager.instance.PlayAudioClip (key1);
		SceneManager.LoadScene("_WeekCalendar2");
	}

	public void LoadDocs(){
		HsAudioManager.instance.PlayAudioClip (key1);
		SceneManager.LoadScene("_WeekCalendar3");

	}

	public void LoadProg(){
		HsAudioManager.instance.PlayAudioClip (key1);
		SceneManager.LoadScene("_WeekCalendar4");
	}
}

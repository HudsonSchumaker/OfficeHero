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

	private void Start () {
		AdManager.instance.ShowBannerDown ();
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

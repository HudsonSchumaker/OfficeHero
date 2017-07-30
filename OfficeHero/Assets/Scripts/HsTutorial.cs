using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/


public class HsTutorial : MonoBehaviour {

	public GameObject image1;
	public GameObject image2;
	public GameObject image3;
	public Text tip;
	public Text texto;

	private int k;
	private SystemLanguage lingua;

	private void Start(){
		lingua = Application.systemLanguage;
		k = 0;
		Manage ();
	}

	public void Foward(){
		if(k<2){
			k++;
		}
		Manage ();

	}

	public void Back(){
		if(k>-1){
			k--;
		}
		Manage ();
	}

	private void Manage(){
		if (k == 0) {
			ManageLanguage (0);
			image1.SetActive (true);
			image2.SetActive (false);
			image3.SetActive (false);
			return;
		}
		if (k == 1) {
			ManageLanguage (1);
			image1.SetActive (false);
			image2.SetActive (true);
			image3.SetActive (false);
			return;
		}
		if (k == 2) {
			ManageLanguage (2);
			image1.SetActive (false);
			image2.SetActive (false);
			image3.SetActive (true);
			return;
		}
		if (k == -1) {
			SceneManager.LoadScene ("_MainScreen");
		} 
	}

	private void ManageLanguage(int n){
		if(k==0){
			if (lingua == SystemLanguage.Spanish){
				tip.text = HsLanguage.tip [1];
				texto.text = HsLanguage.tips1 [1];
			}
			else if(lingua == SystemLanguage.Portuguese){
				tip.text = HsLanguage.tip [2];
				texto.text = HsLanguage.tips1 [2];
			}
			else {
				tip.text = HsLanguage.tip [0];
				texto.text = HsLanguage.tips1 [0];
			}
			return;
		}
		if(k==1){
			if (lingua == SystemLanguage.Spanish){
				tip.text = HsLanguage.tip [1];
				texto.text = HsLanguage.tips2 [1];
			}
			else if(lingua == SystemLanguage.Portuguese){
				tip.text = HsLanguage.tip [2];
				texto.text = HsLanguage.tips2 [2];
			}
			else {
				tip.text = HsLanguage.tip [0];
				texto.text = HsLanguage.tips2 [0];
			}
			return;
		}
		if(k==2){
			if (lingua == SystemLanguage.Spanish){
				tip.text = HsLanguage.tip [1];
				texto.text = HsLanguage.tips3 [1];
			}
			else if(lingua == SystemLanguage.Portuguese){
				tip.text = HsLanguage.tip [2];
				texto.text = HsLanguage.tips3 [2];
			}
			else {
				tip.text = HsLanguage.tip [0];			
				texto.text = HsLanguage.tips3 [0];
			}
		}
	}
}
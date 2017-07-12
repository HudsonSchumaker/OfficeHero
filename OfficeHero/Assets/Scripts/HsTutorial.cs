using UnityEngine;
using UnityEngine.SceneManagement;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/


public class HsTutorial : MonoBehaviour {

	public GameObject image1;
	public GameObject image2;
	public GameObject image3;

	private int k;

	private void Start(){
		k = 0;
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
			image1.SetActive (true);
			image2.SetActive (false);
			image3.SetActive (false);
			return;
		}
		if (k == 1) {
			image1.SetActive (false);
			image2.SetActive (true);
			image3.SetActive (false);
			return;
		}
		if (k == 2) {
			image1.SetActive (false);
			image2.SetActive (false);
			image3.SetActive (true);
			return;
		}
		if (k == -1) {
			SceneManager.LoadScene ("_MainScreen");
		} 
	}
}
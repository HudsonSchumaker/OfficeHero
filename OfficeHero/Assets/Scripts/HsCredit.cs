using UnityEngine;
using UnityEngine.SceneManagement;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsCredit : MonoBehaviour {

	public GameObject image1;
	public GameObject image2;
	public GameObject image3;

	private void Update () {
		Invoke ("ManageImage2", 5.0f);
		Invoke ("ManageImage3", 10.0f);
		Invoke ("Back", 15.0f);
	}
		
	private void ManageImage2(){
		image1.SetActive (false);
		image2.SetActive (true);
	}

	private void ManageImage3(){
		image2.SetActive (false);
		image3.SetActive (true);
	}

	private void Back(){
		SceneManager.LoadScene("_MainScreen");
	}
}
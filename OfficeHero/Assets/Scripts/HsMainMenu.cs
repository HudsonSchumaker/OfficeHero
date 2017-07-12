using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsMainMenu : MonoBehaviour {

	public AudioClip key1;
	public Text userName;

	private SpriteRenderer grafico;
	private float larguraImagem;
	private float alturaImagem;
	private float alturaTela;
	private float larguraTela;

	private void Start () {
		AdManager.instance.ShowBannerDown ();

		grafico = GetComponent<SpriteRenderer> ();

		// Width and Heigth do sprite
		larguraImagem = grafico.sprite.bounds.size.x;
		alturaImagem = grafico.sprite.bounds.size.y;

		// Width and Heigth da tela
		alturaTela = Camera.main.orthographicSize * 2.0f;
		larguraTela = alturaTela / Screen.height * Screen.width;

		Vector2 novaEscala = transform.localScale;
		novaEscala.x = larguraTela/larguraImagem; // + 0.25f para nao risco em background scroller 
		novaEscala.y = alturaTela/alturaImagem;
		this.transform.localScale = novaEscala;

		userName.text = PlayerPrefs.GetString("playerName");
	}

	public void LoadArcadeMode(){
		HsAudioManager.instance.PlayAudioClip (key1);
		SceneManager.LoadScene("_Levels");
	}

	public void LoadEndlessMode(){
		HsAudioManager.instance.PlayAudioClip (key1);
		SceneManager.LoadScene("_Endless");
	}

	public void LoadLeaderBoards(){
		HsAudioManager.instance.PlayAudioClip (key1);
		Application.OpenURL("http://schumakerteam.com/officeheroleaderboards.html");
	}

	public void LoadSettings(){
		HsAudioManager.instance.PlayAudioClip (key1);
		SceneManager.LoadScene("_Tutorial");	
	}

	public void Exit(){
		Application.Quit ();
	}
}
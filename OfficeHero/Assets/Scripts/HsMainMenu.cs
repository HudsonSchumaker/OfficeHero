using UnityEngine;
using UnityEngine.SceneManagement;

public class HsMainMenu : MonoBehaviour {

	public AudioClip key1;

	private SpriteRenderer grafico;
	private float larguraImagem;
	private float alturaImagem;
	private float alturaTela;
	private float larguraTela;

	private void Start () {
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
	}

	public void LoadArcadeMode(){
		HsAudioManager.instance.PlayAudioClip (key1);
		SceneManager.LoadScene("_WeekCalendar1");
	}

	public void LoadEndlessMode(){
		HsAudioManager.instance.PlayAudioClip (key1);
		
	}

	public void LoadLeaderBoards(){
		HsAudioManager.instance.PlayAudioClip (key1);
		
	}

	public void LoadSettings(){
		HsAudioManager.instance.PlayAudioClip (key1);
		
	}
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class HsCalendar : MonoBehaviour {

	private SpriteRenderer grafico;
	private float larguraImagem;
	private float alturaImagem;
	private float alturaTela;
	private float larguraTela;
	private float delay;

	private void Start () {
		delay = 1.5f;
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

	void Update () {
		delay -= Time.deltaTime;
		if(delay <= 0.0f){
			SceneManager.LoadScene("_Game");
		}
	}
}

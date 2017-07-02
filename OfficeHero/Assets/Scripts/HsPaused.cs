using UnityEngine;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsPaused : MonoBehaviour {

	private SpriteRenderer grafico;
	private float larguraImagem;
	private float alturaTela;
	private float larguraTela;

	private void Start () {
		grafico = GetComponent<SpriteRenderer> ();

		// Width and Heigth do sprite
		larguraImagem = grafico.sprite.bounds.size.x;

		// Width and Heigth da tela
		alturaTela = Camera.main.orthographicSize * 2.0f;
		larguraTela = alturaTela / Screen.height * Screen.width;

		Vector2 novaEscala = transform.localScale;
		novaEscala.x = larguraTela/larguraImagem; // + 0.25f para nao risco em background scroller 
		//novaEscala.y = alturaTela/alturaImagem;
		this.transform.localScale = novaEscala;
	}
}

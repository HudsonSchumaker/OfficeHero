﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* 
	@author Hudson Schumaker
	@version 1.0.0
*/

public class HsScore1_2 : MonoBehaviour {

	private SpriteRenderer grafico;
	public  Text score;
	public  Text strike;
	private float larguraImagem;
	private float alturaImagem;
	private float alturaTela;
	private float larguraTela;
	private float delay;

	private void Start () {
		this.delay = 5.5f;
		this.grafico = GetComponent<SpriteRenderer> ();
		this.larguraImagem = grafico.sprite.bounds.size.x;
		this.alturaImagem = grafico.sprite.bounds.size.y;
		this.alturaTela = Camera.main.orthographicSize * 2.0f;
		this.larguraTela = alturaTela / Screen.height * Screen.width;
		Vector2 novaEscala = transform.localScale;
		novaEscala.x = larguraTela/larguraImagem;
		novaEscala.y = alturaTela/alturaImagem;
		this.transform.localScale = novaEscala;
		score.text = "Score: " + PlayerPrefs.GetInt("ScoreLv1-2");
		strike.text = "Longest Strike: "+ PlayerPrefs.GetInt("StrikeLv1-2");
	}

	private void Update () {
		delay -= Time.deltaTime;
		if(delay <= 0.0f){
			SceneManager.LoadScene("_PreWeek1-3");
		}
	}
}
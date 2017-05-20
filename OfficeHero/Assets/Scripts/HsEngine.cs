using UnityEngine;
using UnityEngine.UI;

public class HsEngine : MonoBehaviour {


	public GameObject key;
	public Text scoreStr;
	public GameObject hero;

	private int lane;
	private int auxLane;
	private int score;
	private float x1, x2, x3, x4;
	private float y;
	private float z;
	private float levelSpeed;
	private bool frisTime;

	private void Start () {
		auxLane = lane = score = 0;
		scoreStr.text = "Score: " + score;
		x1 = -2.0f;
		x2 = -0.7f;
		x3 = 0.7f;
		x4 = 2.0f;
		y = 5.5f;
		z = 0.0f;
		levelSpeed = 1.5f;
		frisTime = true;
	}

	private void Update () {
		scoreStr.text = "Score: " + score;
		if(frisTime){
			FristTime ();
			frisTime = false;
		}else{
			lane = Random.Range (1,300);
			if(lane != auxLane){
				Invoke ("Manager", 1.5f);
			}
			auxLane = lane;
		}
		if(Input.touchCount > 0){
			hero.SetActive(false);
			Invoke ("backFrame", 0.4f);
		}
	}

	private void Manager () {
		if (lane == 1) {
			Invoke ("CreateKey1", 5.0f);
		}
		if (lane == 2) {
			Invoke ("CreateKey2", 5.0f);
		}
		if (lane == 3) {
			Invoke ("CreateKey3", 5.0f);
		}
		if (lane == 4) {
			Invoke ("CreateKey4", 5.0f);
		}
	}
		
	private void CreateKey1 () {
		Instantiate (key, new Vector3 (x1, y, z), Quaternion.identity);	
	}

	private void CreateKey2 () {
		Instantiate (key, new Vector3 (x2, y, z), Quaternion.identity);	
	}

	private void CreateKey3 () {
		Instantiate (key, new Vector3 (x3, y, z), Quaternion.identity);	
	}

	private void CreateKey4 () {
		Instantiate (key, new Vector3 (x4, y, z), Quaternion.identity);	
	}

	private void FristTime(){
		Invoke ("CreateKey1", 0.1f);
		Invoke ("CreateKey2", 0.5f);
		Invoke ("CreateKey3", 0.9f);
		Invoke ("CreateKey4", 1.4f);
	}

	private void backFrame(){
		hero.SetActive(true);
	}

	public void AddScore () {
		score++;
	}

	public void AddScore (int value) {
		score += value;
	}

	public float GetLevelSpeed () {
		return this.levelSpeed;
	}
}

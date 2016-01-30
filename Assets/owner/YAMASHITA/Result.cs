using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Result : MonoBehaviour {
	private GameManager manager;
	public float timer;
	public Image resultImage;
	[SerializeField] private Sprite[] winner = new Sprite[2]; 

	//public float alpha;

	void Start () {
		timer = 0;
		manager = GameObject.Find ("gameManager").GetComponent<GameManager> ();
	}

	void Update () {
		if (manager.ReturnGameFinish() == true) {
			timer += Time.deltaTime;
			if (manager. ReturnLoserName() == "Player1") {
				resultImage.sprite = winner [0];
				resultImage.enabled = true;
			}else {
				resultImage.sprite = winner [1];
				resultImage.enabled = true;
			}
		}
		if(3f < timer){
			Application.LoadLevel("credit");
		}
	}
}

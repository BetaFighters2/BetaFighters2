using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Result : MonoBehaviour {
	private GameManager manager;
	public float timer;
	public Image resultImage;
	[SerializeField] private Sprite[] winner = new Sprite[2]; 

	bool isPlayedBgm = false;

	//public float alpha;

	void Start () {
		timer = 0;
		manager = GameObject.Find ("gameManager").GetComponent<GameManager> ();
		isPlayedBgm = false;
	}

	void Update () {
		if (manager.ReturnGameFinish() == true) {
			timer += Time.deltaTime;
			if (manager. ReturnLoserName() == "Player1") {
				GameObject.Find ("1PWIN").GetComponent<Image> ().enabled = true;
				GameObject.Find ("1PWIN").GetComponent<Animator> ().enabled = true;
				//resultImage.enabled = true;
			}else {
				GameObject.Find ("2PWIN").GetComponent<Image> ().enabled = true;
				GameObject.Find ("2PWIN").GetComponent<Animator> ().enabled = true;
				//resultImage.enabled = true;
			}
				
			//鳴らすBGMを入れる
			if (isPlayedBgm == false) {
				SoundManager.PlayBGM (BGM_NAME.RESULT);	
				isPlayedBgm = true;
			}
		}
		if(8f < timer){
			Application.LoadLevel("OPScene");
		}
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour {
	float waitTimer = 0;
	bool isNextScene = false;

	// Use this for initialization
	void Start () {
		//鳴らすBGMを入れる
		SoundManager.PlayBGM (BGM_NAME.HOWTOPLAY);			
		waitTimer = 1;
		isNextScene = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			//SceneManager.LoadScene ("TitleScene");
			if (isNextScene == false) {
				SoundManager.PlaySE (SE_NAME.BUTTON_PUSH, gameObject);
			}
			isNextScene = true;
		}
		if (isNextScene == true) {
			waitTimer -= Time.deltaTime;
			if (waitTimer < 0) {
				SceneManager.LoadScene ("TitleScene");
			}
		}
	}
}

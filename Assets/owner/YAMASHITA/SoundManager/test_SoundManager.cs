using UnityEngine;
using System.Collections;

public class test_SoundManager : MonoBehaviour {
	bool flag = false;
	// Use this for initialization
	void Start () {
		//鳴らすBGMを入れる
		SoundManager.PlayBGM (BGM_NAME.TITLE);


		//鳴らすBGMとフレームタイムを入れる
		//SoundManager.Fade_inPlay (BGM_NAME.TITLE,360f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) flag = true;

		if (flag == true) {
			//フェードアウトするまでにかかるフレームタイムを入れる
			SoundManager.Fade_out (360f);
		}	

	}
}

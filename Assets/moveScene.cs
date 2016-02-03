using UnityEngine;
using System.Collections;

public class moveScene : MonoBehaviour {
	bool isStart;
	float timer;
	// Use this for initialization
	void Start () {
		isStart = false;
		timer = 0;
		SoundManager.PlayBGM (BGM_NAME.CREDITS);
	}
	
	// Update is called once per frame
	void Update () {
		if(isStart){
			GameObject.Find ("Fead").GetComponent<Animator> ().SetBool ("isStart", true);
			timer += Time.deltaTime;
			if(timer > 1.5f){
				Application.LoadLevel("TitleScene");
			}
		}
		if(Input.GetKeyDown(KeyCode.Return)){
			isStart = true;
			SoundManager.PlaySE (SE_NAME.BUTTON_PUSH, gameObject);
		}
	}

	public void toTitle(){
		isStart = true;
	}
}

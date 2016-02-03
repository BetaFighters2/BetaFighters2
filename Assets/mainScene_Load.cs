using UnityEngine;
using System.Collections;

public class mainScene_Load : MonoBehaviour {
	AsyncOperation async;
	void Start(){
		async = Application.LoadLevelAsync ("MainScene");
		async.allowSceneActivation = false;    // シーン遷移をしない
	}
	void Update(){
		if(async.progress >= 0.5f){
			Application.LoadLevel ("TitleScene");
		}
	}
}

using UnityEngine;
using System.Collections;

public class OPLoad : MonoBehaviour {
	float timer;
	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer > 1f){
			Application.LoadLevel ("TitleScene");
		}
	}
}

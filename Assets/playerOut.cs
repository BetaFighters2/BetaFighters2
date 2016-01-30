using UnityEngine;
using System.Collections;

public class playerOut : MonoBehaviour {
	static public bool outP1;
	static public bool outP2;

	// Use this for initialization
	void Start () {
		outP1 = false;
		outP2 = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.name == "Player1"){
			outP1 = false;
		}
		if(col.gameObject.name == "Player2"){
			outP2 = false;
		}
	}
	void OnTriggerExit(Collider col){
		if(col.gameObject.name == "Player1"){
			outP1 = true;
		}
		if(col.gameObject.name == "Player2"){
			outP2 = true;
		}
	}
}

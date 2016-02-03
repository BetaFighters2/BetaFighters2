using UnityEngine;
using System.Collections;

public class betaErea : MonoBehaviour {
	private bool isErea;

	void Start(){
		isErea = false;
	}

	void Update(){
		if(isErea){			
			GameObject.Find("betaGirl").GetComponent<enemyManager>().MoveSide (this.gameObject);
		}
	}
	void OnCollisionStay(Collision col){
		if(col.gameObject.name == "center_player"){
			isErea = true;
		}
	}
	void OnCollisionExit(Collision col){
		if(col.gameObject.name == "center_player"){
			isErea = false;
		}
	}
}

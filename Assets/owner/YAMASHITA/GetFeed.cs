using UnityEngine;
using System.Collections;

public class GetFeed : MonoBehaviour {
	public float upSize = 1.1f;
	public int eatCount = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void UpSizeCheck(){
		upSize = upSize - 0.02f;
		if (upSize < 1.0f) upSize = 1.0001f;
	}

	void OnCollisionEnter(Collision other){
		if (other.transform.CompareTag("Feeds")) {
			eatCount+=1;
			UpSizeCheck ();
			transform.localScale = new Vector3 (transform.localScale.x * upSize,
												transform.localScale.y * upSize,
												transform.localScale.z * upSize);
			Destroy (other.transform.gameObject);
		}
	}
}

using UnityEngine;
using System.Collections;
//ベタをコントロールする

public class betacontrol : MonoBehaviour {
	Rigidbody betarb;

	//select input
	[SerializeField]
	KeyCode bettaup;
	[SerializeField]
	KeyCode bettadown;
	[SerializeField]
	KeyCode bettaleft;
	[SerializeField]
	KeyCode bettaright;

	[SerializeField]
	bool is1P;

	[SerializeField]
	float speed = 10.0f;

	// Use this for initialization
	void Start () {
		betarb = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.Find("gameManager").GetComponent<GameManager>().WorldTimeInt >= 3){//カウントダウン後の移動開始
			float horizontal = 0;
			float vertial = 0;
			if (is1P == true) {
				horizontal = Input.GetAxis ("Horizontal_1P");
				vertial = Input.GetAxis ("Vertical_1P");
			} else {
				horizontal = Input.GetAxis ("Horizontal_2P");
				vertial = Input.GetAxis ("Vertical_2P");
			}
			if (Input.GetKey (bettaleft)
				|| horizontal < -0.5
			)
			{
				transform.rotation = new Quaternion (0, 180, 0, 0);
				betarb.AddForce (Vector3.left *speed);
			}
			if (Input.GetKey (bettaup)
				|| vertial > 0.5
			)
			{
				betarb.AddForce (Vector3.up *speed);
			}
			if (Input.GetKey (bettadown)
				|| vertial < -0.5
			)
			{
				betarb.AddForce (Vector3.down *speed);
			}
			if (Input.GetKey (bettaright)
				|| horizontal > 0.5
			)
			{
				transform.rotation = new Quaternion (0, 0, 0, 0);
				betarb.AddForce (Vector3.right *speed);
			}
		}
	}
}

using UnityEngine;
using System.Collections;

//BGMの名前
public enum BETTA_DIR
{
	NONE = 0,
	UP,
	DOWN,
	RIGHT,
	LEFT,
}

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

	// key direction
	BETTA_DIR bettaDir = BETTA_DIR.NONE;

	// Use this for initialization
	void Start () {
		betarb = this.GetComponent<Rigidbody> ();
		bettaDir = BETTA_DIR.NONE;
	}

	// Update is called once per frame
	void Update () {
		if(GameObject.Find("gameManager").GetComponent<GameManager>().WorldTimeInt >= 3){//カウントダウン後の移動開始
			float horizontal = 0;
			float vertial = 0;
			BETTA_DIR newBettaDir = BETTA_DIR.NONE;

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
				newBettaDir = BETTA_DIR.LEFT;
			}
			if (Input.GetKey (bettaup)
				|| vertial > 0.5
			)
			{
				betarb.AddForce (Vector3.up *speed);
				newBettaDir = BETTA_DIR.UP;
			}
			if (Input.GetKey (bettadown)
				|| vertial < -0.5
			)
			{
				betarb.AddForce (Vector3.down *speed);
				newBettaDir = BETTA_DIR.DOWN;
			}
			if (Input.GetKey (bettaright)
				|| horizontal > 0.5
			)
			{
				transform.rotation = new Quaternion (0, 0, 0, 0);
				betarb.AddForce (Vector3.right *speed);
				newBettaDir = BETTA_DIR.RIGHT;
			}

			// Play swim SE
			if (bettaDir != newBettaDir) {
				SoundManager.PlaySE (SE_NAME.SWIM, gameObject);	
			}
			bettaDir = newBettaDir;
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag ("Player")) {
			SoundManager.PlaySE (SE_NAME.HIT, gameObject);
		}
	}

}
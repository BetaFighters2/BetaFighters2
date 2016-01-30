using UnityEngine;
using System.Collections;

public class enemyManager : MonoBehaviour {
	private bool isPlayer;
	public GameObject pos1;
	public GameObject pos2;
	public float speed;
	private float sh;
	private bool isAnim1;
	private bool isAnim2;
//	public Transform target;
	// Use this for initialization
	void Start () {
		isAnim1 = false;
		isAnim2 = false;
		isPlayer = false;
		sh = Screen.height;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("gameManager").GetComponent<GameManager> ().ReturnGameFinish () == false) {			
			if (GameObject.Find ("gameManager").GetComponent<GameManager> ().WorldTimeInt >= 3 && GameObject.Find ("gameManager").GetComponent<GameManager> ().GameFinish == false) {//カウントダウン後の移動開始
				GameObject.Find ("Enemy").GetComponent<Animator> ().SetBool ("isStart", true);
			} else {
				GameObject.Find ("Enemy").GetComponent<Animator> ().SetBool ("isStart", false);
			}

			if (playerOut.outP1) {
				GameObject.Find ("Enemy").GetComponent<Animator> ().Stop ();
				LookAt2D (pos1);
				Move (pos1);
				isAnim1 = true;
			} else if (!playerOut.outP1) {
				if (isAnim1 == true) {
					GameObject.Find ("Enemy").GetComponent<Animator> ().Play ("betaGirl", 0, 0.0f);
					isAnim1 = false;
				}
			}
			if (playerOut.outP2) {
				GameObject.Find ("Enemy").GetComponent<Animator> ().Stop ();
				LookAt2D (pos2);
				Move (pos2);
				isAnim2 = true;
			} else if (!playerOut.outP2) {
				if (isAnim2 == true) {
					GameObject.Find ("Enemy").GetComponent<Animator> ().Play ("betaGirl", 0, 0.0f);
					isAnim2 = false;
				}
			}
		} else {
			GameObject.Find ("betaGirl").GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
			GameObject.Find ("Enemy").GetComponent<Animator> ().Stop ();
			speed = 0;
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.name == "Player1"){
			GameObject.Find ("gameManager").GetComponent<GameManager>().SetGameFinish(col.gameObject.name);
			Destroy (col.gameObject);
		}
		if(col.gameObject.name == "Player2"){
			GameObject.Find ("gameManager").GetComponent<GameManager>().SetGameFinish(col.gameObject.name);
			Destroy (col.gameObject);
		}
	}
	void LookAt2D(GameObject target)
	{
		if(target == null){
			return;
		}
		// 指定オブジェクトと回転さすオブジェクトの位置の差分(ベクトル)
		Vector3 pos = target.transform.position - transform.position;
		// ベクトルのX,Yを使い回転角を求める
		float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
		Quaternion rotation = new Quaternion();
		// 回転角は右方向が0度なので-90しています
		var screenPos = GameObject.Find("Main Camera").GetComponent<Camera>().WorldToScreenPoint(this.transform.position);
//		if (screenPos.y > sh / 2) {
			rotation.eulerAngles = new Vector3 (0, 0, angle);
//		} else {
		//	rotation.eulerAngles = new Vector3 (0, 180, angle + 90);		
//		}
		// 回転
		transform.rotation = rotation;
	}

	void Move(GameObject target){
		if(target == null){
			return;
		}
		this.gameObject.GetComponent<Rigidbody>().velocity = (target.transform.position - this.transform.position).normalized * speed;
	}
}

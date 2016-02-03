using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class enemyManager : MonoBehaviour {
	private bool isPlayer;
	public GameObject pos1;
	public GameObject pos2;
	public float speed;
	private float sh;
	private bool isAnim;
	public GameObject posZero;
//	public Transform target;
	// Use this for initialization
	void Start () {
		isAnim = false;
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
				GameObject.Find ("warning").GetComponent<Animator> ().SetBool("isWarning", true);
				GameObject.Find ("Enemy").GetComponent<Animator> ().speed = 0;
				LookAt2D (pos1);
				Move (pos1);
				if (isAnim == false) {
					SoundManager.PlaySE (SE_NAME.CAN_EAT, gameObject);
				}
				isAnim = true;
			} 
			if (playerOut.outP2) {
				GameObject.Find ("warning").GetComponent<Animator> ().SetBool("isWarning", true);
				GameObject.Find ("Enemy").GetComponent<Animator> ().speed = 0;
				LookAt2D (pos2);
				Move (pos2);
				if (isAnim == false) {
					SoundManager.PlaySE (SE_NAME.CAN_EAT, gameObject);
				}
				isAnim = true;
			} 
			if (!playerOut.outP1 && !playerOut.outP2) {
				if (isAnim == true) {
					GameObject.Find ("warning").GetComponent<Animator> ().SetBool("isWarning", false);
					LookAt2D (posZero);
					Move (posZero);
					if(0.1f > Mathf.Abs(this.transform.localPosition.x)){
						GameObject.Find ("betaGirl").GetComponent<Rigidbody> ().velocity = Vector3.zero;
						GameObject.Find ("betaGirl").transform.localPosition = new Vector3 (0,0,0);
						GameObject.Find ("betaGirl").transform.localEulerAngles = new Vector3 (0, 180, 90);
						GameObject.Find ("Enemy").GetComponent<Animator> ().speed = 1;
						isAnim = false;
					}
				}
			}


		} else {
			GameObject.Find ("betaGirl").GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
			GameObject.Find ("Enemy").GetComponent<Animator> ().Stop ();
			speed = 0;
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
		rotation.eulerAngles = new Vector3 (0, 0, angle);
		transform.rotation = rotation;
	}

	void Move(GameObject target){
		if(target == null){
			return;
		}
		this.gameObject.GetComponent<Rigidbody>().velocity = (target.transform.position - this.transform.position).normalized * speed;
	}
	public void MoveSide(GameObject target){
		if(target == null){
			return;
		}
		this.transform.position += this.transform.right * speed * Time.deltaTime;
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.name == "Player1"){
			if(GameObject.Find ("gameManager").GetComponent<GameManager>().GameFinish == false){
				GameObject.Find ("gameManager").GetComponent<GameManager>().SetGameFinish(col.gameObject.name);
				SoundManager.PlaySE (SE_NAME.EAT, gameObject);	
				Destroy (col.gameObject);
			}
		}
		if(col.gameObject.name == "Player2"){
			if (GameObject.Find ("gameManager").GetComponent<GameManager> ().GameFinish == false) {
				GameObject.Find ("gameManager").GetComponent<GameManager> ().SetGameFinish (col.gameObject.name);
				SoundManager.PlaySE (SE_NAME.EAT, gameObject);	
				Destroy (col.gameObject);
			}
		}
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//えさのスクリプト
public class Feed : MonoBehaviour {
	public GameObject obj;
	//public Canvas canvas;
	private Vector3[] feed_pos = new Vector3[10];	 //それぞれのポジション

	public float Min_X = 0f, Max_X = 0f; 			 //Xの最小値,最大値
	public float Min_Y = 0f, Max_Y = 0f; 			 //yの最小値,最大値

	private bool setTime;	 						 //タイム, ポジションを決めたときのフラグ
	public float MinTimer = 0f,MaxTimer = 1f;		 //発射までの最小待ち時間と最大待ち時間
	private int MaxFeedCount = 10; 				     //一度に出すえさの最大数
	public float waitTimer = 0f, timer = 0f;
	private GameManager manager;
	private int count=0;

	// Use this for initialization
	void Start () {
//		manager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
		setTime = false;
	}

	void Update () {
		//初期Instatnce
		if (GameObject.Find("gameManager").GetComponent<GameManager>().ReturnMove () == true && count == 0) {
			SetFeedInstance ();
			count = 1;
		}

		SetSpawnTime ();

		timer += Time.deltaTime;
		if (waitTimer - timer <= 0f) {
			SetFeedInstance ();
			setTime = false;
			timer = 0;
		}
	}

	//えさの出現時間をランダムで決定
	void SetSpawnTime(){
		if (setTime != true) {
			waitTimer = Random.Range (MinTimer, MaxTimer);
			setTime = true;
		}
	}

	void SetFeedInstance(){
		for (int i = 0; i < MaxFeedCount; i++) {
			feed_pos[i] = new Vector3 (Random.Range (Min_X, Max_X), 
									   Random.Range (Min_Y, Max_Y),
									   0);

			GameObject newObj = Instantiate (obj, 
				                             feed_pos [i], 
				                             Quaternion.identity) as GameObject;
		} 
	}
}

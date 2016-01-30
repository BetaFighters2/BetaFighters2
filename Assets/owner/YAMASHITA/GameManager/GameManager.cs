using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public float WorldTime = 0f;		//全体の経過時間
	public int WorldTimeInt = 0;		//全体の経過時間(int型)

	public bool Move;					//Playerたちが動けるかどうか
	public bool GameFinish;				//Game終了時
	public string loserName;            //負けたPlayerがどちらか

	// Use this for initialization
	void Awake () {
		Move = false;
		GameFinish = false;
	}

	// Update is called once per frame
	void Update () {
		WorldTime += 1.0f * Time.deltaTime;
		WorldTimeInt = (int)WorldTime;
	}

	public bool ReturnMove(){
		return Move;
	}

	public bool ReturnGameFinish(){
		return GameFinish;
	}

	/**************必要か悩んだので追加(不要なら後で削除)*************/
	//３カウントが終わってPlayerが動き出すためのフラグをTrueにする.
	public bool SetMove(){
		return Move = true;
	}

	//死んだ時用. 引数は負けたPlayerの名前を入れる.
	public bool SetGameFinish(string str){
		loserName = str;
		return GameFinish = true;
	}

	//勝ち負け表示時用.
	public string ReturnLoserName() {
		return loserName;
	}
	/****************************************************************/
}

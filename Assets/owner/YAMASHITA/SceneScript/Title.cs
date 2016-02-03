using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Title : MonoBehaviour {
	public Image[] selectImage = new Image[4];
	private int selectNum = 0;
	private bool isStart;
	private float timer;

	// Alpha増減値(点滅スピード調整)
	private float _Step = 0.05f;
	public int stageLimit;
	public string[] nextSceneName = new string[3];

	void Awake(){
		isStart = false;
		timer = 0;
		//鳴らすBGMを入れる
	}
	// Use this for initialization
	void Start () {
		SoundManager.PlayBGM (BGM_NAME.TITLE);	
		AsyncOperation async = Application.LoadLevelAsync("MainScene");
		async.allowSceneActivation = false;    // シーン遷移をしない
	}
	
	// Update is called once per frame
	void Update () {
		AlphaChange ();

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			selectNum++;
			if (selectNum > 3)	selectNum = 0;
			SoundManager.PlaySE (SE_NAME.SWIM, gameObject);
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			selectNum--;
			if (selectNum < 0)	selectNum = 3;
			SoundManager.PlaySE (SE_NAME.SWIM, gameObject);
		}

		if (Input.GetKeyDown (KeyCode.Return)
			|| Input.GetButtonDown( "Fire1" )
			|| Input.GetButtonDown( "Fire1_pad" )
		) {
			isStart = true; 
			GameObject.Find ("Fead").GetComponent<Animator> ().SetBool ("isStart", true);
			SoundManager.PlaySE (SE_NAME.BUTTON_PUSH, gameObject);
		}

		if(isStart){
			timer += Time.deltaTime;
			if(timer > 1.5f){
				if (selectNum == 0)	SoundManager.stageNum = Random.Range(1,stageLimit);
				if (selectNum == 3)	Application.Quit ();
				else Application.LoadLevel (nextSceneName[selectNum]);
			}
		}
	}

	void AlphaChange() {
		// 現在のAlpha値を取得
		float toColor = selectImage[selectNum].GetComponent<Image>().color.a;

		// Alphaが0 または 1になったら増減値を反転
		if (toColor < 0 || toColor > 1)
		{
			_Step = _Step * -1;
		}

		// Alpha値を増減させてセット
		if (selectNum == 0) {
			selectImage [0].GetComponent<Image> ().color = new Color (255, 255, 255, toColor + _Step);
			selectImage [1].GetComponent<Image> ().color = new Color (255, 255, 255, 1);
			selectImage [2].GetComponent<Image> ().color = new Color (255, 255, 255, 1);
			selectImage [3].GetComponent<Image> ().color = new Color (255, 255, 255, 1);
		} else if (selectNum == 1) {
			selectImage [0].GetComponent<Image> ().color = new Color (255, 255, 255, 1);
			selectImage [1].GetComponent<Image> ().color = new Color (255, 255, 255, toColor + _Step);
			selectImage [2].GetComponent<Image> ().color = new Color (255, 255, 255, 1);
			selectImage [3].GetComponent<Image> ().color = new Color (255, 255, 255, 1);
		} else if (selectNum == 2) {
			selectImage [0].GetComponent<Image> ().color = new Color (255, 255, 255, 1);
			selectImage [1].GetComponent<Image> ().color = new Color (255, 255, 255, 1);
			selectImage [2].GetComponent<Image> ().color = new Color (255, 255, 255, toColor + _Step);
			selectImage [3].GetComponent<Image> ().color = new Color (255, 255, 255, 1);
		} else {
			selectImage [0].GetComponent<Image> ().color = new Color (255, 255, 255, 1);
			selectImage [1].GetComponent<Image> ().color = new Color (255, 255, 255, 1);
			selectImage [2].GetComponent<Image> ().color = new Color (255, 255, 255, 1);
			selectImage [3].GetComponent<Image> ().color = new Color (255, 255, 255, toColor + _Step);
		}
	}
}

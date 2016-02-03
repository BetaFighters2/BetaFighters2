using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StageSelect : MonoBehaviour {
	public Image[] stageImage = new Image[3]; 
	public int selectNum = 0;
	private bool stop, setStage;
	public float stopingTimer = 3f, selenum = 0f;

	private bool isStart;
	[SerializeField] private float timer = 0f, waitTime = 3f;

	// Use this for initialization
	void Start () {
		stop = false;
		setStage = false;
		isStart = false;
	}

	// Update is called once per frame
	void Update () {
		//SetStageNum ();
		if (stop == false){
			selectNum = Random.Range (0, stageImage.Length);
		} else {
			timer += Time.deltaTime;
			if (timer > waitTime) {
				isStart = true; 
				GameObject.Find ("Fead").GetComponent<Animator> ().SetBool ("isStart", true);
			}
		}
			
		if(Input.GetKeyDown(KeyCode.Return)) stop = true;

		SetStageColor ();
	}
		
	void SetStageNum(){
		if (setStage == false) {
			if(Input.GetKeyDown(KeyCode.Return)) stop = true;

			selenum += stopingTimer;
			selectNum = (int)selenum;
			if (selectNum >= 2) selectNum = 0;

			if (stop == true) stopingTimer -= 1.0f * Time.deltaTime;

			if (stopingTimer <= 0.0f) setStage = true;
		}
	}

	void SetStageColor(){
		if (selectNum == 0) {
			stageImage [0].color = new Color (255, 0, 0, 1);
			stageImage [1].color = new Color (255, 255, 255, 1);
			stageImage [2].color = new Color (255, 255, 255, 1);
		} else if (selectNum == 1) {
			stageImage [0].color = new Color (255, 255, 255, 1);
			stageImage [1].color = new Color (255, 0, 0, 1);
			stageImage [2].color = new Color (255, 255, 255, 1);
		} else {
			stageImage [0].color = new Color (255, 255, 255, 1);
			stageImage [1].color = new Color (255, 255, 255, 1);
			stageImage [2].color = new Color (255, 0, 0, 1);
		}

	}
}

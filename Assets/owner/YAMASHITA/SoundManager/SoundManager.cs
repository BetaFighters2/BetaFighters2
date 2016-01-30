using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//BGMの名前
public enum BGM_NAME
{
	TITLE = 0,
	GAMEPLAY,
}

//BGMの名前
public enum SE_NAME
{
	BUTTON_PUSH = 0,
	THREE_COUNT,
	HIT,
	EAT,
	CAN_EAT,
	SWIM,
	RESULT
}

public class SoundManager : MonoBehaviour {
	[System.Serializable]
	public class BGMs
	{
		public BGM_NAME bgmName;
		public AudioClip clip;
		public float volume=1.0f;
	}

	[System.Serializable]
	public class SEs
	{
		public SE_NAME seName;
		public AudioClip se;
		public float volume=1.0f;
	}
	[SerializeField]
	BGMs[] bgmParameter;
	[SerializeField]
	SEs[] seParameter;

	public AnimationCurve feed_inCurveSetting;
	public AnimationCurve feed_outCurveSetting;

	static Dictionary<BGM_NAME, BGMs> bgmDictionary;
	static Dictionary<SE_NAME, SEs> seDictionary;

	static AnimationCurve feed_inCurve;
	static AnimationCurve feed_outCurve;

	static AnimationCurve updateCurve;
	static GameObject myObj;
	static BGM_NAME nowBgmEnum;
	static float nowVolume;

	float curveRate;
	static float beginVolume;
	static float endVolume;
	public float frame;

	void Awake () {
		if (GameObject.FindGameObjectsWithTag ("SoundManager").Length >= 2) {
			Destroy (gameObject);
			return;
		}
		curveRate = 0.0f;
		nowVolume = 1.0f;
		updateCurve = null;
		DontDestroyOnLoad (this.gameObject);
		feed_inCurve = feed_inCurveSetting;
		feed_outCurve = feed_outCurveSetting;

		//Dictionaryに追加する
		bgmDictionary = new Dictionary<BGM_NAME, BGMs>();
		for (int i = 0; i < bgmParameter.Length; i++) {
			bgmDictionary [bgmParameter [i].bgmName] = bgmParameter [i];
		}

		seDictionary = new Dictionary<SE_NAME, SEs>();
		for (int i = 0; i < seParameter.Length; i++) {
			seDictionary [seParameter [i].seName] = seParameter [i];
		}
		gameObject.AddComponent<AudioSource> ();
		myObj = gameObject;
		nowBgmEnum = BGM_NAME.TITLE;
		SetVolume (1.0f);
	}
	

	void Update () {
		//フェードイン処理
		if(updateCurve != null) {
			curveRate += 1 / frame;
			SetVolume(Mathf.Lerp(beginVolume,endVolume,updateCurve.Evaluate(curveRate)));

			if (updateCurve.Evaluate(curveRate)>= 1.0f) {
				updateCurve = null;
				SetVolume(endVolume);
			}
		} else {
			curveRate = 0.0f;
		}
	}

	public static void Fade_inPlay(BGM_NAME bgmEnum,float frame) {
		nowBgmEnum = bgmEnum;
		BGMs bgms = bgmDictionary[bgmEnum];
		myObj.GetComponent<AudioSource>().clip = bgms.clip;
		myObj.GetComponent<AudioSource>().Play();
		updateCurve = feed_inCurve;
		beginVolume = 0.0f;
		endVolume = nowVolume * bgmDictionary[nowBgmEnum].volume;
		myObj.GetComponent<SoundManager>().frame = frame;
	}

	public static void Fade_out(float frame) {
		updateCurve = feed_outCurve;
		beginVolume = GetVolume();
		endVolume = 0.0f;
		myObj.GetComponent<SoundManager>().frame = frame;
	}

	public static void SetVolume(float v) {
		nowVolume = v;
		myObj.GetComponent<AudioSource>().volume = nowVolume * bgmDictionary[nowBgmEnum].volume;
	}

	public static float GetVolume() {
		return nowVolume;
	}

	//BGMを再生する
	public static void PlayBGM(BGM_NAME bgmEnum) {
		nowBgmEnum = bgmEnum;
		AudioSource audio = myObj.GetComponent<AudioSource>();
		BGMs bgm = bgmDictionary[bgmEnum];
		audio.Stop();
		audio.clip = bgm.clip;
		audio.loop = true;
		audio.volume = nowVolume*bgm.volume;
		audio.Play();
	}

	//SEを再生
	public static void PlaySE(SE_NAME seEnum) {
		SEs se = seDictionary[seEnum];
		AudioSource audio = myObj.GetComponent<AudioSource>();

		audio.loop = false;
		audio.clip = se.se;
		audio.volume = nowVolume*se.volume;
		audio.Play();
	}

	//SEを再生
	public static void PlaySE(SE_NAME seEnum, GameObject obj) {
		SEs se = seDictionary[seEnum];
		AudioSource audio;

		audio = isComponent(obj);
		audio.loop = false;
		audio.clip = se.se;
		audio.volume = nowVolume*se.volume;
		audio.Play();
	}

	//SEを再生するAudioSorceを取得する
	static AudioSource isComponent(GameObject obj)
	{
		AudioSource ans=null;
		//オブジェクトが持っているAudioSourceを全て取得
		AudioSource[] audio=obj.GetComponents<AudioSource>();

		for(int i=0;i<audio.Length;i++)
		{
			if(!audio[i].isPlaying)//再生していないAudioSourceがあったら
			{
				ans = audio[i];//それを格納
				break;
			}
		}
		//再生していないAudioSourceがない場合
		if(ans==null)
		{
			ans = obj.AddComponent<AudioSource>();//新しくADDComponentする
		}

		return ans;
	}
}

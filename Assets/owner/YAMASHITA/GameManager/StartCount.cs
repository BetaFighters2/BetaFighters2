using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StartCount : MonoBehaviour {
	private GameManager manager;
	Image myImage;                      		 		
	[SerializeField] private float addAlpha;             //1フレーム毎に足されていくalpha値
	[SerializeField] private List<Sprite> countSprite;   //カウントダウンのスプライト
	private int spriteNum;              				 //カウントダウンの数
	private int countNum;              					 //現在のカウントダウンの数

	// Use this for initialization
	void Awake () {
		manager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
		myImage = GetComponent<Image>();
		spriteNum = countSprite.Count;

		countNum = -1;
		SetSprite();
	}

	void Update(){
		
	}
		
	void SetSprite()
	{
		countNum++;
		if(countNum>=spriteNum)//最後の数だったら
		{
			manager.SetMove ();
			Destroy(gameObject);//このオブジェクトの削除
			return;
		}
		myImage.sprite = countSprite[countNum];
		StartCoroutine(Transparency());
	}

	IEnumerator Transparency()
	{
		float alpha = 0.0f;
		Color color = myImage.color;
		while(true)
		{
			alpha += addAlpha * Time.deltaTime;
			color.a = alpha;
			myImage.color = color;
			if (alpha >= 1.0f) break;
			yield return null;
		}
		SetSprite();
	}
}

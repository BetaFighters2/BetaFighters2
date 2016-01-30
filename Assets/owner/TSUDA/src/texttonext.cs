using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class texttonext : MonoBehaviour {
	[SerializeField]
	int speedofscroll = 2;
	[SerializeField]
	int mostlargesize = 1000;
	[SerializeField]
	int NumberofMember;

	//サイズ変更用
	RectTransform trans;
	private int NameofWidth = 0;

	//親オブジェクト(Canvas)
	private GameObject parent;

	private Text nametex;
	private string[] membername;

	// Use this for initialization
	void Start () {
		trans = this.GetComponent (typeof(RectTransform))as RectTransform;
		parent = transform.root.gameObject;
		nametex = this.GetComponent<Text> ();
		membername = parent.GetComponent<credit> ().member;
		//this.GetComponent<Text> ().text = parent.GetComponent<credit>().member[NumberofMember];
	}
	
	// Update is called once per frame
	void Update () {
		MoveName ();

	}

	void MoveName()
	{
		nametex.text = membername [NumberofMember];

		if (NameofWidth < mostlargesize)
		{
			NameofWidth+=speedofscroll;
		}
		else
		{
			NameofWidth = mostlargesize;
		}
		trans.sizeDelta = new Vector2 (NameofWidth, 80);
	}
}

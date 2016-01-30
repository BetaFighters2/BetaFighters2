using UnityEngine;
using System.Collections;

public class nawabariScript : MonoBehaviour {

    public GameObject obj;
    public float Animation;
    public string folderName;
    public string headText;
    public int imageLength;
    private int firstFrameNum;
    private float dTime;

	void Start () {

        firstFrameNum = 1;
        dTime = 0.0f;

	}
	
	
	void Update () {
        dTime += Time.deltaTime;
        if(Animation < dTime){
            dTime = 0.0f;
            firstFrameNum++;
            if (firstFrameNum > imageLength) firstFrameNum = 1;
        }

        Texture tex = Resources.Load(folderName + "/" + headText + firstFrameNum) as Texture;
        //obj.renderer.material.SetTexture("_MainTex",tex);

	}
}

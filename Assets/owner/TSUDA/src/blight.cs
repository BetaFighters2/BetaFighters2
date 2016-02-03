using UnityEngine;
using System.Collections;

public class blight : MonoBehaviour {
	private float frame;
	Renderer render;

	// Use this for initialization
	void Start () {
		render = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		frame+=Time.deltaTime;

		if (frame % 30 == 0)
		{
			render.enabled = false;
		}
		else
		{
			render.enabled = true;
		}
	}
}

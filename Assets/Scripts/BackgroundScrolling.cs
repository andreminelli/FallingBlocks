using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour {

	public float Velocity = 0.3f;
	Material material;

	// Use this for initialization
	void Start () {
		material = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {

		material.mainTextureOffset = new Vector2(0, Velocity) * Time.timeSinceLevelLoad;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour {
    private const int Speed = 7;
    private float visibleHeightThreshold;

    // Use this for initialization
    void Start () {
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
        if (transform.position.y < visibleHeightThreshold)
        {
            Destroy(gameObject);
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour {
	public GameObject StopFallingPrefab;

	Vector2 screenHalfWorldUnits;
	float nextSpawnTime;

	// Use this for initialization
	void Start () {
		screenHalfWorldUnits = Screen.HalfWorldUnits;
		nextSpawnTime = 5f;
	}

	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawnTime)
		{
			var spawnPosition = new Vector2(Random.Range(-screenHalfWorldUnits.x, screenHalfWorldUnits.x), screenHalfWorldUnits.y);
			Instantiate(StopFallingPrefab, spawnPosition, Quaternion.identity);

			// Stop spawning
			nextSpawnTime = float.MaxValue;
		}
	}
}

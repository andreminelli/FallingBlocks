using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject FallingBlockPrefab;
	public int Speed = 7;
	public float SecondsBetweenSpawnsMin = 0.4f;
	public float SecondsBetweenSpawnsMax = 1;
	public float SpawnAngleMax = 15;
	public float SpawnSizeMin = 0.2f;
	public float SpawnSizeMax = 2f;


	float nextSpawnTime;
	Vector2 screenHalfWidthWorldUnits;

	// Use this for initialization
	void Start () {
		screenHalfWidthWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
	}

	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawnTime)
		{
			var secondsBetweenSpawns = Mathf.Lerp(SecondsBetweenSpawnsMax, SecondsBetweenSpawnsMin, Difficulty.GetDifficultyPercent());
			nextSpawnTime = Time.time + secondsBetweenSpawns;

			var spawnAngle = Random.Range(-SpawnAngleMax, SpawnAngleMax);
			var spawnSize = Random.Range(SpawnSizeMin, SpawnSizeMax);
			var spawnPosition = new Vector2(Random.Range(-screenHalfWidthWorldUnits.x, screenHalfWidthWorldUnits.x), screenHalfWidthWorldUnits.y);
			var newBlock = Instantiate(FallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
			newBlock.transform.localScale = Vector2.one * spawnSize;
		}

	}
}

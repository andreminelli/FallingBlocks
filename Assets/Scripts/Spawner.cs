using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject FallingBlockPrefab1;
	public GameObject FallingBlockPrefab2;
	public GameObject FallingBlockPrefab3;

	public int Speed = 7;
	public float SecondsBetweenSpawnsMin = 0.4f;
	public float SecondsBetweenSpawnsMax = 1;
	public float SpawnAngleMax = 15;
	public float SpawnSizeMin = 0.2f;
	public float SpawnSizeMax = 2f;


	GameObject[] fallingBlocksPrefabs;
	float nextSpawnTime;
	Vector2 screenHalfWidthWorldUnits;

	// Use this for initialization
	void Start () {
		screenHalfWidthWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);

		fallingBlocksPrefabs = new[] { FallingBlockPrefab1, FallingBlockPrefab2, FallingBlockPrefab3 };
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
			var fallingBlockPrefab = fallingBlocksPrefabs[Random.Range(0, 1000) % fallingBlocksPrefabs.Length];
			var newBlock = Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
			newBlock.transform.localScale = Vector2.one * spawnSize;
		}

	}
}

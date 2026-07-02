using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject FallingBlockPrefab1;
	public GameObject FallingBlockPrefab2;
	public GameObject FallingBlockPrefab3;

	public float SecondsBetweenSpawnsMin = 0.4f;
	public float SecondsBetweenSpawnsMax = 1;
	public float SpawnAngleMax = 15;
	public float SpawnSizeMin = 0.2f;
	public float SpawnSizeMax = 2f;

	public Vector2 FallingSpeedMinMax;

	GameObject[] fallingBlocksPrefabs;
	float nextSpawnTime;

	// Use this for initialization
	void Start ()
	{
		fallingBlocksPrefabs = new[] { FallingBlockPrefab1, FallingBlockPrefab2, FallingBlockPrefab3 };
	}

	// Update is called once per frame
	void Update ()
	{
		if (Time.time > nextSpawnTime && Difficulty.SpawnEnabled)
		{
			var secondsBetweenSpawns = Mathf.Lerp(SecondsBetweenSpawnsMax, SecondsBetweenSpawnsMin, Difficulty.GetDifficultyPercent());
			nextSpawnTime = Time.time + secondsBetweenSpawns;

			var spawnAngle = Random.Range(-SpawnAngleMax, SpawnAngleMax);
			var spawnSize = Random.Range(SpawnSizeMin, SpawnSizeMax);
			var horizontalBounds = Screen.HorizontalWorldBounds;
			var spawnPosition = new Vector2(Random.Range(horizontalBounds.x, horizontalBounds.y), Screen.TopWorldY);
			var fallingBlockPrefab = fallingBlocksPrefabs[Random.Range(0, 1000) % fallingBlocksPrefabs.Length];
			var newBlock = Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
			newBlock.transform.localScale = Vector2.one * spawnSize;

			var fallingBlock = newBlock.GetComponent<FallingBlock>();
			if (fallingBlock == null)
			{
				Debug.LogError("Spawned falling block prefab is missing FallingBlock component.", this);
				return;
			}
			fallingBlock.Initialize(FallingSpeedMinMax);
		}

	}
}

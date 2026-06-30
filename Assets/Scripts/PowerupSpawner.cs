using UnityEngine;

public class PowerupSpawner : MonoBehaviour {
	public GameObject StopFallingPrefab;

	float nextSpawnTime;

	void Start ()
	{
		SetNextSpawnTime();
	}

	void Update ()
	{
		if (Time.time > nextSpawnTime)
		{
			var horizontalBounds = Screen.HorizontalWorldBounds;
			var spawnPosition = new Vector2(Random.Range(horizontalBounds.x, horizontalBounds.y), Screen.TopWorldY);
			Instantiate(StopFallingPrefab, spawnPosition, Quaternion.identity);

			SetNextSpawnTime();
		}
	}

	private void SetNextSpawnTime()
	{
		nextSpawnTime = Time.time + Random.Range(5, 15);
	}
}

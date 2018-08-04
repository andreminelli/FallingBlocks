using UnityEngine;

public class PowerupSpawner : MonoBehaviour {
	public GameObject StopFallingPrefab;

	Vector2 screenHalfWorldUnits;
	float nextSpawnTime;

	void Start ()
	{
		screenHalfWorldUnits = Screen.HalfWorldUnits;
		SetNextSpawnTime();
	}

	void Update ()
	{
		if (Time.time > nextSpawnTime)
		{
			var spawnPosition = new Vector2(Random.Range(-screenHalfWorldUnits.x, screenHalfWorldUnits.x), screenHalfWorldUnits.y);
			Instantiate(StopFallingPrefab, spawnPosition, Quaternion.identity);

			SetNextSpawnTime();
		}
	}

	private void SetNextSpawnTime()
	{
		nextSpawnTime = Time.time + Random.Range(5, 15);
	}
}

using UnityEngine;

public class PowerupSpawner : MonoBehaviour {
	public GameObject StopFallingPrefab;
	private Spawner spawner;

	float nextSpawnTime;

	void Start ()
	{
        if (spawner == null)
        {
            spawner = FindAnyObjectByType<Spawner>();
        }

        if (spawner == null)
        {
            Debug.LogError("PowerupSpawner requires a Spawner reference.", this);
        }

        SetNextSpawnTime();
	}

	void Update ()
	{
		if (spawner == null)
		{
			return;
		}

		if (Time.time > nextSpawnTime)
		{
			var horizontalBounds = Screen.HorizontalWorldBounds;
			var spawnPosition = new Vector2(Random.Range(horizontalBounds.x, horizontalBounds.y), Screen.TopWorldY);
			var powerup = Instantiate(StopFallingPrefab, spawnPosition, Quaternion.identity);
			var fallingBlock = powerup.GetComponent<FallingBlock>();
			if (fallingBlock == null)
			{
				Debug.LogError("Spawned powerup prefab is missing FallingBlock component.", this);
				return;
			}
			fallingBlock.Initialize(spawner.FallingSpeedMinMax);

			SetNextSpawnTime();
		}
	}

	private void SetNextSpawnTime()
	{
		nextSpawnTime = Time.time + Random.Range(5, 15);
	}
}

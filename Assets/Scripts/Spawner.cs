using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject FallingBlockPrefab;
    public int Speed = 7;
    public float secondsBetweenSpawns = 1;

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
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            var spawnPosition = new Vector2(Random.Range(-screenHalfWidthWorldUnits.x, screenHalfWidthWorldUnits.x), screenHalfWidthWorldUnits.y);
            var newBlock = Instantiate(FallingBlockPrefab, spawnPosition, Quaternion.identity);
        }

	}
}

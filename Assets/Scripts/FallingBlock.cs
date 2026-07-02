using UnityEngine;

public class FallingBlock : MonoBehaviour {
	private Vector2 speedMinMax = new(7, 13);
	private float speed;
	private float visibleHeightThreshold;

	public void Initialize(Vector2 configuredSpeedMinMax)
	{
		speedMinMax = configuredSpeedMinMax;
		speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
	}

    void Start()
    {
		visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
		speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
	}

    void Update()
    {
		transform.Translate(Vector3.down * speed * Time.deltaTime);
		if (transform.position.y < visibleHeightThreshold)
		{
			Destroy(gameObject);
		}
	}
}

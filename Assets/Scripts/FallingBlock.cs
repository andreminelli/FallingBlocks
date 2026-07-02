using UnityEngine;

public class FallingBlock : MonoBehaviour {
	private Vector2 speedMinMax = new(7, 13);
	private float speed;
    private float visibleHeightThreshold;

    private Camera mainCamera;
	private SpriteRenderer spriteRenderer;

	public void Initialize(Vector2 configuredSpeedMinMax)
	{
		speedMinMax = configuredSpeedMinMax;
		speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
	}

    void Start()
    {
		spriteRenderer = GetComponent<SpriteRenderer>();
		BackgroundClipMask.EnsureCreated();
		if (spriteRenderer != null) spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
	}

    void Update()
    {
		transform.Translate(Vector3.down * speed * Time.deltaTime);

		var spriteExtents = spriteRenderer != null
			? spriteRenderer.bounds.extents
			: new Vector3(transform.lossyScale.x * 0.5f, transform.lossyScale.y * 0.5f, 0f);
        if (transform.position.y < visibleHeightThreshold)
        {
			Destroy(gameObject);
		}
	}
}

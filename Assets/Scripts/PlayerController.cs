using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private const int Speed = 7;
	private float playerHalfWidth;

	public event Action OnPlayerDeath;
	public event Action OnPowerup;

	void Start ()
	{
		var collider2d = GetComponent<Collider2D>();
		playerHalfWidth = collider2d != null ? collider2d.bounds.extents.x : transform.localScale.x / 2f;
	}
	
	void Update ()
	{
		var inputX = GameInput.GetHorizontalMovement();
		var velocity = inputX * Speed;
		transform.Translate(Vector2.right * velocity * Time.deltaTime);

		var horizontalBounds = Screen.HorizontalWorldBounds;
		var clampedX = Mathf.Clamp(transform.position.x, horizontalBounds.x + playerHalfWidth, horizontalBounds.y - playerHalfWidth);
		transform.position = new Vector2(clampedX, transform.position.y);

		Beam();
	}

	private void Beam()
	{
		var hitInfo = Physics2D.Raycast(transform.position, transform.up, 100);
		if (hitInfo.collider != null)
		{
			Debug.Log(hitInfo.collider.name);
			Debug.DrawLine(transform.position, hitInfo.point, Color.red);
		}
		else
		{
			Debug.Log("no collider");
			Debug.DrawLine(transform.position, transform.position + transform.up * 100, Color.green);
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Powerup")
		{
			OnPowerup?.Invoke();
			Destroy(collider.gameObject.transform.parent.gameObject);
		}
		else
		{
			OnPlayerDeath?.Invoke();
			Destroy(gameObject);
		}
	}
}

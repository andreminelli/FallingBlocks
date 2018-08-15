using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private const int Speed = 7;
	private float screenHalfWidth;
	private float playerHalfWidth;

	public event Action OnPlayerDeath;
	public event Action OnPowerup;

	void Start ()
	{
		playerHalfWidth = transform.localScale.x / 2;
		screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
	}
	
	void Update ()
	{
		var inputX = Input.GetAxisRaw("Horizontal");
		var velocity = inputX * Speed;
		transform.Translate(Vector2.right * velocity * Time.deltaTime);

		var xMantisse = Math.Abs(transform.position.x);
		var fullHalfWidth = screenHalfWidth - playerHalfWidth;
		if (xMantisse > fullHalfWidth)
		{
			transform.position = new Vector2(fullHalfWidth * transform.position.x / xMantisse, transform.position.y);
		}

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

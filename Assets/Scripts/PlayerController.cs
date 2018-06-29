using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private const int Speed = 7;
    private float screenHalfWidth;
    private float playerHalfWidth;

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
    }
}

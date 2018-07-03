using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public GameObject GameOverScreen;

	// Use this for initialization
	void Start () {
		FindObjectOfType<PlayerController>().OnPlayerDeath += OnGameOver;
	}

	// Update is called once per frame
	void Update () {

				
	}

	public void OnGameOver()
	{
		GameOverScreen.SetActive(true);
	}
}

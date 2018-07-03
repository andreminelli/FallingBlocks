using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public GameObject GameOverScreen;
	public Text SecondsSurvivedUI;

	private bool gameOver;

	// Use this for initialization
	void Start () {
		GameOverScreen.SetActive(false);
		FindObjectOfType<PlayerController>().OnPlayerDeath += OnGameOver;
	}

	// Update is called once per frame
	void Update () {
		if (gameOver)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				SceneManager.LoadScene(0);
			}
		}
	}

	public void OnGameOver()
	{
		SecondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
		GameOverScreen.SetActive(true);
		gameOver = true;
	}
}

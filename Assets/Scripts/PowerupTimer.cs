using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupTimer : MonoBehaviour {

	public static float PowerUpTimeInSecs = 5;

	public Slider PowerupSlider;
	public Text PowerupText;

	bool isEnabled = false;
	float StartTime;

	// Use this for initialization
	void Start ()
	{
		EnablePowerupBar(false);
		PowerupSlider.value = 1;

		FindObjectOfType<PlayerController>().OnPowerup += StartPowerUp;
	}

	// Update is called once per frame
	void Update()
	{
		if (isEnabled)
		{
			PowerupText.text = "Stop falling";
			var currentPowerupValue = Mathf.Lerp(1, 0, (Time.time - StartTime) / PowerUpTimeInSecs);
			//print(currentPowerupValue);
			PowerupSlider.value = currentPowerupValue;

			if (PowerupFinished())
			{
				EnablePowerupBar(false);
				Difficulty.EnableSpawn(true);
			}
		}
	}

	private bool PowerupFinished() 
		=> PowerupSlider.value <= 0;

	private void StartPowerUp()
	{
		StartTime = Time.time;
		EnablePowerupBar(true);
		Difficulty.EnableSpawn(false);
	}

	private void EnablePowerupBar(bool enabled)
	{
		isEnabled = enabled;
		PowerupSlider.gameObject.SetActive(enabled);
	}

}

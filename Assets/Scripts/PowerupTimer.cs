using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupTimer : MonoBehaviour {

	public Slider PowerupSlider;

	public float PowerUpTimeInSecs = 5;

	bool isEnabled = false;
	float StartTime;

	// Use this for initialization
	void Start ()
	{
		SetEnable(false);
		PowerupSlider.value = 1;

		FindObjectOfType<PlayerController>().OnPowerup += StartTimer;
	}

	// Update is called once per frame
	void Update ()
	{
		if (isEnabled)
		{
			var currentPowerupValue = Mathf.Lerp(1, 0, (Time.time - StartTime) / PowerUpTimeInSecs);
			//print(currentPowerupValue);
			PowerupSlider.value = currentPowerupValue;

			if (currentPowerupValue <= 0)
			{
				SetEnable(false);
			}
		}
	}

	private void StartTimer()
	{
		SetEnable(true);
		StartTime = Time.time;
	}

	private void SetEnable(bool enabled)
	{
		isEnabled = enabled;
		PowerupSlider.gameObject.SetActive(enabled);
	}

}

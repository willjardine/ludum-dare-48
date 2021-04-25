using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	private Image healthBar;
	private Health playerHealth;

	void Awake() {
		healthBar = GetComponent<Image>();
		playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
	}

	void Update() {
		UpdateHealth(playerHealth.health);
	}

	void UpdateHealth(float value) {
		value /= 10f;
		if (value < 0f) {
			value = 0f;
		}
		healthBar.fillAmount = value;
	}
}

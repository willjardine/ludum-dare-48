using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

	public static WaveManager instance;
	public List<GameObject> waves;

	private AudioSource audioSource;

	private int currentWave;
	private int totalEnemies;
	private int enemiesKilled;

	void Awake() {
		instance = this;
		audioSource = GetComponent<AudioSource>();
	}
	public void Start() {
		currentWave = 0;
		enemiesKilled = 0;
		totalEnemies = 1;
		waves[currentWave].SetActive(true);
	}

	public void EnemyKilled() {
		audioSource.Play();
		enemiesKilled++;
		if (enemiesKilled >= totalEnemies) {
			NextWave();
		}


	}
	void NextWave() {
		waves[currentWave].SetActive(false);
		currentWave++;
		enemiesKilled = 0;
		waves[currentWave].SetActive(true);
		if (currentWave == 0) {
			totalEnemies = 1;
		} else if (currentWave == 1) {
			totalEnemies = 1;
		} else if (currentWave == 2) {
			totalEnemies = 2;
		} else if (currentWave == 3) {
			totalEnemies = 2;
		} else if (currentWave == 4) {
			totalEnemies = 1;
		} else if (currentWave == 5) {
			totalEnemies = 1;
		}
		//ScreenFlash.instance.Flash();
	}

}

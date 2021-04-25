using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
	public static EnemyManager instance;
	[SerializeField] private GameObject enemyPrefab;

	void Awake() {
		if (instance == null) {
			instance = this;
		}
	}

	public void SpawnEnemy() {
		Instantiate(enemyPrefab, transform.position, Quaternion.identity);
	}
}

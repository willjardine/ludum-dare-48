using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

	public float health = 100f;
	public bool isHitable;

	private CharacterAnimation charAnimation;
	private EnemyMovement enemyMovement;
	private PlayerMovement playerMovement;
	private bool isDead;
	private bool isPlayer;

	public void Awake() {
		charAnimation = GetComponentInChildren<CharacterAnimation>();
		enemyMovement = GetComponent<EnemyMovement>();
		playerMovement = GetComponent<PlayerMovement>();
		if (playerMovement) {
			isPlayer = true;
		}
	}

	public void Start() {
		isHitable = true;
	}

	public void ApplyDamage(float damage, bool knockDown) {
		if (isDead) {
			return;
		}
		health -= damage;

		if (health <= 0f) {
			charAnimation.Death();
			isHitable = false;
			if (isPlayer) {
				ScreenFlash.instance.Flash();
			}
			Invoke("CharacterDied", 2f);
			return;
		}

		if (knockDown) {
			if (Random.Range(0, 2) > 0) {
				charAnimation.KnockDown();
			}
		} else {
			if (Random.Range(0, 3) > 1) {
				charAnimation.Hit();
			}
		}

	}

	void CharacterDied() {
		if (isPlayer) {
			// player died
			SceneManager.LoadScene("GameOver");
		} else {
			// enemy died
			WaveManager.instance.EnemyKilled();
		}
		gameObject.SetActive(false);
	}



}
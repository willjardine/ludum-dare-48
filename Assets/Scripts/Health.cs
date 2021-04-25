using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float health = 100f;

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

	public void ApplyDamage(float damage, bool knockDown) {
		if (isDead) {
			return;
		}
		health -= damage;

		if (health <= 0f) {
			charAnimation.Death();
			if (isPlayer) {
				Debug.Log("GAME OVER!");
			}
			return;
		}

		if (!isPlayer) {
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
	}

}
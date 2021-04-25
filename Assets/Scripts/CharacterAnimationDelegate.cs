using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour {
	public GameObject punchAttackPoint;
	public GameObject kickAttackPoint;

	public float standUpTimer = 2f;
	private CharacterAnimation charAnimation;

	private AudioSource audioSource;
	[SerializeField]
	private AudioClip attackSound, knockDownSound, deathSound;

	private EnemyMovement enemyMovement;
	private PlayerMovement playerMovement;

	public void Awake() {
		charAnimation = GetComponent<CharacterAnimation>();
		audioSource = GetComponent<AudioSource>();
		enemyMovement = GetComponentInParent<EnemyMovement>();
		playerMovement = GetComponentInParent<PlayerMovement>();
	}

	void PunchAttackOn() {
		punchAttackPoint.SetActive(true);
	}

	void PunchAttackOff() {
		if (punchAttackPoint.activeInHierarchy) {
			punchAttackPoint.SetActive(false);
		}
	}

	void KickAttackOn() {
		kickAttackPoint.SetActive(true);
	}

	void KickAttackOff() {
		if (kickAttackPoint.activeInHierarchy) {
			kickAttackPoint.SetActive(false);
		}
	}

	void KnockDownPunchOn() {
		punchAttackPoint.tag = "Knock Down";
	}

	void KnockDownPunchOff() {
		punchAttackPoint.tag = "Untagged";
	}

	void StandUp() {
		StartCoroutine(StandUpAfterTime());
	}

	IEnumerator StandUpAfterTime() {
		yield return new WaitForSeconds(standUpTimer);
		charAnimation.StandUp();
	}

	public void SFX_Attack() {
		audioSource.volume = 0.5f;
		audioSource.clip = attackSound;
		audioSource.Play();
	}
	public void SFX_KnockDown() {
		audioSource.volume = 0.5f;
		audioSource.clip = knockDownSound;
		audioSource.Play();
	}
	public void SFX_Death() {
		audioSource.volume = 1f;
		audioSource.clip = deathSound;
		audioSource.Play();
	}

	public void DisableMovement() {
		if (enemyMovement) {
			enemyMovement.enabled = false;
		}
		if (playerMovement) {
			playerMovement.enabled = false;
		}
	}
	public void EnableMovement() {
		if (enemyMovement) {
			enemyMovement.enabled = true;
		}
		if (playerMovement) {
			playerMovement.enabled = true;
		}
	}
}

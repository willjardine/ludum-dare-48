using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	private CharacterAnimation charAnimation;
	private SpriteRenderer sprite;
	private Rigidbody rb;
	public float speed = 5f;

	private Transform playerTarget;

	public float attackDistance = 1f;
	private float chasePlayerAfterAttack = 0.5f;

	private float currentAttackTime;
	private float defaultAttackTime = 1.5f;

	private bool followPlayer;
	private bool attackPlayer;

	public void Awake() {
		charAnimation = GetComponentInChildren<CharacterAnimation>();
		sprite = GetComponentInChildren<SpriteRenderer>();
		rb = GetComponent<Rigidbody>();
		playerTarget = GameObject.FindWithTag("Player").transform;
	}


	void Start() {
		followPlayer = true;
		currentAttackTime = defaultAttackTime;
	}

	void Update() {
		Attack();
	}

	void FixedUpdate() {
		FollowTarget();
	}

	void FollowTarget() {
		if (!followPlayer) {
			return;
		}
		if (Vector3.Distance(transform.position, playerTarget.position) > attackDistance) {
			Vector3 dir = (playerTarget.position - transform.position).normalized;
			if (dir.x > 0) {
				sprite.flipX = false;
			} else if (dir.x < 0) {
				sprite.flipX = true;
			}
			rb.velocity = new Vector3(
				dir.x * speed,
				rb.velocity.y,
				dir.z * speed
			);
			if (rb.velocity.sqrMagnitude != 0) {
				charAnimation.Walk(true);
			}
		} else if (Vector3.Distance(transform.position, playerTarget.position) <= attackDistance) {
			rb.velocity = Vector3.zero;
			charAnimation.Walk(false);
			followPlayer = false;
			attackPlayer = true;
		}
	}

	void Attack() {
		if (!attackPlayer) {
			return;
		}
		currentAttackTime += Time.deltaTime;
		if (currentAttackTime > defaultAttackTime) {
			charAnimation.Attack(Random.Range(0, 3));
			currentAttackTime = 0f;
		}
		if (Vector3.Distance(transform.position, playerTarget.position) > attackDistance + chasePlayerAfterAttack) {
			attackPlayer = false;
			followPlayer = true;
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private CharacterAnimation charAnimation;
	private Rigidbody rb;
	public float walkSpeed = 1f;
	public float zSpeed = 1f;
	public bool isAttacking;

	private PlayerAttack playerAttack;


	void Awake() {
		charAnimation = GetComponentInChildren<CharacterAnimation>();
		rb = GetComponent<Rigidbody>();
		playerAttack = GetComponent<PlayerAttack>();
	}

	public void Update() {
		UpdateFlip();
		AnimateWalk();
		playerAttack.UpdateAttack();
	}

	void FixedUpdate() {
		UpdateMovement();
	}

	void UpdateMovement() {
		if (isAttacking) {
			rb.velocity = new Vector3(
				0f,
				rb.velocity.y,
				0f
			);
		} else {
			rb.velocity = new Vector3(
				Input.GetAxisRaw("Horizontal") * walkSpeed,
				rb.velocity.y,
				Input.GetAxisRaw("Vertical") * zSpeed
			);
		}
	}

	void UpdateFlip() {
		if (Input.GetAxisRaw("Horizontal") > 0) {
			transform.localScale = Vector3.one;
		} else if (Input.GetAxisRaw("Horizontal") < 0) {
			transform.localScale = new Vector3(-1f, 1f, 1f);
		}

	}

	void AnimateWalk() {
		if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) {
			charAnimation.Walk(true);
		} else {
			charAnimation.Walk(false);
		}
	}

}
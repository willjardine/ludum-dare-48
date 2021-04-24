using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private CharacterAnimation charAnimation;
	private SpriteRenderer sprite;
	private Rigidbody rb;
	public float walkSpeed = 1f;
	public float zSpeed = 1f;


	void Awake() {
		charAnimation = GetComponentInChildren<CharacterAnimation>();
		sprite = GetComponentInChildren<SpriteRenderer>();
		rb = GetComponent<Rigidbody>();
	}

	public void Update() {
		UpdateFlip();
		AnimateWalk();
	}

	void FixedUpdate() {
		UpdateMovement();
	}

	void UpdateMovement() {
		rb.velocity = new Vector3(
			Input.GetAxisRaw("Horizontal") * walkSpeed,
			rb.velocity.y,
			Input.GetAxisRaw("Vertical") * zSpeed
		);
	}

	void UpdateFlip() {
		if (Input.GetAxisRaw("Horizontal") > 0) {
			sprite.flipX = false;
		} else if (Input.GetAxisRaw("Horizontal") < 0) {
			sprite.flipX = true;
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
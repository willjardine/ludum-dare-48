using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour {

	private Animator anim;

	void Awake() {
		anim = GetComponent<Animator>();
	}

	public void Attack(int value) {
		if (value == 0) {
			Punch1();
		} else if (value == 1) {
			Punch2();
		} else if (value == 2) {
			Punch3();
		}
	}

	public void Punch1() {
		anim.SetTrigger("Punch1");
	}

	public void Punch2() {
		anim.SetTrigger("Punch2");
	}

	public void Punch3() {
		anim.SetTrigger("Punch3");
	}

	public void Walk(bool value) {
		anim.SetBool("Walk", value);
	}

	public void KnockDown() {
		anim.SetTrigger("KnockDown");
	}
	public void StandUp() {
		anim.SetTrigger("StandUp");
	}
	public void Hit() {
		anim.SetTrigger("Hit");
	}
	public void Death() {
		anim.SetTrigger("Death");
	}

}

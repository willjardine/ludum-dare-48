using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum ComboState {
	NONE,
	PUNCH_1,
	PUNCH_2,
	PUNCH_3
}

public class PlayerAttack : MonoBehaviour {

	private CharacterAnimation charAnimation;
	private bool activateTimerToReset;
	private float defaultComboTimer = 0.4f;
	private float currentComboTimer;
	private ComboState currentComboState;

	void Awake() {
		charAnimation = GetComponentInChildren<CharacterAnimation>();
	}

	public void Start() {
		currentComboTimer = defaultComboTimer;
		currentComboState = ComboState.NONE;
	}

	public void UpdateAttack() {
		ComboAttacks();
		ResetComboState();
	}

	void ComboAttacks() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (currentComboState == ComboState.PUNCH_3) {
				return;
			}
			currentComboState++;
			activateTimerToReset = true;
			currentComboTimer = defaultComboTimer;
			if (currentComboState == ComboState.PUNCH_1) {
				charAnimation.Punch1();
			} else if (currentComboState == ComboState.PUNCH_2) {
				charAnimation.Punch2();
			} else if (currentComboState == ComboState.PUNCH_3) {
				charAnimation.Punch3();
			}
		}
	}

	void ResetComboState() {
		if (activateTimerToReset) {
			currentComboTimer -= Time.deltaTime;
			if (currentComboTimer <= 0f) {
				currentComboState = ComboState.NONE;
				activateTimerToReset = false;
				currentComboTimer = defaultComboTimer;
			}
		}
	}

}

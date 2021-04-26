using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour {

	public static ShakeCamera instance;

	public float power = 0.2f;
	public float duration = 0.2f;
	public float slowDownAmount = 1f;
	private bool shouldShake;
	private float initialDuration;
	private Vector3 startPosition;

	void Awake() {
		instance = this;
	}

	void Start() {
		startPosition = transform.localPosition;
		initialDuration = duration;
	}

	void Update() {
		Shake();
	}

	void Shake() {
		if (shouldShake) {
			if (duration > 0f) {
				transform.localPosition = startPosition + Random.insideUnitSphere * power;
				duration -= Time.deltaTime * slowDownAmount;
			} else {
				shouldShake = false;
				duration = initialDuration;
				transform.localPosition = startPosition;
			}
		}
	}

	public bool ShouldShake {
		get {
			return shouldShake;
		}
		set {
			shouldShake = value;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlash : MonoBehaviour {

	public static ScreenFlash instance;
	private bool isFading;
	private CanvasGroup canvasGroup;
	private Image img;

	private float speed = 2f;

	void Awake() {
		instance = this;
		canvasGroup = GetComponent<CanvasGroup>();
		img = GetComponent<Image>();
	}

	public void Start() {
		Fade();
	}

	public void Update() {
		if (isFading) {
			canvasGroup.alpha = canvasGroup.alpha - (Time.deltaTime * speed);
			if (canvasGroup.alpha <= 0f) {
				canvasGroup.alpha = 0f;
				isFading = false;
			}
		}
	}

	public void Fade() {
		img.color = Color.black;
		canvasGroup.alpha = 1f;
		isFading = true;
	}
	public void Flash() {
		img.color = Color.red;
		canvasGroup.alpha = 1f;
		isFading = true;
	}

}

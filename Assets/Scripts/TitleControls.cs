using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleControls : MonoBehaviour {

	public string nextScene = "Level1";

	private AudioSource audioSource;
	private bool wasTriggered;

	public void Awake() {
		audioSource = GetComponent<AudioSource>();
	}

	public void Start() {
		wasTriggered = false;
	}

	public void Update() {
		if (wasTriggered) {
			return;
		}
		if (Input.GetKeyDown(KeyCode.Space)) {
			audioSource.Play();
			ScreenFlash.instance.Flash();
			wasTriggered = true;
			Invoke("NextScene", 0.5f);
		}
	}

	void NextScene() {
		SceneManager.LoadScene(nextScene);
	}


}

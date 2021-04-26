using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGoal : MonoBehaviour {

	public LayerMask collisionLayer;
	public float radius = 1f;

	public string nextScene = "Level1";

	private AudioSource audioSource;
	private bool wasTriggered;

	public void Awake() {
		audioSource = GetComponent<AudioSource>();
	}

	void Update() {
		if (wasTriggered) {
			return;
		}
		DetectCollision();
	}


	void DetectCollision() {
		Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);
		if (hit.Length > 0) {
			//print("Hit " + hit[0].gameObject.name);
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

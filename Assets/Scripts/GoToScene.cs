using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour {
	public string nextScene = "Title";
	public float waitDuration = 1f;


	void Start() {
		Invoke("NextScene", waitDuration);
	}

	void NextScene() {
		SceneManager.LoadScene(nextScene);
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour {
	public float timer = 2f;

	void Start() {
		Invoke("Deactivate", timer);
	}

	void Deactivate() {
		Destroy(gameObject);
	}

}

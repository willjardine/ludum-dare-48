using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour {

	public LayerMask collisionLayer;
	public float radius = 1f;
	public float damage = 1f;

	public GameObject hitFxPrefab;

	void Update() {
		DetectCollision();
	}

	void DetectCollision() {
		Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);
		if (hit.Length > 0) {
			//print("Hit " + hit[0].gameObject.name);
			Health health = hit[0].GetComponent<Health>();
			if (health.health > 0f && health.isHitable) {
				Instantiate(hitFxPrefab, transform.position, Quaternion.identity);
				if (gameObject.CompareTag("Knock Down")) {
					health.ApplyDamage(damage, true);
				} else {
					health.ApplyDamage(damage, false);
				}
				gameObject.SetActive(false);
			}

		}
	}

}

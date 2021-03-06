﻿using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	public int hp = 1;
	public bool isEnemy = true;

	public void Damage(int damageCount) {
		hp -= damageCount;
		if (hp <= 0) {
			SpecialEffectsHelper.Instance.Explosion(transform.position);
			SoundEffectsHelper.Instance.MakeExplosionSound();
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript> ();
		Debug.Log ("OnTriggerEnter2D");
		if (shot != null) {
			if (shot.isEnemyShot != isEnemy) {
				Debug.Log ("is enemy");
				Damage (shot.damage);
				Destroy (shot.gameObject);
			}
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

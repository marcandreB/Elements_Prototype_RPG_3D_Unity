using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FireSpellController : MonoBehaviour {

	public float burnTime = 3;
	public float burnDamage = 10;
	private Renderer renderer;
	private Rigidbody rigidBody;
	private Golem burnee;
	private float remainingBurn;

	void Start () {
		this.renderer = GetComponent<Renderer> ();
		this.rigidBody = GetComponent<Rigidbody> ();
		burnee = null;
		remainingBurn = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(burnee != null){
			remainingBurn -= Time.deltaTime;
			if (remainingBurn > 0) {
				burnee.TakeDamages (burnDamage);
			} else {
				Destroy (this.gameObject);
			}
		}
	}

	public void OnTriggerEnter(Collider other){
		Golem golem = other.gameObject.GetComponent<Golem> ();
		if (golem != null) {
			burnee = golem;
			remainingBurn = burnTime;
			this.renderer.enabled = false;
			this.rigidBody.detectCollisions = false;
		}
	}
}

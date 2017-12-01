using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpellController : MonoBehaviour {

	public float freezeTime = 4;

	void OnTriggerEnter(Collider other){
		Golem golem = other.gameObject.GetComponent<Golem> ();
		if (golem != null) {
			golem.Freeze(freezeTime);
		}
		Destroy (this.gameObject);
	}
}

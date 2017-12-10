using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarController : MonoBehaviour {

	private Transform healthBar;

	// Use this for initialization
	void Start () {
		healthBar = GetComponentInChildren<Image> ().transform;
	}
	
	public void SetHealthPercentage(float percentage){
		Vector3 scale = healthBar.localScale;
		scale.x = percentage;
		healthBar.localScale = scale;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarController : MonoBehaviour {

	private Transform healthBar;
	private Vector3 originalScale;

	// Use this for initialization
	void Start () {
		healthBar = GetComponentInChildren<Image> ().transform;
		originalScale = healthBar.localScale;
	}
	
	public void SetHealthPercentage(float percentage){
		Vector3 scale = originalScale;
		scale.x *= percentage;
		healthBar.localScale = scale;
	}
}

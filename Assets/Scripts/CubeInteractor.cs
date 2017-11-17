using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteractor : MonoBehaviour, IInteractable {

	private Material material;


	// Use this for initialization
	void Start () {
		material = transform.GetComponent<Renderer> ().material;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void IInteractable.Interacted (){
		Destroy (gameObject);
	}

	void IInteractable.HoverBegin(){
		material.color = Color.red;
	}

	void IInteractable.HoverEnd(){
		material.color = Color.blue;
	}
}

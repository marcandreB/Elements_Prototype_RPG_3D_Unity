using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookEvent : MonoBehaviour {

	public float Distance;
	private Sprite MySprite;
	private Texture BookImage;
	private GameObject spawn1;
	private GameObject spawn2;
	private GameObject spawn3;
	public Transform Prefab;
	private GameObject player;

	// Use this for initialization
	void Start () {
		spawn1 = GameObject.Find ("SpawnLocation");
		spawn2 = GameObject.Find ("SpawnLocation1");
		spawn3 = GameObject.Find ("SpawnLocation2");
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		Distance = Vector3.Distance(transform.position, player.transform.position);

		if (Distance <= 5) {
			Transform spawn1Location = spawn1.transform;
			Debug.Log (Distance);
			Instantiate (Prefab, spawn1Location);
		}
	}
		
}

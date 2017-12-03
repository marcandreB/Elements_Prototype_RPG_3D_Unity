using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

	public GameObject FireBall;
	public GameObject Player;
	public GameObject SpawnUp;
	public GameObject SpawnDown;
	public float attackDamages;
	public enum State{Casting, Attacking, Idle, Hidden, BeforeCombat}

	// Use this for initialization
	void Start () {
		State = State.BeforeCombat;
	}
	
	// Update is called once per frame
	void Update () {
		switch (State)
		{
		case State = State.BeforeCombat:
			if (Vector3.Distance (playerTransform.position, this.transform.position) < 30)
				State = State.Idle;
			break;
	}
}

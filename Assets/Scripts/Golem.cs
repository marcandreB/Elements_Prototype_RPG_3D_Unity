using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour {

	public Transform playerTransform;
	public GameObject player;
	private Animator animator;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerTransform = player.transform;
		animator = GetComponent<Animator> ();
	}

	void Update()
	{

		chasePlayer ();
		attackPlayer ();


	}



	void chasePlayer(){
		if (Vector3.Distance (playerTransform.position, this.transform.position) < 30) {
			Vector3 direction = playerTransform.position - this.transform.position;

			this.transform.rotation = Quaternion.Slerp (this.transform.rotation,
				Quaternion.LookRotation (direction), 0.1f); 

			if (direction.magnitude > 2) {
				animator.SetBool ("RunBool", true);
				this.transform.Translate (0, 0, 0.05f);

			}

		} else {
			animator.SetBool ("RunBool", false);
		}
	}

	void attackPlayer(){
		if (Vector3.Distance(playerTransform.position, this.transform.position) < 6)
		{
			animator.SetTrigger ("AttackTrigger");
		}
	}

}
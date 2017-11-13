using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour {

	public Transform playerTransform;
	public GameObject player;
	private Animator animator;
    public float health;
    public bool isDead = false;
    public float pushBackSpeed;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerTransform = player.transform;
		animator = GetComponent<Animator> ();
        health = 100;
	}

    void Update()
    {
        if (health > 0) { 
        chasePlayer();
        attackPlayer();
        }
        else
        {
            die();
        }

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

    public void TakeDamages(float damages)
    {
        this.health -= damages;
        if (health <= 0) {
            die();
        }
        animator.SetTrigger("GetHitted");
        Debug.Log("Hitted");
        Debug.Log(transform.position);
            

    }

    void die()
    {
        if (isDead == false)
            animator.SetTrigger("Die");
        Debug.Log("Golem death");
        isDead = true;

    }


}
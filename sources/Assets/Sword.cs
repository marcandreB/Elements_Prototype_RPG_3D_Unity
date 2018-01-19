using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    public Transform player;
    public GameObject enemy;
    public float DamageByHit;
    public GameObject script;
    private Animator animator;
    public GameObject Boss;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = player.GetComponent<Animator>();
        Boss = GameObject.FindGameObjectWithTag("Boss");
    }
	
	// Update is called once per frame
	void Update () {
		    
	}

    //On souhaite le collider seulement lorsquon attaque
    
    private void OnTriggerEnter(Collider collider)
    {
        if (animator.GetCurrentAnimatorStateInfo(1).IsName("Attack1") || animator.GetCurrentAnimatorStateInfo(1).IsName("Attack2"))
        {
            if (collider.gameObject.tag == "Enemy")
            {
                collider.GetComponent<Golem>().TakeDamages(DamageByHit);
                Debug.Log(collider + " Took damages for " + DamageByHit + " and health remaining = " + collider.GetComponent<Golem>().health);
                collider.GetComponent<Golem>().Knockback(5);

            }

            if (collider.gameObject.tag == "Boss")
            {
                Boss.GetComponent<Boss>().TakeDamages(DamageByHit);
                Debug.Log(collider + " Took damages for " + DamageByHit + " and health remaining = " + collider.GetComponent<Boss>().Health);

            }
        }
    }
		
}

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

    public float colourChangeDelay = 0.7f;
    public float currentDelay = 0f;
    public bool colourChangeCollision = false;
    public float hitDamages;

    private GameObject music;

    void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerTransform = player.transform;
		animator = GetComponent<Animator> ();
        health = 100;

		music = transform.Find("BossMusicZone").gameObject;
        //music = GetComponent<ZoneMusic>().transform.gameObject;
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
        colorChangeOnHit();

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
        colourChangeCollision = true;
        currentDelay = Time.time + colourChangeDelay;

    }

    void die()
    {
        if (isDead == false)
            animator.SetTrigger("Die");
        //Debug.Log("Golem death");
        isDead = true;
        Destroy(music);
    }

    public void Knockback(float amount)
    {
        //A modifier, marche pas tres bien
        //GetComponent<Rigidbody>().AddForce(Vector3.back * amount, ForceMode.VelocityChange);
    }

    public void colorChangeOnHit()
    {
        if (colourChangeCollision)
        {
            transform.GetComponent<Renderer>().material.color = Color.red;
            if (Time.time > currentDelay)
            {
                transform.GetComponent<Renderer>().material.color = Color.white;
                colourChangeCollision = false;
                Debug.Log("Retour au blanc");
            }
            Debug.Log("Changer couleur");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"){
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")){
                player.GetComponent<PlayerController>().getHitted(hitDamages);
            }
        }
    }


}

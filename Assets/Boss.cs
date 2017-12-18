using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthbarController))]
public class Boss : MonoBehaviour {

	public GameObject FireBall;
	public GameObject Player;
	public GameObject SpawnUp;
    public Animator animator;
	public GameObject SpawnDown;
	public float attackDamages;
    public float Health;
    public float maxHealth;
    public enum State{Casting, Attacking, Idle, Hidden, BeforeCombat}
    public State currentState = State.Attacking;
	private HealthbarController healthbar;
    private float castCooldown = 4;
    private GameObject fireBall;
    private bool isDead = false;
    private float deathDestroy = 20;


    // Use this for initialization
    void Start () {
        //State = State.BeforeCombat;
        animator = GetComponent<Animator>();
		healthbar = GetComponent<HealthbarController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!isDead)
        {
            if (currentState == State.Casting)
            {
                Vector3 direction = Player.transform.position - this.transform.position;

                this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                    Quaternion.LookRotation(direction), 0.1f);
                if (castCooldown <= 0)
                    CastSpell();
                castCooldown -= Time.deltaTime;
            }
            if (currentState == State.Attacking)
            {
                chasePlayer();
                attackPlayer();
            }
        }
        else
        {
            deathDestroy -= Time.deltaTime;
            if (deathDestroy <= 0)
                Destroy(gameObject);
            transform.Translate(0, -.005f, 0);
        }

    }

    void chasePlayer()
    {
        if (Vector3.Distance(Player.transform.position, this.transform.position) < 30)
        {
            Vector3 direction = Player.transform.position - this.transform.position;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction), 0.1f);

            if (direction.magnitude > 2)
            {
                animator.SetBool("RunBool", true);
                //this.transform.Translate(0, 0, 0.05f);
            }

        }
        else
        {
            animator.SetBool("RunBool", false);
        }
    }

    void attackPlayer()
    {
        if (Vector3.Distance(Player.transform.position, this.transform.position) < 6)
        {
            animator.SetTrigger("AttackTrigger");
        }
    }

    public void TakeDamages(float damages)
    {
        Health = Mathf.Max(0, Health - damages);
        //TODO : Pour une raison obscur, ca fait planter lorsqu'il y a la barre et qu'il recoit du dégat
        //healthbar.SetHealthPercentage(Health / maxHealth);
        if (Health <= 0)
        {
            if (isDead == false)
            {
                animator.SetTrigger("Die");
                //audioSource.PlayOneShot(deathSound);
            }
            isDead = true;
            
        }
        else
        {
            animator.SetTrigger("GetHitted");
            Debug.Log(transform.position);
        }

    }

    public void CastSpell()
    {
        Debug.Log("CastSpell");
        Vector3 direction = Player.transform.position - this.transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
            Quaternion.LookRotation(direction), 0.1f);
        GameObject spellPos = GameObject.Find("SpellPosition");
        spellPos.transform.LookAt(Player.transform);
        GameObject fireball = Instantiate(FireBall, spellPos.transform);
        castCooldown = 4;

    }
}

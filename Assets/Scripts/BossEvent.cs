using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEvent : MonoBehaviour {

    public enum State { PreFight, Phase1, Phase2, Phase3, Phase4, Phase5, Phase6, Phase7 };
    public bool StartTrigger = false;
    public float bossHealth;
    public State currentState = State.PreFight;
    public GameObject Boss;
    public GameObject explosion;
    public GameObject Golem;
    private GameObject Player;

    void Start () {
        StartTrigger = false;
        Boss = GameObject.Find("boss");
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        bossHealth = GameObject.Find("boss").GetComponent<Boss>().Health;
		if (StartTrigger)
        {
            if (currentState == State.Phase1)
                phase1();
            if (currentState == State.Phase2)
                phase2();
            if (currentState == State.Phase3)
                phase3();
            if (currentState == State.Phase4)
                phase4();
            if (currentState == State.Phase5)
                phase5();
            if (currentState == State.Phase6)
                phase6();
            if (currentState == State.Phase7)
                phase7();
        }
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!StartTrigger)
            {
                StartTrigger = true;
                Debug.Log("Depart");
                currentState = State.Phase1;
            }
        }
    }

    public void phase1()
    {
        if (bossHealth < 400)
        {
       
   
            currentState = State.Phase2;
            Debug.Log("Fin phase1");
            GameObject explosionLoc = Instantiate(explosion);
            explosionLoc.transform.position = Boss.transform.position;
            Boss.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            Boss.transform.position = GameObject.Find("SouthSpawn").transform.position;
            GameObject monstre = Instantiate(Golem);
            monstre.transform.position = GameObject.Find("SpawnNorth1").transform.position;
            monstre = Instantiate(Golem, GameObject.Find("SpawnNorth2").transform);
            monstre.transform.position = GameObject.Find("SpawnNorth2").transform.position;
            monstre = Instantiate(Golem, GameObject.Find("SpawnNorth3").transform);
            monstre.transform.position = GameObject.Find("SpawnNorth3").transform.position;



        }
    }

    public void phase2()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if (enemy.GetComponent<Golem>().health > 0)
                return;
        }
        Debug.Log("meh");
        currentState = State.Phase3;
        Boss.GetComponent<Boss>().currentState = global::Boss.State.Casting;
    }

    public void phase3()
    {
        Vector3 direction = Player.transform.position - Boss.transform.position;
        if (direction.magnitude < 20)
        {
            currentState = State.Phase4;
            Boss.GetComponent<Boss>().currentState = global::Boss.State.Attacking;
        }
    }

    public void phase4()
    {
        if (bossHealth < 200)
        {
            currentState = State.Phase5;
            Debug.Log("Fin phase4");
            GameObject explosionLoc = Instantiate(explosion);
            explosionLoc.transform.position = Boss.transform.position;
            Boss.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            Boss.transform.position = GameObject.Find("SpawnNorth").transform.position;
            GameObject monstre = Instantiate(Golem, GameObject.Find("SpawnSouth1").transform);
            monstre.transform.position = GameObject.Find("SpawnSouth1").transform.position;
            monstre = Instantiate(Golem, GameObject.Find("SpawnSouth2").transform);
            monstre.transform.position = GameObject.Find("SpawnSouth2").transform.position;
            monstre = Instantiate(Golem, GameObject.Find("SpawnSouth3").transform);
            monstre.transform.position = GameObject.Find("SpawnSouth3").transform.position;
        }
    }

    public void phase5()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if (enemy.GetComponent<Golem>().health > 0)
                return;
        }
        Debug.Log("meh");
        currentState = State.Phase6;
        Boss.GetComponent<Boss>().currentState = global::Boss.State.Casting;
    }

    public void phase6()
    {
        Vector3 direction = Player.transform.position - Boss.transform.position;
        if (direction.magnitude < 20)
        {
            currentState = State.Phase7;
            Boss.GetComponent<Boss>().currentState = global::Boss.State.Attacking;
        }
    }

    public void phase7()
    {
        if (bossHealth <= 0)
            Debug.Log("GG!!!");
    }

}

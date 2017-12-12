using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEvent : MonoBehaviour {

    public enum State { PreFight, Phase1, Phase2 };
    public bool StartTrigger = false;
    public float bossHealth;
    public State currentState = State.PreFight;
    public GameObject Boss;
    public GameObject explosion;
    public GameObject Golem;

	void Start () {
        StartTrigger = false;
        Boss = GameObject.Find("boss");
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
        }
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!StartTrigger)
                StartTrigger = true;
            Debug.Log("Depart");
            currentState = State.Phase1;
        }
    }

    public void phase1()
    {
        if (bossHealth < 800)
        {
            currentState = State.Phase2;
            Debug.Log("Fin phase1");
            GameObject explosionLoc = Instantiate(explosion);
            explosionLoc.transform.position = Boss.transform.position;
            Boss.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            Boss.transform.position = GameObject.Find("SouthSpawn").transform.position;
            Instantiate(Golem);
            /*
            monstre = Instantiate(Golem, GameObject.Find("SpawnNorth2").transform);
            monstre.transform.position = GameObject.Find("SpawnNorth2").transform.position;
            monstre = Instantiate(Golem, GameObject.Find("SpawnNorth3").transform);
            monstre.transform.position = GameObject.Find("SpawnNorth3").transform.position;
            */

        }
    }

    public void phase2()
    {
        if (bossHealth < 600)
        {
            
        }
    }


}

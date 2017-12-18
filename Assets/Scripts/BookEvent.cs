using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookEvent : MonoBehaviour, IInteractable {

	public float Distance;
	private Sprite MySprite;
	private Texture BookImage;
	private GameObject spawn1;
	private GameObject spawn2;
	private GameObject spawn3;
	public Transform Prefab;
	private GameObject player;
	private GameObject Barrier;
	private GameObject bookQuest; 
	private int numberEnemyRemaining = 3;
	public bool eventStarted = false;
	[SerializeField]
	private SpellController spellController;

	// Use this for initialization
	void Start () {
		spawn1 = GameObject.Find ("SpawnLocation");
		spawn2 = GameObject.Find ("SpawnLocation1");
		spawn3 = GameObject.Find ("SpawnLocation2");
		player = GameObject.FindGameObjectWithTag ("Player");
		Barrier = GameObject.Find ("Barrier");
		bookQuest = GameObject.Find ("BookQuestCursor");
	}

	// Update is called once per frame
	void Update () {
		Distance = Vector3.Distance(transform.position, player.transform.position);

		//Si on s'approche du livre, on pop l'event
		if (Distance <= 5) {
			if (eventStarted == false) {
				eventStarted = true;
				popAnotherEnemy ();
				Debug.Log ("Event started");
			}
		}

		//On delete la barriere lorsqu'elle est dans le sol
		/*if (Barrier != null && Barrier.transform.position.y < -4.2)
			Destroy (Barrier);*/
		

	}

	//Poper les enemies apres chaque mort
	//Appele dans le script Golem.cs
	public void popAnotherEnemy(){
		if (numberEnemyRemaining == 3) {
			Transform spawn1Location = spawn1.transform;
			Instantiate (Prefab, spawn1Location);
			numberEnemyRemaining = 2;
		}
		else if (numberEnemyRemaining == 2) {
			Transform spawn2Location = spawn2.transform;
			Instantiate (Prefab, spawn2Location);
			numberEnemyRemaining =1;
		
		} else if (numberEnemyRemaining == 1) {
			Transform spawn3Location = spawn3.transform;
			Instantiate (Prefab, spawn3Location);
			numberEnemyRemaining = 0;
		}
		else if(numberEnemyRemaining == 0) {
			//Barrier.GetComponent<Animator> ().SetTrigger ("Down");
			GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			foreach (GameObject enemy in enemies){
				Destroy (enemy);
			}
            eventStarted = false;
		}
	}

		
	#region IInteractable implementation
	public void Interacted ()
	{
		if (numberEnemyRemaining == 0) {
			spellController.IsEarthSpellUnlocked = true;
			// modifier la quête 
			bookQuest.SetActive(false); 
			//TODO music
			Barrier.GetComponent<Animator> ().SetTrigger ("Down");
			Destroy (Barrier, 5);
			this.gameObject.SetActive (false);
			Destroy (this.gameObject,10);
		}
	}

	public void HoverBegin ()
	{
		Debug.Log ("Hover begin");
	}

	public void HoverEnd ()
	{
	}

	#endregion
}

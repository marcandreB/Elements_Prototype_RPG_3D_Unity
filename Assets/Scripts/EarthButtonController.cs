using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(Button))]
public class EarthButtonController : MonoBehaviour {

	private Button button;
	[SerializeField]
	private SpellController spellController;

	// Use this for initialization
	void Start () {
		button = GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (spellController.IsEarthSpellUnlocked) {
			button.image.color = Color.white;
		}
	}
}

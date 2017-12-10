using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(Button))]
public class FireSpellButtonController : MonoBehaviour {

	private Button button;
	[SerializeField]
	private SpellController spellController;

	// Use this for initialization
	void Start () {
		button = GetComponent<Button> ();
	}

	// Update is called once per frame
	void Update () {
		if (spellController.IsFireSpellUnlocked) {
			if (spellController.remainingCooldown > 0) {
				float percentageCooldown = (spellController.cooldown - spellController.remainingCooldown) / spellController.cooldown;
				button.image.color = Color.Lerp (Color.red, Color.white, percentageCooldown);	
			} else {
				button.image.color = Color.white;
			}
		}
	}
}
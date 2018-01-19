using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour {

	public bool IsEarthSpellUnlocked = false;
	public bool IsFireSpellUnlocked = false;
	public GameObject earthSpellPrefab;
	public GameObject fireSpellPrefab;
	public Transform caster;
	public float spellVelocity = 1;
	public float spellLifetime = 5;
	public float cooldown = 5;
	public float remainingCooldown;

	public void Start(){
		remainingCooldown = 0;
	}

	public void Update(){
		remainingCooldown = Mathf.Max (0, remainingCooldown - Time.deltaTime);
	}

	public void CastEarthSpell(){
		if (IsEarthSpellUnlocked) {
			Cast (earthSpellPrefab);
		}
	}

	public void CastFireSpell(){
		if (IsFireSpellUnlocked) {
			Cast (fireSpellPrefab);
		}
	}

	private void Cast(GameObject spellPrefab){
		if (!IsCoolingDown()) {
			Debug.Log ("Casting!");
			GameObject spell = Instantiate (spellPrefab);
			spell.transform.position = caster.position;
			spell.transform.forward = caster.forward;
			Rigidbody spellRigidBody = spell.GetComponent<Rigidbody> ();
			spellRigidBody.AddForce (spellVelocity * caster.forward);
			Destroy (spell, spellLifetime);
			remainingCooldown = cooldown;
		}
	}

	private bool IsCoolingDown(){
		return remainingCooldown > 0;
	}

}

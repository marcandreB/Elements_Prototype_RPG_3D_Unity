using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public float maxHitDistance=100;
	private Transform cameraTransfrom;
	private IInteractable currentObject;
	public SpellController spellController;

	// Use this for initialization
	void Start () {
		cameraTransfrom = Camera.main.transform;
		currentObject = null;
	}

	void Update(){
		if(Input.GetButton("earth")){
			spellController.CastEarthSpell ();
		}else if(Input.GetButton("fire")){
			spellController.CastFireSpell ();
		}
	}

	// Update is called once per frame
	void LateUpdate () {
		//manage hovering objects and interacting with them
		Vector3 origin = cameraTransfrom.position;
		Vector3 orientation = cameraTransfrom.forward;
		RaycastHit hitInfo;
		bool hit = Physics.Raycast (origin, orientation, out hitInfo, maxHitDistance);

		if (hit) {
			GameObject obj = hitInfo.transform.gameObject;
			IInteractable interactable = obj.GetComponent<IInteractable> ();
			if (interactable != null) {
				if (interactable != currentObject) {
					if (currentObject != null) {
						currentObject.HoverEnd ();
					}
					currentObject = interactable;
					currentObject.HoverBegin ();
				}

				if (IsClicking ()) {
					currentObject.Interacted ();
				}
			} else if (currentObject != null) {
				currentObject.HoverEnd ();
				currentObject = null;
			}
		}
	}

	private bool IsClicking(){
		return Input.GetMouseButtonDown (0);
	}
}

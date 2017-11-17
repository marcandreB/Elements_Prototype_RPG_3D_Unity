using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GateSoundbox : MonoBehaviour {
	private AudioSource audioSource;

	public void Start(){
		audioSource = GetComponent<AudioSource> ();
	}

	public void BarrierStartMove(){
		audioSource.Play ();
	}

	public void BarrierEndMove(){
		audioSource.Stop ();
	}

}

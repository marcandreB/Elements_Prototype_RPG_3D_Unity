using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class JesusSoundsBox : MonoBehaviour {


	public AudioClip runSound;
	public AudioClip walkSound;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {

	}

	void RunStart(){
		audioSource.PlayOneShot(runSound);
	}

	void WalkStart(){
		audioSource.PlayOneShot(walkSound);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	public AudioSource idleMusicSource;
	private AudioSource zoneMusicSource;
	private List<Collider> zones;
	private bool isPlaying;

	// Use this for initialization
	void Start () {
		idleMusicSource.Play ();
		zoneMusicSource = null;
		zones = new List<Collider>();
		isPlaying = false;
	}

	// Update is called once per frame
	void Update () {
		Stack<Collider> toRemove = new Stack<Collider>();
		foreach(Collider zone in zones){
			if(!zone){
				toRemove.Push(zone);
			}
		}

		while(toRemove.Count > 0){
			zones.Remove(toRemove.Pop());
		}
	}

	private void OnTriggerEnter(Collider other){
		ZoneMusic zone = other.GetComponent<ZoneMusic> ();
		//Debug.Log("Trigger enter");
		if (zone != null) {
			zones.Add(other);
			if (zones.Count == 1) {
				isPlaying = true;
				Debug.Log("Start music");
				zoneMusicSource = zone.GetZoneMusic ();
				zoneMusicSource.Play ();
				idleMusicSource.mute = true;
				//TODO fade-in zone fade-out idle
			}
		}
	}

	private void OnTriggerExit(Collider other){
		if(isPlaying){
			ZoneMusic zone = other.GetComponent<ZoneMusic> ();
			zones.Remove(other);
			if(zones.Count == 0){
				Debug.Log("Change music");
				isPlaying = false;
				idleMusicSource.mute = false;
				zoneMusicSource.Stop ();
				zoneMusicSource = null;
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	public AudioSource idleMusicSource;
	private AudioSource zoneMusicSource;
	private int zoneCount;

	// Use this for initialization
	void Start () {
		zoneCount = 0;
		idleMusicSource.Play ();
		zoneMusicSource = null;
	}

	// Update is called once per frame
	void Update () {

	}

	private void OnTriggerEnter(Collider other){
		ZoneMusic zone = other.GetComponent<ZoneMusic> ();
		Debug.Log("Trigger enter");
		if (zone != null) {
			zoneCount++;

			if (zoneCount == 1) {
				Debug.Log("Start music");
				zoneMusicSource = zone.GetZoneMusic ();
				zoneMusicSource.Play ();
				idleMusicSource.mute = true;
				//TODO fade-in zone fade-out idle
			}
		}
	}

	private void OnTriggerExit(Collider other){
		ZoneMusic zone = other.GetComponent<ZoneMusic> ();
		Debug.Log("Trigger exit");
		if (zone != null) {
			zoneCount--;
			if (zoneCount == 0) {
				Debug.Log("Stop music");
				zoneMusicSource.Stop ();
				zoneMusicSource = null;
				idleMusicSource.mute = false;
			}
		}
	}
}

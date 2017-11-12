using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneMusic : MonoBehaviour {

	[SerializeField]
	private AudioSource music;

	public AudioSource GetZoneMusic(){
		return music;
	}
}

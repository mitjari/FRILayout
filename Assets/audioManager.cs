using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class audioManager : MonoBehaviour {

	/*
	 * audio[1] -> Info zvok
	 * audio[2] -> predgovor
	 */
	private AudioSource[] audio;
	private Text hint;

	private GameObject vprasanja;

	private bool interju;
	private bool vprasanjaPrikaz;

	// Use this for initialization
	void Start () {
		audio= this.gameObject.GetComponents<AudioSource>();
		hint= GameObject.Find("VprasanjaHint").gameObject.GetComponent<Text> ();
		vprasanja= GameObject.Find("VprasanjaPanel");

		vprasanja.SetActive(false);
		hint.enabled = false;
		interju = false;

		 vprasanjaPrikaz= false;
	}
	
	// Update is called once per frame
	void Update () {

		if (interju) {
			//Obdelaj prikaz vprasanj
			if( Input.GetKeyDown("v")) vprasanjaPrikaz= !vprasanjaPrikaz;

			if( vprasanjaPrikaz ){
				//Prikazi seznam vprasanj in odmakni hint
				hint.enabled= false;
				vprasanja.SetActive(true);
			}else{
				//skrij seznam vprasanj in prikazi hint
				hint.enabled= true;
				vprasanja.SetActive(false);
			}

			//Obdelaj vprasanja
			//Ugasni vse zvoke razen ambientne glasbe ki jo samo stisaj
			int stVprasanja= 0;
			if( Input.GetKey("1")) stVprasanja= 3;

			if( stVprasanja > 0 ){
				foreach( AudioSource zvok in audio ) {
					if( zvok.isPlaying ) zvok.Stop();
				}
				audio[stVprasanja].Play();
			}

		} else {
			//Intevju onemogocen preveri ali ga lahko omogocis
			if (!audio [2].isPlaying){
				interju = true;
				hint.enabled= true;
				audio[1].Play();

			}else{
				interju = false;
				hint.enabled= false;
			}
		}
	}
}
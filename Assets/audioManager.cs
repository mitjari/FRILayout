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

	bool delayActive= false;

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

				//Resetiraj barvo vprasanj
				if( !delayActive){
					Text[] vprasanjaTxt= vprasanja.transform.GetComponentsInChildren<Text>();
					foreach( Text vprasanjeTxt in vprasanjaTxt){
						vprasanjeTxt.color= new Color(0, 0, 0);
					}
				}
			}else{
				//skrij seznam vprasanj in prikazi hint
				hint.enabled= true;
				vprasanja.SetActive(false);
			}


			//Obdelaj vprasanja
			//Ugasni vse zvoke razen ambientne glasbe ki jo samo stisaj
			int stVprasanja= 0;
			if( Input.GetKeyDown("0")) stVprasanja= -1;
			if( Input.GetKeyDown("1")) stVprasanja= 3;
			if( Input.GetKeyDown("3")) stVprasanja= 5;
			if( Input.GetKeyDown("7")) stVprasanja= 9;

			if( stVprasanja  != 0 && !delayActive){
				foreach( AudioSource zvok in audio ) {
					if( zvok.isPlaying ) zvok.Stop();
				}

				if( stVprasanja > 0 ){
					if(vprasanjaPrikaz){
						string imeVprasanja= "Vprasanje " + (stVprasanja - 2);
						Text vprasanje= GameObject.Find(imeVprasanja).gameObject.GetComponent<Text>();
						vprasanje.color= new Color(200, 0, 0);
					}
					//Z zamikom predvajaj vprasanje
					delayActive= true;
					StartCoroutine(playAudio(0.5f, stVprasanja));
				}
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

	IEnumerator playAudio(float delayTime, int stVprasanja)	{
		yield return new WaitForSeconds(delayTime);
		audio[stVprasanja].Play();
		vprasanjaPrikaz = false;
		delayActive = false;
	}
}
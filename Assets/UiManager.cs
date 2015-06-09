using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {

	private string status;
	private bool enabled;

	private AudioSource[] audioSources;

	private Image InfoImg;
	private GameObject panel;
	private Image tabla;

	private Text textPonizani;
	private Text textLabod;
	private Text textSvet;
	private Text textRibaraca;
	private Text textZirafa;



	// Use this for initialization
	void Start () {
		status = null;
		enabled = false;

		tabla = this.transform.Find("Tabla").gameObject.GetComponent<Image> ();
		InfoImg = this.transform.Find("InfoImg").gameObject.GetComponent<Image> ();
		audioSources= GameObject.Find("FPSController").gameObject.GetComponents<AudioSource>();
		panel= this.transform.Find ("PanelBlur").gameObject;

		textPonizani= this.transform.Find("TextPonizani").gameObject.GetComponent<Text> ();
		textLabod= this.transform.Find("TextLabod").gameObject.GetComponent<Text> ();
		textSvet= this.transform.Find("TextSvet").gameObject.GetComponent<Text> ();
		textRibaraca= this.transform.Find("TextRibaraca").gameObject.GetComponent<Text> ();
		textZirafa= this.transform.Find("TextZirafa").gameObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (status != null && Input.GetKeyDown ("i")) enabled = !enabled;
		panel.SetActive (enabled);
		tabla.enabled= enabled;

		if (enabled) {
			if (status == "PONIZANI") textPonizani.enabled= true;
			else if( status == "LABOD" ) textLabod.enabled= true;
			else if( status == "SVET") textSvet.enabled= true;
			else if( status == "RIBARACA" ) textRibaraca.enabled= true;
			else if( status == "ZIRAFA" ) textZirafa.enabled= true;
		}else{
			//Izklopi vse informacije
			textPonizani.enabled= false;
			textLabod.enabled= false;
			textSvet.enabled= false;
			textRibaraca.enabled= false;
			textZirafa.enabled= false;

		}
	}

	public void showInfo( string txt){
		status = txt;
		InfoImg.enabled = true;
		audioSources [1].Play ();
	}

	public void hideInfo( string txt){
		status = null;
		enabled = false;
		InfoImg.enabled = false;
	}
}

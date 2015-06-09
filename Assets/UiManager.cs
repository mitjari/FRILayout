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
	private Text textZirafa;

	// Use this for initialization
	void Start () {
		status = null;
		enabled = false;

		tabla = this.transform.Find("Tabla").gameObject.GetComponent<Image> ();
		InfoImg = this.transform.Find("InfoImg").gameObject.GetComponent<Image> ();
		audioSources= GameObject.Find("FPSController").gameObject.GetComponents<AudioSource>();
		panel= this.transform.Find ("PanelBlur").gameObject;
		textZirafa= this.transform.Find("TextZirafa").gameObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (status != null && Input.GetKeyDown ("i")) enabled = !enabled;
		panel.SetActive (enabled);
		tabla.enabled= enabled;

		if (enabled) {
			if (status == "ZIRAFA") {
				textZirafa.enabled= true;
			}
		}else{
			//Izklopi vse informacije
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

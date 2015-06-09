using UnityEngine;
using System.Collections;

public class triggerActionSvet : MonoBehaviour {

	public GameObject uiCanvas;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter (Collider other){
		UiManager uiManger = uiCanvas.GetComponent<UiManager>();
		uiManger.showInfo ("SVET");
	}
	
	void OnTriggerExit (Collider other){
		UiManager uiManger = uiCanvas.GetComponent<UiManager>();
		uiManger.hideInfo ("SVET");
	}
}

using UnityEngine;
using System.Collections;

public class triggerActionLabod : MonoBehaviour {

	public GameObject uiCanvas;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter (Collider other){
		UiManager uiManger = uiCanvas.GetComponent<UiManager>();
		uiManger.showInfo ("LABOD");
	}
	
	void OnTriggerExit (Collider other){
		UiManager uiManger = uiCanvas.GetComponent<UiManager>();
		uiManger.hideInfo ("LABOD");
	}
}

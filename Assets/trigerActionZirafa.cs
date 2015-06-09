using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class trigerActionZirafa : MonoBehaviour {

	public GameObject uiCanvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other){
		UiManager uiManger = uiCanvas.GetComponent<UiManager>();
		uiManger.showInfo ("ZIRAFA");
	}

	void OnTriggerExit (Collider other){
		UiManager uiManger = uiCanvas.GetComponent<UiManager>();
		uiManger.hideInfo ("ZIRAFA");
	}
}

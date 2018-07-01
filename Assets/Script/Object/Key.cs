using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	public GameObject OpenPanel = null;

	public GameObject key;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Player") {

			/*
			_animator.SetBool ("open", true);

			Debug.Log (_animator.GetBool("open"));*/

			OpenPanel.SetActive (true);
		}

	}

	void OnTriggerExit(Collider other) {

		if (other.tag == "Player") {
			
			OpenPanel.SetActive (false);

		}

	}

	private bool IsOpenPanelActive {

		get {

			return OpenPanel.activeInHierarchy;
		} 
	}
	
	// Update is called once per frame
	void Update () {

		if (IsOpenPanelActive) {

			if (Input.GetKeyDown (KeyCode.E)) {

				OpenPanel.SetActive (false);

				key.SetActive(false);
			}

		}

	}
}

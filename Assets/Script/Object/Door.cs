using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
	
	//public Animation hingehere;

	private Animator _animator;

	public GameObject OpenPanel = null;

	// Use this for initialization
	void Start () {

		//Debug.Log ("hit");
	
		_animator = GetComponent<Animator>();

		Debug.Log (_animator.GetBool("open"));


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

			_animator.SetBool ("open", false);
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
				_animator.SetBool ("open", true);


			}

		}


	}
}

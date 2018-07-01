using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor1 : MonoBehaviour {

	public GameObject OpenPanel = null;

	public GameObject Key;

	public bool checkInside = false;
	public bool checkLocked = false;

	private Animator _animator;



	// Use this for initialization
	void Start () {

		_animator = GetComponent<Animator>();

	}

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Player") {



			/*
			_animator.SetBool ("open", true);

			Debug.Log (_animator.GetBool("open"));*/

			checkInside = true;


		}

	}

	void OnTriggerExit(Collider other) {

		if (other.tag == "Player") {

			_animator.SetBool ("open", false);
			checkInside = false;

		}



	}

	private bool IsOpenPanelActive {

		get {

			return OpenPanel.activeInHierarchy;
		} 
	} 
	
	// Update is called once per frame
	void Update () {

		if (checkInside == true && Key.activeInHierarchy == true && Input.GetKey (KeyCode.E)) {

			OpenPanel.SetActive (true);

		} else if (checkInside == true && Key.activeInHierarchy == false && Input.GetKey (KeyCode.E)) {

			OpenPanel.SetActive (false);

			_animator.SetBool ("open", true);

		} else {

			OpenPanel.SetActive (false);
		}

	}


}

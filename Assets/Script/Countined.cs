using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Countined : MonoBehaviour {

	// Use this for initialization
	public GameObject OpenPanel = null;

	public AudioClip Sound;
	public float Volume;
	AudioSource audio;
	public bool alreadyPlayed = false;

	// Use this for initialization
	void Start () {

		audio = GetComponent<AudioSource> ();

	}

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Player") {

			if (!alreadyPlayed) 
			{
				audio.PlayOneShot (Sound, Volume);
				alreadyPlayed = true;

			}

			Invoke ("Conversation", 3f);

			Invoke ("NextStage", 5f);

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

	void Conversation ()
	{

		OpenPanel.SetActive (true);

	} 

	void NextStage ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

	// Update is called once per frame
	void Update () {

		if (IsOpenPanelActive) {

			if (Input.GetKeyDown (KeyCode.E)) {

				OpenPanel.SetActive (false);

			}

		}

	}
}

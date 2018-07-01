using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skeleton : MonoBehaviour {

	public float speed;
	private float waitTime;
	public float startWaitTime;

	public GameObject player;

	static Animator _animator;

	public Transform[] moveSpots;
	private int randomSpot;

	public bool findPlayer = false; 

	// Use this for initialization
	void Start () {

		waitTime = startWaitTime;

		randomSpot = Random.Range (0, moveSpots.Length);

		player = GameObject.Find ("player");

		_animator = GetComponent<Animator> ();
		
	}

	// Update is called once per frame
	void Update () {

		// chase player

		Vector3 direction = player.transform.position - this.transform.position;

		float angle = Vector3.Angle (direction, this.transform.forward);

		if (Vector3.Distance (player.transform.position, this.transform.position) < 10 && angle < 80) {

			findPlayer = true;

		} else {

			findPlayer = false;

		} 

			if (findPlayer == true)
			{

				direction.y = 0;

				this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);

				if (direction.magnitude > 1) {

					this.transform.Translate (0, 0, 0.01f);

					_animator.SetBool ("walk", true);


				} 
			} else {

				// move between spots

				transform.position = Vector3.MoveTowards (transform.position, moveSpots [randomSpot].position, speed * Time.deltaTime);

				if(Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
				{

					if (waitTime <= 0) 
					{

						randomSpot = Random.Range (0, moveSpots.Length);
						waitTime = startWaitTime;
					} else {

						waitTime -= Time.deltaTime;
					} 
				}
			} 				         
	}

	void OnTriggerEnter () 
	{

		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 2);

	}
}

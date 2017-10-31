using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Animator _animator;

	void Awake() {
		_animator = GetComponent<Animator> ();

	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			// Playing the attack animation
			_animator.SetTrigger("Attack");
		}
		if (Input.GetKeyDown (KeyCode.W)) {
			_animator.SetBool ("IsRun", true);
		}
		if (Input.GetKeyUp (KeyCode.W)) {
			_animator.SetBool ("IsRun", false);
		}

	}
}

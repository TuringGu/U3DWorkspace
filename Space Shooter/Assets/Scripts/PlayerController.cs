using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]	// Make it could be seen in unity inspector
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private Rigidbody _rigidbody;
	private float nextFire;


	void Start()
	{
		_rigidbody = GetComponent<Rigidbody> ();
	}

	void Update()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}

	}


	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		_rigidbody.velocity = movement * speed;
		_rigidbody.position = new Vector3 
			(
				Mathf.Clamp(_rigidbody.position.x, boundary.xMin, boundary.xMax),
				0.0f, 
				Mathf.Clamp(_rigidbody.position.z, boundary.zMin, boundary.zMax)
			);

		_rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, _rigidbody.velocity.x * -tilt);
	}
}

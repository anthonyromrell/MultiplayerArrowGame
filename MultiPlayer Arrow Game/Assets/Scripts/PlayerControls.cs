using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

	public float MoveSpeed = 0.5f;
	public Rigidbody bPrefab = null;
	private bool charging = false;
	private Rigidbody bulletPrefab;
	private Rigidbody bulletTemp;
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MoveChar();
	}

	private void MoveChar() {
		if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
			transform.Translate(0.0f, 0.0f, MoveSpeed);
		if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
			transform.Translate(0.0f, 0.0f, -MoveSpeed);
		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
			transform.Translate(MoveSpeed, 0.0f, 0.0f);
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
			transform.Translate(-MoveSpeed, 0.0f, 0.0f);
		if(Input.GetKey(KeyCode.Space))
			Dash();
		if(Input.GetKeyDown(KeyCode.LeftShift))
			charging = true;
		if(charging == true)
			ChargeBullet();
		
	}
	
	private void Dash() {
		//TODO
	}

	private void ChargeBullet() {
		// spawn bullet no force
		// make bullet bigger
		// max size of bullet (no bigger)
		// fire on release of button
		if(charging == true) {
			if (Input.GetKeyUp(KeyCode.LeftShift)){
				Shoot();
				charging = false;
			}
		}
	}

	private void Shoot() {
		bulletPrefab = Instantiate(bPrefab, gameObject.transform.position, gameObject.transform.rotation) as Rigidbody;
		bulletPrefab.AddForce(transform.forward * 1);
	}
}

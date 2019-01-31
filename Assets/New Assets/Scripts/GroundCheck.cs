using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

	private bool isGrounded = false;
	public GameObject ball;

	void OnTriggerEnter(Collider col) {
		if(col.gameObject.tag == "Ground") {
			isGrounded = true;
			ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
			ball.GetComponent<Hit>().SetFiring(false);
		}
	}

	void OnTriggerStay(Collider col) {
		if(col.gameObject.tag == "Ground") {
			isGrounded = true;
		}
	}

	void OnTriggerExit(Collider col) {
		if(col.gameObject.tag == "Ground") {
			isGrounded = false;
			ball.GetComponent<Hit>().SetFiring(true);
		}
	}

	public bool GetGrounded() {
		return isGrounded;
	}
}

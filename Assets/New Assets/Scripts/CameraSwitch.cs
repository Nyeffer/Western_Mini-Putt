using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

	// Public Variables
	public Camera birdCam;
	public Camera player;
	public GameObject Normal;
	public GameObject BirdsEye;

	// Private Variables
	private bool isBirds = false;

	void Update() {
		birdCam.gameObject.SetActive(isBirds);
		BirdsEye.SetActive(isBirds);
		player.gameObject.SetActive(!isBirds);
		Normal.SetActive(!isBirds);
	}

	public void ChangeCam() {
		isBirds = !isBirds;
	}
}

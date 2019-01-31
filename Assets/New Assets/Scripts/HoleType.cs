using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleType : MonoBehaviour {

	public int par = 3;
	public int holeNum = 0;
	private bool isPractice;
	public string hole = " ";

	void Start() {
		PlayerPrefs.SetInt(hole, PlayerPrefs.GetInt(hole, 0));
		if(PlayerPrefs.GetInt(hole, 0) != 0) {
			isPractice = false;
		} else {
			isPractice = true;
		}
	}

	public bool GetisPrac() {
		return isPractice;
	}

	public int GetPar() {
		return par;
	}

	public int GetHoleID() {
		return holeNum;
	}

	public string holeName() {
		return hole;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIinfo : MonoBehaviour {

	public Text par;
	public Text hole;
	public Text stroke;
	public Hit player;

	void Update() {
		par.text = player.hole.GetPar().ToString();
		// Hole
		stroke.text = player.GetStroke().ToString();
	}
}

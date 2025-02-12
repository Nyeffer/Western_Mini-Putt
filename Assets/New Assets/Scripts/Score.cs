﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text text;
	public Text scoreFinal;
	private int score = 0;

	// Use this for initialization
	void Start () {
		
		for(int i = 0; i < 9; i++) {
			score += PlayerPrefs.GetInt("Hole_" + (i + 1).ToString(), 0);
			Debug.Log(score);
		}
		scoreFinal.text = (score - 32).ToString();
		text.text = score.ToString();
	}
}

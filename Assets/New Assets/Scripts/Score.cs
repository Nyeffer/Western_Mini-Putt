using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private Text text;
	private int score = 0;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		for(int i = 0; i < 9; i++) {
			score += PlayerPrefs.GetInt("Hole_" + (i + 1).ToString(), 0);
			Debug.Log(score);
		}
		text.text = score.ToString();
	}
}

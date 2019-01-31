using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour {

	public Text[] score;
	private int[] points;
	public HoleType hole;
	public Hit player;

	void Start() {
		points = new int[9];
		PlayerPrefs.SetString(hole.holeName() + "Score", PlayerPrefs.GetString(hole.holeName() + "Score", " "));
		PlayerPrefs.SetInt(hole.holeName(), (hole.GetPar() * -1) + player.GetScore());
	}

	void Update() {
		PlayerPrefs.SetString(hole.holeName() + "Score", player.WhatScore((hole.GetPar() * -1) + player.GetStroke(), hole.GetPar()));
		score[0].text = PlayerPrefs.GetString("Hole_1Score", " ");
		points[0] = PlayerPrefs.GetInt("Hole_1", 0);
		score[1].text = PlayerPrefs.GetString("Hole_2Score", " ");
		points[1] = PlayerPrefs.GetInt("Hole_2", 0);
		score[2].text = PlayerPrefs.GetString("Hole_3Score", " ");
		points[2] = PlayerPrefs.GetInt("Hole_3", 0);
		score[3].text = PlayerPrefs.GetString("Hole_4Score", " ");
		points[3] = PlayerPrefs.GetInt("Hole_4", 0);
		score[4].text = PlayerPrefs.GetString("Hole_5Score", " ");
		points[4] = PlayerPrefs.GetInt("Hole_5", 0);
		score[5].text = PlayerPrefs.GetString("Hole_6Score", " ");
		points[5] = PlayerPrefs.GetInt("Hole_6", 0);
		score[6].text = PlayerPrefs.GetString("Hole_7Score", " ");
		points[6] = PlayerPrefs.GetInt("Hole_7", 0);
		score[7].text = PlayerPrefs.GetString("Hole_8Score", " ");
		points[7] = PlayerPrefs.GetInt("Hole_8", 0);
		score[8].text = PlayerPrefs.GetString("Hole_9Score", " ");
		points[8] = PlayerPrefs.GetInt("Hole_9", 0);
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior_Menu : MonoBehaviour {

	public GameObject Menu;
	public GameObject Practice;

	void Start() {
		Debug.Log("Start");
		PlayerPrefs.SetInt("Hole_1", 0);
		PlayerPrefs.SetInt("Hole_2", 0);
		PlayerPrefs.SetInt("Hole_3", 0);
		PlayerPrefs.SetInt("Hole_4", 0);
		PlayerPrefs.SetInt("Hole_5", 0);
		PlayerPrefs.SetInt("Hole_6", 0);
		PlayerPrefs.SetInt("Hole_7", 0);
		PlayerPrefs.SetInt("Hole_8", 0);
		PlayerPrefs.SetInt("Hole_9", 0);
	}
	public void GoToPracticeMenu() {
		Menu.SetActive(false);
		Practice.SetActive(true);
	}

	public void GoBack() {
		Menu.SetActive(true);
		Practice.SetActive(false);
	}

	public void PlayPractice(int holeNum) {
		string name = "Hole_" + holeNum.ToString() + "";
		PlayerPrefs.SetInt(name, 0);
		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}

	public void Play() {
		PlayerPrefs.SetString("Hole_1Score", " ");
		PlayerPrefs.SetString("Hole_2Score", " ");
		PlayerPrefs.SetString("Hole_3Score", " ");
		PlayerPrefs.SetString("Hole_4Score", " ");
		PlayerPrefs.SetString("Hole_5Score", " ");
		PlayerPrefs.SetString("Hole_6Score", " ");
		PlayerPrefs.SetString("Hole_7Score", " ");
		PlayerPrefs.SetString("Hole_8Score", " ");
		PlayerPrefs.SetString("Hole_9Score", " ");
		PlayerPrefs.SetInt("Hole_1", 1);
		PlayerPrefs.SetInt("Hole_2", 1);
		PlayerPrefs.SetInt("Hole_3", 1);
		PlayerPrefs.SetInt("Hole_4", 1);
		PlayerPrefs.SetInt("Hole_5", 1);
		PlayerPrefs.SetInt("Hole_6", 1);
		PlayerPrefs.SetInt("Hole_7", 1);
		PlayerPrefs.SetInt("Hole_8", 1);
		PlayerPrefs.SetInt("Hole_9", 1);
		SceneManager.LoadScene("Hole_1", LoadSceneMode.Single);
	}
	
}

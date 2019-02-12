using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hit : MonoBehaviour {

	// Public Variable
	public float force = 0.0f;
	public Rigidbody rb;
	public HoleType hole;
	public GroundCheck gc;
	public GameObject beforeFiring;
	public GameObject currentlyFiring;
	public GameObject Chart;
	public Slider powerMeter;
	public int multiplier = 10;
	public string reset = " ";
	public string after = " ";
	public float timeToEnd = 3.0f;
	public GameObject ball;
	public AudioClip hitClip;
	public AudioClip HoleInOneClip;
	public AudioClip GoalClip;
	
	// Private Variables
	private int score = 0;
	private int stroke = 0;
	private float powerCounter = 0.0f;
	private bool readyToFire = false;
	private bool pos = true;
	private bool firing = false;
	private float counter = 0.0f;
	private bool Done = false;
	private bool isMoving = false;
	private bool inGoal = false;
	private Vector3 origPos;
	private AudioSource As;

	void Start() {
		origPos = gameObject.transform.position;
		As = GetComponent<AudioSource>();
		Done = false;
		score = hole.GetPar() * -1;
		beforeFiring.SetActive(true);
		currentlyFiring.SetActive(false);
		Chart.SetActive(false);
	}

	void Update() {
		ball.transform.Rotate(ball.transform.localRotation * (rb.velocity * 10), Space.Self);
		if(inGoal) {
			if(isMoving) {
				beforeFiring.SetActive(false);
				Delay(1.0f);
				isMoving = false;
			} else {
				beforeFiring.SetActive(true);
			}
		} else {
			if(rb.velocity != Vector3.zero) {
				beforeFiring.SetActive(false);
			} else {
				origPos = gameObject.transform.position;
				rb.velocity = Vector3.zero;
				Delay(0.5f);
				beforeFiring.SetActive(true);
			}
		}
		if(Done) {
			PlayerPrefs.SetInt(hole.holeName(), stroke);
			beforeFiring.SetActive(false);
			currentlyFiring.SetActive(false);
			Chart.SetActive(true);
			if(counter < timeToEnd) {
				counter += Time.deltaTime;
			} else {
				if(hole.GetisPrac()) {
					gameObject.GetComponent<PlayAd>().ShowAd();
				} else {
					WhatScore(score, hole.GetPar());
					SceneManager.LoadScene(after, LoadSceneMode.Single);
					if(after == "Menu") {
						gameObject.GetComponent<PlayAd>().ShowAd();
					}
				}
			}
		} else {
			if(!readyToFire) {
			currentlyFiring.SetActive(false);
			} else {
				beforeFiring.SetActive(false);
				currentlyFiring.SetActive(true);
				if(pos) {
					if(powerCounter < powerMeter.maxValue) {
						powerCounter += ((Time.deltaTime * 3) * multiplier);
						powerMeter.value = powerCounter;
					} else {
						multiplier *= -1;
						pos = false;
					}
				} else {
					if(powerCounter > 0.0f) {
						powerCounter += ((Time.deltaTime * 3) * multiplier);
						powerMeter.value = powerCounter;
					} else {
						multiplier *= -1;
						pos = true;
					}
				}
			}
		}
		if(stroke >= 12) {
			if(hole.GetisPrac()) {
				SceneManager.LoadScene("Menu", LoadSceneMode.Single);
			} else {
				WhatScore(score, hole.GetPar());
				SceneManager.LoadScene(after, LoadSceneMode.Single);
			}
		}
	}
	public void Shoot() {
		force = powerCounter;
		rb.AddForce(rb.gameObject.transform.forward * force, ForceMode.Impulse);
		As.PlayOneShot(hitClip, 0.4f);
		score += 1;
		stroke += 1;
		readyToFire = false;
		if(inGoal) {
			isMoving = true;
		}
	}

	public void Ready() {
		readyToFire = true;
	}

	public int GetStroke() {
		return stroke;
	}

	public int GetScore() {
		return score;
	}

	void OnTriggerEnter(Collider col) {
		if(col.gameObject.tag == "Goal") {
			As.PlayOneShot(GoalClip);
			Done = true;
		}
		if(col.gameObject.tag == "GoalFloor") {
			inGoal = true;
		}
	}

	void OnTriggerStay(Collider col) {
		if(col.gameObject.tag == "GoalFloor") {
			inGoal = true;
		}
	} 

	void OnCollisionEnter(Collision col) {
		if(col.gameObject.tag == "Death") {
			rb.velocity = Vector3.zero;
			gameObject.transform.position = origPos;
		}
		if(col.gameObject.tag == "Ground") {

		}
	}

	void OnTriggerExit(Collider col) {
		if(col.gameObject.tag == "DeathZone") {
			rb.velocity = Vector3.zero;
			gameObject.transform.position = origPos;
		}
		if(col.gameObject.tag == "GoalFloor") {
			inGoal = false;
		}
	}

	public void SetFiring(bool newVal) {
		firing = newVal;
	}

	IEnumerator Delay(float seconds)
    {
		yield return new WaitForSeconds(seconds);
    }

	public string WhatScore(int points, int par) {
		string name = " ";
		switch(par) {
			case 5:
				switch(points) {
					case -4:
						name = "Hole in One";
						As.PlayOneShot(HoleInOneClip);
						As.loop = false;
					break;
					case -3:
						name = "Double Eagle";
					break;
					case -2:
						name = "Eagle";
					break;
					case -1:
						name = "Birdie";
					break;
					case 0:
						name = "Par";
					break;
					case 1:
						name = "Boogie";
					break;
					case 2:
						name = "Double Boogie";
					break;
					case 3:
						name = "Triple Boogie";
					break;
					case 4:
						name = " + 4";
					break;
					case 5:
						name = " + 5";
					break;
					case 6:
						name = " + 6";
					break;
					default:
					break;
				}
			break;
			case 4:
				switch(points) {
					case -3:
						name = "Hole in One";
						As.PlayOneShot(HoleInOneClip);
						As.loop = false;
					break;
					case -2:
						name = "Eagle";
					break;
					case -1:
						name = "Birdie";
					break;
					case 0:
						name = "Par";
					break;
					case 1:
						name = "Boogie";
					break;
					case 2:
						name = "Double Boogie";
					break;
					case 3:
						name = "Triple Boogie";
					break;
					case 4:
						name = " + 4";
					break;
					case 5:
						name = " + 5";
					break;
					case 6:
						name = " + 6";
					break;
					default:
					break;
				}
			break;
			case 3:
				switch(points) {
					case -2:
						name = "Hole in One";
						As.PlayOneShot(HoleInOneClip);
						As.loop = false;
					break;
					case -1:
						name = "Birdie";
					break;
					case 0:
						name = "Par";
					break;
					case 1:
						name = "Boogie";
					break;
					case 2:
						name = "Double Boogie";
					break;
					case 3:
						name = "Triple Boogie";
					break;
					case 4:
						name = " + 4";
					break;
					case 5:
						name = " + 5";
					break;
					case 6:
						name = " + 6";
					break;
					default:
					break;
				}
			break;
			default:
			break;
		}
		return name;
	}
}

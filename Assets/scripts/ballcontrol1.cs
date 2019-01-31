using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ballcontrol1 : MonoBehaviour {

    //public Transform clubObj;
	private float zforce = 3500;
    public Transform arrowObj;
    private bool isShot;
    public Rigidbody golfBall;
    public GameObject ball;
    private int shotsTaken;
    public int[] pars;
    private int parTotal;
    private int currentHole;
    public int[] score;
    public GameObject[] startPos;
    private bool inHole;
    public GameObject[] cams;
    public GameObject[] Hole2Cams;	
	public Slider PowerBar;
	private bool IsGrowing;
	private float Direction;
	public AudioSource soundEffects;
	public Button shootButton;
	private float timer;
	private const float DELAY = 5;
    public AudioSource Done;
	public Text scoreText;
	public Text parScore;
	public Text hole;
	public Text currentStroke;
	private float timerOne;
	private const float delayOne = 3;
	
   

    void addPar()
    {
        for (int i = 0; i < pars.Length; i++)
        {
            parTotal += pars[i];
        }
    }

    //score[currentHole] = pars[currentHole] - shotsTaken;

	// Use this for initialization
	void Start ()
    {
		IsGrowing = false;
		inHole = false;
        isShot = false;
        shotsTaken = 0;
        parTotal = 0;
        currentHole = 0;
		PowerBar.value = 0;
		Direction = -.6f;
		timer = DELAY;
		timerOne = delayOne;
		scoreText.text = "";
		parScore.text = pars[currentHole].ToString();
		hole.text = (currentHole + 1).ToString();
		currentStroke.text = "0";
		
	}

	public void Right(){
		ball.transform.Rotate(0, 7, 0);
	}

	public void Left(){
		ball.transform.Rotate(0, -7, 0);
	}

	public void Shoot(){
		soundEffects.Play ();
		shotsTaken++;
		currentStroke.text = shotsTaken.ToString();
		ball.transform.DetachChildren();
		shootButton.enabled = false;
		//Debug.Log(shotsTaken);
		isShot = true;
		//Debug.Log (isShot);
		//golfBall.AddRelativeForce(0, 0, zforce * PowerBar.value);
		golfBall.AddForce(transform.forward * zforce * PowerBar.value);

	}


	// Update is called once per frame
	void Update () {
		if (isShot == false) {
			if (PowerBar.value == 0 ) {
				Direction *= -1;

			}

			if (PowerBar.value == 1 ) {
				Direction *= -1;
				//PowerBar.value += Direction * Time.deltaTime;
			}

			PowerBar.value += Direction * Time.deltaTime;
		}

		if (isShot) {
			timer -= Time.deltaTime;
		}

		if(golfBall.velocity == Vector3.zero || golfBall.velocity.x < .1f)
        {
			//out of the hole
			if(timer <= 0 && inHole == false)
            {
				//Debug.Log (isShot);  
				golfBall.angularVelocity = Vector3.zero;
                ball.transform.position = transform.position;
                this.transform.parent = ball.transform;
                arrowObj.transform.parent = ball.transform;
                golfBall.transform.rotation = ball.transform.rotation;
                arrowObj.transform.position = transform.position;
				timer = DELAY;
				shootButton.enabled = true;
				PowerBar.value = 0;
				isShot = false;
				//isShot = false;
            }
			//inside the hole/ switch holes
			if(timer <= 0 && inHole == true)
            {
				timerOne -= Time.deltaTime;


				if (timerOne <= 0) {
					// switch holes
					golfBall.velocity = Vector3.zero;
					golfBall.angularVelocity = Vector3.zero;
					cams[currentHole].SetActive(false);

					currentHole++;
					hole.text = (currentHole + 1).ToString();
					parScore.text = pars[currentHole].ToString();
					timerOne = delayOne;
					currentStroke.text = "0";
					ball.transform.position = startPos[currentHole].transform.position;
					inHole = false;
					isShot = false;
					//ball.transform.position = transform.position;
					this.transform.position = ball.transform.position;
					this.transform.parent = ball.transform;
					arrowObj.transform.parent = ball.transform;
					golfBall.transform.rotation = ball.transform.rotation;
					arrowObj.transform.position = transform.position;
					cams[currentHole].SetActive(true);
					shotsTaken = 0;
					timer = DELAY;
					shootButton.enabled = true;
					PowerBar.value = 0;
					scoreText.text = "";
					isShot = false;
				}

                //Debug.Log(score[currentHole]);

            }

        }

        /*if (Input.GetButtonDown("up") && isShot == false)
        {
            shotsTaken++;
            //Debug.Log(shotsTaken);
            isShot = true;
            ball.transform.DetachChildren();
            //golfBall.AddRelativeForce(0, 0, zforce);
            golfBall.AddForce(transform.forward * zforce);

        }

        //fix
        if (Input.GetKeyDown("space"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            //Instantiate(clubObj, transform.position, clubObj.rotation);
            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
            arrowObj.GetComponent<Transform>().position = transform.position;
        }

        if (Input.GetKey("a"))
        {

            ball.transform.Rotate(0, -1, 0);
           
        }
        if (Input.GetKey("d"))
        {
            
            ball.transform.Rotate(0, 1, 0);
        }

        if (Input.GetButton("one"))
        {
            zforce += 5;
        }

        if (Input.GetButton("two"))
        {
            zforce -= 5;
        }

        if (zforce < 20)
        {
            zforce = 20;
        }

        if (zforce > 2000)
        {
            zforce = 2000;
        }*/




    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "cup")
        {            
			score[currentHole] = shotsTaken - pars[currentHole];
			displayScore ();
            inHole = true;
			Done.Play();
            //GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if(other.name == "camera trigger")
        {
            if (Hole2Cams[0].activeInHierarchy)
            {
                Hole2Cams[0].SetActive(false);
                Hole2Cams[1].SetActive(true);
            }
            else
            {
                Hole2Cams[1].SetActive(false);
                Hole2Cams[0].SetActive(true);
            }

         

        }
    }

	private void displayScore(){
		Debug.Log ("display score");
		switch (score[currentHole]) {

        case -4:
			Debug.Log ("-4");
			if (currentHole == 8) {
				scoreText.text = "HOLE IN ONE";
			}
			break;

		case -3:
			Debug.Log ("-3");
			if (currentHole == 3) {
				scoreText.text = "HOLE IN ONE";
			}

			if (currentHole == 4) {
				scoreText.text = "HOLE IN ONE";
			}

			if (currentHole == 6) {
				scoreText.text = "HOLE IN ONE";
			}

			if (currentHole == 7) {
				scoreText.text = "HOLE IN ONE";
			}
			if (currentHole == 8) {
				scoreText.text = "DOUBLE EAGLE";
			}
			break;

		case -2:
			Debug.Log ("-2");
			if (currentHole == 0) {
				scoreText.text = "HOLE IN ONE";
			}

			if (currentHole == 1) {
				scoreText.text = "HOLE IN ONE";
			}

			if (currentHole == 2) {
				scoreText.text = "HOLE IN ONE";
			}

			if (currentHole == 5) {
				scoreText.text = "HOLE IN ONE";
			}
			if (currentHole == 3) {
				scoreText.text = "EAGLE";
			}
			if (currentHole == 4) {
				scoreText.text = "EAGLE";
			}
			if (currentHole == 6) {
				scoreText.text = "EAGLE";
			}
			if (currentHole == 7) {
				scoreText.text = "EAGLE";
			}
			if (currentHole == 8) {
				scoreText.text = "EAGLE";
			}

			break;

		case -1:
			Debug.Log ("-1");
			if (currentHole == 0) {
				scoreText.text = "BIRDIE";
			}
			if (currentHole == 1) {
				scoreText.text = "BIRDIE";
			}
			if (currentHole == 2) {
				scoreText.text = "BIRDIE";
			}
			if (currentHole == 5) {
				scoreText.text = "BIRDIE";
			}
			if (currentHole == 3) {
				scoreText.text = "BIRDIE";
			}
			if (currentHole == 4) {
				scoreText.text = "BIRDIE";
			}
			if (currentHole == 6) {
				scoreText.text = "BIRDIE";
			}
			if (currentHole == 7) {
				scoreText.text = "BIRDIE";
			}
			if (currentHole == 8) {
				scoreText.text = "BIRDIE";
			}
			break;

		case 0:
			Debug.Log ("0");
			if (currentHole == 0) {
				scoreText.text = "PAR";
			}
			if (currentHole == 1) {
				scoreText.text = "PAR";
			}
			if (currentHole == 2) {
				scoreText.text = "PAR";
			}
			if (currentHole == 5) {
				scoreText.text = "PAR";
			}
			if (currentHole == 3) {
				scoreText.text = "PAR";
			}
			if (currentHole == 4) {
				scoreText.text = "PAR";
			}
			if (currentHole == 6) {
				scoreText.text = "PAR";
			}
			if (currentHole == 7) {
				scoreText.text = "PAR";
			}
			if (currentHole == 8) {
				scoreText.text = "PAR";
			}
			break;

		case 1:
			Debug.Log ("PlusOne");
			if (currentHole == 0) {
				scoreText.text = "BOGEY";
			}
			if (currentHole == 1) {
				scoreText.text = "BOGEY";
			}
			if (currentHole == 2) {
				scoreText.text = "BOGEY";
			}
			if (currentHole == 5) {
				scoreText.text = "BOGEY";
			}
			if (currentHole == 3) {
				scoreText.text = "BOGEY";
			}
			if (currentHole == 4) {
				scoreText.text = "BOGEY";
			}
			if (currentHole == 6) {
				scoreText.text = "BOGEY";
			}
			if (currentHole == 7) {
				scoreText.text = "BOGEY";
			}
			if (currentHole == 8) {
				scoreText.text = "BOGEY";
			}
			break;

		case 2:
			Debug.Log ("PlusTwo");
			if (currentHole == 0) {
				scoreText.text = "DOUBLE BOGEY";
			}
			if (currentHole == 1) {
				scoreText.text = "DOUBLE BOGEY";
			}
			if (currentHole == 2) {
				scoreText.text = "DOUBLE BOGEY";
			}
			if (currentHole == 5) {
				scoreText.text = "DOUBLE BOGEY";
			}
			if (currentHole == 3) {
				scoreText.text = "DOUBLE BOGEY";
			}
			if (currentHole == 4) {
				scoreText.text = "DOUBLE BOGEY";
			}
			if (currentHole == 6) {
				scoreText.text = "DOUBLE BOGEY";
			}
			if (currentHole == 7) {
				scoreText.text = "DOUBLE BOGEY";
			}
			if (currentHole == 8) {
				scoreText.text = "DOUBLE BOGEY";
			}
			break;

		case 3:
			Debug.Log ("PlusThree");
			if (currentHole == 0) {
				scoreText.text = "TRIPLE BOGEY";
			}
			if (currentHole == 1) {
				scoreText.text = "TRIPLE BOGEY";
			}
			if (currentHole == 2) {
				scoreText.text = "TRIPLE BOGEY";
			}
			if (currentHole == 5) {
				scoreText.text = "TRIPLE BOGEY";
			}
			if (currentHole == 3) {
				scoreText.text = "TRIPLE BOGEY";
			}
			if (currentHole == 4) {
				scoreText.text = "TRIPLE BOGEY";
			}
			if (currentHole == 6) {
				scoreText.text = "TRIPLE BOGEY";
			}
			if (currentHole == 7) {
				scoreText.text = "TRIPLE BOGEY";
			}
			if (currentHole == 8) {
				scoreText.text = "TRIPLE BOGEY";
			}
			break;

		case 4:
			Debug.Log ("PlusFour");
			if (currentHole == 0) {
				scoreText.text = "+4";
			}
			if (currentHole == 1) {
				scoreText.text = "+4";
			}
			if (currentHole == 2) {
				scoreText.text = "+4";
			}
			if (currentHole == 5) {
				scoreText.text = "+4";
			}
			if (currentHole == 3) {
				scoreText.text = "+4";
			}
			if (currentHole == 4) {
				scoreText.text = "+4";
			}
			if (currentHole == 6) {
				scoreText.text = "+4";
			}
			if (currentHole == 7) {
				scoreText.text = "+4";
			}
			if (currentHole == 8) {
				scoreText.text = "+4";
			}
			break;

		case 5:
			Debug.Log ("PlusFive");
			if (currentHole == 0) {
				scoreText.text = "+5";
			}
			if (currentHole == 1) {
				scoreText.text = "+5";
			}
			if (currentHole == 2) {
				scoreText.text = "+5";
			}
			if (currentHole == 5) {
				scoreText.text = "+5";
			}
			if (currentHole == 3) {
				scoreText.text = "+5";
			}
			if (currentHole == 4) {
				scoreText.text = "+5";
			}
			if (currentHole == 6) {
				scoreText.text = "+5";
			}
			if (currentHole == 7) {
				scoreText.text = "+5";
			}
			if (currentHole == 8) {
				scoreText.text = "+5";
			}
			break;

		case 6:
			Debug.Log ("PlusSix");
			if (currentHole == 0) {
				scoreText.text = "+6";
			}
			if (currentHole == 1) {
				scoreText.text = "+6";
			}
			if (currentHole == 2) {
				scoreText.text = "+6";
			}
			if (currentHole == 5) {
				scoreText.text = "+6";
			}
			if (currentHole == 3) {
				scoreText.text = "+6";
			}
			if (currentHole == 4) {
				scoreText.text = "+6";
			}
			if (currentHole == 6) {
				scoreText.text = "+6";
			}
			if (currentHole == 7) {
				scoreText.text = "+6";
			}
			if (currentHole == 8) {
				scoreText.text = "+6";
			}
			break;

		case 7:
			Debug.Log ("PlusSeven");
			if (currentHole == 0) {
				scoreText.text = "+7";
			}
			if (currentHole == 1) {
				scoreText.text = "+7";
			}
			if (currentHole == 2) {
				scoreText.text = "+7";
			}
			if (currentHole == 5) {
				scoreText.text = "+7";
			}
			if (currentHole == 3) {
				scoreText.text = "+7";
			}
			if (currentHole == 4) {
				scoreText.text = "+7";
			}
			if (currentHole == 6) {
				scoreText.text = "+7";
			}
			if (currentHole == 7) {
				scoreText.text = "+7";
			}
			if (currentHole == 8) {
				scoreText.text = "+7";
			}
			break;
		}
	}


}

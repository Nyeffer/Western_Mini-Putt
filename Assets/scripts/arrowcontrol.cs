using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowcontrol : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //item gets destroyed but dont know how to bring it back
        /*if (Input.GetButton("up"))
        {
            Destroy(gameObject);
        }*/

        if (Input.GetKey("a"))
        {
            transform.Rotate(0, 0, 1);
        }
        if (Input.GetKey("d"))
        {
            transform.Rotate(0, 0, -1);
        }
        if (Input.GetKeyDown("space"))
        {
            GetComponent<Transform>().eulerAngles = new Vector3(90, 0, 0);
        }
    }
}

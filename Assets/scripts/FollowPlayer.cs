using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;
    public Vector3 offset;
    
	
	// Update is called once per frame
	void Update () {
        transform.position = player.position + offset;

        if (Input.GetAxis ("Mouse ScrollWheel") > 0)
        {
            GetComponent<Camera>().fieldOfView -= 1;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            GetComponent<Camera>().fieldOfView += 1;
        }
	}
}

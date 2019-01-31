using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class VirtualJoyStick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	private Image bgImg; // Image that Signifies the limit of the Joystick
	private Image joystickImg; // The Joystick that'll move
	public GameObject player; // Player Constructor
	private Move movement; // Constructor of the Move script

	public float moveSpeed = 3.0f; // Movespeed - customable
	public float rotSpeed = 150.0f; // Rotatespeed - customable
	public bool isWalking;

	public Vector3 InputDirection { set; get; } // Constructor of the Direction from the Joystick
	private void Start() {
		bgImg = GetComponent<Image>(); // Initializing bgImg
		joystickImg = transform.GetChild(0).GetComponent<Image>(); // Initializing the Joystick from the first child
		InputDirection = Vector3.zero; // Initializing the Direction to zero
		movement = player.GetComponent<Move>(); // Initializing Move Script from the player
		isWalking = false;
	}

	void Update() {
		// Checking the Direction of the Joystick
		if (InputDirection.z > 0) { // Check if it's Up
			movement.MoveForward (Vector3.forward, moveSpeed); // Move Forward where the player is looking
		} 
		if (InputDirection.z < 0) { // Check if it's Down
			movement.MoveBackward (Vector3.forward, moveSpeed); // Move Backward that's directly behind the player
		} 
		if (InputDirection.x > 0.5) { // Check if it's Right
			movement.MoveRight (Vector3.right, moveSpeed); // Move directly to the Right 
		}
		if (InputDirection.x < -0.5) { // Check if it's Left
			movement.MoveLeft (Vector3.right, moveSpeed); // Move directly to the Left
		}
	}

	public virtual void OnDrag(PointerEventData ped) {
		Vector2 pos = Vector2.zero; // Resetting the position everytime this function is called
		if(RectTransformUtility.ScreenPointToLocalPointInRectangle( 
			bgImg.rectTransform,
			ped.position,
			ped.pressEventCamera,
			out pos)) { // Checking if the action is within the bgImg
				pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x); // setting the X position is within the bgImg
				pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y); // setting the Y position is within the bgImg

				float x = (bgImg.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1; // Check if the pivot should move left or right
				float y = (bgImg.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1; // Check if the pivot should move up or down
				
				InputDirection = new Vector3(x, 0, y); // Setting the Vector of Input direction

				InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection; // Checking if the value of Inputdirection is big enough or not
				joystickImg.rectTransform.anchoredPosition = new Vector3 (InputDirection.x * (bgImg.rectTransform.sizeDelta.x /3), 
				InputDirection.z * (bgImg.rectTransform.sizeDelta.y /3)); // Restrain the Joystick
		}

	}

	public virtual void OnPointerDown(PointerEventData ped) {
		OnDrag(ped); // Call upon touch
		isWalking = true; // Start the Walking animation
	}

	public virtual void OnPointerUp(PointerEventData ped) {
		InputDirection = Vector3.zero; // Reset the InputDirection
		joystickImg.rectTransform.anchoredPosition = Vector3.zero; // Reset the position of the Joystick
		isWalking = false; // Change the state of IsWalkiing to false to stop the Walking animation
	}
}

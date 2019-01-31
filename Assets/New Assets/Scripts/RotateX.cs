using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class RotateX : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	private Image bgImg;
	private Image joystickImg;
	public GameObject player;
	private Move movement;

	public float moveSpeed = 3.0f;
	public float rotSpeed = 150.0f;

	public Vector3 InputDirection { set; get; }
	private void Start() {
		bgImg = GetComponent<Image>();
		joystickImg = transform.GetChild(0).GetComponent<Image>();
		InputDirection = Vector3.zero;
		movement = player.GetComponent<Move>();
	}


	void Update() {
			movement.RotateUp(new Vector2(InputDirection.x, InputDirection.z), rotSpeed);
	}


	public virtual void OnDrag(PointerEventData ped) {
		Vector2 pos = Vector2.zero;
		if(RectTransformUtility.ScreenPointToLocalPointInRectangle(
			bgImg.rectTransform,
			ped.position,
			ped.pressEventCamera,
			out pos)) {
				pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
				// pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

				float x = (bgImg.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
				// float y = (bgImg.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;
				
				InputDirection = new Vector3(x, 0, 0);

				InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;
				joystickImg.rectTransform.anchoredPosition = new Vector3 (InputDirection.x * (bgImg.rectTransform.sizeDelta.x /3),
				InputDirection.z * (bgImg.rectTransform.sizeDelta.y /3));
		}
	}

	public virtual void OnPointerDown(PointerEventData ped) {
		OnDrag(ped);
	}

	public virtual void OnPointerUp(PointerEventData ped) {
		InputDirection = Vector3.zero;
		joystickImg.rectTransform.anchoredPosition = Vector3.zero;
	}
}

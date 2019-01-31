using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AutoScaler : MonoBehaviour {

		// Use this for initialization
		public GameObject scaler;
		private Vector2 formerScale;

		void Awake() {
			
		}

		void Start() {
			formerScale = scaler.GetComponent<Resize>().GetScale();
			GetComponent<RectTransform>().sizeDelta = formerScale;
			transform.localScale = new Vector3(transform.localScale.x * (scaler.GetComponent<CanvasScaler>().referenceResolution.x / formerScale.x), transform.localScale.y * (scaler.GetComponent<CanvasScaler>().referenceResolution.x / formerScale.x), transform.localScale.z);
		}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Resize : MonoBehaviour {

		// Use this for initialization
		private CanvasScaler scaler;
		private Vector2 formerScale;

		void Awake() {
			scaler = GetComponent<CanvasScaler>();
			formerScale = scaler.referenceResolution;
			scaler.referenceResolution = new Vector2(Screen.width, Screen.height);
			Debug.Log(scaler.referenceResolution / formerScale);
		}

		public Vector2 GetScale() {
			return formerScale;
		}
}

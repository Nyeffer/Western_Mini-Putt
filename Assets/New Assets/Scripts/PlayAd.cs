using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class PlayAd : MonoBehaviour {

    void Start() {
        // Advertisement.Initialize("2659783");
        #if UNITY_ANDRIOD
        Advertisement.Initialize("3016113");
        #endif
        #if UNITY_IOS
        Advertisement.Initialize("3016112");
        #endif
    }

	public void ShowAd() {
        #if UNITY_ANDRIOD
        Advertisement.Initialize("3016113");
        #endif
        #if UNITY_IOS
        Advertisement.Initialize("3016112");
        #endif
        Advertisement.Show();
        if(Advertisement.IsReady()) {
            Advertisement.Show();
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        } else {
            Advertisement.Show();
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
	}
}
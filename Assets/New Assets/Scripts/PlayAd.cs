using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class PlayAd : MonoBehaviour {

    void Start() {
       #if UNITY_ANDRIOD
        Advertisement.Initialize("3016113");
        #endif
        #if UNITY_IOS
        Advertisement.Initialize("3016112");
        #endif
    }

	public void ShowDefaultAd()
    {
        #if UNITY_ADS
        if (!Advertisement.IsReady())
        {
            Debug.Log("Ads not ready for default placement");
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
            return;
        }
        Advertisement.Show();
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        #endif
    }

    public void ShowRewardedAd()
    {
        const string RewardedPlacementId = "rewardedVideo";

        #if UNITY_ADS
        if (!Advertisement.IsReady(RewardedPlacementId))
        {
            Debug.Log(string.Format("Ads not ready for placement '{0}'", RewardedPlacementId));
            return;
        }

        var options = new ShowOptions { resultCallback = HandleShowResult };
        Advertisement.Show(RewardedPlacementId, options);
        #endif
    }

    #if UNITY_ADS
    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }

    #endif
}
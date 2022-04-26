using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsControllerScript : MonoBehaviour
{
    string GooglePlayId = "4428190";
    bool GameMode = true;
    int Count;
    public static bool RewardedVideo;
    void Start()
    {
        Advertisement.Initialize(GooglePlayId);
    }

    // Show the loaded content in the Ad Unit: 
    public void ShowAd()
    {
        Advertisement.Show();
        Count = 0;
    }

    public void CountRestarts()
    {
        Count++;

        if(Count >= 3)
        {
            ShowAd();
        }
    }

    
    public void OnUnityAdsReady()
    {
        var options = new ShowOptions { resultCallback = HandleShowResult };
        Advertisement.Show("Rewarded_Android", options);
    }

 

    public void ShowRewardedAd()
          {
      
           if (Advertisement.IsReady("Rewarded_Android"))
            {
             
              var options = new ShowOptions { resultCallback = HandleShowResult };
              Advertisement.Show("Rewarded_Android", options);
              //, options);
            }
          }

 

          private void HandleShowResult(ShowResult result)
          {
            switch (result)
            {
              case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                RewardedVideo = true;
                // Give coins etc.
                break;
              case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
              case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
            }
}}

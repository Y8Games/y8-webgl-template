using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowAd()
    {
        Debug.Log("showAd");
        AfgbetaJs.InterstialAd();
    }

    public void ShowRewardAd()
    {
        Debug.Log("showRewardAd");
        AfgbetaJs.rewardAds();
    }

    public void PauseGame()
    {
        Debug.Log("pauseGame");
    }

    public void ResumeGame()
    {
        Debug.Log("resumeGame");
    }

    public void RewardAdsCompleted()
    {
        Debug.Log("rewardAdsCompleted");
        Debug.Log("This fucntion will triger if the user watched the ads completely, we should give the rewards here");
    }

    public void RewardAdsCanceled()
    {
        Debug.Log("rewardAdsCanceled");
        Debug.Log("This fucntion will triger if the user cancel the ads before the ads completed");
    }

    public void NoRewardedAdsTryLater()
    {
        Debug.Log("NoRewardedAdsTryLater");
        Debug.Log("This fucntion will triger if theer is no ads right now");
    }
}

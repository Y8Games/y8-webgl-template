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

    public void showAd()
    {
        Debug.Log("showAd");
        AfgbetaJs.InterstialAd();
    }

    public void showRewardAd()
    {
        Debug.Log("showRewardAd");
        AfgbetaJs.rewardAds();
    }

    public void pauseGame()
    {
        Debug.Log("pauseGame");
    }

    public void resumeGame()
    {
        Debug.Log("resumeGame");
    }

    public void rewardAdsCompleted()
    {
        Debug.Log("rewardAdsCompleted");
        Debug.Log("This fucntion will triger if the user watched the ads completely, we should give the rewards here");
    }

    public void rewardAdsCanceled()
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

using UnityEngine;

public class Y8AdsListener : MonoBehaviour
{
    public static Y8AdsListener instance;
    void Awake()
    {
        // Keep this object alive across all scenes
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ----------------------------
    // Public functions to call ads
    // ----------------------------

    public void showAd()
    {
        Debug.Log("showAd");
#if !UNITY_EDITOR && UNITY_WEBGL
        y8MinimalAds.InterstitialAd();
#endif
    }

    public void showRewardAd()
    {
        Debug.Log("showRewardAd");
#if !UNITY_EDITOR && UNITY_WEBGL
        y8MinimalAds.rewardAds();
#endif
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

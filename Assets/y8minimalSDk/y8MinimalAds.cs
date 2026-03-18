using UnityEngine;
using System.Runtime.InteropServices;

public class y8MinimalAds : MonoBehaviour
{

    [DllImport("__Internal")]
    public static extern void InterstitialAd();

    [DllImport("__Internal")]
    public static extern void rewardAds();

    [DllImport("__Internal")]
    public static extern void initAds(string _AppId, string _AdsId);

    [Header("ENTER APP ID HERE")] public string AppId = "";
    [Header("ENTER ADS ID HERE")] public string AdsId = "";

    void Start()
    {
        Debug.Log("Start Afgbeta");
        init();
    }

    public void ShowInterstitialAd()
    {
        // Calling JS function
#if !UNITY_EDITOR && UNITY_WEBGL
        Debug.Log("ShowInterstitialAd");
        InterstitialAd();
#else
        Debug.Log("Skipping InterstitialAd call in Unity Editor or non-WebGL build.");
#endif
    }

    public void ShowRewardedAds()
    {
        // Calling JS function
#if !UNITY_EDITOR && UNITY_WEBGL
        Debug.Log("ShowRewardedAds");
        rewardAds();
#else
        Debug.Log("Skipping ShowRewardedAds call in Unity Editor or non-WebGL build.");
#endif
    }

    public void init()
    {
        // Calling JS function
#if !UNITY_EDITOR && UNITY_WEBGL
        Debug.Log("init");
        Debug.Log("AppId "+ AppId);
        Debug.Log("AdsId"+ AdsId);
        initAds(AppId, AdsId);
#else
        Debug.Log("Skipping initAds call in Unity Editor or non-WebGL build.");
#endif
    }
}

var y8MinimalAds = {
    InterstitialAd: function()
    {
        console.log("InterstitialAd");
        nextAds();
    },
    rewardAds: function()
    {
        console.log("rewardAds");
        showReward();
    },
    initAds: function(_appId, _adsId, testAds)
    {
        var appId = UTF8ToString(_appId);   // convert pointer → JS string
        var adsId = UTF8ToString(_adsId);
        console.log("initAds " + _adsId);
        initSdk(appId, adsId, testAds);
    }
};

mergeInto(LibraryManager.library, y8MinimalAds);
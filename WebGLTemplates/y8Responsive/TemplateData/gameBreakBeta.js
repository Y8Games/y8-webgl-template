let y8Sdk = null;
let adsReady = false;
let isGamePausedByAd = false;
// Initialize SDK (call once from Unity)
function initSdk(_appId, adsId) {

    console.log("initSdk");
    window.initMinimalSdk = function () {
        console.log("Y8 Minimal SDK loaded");
        window.addEventListener("y8sdk.ready", function () {
			if (y8Sdk) {
				console.log("Y8 already initialized");
				return;
			}
            if (window.y8 && typeof y8.sdk === "function") {
                console.log("Y8 SDK ready");
                y8Sdk = y8.sdk();

                let appConfig = {
                    appId: _appId,
                    autoLogin: false
                };
				
                let adConfig = {
                    gameId: adsId,
                    preloadAdBreaks: "auto",
                    sound: "on",
                    onReady: () => {
						adsReady = true;
                        console.log("Ads ready (minimal SDK)");
                    }
                };

                y8Sdk.init(appConfig, adConfig);
				
				y8Sdk.onAuth((user, error) => {
                    if (error) {
                        console.log("Auth error", error);
                        return;
                    }
                    console.log("User:", user);
                });
            } else {
                console.error("Y8 SDK not available");
            }

        }, { once: true });

        if (window.y8 && window.y8.emitReadyEvent) {
            window.y8.emitReadyEvent();
        }
    };

    (function (d, s, id) {

        let js, fjs = d.getElementsByTagName(s)[0];

        if (d.getElementById(id)) {
            console.log("Y8 script already added");
			if (window.y8) {
				window.initMinimalSdk();
			}
            return;
        }

        js = d.createElement(s);
        js.id = id;
        js.src = "https://cdn.y8.com/minimal-sdk/2-0/y8.min.js";
        js.async = true;
        js.onload = window.initMinimalSdk;

        fjs.parentNode.insertBefore(js, fjs);

    }(document, "script", "minimal-y8-jssdk"));
}

function nextAds() {

    if (!y8Sdk) {
        console.log("SDK not ready");
        return;
    }

    y8Sdk.showAd({
        type: "start",
        name: "start-game",

        beforeAd: () => {
            console.log("beforeAd");
            pauseGame();
        },

        afterAd: () => {
            console.log("afterAd");
			resumeGame();
        },

        adDismissed: () => {
            console.log("adDismissed");
            unitySendMessage("OnAdSkipped");
        },

        adViewed: () => {
            console.log("adViewed");
        },

        adBreakDone: (info) => {
            console.log("adBreakDone", info);
			resumeGame();
        }

    }).catch((e) => console.log("Ad error", e));
}

function showReward() {

    if (!y8Sdk) {
        console.log("SDK not ready");
        return;
    }


    y8Sdk.showAd({

        type: "reward",
        name: "reward-ad",
		
		beforeAd: () => {
            console.log("beforeAd");
            pauseGame();
        },

        afterAd: () => {
            console.log("afterAd");
			resumeGame();
        },
		
        beforeReward: function (showAdFn) {
            console.log("Reward ad starting");
            showAdFn();
        },

        adViewed: function () {
            console.log("Reward completed");
            rewardAdsCompleted();
        },

        adDismissed: function () {
            console.log("Reward ad skipped");
            rewardAdsCanceled();
        },

        adBreakDone: function (info) {
            console.log("Ad break finished", info);
			if (info && info.breakStatus) {
				switch (info.breakStatus) {
					case "frequencyCapped":
					case "noAdPreloaded":
					case "other":
						noRewardedAdsTryLater();
						break;

					case "viewed":
						// Already handled in adViewed()
						break;

					case "dismissed":
						// Already handled in adDismissed()
						break;
				}
			}
			resumeGame();
        }

    }).catch(function (e) {
        console.log("Ad error:", e);
    });
}

function pauseGame()
{
    //Pause Game Code	
    console.log("Pause Game");
	if (isGamePausedByAd) return;
	isGamePausedByAd = true;	
    myGameInstance.SendMessage('GameObjectAds', 'pauseGame');
}

function resumeGame()
{
    //Resume Game Code
    console.log("Resume Game");
	if (!isGamePausedByAd) return;
	isGamePausedByAd = false;
    myGameInstance.SendMessage('GameObjectAds', 'resumeGame');
}

function rewardAdsCompleted()
{
    console.log("rewardAdsCompleted");
    console.log("Function triggered when the ad is watched completely. Rewards should be given here.");
    myGameInstance.SendMessage('GameObjectAds', 'rewardAdsCompleted');
}

function noRewardedAdsTryLater()
{
    console.log("noRewardedAdsTryLater");
    console.log("No rewarded ad available right now. Ask user to try later.");
    myGameInstance.SendMessage('GameObjectAds', 'NoRewardedAdsTryLater');
}

function rewardAdsCanceled()
{
    console.log("rewardAdsCanceled");
     console.log("User dismissed/canceled the ad before completion.");
     myGameInstance.SendMessage('GameObjectAds', 'rewardAdsCanceled');
}

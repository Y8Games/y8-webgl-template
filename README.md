# Responsive Template with Ads

## How to set up 
1) Download the responisveWebGL template and import it into your project
2) When building for WebGL, use the Y8 template `y8Responsive` 

## To show Ads
1) Download the assets folder containing the required files.
2) Copy AfgbetaJs.jslib, AfgbetaJs.cs, and main.cs into your project.
3) Create a new GameObject named GameObjectAds. Add components to include the AfgbetaJs.cs and main.cs scripts.
   Use the following functions for ads:
     - showAd()  Call to show ads.
     - showRewardAd() Call to show rewarded ads.
     - pauseGame() Pause the game.
     - resumeGame() Resume the game.
     - rewardAdsCompleted() Trigger rewards after completing an ad.
     - NoRewardedAdsTryLater() Call if no rewarded ads are available.
     - rewardAdsCanceled() Trigger if the user cancels the rewarded ad.
4) Locate the responsiveWebGL template folder, Find gameBreakBeta.js and drag and drop it into the editor.
5) If you have your own AdSense ID, replace it in the code 
   - var AdsenseId = "ca-pub-6129580795478709"; 
   - set activateAFP to true (var activateAFP = true;)
6) If you don't have an AdSense ID, replace the Channel ID you received
   var ChannelId = "YOUR_CHANNEL_ID";
   Set activateAFP to false (var activateAFP = false;)
7) Set testAdsOn to false when the game is ready to go live (var testAdsOn = false;)

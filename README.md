# Responsive Template with Ads

## How to set up 
1) Download the responisveWebGL template and import it into your project
2) When building for WebGL, use the Y8 template `y8Responsive` 

## Ads
Y8 offers two types of revenue share models:

AFP (AdSense for Platforms) — You get paid directly by Google through your own AdSense account.

Manual Revenue Share — You send Y8 invoices, and the payment is handled manually.

To apply for AFP, first create a Studio:

Visit https://www.y8.com/studios

## To show Ads
1) Download the assets folder containing the required files.
2) Copy y8MinimalAds.jslib, y8MinimalAds.cs, and Y8AdsListener.cs into your project.
3) Create a new GameObject named GameObjectAds. Add components to include the y8MinimalAds.cs and Y8AdsListener.cs scripts.
   Use the following functions for ads:
     - showAd()  Call to show ads.
     - showRewardAd() Call to show rewarded ads.
     - pauseGame() Pause the game.
     - resumeGame() Resume the game.
     - rewardAdsCompleted() Trigger rewards after completing an ad.
     - NoRewardedAdsTryLater() Call if no rewarded ads are available.
     - rewardAdsCanceled() Trigger if the user cancels the rewarded ad.
4) Assign your App ID
   - In the Unity Inspector, select the GameObjectAds object.
   - Under the Y8 Minimal Ads (Script) component, find the field labeled “ENTER APP ID HERE”.
   - Replace it with your actual App ID
5) Assign your Ads ID
   - In the same Y8 Minimal Ads (Script) section, find the field labeled “ENTER ADS ID HERE”.
   - Enter your Game ID (also known as Ads ID).
6) Enable Test Ads
   - Check the Test Ads box to enable test mode and verify that ads are working.
   - Once testing is complete and your game is ready for release, uncheck this option to use live ads.

## Demo Source
- Download the below example Unity source for your reference:
[**Unity Example Template with Ads**](https://storage.y8.com/Gani/unity_webgl/unityAFPSample/unity_example_new_sdk.zip)

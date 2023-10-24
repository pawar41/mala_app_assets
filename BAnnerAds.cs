using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BAnnerAds : MonoBehaviour
{
    public string AndroidGameID;
    public string IOSGameID;

    string adUnitID;
    BannerPosition positionOfBanner = BannerPosition.BOTTOM_CENTER;

    void Start()
    {
        adUnitID = AndroidGameID;

        Advertisement.Banner.SetPosition(positionOfBanner);

    }

    public void loadTheBanner()
    {
        BannerLoadOptions options = new BannerLoadOptions {
            loadCallback = onBannerLoaded,
            errorCallback = onBannerLoadError
        };

        Advertisement.Banner.Load(adUnitID, options);
        
    }

    void onBannerLoaded()
    {
        Debug.Log("Banner loaded");
        showBAnnerAd(); 
    }

    void onBannerLoadError(string error)
    {
        Debug.Log("Banner AD failed to load : " + error );
    }

    public void showBAnnerAd()
    {
        BannerOptions options = new BannerOptions
        {
            showCallback = onBannerShow,
            clickCallback = onBannerClicked,
            hideCallback = onBannerHidden
        };

        Advertisement.Banner.Show(adUnitID, options); 
    }

    void onBannerShow()
    {

    }

    void onBannerClicked()
    {

    }

    void onBannerHidden()
    {
         
    }

    public void HideBAnnerAD()
    {
        Advertisement.Banner.Hide();
    }
}

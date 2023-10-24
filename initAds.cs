using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class initAds : MonoBehaviour,IUnityAdsInitializationListener
{
    public string AndroidGameID;
    public string IosGameID;

    public bool isTestingMode = true;

    string gameID;

    void Awake()
    {
        initAdsF();
    }

    void initAdsF()
    {
        gameID = AndroidGameID;

        if(!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(gameID,isTestingMode,this );
        }
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Ads initialized");
        //throw new System.NotImplementedException();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Ads initialized FAIL");

        //throw new System.NotImplementedException();
    }

}

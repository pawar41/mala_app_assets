using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class rewardedAdsð  : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public string androidAdUnityID;
    public string IOSAdUnityID;

    string adUnitID;

    void Awake()
    {
        adUnitID = androidAdUnityID;
    }


    public void loadAD()
    {
        Debug.Log("loading AD >> intertisial");
        Advertisement.Load(adUnitID, this);
    }








    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("interstial AD loaed");
        showAds(); 
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        if (placementId.Equals(adUnitID))
        {
            Debug.Log("interstial AD load : FAIL ");
        }
        //throw new System.NotImplementedException();
    }








    public void showAds()
    {
        Debug.Log("showing Ads");
        Advertisement.Show(adUnitID, this);
    }


    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("intersial showClicked");
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId.Equals(adUnitID) && showCompletionState.Equals(UnityAdsCompletionState.COMPLETED) )
        {
            Debug.Log("intersial adshow complete");
        }
        
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("intersial adshow fail");
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("intersial showStart");
        //throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

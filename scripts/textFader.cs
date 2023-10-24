using UnityEngine;
using TMPro;

public class textFader : MonoBehaviour
{
    TextMeshProUGUI TextToFade;

    public bool fadeIn, fadeOut;
    bool fadeInDone, fadeOutDone;

    float startRefTime;
    bool startTimeSetIndicator;

    public float secondsToWaitShowLogo = 2f;
    public GameObject enableSubs;
    public float speedIncrementer = 0.002f;

    // Start is called before the first frame update
    void Start()
    {
        if (enableSubs != null) {
            enableSubs.SetActive(false);
        }

        TextToFade = gameObject.GetComponent<TextMeshProUGUI>();

        if (fadeIn)
        {
            TextToFade.alpha = 0.01f;
            fadeInDone = true;
            //fadeOutDone = false;
        }

        if (fadeOut)
        {
            TextToFade.alpha = 1f;
            fadeOutDone = true;
            //fadeInDone = false;
        }

        if(fadeIn && fadeOut)
        {
            TextToFade.alpha = 0.01f;
        }

        startTimeSetIndicator = false;
        startRefTime = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIn && fadeInDone && !fadeOut) {
            fadeInFunc();
        } else if (fadeOut && fadeOutDone && !fadeIn)
        {
            fadeOutFunc();
        } else if (fadeIn && fadeOut)
        {
            if (fadeInDone) {
                fadeInFunc();
            } else if (fadeOutDone && waitFunc(secondsToWaitShowLogo)) {
                fadeOutFunc();
            }
        }

        // output
        //Debug.Log(Time.fixedTime);
    }

    bool fadeInFunc()
    {
        if (TextToFade.alpha < 0.98f)
            TextToFade.alpha += speedIncrementer;
        else
        {
            TextToFade.alpha = 1f;
            fadeInDone = false;
            //Debug.Log(fadeInDone);

        }

        return (fadeInDone);
    }

    bool fadeOutFunc()
    {
        if (TextToFade.alpha > 0.02f)
            TextToFade.alpha -= speedIncrementer;
        else
        {
            TextToFade.alpha = 0f;
            fadeOutDone = false;
            //Debug.Log(Time.fixedTime);
        }

        return(fadeOutDone);
    }

    bool waitFunc(float secondsToWait = 2f)
    {
        if (startTimeSetIndicator == false)
        {
            startRefTime = Time.fixedTime;
            startTimeSetIndicator = true;
            if (enableSubs != null)
            {
                enableSubs.SetActive(true);
            }
        }

        if(secondsToWait > (Time.fixedTime - startRefTime))
        {
            return (false);
        } else
        {
            return (true);
        }
    }
}

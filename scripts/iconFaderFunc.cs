using UnityEngine;
using UnityEngine.UI;

public class iconFaderFunc : MonoBehaviour
{
    public Image iconToFade;
    Color giverColour;

    float decrementer_alpha = 0.1f;
    bool OnlyOnceSetter;

    bool faderTrigger;

    bool fadeOutDone, fadeInDone;

    void InitializeIconFader()
    {
        giverColour = iconToFade.color;
        giverColour.a = 1f;
        iconToFade.color = giverColour;

        OnlyOnceSetter = true;
        faderTrigger = false;

        fadeOutDone = true;
        fadeInDone = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (faderTrigger)
        {
            acutualIconFader();
        }
    }

    void acutualIconFader()
    {
        if (iconToFade.color.a > 0.02f && fadeOutDone)
        {
            giverColour.a -= decrementer_alpha;
            iconToFade.color = giverColour;

            if(iconToFade.color.a <= 0.02f)
            {
                fadeOutDone = false;
            }
        }
        else
        {
            if (OnlyOnceSetter)
            {
                giverColour.a = 0;
                iconToFade.color = giverColour;

                OnlyOnceSetter = false;
            }

            //Debug.Log(Time.fixedTime);


            if (iconToFade.color.a < 0.98f && fadeInDone)
            {
                giverColour.a += decrementer_alpha;
                iconToFade.color = giverColour;

                if (iconToFade.color.a >= 0.98f)
                {
                    fadeInDone = false;
                }
            }
            else if(faderTrigger)
            {
                giverColour.a = 1f;
                iconToFade.color = giverColour;

                faderTrigger = false;
            }
        }
    }

    public void BeginIconFade()
    {
        InitializeIconFader();
        faderTrigger = true;
    }
}

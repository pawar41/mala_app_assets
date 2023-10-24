using UnityEngine;
using TMPro;



public class fader_TMP : MonoBehaviour
{
    public TextMeshProUGUI toFadeText;

    Color giverColour;

    bool onceSetter = true;
    bool doneFadeIn, doneFadeOut;

    bool fadeStatusMark = false;

    public float decrementer_alpha = 0.002f;

    void initializeFader()
    {
        //toFadeIn = gameObject.GetComponent<Image>();


        doneFadeOut = false;
        doneFadeIn = false;

        giverColour = toFadeText.color;
        giverColour.a = 1f;
        toFadeText.color = giverColour;

        /*giverColour = toFadeOut.color;
        giverColour.a = 1f;
        toFadeOut.color = giverColour;*/
    }
    void Update()
    {
        if (fadeStatusMark)
        {
            actualFader();
        }
    }

    public void beginFade()
    {
        fadeStatusMark = true;
        initializeFader();
    }

    void actualFader()
    {
        if (toFadeText.color.a > 0 && !doneFadeOut)
        {

            giverColour.a -= decrementer_alpha;
            toFadeText.color = giverColour;

            if (toFadeText.color.a < 0.02f)
            {
                doneFadeOut = true;
            }
        }
        else if (!doneFadeIn)
        {
            if (onceSetter)
            {
                giverColour = toFadeText.color;
                giverColour.a = 0;
                toFadeText.color = giverColour;
                onceSetter = false;
            }

            if (toFadeText.color.a < 0.98f)
            {
                giverColour.a += decrementer_alpha;
                toFadeText.color = giverColour;
            }
            else if (toFadeText.color.a > 0.98f)
            {
                giverColour.a = 1f;
                toFadeText.color = giverColour;

                fadeStatusMark = false;
            }
        }
    }
}
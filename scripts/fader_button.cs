using UnityEngine;
using UnityEngine.UI;

public class fader_button : MonoBehaviour
{
    public Image toFadeOut;
    public Image toFadeIn;

    Color giverColour;

    bool onceSetter = true;

    public float decrementer_alpha = 0.002f;

    void Start()
    {
        //toFadeIn = gameObject.GetComponent<Image>();

        

        giverColour = toFadeIn.color;
        giverColour.a = 0;
        toFadeIn.color = giverColour;

        giverColour = toFadeOut.color;
        giverColour.a = 1f;
        toFadeOut.color = giverColour;
    }
    void Update()
    {
        if (toFadeOut.color.a > 0) {
            
            giverColour.a -= decrementer_alpha;
            toFadeOut.color = giverColour;
        } else
        {
            if (onceSetter)
            {
                giverColour = toFadeIn.color;
                onceSetter = false;
            }

            if (toFadeIn.color.a < 1)
            {
                giverColour.a += decrementer_alpha;
                toFadeIn.color = giverColour;
            } else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
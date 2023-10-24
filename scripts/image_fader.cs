using UnityEngine;
using UnityEngine.UI;


public class image_fader : MonoBehaviour
{
    Image toFadeImage;
    Color giverColour;

    public float decrementer_alpha = 0.002f;

    void Start()
    {
        toFadeImage = gameObject.GetComponent<Image>();

        giverColour = toFadeImage.color;
        giverColour.a = 1f;
        

    }
    void Update()
    {
        if (toFadeImage.color.a > 0.02f) {
            toFadeImage.color = giverColour;
            giverColour.a -= decrementer_alpha;
        } else
        {
            giverColour.a = 0;
            toFadeImage.color = giverColour;

            gameObject.SetActive(false);
        }
    }
}